'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'
'Date: June 2002
'Author: Duncan Mackenzie
'
'Requires the release version of .NET Framework


Imports Microsoft.MSDN.Samples.GraphicObjects
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.Serialization



<System.Serializable()> Public Class GraphicsSurface
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub

    'UserControl1 overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'GraphicsSurface
        '
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Name = "GraphicsSurface"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Events"

    Public Event SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
    Public Event StatusUpdate(ByVal sender As Object, ByVal e As StatusUpdateEventArgs)
#End Region

    Private Const MinimumGridSize As Single = 10
    Private dragOffset As New Point(0, 0)
    Private dragStart As New Point(0, 0)

    Private selectionDragging As Boolean = False
    Private selectable As Boolean = True
    Private dragging As Boolean = False
    Private draggingfs As Boolean = False
    Private rotating As Boolean = False
    Private hoverdraw As Boolean = False
    Private startingRotation As Single = 0
    Private originalRotation As Single = 0
    Private selectionRect As Rectangle
    Private hoverRect As Rectangle

    Private justselected As Boolean = False

    Private m_SurfaceBounds As New Rectangle(0, 0, 10000, 7000)
    Private m_SurfaceMargins As New Rectangle(10, 10, 10000, 7000)
    Public m_HorizRes As Integer = 300
    Public m_VertRes As Integer = 300
    Private m_ShowGrid As Boolean = True
    Private m_NonPrintingAreaColor As Color = Color.Gray
    Private m_GridColor As Color = Color.LightBlue
    Private m_GridSize As Single = 100
    Private m_GridLineWidth As Integer = 1
    Private m_MarginLineWidth As Integer = 1
    Private m_MarginColor As Color = Color.Green
    Private m_SelectedObject As GraphicObject
    Private m_Zoom As Single = 0.5

    Private m_snaptogrid As Boolean = False
    Private m_mousehoverselect As Boolean = False
    Private m_quickconnectmode As Boolean = False

    Public m_drawingObjects As New GraphicObjectCollection()

    Public m_SelectedObjects As New Collections.Generic.Dictionary(Of String, GraphicObject)

#Region "Saving / Loading"

    Public Overridable Sub LoadFromFile(ByVal fileName As String)
        'load objects from a binary file
        Try
            Dim settingsPath As String = fileName
            Dim myBinarySerializer As New Formatters.Binary.BinaryFormatter()
            m_drawingObjects = myBinarySerializer.Deserialize( _
                New IO.FileStream(settingsPath, IO.FileMode.Open))
            Me.SelectedObject = Nothing
            RaiseEvent StatusUpdate(Me, _
                New StatusUpdateEventArgs(StatusUpdateType.FileLoaded, _
                Nothing, String.Format("file {0} loaded into the Graphic Surface", fileName), _
                Nothing, Nothing))
            Me.Invalidate()
        Catch e As Exception
            Throw New ApplicationException("File failed to load.", e)
        End Try

    End Sub


    Public Overridable Sub SaveToFile(ByVal fileName As String)
        'save objects to a binary file
        Try
            Dim settingsPath As String = fileName
            Dim myBinarySerializer As New Formatters.Binary.BinaryFormatter()
            myBinarySerializer.Serialize( _
                New IO.FileStream(settingsPath, IO.FileMode.Create), _
                Me.drawingObjects)
            RaiseEvent StatusUpdate(Me, _
                New StatusUpdateEventArgs(StatusUpdateType.FileSaved, _
                m_SelectedObject, _
                String.Format("Graphic Surface saved to file {0}", fileName), _
                Nothing, Nothing))
        Catch e As Exception
            Throw New ApplicationException("Save Failed.", e)
        End Try
    End Sub

#End Region

    Public Property QuickConnect() As Boolean
        Get
            Return m_quickconnectmode
        End Get
        Set(ByVal value As Boolean)
            m_quickconnectmode = value
        End Set
    End Property

    Public Property SurfaceBounds() As Rectangle
        'bounds in 1/100ths of an inch, just like the printer objects use
        Get
            Return m_SurfaceBounds
        End Get
        Set(ByVal Value As Rectangle)
            m_SurfaceBounds = Value
            Me.Invalidate()
        End Set
    End Property

    Public Property SnapToGrid() As Boolean
        Get
            Return m_snaptogrid
        End Get
        Set(ByVal value As Boolean)
            m_snaptogrid = value
        End Set
    End Property

    Public Property MouseHoverSelect() As Boolean
        Get
            Return m_mousehoverselect
        End Get
        Set(ByVal value As Boolean)
            m_mousehoverselect = value
        End Set
    End Property

    Public Property SurfaceMargins() As Rectangle
        'bounds in 1/100ths of an inch, just like the printer objects use
        Get
            Return m_SurfaceMargins
        End Get
        Set(ByVal Value As Rectangle)
            m_SurfaceMargins = Value
        End Set
    End Property

    Public Property Zoom() As Single
        Get
            Return m_Zoom
        End Get
        Set(ByVal Value As Single)
            Dim xp, yp As Double
            xp = Me.HorizontalScroll.Value / (m_Zoom * Me.Width)
            yp = Me.VerticalScroll.Value / (m_Zoom * Me.Height)
            If Value > 0.05 Then
                If Value > 100 Then
                    m_Zoom = 100.0#
                    Me.Invalidate()
                    Me.HorizontalScroll.Value = xp * 100.0# * Me.Width
                    Me.VerticalScroll.Value = yp * 100.0# * Me.Height
                    Me.Invalidate()
                Else
                    m_Zoom = Value
                    Me.Invalidate()
                    If Not xp * Value * Me.Width < Me.HorizontalScroll.SmallChange And Not xp * Value * Me.Width > Me.HorizontalScroll.Maximum Then
                        Me.HorizontalScroll.Value = CInt(xp * Value * Me.Width)
                    End If
                    If Not yp * Value * Me.Height < Me.HorizontalScroll.SmallChange And Not yp * Value * Me.Height > Me.VerticalScroll.Maximum Then
                        Me.VerticalScroll.Value = CInt(yp * Value * Me.Height)
                    End If
                    Me.Invalidate()
                End If
            Else
                m_Zoom = 0.05
                Me.Invalidate()
                Me.HorizontalScroll.Value = xp * 0.05 * Me.Width
                Me.VerticalScroll.Value = yp * 0.05 * Me.Height
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property SelectRectangle() As Boolean
        Get
            Return selectable
        End Get
        Set(ByVal Value As Boolean)
            selectable = Value
        End Set
    End Property

    Public Overridable ReadOnly Property drawingObjects() As GraphicObjectCollection
        Get
            'since this is a reference type, users can add/remove/manipulate its contents
            'even though it is read only. they can't change m_drawingobjects itself though
            'ie. graphicssurface1.drawingobjects = Nothing would fail.
            Return m_drawingObjects
        End Get
    End Property

    Public Overridable Property MarginColor() As Color
        Get
            Return m_MarginColor
        End Get
        Set(ByVal Value As Color)
            m_MarginColor = Value
        End Set
    End Property

    Public Overridable Property MarginLineWidth() As Integer
        Get
            Return m_MarginLineWidth
        End Get
        Set(ByVal Value As Integer)
            If Value > 0 Then
                m_MarginLineWidth = Value
            Else
                Throw New ArgumentOutOfRangeException("MarginLineWidth", _
                    "MarginLineWidth must be greater than zero")
            End If
        End Set
    End Property

    Public Overridable Property ShowGrid() As Boolean
        Get
            Return m_ShowGrid
        End Get
        Set(ByVal Value As Boolean)
            m_ShowGrid = False
        End Set
    End Property

    Public Overridable Property GridColor() As Color
        Get
            Return m_GridColor
        End Get
        Set(ByVal Value As Color)
            m_GridColor = Value
        End Set
    End Property

    Public Overridable Property NonPrintingAreaColor() As Color
        Get
            Return m_NonPrintingAreaColor
        End Get
        Set(ByVal Value As Color)
            m_NonPrintingAreaColor = Value
        End Set
    End Property

    Public Overridable Property GridLineWidth() As Integer
        Get
            Return m_GridLineWidth
        End Get
        Set(ByVal Value As Integer)
            If Value > 0 Then
                m_GridLineWidth = Value
            Else
                Throw New ArgumentOutOfRangeException("GridLineWidth", _
                    "GridLineWidth must be greater than zero")
            End If
        End Set
    End Property

    Public Overridable Property GridSize() As Single
        'in 100ths of an inch
        Get
            Return m_GridSize
        End Get
        Set(ByVal Value As Single)
            If Value > MinimumGridSize Then
                m_GridSize = Value
            Else
                Throw New ArgumentOutOfRangeException("GridSize", _
                        String.Format("Grid Size must be greater than {0}", MinimumGridSize))
            End If
        End Set
    End Property

    Protected Function ConvertToHPixels(ByVal value As Single) As Single
        Return value * Me.m_HorizRes
    End Function

    Protected Function ConvertToVPixels(ByVal value As Single) As Single
        Return value * Me.m_VertRes
    End Function

    Protected Function ConvertToPixels(ByVal rect As Rectangle) As Rectangle
        'convert from 100ths of an inch to pixels
        Dim Bounds As Rectangle
        Bounds = New Rectangle(ConvertToHPixels(rect.X / 100), _
            ConvertToVPixels(rect.Y / 100), _
            ConvertToHPixels(rect.Width / 100), _
            ConvertToVPixels(rect.Height / 100))
        Return Bounds
    End Function

    Protected Function ZoomRectangle(ByVal originalRect As Rectangle) As Rectangle
        Dim myNewRect As New Rectangle(originalRect.X * Me.Zoom, _
                originalRect.Y * Me.Zoom, _
                originalRect.Width * Me.Zoom, _
                originalRect.Height * Me.Zoom)
        Return myNewRect
    End Function

    Protected Function DeZoomRectangle(ByVal originalRect As Rectangle) As Rectangle
        Dim myNewRect As New Rectangle(originalRect.X / Me.Zoom, _
                originalRect.Y / Me.Zoom, _
                originalRect.Width / Me.Zoom, _
                originalRect.Height / Me.Zoom)
        Return myNewRect
    End Function

    Public Overridable Sub DrawGrid(ByVal g As Graphics)
        Dim bounds As Rectangle
        Dim horizGridSize As Integer = ConvertToHPixels(GridSize / 100) * Me.Zoom
        Dim vertGridSize As Integer = ConvertToVPixels(GridSize / 100) * Me.Zoom
        bounds = ConvertToPixels(SurfaceBounds)
        bounds = ZoomRectangle(bounds)
        If Me.AutoScrollMinSize.Height <> bounds.Height _
            AndAlso Me.AutoScrollMinSize.Width <> bounds.Width Then
            Me.AutoScrollMinSize = New Size(bounds.Width, bounds.Height)
        End If

        g.Clear(m_NonPrintingAreaColor)
        g.FillRectangle(New SolidBrush(Me.BackColor), bounds)

        Dim gridPen As New Pen(GridColor, m_GridLineWidth)
        'gridPen.DashStyle = DashStyle.Dot
        Dim i As Integer
        For i = vertGridSize To bounds.Height Step vertGridSize
            g.DrawLine(gridPen, 0, i, bounds.Width, i)
        Next
        For i = horizGridSize To bounds.Width Step horizGridSize
            g.DrawLine(gridPen, i, 0, i, bounds.Height)
        Next
    End Sub

    Protected Overridable Sub DrawMargins(ByVal g As Graphics)
        Dim margins As Rectangle = ZoomRectangle(ConvertToPixels(Me.m_SurfaceMargins))
        Dim marginPen As New Pen(m_MarginColor)
        marginPen.DashStyle = Drawing2D.DashStyle.Dash
        marginPen.Width = m_MarginLineWidth
        g.DrawRectangle(marginPen, margins)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        'Try
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.Default
        'get the dpi settings of the graphics context,
        'for example; 96dpi on screen, 600dpi for the printer
        'used to adjust grid and margin sizing.
        Me.m_HorizRes = g.DpiX
        Me.m_VertRes = g.DpiY

        'handle the possibility that the viewport is scrolled,
        'adjust my origin coordintates to compensate
        Dim pt As Point = Me.AutoScrollPosition
        g.TranslateTransform(pt.X, pt.Y)

        DrawGrid(g)

        If hoverdraw Then
            Dim myOriginalMatrix As Drawing2D.Matrix
            myOriginalMatrix = g.Transform()
            g.PageUnit = GraphicsUnit.Pixel
            g.ScaleTransform(Zoom, Zoom)
            Dim color1, color2, color3 As Color
            color1 = Color.FromArgb(50, 170, 215, 230)
            color2 = Color.FromArgb(50, 2, 140, 140)
            color3 = Color.FromArgb(50, 2, 140, 140)
            'Dim roundpercent As Integer = (hoverRect.Height ^ 2 + hoverRect.Width ^ 2) ^ 0.5 * 0.1
            Dim gbrush As New LinearGradientBrush(hoverRect, color1, color2, LinearGradientMode.Vertical)
            DrawRoundRect(g, New Pen(color3, 1), hoverRect.X, hoverRect.Y, hoverRect.Width, hoverRect.Height, 15, gbrush)
            g.Transform = myOriginalMatrix
        End If


        'draw the actual objects onto the page, on top of the grid

        For Each gr As GraphicObject In Me.SelectedObjects.Values
            Me.drawingObjects.DrawSelectedObject(g, gr, Me.Zoom)
        Next

        With Me.drawingObjects
            'pass the graphics resolution onto the objects
            'so that images and other objects can be sized
            'correct taking the dpi into consideration.
            .HorizontalResolution = g.DpiX
            .VerticalResolution = g.DpiY
            'doesn't really draw the selected object, but instead the
            'selection indicator, a dotted outline around the selected object
            .DrawObjects(g, Me.Zoom)
            If Not m_SelectedObject Is Nothing Then
                If Not Me.SelectedObjects.ContainsKey(m_SelectedObject.Name) Then
                    .DrawSelectedObject(g, m_SelectedObject, Me.Zoom)
                End If
            End If
        End With

        'Draw dashed line margin indicators, over top of objects
        DrawMargins(g)

        'draw selection rectangle (click and drag to select interface)
        'on top of everything else, but transparent
        If selectionDragging Then
            DrawSelectionRectangle(g, selectionRect)
        End If
        'Catch ex As System.Exception
        'Debug.WriteLine(ex.ToString)
        'Throw New System.ApplicationException("Error Drawing Graphics Surface", ex)
        ' End Try

    End Sub

    Protected Overrides Function IsInputKey(ByVal keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Up
                Return True
            Case Keys.Down
                Return True
            Case Keys.Left
                Return True
            Case Keys.Right
                Return True
            Case Else
                Return MyBase.IsInputKey(keyData)
        End Select
    End Function

    Private Sub DrawSelectionRectangle(ByVal g As Graphics, _
            ByVal selectionRect As Rectangle)

        Dim selectionBrush As New SolidBrush(Color.FromArgb(50, Color.LightBlue))
        Dim normalizedRectangle As Rectangle

        'make sure the rectangle's upper left point is
        'up and to the left relative to the other points of the rectangle by
        'ensuring that it has a positive width and height.
        normalizedRectangle.Size = selectionRect.Size
        If selectionRect.Width < 0 Then
            normalizedRectangle.X = selectionRect.X - normalizedRectangle.Width
        Else
            normalizedRectangle.X = selectionRect.X
        End If

        If selectionRect.Height < 0 Then
            normalizedRectangle.Y = selectionRect.Y - normalizedRectangle.Height
        Else
            normalizedRectangle.Y = selectionRect.Y
        End If

        g.FillRectangle(selectionBrush, normalizedRectangle)

    End Sub

    Public Overloads Function gscTogoc( _
            ByVal gsPT As Point) As Point
        Dim myNewPoint As Point
        myNewPoint.X = CInt((gsPT.X - Me.AutoScrollPosition.X) / Me.Zoom)
        myNewPoint.Y = CInt((gsPT.Y - Me.AutoScrollPosition.Y) / Me.Zoom)
        Return myNewPoint
    End Function
    Public Overloads Function gscTogoc( _
            ByVal X As Integer, ByVal Y As Integer) As Point
        Dim myNewPoint As Point
        myNewPoint.X = CInt((X - Me.AutoScrollPosition.X) / Me.Zoom)
        myNewPoint.Y = CInt((Y - Me.AutoScrollPosition.Y) / Me.Zoom)
        Return myNewPoint
    End Function

    Public Overloads Function gocTogsc( _
            ByVal goPT As Point) As Point
        'note that there is no need for a New for my Point
        'before I can assign values to X and Y
        'as it is a structure not an object
        Dim myNewPoint As Point
        myNewPoint.X = CInt((goPT.X) * Me.Zoom)
        myNewPoint.Y = CInt((goPT.Y) * Me.Zoom)

        Return myNewPoint
    End Function
    Public Overloads Function gocTogsc( _
            ByVal X As Integer, ByVal Y As Integer) As Point
        Dim myNewPoint As Point
        myNewPoint.X = CInt(X * Me.Zoom)
        myNewPoint.Y = CInt(Y * Me.Zoom)
        Return myNewPoint
    End Function

    Private Sub GraphicsSurface_MouseDown(ByVal sender As Object, _
            ByVal e As MouseEventArgs) _
            Handles MyBase.MouseDown

        Dim mousePT As Point = gscTogoc(e.X, e.Y)
        dragStart = New Point(e.X, e.Y)
        Me.SelectedObject = Me.drawingObjects.FindObjectAtPoint(mousePT)
        If Me.SelectedObject Is Nothing Then
            Me.SelectedObjects.Clear()
            justselected = False
            If My.Computer.Keyboard.ShiftKeyDown Then
                draggingfs = True
            End If
        Else
            If My.Computer.Keyboard.CtrlKeyDown Then
                If Not Me.SelectedObjects.ContainsKey(Me.SelectedObject.Name) Then
                    Me.SelectedObjects.Add(Me.SelectedObject.Name, Me.SelectedObject)
                Else
                    Me.SelectedObjects.Remove(Me.SelectedObject.Name)
                End If
                justselected = True
            Else
                If Not justselected Then Me.SelectedObjects.Clear()
                If Not Me.SelectedObjects.ContainsKey(Me.SelectedObject.Name) Then
                    Me.SelectedObjects.Add(Me.SelectedObject.Name, Me.SelectedObject)
                End If
                justselected = False
            End If
        End If
        Me.Invalidate()

        If Not m_SelectedObject Is Nothing Then
            If e.Button And Windows.Forms.MouseButtons.Right Then
                'rotating = True
                dragging = True
                startingRotation = AngleToPoint(m_SelectedObject.GetPosition, mousePT)
                originalRotation = m_SelectedObject.Rotation
            Else
                dragging = True
                dragOffset.X = m_SelectedObject.X - mousePT.X
                dragOffset.Y = m_SelectedObject.Y - mousePT.Y
            End If
        Else
            If e.Button And Windows.Forms.MouseButtons.Left And Me.SelectRectangle And Not My.Computer.Keyboard.ShiftKeyDown Then
                selectionDragging = True
                selectionRect.X = mousePT.X * Me.Zoom
                selectionRect.Y = mousePT.Y * Me.Zoom
                selectionRect.Height = 0
                selectionRect.Width = 0
            End If
        End If

    End Sub

    Public Sub ZoomAll()

        Dim minx As Integer = 10000
        Dim miny As Integer = 10000
        Dim maxx As Integer = 0
        Dim maxy As Integer = 0

        For Each gobj As GraphicObject In Me.drawingObjects
            If gobj.X <= minx Then minx = gobj.X
            If gobj.X + gobj.Width >= maxx Then maxx = gobj.X + gobj.Width + 60
            If gobj.Y <= miny Then miny = gobj.Y
            If gobj.Y + gobj.Height >= maxy Then maxy = gobj.Y + gobj.Height + 60
        Next

        Dim windowheight, windowwidth, fsx, fsy, fsheight, fswidth As Integer

        windowheight = Me.Height
        windowwidth = Me.Width

        fsx = Me.HorizontalScroll.Value
        fsy = Me.VerticalScroll.Value
        fswidth = fsx + windowwidth
        fsheight = fsy + windowheight

        Dim newx, newy As Integer

        newx = minx - 30
        newy = miny - 30

        If newx < 0 Then newx = 0
        If newy < 0 Then newy = 0

        Dim zoomx As Double = 1.0#
        Dim zoomy As Double = 1.0#

        zoomx = (fswidth-fsx) / (maxx - newx)
        zoomy = (fsheight - fsy) / (maxy - newy)

        If zoomx > zoomy Then Me.Zoom = zoomy Else Me.Zoom = zoomx

        If newx * Me.Zoom < Me.HorizontalScroll.Maximum Then Me.HorizontalScroll.Value = CInt(newx * Me.Zoom)
        If newy * Me.Zoom < Me.VerticalScroll.Maximum Then Me.VerticalScroll.Value = CInt(newy * Me.Zoom)

        Me.Invalidate()

    End Sub

    Private Sub GraphicsSurface_MouseMove(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles MyBase.MouseMove

        If draggingfs Then
            Me.Cursor = Cursors.Hand
            Dim dx As Integer = -(e.X - dragStart.X)
            Dim dy As Integer = -(e.Y - dragStart.Y)
            If Me.HorizontalScroll.Value + dx > Me.HorizontalScroll.Minimum Then
                Me.HorizontalScroll.Value += dx
            Else
                Me.HorizontalScroll.Value += Me.HorizontalScroll.Minimum
            End If
            If Me.VerticalScroll.Value + dy > Me.VerticalScroll.Minimum Then
                Me.VerticalScroll.Value += dy
            Else
                Me.VerticalScroll.Value += Me.VerticalScroll.Minimum
            End If
            dragStart = New Point(e.X, e.Y)
            Me.Invalidate()
        Else
            Cursor.Current = Cursors.Default
            If Not Me.QuickConnect Or Not My.Computer.Keyboard.CtrlKeyDown Then
                Dim dragPoint As Point = gscTogoc(e.X, e.Y)

                Dim obj As GraphicObject = Me.drawingObjects.FindObjectAtPoint(dragPoint)
                Me.Invalidate()

                If Not obj Is Nothing Then
                    If obj.TipoObjeto <> TipoObjeto.GO_TabelaRapida And obj.TipoObjeto <> TipoObjeto.GO_Texto _
                    And obj.TipoObjeto <> TipoObjeto.GO_Figura And obj.TipoObjeto <> TipoObjeto.GO_Tabela _
                    And obj.TipoObjeto <> TipoObjeto.Nenhum Then
                        With Me.hoverRect
                            .X = obj.X - 10
                            .Y = obj.Y - 10
                            Select Case obj.TipoObjeto
                                Case TipoObjeto.GO_Animation, TipoObjeto.GO_Figura, TipoObjeto.GO_Tabela, TipoObjeto.GO_TabelaRapida, TipoObjeto.GO_Texto, TipoObjeto.GO_MasterTable
                                    .Height = obj.Height + 20
                                    .Width = obj.Width + 20
                                Case Else
                                    .Height = obj.Height + 30
                                    .Width = obj.Width + 20
                                    Dim g As Graphics = Graphics.FromHwnd(Me.Handle)
                                    Dim strdist As SizeF = g.MeasureString(obj.Tag, New Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel, 0, False), New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                                    If strdist.Width > obj.Width Then
                                        .X = obj.X + (obj.Width - strdist.Width) / 2 - 10
                                        .Width = strdist.Width + 20
                                    End If
                            End Select
                        End With
                        hoverdraw = True
                    End If
                Else
                    hoverdraw = False
                End If

                If Not m_SelectedObject Is Nothing Then

                    If Not m_SelectedObject.IsConnector And SelectRectangle Then

                        If dragging Then
                            dragPoint.Offset(dragOffset.X, dragOffset.Y)
                            'm_SelectedObject.SetPosition(dragPoint)

                            For Each gr As GraphicObject In Me.SelectedObjects.Values
                                Dim p As Point = New Point(gr.X, gr.Y)
                                p.Offset((e.X - dragStart.X) / Me.Zoom, (e.Y - dragStart.Y) / Me.Zoom)
                                gr.SetPosition(p)
                            Next

                            dragStart = New Point(e.X, e.Y)

                            RaiseEvent StatusUpdate(Me, _
                                New StatusUpdateEventArgs(StatusUpdateType.ObjectMoved, _
                                    Me.SelectedObject, _
                                    String.Format("Object Moved to {0}, {1}", dragPoint.X, dragPoint.Y), _
                                    dragPoint, 0))
                            Me.Invalidate()
                        ElseIf rotating Then

                            Dim currentRotation As Single

                            currentRotation = _
                                AngleToPoint(m_SelectedObject.GetPosition, dragPoint)
                            currentRotation = _
                                CInt((currentRotation - startingRotation + originalRotation) Mod 360)

                            m_SelectedObject.Rotation = currentRotation

                            RaiseEvent StatusUpdate(Me, _
                                New StatusUpdateEventArgs(StatusUpdateType.ObjectRotated, _
                                        Me.SelectedObject, _
                                        String.Format("Object Rotated to {0} degrees", currentRotation), _
                                        Nothing, currentRotation))

                            Me.Invalidate()
                        End If

                    End If
                Else
                    If selectionDragging And SelectRectangle Then
                        selectionRect.Width = dragPoint.X * Me.Zoom - selectionRect.X
                        selectionRect.Height = dragPoint.Y * Me.Zoom - selectionRect.Y
                        Me.Invalidate()
                    End If
                End If

            End If

        End If

    End Sub

    Private Sub GraphicsSurface_MouseUp(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        draggingfs = False
        If dragging And SnapToGrid Then
            Dim horizGridSize As Integer = ConvertToHPixels(GridSize / 100) * Me.Zoom
            Dim vertGridSize As Integer = ConvertToVPixels(GridSize / 100) * Me.Zoom
            Dim bounds As Rectangle = ConvertToPixels(SurfaceBounds)
            bounds = ZoomRectangle(bounds)
            Dim oc As Point
            Dim nlh, nlv, snapx, snapy As Integer
            nlh = bounds.Width / horizGridSize
            nlv = bounds.Height / vertGridSize
            For Each go As GraphicObject In Me.SelectedObjects.Values
                oc = New Point(go.X + go.Width / 2, go.Y + go.Height / 2)
                snapx = Math.Round(oc.X / horizGridSize) * horizGridSize - go.Width / 2
                snapy = Math.Round(oc.Y / vertGridSize) * vertGridSize - go.Height / 2
                go.SetPosition(New Point(snapx, snapy))
            Next
        End If
        dragging = False
        rotating = False
        If selectionDragging Then
            'TODO: Rewrite to handle multiple selections
            'really just need to change from m_SelectedObject to a collection
            'add each found object in this loop, removing the Exit For
            Dim zoomedSelection As Rectangle = DeZoomRectangle(selectionRect)
            Dim graphicObj As GraphicObject
            For Each graphicObj In Me.drawingObjects
                If graphicObj.HitTest(zoomedSelection) Then
                    Me.SelectedObject = graphicObj
                    Exit For
                End If
            Next
            For Each graphicObj In Me.drawingObjects
                If graphicObj.HitTest(zoomedSelection) Then
                    If Not Me.SelectedObjects.ContainsKey(graphicObj.Name) Then Me.SelectedObjects.Add(graphicObj.Name, graphicObj)
                End If
            Next
            selectionDragging = False
            justselected = True
            Me.Invalidate()
        End If


    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Delta <> 0 Then 'has wheel been moved?

            'The .NET docs suggest that e.Delta returns the actual number of notches
            'the mouse wheel has been rotated, but in actuality each roll of the mouse wheel
            'returns a value of +/- 120 (depending on the direction of rotation).
            '120 is actually a system constant, and therefore there is a possibility that it could
            'change to allow for higher-resolution mouse wheels.

            'check out <http://msdn.microsoft.com/library/en-us/winui/winui/windowsuserinterface/userinput/mouseinput/mouseinputreference/mouseinputmessages/wm_mousewheel.asp>
            'for more information

            If My.Computer.Keyboard.CtrlKeyDown Then

                Dim detents As Integer = Math.Abs(e.Delta \ 120)
                Dim i As Integer
                Dim delta As Integer
                Dim zoomIn As Boolean = (e.Delta < 0)
                Dim zoomPercentage As Integer = Me.Zoom * 100
                For i = 1 To detents
                    If zoomPercentage <= 100 Then
                        If zoomIn Then
                            delta = -5
                            zoomPercentage = zoomPercentage - 5
                        Else
                            delta = +5
                            zoomPercentage = zoomPercentage + 5
                        End If
                    Else
                        If zoomIn Then
                            delta = -5
                            zoomPercentage = zoomPercentage - 5
                        Else
                            delta = +5
                            zoomPercentage = zoomPercentage + 5
                        End If
                    End If
                Next

                'Dim cursorpos As Point = gscTogoc(Cursor.Position)

                'Dim dx, dy As Integer
                'dx = cursorpos.X + Me.AutoScrollPosition.X / Me.Zoom
                'dy = cursorpos.Y + Me.AutoScrollPosition.Y / Me.Zoom

                'Me.HorizontalScroll.Value -= dx / (zoomPercentage / 100)
                'Me.VerticalScroll.Value -= dx / (zoomPercentage / 100)

                Me.Zoom = zoomPercentage / 100
                RaiseEvent StatusUpdate(Me, New StatusUpdateEventArgs(StatusUpdateType.SurfaceZoomChanged, _
                        Me.SelectedObject, String.Format("Zoom set to {0}", Me.Zoom * 100), _
                        Nothing, Me.Zoom))

            Else

                Dim detents As Integer = e.Delta / 120

                If detents > 0 Then
                    If Me.VerticalScroll.Value > 4 * My.Computer.Mouse.WheelScrollLines Then
                        If 4 * My.Computer.Mouse.WheelScrollLines > Me.VerticalScroll.SmallChange Then
                            Me.VerticalScroll.Value -= 4 * My.Computer.Mouse.WheelScrollLines
                        End If
                    Else
                        Me.VerticalScroll.Value = 0
                    End If
                ElseIf detents < 0 Then
                    If Me.VerticalScroll.Value > 4 * My.Computer.Mouse.WheelScrollLines Then
                        If 4 * My.Computer.Mouse.WheelScrollLines > Me.VerticalScroll.SmallChange Then
                            Me.VerticalScroll.Value += 4 * My.Computer.Mouse.WheelScrollLines
                        End If
                    Else
                        Me.VerticalScroll.Value = 0
                    End If
                End If

            End If

            Me.Invalidate()

        End If
    End Sub

    'TODO: Rewrite to handle multiple selected objects
    Public Property SelectedObject() As GraphicObject
        Get
            Return m_SelectedObject
        End Get
        Set(ByVal Value As GraphicObject)
            If Not Value Is m_SelectedObject Then
                If m_drawingObjects.Contains(Value) OrElse Value Is Nothing Then
                    m_SelectedObject = Value
                    RaiseEvent SelectionChanged(Me, New SelectionChangedEventArgs(Value))
                    If Value Is Nothing Then
                        RaiseEvent StatusUpdate(Me, _
                            New StatusUpdateEventArgs(StatusUpdateType.SelectionChanged, _
                                Value, "No Object Selected", _
                                Nothing, 0))
                    Else
                        RaiseEvent StatusUpdate(Me, _
                            New StatusUpdateEventArgs(StatusUpdateType.SelectionChanged, _
                                Value, "Selected Object Changed", _
                                Value.GetPosition, 0))
                    End If
                    Me.Invalidate()
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property SelectedObjects() As Generic.Dictionary(Of String, GraphicObject)
        Get
            Return m_SelectedObjects
        End Get
    End Property

    Public Sub DeleteSelectedObject()
        Dim objectToDelete As GraphicObject = Me.SelectedObject
        If Not objectToDelete Is Nothing Then
            If Me.drawingObjects.Contains(objectToDelete) Then
                Me.drawingObjects.Remove(objectToDelete)
                Me.SelectedObject = Nothing
                objectToDelete.Container = Nothing
                Me.Invalidate()
            End If
        End If
    End Sub

    Public Sub DeleteAllObjects()
        Me.drawingObjects.Clear()
        Me.Invalidate()
    End Sub

    Private Function AngleToPoint(ByVal Origin As Point, _
            ByVal Target As Point) As Single
        'a cool little utility function, 
        'given two points finds the angle between them....
        'forced me to recall my highschool math, 
        'but the task is made easier by a special overload to
        'Atan that takes X,Y co-ordinates.
        Dim Angle As Single
        Target.X = Target.X - Origin.X
        Target.Y = Target.Y - Origin.Y
        Angle = Math.Atan2(Target.Y, Target.X) / (Math.PI / 180)
        Return Angle
    End Function

    Public Sub DrawRoundRect(ByVal g As Graphics, ByVal p As Pen, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal radius As Integer, ByVal myBrush As Brush)

        Dim gp As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath

        gp.AddLine(x + radius, y, x + width - radius, y)
        gp.AddArc(x + width - radius, y, radius, radius, 270, 90)
        gp.AddLine(x + width, y + radius, x + width, y + height - radius)
        gp.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90)
        gp.AddLine(x + width - radius, y + height, x + radius, y + height)
        gp.AddArc(x, y + height - radius, radius, radius, 90, 90)
        gp.AddLine(x, y + height - radius, x, y + radius)
        gp.AddArc(x, y, radius, radius, 180, 90)

        gp.CloseFigure()

        g.DrawPath(p, gp)
        g.FillPath(myBrush, gp)

        gp.Dispose()

    End Sub

End Class

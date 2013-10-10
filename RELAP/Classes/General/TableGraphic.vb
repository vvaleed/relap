﻿'    Table Graphic Object
'    
'
'    This file is part of RIFGen.
'
'    RIFGen is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    RIFGen is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with RELAP.  If not, see <http://www.gnu.org/licenses/>.

Imports System.Drawing
Imports Microsoft.Msdn.Samples.GraphicObjects
Imports System.Drawing.Drawing2D
'Imports RELAP.RELAP.SimulationObjects
Imports RELAP.RELAP.Outros

Namespace RELAP.GraphicObjects

    <Serializable()> Public Class MasterTableGraphic

        Inherits ShapeGraphic

        Protected m_Font_Col1 As Font = New Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Pixel, 0, False)
        Protected m_Font_Col2 As Font = New Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Pixel, 0, False)
        Protected m_Font_Col3 As Font = New Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Pixel, 0, False)
        Protected m_HeaderFont As Font = New Font("Verdana", 10, FontStyle.Bold, GraphicsUnit.Pixel, 0, False)

        Protected m_Text As String = ""

        Protected m_Color_Bg As Color = Drawing.Color.White
        Protected m_Color_Gradient_1 As Color = Drawing.Color.LightGray
        Protected m_Color_Gradient_2 As Color = Drawing.Color.WhiteSmoke

        Protected m_bgOpacity As Integer = 175

        Protected m_IsGradientBg As Boolean = False

        Protected m_BorderThickness As Integer = 1
        Protected m_Padding As Integer = 2

        <System.NonSerialized()> Protected m_BorderPen As Drawing.Pen = New Drawing.Pen(Color.Black)
        Protected m_BorderStyle As Drawing2D.DashStyle = DashStyle.Solid
        Protected m_BorderColor As Color = Color.Black

        Protected m_TextRenderStyle As Drawing2D.SmoothingMode = Drawing2D.SmoothingMode.Default
        Protected m_objectfamily As TipoObjeto = Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.MaterialStream

        Protected m_objectlist As Dictionary(Of String, Boolean)
        Protected m_propertylist As Dictionary(Of String, Boolean)
        Protected m_sortby As String = ""
        Protected m_sortableitems As ArrayList
        Protected m_sortedlist As List(Of String)

        Protected m_items As Dictionary(Of String, List(Of RELAP.Outros.NodeItem))

#Region "Constructors"

        Public Sub New()
            Me.TipoObjeto = TipoObjeto.GO_MasterTable
            m_objectlist = New Dictionary(Of String, Boolean)
            m_propertylist = New Dictionary(Of String, Boolean)
            m_sortableitems = New ArrayList
        End Sub

        Public Sub New(ByVal graphicPosition As Point)
            Me.New()
            Me.SetPosition(graphicPosition)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer)
            Me.New(New Point(posX, posY))
        End Sub

#End Region

#Region "Properties"

        Public Property SortBy() As String
            Get
                If m_sortby Is Nothing Then m_sortby = "Name | DESC"
                Return m_sortby
            End Get
            Set(ByVal value As String)
                m_sortby = value
            End Set
        End Property

        Public ReadOnly Property SortableItems() As String()
            Get
                If m_sortableitems Is Nothing Then m_sortableitems = New ArrayList
                m_sortableitems.Clear()
                m_sortableitems.Add("Name | ASC")
                m_sortableitems.Add("Name | DESC")
                For Each kvp As KeyValuePair(Of String, Boolean) In m_propertylist
                    If kvp.Value Then
                        m_sortableitems.Add(kvp.Key & " | ASC")
                        m_sortableitems.Add(kvp.Key & " | DESC")
                    End If
                Next
                m_sortableitems.Add("Custom")
                Return m_sortableitems.ToArray(Type.GetType("System.String"))
            End Get
        End Property

        Public ReadOnly Property PropertyList() As Dictionary(Of String, Boolean)
            Get
                Return m_propertylist
            End Get
        End Property

        Public ReadOnly Property ObjectList() As Dictionary(Of String, Boolean)
            Get
                Return m_objectlist
            End Get
        End Property

        Public Property SortedList() As List(Of String)
            Get
                Return m_sortedlist
            End Get
            Set(ByVal value As List(Of String))
                m_sortedlist = value
            End Set
        End Property

        Public Property ObjectFamily() As TipoObjeto
            Get
                Return m_objectfamily
            End Get
            Set(ByVal value As TipoObjeto)
                m_objectfamily = value
                m_objectlist.Clear()
                m_propertylist.Clear()
                m_sortby = "Name | DESC"
            End Set
        End Property

        Public Property HeaderFont() As Font
            Get
                Return m_HeaderFont
            End Get
            Set(ByVal Value As Font)
                m_HeaderFont = Value
            End Set
        End Property

        Public Property FontCol1() As Font
            Get
                Return m_Font_Col1
            End Get
            Set(ByVal Value As Font)
                m_Font_Col1 = Value
            End Set
        End Property

        Public Property FontCol2() As Font
            Get
                Return m_Font_Col2
            End Get
            Set(ByVal Value As Font)
                m_Font_Col2 = Value
            End Set
        End Property

        Public Property FontCol3() As Font
            Get
                Return m_Font_Col3
            End Get
            Set(ByVal Value As Font)
                m_Font_Col3 = Value
            End Set
        End Property

        Public Property HeaderText() As String
            Get
                Return m_Text
            End Get
            Set(ByVal Value As String)
                m_Text = Value
            End Set
        End Property

        Public Property BorderThickness() As Integer
            Get
                Return m_BorderThickness
            End Get
            Set(ByVal value As Integer)
                m_BorderThickness = value
            End Set
        End Property

        Public Property Padding() As Integer
            Get
                Return m_Padding
            End Get
            Set(ByVal value As Integer)
                m_Padding = value
            End Set
        End Property

        Public Property Opacity() As Integer
            Get
                Return m_bgOpacity
            End Get
            Set(ByVal value As Integer)
                m_bgOpacity = value
            End Set
        End Property

        Public Property BackgroundColor() As System.Drawing.Color
            Get
                Return m_Color_Bg
            End Get
            Set(ByVal Value As System.Drawing.Color)
                m_Color_Bg = Value
            End Set
        End Property

        Public Property BackgroundGradientColor1() As System.Drawing.Color
            Get
                Return m_Color_Gradient_1
            End Get
            Set(ByVal Value As System.Drawing.Color)
                m_Color_Gradient_1 = Value
            End Set
        End Property

        Public Property BackgroundGradientColor2() As System.Drawing.Color
            Get
                Return m_Color_Gradient_2
            End Get
            Set(ByVal Value As System.Drawing.Color)
                m_Color_Gradient_2 = Value
            End Set
        End Property

        Public Property BorderStyle() As Drawing.Drawing2D.DashStyle
            Get
                Return m_BorderStyle
            End Get
            Set(ByVal value As Drawing.Drawing2D.DashStyle)
                m_BorderStyle = value
            End Set
        End Property

        Public Property BorderColor() As Drawing.Color
            Get
                Return m_BorderColor
            End Get
            Set(ByVal value As Drawing.Color)
                m_BorderColor = value
            End Set
        End Property

        Public Property TextRenderStyle() As Drawing2D.SmoothingMode
            Get
                Return m_TextRenderStyle
            End Get
            Set(ByVal value As Drawing2D.SmoothingMode)
                m_TextRenderStyle = value
            End Set
        End Property

        Property IsGradientBackground() As Boolean
            Get
                Return m_IsGradientBg
            End Get
            Set(ByVal value As Boolean)
                m_IsGradientBg = value
            End Set
        End Property
#End Region

        Public Sub Update(ByRef form As FormFlowsheet)

            Dim su As RELAP.SistemasDeUnidades.Unidades = form.Options.SelectedUnitSystem
            Dim nf As String = form.Options.NumberFormat

            m_items = New Dictionary(Of String, List(Of RELAP.Outros.NodeItem))

            Dim objectstoremove As New ArrayList

            For Each kvp As KeyValuePair(Of String, Boolean) In m_objectlist
                If form.GetFlowsheetGraphicObject(kvp.Key) Is Nothing Then
                    objectstoremove.Add(kvp.Key)
                End If
            Next

            For i As Integer = 0 To objectstoremove.Count - 1
                m_objectlist.Remove(objectstoremove(i))
            Next

            For Each kvp As KeyValuePair(Of String, Boolean) In m_objectlist
                If kvp.Value = True Then
                    Dim myobj As SimulationObjects_BaseClass = form.GetFlowsheetSimulationObject(kvp.Key)
                    m_items.Add(kvp.Key, New List(Of NodeItem))
                    m_items(kvp.Key).Add(New NodeItem(RELAP.App.GetLocalString("Objeto"), kvp.Key, "", 0, 0, ""))
                    If Me.HeaderText = "" Then Me.HeaderText = RELAP.App.GetLocalString("MasterTable") & " - " & RELAP.App.GetLocalString(myobj.Descricao)
                    Dim mypropid As String = ""
                    Dim props() As String = myobj.GetProperties(SimulationObjects_BaseClass.PropertyType.ALL)
                    For Each kvp2 As KeyValuePair(Of String, Boolean) In m_propertylist
                        If kvp2.Value = True Then
                            For Each p As String In props
                                If RELAP.App.GetPropertyName(p) = kvp2.Key Then
                                    mypropid = p
                                    Exit For
                                End If
                            Next
                            Dim value As Object = myobj.GetPropertyValue(mypropid, su)
                            If Double.TryParse(value, New Double) Then
                                m_items(kvp.Key).Add(New NodeItem(kvp2.Key, Format(Double.Parse(value), nf), myobj.GetPropertyUnit(mypropid, su), 0, 0, ""))
                            Else
                                m_items(kvp.Key).Add(New NodeItem(kvp2.Key, value, myobj.GetPropertyUnit(mypropid, su), 0, 0, ""))
                            End If
                        End If
                    Next
                End If
            Next

            If m_sortableitems Is Nothing Then m_sortableitems = New ArrayList

            If Not m_sortableitems.Contains(m_sortby) Then m_sortby = "Name | DESC"

            If m_sortedlist Is Nothing Then m_sortedlist = New List(Of String)

            If m_sortby = "Custom" Then

                For i As Integer = 0 To objectstoremove.Count - 1
                    If m_sortedlist.Contains(objectstoremove(i)) Then m_sortedlist.Remove(objectstoremove(i))
                Next

                objectstoremove = New ArrayList

                For Each s As String In m_sortedlist
                    If m_objectlist(s) = False Then objectstoremove.Add(s)
                Next

                For i As Integer = 0 To objectstoremove.Count - 1
                    If m_sortedlist.Contains(objectstoremove(i)) Then m_sortedlist.Remove(objectstoremove(i))
                Next

            Else

                m_sortedlist.Clear()

                Dim p1, p2 As Object
                Dim j As Integer = 0
                Dim istidx As Integer = 0
                Dim isnotname As Boolean
                For Each s As String In m_items.Keys
                    isnotname = False
                    If j > 0 Then
                        istidx = 0
                        For Each ni As NodeItem In m_items(s)
                            If m_sortby.Contains(ni.Text) Then
                                isnotname = True
                                If Double.TryParse(ni.Value, New Double()) Then
                                    p1 = Double.Parse(ni.Value)
                                    For Each s2 As String In m_sortedlist
                                        p2 = Double.Parse(m_items(s2)(m_items(s).IndexOf(ni)).Value)
                                        If m_sortby.Contains("ASC") Then
                                            'ASC
                                            If p1 >= p2 Then
                                                istidx += 1
                                            End If
                                        Else
                                            'DESC
                                            If p1 <= p2 Then
                                                istidx += 1
                                            End If
                                        End If
                                    Next
                                Else
                                    p1 = ni.Value
                                    For Each s2 As String In m_sortedlist
                                        p2 = m_items(s2)(m_items(s).IndexOf(ni)).Value
                                        If m_sortby.Contains("ASC") Then
                                            'ASC
                                            If p1 >= p2 Then
                                                istidx += 1
                                            End If
                                        Else
                                            'DESC
                                            If p1 <= p2 Then
                                                istidx += 1
                                            End If
                                        End If
                                    Next
                                End If
                                m_sortedlist.Insert(istidx, s)
                                Exit For
                            End If
                        Next
                        If Not isnotname Then
                            'sort by object's name
                            p1 = s
                            istidx = 0
                            For Each s2 As String In m_sortedlist
                                p2 = s2
                                If m_sortby.Contains("ASC") Then
                                    'ASC
                                    If p1 >= p2 Then
                                        istidx += 1
                                    End If
                                Else
                                    'DESC
                                    If p1 <= p2 Then
                                        istidx += 1
                                    End If
                                End If
                            Next
                            m_sortedlist.Insert(istidx, s)
                        End If
                    Else
                        m_sortedlist.Add(s)
                    End If
                    j += 1
                Next
            End If

        End Sub

        Public Sub PopulateGrid(ByRef pgrid As PropertyGridEx.PropertyGridEx, ByRef form As FormFlowsheet)

            With pgrid

                .Item.Clear()

                .Item.Add(RELAP.App.GetLocalString("MT_ObjectFamily"), Me, "ObjectFamily", False, "1. " & RELAP.App.GetLocalString("MT_ObjectFamily"), "", True)

                For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
                    If obj.GraphicObject.TipoObjeto = Me.ObjectFamily Then
                        If m_objectlist.ContainsKey(obj.GraphicObject.Tag) Then
                            .Item.Add(obj.GraphicObject.Tag, m_objectlist(obj.GraphicObject.Tag), False, "2. " & RELAP.App.GetLocalString("MT_ObjectsToShow"), "", True)
                        Else
                            .Item.Add(obj.GraphicObject.Tag, False, False, "2. " & RELAP.App.GetLocalString("MT_ObjectsToShow"), "", True)
                        End If
                        .Item(.Item.Count - 1).DefaultType = Type.GetType("System.Boolean")
                        .Item(.Item.Count - 1).Tag = "Object|" & obj.Nome
                    End If
                Next

                Dim props() As String = Nothing

                If m_objectlist.Count > 0 Then
                    For Each s As String In m_objectlist.Keys
                        props = form.GetFlowsheetSimulationObject(s).GetProperties(SimulationObjects_BaseClass.PropertyType.ALL)
                        Exit For
                    Next
                    For Each p As String In props
                        If m_propertylist.ContainsKey(RELAP.App.GetPropertyName(p)) Then
                            .Item.Add(RELAP.App.GetPropertyName(p), m_propertylist(RELAP.App.GetPropertyName(p)), False, "4. " & RELAP.App.GetLocalString("MT_PropertiesToShow"), "", True)
                        Else
                            .Item.Add(RELAP.App.GetPropertyName(p), False, False, "4. " & RELAP.App.GetLocalString("MT_PropertiesToShow"), "", True)
                        End If
                        .Item(.Item.Count - 1).DefaultType = Type.GetType("System.Boolean")
                        .Item(.Item.Count - 1).Tag = "Property|" & p
                    Next
                End If

                .Item.Add(RELAP.App.GetLocalString("MT_SortObjectsBy"), Me, "SortBy", False, "3. " & RELAP.App.GetLocalString("MT_Sorting"), "", True)
                .Item(.Item.Count - 1).Choices = New PropertyGridEx.CustomChoices(Me.SortableItems, False)

                'If Me.SortBy = "Custom" Then
                '    .Item.Add(RELAP.App.GetLocalString("MT_CustomSortList"), Me, "SortedList", False, "3. " & RELAP.App.GetLocalString("MT_Sorting"), "", True)
                '    .Item(.Item.Count - 1).CustomEditor = New RELAP.Editors.MasterTable.UIMTableObjectOrderEditor
                '    .Item(.Item.Count - 1).IsBrowsable = False
                '    .Item(.Item.Count - 1).BrowsableLabelStyle = PropertyGridEx.BrowsableTypeConverter.LabelStyle.lsEllipsis
                'End If

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True

            End With

        End Sub

        Public Overrides Sub Draw(ByVal g As System.Drawing.Graphics)

            Dim gContainer As System.Drawing.Drawing2D.GraphicsContainer
            Dim myMatrix As Drawing2D.Matrix
            gContainer = g.BeginContainer()
            myMatrix = g.Transform()
            If m_Rotation <> 0 Then
                myMatrix.RotateAt(m_Rotation, New PointF(X, Y), Drawing.Drawing2D.MatrixOrder.Append)
                g.Transform = myMatrix
            End If

            If Not Me.TextRenderStyle = -1 Then g.TextRenderingHint = Me.TextRenderStyle

            Dim k As Integer = 0
            For Each bo As Boolean In Me.m_objectlist.Values
                If bo Then k += 1
            Next

            Dim maxL1, maxL2(k - 1), maxL2a, maxL3, count, i, maxH, n As Integer

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            With format1
                .Alignment = StringAlignment.Far
            End With

            Dim format2 As New StringFormat(StringFormatFlags.NoClip)
            With format2
                .Alignment = StringAlignment.Far
            End With

            'determinar comprimento das colunas e altura das linhas
            maxL1 = 0
            maxL3 = 0
            maxH = 0
            Dim size As SizeF
            Dim ni As NodeItem
            If Not m_items Is Nothing Then
                i = 0
                If Not m_sortedlist Is Nothing Then
                    For Each s As String In m_sortedlist
                        maxL2(i) = 0
                        count = 1
                        For Each ni In m_items(s)
                            size = g.MeasureString(ni.Text, Me.FontCol1, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                            If size.Width > maxL1 Then maxL1 = size.Width
                            If size.Height > maxH Then maxH = size.Height
                            size = g.MeasureString(ni.Value, Me.FontCol2, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                            If size.Width > maxL2(i) Then maxL2(i) = size.Width
                            If size.Height > maxH Then maxH = size.Height
                            size = g.MeasureString(ni.Unit, Me.FontCol3, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                            If size.Width > maxL3 Then maxL3 = size.Width
                            If size.Height > maxH Then maxH = size.Height
                            count += 1
                        Next
                        i += 1
                    Next
                Else
                    For Each s As String In m_items.Keys
                        maxL2(i) = 0
                        count = 1
                        For Each ni In m_items(s)
                            size = g.MeasureString(ni.Text, Me.FontCol1, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                            If size.Width > maxL1 Then maxL1 = size.Width
                            If size.Height > maxH Then maxH = size.Height
                            size = g.MeasureString(ni.Value, Me.FontCol2, New PointF(0, 0), New StringFormat(StringFormatFlags.DirectionRightToLeft, 0))
                            If size.Width > maxL2(i) Then maxL2(i) = size.Width
                            If size.Height > maxH Then maxH = size.Height
                            size = g.MeasureString(ni.Unit, Me.FontCol3, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                            If size.Width > maxL3 Then maxL3 = size.Width
                            If size.Height > maxH Then maxH = size.Height
                            count += 1
                        Next
                        i += 1
                    Next
                End If
            Else

            End If
            'size = g.MeasureString(Me.HeaderText, Me.HeaderFont, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
            'If size.Width > maxL1 Then maxL1 = size.Width
            'If size.Height > maxH Then maxH = size.Height

            Me.Height = (count) * (maxH + 2 * Me.Padding)
            If Not m_items Is Nothing Then
                If maxL2.Length > 0 Then
                    maxL2a = MathEx.Common.Max(maxL2) + 3 * Padding
                    Me.Width = (4 + 2 * m_items.Count) * Me.Padding + maxL1 + (k) * maxL2a + maxL3
                Else
                    Me.Width = 100
                    maxL2a = 50
                End If
            Else
                Me.Width = 100
                maxL2a = 50
            End If

            maxL1 = maxL1 + 2 * Padding
            maxL3 = maxL3 + 2 * Padding
            maxH = maxH + 2 * Padding

            If m_BorderPen Is Nothing Then m_BorderPen = New Drawing.Pen(Color.Black)

            With Me.m_BorderPen
                .Color = Me.BorderColor
                .DashStyle = Me.BorderStyle
            End With

            Dim rect As New Rectangle(X, Y, Width, Height)
            If Me.IsGradientBackground = False Then
                g.FillRectangle(New SolidBrush(Color.FromArgb(Me.Opacity, Me.BackgroundColor)), rect)
            Else
                g.FillRectangle(New Drawing2D.LinearGradientBrush(rect, Color.FromArgb(Me.Opacity, Me.BackgroundGradientColor2), Color.FromArgb(Me.Opacity, Me.BackgroundGradientColor1), LinearGradientMode.Vertical), rect)
            End If

            'desenhar textos e retangulos
            g.DrawString(Me.HeaderText, Me.HeaderFont, New SolidBrush(Me.LineColor), X + Padding, Y + Padding)
            If Not m_items Is Nothing Then
                If maxL2.Length > 0 Then
                    i = 0
                    If Not m_sortedlist Is Nothing Then
                        For Each s As String In m_sortedlist
                            n = 1
                            For Each ni In m_items(s)
                                If i = 0 Then g.DrawString(RELAP.App.GetPropertyName(ni.Text), Me.FontCol1, New SolidBrush(Me.LineColor), X + Padding, Y + n * maxH + Padding)
                                g.DrawString(ni.Value, Me.FontCol2, New SolidBrush(Me.LineColor), X + maxL1 + (i + 1) * maxL2a, Y + n * maxH + Padding, format1)
                                g.DrawLine(Me.m_BorderPen, X + maxL1 + (i + 1) * maxL2a + 2 * Me.Padding, Y + maxH, X + maxL1 + (i + 1) * maxL2a + 2 * Me.Padding, Y + Height)
                                If i = m_items.Count - 1 Then g.DrawString(ni.Unit, Me.FontCol3, New SolidBrush(Me.LineColor), X + maxL1 + (i + 1) * maxL2a + 3 * Padding, Y + n * maxH + Padding)
                                g.DrawLine(Me.m_BorderPen, X, Y + n * maxH, X + Width, Y + n * maxH)
                                n += 1
                            Next
                            i += 1
                        Next
                    Else
                        For Each s As String In m_items.Keys
                            n = 1
                            For Each ni In m_items(s)
                                If i = 0 Then g.DrawString(RELAP.App.GetPropertyName(ni.Text), Me.FontCol1, New SolidBrush(Me.LineColor), X + Padding, Y + n * maxH + Padding)
                                g.DrawString(ni.Value, Me.FontCol2, New SolidBrush(Me.LineColor), X + maxL1 + (i + 1) * maxL2a, Y + n * maxH + Padding, format1)
                                g.DrawLine(Me.m_BorderPen, X + maxL1 + (i + 1) * maxL2a + 2 * Me.Padding, Y + maxH, X + maxL1 + (i + 1) * maxL2a + 2 * Me.Padding, Y + Height)
                                If i = m_items.Count - 1 Then g.DrawString(ni.Unit, Me.FontCol3, New SolidBrush(Me.LineColor), X + maxL1 + (i + 1) * maxL2a + 3 * Padding, Y + n * maxH + Padding)
                                g.DrawLine(Me.m_BorderPen, X, Y + n * maxH, X + Width, Y + n * maxH)
                                n += 1
                            Next
                            i += 1
                        Next
                    End If
                Else
                    Me.Height = 40
                End If
            Else
                Me.Height = 40
            End If

            g.DrawRectangle(Me.m_BorderPen, New Rectangle(Me.X, Me.Y, Me.Width, Me.Height))
            g.DrawLine(Me.m_BorderPen, X, Y + maxH, X + Width, Y + maxH)
            g.DrawLine(Me.m_BorderPen, X + maxL1, Y + maxH, X + maxL1, Y + Height)

            g.EndContainer(gContainer)

        End Sub

    End Class

    <Serializable()> Public Class TableGraphic
        Inherits ShapeGraphic

        Public BaseOwner As SimulationObjects_BaseClass

        Protected m_Font_Col1 As Font = New Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Pixel, 0, False)
        Protected m_Font_Col2 As Font = New Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Pixel, 0, False)
        Protected m_Font_Col3 As Font = New Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Pixel, 0, False)
        Protected m_HeaderFont As Font = New Font("Verdana", 10, FontStyle.Bold, GraphicsUnit.Pixel, 0, False)

        Protected m_Text As String = ""

        Protected m_Color_Bg As Color = Drawing.Color.White
        Protected m_Color_Gradient_1 As Color = Drawing.Color.LightGray
        Protected m_Color_Gradient_2 As Color = Drawing.Color.WhiteSmoke

        Protected m_bgOpacity As Integer = 175

        Protected m_IsGradientBg As Boolean = False

        Protected m_BorderThickness As Integer = 1
        Protected m_Padding As Integer = 2

        <System.NonSerialized()> Protected m_BorderPen As Drawing.Pen = New Drawing.Pen(Color.Black)
        Protected m_BorderStyle As Drawing2D.DashStyle = DashStyle.Solid
        Protected m_BorderColor As Color = Color.Black

        Protected m_TextRenderStyle As Drawing2D.SmoothingMode = Drawing2D.SmoothingMode.Default

#Region "Constructors"
        Public Sub New(ByRef owner As SimulationObjects_BaseClass)
            Me.TipoObjeto = TipoObjeto.GO_Tabela
            Me.BaseOwner = owner
        End Sub

        Public Sub New(ByRef owner As SimulationObjects_BaseClass, ByVal graphicPosition As Point)
            Me.New(owner)
            Me.SetPosition(graphicPosition)
        End Sub

        Public Sub New(ByRef owner As SimulationObjects_BaseClass, ByVal posX As Integer, ByVal posY As Integer)
            Me.New(owner, New Point(posX, posY))
        End Sub

#End Region

#Region "Properties"

        Public Property HeaderFont() As Font
            Get
                Return m_HeaderFont
            End Get
            Set(ByVal Value As Font)
                m_HeaderFont = Value
            End Set
        End Property

        Public Property FontCol1() As Font
            Get
                Return m_Font_Col1
            End Get
            Set(ByVal Value As Font)
                m_Font_Col1 = Value
            End Set
        End Property

        Public Property FontCol2() As Font
            Get
                Return m_Font_Col2
            End Get
            Set(ByVal Value As Font)
                m_Font_Col2 = Value
            End Set
        End Property

        Public Property FontCol3() As Font
            Get
                Return m_Font_Col3
            End Get
            Set(ByVal Value As Font)
                m_Font_Col3 = Value
            End Set
        End Property

        Public Property HeaderText() As String
            Get
                Return m_Text
            End Get
            Set(ByVal Value As String)
                m_Text = Value
            End Set
        End Property

        Public Property BorderThickness() As Integer
            Get
                Return m_BorderThickness
            End Get
            Set(ByVal value As Integer)
                m_BorderThickness = value
            End Set
        End Property

        Public Property Padding() As Integer
            Get
                Return m_Padding
            End Get
            Set(ByVal value As Integer)
                m_Padding = value
            End Set
        End Property

        Public Property Opacity() As Integer
            Get
                Return m_bgOpacity
            End Get
            Set(ByVal value As Integer)
                m_bgOpacity = value
            End Set
        End Property

        Public Property BackgroundColor() As System.Drawing.Color
            Get
                Return m_Color_Bg
            End Get
            Set(ByVal Value As System.Drawing.Color)
                m_Color_Bg = Value
            End Set
        End Property

        Public Property BackgroundGradientColor1() As System.Drawing.Color
            Get
                Return m_Color_Gradient_1
            End Get
            Set(ByVal Value As System.Drawing.Color)
                m_Color_Gradient_1 = Value
            End Set
        End Property

        Public Property BackgroundGradientColor2() As System.Drawing.Color
            Get
                Return m_Color_Gradient_2
            End Get
            Set(ByVal Value As System.Drawing.Color)
                m_Color_Gradient_2 = Value
            End Set
        End Property

        Public Property BorderStyle() As Drawing.Drawing2D.DashStyle
            Get
                Return m_BorderStyle
            End Get
            Set(ByVal value As Drawing.Drawing2D.DashStyle)
                m_BorderStyle = value
            End Set
        End Property

        Public Property BorderColor() As Drawing.Color
            Get
                Return m_BorderColor
            End Get
            Set(ByVal value As Drawing.Color)
                m_BorderColor = value
            End Set
        End Property

        Public Property TextRenderStyle() As Drawing2D.SmoothingMode
            Get
                Return m_TextRenderStyle
            End Get
            Set(ByVal value As Drawing2D.SmoothingMode)
                m_TextRenderStyle = value
            End Set
        End Property

        Property IsGradientBackground() As Boolean
            Get
                Return m_IsGradientBg
            End Get
            Set(ByVal value As Boolean)
                m_IsGradientBg = value
            End Set
        End Property
#End Region

        Public Sub PopulateGrid(ByRef pgrid As PropertyGridEx.PropertyGridEx)

            With pgrid

                .Item.Clear()

                Dim ni As RELAP.Outros.NodeItem

                For Each ni In Me.BaseOwner.NodeTableItems.Values
                    .Item.Add(RELAP.App.GetPropertyName(ni.Text), ni, "Checked", False, "", "", True)
                Next

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True

            End With

        End Sub

        Public Overrides Sub Draw(ByVal g As System.Drawing.Graphics)

            Dim gContainer As System.Drawing.Drawing2D.GraphicsContainer
            Dim myMatrix As Drawing2D.Matrix
            gContainer = g.BeginContainer()
            myMatrix = g.Transform()
            If m_Rotation <> 0 Then
                myMatrix.RotateAt(m_Rotation, New PointF(X, Y), Drawing.Drawing2D.MatrixOrder.Append)
                g.Transform = myMatrix
            End If

            If Not Me.TextRenderStyle = -1 Then g.TextRenderingHint = Me.TextRenderStyle

            Dim maxL1, maxL2, maxL3, count As Integer
            Dim maxH As Integer

            'determinar comprimento das colunas e altura das linhas
            maxL1 = 0
            maxL2 = 0
            maxL3 = 0
            maxH = 0
            count = 1
            Dim size As SizeF
            Dim ni As RELAP.Outros.NodeItem
            For Each ni In Me.BaseOwner.NodeTableItems.Values
                If ni.Checked = True Then
                    If ni.Level = 0 And ni.ParentNode = "" Or ni.Level > 0 And ni.ParentNode <> "" Then
                        size = g.MeasureString(RELAP.App.GetPropertyName(ni.Text), Me.FontCol1, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                        If size.Width > maxL1 Then maxL1 = size.Width
                        If size.Height > maxH Then maxH = size.Height
                        If Double.TryParse(ni.Value, New Double) Then
                            size = g.MeasureString(Format(CDbl(ni.Value), Me.BaseOwner.FlowSheet.Options.NumberFormat), Me.FontCol2, New PointF(0, 0), New StringFormat(StringFormatFlags.DirectionRightToLeft, 0))
                        Else
                            size = g.MeasureString(ni.Value, Me.FontCol2, New PointF(0, 0), New StringFormat(StringFormatFlags.DirectionRightToLeft, 0))
                        End If
                        If size.Width > maxL2 Then maxL2 = size.Width
                        If size.Height > maxH Then maxH = size.Height
                        size = g.MeasureString(ni.Unit, Me.FontCol3, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                        If size.Width > maxL3 Then maxL3 = size.Width
                        If size.Height > maxH Then maxH = size.Height
                        count += 1
                    End If
                End If
            Next
            size = g.MeasureString(Me.HeaderText, Me.HeaderFont, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
            If size.Width > maxL1 Then maxL1 = size.Width
            If size.Height > maxH Then maxH = size.Height

            Me.Height = (count) * (maxH + 2 * Me.Padding)
            Me.Width = 6 * Me.Padding + maxL1 + maxL2 + maxL3

            maxL1 = maxL1 + 2 * Padding
            maxL2 = maxL2 + 2 * Padding
            maxL3 = maxL3 + 2 * Padding
            maxH = maxH + 2 * Padding

            If m_BorderPen Is Nothing Then m_BorderPen = New Drawing.Pen(Color.Black)

            With Me.m_BorderPen
                .Color = Me.BorderColor
                .DashStyle = Me.BorderStyle
            End With

            Dim rect As New Rectangle(X, Y, Width, Height)
            If Me.IsGradientBackground = False Then
                g.FillRectangle(New SolidBrush(Color.FromArgb(Me.Opacity, Me.BackgroundColor)), rect)
            Else
                g.FillRectangle(New Drawing2D.LinearGradientBrush(rect, Color.FromArgb(Me.Opacity, Me.BackgroundGradientColor2), Color.FromArgb(Me.Opacity, Me.BackgroundGradientColor1), LinearGradientMode.Vertical), rect)
            End If

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            With format1
                .Alignment = StringAlignment.Far
                '.LineAlignment = StringAlignment.Far
            End With

            'desenhar textos e retangulos
            g.DrawString(Me.HeaderText, Me.HeaderFont, New SolidBrush(Me.LineColor), X + Padding, Y + Padding)
            Dim n As Integer = 1
            For Each ni In Me.BaseOwner.NodeTableItems.Values
                If ni.Checked = True Then
                    If ni.Level = 0 And ni.ParentNode = "" Or ni.Level > 0 And ni.ParentNode <> "" Then
                        g.DrawString(RELAP.App.GetPropertyName(ni.Text), Me.FontCol1, New SolidBrush(Me.LineColor), X + Padding, Y + n * maxH + Padding)
                        If Double.TryParse(ni.Value, New Double) Then
                            g.DrawString(Format(CDbl(ni.Value), Me.BaseOwner.FlowSheet.Options.NumberFormat), Me.FontCol2, New SolidBrush(Me.LineColor), X + maxL1 + maxL2, Y + n * maxH + Padding, format1)
                        Else
                            g.DrawString(ni.Value, Me.FontCol2, New SolidBrush(Me.LineColor), X + maxL1 + maxL2, Y + n * maxH + Padding, format1)
                        End If
                        g.DrawString(ni.Unit, Me.FontCol3, New SolidBrush(Me.LineColor), X + maxL1 + maxL2 + Padding, Y + n * maxH + Padding)
                        g.DrawLine(Me.m_BorderPen, X, Y + n * maxH, X + Width, Y + n * maxH)
                        n += 1
                    End If
                End If
            Next

            g.DrawRectangle(Me.m_BorderPen, New Rectangle(Me.X, Me.Y, Me.Width, Me.Height))
            g.DrawLine(Me.m_BorderPen, X, Y + maxH, X + Width, Y + maxH)
            g.DrawLine(Me.m_BorderPen, X + maxL1, Y + maxH, X + maxL1, Y + Height)
            g.DrawLine(Me.m_BorderPen, X + maxL1 + maxL2, Y + maxH, X + maxL1 + maxL2, Y + Height)

            g.EndContainer(gContainer)

        End Sub

    End Class

    <Serializable()> Public Class QuickTableGraphic
        Inherits ShapeGraphic

        Public BaseOwner As SimulationObjects_BaseClass

        Protected m_HeaderFont As Font = New Font("Verdana", 10, FontStyle.Bold, GraphicsUnit.Pixel, 0, False)

        Protected m_Text As String = ""

        Protected m_Color_Bg As Color = Drawing.Color.Black
        Protected m_Color_Gradient_1 As Color = Drawing.Color.LightSteelBlue
        Protected m_Color_Gradient_2 As Color = Drawing.Color.RoyalBlue

        Protected m_bgOpacity As Integer = 140

        Protected m_IsGradientBg As Boolean = True

        Protected m_BorderThickness As Integer = 1
        Protected m_Padding As Integer = 2

        <System.NonSerialized()> Protected m_BorderPen As Drawing.Pen = New Drawing.Pen(Color.Gray)
        Protected m_BorderStyle As Drawing2D.DashStyle = DashStyle.Solid
        Protected m_BorderColor As Color = Color.Black

        Protected m_TextRenderStyle As Drawing2D.SmoothingMode = Drawing2D.SmoothingMode.Default

#Region "Constructors"
        Public Sub New(ByRef owner As SimulationObjects_BaseClass)
            Me.TipoObjeto = TipoObjeto.GO_TabelaRapida
            Me.BaseOwner = owner
        End Sub

        Public Sub New(ByRef owner As SimulationObjects_BaseClass, ByVal graphicPosition As Point)
            Me.New(owner)
            Me.SetPosition(graphicPosition)
        End Sub

        Public Sub New(ByRef owner As SimulationObjects_BaseClass, ByVal posX As Integer, ByVal posY As Integer)
            Me.New(owner, New Point(posX, posY))
        End Sub

#End Region

#Region "Properties"

        Public Property HeaderFont() As Font
            Get
                Return m_HeaderFont
            End Get
            Set(ByVal Value As Font)
                m_HeaderFont = Value
            End Set
        End Property

        Public Property HeaderText() As String
            Get
                Return m_Text
            End Get
            Set(ByVal Value As String)
                m_Text = Value
            End Set
        End Property

        Public Property BorderThickness() As Integer
            Get
                Return m_BorderThickness
            End Get
            Set(ByVal value As Integer)
                m_BorderThickness = value
            End Set
        End Property

        Public Property Padding() As Integer
            Get
                Return m_Padding
            End Get
            Set(ByVal value As Integer)
                m_Padding = value
            End Set
        End Property

        Public Property Opacity() As Integer
            Get
                Return m_bgOpacity
            End Get
            Set(ByVal value As Integer)
                m_bgOpacity = value
            End Set
        End Property

        Public Property BackgroundColor() As System.Drawing.Color
            Get
                Return m_Color_Bg
            End Get
            Set(ByVal Value As System.Drawing.Color)
                m_Color_Bg = Value
            End Set
        End Property

        Public Property BackgroundGradientColor1() As System.Drawing.Color
            Get
                Return m_Color_Gradient_1
            End Get
            Set(ByVal Value As System.Drawing.Color)
                m_Color_Gradient_1 = Value
            End Set
        End Property

        Public Property BackgroundGradientColor2() As System.Drawing.Color
            Get
                Return m_Color_Gradient_2
            End Get
            Set(ByVal Value As System.Drawing.Color)
                m_Color_Gradient_2 = Value
            End Set
        End Property

        Public Property BorderStyle() As Drawing.Drawing2D.DashStyle
            Get
                Return m_BorderStyle
            End Get
            Set(ByVal value As Drawing.Drawing2D.DashStyle)
                m_BorderStyle = value
            End Set
        End Property

        Public Property BorderColor() As Drawing.Color
            Get
                Return m_BorderColor
            End Get
            Set(ByVal value As Drawing.Color)
                m_BorderColor = value
            End Set
        End Property

        Public Property TextRenderStyle() As Drawing2D.SmoothingMode
            Get
                Return m_TextRenderStyle
            End Get
            Set(ByVal value As Drawing2D.SmoothingMode)
                m_TextRenderStyle = value
            End Set
        End Property

        Property IsGradientBackground() As Boolean
            Get
                Return m_IsGradientBg
            End Get
            Set(ByVal value As Boolean)
                m_IsGradientBg = value
            End Set
        End Property
#End Region

        Public Overrides Sub Draw(ByVal g As System.Drawing.Graphics)

            If Me.BaseOwner.ShowQuickTable Then

                Me.Opacity = 225

                Dim gContainer As System.Drawing.Drawing2D.GraphicsContainer
                Dim myMatrix As Drawing2D.Matrix
                gContainer = g.BeginContainer()
                myMatrix = g.Transform()
                If m_Rotation <> 0 Then
                    myMatrix.RotateAt(m_Rotation, New PointF(X, Y), Drawing.Drawing2D.MatrixOrder.Append)
                    g.Transform = myMatrix
                End If

                'If Not Me.TextRenderStyle = -1 Then g.TextRenderingHint = Me.TextRenderStyle

                Dim maxL1, maxL2, maxL3, count As Integer
                Dim maxH As Integer

                'determinar comprimento das colunas e altura das linhas
                maxL1 = 0
                maxL2 = 0
                maxL3 = 0
                maxH = 0
                count = 1
                Dim size, size2 As SizeF
                Dim ni As RELAP.Outros.NodeItem
                For Each ni In Me.BaseOwner.QTNodeTableItems.Values
                    size = g.MeasureString(ni.Text, Me.HeaderFont, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                    If size.Width > maxL1 Then maxL1 = size.Width
                    If size.Height > maxH Then maxH = size.Height
                    size = g.MeasureString(ni.Value, Me.HeaderFont, New PointF(0, 0), New StringFormat(StringFormatFlags.DirectionRightToLeft, 0))
                    If size.Width > maxL2 Then maxL2 = size.Width
                    If size.Height > maxH Then maxH = size.Height
                    size = g.MeasureString(ni.Unit, Me.HeaderFont, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                    If size.Width > maxL3 Then maxL3 = size.Width
                    If size.Height > maxH Then maxH = size.Height
                    count += 1
                Next
                'size = g.MeasureString(Me.HeaderText, Me.HeaderFont, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                'If size.Width > maxL1 Then maxL1 = size.Width
                'If size.Height > maxH Then maxH = size.Height

                If maxH = 0 Then maxH = 20

                Me.Height = (count + 1) * (maxH + 2 * Me.Padding)
                size = g.MeasureString(Me.HeaderText, Me.HeaderFont, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))
                size2 = g.MeasureString(RELAP.App.GetLocalString(Me.BaseOwner.GraphicObject.Description), Me.HeaderFont, New PointF(0, 0), New StringFormat(StringFormatFlags.NoClip, 0))

                If size.Width > size2.Width Then
                    If size.Width > (2 * Me.Padding + maxL1 + maxL2 + maxL3) Then
                        Me.Width = 2 * Me.Padding + size.Width
                    Else
                        Me.Width = 6 * Me.Padding + maxL1 + maxL2 + maxL3
                    End If
                Else
                    If size2.Width > (2 * Me.Padding + maxL1 + maxL2 + maxL3) Then
                        Me.Width = 2 * Me.Padding + size2.Width
                    Else
                        Me.Width = 6 * Me.Padding + maxL1 + maxL2 + maxL3
                    End If
                End If

                maxL1 = maxL1 + 2 * Padding
                maxL2 = maxL2 + 2 * Padding
                maxL3 = maxL3 + 2 * Padding

                maxH = maxH + 2 * Padding

                If m_BorderPen Is Nothing Then m_BorderPen = New Drawing.Pen(Color.Black)

                With Me.m_BorderPen
                    .Color = Color.White
                    .DashStyle = Me.BorderStyle
                End With

                Dim rect0 As New Rectangle(X + 4, Y + 4, Width, Height)
                DrawRoundRect(g, Pens.Transparent, rect0.X, rect0.Y, rect0.Width, rect0.Height, 10, New SolidBrush(Color.FromArgb(100, Color.Gray)))
                'g.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.DimGray)), rect0)
                'Me.DrawRoundRect(g, New Pen(Color.Transparent), X + 4, Y + 4, Width, Height, 10, New SolidBrush(Color.FromArgb(50, Color.DimGray)))


                m_Color_Gradient_1 = Drawing.Color.SteelBlue
                m_Color_Gradient_2 = Color.FromArgb(255, 29, 80, 132)
                Opacity = 255

                'm_Color_Gradient_1 = Drawing.Color.WhiteSmoke
                'm_Color_Gradient_2 = Drawing.Color.Gainsboro

                Dim rect As New Rectangle(X, Y, Width, Height)
                If Me.IsGradientBackground = False Then
                    'g.FillRectangle(New SolidBrush(Color.FromArgb(Me.Opacity, Me.FillColor)), rect)
                    DrawRoundRect(g, Pens.Transparent, rect.X, rect.Y, rect.Width, rect.Height, 10, New SolidBrush(Color.FromArgb(Me.Opacity, Me.FillColor)))
                Else
                    'g.FillRectangle(New Drawing2D.LinearGradientBrush(rect, Color.FromArgb(Me.Opacity, Me.BackgroundGradientColor1), Color.FromArgb(Me.Opacity, Me.BackgroundGradientColor2), LinearGradientMode.Vertical), rect)
                    DrawRoundRect(g, Pens.Transparent, rect.X, rect.Y, rect.Width, rect.Height, 10, New Drawing2D.LinearGradientBrush(rect, Color.FromArgb(Me.Opacity, Me.BackgroundGradientColor1), Color.FromArgb(Me.Opacity, Me.BackgroundGradientColor2), LinearGradientMode.Vertical))
                End If

                Dim format1 As New StringFormat(StringFormatFlags.NoClip)
                With format1
                    .Alignment = StringAlignment.Far
                    '.LineAlignment = StringAlignment.Far
                End With

                'desenhar textos e retangulos
                Me.HeaderFont = New Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Pixel, 0, False)
                g.DrawString(Me.BaseOwner.GraphicObject.Tag, Me.HeaderFont, New SolidBrush(Color.White), X + Padding, Y + Padding)
                g.DrawString(RELAP.App.GetLocalString(Me.BaseOwner.GraphicObject.Description), Me.HeaderFont, New SolidBrush(Color.White), X + Padding, Y + maxH)
                Dim n As Integer = 1
                For Each ni In Me.BaseOwner.QTNodeTableItems.Values
                    g.DrawString(ni.Text, Me.HeaderFont, New SolidBrush(Color.White), X + Padding, Y + (n + 1) * maxH + Padding)
                    g.DrawString(ni.Value, Me.HeaderFont, New SolidBrush(Color.White), X + maxL1 + maxL2, Y + (n + 1) * maxH + Padding, format1)
                    g.DrawString(ni.Unit, Me.HeaderFont, New SolidBrush(Color.White), X + maxL1 + maxL2 + Padding, Y + (n + 1) * maxH + Padding)
                    'g.DrawLine(Me.m_BorderPen, X, Y + n * maxH, X + Width, Y + n * maxH)
                    n += 1
                Next


                'g.DrawRectangle(Me.m_BorderPen, New Rectangle(Me.X, Me.Y, Me.Width, Me.Height))
                DrawRoundRect(g, Me.m_BorderPen, Me.X, Me.Y, Me.Width, Me.Height, 10, Brushes.Transparent)
                'Me.DrawRoundRect(g, Me.m_BorderPen, X, Y, Width, Height, 5, New SolidBrush(Color.FromArgb(Me.Opacity, Color.GhostWhite)))
                g.DrawLine(Me.m_BorderPen, X + 2 * Padding, Y + 2 * maxH - Padding, X + Width - 2 * Padding, Y + 2 * maxH - Padding)
                'g.DrawLine(Me.m_BorderPen, X + maxL1, Y + maxH, X + maxL1, Y + Height)
                'g.DrawLine(Me.m_BorderPen, X + maxL1 + maxL2, Y + maxH, X + maxL1 + maxL2, Y + Height)

                g.EndContainer(gContainer)

            End If

        End Sub

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


End Namespace

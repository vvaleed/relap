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

Imports System.Drawing
Imports System.Collections.Generic

Namespace GraphicObjects

    Public Enum TipoObjeto

        Subsystem
        Simulator
        NodeIn
        NodeOut
        NodeEn
        Pump
        Tank
        FuelRod
        Vessel
        MaterialStream
        EnergyStream
        Compressor
        Expander
        TPVessel
        SingleVolume
        SingleJunction
        TimeDependentJunction
        Heater
        Pipe
        Branch
        Separator
        Valve
        Nenhum
        GO_Tabela
        GO_Texto
        GO_Figura
        GO_TabelaRapida
        OT_Ajuste
        OT_Especificacao
        OT_Reciclo
        RCT_Conversion
        RCT_Equilibrium
        RCT_Gibbs
        RCT_CSTR
        RCT_PFR
        HeatStructure
        ShortcutColumn
        DistillationColumn
        AbsorptionColumn
        RefluxedAbsorber
        ReboiledAbsorber
        OT_EnergyRecycle
        GO_Animation
        ComponentSeparator
        OrificePlate
        CustomUO
        CapeOpenUO
        GO_MasterTable

    End Enum

    Public Enum ShapeIcon

        DefaultShape
        NodeIn
        NodeOut
        Pump
        Tank
        FuelRod
        Vessel
        Compressor
        Expander
        Cooler
        Heater
        Pipe
        Valve
        RCT_Conversion
        RCT_Equilibrium
        RCT_Gibbs
        RCT_CSTR
        RCT_PFR
        HeatStructure
        DistillationColumn
        AbsorptionColumn
        ComponentSeparator
        OrificePlate

    End Enum

    Public Enum Status
        Calculated
        Calculating
        ErrorCalculating
        Inactive
        Idle
        NotCalculated
    End Enum

    <System.Serializable()> Public MustInherit Class GraphicObject

        Protected m_Position As New Point(0, 0)
        Protected m_Size As New Size(0, 0)
        Protected m_Rotation As Single = 0
        Protected m_AutoSize As Boolean = True
        Protected m_Container As GraphicObjectCollection
        Protected m_Name As String = ""
        Protected m_IsConnector As Boolean = False
        Protected m_InputConnectors As New System.Collections.Generic.List(Of ConnectionPoint)
        Protected m_OutputConnectors As New System.Collections.Generic.List(Of ConnectionPoint)
        Protected m_EnergyConnector As New ConnectionPoint
        Protected m_SpecialConnectors As New System.Collections.Generic.List(Of ConnectionPoint)
        Protected m_tag As String = ""
        Protected m_active As Boolean = True
        Protected m_calculated As Boolean = False
        Protected m_isenergy As Boolean = False
        Protected m_tipoobjeto As TipoObjeto = TipoObjeto.Nenhum
        Protected m_flippedV As Boolean = False
        Protected m_flippedH As Boolean = False
        Protected m_shape As Integer = 0
        Protected m_ainfo As Object = Nothing
        Protected m_objdesc As String = ""
        Protected m_status As Status = Status.NotCalculated
        Protected m_icon As ShapeIcon = ShapeIcon.DefaultShape

        Public Property ShapeOverride() As ShapeIcon
            Get
                Return m_icon
            End Get
            Set(ByVal value As ShapeIcon)
                m_icon = value
            End Set
        End Property

        Public Property Status() As Status
            Get
                Return m_status
            End Get
            Set(ByVal value As Status)
                m_status = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_objdesc
            End Get
            Set(ByVal value As String)
                m_objdesc = value
            End Set
        End Property

        Public Property AdditionalInfo() As Object
            Get
                Return m_ainfo
            End Get
            Set(ByVal value As Object)
                m_ainfo = value
            End Set
        End Property

        Public Property Shape() As Integer
            Get
                Return m_shape
            End Get
            Set(ByVal value As Integer)
                m_shape = value
            End Set
        End Property

        Public Property FlippedH() As Boolean
            Get
                Return Me.m_flippedH
            End Get
            Set(ByVal value As Boolean)
                Me.m_flippedH = value
            End Set
        End Property

        Public Property FlippedV() As Boolean
            Get
                Return Me.m_flippedV
            End Get
            Set(ByVal value As Boolean)
                Me.m_flippedV = value
            End Set
        End Property

        Public Property TipoObjeto() As TipoObjeto
            Get
                Return m_tipoobjeto
            End Get
            Set(ByVal tipo As TipoObjeto)
                m_tipoobjeto = tipo
            End Set
        End Property

        Public Property IsEnergyStream() As Boolean
            Get
                Return m_isenergy
            End Get
            Set(ByVal Value As Boolean)
                m_isenergy = Value
            End Set
        End Property

        Public Overridable Property Active() As Boolean
            Get
                Return m_active
            End Get
            Set(ByVal Value As Boolean)
                Try
                    m_active = Value
                Catch ex As Exception
                    MsgBox("Erro ao ativar objeto.", MsgBoxStyle.Critical, "Erro")
                End Try
            End Set
        End Property

        Public Overridable Property Calculated() As Boolean
            Get
                Select Case Status
                    Case GraphicObjects.Status.Calculated
                        Return True
                    Case GraphicObjects.Status.Calculating
                        Return False
                    Case GraphicObjects.Status.ErrorCalculating
                        Return False
                    Case GraphicObjects.Status.Idle
                        Return True
                    Case GraphicObjects.Status.Inactive
                        Return False
                    Case GraphicObjects.Status.NotCalculated
                        Return False
                    Case Else
                        Return False
                End Select
            End Get
            Set(ByVal Value As Boolean)
                m_calculated = Value
                If Value = False Then
                    Status = GraphicObjects.Status.ErrorCalculating
                Else
                    Status = GraphicObjects.Status.Calculated
                End If
            End Set
        End Property

        Public Overridable Overloads Property Tag() As String
            Get
                Return m_tag
            End Get
            Set(ByVal Value As String)
                Try
                    m_tag = CStr(Value)
                Catch ex As Exception
                    MsgBox("Erro ao identificar objeto.", MsgBoxStyle.Critical, "Erro")
                End Try
            End Set
        End Property

        Public Property Container() As GraphicObjectCollection
            Get
                Return m_Container
            End Get
            Set(ByVal Value As GraphicObjectCollection)
                m_Container = Value
            End Set
        End Property

        Public Property InputConnectors() As System.Collections.Generic.List(Of ConnectionPoint)
            Get
                Return m_InputConnectors
            End Get
            Set(ByVal Value As System.Collections.Generic.List(Of ConnectionPoint))
                m_InputConnectors = Value
            End Set
        End Property

        Public Property OutputConnectors() As System.Collections.Generic.List(Of ConnectionPoint)
            Get
                Return m_OutputConnectors
            End Get
            Set(ByVal Value As System.Collections.Generic.List(Of ConnectionPoint))
                m_OutputConnectors = Value
            End Set
        End Property

        Public Property SpecialConnectors() As System.Collections.Generic.List(Of ConnectionPoint)
            Get
                Return m_SpecialConnectors
            End Get
            Set(ByVal Value As System.Collections.Generic.List(Of ConnectionPoint))
                m_SpecialConnectors = Value
            End Set
        End Property

        Public Property EnergyConnector() As ConnectionPoint
            Get
                Return Me.m_EnergyConnector
            End Get
            Set(ByVal Value As ConnectionPoint)
                Me.m_EnergyConnector = Value
            End Set
        End Property

        Public Overridable Overloads Function HitTest(ByVal pt As System.Drawing.Point) As Boolean
            Dim gp As New Drawing2D.GraphicsPath()
            Dim myMatrix As New Drawing2D.Matrix()

            gp.AddRectangle(New Rectangle(X, Y, Width, Height))
            If Me.Rotation <> 0 Then
                myMatrix.RotateAt(Me.Rotation, New PointF(Me.X, Me.Y), _
                    Drawing.Drawing2D.MatrixOrder.Append)
            End If

            gp.Transform(myMatrix)
            Return gp.IsVisible(pt)
        End Function

        Public Overridable Overloads Function HitTest(ByVal rect As Rectangle) As Boolean
            'is this object contained within the supplied rectangle
            Dim gp As New Drawing2D.GraphicsPath()
            Dim myMatrix As New Drawing2D.Matrix()

            gp.AddRectangle(New Rectangle(X, Y, Width, Height))
            If Me.Rotation <> 0 Then
                myMatrix.RotateAt(Me.Rotation, New PointF(Me.X, Me.Y), _
                    Drawing.Drawing2D.MatrixOrder.Append)
            End If
            gp.Transform(myMatrix)
            Dim gpRect As Rectangle = Rectangle.Round(gp.GetBounds)
            Return rect.Contains(gpRect)
        End Function


#Region "Constructors"
        Protected Sub New()
        End Sub

        Protected Sub New(ByVal graphicPosition As Point)
            Me.New()
            Me.SetPosition(graphicPosition)
        End Sub

        Protected Sub New(ByVal posX As Integer, ByVal posY As Integer)
            Me.New(New Point(posX, posY))
        End Sub

        Protected Sub New(ByVal graphicPosition As Point, ByVal graphicSize As Size)
            Me.New(graphicPosition)
            Me.SetSize(graphicSize)
            Me.AutoSize = False
        End Sub

        Protected Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal graphicSize As Size)
            Me.New(New Point(posX, posY), graphicSize)
        End Sub

        Protected Sub New(ByVal posX As Integer, ByVal posY As Integer, _
                ByVal width As Integer, ByVal height As Integer)
            Me.New(New Point(posX, posY), New Size(width, height))
        End Sub

        Protected Sub New(ByVal graphicPosition As Point, ByVal Rotation As Single)
            Me.New()
            Me.SetPosition(graphicPosition)
            Me.Rotation = Rotation
        End Sub

        Protected Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal Rotation As Single)
            Me.New(New Point(posX, posY), Rotation)
        End Sub

        Protected Sub New(ByVal graphicPosition As Point, ByVal graphicSize As Size, ByVal Rotation As Single)
            Me.New(graphicPosition, Rotation)
            Me.SetSize(graphicSize)
            Me.AutoSize = False
        End Sub

        Protected Sub New(ByVal posX As Integer, ByVal posY As Integer, _
            ByVal graphicSize As Size, ByVal Rotation As Single)
            Me.New(New Point(posX, posY), graphicSize, Rotation)
        End Sub

        Protected Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, _
                               ByVal height As Integer, ByVal Rotation As Single)
            Me.New(New Point(posX, posY), New Size(width, height), Rotation)
        End Sub

#End Region

        Public Overridable Property AutoSize() As Boolean
            Get
                Return m_AutoSize
            End Get
            Set(ByVal Value As Boolean)
                If Value <> m_AutoSize Then
                    m_AutoSize = Value
                End If
            End Set
        End Property

        Public Overridable Property IsConnector() As Boolean
            Get
                Return m_IsConnector
            End Get
            Set(ByVal Value As Boolean)
                If Value <> m_IsConnector Then
                    m_IsConnector = Value
                End If
            End Set
        End Property

        Public Overridable Property X() As Integer
            Get
                Return m_Position.X
            End Get
            Set(ByVal Value As Integer)
                m_Position.X = Value
            End Set
        End Property

        Public Overridable Property Y() As Integer
            Get
                Return m_Position.Y
            End Get
            Set(ByVal Value As Integer)
                m_Position.Y = Value
            End Set
        End Property

        Public Overridable Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal name As String)
                m_Name = name
            End Set
        End Property

        Public Overridable Function GetPosition() As Point
            Dim myPosition As New Point(m_Position.X, m_Position.Y)
            Return myPosition
        End Function

        Public Overridable Sub SetPosition(ByVal Value As Point)
            'any value is currently ok,
            'but I might want to add validation later.
            m_Position = Value
        End Sub

        Public Overridable Property Height() As Integer
            Get
                Return m_Size.Height
            End Get
            Set(ByVal Value As Integer)
                m_Size.Height = Value
            End Set
        End Property

        Public Overridable Property Width() As Integer
            Get
                Return m_Size.Width
            End Get
            Set(ByVal Value As Integer)
                m_Size.Width = Value
            End Set
        End Property

        Public Overridable Sub SetSize(ByVal Value As Size)
            m_Size = Value
        End Sub

        Public Overridable Function GetSize() As Size
            Dim mySize As New Size(m_Size.Width, m_Size.Height)
            Return mySize
        End Function

        Public Overridable Property Rotation() As Single
            Get
                Return m_Rotation
            End Get
            Set(ByVal Value As Single)
                If System.Math.Abs(Value) <= 360 Then
                    m_Rotation = Value
                Else
                    Throw New ArgumentOutOfRangeException("Rotation", _
                        "Rotation must be between -360.0 and 360.0")
                End If
            End Set
        End Property

        Public Overridable Sub Draw(ByVal g As Graphics)

            'Calls overriden method to position connectors, since only derived classes know their places.
            PositionConnectors()

            'Rotates them if needed.
            RotateConnectors()

        End Sub

       
        Public Overridable Sub PositionConnectors()

            'To be implemented in derived classes.

        End Sub

        Public Sub RotateConnectors()

            Dim pt As Point
            Dim raio, angulo As Double
            Dim con As ConnectionPoint
            For Each con In Me.InputConnectors
                pt = con.Position
                raio = ((pt.X - Me.X) ^ 2 + (pt.Y - Me.Y) ^ 2) ^ 0.5
                angulo = Math.Atan2(pt.Y - Me.Y, pt.X - Me.X)
                pt.X = Me.X + raio * Math.Cos(angulo + Me.Rotation / 360 * 2 * Math.PI)
                pt.Y = Me.Y + raio * Math.Sin(angulo + Me.Rotation / 360 * 2 * Math.PI)
                con.Position = pt
            Next
            For Each con In Me.OutputConnectors
                pt = con.Position
                raio = ((pt.X - Me.X) ^ 2 + (pt.Y - Me.Y) ^ 2) ^ 0.5
                angulo = Math.Atan2(pt.Y - Me.Y, pt.X - Me.X)
                pt.X = Me.X + raio * Math.Cos(angulo + Me.Rotation / 360 * 2 * Math.PI)
                pt.Y = Me.Y + raio * Math.Sin(angulo + Me.Rotation / 360 * 2 * Math.PI)
                con.Position = pt
            Next
            With Me.EnergyConnector
                pt = .Position
                raio = ((pt.X - Me.X) ^ 2 + (pt.Y - Me.Y) ^ 2) ^ 0.5
                angulo = Math.Atan2(pt.Y - Me.Y, pt.X - Me.X)
                pt.X = Me.X + raio * Math.Cos(angulo + Me.Rotation / 360 * 2 * Math.PI)
                pt.Y = Me.Y + raio * Math.Sin(angulo + Me.Rotation / 360 * 2 * Math.PI)
                .Position = pt
            End With

        End Sub

        Public Sub CreateConnectors(ByVal InCount As Integer, ByVal OutCount As Integer)

            'Creates all the connection points.

            For I As Integer = 1 To InCount

                Dim Con As New ConnectionPoint
                Con.Type = ConType.ConIn
                InputConnectors.Add(Con)

            Next

            For I As Integer = 1 To OutCount

                Dim Con As New ConnectionPoint
                Con.Type = ConType.ConOut
                OutputConnectors.Add(Con)

            Next

        End Sub

    End Class

End Namespace


Public Class PipeProfile
    Protected m_collection As Generic.SortedDictionary(Of Integer, PipeSection)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property Sections() As Generic.SortedDictionary(Of Integer, PipeSection)
        Get
            Return m_collection
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, PipeSection))
            m_collection = value
        End Set
    End Property

    Public Sub New()
        m_collection = New Generic.SortedDictionary(Of Integer, PipeSection)
    End Sub


End Class

Public Class PipeSection
    Private m_FlowArea As Double
    Public Property FlowArea() As Double
        Get
            Return m_FlowArea
        End Get
        Set(ByVal value As Double)
            m_FlowArea = value
        End Set
    End Property
    Private m_VolumeNumber As Double
    Public Property VolumeNumber() As Double
        Get
            Return m_VolumeNumber
        End Get
        Set(ByVal value As Double)
            m_VolumeNumber = value
        End Set
    End Property
    Private m_JunctionFlowArea As Double
    Public Property JunctionFlowArea() As Double
        Get
            Return m_JunctionFlowArea
        End Get
        Set(ByVal value As Double)
            m_JunctionFlowArea = value
        End Set
    End Property
    Private m_LengthofVolume As Double
    Public Property LengthofVolume() As Double
        Get
            Return m_LengthofVolume
        End Get
        Set(ByVal value As Double)
            m_LengthofVolume = value
        End Set
    End Property
    Private m_VolumeofVolume As Double
    Public Property VolumeofVolume() As Double
        Get
            Return m_VolumeofVolume
        End Get
        Set(ByVal value As Double)
            m_VolumeofVolume = value
        End Set
    End Property
    Private m_VerticalAngle As Double
    Public Property VerticalAngle() As Double
        Get
            Return m_VerticalAngle
        End Get
        Set(ByVal value As Double)
            m_VerticalAngle = value
        End Set
    End Property

    Private m_Azimuthalangle As Double
    Public Property Azimuthalangle() As Double
        Get
            Return m_Azimuthalangle
        End Get
        Set(ByVal value As Double)
            m_Azimuthalangle = value
        End Set
    End Property
    Private m_HydraulicDiameter As Double
    Public Property HydraulicDiameter() As Double
        Get
            Return m_HydraulicDiameter
        End Get
        Set(ByVal value As Double)
            m_HydraulicDiameter = value
        End Set
    End Property

    Private m_WallRoughness As Double
    Public Property WallRoughness() As Double
        Get
            Return m_WallRoughness
        End Get
        Set(ByVal value As Double)
            m_WallRoughness = value
        End Set
    End Property

    Public Sub New(ByVal VolumeNumber As Double, ByVal Azimuthalangle As Double, ByVal FlowArea As Double, ByVal HydraulicDiameter As Double, ByVal JunctionFlowArea As Double, ByVal LengthofVolume As Double, _
                     ByVal VerticalAngle As Double, ByVal VolumeofVolume As Double, ByVal WallRoughness As Double)
        Me.m_Azimuthalangle = Azimuthalangle
        Me.m_FlowArea = FlowArea
        Me.m_HydraulicDiameter = HydraulicDiameter
        Me.m_JunctionFlowArea = JunctionFlowArea
        Me.m_LengthofVolume = LengthofVolume
        Me.m_VerticalAngle = VerticalAngle
        Me.m_VolumeNumber = VolumeNumber
        Me.m_VolumeofVolume = VolumeofVolume
        Me.m_WallRoughness = WallRoughness

        '   Me.m_results = New System.Collections.Generic.List(Of PipeResults)

    End Sub
End Class
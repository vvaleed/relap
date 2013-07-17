<System.Serializable()> Public Class PipeProfile
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

    Protected m_collection2 As Generic.SortedDictionary(Of Integer, PipeJunctions)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property Junctions() As Generic.SortedDictionary(Of Integer, PipeJunctions)
        Get
            Return m_collection2
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, PipeJunctions))
            m_collection2 = value
        End Set
    End Property

    Public Sub New()
        m_collection = New Generic.SortedDictionary(Of Integer, PipeSection)
        m_collection2 = New Generic.SortedDictionary(Of Integer, PipeJunctions)
    End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function

End Class

Public Class PipeSection
    Private m_VolumeNumber As Double
    Public Property VolumeNumber() As Double
        Get
            Return m_VolumeNumber
        End Get
        Set(ByVal value As Double)
            m_VolumeNumber = value
        End Set
    End Property

    Private m_FlowArea As Double
    Public Property FlowArea() As Double
        Get
            Return m_FlowArea
        End Get
        Set(ByVal value As Double)
            m_FlowArea = value
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

    Private m_Azimuthalangle As Double
    Public Property Azimuthalangle() As Double
        Get
            Return m_Azimuthalangle
        End Get
        Set(ByVal value As Double)
            m_Azimuthalangle = value
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

    Private m_ElevationChange As Double
    Public Property ElevationChange() As Double
        Get
            Return m_ElevationChange
        End Get
        Set(ByVal value As Double)
            m_ElevationChange = value
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

    'control flags variable initialization

    Private m_t As Boolean
    Public Property ThermalStratificationModel() As Boolean
        Get
            Return m_t
        End Get
        Set(ByVal value As Boolean)
            m_t = value
        End Set
    End Property

    Private m_l As Boolean
    Public Property LevelTrackingModel() As Boolean
        Get
            Return m_l
        End Get
        Set(ByVal value As Boolean)
            m_l = value
        End Set
    End Property

    Private m_p As Boolean
    Public Property WaterPackingScheme() As Boolean
        Get
            Return m_p
        End Get
        Set(ByVal value As Boolean)
            m_p = value
        End Set
    End Property

    Private m_v As Boolean
    Public Property VerticalStratificationModel() As Boolean
        Get
            Return m_v
        End Get
        Set(ByVal value As Boolean)
            m_v = value
        End Set
    End Property

    Private m_b As Boolean
    Public Property InterphaseFriction() As Boolean
        Get
            Return m_b
        End Get
        Set(ByVal value As Boolean)
            m_b = value
        End Set
    End Property

    Private m_f As Boolean
    Public Property ComputeWallFriction() As Boolean
        Get
            Return m_f
        End Get
        Set(ByVal value As Boolean)
            m_f = value
        End Set
    End Property

    Private m_e As Boolean
    Public Property EquilibriumTemperature() As Boolean
        Get
            Return m_e
        End Get
        Set(ByVal value As Boolean)
            m_e = value
        End Set
    End Property

    Public Sub New(ByVal VolumeNumber As Double, ByVal FlowArea As Double, ByVal LengthofVolume As Double, ByVal VolumeofVolume As Double, ByVal Azimuthalangle As Double, ByVal VerticalAngle As Double, ByVal ElevationChange As Double, ByVal HydraulicDiameter As Double, ByVal WallRoughness As Double, _
                    ByVal ThermalStratificationModel As Boolean, ByVal LevelTrackingModel As Boolean, ByVal WaterPackingScheme As Boolean, ByVal VerticalStratificationModel As Boolean, ByVal InterphaseFriction As Boolean, ByVal ComputeWallFriction As Boolean, ByVal EquilibriumTemperature As Boolean)
        Me.m_Azimuthalangle = Azimuthalangle
        Me.m_FlowArea = FlowArea
        Me.m_HydraulicDiameter = HydraulicDiameter
        Me.m_LengthofVolume = LengthofVolume
        Me.m_VerticalAngle = VerticalAngle
        Me.m_VolumeNumber = VolumeNumber
        Me.m_VolumeofVolume = VolumeofVolume
        Me.m_WallRoughness = WallRoughness
        Me.m_ElevationChange = ElevationChange
        Me.m_t = ThermalStratificationModel
        Me.m_l = LevelTrackingModel
        Me.m_p = WaterPackingScheme
        Me.m_v = VerticalStratificationModel
        Me.m_b = InterphaseFriction
        Me.m_f = ComputeWallFriction
        Me.m_e = EquilibriumTemperature

        '   Me.m_results = New System.Collections.Generic.List(Of PipeResults)

    End Sub
End Class
Public Class PipeJunctions
    Private _JunctionNumber As Integer
    Public Property JunctionNumber() As Integer
        Get
            Return _JunctionNumber
        End Get
        Set(ByVal value As Integer)
            _JunctionNumber = value
        End Set
    End Property
    Private _JunctionDiameter As Double
    Public Property JunctionDiameter() As Double
        Get
            Return _JunctionDiameter
        End Get
        Set(ByVal value As Double)
            _JunctionDiameter = value
        End Set
    End Property

   
    Public Sub New(JunctionNumber As String, JunctionDiameter As String)
        _JunctionNumber = JunctionNumber
        _JunctionDiameter = JunctionDiameter
    End Sub
End Class
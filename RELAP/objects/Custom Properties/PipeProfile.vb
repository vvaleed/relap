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
<System.Serializable()> Public Class PipeSection
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


<System.Serializable()> Public Class PipeJunctions
    Private m_JunctionNumber As Double
    Public Property JunctionNumber() As Double
        Get
            Return m_JunctionNumber
        End Get
        Set(ByVal value As Double)
            m_JunctionNumber = value
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

    Private m_ffelc As Double
    Public Property FflowLossCo() As Double
        Get
            Return m_ffelc
        End Get
        Set(ByVal value As Double)
            m_ffelc = value
        End Set
    End Property

    Private m_rfelc As Double
    Public Property RflowLossCo() As Double
        Get
            Return m_rfelc
        End Get
        Set(ByVal value As Double)
            m_rfelc = value
        End Set
    End Property

    Private m_e_junction As Boolean
    Public Property PVterm() As Boolean
        Get
            Return m_e_junction
        End Get
        Set(ByVal value As Boolean)
            m_e_junction = value
        End Set
    End Property

    Private m_f_junction As Boolean
    Public Property CCFLModel() As Boolean
        Get
            Return m_f_junction
        End Get
        Set(ByVal value As Boolean)
            m_f_junction = value
        End Set
    End Property

    Private m_v_junction As Boolean
    Public Property StratificationEntrainmentModel() As Boolean
        Get
            Return m_v_junction
        End Get
        Set(ByVal value As Boolean)
            m_v_junction = value
        End Set
    End Property

    Private m_c_junction As Boolean
    Public Property ChokingModel() As Boolean
        Get
            Return m_c_junction
        End Get
        Set(ByVal value As Boolean)
            m_c_junction = value
        End Set
    End Property

    Private m_a_junction_smooth As String
    Public Property SmoothAreaChange() As String
        Get
            Return m_a_junction_smooth
        End Get
        Set(ByVal value As String)
            m_a_junction_smooth = value
        End Set
    End Property

    Private m_a_junction_abrupt As Boolean
    Public Property FullAbruptAreaChange() As Boolean
        Get
            Return m_a_junction_abrupt
        End Get
        Set(ByVal value As Boolean)
            m_a_junction_abrupt = value
        End Set
    End Property

    Private m_a_junction_partial As Boolean
    Public Property PartialAbruptAreaChange() As Boolean
        Get
            Return m_a_junction_partial
        End Get
        Set(ByVal value As Boolean)
            m_a_junction_partial = value
        End Set
    End Property

    Private m_h_junction_homogeneus As String
    Public Property TwoVelocityMomentumEquations() As String
        Get
            Return m_h_junction_homogeneus
        End Get
        Set(ByVal value As String)
            m_h_junction_homogeneus = value
        End Set
    End Property

    Private m_h_junction_nonhomogeneus As String
    Public Property SingleVelocityMomentumEquations() As String
        Get
            Return m_h_junction_nonhomogeneus
        End Get
        Set(ByVal value As String)
            m_h_junction_nonhomogeneus = value
        End Set
    End Property

    Private m_s_junction As String
    Public Property MomentumFlux() As String
        Get
            Return m_s_junction
        End Get
        Set(ByVal value As String)
            m_s_junction = value
        End Set
    End Property

    Public Sub New(JunctionNumber As Double, JunctionFlowArea As Double, FflowLossCo As Double, RflowLossCo As Double, PVterm As Boolean, CCFLModel As Boolean, StratificationEntrainmentModel As Boolean, _
                   ChokingModel As Boolean, SmoothAreaChange As String, TwoVelocityMomentumEquations As String, MomentumFlux As String)
        Me.m_JunctionNumber = JunctionNumber
        Me.m_JunctionFlowArea = JunctionFlowArea
        Me.m_ffelc = FflowLossCo
        Me.m_rfelc = RflowLossCo
        Me.m_e_junction = PVterm
        Me.m_f_junction = CCFLModel
        Me.m_v_junction = StratificationEntrainmentModel
        Me.m_c_junction = ChokingModel
        Me.m_a_junction_smooth = SmoothAreaChange
        Me.m_h_junction_homogeneus = TwoVelocityMomentumEquations
        Me.m_s_junction = MomentumFlux

    End Sub
End Class
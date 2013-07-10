Public Class PipeProfile
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
End Class

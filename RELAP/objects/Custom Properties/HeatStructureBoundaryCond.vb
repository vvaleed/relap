<System.Serializable()> Public Class HeatStructureBoundaryCond

    Protected m_collection As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab1)

    Public Property BoundaryCondTab1() As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab1)
        Get
            Return m_collection
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab1))
            m_collection = value
        End Set
    End Property

    Protected m_collection2 As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab2)
    Public Property BoundaryCondTab2() As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab2)
        Get
            Return m_collection2
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab2))
            m_collection2 = value
        End Set
    End Property

    Protected m_collection3 As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab3)
    Public Property BoundaryCondTab3() As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab3)
        Get
            Return m_collection3
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab3))
            m_collection3 = value
        End Set
    End Property

    Protected m_collection4 As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab4)
    Public Property BoundaryCondTab4() As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab4)
        Get
            Return m_collection4
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab4))
            m_collection4 = value
        End Set
    End Property

    Protected m_collection5 As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab5)

    Public Property BoundaryCondTab5() As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab5)
        Get
            Return m_collection5
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSBoundaryCondTab5))
            m_collection5 = value
        End Set
    End Property

    Public Sub New()
        m_collection = New Generic.SortedDictionary(Of Integer, HSBoundaryCondTab1)
        m_collection2 = New Generic.SortedDictionary(Of Integer, HSBoundaryCondTab2)
        m_collection3 = New Generic.SortedDictionary(Of Integer, HSBoundaryCondTab3)
        m_collection4 = New Generic.SortedDictionary(Of Integer, HSBoundaryCondTab4)
        m_collection5 = New Generic.SortedDictionary(Of Integer, HSBoundaryCondTab5)
    End Sub

    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function

End Class

<System.Serializable()> Public Class HSBoundaryCondTab1
    Private _LeftBoundaryVolumeNumber As Double
    Public Property LeftBoundaryVolumeNumber() As Double
        Get
            Return _LeftBoundaryVolumeNumber
        End Get
        Set(ByVal value As Double)
            _LeftBoundaryVolumeNumber = value
        End Set
    End Property

    Private _LeftIncrement As Double
    Public Property LeftIncrement() As Double
        Get
            Return _LeftIncrement
        End Get
        Set(ByVal value As Double)
            _LeftIncrement = value
        End Set
    End Property

    Private _LeftBoundaryConditionType As Double
    Public Property LeftBoundaryConditionType() As Double
        Get
            Return _LeftBoundaryConditionType
        End Get
        Set(ByVal value As Double)
            _LeftBoundaryConditionType = value
        End Set
    End Property

    Private _LeftSurfaceAreaSelection As Double
    Public Property LeftSurfaceAreaSelection() As Double
        Get
            Return _LeftSurfaceAreaSelection
        End Get
        Set(ByVal value As Double)
            _LeftSurfaceAreaSelection = value
        End Set
    End Property

    Private _LeftSurfaceArea As Double
    Public Property LeftSurfaceArea() As Double
        Get
            Return _LeftSurfaceArea
        End Get
        Set(ByVal value As Double)
            _LeftSurfaceArea = value
        End Set
    End Property

    Private _LeftHeatStructureNumber As Double
    Public Property LeftHeatStructureNumber() As Double
        Get
            Return _LeftHeatStructureNumber
        End Get
        Set(ByVal value As Double)
            _LeftHeatStructureNumber = value
        End Set
    End Property

    Public Sub New(ByVal LeftBoundaryVolumeNumber As Double, ByVal LeftIncrement As Double, ByVal LeftBoundaryConditionType As Double, ByVal LeftSurfaceAreaSelection As Double, ByVal LeftSurfaceArea As Double, ByVal LeftHeatStructureNumber As Double)
        Me._LeftBoundaryVolumeNumber = LeftBoundaryVolumeNumber
        Me._LeftIncrement = LeftIncrement
        Me._LeftBoundaryConditionType = LeftBoundaryConditionType
        Me._LeftSurfaceAreaSelection = LeftSurfaceAreaSelection
        Me._LeftSurfaceArea = LeftSurfaceArea
        Me._LeftHeatStructureNumber = LeftHeatStructureNumber
    End Sub
End Class

<System.Serializable()> Public Class HSBoundaryCondTab2
    Private _RightBoundaryVolumeNumber As Double
    Public Property RightBoundaryVolumeNumber() As Double
        Get
            Return _RightBoundaryVolumeNumber
        End Get
        Set(ByVal value As Double)
            _RightBoundaryVolumeNumber = value
        End Set
    End Property

    Private _RightIncrement As Double
    Public Property RightIncrement() As Double
        Get
            Return _RightIncrement
        End Get
        Set(ByVal value As Double)
            _RightIncrement = value
        End Set
    End Property

    Private _RightBoundaryConditionType As Double
    Public Property RightBoundaryConditionType() As Double
        Get
            Return _RightBoundaryConditionType
        End Get
        Set(ByVal value As Double)
            _RightBoundaryConditionType = value
        End Set
    End Property

    Private _RightSurfaceAreaSelection As Double
    Public Property RightSurfaceAreaSelection() As Double
        Get
            Return _RightSurfaceAreaSelection
        End Get
        Set(ByVal value As Double)
            _RightSurfaceAreaSelection = value
        End Set
    End Property

    Private _RightSurfaceArea As Double
    Public Property RightSurfaceArea() As Double
        Get
            Return _RightSurfaceArea
        End Get
        Set(ByVal value As Double)
            _RightSurfaceArea = value
        End Set
    End Property

    Private _RightHeatStructureNumber As Double
    Public Property RightHeatStructureNumber() As Double
        Get
            Return _RightHeatStructureNumber
        End Get
        Set(ByVal value As Double)
            _RightHeatStructureNumber = value
        End Set
    End Property

    Public Sub New(ByVal RightBoundaryVolumeNumber As Double, ByVal RightIncrement As Double, ByVal RightBoundaryConditionType As Double, ByVal RightSurfaceAreaSelection As Double, ByVal RightSurfaceArea As Double, ByVal RightHeatStructureNumber As Double)
        Me._RightBoundaryVolumeNumber = RightBoundaryVolumeNumber
        Me._RightIncrement = RightIncrement
        Me._RightBoundaryConditionType = RightBoundaryConditionType
        Me._RightSurfaceAreaSelection = RightSurfaceAreaSelection
        Me._RightSurfaceArea = RightSurfaceArea
        Me._RightHeatStructureNumber = RightHeatStructureNumber
    End Sub
End Class

<System.Serializable()> Public Class HSBoundaryCondTab3
    Private _SourceType As Double
    Public Property SourceType() As Double
        Get
            Return _SourceType
        End Get
        Set(ByVal value As Double)
            _SourceType = value
        End Set
    End Property

    Private _InternalSourceMultiplier As Double
    Public Property InternalSourceMultiplier() As Double
        Get
            Return _InternalSourceMultiplier
        End Get
        Set(ByVal value As Double)
            _InternalSourceMultiplier = value
        End Set
    End Property
    Private _DirectModeratorHeatingMultiplierLeft As Double
    Public Property DirectModeratorHeatingMultiplierLeft() As Double
        Get
            Return _DirectModeratorHeatingMultiplierLeft
        End Get
        Set(ByVal value As Double)
            _DirectModeratorHeatingMultiplierLeft = value
        End Set
    End Property

    Private _DirectModeratorHeatingMultiplierRight As Double
    Public Property DirectModeratorHeatingMultiplierRight() As Double
        Get
            Return _DirectModeratorHeatingMultiplierRight
        End Get
        Set(ByVal value As Double)
            _DirectModeratorHeatingMultiplierRight = value
        End Set
    End Property
    Private _SourceHeatStructureNumber As Double
    Public Property SourceHeatStructureNumber() As Double
        Get
            Return _SourceHeatStructureNumber
        End Get
        Set(ByVal value As Double)
            _SourceHeatStructureNumber = value
        End Set
    End Property

    Public Sub New(ByVal SourceType As Double, ByVal InternalSourceMultiplier As Double, ByVal DirectModeratorHeatingMultiplierLeft As Double, ByVal DirectModeratorHeatingMultiplierRight As Double, ByVal SourceHeatStructureNumber As Double)
        Me._SourceType = SourceType
        Me._InternalSourceMultiplier = InternalSourceMultiplier
        Me._DirectModeratorHeatingMultiplierLeft = DirectModeratorHeatingMultiplierLeft
        Me._DirectModeratorHeatingMultiplierRight = DirectModeratorHeatingMultiplierRight
        Me._SourceHeatStructureNumber = SourceHeatStructureNumber
    End Sub
End Class


<System.Serializable()> Public Class HSBoundaryCondTab4
 
End Class


<System.Serializable()> Public Class HSBoundaryCondTab5

End Class
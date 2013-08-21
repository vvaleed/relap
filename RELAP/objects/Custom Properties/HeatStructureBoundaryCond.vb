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

    Private _LeftBoundaryConditionType As String
    Public Property LeftBoundaryConditionType() As String
        Get
            Return _LeftBoundaryConditionType
        End Get
        Set(ByVal value As String)
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

    Public Sub New(ByVal LeftBoundaryVolumeNumber As Double, ByVal LeftIncrement As Double, ByVal LeftBoundaryConditionType As String, ByVal LeftSurfaceAreaSelection As Double, ByVal LeftSurfaceArea As Double, ByVal LeftHeatStructureNumber As Double)
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

    Private _RightBoundaryConditionType As String
    Public Property RightBoundaryConditionType() As String
        Get
            Return _RightBoundaryConditionType
        End Get
        Set(ByVal value As String)
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

    Public Sub New(ByVal RightBoundaryVolumeNumber As Double, ByVal RightIncrement As Double, ByVal RightBoundaryConditionType As String, ByVal RightSurfaceAreaSelection As Double, ByVal RightSurfaceArea As Double, ByVal RightHeatStructureNumber As Double)
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
    Private _leftHeatedEquivalentDiameter As Double
    Public Property leftHeatedEquivalentDiameter() As Double
        Get
            Return _leftHeatedEquivalentDiameter
        End Get
        Set(ByVal value As Double)
            _leftHeatedEquivalentDiameter = value
        End Set
    End Property
    Private _LeftHeatedLengthForward As Double
    Public Property LeftHeatedLengthForward() As Double
        Get
            Return _LeftHeatedLengthForward
        End Get
        Set(ByVal value As Double)
            _LeftHeatedLengthForward = value
        End Set
    End Property
    Private _LeftHeatedLengthReverse As Double
    Public Property LeftHeatedLengthReverse() As Double
        Get
            Return _LeftHeatedLengthReverse
        End Get
        Set(ByVal value As Double)
            _LeftHeatedLengthReverse = value
        End Set
    End Property
    Private _leftGridSpacerLengthForward As Double
    Public Property leftGridSpacerLengthForward() As Double
        Get
            Return _leftGridSpacerLengthForward
        End Get
        Set(ByVal value As Double)
            _leftGridSpacerLengthForward = value
        End Set
    End Property
    Private _leftGridSpacerLengthReverse As Double
    Public Property leftGridSpacerLengthReverse() As Double
        Get
            Return _leftGridSpacerLengthReverse
        End Get
        Set(ByVal value As Double)
            _leftGridSpacerLengthReverse = value
        End Set
    End Property

    Private _leftGridLossCoefficientForward As Double
    Public Property leftGridLossCoefficientForward() As Double
        Get
            Return _leftGridLossCoefficientForward
        End Get
        Set(ByVal value As Double)
            _leftGridLossCoefficientForward = value
        End Set
    End Property
    Private _leftGridLossCoefficientReverse As Double
    Public Property leftGridLossCoefficientReverse() As Double
        Get
            Return _leftGridLossCoefficientReverse
        End Get
        Set(ByVal value As Double)
            _leftGridLossCoefficientReverse = value
        End Set
    End Property
    Private _leftLocalBoilingFactor As Double
    Public Property leftLocalBoilingFactor() As Double
        Get
            Return _leftLocalBoilingFactor
        End Get
        Set(ByVal value As Double)
            _leftLocalBoilingFactor = value
        End Set
    End Property
    Private _leftNaturalCirculationLength As Double
    Public Property leftNaturalCirculationLength() As String
        Get
            Return _leftNaturalCirculationLength
        End Get
        Set(ByVal value As String)
            _leftNaturalCirculationLength = value
        End Set
    End Property
    Private _leftPitchtoDiameterRatio As Double
    Public Property leftPitchtoDiameterRatio() As Double
        Get
            Return _leftPitchtoDiameterRatio
        End Get
        Set(ByVal value As Double)
            _leftPitchtoDiameterRatio = value
        End Set
    End Property
    Private _leftFoulingFactor As Double
    Public Property leftFoulingFactor() As Double
        Get
            Return _leftFoulingFactor
        End Get
        Set(ByVal value As Double)
            _leftFoulingFactor = value
        End Set
    End Property
    Private _leftAddHeatStructureNumber As Double
    Public Property leftAddHeatStructureNumber() As Double
        Get
            Return _leftAddHeatStructureNumber
        End Get
        Set(ByVal value As Double)
            _leftAddHeatStructureNumber = value
        End Set
    End Property


    Public Sub New(ByVal leftHeatedEquivalentDiameter As Double, ByVal LeftHeatedLengthForward As Double, ByVal LeftHeatedLengthReverse As Double, ByVal leftGridSpacerLengthForward As Double, ByVal leftGridSpacerLengthReverse As Double, ByVal leftGridLossCoefficientForward As Double, _
                   ByVal leftGridLossCoefficientReverse As Double, ByVal leftLocalBoilingFactor As Double, ByVal leftNaturalCirculationLength As Double, ByVal leftPitchtoDiameterRatio As Double, ByVal leftFoulingFactor As Double, ByVal leftAddHeatStructureNumber As Double)
        Me._leftHeatedEquivalentDiameter = leftHeatedEquivalentDiameter
        Me._LeftHeatedLengthForward = LeftHeatedLengthForward
        Me._LeftHeatedLengthReverse = LeftHeatedLengthReverse
        Me._leftGridSpacerLengthForward = leftGridSpacerLengthForward
        Me._leftGridSpacerLengthReverse = leftGridSpacerLengthReverse
        Me._leftGridLossCoefficientForward = leftGridLossCoefficientForward
        Me._leftGridLossCoefficientReverse = leftGridLossCoefficientReverse
        Me._leftLocalBoilingFactor = leftLocalBoilingFactor
        Me._leftNaturalCirculationLength = leftNaturalCirculationLength
        Me._leftPitchtoDiameterRatio = leftPitchtoDiameterRatio
        Me._leftFoulingFactor = leftFoulingFactor
        Me._leftAddHeatStructureNumber = leftAddHeatStructureNumber
    End Sub
End Class


<System.Serializable()> Public Class HSBoundaryCondTab5
    Private _rightHeatedEquivalentDiameter As Double
    Public Property rightHeatedEquivalentDiameter() As Double
        Get
            Return _rightHeatedEquivalentDiameter
        End Get
        Set(ByVal value As Double)
            _rightHeatedEquivalentDiameter = value
        End Set
    End Property
    Private _rightHeatedLengthForward As Double
    Public Property rightHeatedLengthForward() As Double
        Get
            Return _rightHeatedLengthForward
        End Get
        Set(ByVal value As Double)
            _rightHeatedLengthForward = value
        End Set
    End Property
    Private _rightHeatedLengthReverse As Double
    Public Property rightHeatedLengthReverse() As Double
        Get
            Return _rightHeatedLengthReverse
        End Get
        Set(ByVal value As Double)
            _rightHeatedLengthReverse = value
        End Set
    End Property
    Private _rightGridSpacerLengthForward As Double
    Public Property rightGridSpacerLengthForward() As Double
        Get
            Return _rightGridSpacerLengthForward
        End Get
        Set(ByVal value As Double)
            _rightGridSpacerLengthForward = value
        End Set
    End Property
    Private _rightGridSpacerLengthReverse As Double
    Public Property rightGridSpacerLengthReverse() As Double
        Get
            Return _rightGridSpacerLengthReverse
        End Get
        Set(ByVal value As Double)
            _rightGridSpacerLengthReverse = value
        End Set
    End Property

    Private _rightGridLossCoefficientForward As Double
    Public Property rightGridLossCoefficientForward() As Double
        Get
            Return _rightGridLossCoefficientForward
        End Get
        Set(ByVal value As Double)
            _rightGridLossCoefficientForward = value
        End Set
    End Property
    Private _rightGridLossCoefficientReverse As Double
    Public Property rightGridLossCoefficientReverse() As Double
        Get
            Return _rightGridLossCoefficientReverse
        End Get
        Set(ByVal value As Double)
            _rightGridLossCoefficientReverse = value
        End Set
    End Property
    Private _rightLocalBoilingFactor As Double
    Public Property rightLocalBoilingFactor() As Double
        Get
            Return _rightLocalBoilingFactor
        End Get
        Set(ByVal value As Double)
            _rightLocalBoilingFactor = value
        End Set
    End Property
    Private _rightNaturalCirculationLength As Double
    Public Property rightNaturalCirculationLength() As String
        Get
            Return _rightNaturalCirculationLength
        End Get
        Set(ByVal value As String)
            _rightNaturalCirculationLength = value
        End Set
    End Property
    Private _rightPitchtoDiameterRatio As Double
    Public Property rightPitchtoDiameterRatio() As Double
        Get
            Return _rightPitchtoDiameterRatio
        End Get
        Set(ByVal value As Double)
            _rightPitchtoDiameterRatio = value
        End Set
    End Property
    Private _rightFoulingFactor As Double
    Public Property rightFoulingFactor() As Double
        Get
            Return _rightFoulingFactor
        End Get
        Set(ByVal value As Double)
            _rightFoulingFactor = value
        End Set
    End Property
    Private _rightAddHeatStructureNumber As Double
    Public Property rightAddHeatStructureNumber() As Double
        Get
            Return _rightAddHeatStructureNumber
        End Get
        Set(ByVal value As Double)
            _rightAddHeatStructureNumber = value
        End Set
    End Property


    Public Sub New(ByVal rightHeatedEquivalentDiameter As Double, ByVal rightHeatedLengthForward As Double, ByVal rightHeatedLengthReverse As Double, ByVal rightGridSpacerLengthForward As Double, ByVal rightGridSpacerLengthReverse As Double, ByVal rightGridLossCoefficientForward As Double, _
                   ByVal rightGridLossCoefficientReverse As Double, ByVal rightLocalBoilingFactor As Double, ByVal rightNaturalCirculationLength As Double, ByVal rightPitchtoDiameterRatio As Double, ByVal rightFoulingFactor As Double, ByVal rightAddHeatStructureNumber As Double)
        Me._rightHeatedEquivalentDiameter = rightHeatedEquivalentDiameter
        Me._rightHeatedLengthForward = rightHeatedLengthForward
        Me._rightHeatedLengthReverse = rightHeatedLengthReverse
        Me._rightGridSpacerLengthForward = rightGridSpacerLengthForward
        Me._rightGridSpacerLengthReverse = rightGridSpacerLengthReverse
        Me._rightGridLossCoefficientForward = rightGridLossCoefficientForward
        Me._rightGridLossCoefficientReverse = rightGridLossCoefficientReverse
        Me._rightLocalBoilingFactor = rightLocalBoilingFactor
        Me._rightNaturalCirculationLength = rightNaturalCirculationLength
        Me._rightPitchtoDiameterRatio = rightPitchtoDiameterRatio
        Me._rightFoulingFactor = rightFoulingFactor
        Me._rightAddHeatStructureNumber = rightAddHeatStructureNumber
    End Sub
End Class
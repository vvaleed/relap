<System.Serializable()> Public Class HeatStructureMeshData

    Private _GapConductanceModel As Boolean
    Public Property GapConductanceModel() As Boolean
        Get
            Return _GapConductanceModel
        End Get
        Set(ByVal value As Boolean)
            _GapConductanceModel = value
        End Set
    End Property
    Private _InitialGapInternalPressure As String
    Public Property InitialGapInternalPressure() As String
        Get
            Return _InitialGapInternalPressure
        End Get
        Set(ByVal value As String)
            _InitialGapInternalPressure = value
        End Set
    End Property
    Private _GapConductanceReferenceVolume As String
    Public Property GapConductanceReferenceVolume() As String
        Get
            Return _GapConductanceReferenceVolume
        End Get
        Set(ByVal value As String)
            _GapConductanceReferenceVolume = value
        End Set
    End Property
    Private _MetalWaterReaction As Boolean
    Public Property MetalWaterReaction() As Boolean
        Get
            Return _MetalWaterReaction
        End Get
        Set(ByVal value As Boolean)
            _MetalWaterReaction = value
        End Set
    End Property
    Private _InitialOxideThicknes As String
    Public Property InitialOxideThicknes() As String
        Get
            Return _InitialOxideThicknes
        End Get
        Set(ByVal value As String)
            _InitialOxideThicknes = value
        End Set
    End Property
    Private _FormLossFactors As Boolean
    Public Property FormLossFactors() As Boolean
        Get
            Return _FormLossFactors
        End Get
        Set(ByVal value As Boolean)
            _FormLossFactors = value
        End Set
    End Property


    Private _EnterMeshGeometry As String
    Public Property EnterMeshGeometry() As String
        Get
            Return _EnterMeshGeometry
        End Get
        Set(ByVal value As String)
            _EnterMeshGeometry = value
        End Set
    End Property

    Private _EnterInitialTemp As String
    Public Property EnterInitialTemp() As String
        Get
            Return _EnterInitialTemp
        End Get
        Set(ByVal value As String)
            _EnterInitialTemp = value
        End Set
    End Property

    Private _SelectFormat As String
    Public Property SelectFormat() As String
        Get
            Return _SelectFormat
        End Get
        Set(ByVal value As String)
            _SelectFormat = value
        End Set
    End Property
    Private _SelectTemp As String
    Public Property SelectTemp() As String
        Get
            Return _SelectTemp
        End Get
        Set(ByVal value As String)
            _SelectTemp = value
        End Set
    End Property
    Private _DecayHeat As String
    Public Property DecayHeat() As String
        Get
            Return _DecayHeat
        End Get
        Set(ByVal value As String)
            _DecayHeat = value
        End Set
    End Property

    Private _selectComp As String
    Public Property SelectComp() As String
        Get
            Return _selectComp
        End Get
        Set(ByVal value As String)
            _selectComp = value
        End Set
    End Property


    Protected m_collection0 As Generic.SortedDictionary(Of Integer, HSGapDeformation)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property GapDeformation() As Generic.SortedDictionary(Of Integer, HSGapDeformation)
        Get
            Return m_collection0
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSGapDeformation))
            m_collection0 = value
        End Set
    End Property

    Protected m_collection As Generic.SortedDictionary(Of Integer, HSMeshDataFormat1)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataFormat1() As Generic.SortedDictionary(Of Integer, HSMeshDataFormat1)
        Get
            Return m_collection
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataFormat1))
            m_collection = value
        End Set
    End Property
    Protected m_collection2 As Generic.SortedDictionary(Of Integer, HSMeshDataFormat2)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataFormat2() As Generic.SortedDictionary(Of Integer, HSMeshDataFormat2)
        Get
            Return m_collection2
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataFormat2))
            m_collection2 = value
        End Set
    End Property
    Protected m_collection3 As Generic.SortedDictionary(Of Integer, HSMeshDataNoDecay)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataNoDecay() As Generic.SortedDictionary(Of Integer, HSMeshDataNoDecay)
        Get
            Return m_collection3
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataNoDecay))
            m_collection3 = value
        End Set
    End Property
    Protected m_collection4 As Generic.SortedDictionary(Of Integer, HSMeshDataWithDecay)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataWithDecay() As Generic.SortedDictionary(Of Integer, HSMeshDataWithDecay)
        Get
            Return m_collection4
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataWithDecay))
            m_collection4 = value
        End Set
    End Property
    Protected m_collection5 As Generic.SortedDictionary(Of Integer, HSMeshDataComposition)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataComposition() As Generic.SortedDictionary(Of Integer, HSMeshDataComposition)
        Get
            Return m_collection5
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataComposition))
            m_collection5 = value
        End Set
    End Property
    Protected m_collection52 As Generic.SortedDictionary(Of Integer, HSMeshDataComposition2)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataComposition2() As Generic.SortedDictionary(Of Integer, HSMeshDataComposition2)
        Get
            Return m_collection52
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataComposition2))
            m_collection52 = value
        End Set
    End Property
    Protected m_collection53 As Generic.SortedDictionary(Of Integer, HSMeshDataComposition3)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataComposition3() As Generic.SortedDictionary(Of Integer, HSMeshDataComposition3)
        Get
            Return m_collection53
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataComposition3))
            m_collection53 = value
        End Set
    End Property
    Protected m_collection54 As Generic.SortedDictionary(Of Integer, HSMeshDataComposition4)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataComposition4() As Generic.SortedDictionary(Of Integer, HSMeshDataComposition4)
        Get
            Return m_collection54
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataComposition4))
            m_collection54 = value
        End Set
    End Property
    Protected m_collection55 As Generic.SortedDictionary(Of Integer, HSMeshDataComposition5)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataComposition5() As Generic.SortedDictionary(Of Integer, HSMeshDataComposition5)
        Get
            Return m_collection55
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataComposition5))
            m_collection55 = value
        End Set
    End Property
    Protected m_collection56 As Generic.SortedDictionary(Of Integer, HSMeshDataComposition6)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property MeshDataComposition6() As Generic.SortedDictionary(Of Integer, HSMeshDataComposition6)
        Get
            Return m_collection56
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMeshDataComposition6))
            m_collection56 = value
        End Set
    End Property
    Protected m_collection6 As Generic.SortedDictionary(Of Integer, HSTemp1)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property Temp1() As Generic.SortedDictionary(Of Integer, HSTemp1)
        Get
            Return m_collection6
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSTemp1))
            m_collection6 = value
        End Set
    End Property
    Protected m_collection7 As Generic.SortedDictionary(Of Integer, HSTemp2)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property Temp2() As Generic.SortedDictionary(Of Integer, HSTemp2)
        Get
            Return m_collection7
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSTemp2))
            m_collection7 = value
        End Set
    End Property

    Protected m_collection8 As Generic.SortedDictionary(Of Integer, HSMat)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property proHSMat() As Generic.SortedDictionary(Of Integer, HSMat)
        Get
            Return m_collection8
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HSMat))
            m_collection8 = value
        End Set
    End Property

    Public Sub New()
        m_collection0 = New Generic.SortedDictionary(Of Integer, HSGapDeformation)
        m_collection = New Generic.SortedDictionary(Of Integer, HSMeshDataFormat1)
        m_collection2 = New Generic.SortedDictionary(Of Integer, HSMeshDataFormat2)
        m_collection3 = New Generic.SortedDictionary(Of Integer, HSMeshDataNoDecay)
        m_collection4 = New Generic.SortedDictionary(Of Integer, HSMeshDataWithDecay)
        m_collection5 = New Generic.SortedDictionary(Of Integer, HSMeshDataComposition)
        m_collection52 = New Generic.SortedDictionary(Of Integer, HSMeshDataComposition2)
        m_collection53 = New Generic.SortedDictionary(Of Integer, HSMeshDataComposition3)
        m_collection54 = New Generic.SortedDictionary(Of Integer, HSMeshDataComposition4)
        m_collection55 = New Generic.SortedDictionary(Of Integer, HSMeshDataComposition5)
        m_collection56 = New Generic.SortedDictionary(Of Integer, HSMeshDataComposition6)
        m_collection6 = New Generic.SortedDictionary(Of Integer, HSTemp1)
        m_collection7 = New Generic.SortedDictionary(Of Integer, HSTemp2)
        m_collection8 = New Generic.SortedDictionary(Of Integer, HSMat)
    End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function

End Class

<System.Serializable()> Public Class HSGapDeformation
    Private _FuelSurfaceRoughness As Double
    Public Property FuelSurfaceRoughness() As Double
        Get
            Return _FuelSurfaceRoughness
        End Get
        Set(ByVal value As Double)
            _FuelSurfaceRoughness = value
        End Set
    End Property

    Private _CladdingSurfaceRoughness As Double
    Public Property CladdingSurfaceRoughness() As Double
        Get
            Return _CladdingSurfaceRoughness
        End Get
        Set(ByVal value As Double)
            _CladdingSurfaceRoughness = value
        End Set
    End Property

    Private _RadialDisplacementFission As Double
    Public Property RadialDisplacementFission() As Double
        Get
            Return _RadialDisplacementFission
        End Get
        Set(ByVal value As Double)
            _RadialDisplacementFission = value
        End Set
    End Property

    Private _RadialDisplacementCladding As Double
    Public Property RadialDisplacementCladding() As Double
        Get
            Return _RadialDisplacementCladding
        End Get
        Set(ByVal value As Double)
            _RadialDisplacementCladding = value
        End Set
    End Property

    Private _HSnumberGapDef As Double
    Public Property HSnumberGapDef() As Double
        Get
            Return _HSnumberGapDef
        End Get
        Set(ByVal value As Double)
            _HSnumberGapDef = value
        End Set
    End Property

    Public Sub New(ByVal FuelSurfaceRoughness As Double, ByVal CladdingSurfaceRoughness As Double, ByVal RadialDisplacementFission As Double, ByVal RadialDisplacementCladding As Double, ByVal HSnumberGapDef As Double)
        Me._FuelSurfaceRoughness = FuelSurfaceRoughness
        Me._CladdingSurfaceRoughness = CladdingSurfaceRoughness
        Me._RadialDisplacementFission = RadialDisplacementFission
        Me._RadialDisplacementCladding = RadialDisplacementCladding
        Me._HSnumberGapDef = HSnumberGapDef
    End Sub

End Class

<System.Serializable()> Public Class HSMeshDataFormat1
    Private _NumberOfIntervals As Double
    Public Property NumberOfIntervals() As Double
        Get
            Return _NumberOfIntervals
        End Get
        Set(ByVal value As Double)
            _NumberOfIntervals = value
        End Set
    End Property

    Private _RightCoordinate As Double
    Public Property RightCoordinate() As Double
        Get
            Return _RightCoordinate
        End Get
        Set(ByVal value As Double)
            _RightCoordinate = value
        End Set
    End Property

    Public Sub New(ByVal NumberOfIntervals As Double, ByVal RightCoordinate As Double)
        Me._NumberOfIntervals = NumberOfIntervals
        Me._RightCoordinate = RightCoordinate
    End Sub

End Class
<System.Serializable()> Public Class HSMeshDataFormat2
    Private _MeshInterval As Double
    Public Property MeshInterval() As Double
        Get
            Return _MeshInterval
        End Get
        Set(ByVal value As Double)
            _MeshInterval = value
        End Set
    End Property
    Private _IntervalNumber As Double
    Public Property IntervalNumber() As Double
        Get
            Return _IntervalNumber
        End Get
        Set(ByVal value As Double)
            _IntervalNumber = value
        End Set
    End Property
    Public Sub New(ByVal MeshInterval As Double, ByVal IntervalNumber As Double)
        Me._MeshInterval = MeshInterval
        Me._IntervalNumber = IntervalNumber
    End Sub

End Class
<System.Serializable()> Public Class HSMeshDataNoDecay
    Private _SourceValue As Double
    Public Property SourceValue() As Double
        Get
            Return _SourceValue
        End Get
        Set(ByVal value As Double)
            _SourceValue = value
        End Set
    End Property

    Private _MeshIntervalNumber As Double
    Public Property MeshIntervalNumber() As Double
        Get
            Return _MeshIntervalNumber
        End Get
        Set(ByVal value As Double)
            _MeshIntervalNumber = value
        End Set
    End Property
    Public Sub New(ByVal SourceValue As Double, ByVal MeshIntervalNumber As Double)
        Me._SourceValue = SourceValue
        Me._MeshIntervalNumber = MeshIntervalNumber
    End Sub
End Class
<System.Serializable()> Public Class HSMeshDataWithDecay
    Private _GammaAttenuationCo As Double
    Public Property GammaAttenuationCo() As Double
        Get
            Return _GammaAttenuationCo
        End Get
        Set(ByVal value As Double)
            _GammaAttenuationCo = value
        End Set
    End Property
    Private _MeshIntervalNumber2 As Double
    Public Property MeshIntervalNumber2() As Double
        Get
            Return _MeshIntervalNumber2
        End Get
        Set(ByVal value As Double)
            _MeshIntervalNumber2 = value
        End Set
    End Property
    Public Sub New(ByVal GammaAttenuationCo As Double, ByVal MeshIntervalNumber2 As Double)
        Me._GammaAttenuationCo = GammaAttenuationCo
        Me._MeshIntervalNumber2 = MeshIntervalNumber2
    End Sub
End Class
<System.Serializable()> Public Class HSMeshDataComposition
    Private _CompositionNumber As Double
    Public Property CompositionNumber() As Double
        Get
            Return _CompositionNumber
        End Get
        Set(ByVal value As Double)
            _CompositionNumber = value
        End Set
    End Property
    Private _MeshIntervalNumber3 As Double
    Public Property MeshIntervalNumber3() As Double
        Get
            Return _MeshIntervalNumber3
        End Get
        Set(ByVal value As Double)
            _MeshIntervalNumber3 = value
        End Set
    End Property
    Public Sub New(ByVal CompositionNumber As Double, ByVal MeshIntervalNumber3 As Double)
        Me._CompositionNumber = CompositionNumber
        Me._MeshIntervalNumber3 = MeshIntervalNumber3
    End Sub
End Class
<System.Serializable()> Public Class HSMeshDataComposition2
    Private _CompositionNumber2 As Double
    Public Property CompositionNumber2() As Double
        Get
            Return _CompositionNumber2
        End Get
        Set(ByVal value As Double)
            _CompositionNumber2 = value
        End Set
    End Property
    Private _MeshIntervalNumber4 As Double
    Public Property MeshIntervalNumber4() As Double
        Get
            Return _MeshIntervalNumber4
        End Get
        Set(ByVal value As Double)
            _MeshIntervalNumber4 = value
        End Set
    End Property
    Public Sub New(ByVal CompositionNumber2 As Double, ByVal MeshIntervalNumber4 As Double)
        Me._CompositionNumber2 = CompositionNumber2
        Me._MeshIntervalNumber4 = MeshIntervalNumber4
    End Sub
End Class
<System.Serializable()> Public Class HSMeshDataComposition3
    Private _CompositionNumber3 As Double
    Public Property CompositionNumber3() As Double
        Get
            Return _CompositionNumber3
        End Get
        Set(ByVal value As Double)
            _CompositionNumber3 = value
        End Set
    End Property
    Private _MeshIntervalNumber33 As Double
    Public Property MeshIntervalNumber33() As Double
        Get
            Return _MeshIntervalNumber33
        End Get
        Set(ByVal value As Double)
            _MeshIntervalNumber33 = value
        End Set
    End Property
    Public Sub New(ByVal CompositionNumber3 As Double, ByVal MeshIntervalNumber33 As Double)
        Me._CompositionNumber3 = CompositionNumber3
        Me._MeshIntervalNumber33 = MeshIntervalNumber33
    End Sub
End Class
<System.Serializable()> Public Class HSMeshDataComposition4
    Private _CompositionNumber4 As Double
    Public Property CompositionNumber4() As Double
        Get
            Return _CompositionNumber4
        End Get
        Set(ByVal value As Double)
            _CompositionNumber4 = value
        End Set
    End Property
    Private _MeshIntervalNumber34 As Double
    Public Property MeshIntervalNumber34() As Double
        Get
            Return _MeshIntervalNumber34
        End Get
        Set(ByVal value As Double)
            _MeshIntervalNumber34 = value
        End Set
    End Property
    Public Sub New(ByVal CompositionNumber4 As Double, ByVal MeshIntervalNumber34 As Double)
        Me._CompositionNumber4 = CompositionNumber4
        Me._MeshIntervalNumber34 = MeshIntervalNumber34
    End Sub
End Class
<System.Serializable()> Public Class HSMeshDataComposition5
    Private _CompositionNumber5 As Double
    Public Property CompositionNumber5() As Double
        Get
            Return _CompositionNumber5
        End Get
        Set(ByVal value As Double)
            _CompositionNumber5 = value
        End Set
    End Property
    Private _MeshIntervalNumber35 As Double
    Public Property MeshIntervalNumber35() As Double
        Get
            Return _MeshIntervalNumber35
        End Get
        Set(ByVal value As Double)
            _MeshIntervalNumber35 = value
        End Set
    End Property
    Public Sub New(ByVal CompositionNumber5 As Double, ByVal MeshIntervalNumber35 As Double)
        Me._CompositionNumber5 = CompositionNumber5
        Me._MeshIntervalNumber35 = MeshIntervalNumber35
    End Sub
End Class
<System.Serializable()> Public Class HSMeshDataComposition6
    Private _CompositionNumber6 As Double
    Public Property CompositionNumber6() As Double
        Get
            Return _CompositionNumber6
        End Get
        Set(ByVal value As Double)
            _CompositionNumber6 = value
        End Set
    End Property
    Private _MeshIntervalNumber36 As Double
    Public Property MeshIntervalNumber36() As Double
        Get
            Return _MeshIntervalNumber36
        End Get
        Set(ByVal value As Double)
            _MeshIntervalNumber36 = value
        End Set
    End Property
    Public Sub New(ByVal CompositionNumber6 As Double, ByVal MeshIntervalNumber36 As Double)
        Me._CompositionNumber6 = CompositionNumber6
        Me._MeshIntervalNumber36 = MeshIntervalNumber36
    End Sub
End Class
<System.Serializable()> Public Class HSTemp1
    Private _Temp1Temperature As Double
    Public Property Temp1Temperature() As Double
        Get
            Return _Temp1Temperature
        End Get
        Set(ByVal value As Double)
            _Temp1Temperature = value
        End Set
    End Property
    Private _Temp1MeshPointNumber As Double
    Public Property Temp1MeshPointNumber() As Double
        Get
            Return _Temp1MeshPointNumber
        End Get
        Set(ByVal value As Double)
            _Temp1MeshPointNumber = value
        End Set
    End Property
    Public Sub New(ByVal Temp1Temperature As Double, ByVal Temp1MeshPointNumber As Double)
        Me._Temp1Temperature = Temp1Temperature
        Me._Temp1MeshPointNumber = Temp1MeshPointNumber
    End Sub

End Class

<System.Serializable()> Public Class HSTemp2
    Private _Temp2GammaAttenCo As Double
    Public Property Temp2GammaAttenCo() As Double
        Get
            Return _Temp2GammaAttenCo
        End Get
        Set(ByVal value As Double)
            _Temp2GammaAttenCo = value
        End Set
    End Property
    Private _Temp2MeshIntervalNumber As Double
    Public Property Temp2MeshIntervalNumber() As Double
        Get
            Return _Temp2MeshIntervalNumber
        End Get
        Set(ByVal value As Double)
            _Temp2MeshIntervalNumber = value
        End Set
    End Property
    Public Sub New(ByVal Temp2GammaAttenCo As Double, ByVal Temp2MeshIntervalNumber As Double)
        Me._Temp2GammaAttenCo = Temp2GammaAttenCo
        Me._Temp2MeshIntervalNumber = Temp2MeshIntervalNumber
    End Sub

End Class
<System.Serializable()> Public Class HSMat
    Private _CompositionMat As String
    Public Property CompositionMat() As String
        Get
            Return _CompositionMat
        End Get
        Set(ByVal value As String)
            _CompositionMat = value
        End Set
    End Property
    Private _MaterialNumber As Double
    Public Property MaterialNumber() As Double
        Get
            Return _MaterialNumber
        End Get
        Set(ByVal value As Double)
            _MaterialNumber = value
        End Set
    End Property

    Private _RegionIncluded As Boolean
    Public Property RegionIncluded() As Boolean
        Get
            Return _RegionIncluded
        End Get
        Set(ByVal value As Boolean)
            _RegionIncluded = value
        End Set
    End Property

    Private _gapmodel As Boolean
    Public Property gapmodel() As Boolean
        Get
            Return _gapmodel
        End Get
        Set(ByVal value As Boolean)
            _gapmodel = value
        End Set
    End Property

    Private _HSnum As Double
    Public Property HSnum() As Double
        Get
            Return _HSnum
        End Get
        Set(ByVal value As Double)
            _HSnum = value
        End Set
    End Property



    Public Sub New(ByVal CompositionMat As String, ByVal MaterialNumber As Double, ByVal RegionIncluded As Boolean, ByVal gapmodel As Boolean, ByVal HSnum As Double)
        Me._CompositionMat = CompositionMat
        Me._MaterialNumber = MaterialNumber
        Me._RegionIncluded = RegionIncluded
        Me._gapmodel = gapmodel
        Me._HSnum = HSnum
    End Sub

End Class

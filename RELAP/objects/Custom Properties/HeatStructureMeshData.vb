<System.Serializable()> Public Class HeatStructureMeshData
    Private _EnterMeshGeometry As Boolean
    Public Property EnterMeshGeometry() As Boolean
        Get
            Return _EnterMeshGeometry
        End Get
        Set(ByVal value As Boolean)
            _EnterMeshGeometry = value
        End Set
    End Property
    Private _EnterMeshGeometry2 As Boolean
    Public Property EnterMeshGeometry2() As Boolean
        Get
            Return _EnterMeshGeometry2
        End Get
        Set(ByVal value As Boolean)
            _EnterMeshGeometry2 = value
        End Set
    End Property
    Private _EnterMeshGeometry3 As Boolean
    Public Property EnterMeshGeometry3() As Boolean
        Get
            Return _EnterMeshGeometry3
        End Get
        Set(ByVal value As Boolean)
            _EnterMeshGeometry3 = value
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

    Public Sub New()
        m_collection = New Generic.SortedDictionary(Of Integer, HSMeshDataFormat1)
        m_collection2 = New Generic.SortedDictionary(Of Integer, HSMeshDataFormat2)
        m_collection3 = New Generic.SortedDictionary(Of Integer, HSMeshDataNoDecay)
        m_collection4 = New Generic.SortedDictionary(Of Integer, HSMeshDataWithDecay)
        m_collection5 = New Generic.SortedDictionary(Of Integer, HSMeshDataComposition)
    End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function

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

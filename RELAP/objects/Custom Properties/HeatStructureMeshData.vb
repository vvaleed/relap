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
    Protected m_collection As Generic.SortedDictionary(Of Integer, HeatStructureMeshData)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property State() As Generic.SortedDictionary(Of Integer, HeatStructureMeshData)
        Get
            Return m_collection
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, HeatStructureMeshData))
            m_collection = value
        End Set
    End Property

    Public Sub New()
        m_collection = New Generic.SortedDictionary(Of Integer, HeatStructureMeshData)
    End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function

End Class


<System.Serializable()> Public Class HeatStructureMeshData1

End Class
<System.Serializable()> Public Class HeatStructureMeshData2

End Class
<System.Serializable()> Public Class HeatStructureMeshData3

End Class
<System.Serializable()> Public Class HeatStructureMeshData4

End Class
<System.Serializable()> Public Class HeatStructureMeshData5


End Class

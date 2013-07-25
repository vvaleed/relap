<System.Serializable()> Public Class HeatStructureMeshData
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

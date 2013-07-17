<System.Serializable()> Public Class ThermoDynamicStates

    Protected m_collection As Generic.SortedDictionary(Of Integer, ThermoDynamicState)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property State() As Generic.SortedDictionary(Of Integer, ThermoDynamicState)
        Get
            Return m_collection
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, ThermoDynamicState))
            m_collection = value
        End Set
    End Property

    Public Sub New()
        m_collection = New Generic.SortedDictionary(Of Integer, ThermoDynamicState)
    End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function
End Class
Public Class ThermoDynamicState
    Private _StatesString As String
    Public Property StatesString() As String
        Get
            Return _StatesString
        End Get
        Set(ByVal value As String)
            _StatesString = value
        End Set
    End Property
    Private _StateType As String
    Public Property StateType() As String
        Get
            Return _StateType
        End Get
        Set(ByVal value As String)
            _StateType = value
        End Set
    End Property


    Public Sub New(str, statetype)
        Me._StatesString = str
        Me._StateType = statetype
    End Sub
End Class

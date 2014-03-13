<System.Serializable()> Public Class MinorEdit
    Private _storeindex As Integer
    Public Property storeindex() As Integer
        Get
            Return _storeindex
        End Get
        Set(ByVal value As Integer)
            _storeindex = value
        End Set
    End Property


    Private _cmbocheck As Integer
    Public Property cmbocheck() As Integer
        Get
            Return _cmbocheck
        End Get
        Set(ByVal value As Integer)
            _cmbocheck = value
        End Set
    End Property
    Protected m_collection As Generic.SortedDictionary(Of Integer, MinorEdit101)
    ' Protected m_status As 
    'EditorStatus = PipeEditorStatus.Definir

    Public Property ProMinorEdit101() As Generic.SortedDictionary(Of Integer, MinorEdit101)
        Get
            Return m_collection
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, MinorEdit101))
            m_collection = value
        End Set
    End Property

    Public Sub New()
        m_collection = New Generic.SortedDictionary(Of Integer, MinorEdit101)
    End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function
End Class
<System.Serializable()> Public Class MinorEdit101
    Private _cboVariableCode As String
    Public Property cboVariableCode() As String
        Get
            Return _cboVariableCode
        End Get
        Set(ByVal value As String)
            _cboVariableCode = value
        End Set
    End Property
    Private _cboParameter As String
    Public Property cboParameter() As String
        Get
            Return _cboParameter
        End Get
        Set(ByVal value As String)
            _cboParameter = value
        End Set
    End Property


    Public Sub New(ByVal cboVariableCode, ByVal cboParameter)
        Me._cboVariableCode = cboVariableCode
        Me._cboParameter = cboParameter
    End Sub
End Class

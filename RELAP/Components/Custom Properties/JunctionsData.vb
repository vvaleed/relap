<System.Serializable()> Public Class JunctionsData

    Private _EnterMassorVelocity As Double
    Public Property EnterMassorVelocity() As Double
        Get
            Return _EnterMassorVelocity
        End Get
        Set(ByVal value As Double)
            _EnterMassorVelocity = value
        End Set
    End Property

    Protected m_collection As Generic.SortedDictionary(Of Integer, JunctionDatavelocity)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property JunctionDatavelocity() As Generic.SortedDictionary(Of Integer, JunctionDatavelocity)
        Get
            Return m_collection
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, JunctionDatavelocity))
            m_collection = value
        End Set
    End Property
  

    Public Sub New()
        m_collection = New Generic.SortedDictionary(Of Integer, JunctionDatavelocity)

    End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function

End Class
<System.Serializable()> Public Class JunctionDatavelocity
    Private _TimeVelocity As Double
    Public Property TimeVelocity() As Double
        Get
            Return _TimeVelocity
        End Get
        Set(ByVal value As Double)
            _TimeVelocity = value
        End Set
    End Property
    Private _LiquidVelocity As Double
    Public Property LiquidVelocity() As Double
        Get
            Return _LiquidVelocity
        End Get
        Set(ByVal value As Double)
            _LiquidVelocity = value
        End Set
    End Property

    Private _VaporVelocity As Double
    Public Property VaporVelocity() As Double
        Get
            Return _VaporVelocity
        End Get
        Set(ByVal value As Double)
            _VaporVelocity = value
        End Set
    End Property


    Public Sub New(ByVal TimeVelocity As Double, ByVal LiquidVelocity As Double, ByVal VaporVelocity As Double)
        Me._TimeVelocity = TimeVelocity
        Me._LiquidVelocity = LiquidVelocity
        Me._VaporVelocity = VaporVelocity
    End Sub
End Class


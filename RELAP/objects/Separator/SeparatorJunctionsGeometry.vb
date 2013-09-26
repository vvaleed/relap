<System.Serializable()> Public Class SeparatorJunctionsGeometry

    'Private _EnterMassorVelocity As Double
    'Public Property EnterMassorVelocity() As Double
    '    Get
    '        Return _EnterMassorVelocity
    '    End Get
    '    Set(ByVal value As Double)
    '        _EnterMassorVelocity = value
    '    End Set
    'End Property
    Private _toN As Integer
    Public Property toN() As Integer
        Get
            Return _toN
        End Get
        Set(ByVal value As Integer)
            _toN = value
        End Set
    End Property
    Private _fromN As Integer
    Public Property fromN() As Integer
        Get
            Return _fromN
        End Get
        Set(ByVal value As Integer)
            _fromN = value
        End Set
    End Property
    Protected m_collection As Generic.SortedDictionary(Of Integer, SeparatorGeometry)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property SeparatorGeometry() As Generic.SortedDictionary(Of Integer, SeparatorGeometry)
        Get
            Return m_collection
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, SeparatorGeometry))
            m_collection = value
        End Set
    End Property

    'Protected m_collection1 As Generic.SortedDictionary(Of Integer, JunctionDataMass)
    '' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    'Public Property JunctionDataMass() As Generic.SortedDictionary(Of Integer, JunctionDataMass)
    '    Get
    '        Return m_collection1
    '    End Get
    '    Set(ByVal value As Generic.SortedDictionary(Of Integer, JunctionDataMass))
    '        m_collection1 = value
    '    End Set
    'End Property

    Public Sub New()
        m_collection = New Generic.SortedDictionary(Of Integer, SeparatorGeometry)
        '    m_collection1 = New Generic.SortedDictionary(Of Integer, JunctionDataMass)
    End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function

End Class
<System.Serializable()> Public Class SeparatorGeometry
    Private _FromComponent As String
    Public Property FromComponent() As String
        Get
            Return _FromComponent
        End Get
        Set(ByVal value As String)
            _FromComponent = value
        End Set
    End Property
    Private _FromComponentVolumeNumber As Double
    Public Property FromComponentVolumeNumber() As Double
        Get
            Return _FromComponentVolumeNumber
        End Get
        Set(ByVal value As Double)
            _FromComponentVolumeNumber = value
        End Set
    End Property

    Private _FromFaceNumber As String
    Public Property FromFaceNumber() As String
        Get
            Return _FromFaceNumber
        End Get
        Set(ByVal value As String)
            _FromFaceNumber = value
        End Set
    End Property
    Private _ToComponent As String
    Public Property ToComponent() As String
        Get
            Return _ToComponent
        End Get
        Set(ByVal value As String)
            _ToComponent = value
        End Set
    End Property

    Private _ToComponentVolumeNumber As Double
    Public Property ToComponentVolumeNumber() As Double
        Get
            Return _ToComponentVolumeNumber
        End Get
        Set(ByVal value As Double)
            _ToComponentVolumeNumber = value
        End Set
    End Property
    Private _ToFaceNumber As String
    Public Property ToFaceNumber() As String
        Get
            Return _ToFaceNumber
        End Get
        Set(ByVal value As String)
            _ToFaceNumber = value
        End Set
    End Property
    Private _JunctionArea As Double
    Public Property JunctionArea() As Double
        Get
            Return _JunctionArea
        End Get
        Set(ByVal value As Double)
            _JunctionArea = value
        End Set
    End Property

    Private _FFLossCo As Double
    Public Property FFLossCo() As Double
        Get
            Return _FFLossCo
        End Get
        Set(ByVal value As Double)
            _FFLossCo = value
        End Set
    End Property
    Private _RFlossCo As Double
    Public Property RFlossCo() As Double
        Get
            Return _RFlossCo
        End Get
        Set(ByVal value As Double)
            _RFlossCo = value
        End Set
    End Property

    Private _SubcooledDischargeCo As Double
    Public Property SubcooledDischargeCo() As Double
        Get
            Return _SubcooledDischargeCo
        End Get
        Set(ByVal value As Double)
            _SubcooledDischargeCo = value
        End Set
    End Property

    Private _LiquidMassFlow As Double
    Public Property LiquidMassFlow() As Double
        Get
            Return _LiquidMassFlow
        End Get
        Set(ByVal value As Double)
            _LiquidMassFlow = value
        End Set
    End Property

    Private _VaporMassFlow As Double
    Public Property VaporMassFlow() As Double
        Get
            Return _VaporMassFlow
        End Get
        Set(ByVal value As Double)
            _VaporMassFlow = value
        End Set
    End Property
   



    Public Sub New(ByVal FromComponent As String, ByVal FromComponentVolumeNumber As Double, ByVal FromFaceNumber As String, ByVal ToComponent As String, ByVal ToComponentVolumeNumber As Double, ByVal ToFaceNumber As String, ByVal JunctionArea As Double, ByVal FFLossCo As Double, ByVal RFlossCo As Double, _
                   ByVal SubcooledDischargeCo As Double, ByVal LiquidMassFlow As Double, ByVal VaporMassFlow As Double)
        Me._FromComponent = FromComponent
        Me._FromComponentVolumeNumber = FromComponentVolumeNumber
        Me._FromFaceNumber = FromFaceNumber
        Me._ToComponent = ToComponent
        Me._ToComponentVolumeNumber = ToComponentVolumeNumber
        Me._ToFaceNumber = ToFaceNumber
        Me._JunctionArea = JunctionArea
        Me._FFLossCo = FFLossCo
        Me._RFlossCo = RFlossCo
        Me._SubcooledDischargeCo = SubcooledDischargeCo
        Me._LiquidMassFlow = LiquidMassFlow
        Me._VaporMassFlow = VaporMassFlow
    End Sub
End Class


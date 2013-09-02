<System.Serializable()> Public Class BranchJunctionsGeometry

    'Private _EnterMassorVelocity As Double
    'Public Property EnterMassorVelocity() As Double
    '    Get
    '        Return _EnterMassorVelocity
    '    End Get
    '    Set(ByVal value As Double)
    '        _EnterMassorVelocity = value
    '    End Set
    'End Property

    Protected m_collection As Generic.SortedDictionary(Of Integer, BranchGeometry)
    ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    Public Property BranchGeometry() As Generic.SortedDictionary(Of Integer, BranchGeometry)
        Get
            Return m_collection
        End Get
        Set(ByVal value As Generic.SortedDictionary(Of Integer, BranchGeometry))
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
        m_collection = New Generic.SortedDictionary(Of Integer, BranchGeometry)
        '    m_collection1 = New Generic.SortedDictionary(Of Integer, JunctionDataMass)
    End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function

End Class
<System.Serializable()> Public Class BranchGeometry
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

    Private _PVterm As Boolean
    Public Property PVterm() As Boolean
        Get
            Return _PVterm
        End Get
        Set(ByVal value As Boolean)
            _PVterm = value
        End Set
    End Property
    Private _CCFLModel As Boolean
    Public Property CCFLModel() As Boolean
        Get
            Return _CCFLModel
        End Get
        Set(ByVal value As Boolean)
            _CCFLModel = value
        End Set
    End Property
    Private _StratificationModel As String
    Public Property StratificationModel() As String
        Get
            Return _StratificationModel
        End Get
        Set(ByVal value As String)
            _StratificationModel = value
        End Set
    End Property
    Private _ChokingModel As Boolean
    Public Property ChokingModel() As Boolean
        Get
            Return _ChokingModel
        End Get
        Set(ByVal value As Boolean)
            _ChokingModel = value
        End Set
    End Property
    Private _AreaChange As String
    Public Property AreaChange() As String
        Get
            Return _AreaChange
        End Get
        Set(ByVal value As String)
            _AreaChange = value
        End Set
    End Property
    Private _VelocityMomentumEquation As String
    Public Property VelocityMomentumEquation() As String
        Get
            Return _VelocityMomentumEquation
        End Get
        Set(ByVal value As String)
            _VelocityMomentumEquation = value
        End Set
    End Property
    Private _MomentumFlux As String
    Public Property MomentumFlux() As String
        Get
            Return _MomentumFlux
        End Get
        Set(ByVal value As String)
            _MomentumFlux = value
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
    Private _TwoPhaseDischargeCo As Double
    Public Property TwoPhaseDischargeCo() As Double
        Get
            Return _TwoPhaseDischargeCo
        End Get
        Set(ByVal value As Double)
            _TwoPhaseDischargeCo = value
        End Set
    End Property
    Private _SuperheatedDischargeCo As Double
    Public Property SuperheatedDischargeCo() As Double
        Get
            Return _SuperheatedDischargeCo
        End Get
        Set(ByVal value As Double)
            _SuperheatedDischargeCo = value
        End Set
    End Property


    Public Sub New(ByVal FromComponent As String, ByVal FromComponentVolumeNumber As Double, ByVal FromFaceNumber As String, ByVal ToComponent As String, ByVal ToComponentVolumeNumber As Double, ByVal ToFaceNumber As String, ByVal JunctionArea As Double, ByVal FFLossCo As Double, ByVal RFlossCo As Double, _
                   ByVal PVterm As Boolean, ByVal CCFLModel As Boolean, ByVal StratificationModel As String, ByVal ChokingModel As Boolean, ByVal AreaChange As String, ByVal VelocityMomentumEquation As String, ByVal MomentumFlux As String, ByVal SubcooledDischargeCo As Double, ByVal TwoPhaseDischargeCo As Double, ByVal SuperheatedDischargeCo As Double)
        Me._FromComponent = FromComponent
        Me._FromComponentVolumeNumber = FromComponentVolumeNumber
        Me._FromFaceNumber = FromFaceNumber
        Me._ToComponent = ToComponent
        Me._ToComponentVolumeNumber = ToComponentVolumeNumber
        Me._ToFaceNumber = ToFaceNumber
        Me._JunctionArea = JunctionArea
        Me._FFLossCo = FFLossCo
        Me._RFlossCo = RFlossCo
        Me._PVterm = PVterm
        Me._CCFLModel = CCFLModel
        Me._StratificationModel = StratificationModel
        Me._ChokingModel = ChokingModel
        Me._AreaChange = AreaChange
        Me._VelocityMomentumEquation = VelocityMomentumEquation
        Me._MomentumFlux = MomentumFlux
        Me._SubcooledDischargeCo = SubcooledDischargeCo
        Me._TwoPhaseDischargeCo = TwoPhaseDischargeCo
        Me._SuperheatedDischargeCo = SuperheatedDischargeCo
    End Sub
End Class

'<System.Serializable()> Public Class JunctionDataMass
'    Private _TimeMass As Double
'    Public Property TimeMass() As Double
'        Get
'            Return _TimeMass
'        End Get
'        Set(ByVal value As Double)
'            _TimeMass = value
'        End Set
'    End Property
'    Private _LiquidMassFlow As Double
'    Public Property LiquidMassFlow() As Double
'        Get
'            Return _LiquidMassFlow
'        End Get
'        Set(ByVal value As Double)
'            _LiquidMassFlow = value
'        End Set
'    End Property

'    Private _VaporMassFlow As Double
'    Public Property VaporMassFlow() As Double
'        Get
'            Return _VaporMassFlow
'        End Get
'        Set(ByVal value As Double)
'            _VaporMassFlow = value
'        End Set
'    End Property

'    Private _InterfaceVelocitym As Double
'    Public Property InterfaceVelocitym() As Double
'        Get
'            Return _InterfaceVelocitym
'        End Get
'        Set(ByVal value As Double)
'            _InterfaceVelocitym = value
'        End Set
'    End Property


'    Public Sub New(ByVal TimeMass As Double, ByVal LiquidMassFlow As Double, ByVal VaporMassFlow As Double, ByVal InterfaceVelocitym As Double)
'        Me._TimeMass = TimeMass
'        Me._LiquidMassFlow = LiquidMassFlow
'        Me._VaporMassFlow = VaporMassFlow
'        Me._InterfaceVelocitym = InterfaceVelocitym
'    End Sub
'End Class

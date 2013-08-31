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

    'Protected m_collection As Generic.SortedDictionary(Of Integer, JunctionDatavelocity)
    '' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

    'Public Property JunctionDatavelocity() As Generic.SortedDictionary(Of Integer, JunctionDatavelocity)
    '    Get
    '        Return m_collection
    '    End Get
    '    Set(ByVal value As Generic.SortedDictionary(Of Integer, JunctionDatavelocity))
    '        m_collection = value
    '    End Set
    'End Property
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

    'Public Sub New()
    '    m_collection = New Generic.SortedDictionary(Of Integer, JunctionDatavelocity)
    '    m_collection1 = New Generic.SortedDictionary(Of Integer, JunctionDataMass)
    'End Sub
    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function

End Class
'<System.Serializable()> Public Class JunctionDatavelocity
'    Private _TimeVelocity As Double
'    Public Property TimeVelocity() As Double
'        Get
'            Return _TimeVelocity
'        End Get
'        Set(ByVal value As Double)
'            _TimeVelocity = value
'        End Set
'    End Property
'    Private _LiquidVelocity As Double
'    Public Property LiquidVelocity() As Double
'        Get
'            Return _LiquidVelocity
'        End Get
'        Set(ByVal value As Double)
'            _LiquidVelocity = value
'        End Set
'    End Property

'    Private _VaporVelocity As Double
'    Public Property VaporVelocity() As Double
'        Get
'            Return _VaporVelocity
'        End Get
'        Set(ByVal value As Double)
'            _VaporVelocity = value
'        End Set
'    End Property

'    Private _InterfaceVelocityv As Double
'    Public Property InterfaceVelocityv() As Double
'        Get
'            Return _InterfaceVelocityv
'        End Get
'        Set(ByVal value As Double)
'            _InterfaceVelocityv = value
'        End Set
'    End Property


'    Public Sub New(ByVal TimeVelocity As Double, ByVal LiquidVelocity As Double, ByVal VaporVelocity As Double, ByVal InterfaceVelocityv As Double)
'        Me._TimeVelocity = TimeVelocity
'        Me._LiquidVelocity = LiquidVelocity
'        Me._VaporVelocity = VaporVelocity
'        Me._InterfaceVelocityv = InterfaceVelocityv
'    End Sub
'End Class

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

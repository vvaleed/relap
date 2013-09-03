<System.Serializable()> Public Class ValveType


    Private _ValveTypeName As String
    Public Property ValveTypeName() As String
        Get
            Return _ValveTypeName
        End Get
        Set(ByVal value As String)
            _ValveTypeName = value
        End Set
    End Property


    Private _CheckType As String
    Public Property CheckType() As String
        Get
            Return _CheckType
        End Get
        Set(ByVal value As String)
            _CheckType = value
        End Set
    End Property

    Private _checkPosition As String
    Public Property checkPosition() As String
        Get
            Return _checkPosition
        End Get
        Set(ByVal value As String)
            _checkPosition = value
        End Set
    End Property

    Private _checkbackpressure As String
    Public Property checkbackpressure() As String
        Get
            Return _checkbackpressure
        End Get
        Set(ByVal value As String)
            _checkbackpressure = value
        End Set
    End Property

    Private _checkleakratio As String
    Public Property checkleakratio() As String
        Get
            Return _checkleakratio
        End Get
        Set(ByVal value As String)
            _checkleakratio = value
        End Set
    End Property

    Private _tripvalvetripno As String
    Public Property tripvalvetripno() As String
        Get
            Return _tripvalvetripno
        End Get
        Set(ByVal value As String)
            _tripvalvetripno = value
        End Set
    End Property

    Private _inertialLatchoption As String
    Public Property inertialLatchoption() As String
        Get
            Return _inertialLatchoption
        End Get
        Set(ByVal value As String)
            _inertialLatchoption = value
        End Set
    End Property

    Private _inertialInitialposition As String
    Public Property inertialInitialposition() As String
        Get
            Return _inertialInitialposition
        End Get
        Set(ByVal value As String)
            _inertialInitialposition = value
        End Set
    End Property

    Private _inertialbackpressure As String
    Public Property inertialbackpressure() As String
        Get
            Return _inertialbackpressure
        End Get
        Set(ByVal value As String)
            _inertialbackpressure = value
        End Set
    End Property

    Private _inertialLeakratio As String
    Public Property inertialLeakratio() As String
        Get
            Return _inertialLeakratio
        End Get
        Set(ByVal value As String)
            _inertialLeakratio = value
        End Set
    End Property

    Private _inertialinitialangle As String
    Public Property inertialinitialangle() As String
        Get
            Return _inertialinitialangle
        End Get
        Set(ByVal value As String)
            _inertialinitialangle = value
        End Set
    End Property

    Private _inertialminangle As String
    Public Property inertialminangle() As String
        Get
            Return _inertialminangle
        End Get
        Set(ByVal value As String)
            _inertialminangle = value
        End Set
    End Property

    Private _inertialmaxangle As String
    Public Property inertialmaxangle() As String
        Get
            Return _inertialmaxangle
        End Get
        Set(ByVal value As String)
            _inertialmaxangle = value
        End Set
    End Property

    Private _inertialmomentinertia As String
    Public Property inertialmomentinertia() As String
        Get
            Return _inertialmomentinertia
        End Get
        Set(ByVal value As String)
            _inertialmomentinertia = value
        End Set
    End Property

    Private _inertialangularvelocity As String
    Public Property inertialangularvelocity() As String
        Get
            Return _inertialangularvelocity
        End Get
        Set(ByVal value As String)
            _inertialangularvelocity = value
        End Set
    End Property

    Private _inertialmomentlength As String
    Public Property inertialmomentlength() As String
        Get
            Return _inertialmomentlength
        End Get
        Set(ByVal value As String)
            _inertialmomentlength = value
        End Set
    End Property

    Private _inertialradius As String
    Public Property inertialradius() As String
        Get
            Return _inertialradius
        End Get
        Set(ByVal value As String)
            _inertialradius = value
        End Set
    End Property

    Private _inertialmass As String
    Public Property inertialmass() As String
        Get
            Return _inertialmass
        End Get
        Set(ByVal value As String)
            _inertialmass = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return "Click to Edit..."
    End Function
End Class

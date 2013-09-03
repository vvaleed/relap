Public Class ucValveEditor
    Private _ValveType As ValveType
    Public Property ValveType() As ValveType
        Get
            Return _ValveType
        End Get
        Set(ByVal value As ValveType)
            _ValveType = value
        End Set
    End Property

    Private _us As RELAP.SistemasDeUnidades.Unidades
    Public Property SystemOfUnits() As RELAP.SistemasDeUnidades.Unidades
        Get
            Return _us
        End Get
        Set(ByVal value As RELAP.SistemasDeUnidades.Unidades)
            _us = value
        End Set
    End Property

    Private _nf As String
    Public Property NumberFormat() As String
        Get
            Return _nf
        End Get
        Set(ByVal value As String)
            _nf = value
        End Set
    End Property

   
End Class

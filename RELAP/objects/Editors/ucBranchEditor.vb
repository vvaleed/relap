Public Class ucBranchEditor

    Private _BranchJunctionsGeometry As BranchJunctionsGeometry
    Public Property BranchJunctionsGeometry() As BranchJunctionsGeometry
        Get
            Return _BranchJunctionsGeometry
        End Get
        Set(ByVal value As BranchJunctionsGeometry)
            _BranchJunctionsGeometry = value
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

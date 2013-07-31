Public Class ucHeatStructureEditor2
    Private _HeatStructureBoundaryCond As HeatStructureBoundaryCond
    Public Property HeatStructureBoundaryCond() As HeatStructureBoundaryCond
        Get
            Return _HeatStructureBoundaryCond
        End Get
        Set(ByVal value As HeatStructureBoundaryCond)
            _HeatStructureBoundaryCond = value
        End Set
    End Property
    Private _BC As RELAP.SistemasDeUnidades.Unidades
    Public Property SystemOfUnits() As RELAP.SistemasDeUnidades.Unidades
        Get
            Return _BC
        End Get
        Set(ByVal value As RELAP.SistemasDeUnidades.Unidades)
            _BC = value
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

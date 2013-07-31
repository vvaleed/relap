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

    Private Sub ucHeatStructureEditor2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim gobj As Microsoft.MSDN.Samples.GraphicObjects.HeatStructureGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myCOTK As RELAP.SimulationObjects.UnitOps.HeatStructure = My.Application.ActiveSimulation.Collections.CLCS_HeatStructureCollection(gobj.Name)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvtab1.CellEnter, dgvTab2.CellEnter, dgvTab3.CellEnter, cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10 As Object

        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab1.Clear()
            Me.HeatStructureBoundaryCond.BoundaryCondTab2.Clear()
            Me.HeatStructureBoundaryCond.BoundaryCondTab3.Clear()
            Me.HeatStructureBoundaryCond.BoundaryCondTab4.Clear()
            Me.HeatStructureBoundaryCond.BoundaryCondTab5.Clear()
        End If
        Try
            For Each row In Me.dgvtab1.Rows
                v1 = row.Cells(0).Value
                v2 = row.Cells(1).Value
                v3 = row.Cells(2).Value
                v4 = row.Cells(3).Value
                v5 = row.Cells(4).Value
                v6 = row.Cells(5).Value
                Me.HeatStructureBoundaryCond.BoundaryCondTab1.Add(row.Index + 1, New HSBoundaryCondTab1(v1, v2, v3, v4, v5, v6))
            Next
        Catch ex As Exception

        End Try

        For Each row In Me.dgvTab3.Rows
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab3.Add(row.Index + 1, New HSBoundaryCondTab3(v1, v2, v3, v4, v5))
        Next
        row.Dispose()
    End Sub
End Class

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

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12 As Object

        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab1.Clear()
        End If

        For i = 0 To dgvtab1.Rows.Count - 2
            row = dgvtab1.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            v6 = row.Cells(5).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab1.Add(row.Index + 1, New HSBoundaryCondTab1(v1, v2, v3, v4, v5, v6))
        Next
        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab2.Clear()
        End If

        For i = 0 To dgvTab2.Rows.Count - 2
            row = dgvTab2.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            v6 = row.Cells(5).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab2.Add(row.Index + 1, New HSBoundaryCondTab2(v1, v2, v3, v4, v5, v6))
        Next

        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab3.Clear()
        End If

        For i = 0 To dgvTab3.Rows.Count - 2
            row = dgvTab3.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab3.Add(row.Index + 1, New HSBoundaryCondTab3(v1, v2, v3, v4, v5))
        Next
        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab4.Clear()
        End If

        For i = 0 To dgvTab4.Rows.Count - 2
            row = dgvTab4.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            v6 = row.Cells(5).Value
            v7 = row.Cells(6).Value
            v8 = row.Cells(7).Value
            v9 = row.Cells(8).Value
            v10 = row.Cells(9).Value
            v11 = row.Cells(10).Value
            v12 = row.Cells(11).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab4.Add(row.Index + 1, New HSBoundaryCondTab4(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12))
        Next
        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab5.Clear()
        End If

        For i = 0 To dgvTab5.Rows.Count - 2
            row = dgvTab5.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            v6 = row.Cells(5).Value
            v7 = row.Cells(6).Value
            v8 = row.Cells(7).Value
            v9 = row.Cells(8).Value
            v10 = row.Cells(9).Value
            v11 = row.Cells(10).Value
            v12 = row.Cells(11).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab5.Add(row.Index + 1, New HSBoundaryCondTab5(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12))
        Next
        row.Dispose()
    End Sub
End Class

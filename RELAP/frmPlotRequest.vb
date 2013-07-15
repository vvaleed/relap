Public Class frmPlotRequest
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        cboObjects.Items.Clear()
        For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
            cboObjects.Items.Add(kvp.Value.GraphicObject.Tag)
        Next
    End Sub
End Class
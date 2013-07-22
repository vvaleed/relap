Public Class frmPlotRequest
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
    Public objs As New List(Of String)
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        cboObjects.Items.Clear()


        For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
            cboObjects.Items.Add(kvp.Value.GraphicObject.Tag)
            objs.Add(kvp.Value.UID)
        Next

        

    End Sub


    Private Sub frmPlotRequest_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboPlotVariableName.SelectedIndex = 9
    End Sub
End Class
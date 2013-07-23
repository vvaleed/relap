Public Class frmPlotRequest
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

   
    Private Sub frmPlotRequest_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        cboObjects.Items.Clear()

        For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
            cboObjects.Items.Add(kvp.Value.GraphicObject.Tag)

        Next

    End Sub


    Private Sub frmPlotRequest_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboPlotVariableName.SelectedIndex = 9
    End Sub
End Class
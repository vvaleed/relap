Public Class frmPlotRequest
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

   
    Private Sub frmPlotRequest_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
     

    End Sub


    Private Sub frmPlotRequest_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboPlotVariableName.SelectedIndex = 9
    End Sub

    Private Sub frmPlotRequest_Shown(sender As Object, e As EventArgs) Handles Me.Shown, Me.GotFocus, Me.Load, Me.LostFocus, DataGridView1.CellClick
        Try


            cboObjects.Items.Clear()

            For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                cboObjects.Items.Add(kvp.Value.GraphicObject.Tag)

            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
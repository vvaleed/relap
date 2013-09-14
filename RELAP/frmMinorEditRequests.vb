Public Class frmMinorEditRequests
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Private Sub frmMinorEditRequests_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try


            txtVariableCode.Items.Clear()

            For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                txtVariableCode.Items.Add(kvp.Value.GraphicObject.Tag)

            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
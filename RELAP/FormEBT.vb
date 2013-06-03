Public Class frmEBT

    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Private Sub cmbothermostates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbothermostates.SelectedIndexChanged
        If cmbothermostates.SelectedIndex = 0 Then
            TableLayoutPanel1.ColumnCount = 1
        ElseIf cmbothermostates.SelectedIndex = 1 Then
            TableLayoutPanel1.ColumnCount = 2


        End If
    End Sub

    Private Sub TableLayoutPanel1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableLayoutPanel1.TabIndexChanged

    End Sub
End Class
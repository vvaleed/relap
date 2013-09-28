Public Class frmCoreInput
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent



    Private Sub txtAxialNodes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAxialNodes.ValueChanged
        If txtAxialNodes.Value > 0 Then
            dgvAxialNodeHeights.Rows.Clear()
            For i As Integer = 1 To txtAxialNodes.Text
                dgvAxialNodeHeights.Rows.Add(i.ToString)
            Next

        End If
    End Sub

    Private Sub dgvGridSpacer_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvGridSpacer.RowsAdded
        dgvGridSpacer.Rows(e.RowIndex).Cells(0).Value = e.RowIndex + 1
    End Sub
End Class
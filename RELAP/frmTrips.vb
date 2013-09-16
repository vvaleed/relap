Public Class frmTrips
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.ColumnIndex = 1 Then
            DataGridView1.Rows(e.RowIndex).Cells(8).Value = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        End If
        If e.ColumnIndex = 4 Then
            DataGridView1.Rows(e.RowIndex).Cells(9).Value = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        End If
    End Sub
End Class
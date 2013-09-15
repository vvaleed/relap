Public Class frmMinorEditRequests
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    Private Sub frmMinorEditRequests_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try


            cboParameter.Items.Clear()

            For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                cboParameter.Items.Add(kvp.Value.GraphicObject.Tag)

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        If e.ColumnIndex = 0 Then
            Dim str As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If str = "CNTRLVAR" Or str = "CPUTIME" Or str = "BGNHG" Or str = "BGMCT" Then
                DataGridView1.Columns(2).Visible = True
                DataGridView1.Columns(1).Visible = False
            Else
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(1).Visible = True
            End If
        End If
    End Sub
End Class
Public Class frmMinorEditRequests
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

   

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

    Private Sub frmMinorEditRequests_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboParameter.DisplayMember = "Tag"
        Try
            cboParameter.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
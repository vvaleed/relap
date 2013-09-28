Public Class frmCoreInput
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
    Dim selectedcells As New List(Of Object)
    Dim selectedcells2 As New List(Of Object)


    Private Sub txtAxialNodes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAxialNodes.ValueChanged
        If txtAxialNodes.Value > 0 Then
            dgvAxialNodeHeights.Rows.Clear()
            For i As Integer = 1 To txtAxialNodes.Text
                dgvAxialNodeHeights.Rows.Add(i.ToString)
            Next
        End If
    End Sub

    Private Sub dgvGridSpacer_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGridSpacer.RowEnter
        dgvGridSpacer.Rows(e.RowIndex).Cells(0).Value = e.RowIndex + 1
    End Sub

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click
        If dgvAxialNodeHeights.SelectedRows.Count = 1 Then
            selectedcells.Clear()
            For Each cell As DataGridViewCell In dgvAxialNodeHeights.SelectedRows(0).Cells
                selectedcells.Add(cell.Value)
            Next
        End If
    End Sub

    Private Sub cmdPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPaste.Click
        For Each row As DataGridViewRow In dgvAxialNodeHeights.SelectedRows
            Dim i = 0
            For i = 1 To row.Cells.Count - 1
                row.Cells(i).Value = selectedcells(i)
            Next
        Next
    End Sub

    Private Sub cmdCopytoAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopytoAll.Click
        If dgvAxialNodeHeights.SelectedRows.Count = 1 Then
            selectedcells.Clear()
            For Each cell As DataGridViewCell In dgvAxialNodeHeights.SelectedRows(0).Cells
                selectedcells.Add(cell.Value)
            Next
        End If
        For Each row As DataGridViewRow In dgvAxialNodeHeights.Rows
            Dim i = 0
            For i = 1 To row.Cells.Count - 1
                row.Cells(i).Value = selectedcells(i)
            Next
        Next
    End Sub

    Private Sub cmdCopy2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy2.Click
        If dgvGridSpacer.SelectedRows.Count = 1 Then
            selectedcells.Clear()
            For Each cell As DataGridViewCell In dgvGridSpacer.SelectedRows(0).Cells
                selectedcells.Add(cell.Value)
            Next
        End If
    End Sub

    Private Sub cmdPaste2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPaste2.Click
        For Each row As DataGridViewRow In dgvGridSpacer.SelectedRows
            Dim i = 0
            For i = 1 To row.Cells.Count - 1
                row.Cells(i).Value = selectedcells(i)
            Next
        Next
    End Sub

    Private Sub cmdCopytoAll2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopytoAll2.Click
        If dgvGridSpacer.SelectedRows.Count = 1 Then
            selectedcells.Clear()
            For Each cell As DataGridViewCell In dgvGridSpacer.SelectedRows(0).Cells
                selectedcells.Add(cell.Value)
            Next
        End If
        For Each row As DataGridViewRow In dgvGridSpacer.Rows
            Dim i = 0
            For i = 1 To row.Cells.Count - 1
                row.Cells(i).Value = selectedcells(i)
            Next
        Next
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            cboComponent.DisplayMember = "Tag"
            cboComponent.ValueMember = "Value"
            cboComponentatTopCenter.DisplayMember = "Tag"
            cboComponentatTopCenter.ValueMember = "Value"
            cboComponenttoReceiveSlumped.DisplayMember = "Tag"
            cboComponenttoReceiveSlumped.ValueMember = "Value"
            cboComponent.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
            cboComponentatTopCenter.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
            cboComponenttoReceiveSlumped.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
        Catch ex As Exception

        End Try

    End Sub
End Class
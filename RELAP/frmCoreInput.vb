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
        cboComponent.DisplayMember = "Tag"
        cboComponent.ValueMember = "Value"
        cboComponentatTopCenter.DisplayMember = "Tag"
        cboComponentatTopCenter.ValueMember = "Value"
        cboComponenttoReceiveSlumped.DisplayMember = "Tag"
        cboComponenttoReceiveSlumped.ValueMember = "Value"
        Try

            cboComponent.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
            cboComponentatTopCenter.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
            cboComponenttoReceiveSlumped.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dgvAxialNodeHeights_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAxialNodeHeights.CellClick
        cmdCopy.Enabled = False
        cmdCopytoAll.Enabled = False
        cmdPaste.Enabled = False
    End Sub

    Private Sub dgvAxialNodeHeights_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAxialNodeHeights.RowHeaderMouseClick
        If dgvAxialNodeHeights.SelectedRows.Count = 1 Then
            cmdCopy.Enabled = True
            cmdCopytoAll.Enabled = True
        Else
            cmdCopy.Enabled = False
            cmdCopytoAll.Enabled = False
        End If
        If dgvAxialNodeHeights.SelectedRows.Count > 0 Then
            cmdPaste.Enabled = True
        Else
            cmdPaste.Enabled = True
        End If
    End Sub

    Private Sub dgvGridSpacer_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGridSpacer.CellClick
        cmdCopy2.Enabled = False
        cmdCopytoAll2.Enabled = False
        cmdPaste2.Enabled = False
    End Sub

    Private Sub dgvGridSpacer_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvGridSpacer.RowHeaderMouseClick
        If dgvGridSpacer.SelectedRows.Count = 1 Then
            cmdCopy2.Enabled = True
            cmdCopytoAll2.Enabled = True
        Else
            cmdCopy2.Enabled = False
            cmdCopytoAll2.Enabled = False
        End If
        If dgvGridSpacer.SelectedRows.Count > 0 Then
            cmdPaste2.Enabled = True
        Else
            cmdPaste2.Enabled = True
        End If
    End Sub

    Private Sub frmCoreInput_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cboCoreSlumpingModel.SelectedIndex = 0
        cboFuelRodDisintegration.SelectedIndex = 0
        cboModelsforFailure.SelectedIndex = 0
        cboPowerHistoryTy.SelectedIndex = 0
        cboPressureDropFlag.SelectedIndex = 0
        cboReactorEnvironment.SelectedIndex = 0
        cboSourceofData.SelectedIndex = 0
    End Sub

   
End Class
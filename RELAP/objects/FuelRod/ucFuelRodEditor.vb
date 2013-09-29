Imports RELAP.RELAP.SimulationObjects.UnitOps

Public Class ucFuelRodEditor


    Private m_FuelRodDetails As RELAP.SimulationObjects.UnitOps.FuelRodDetails
    Public Property FuelRodDetails() As RELAP.SimulationObjects.UnitOps.FuelRodDetails
        Get
            Return m_FuelRodDetails
        End Get
        Set(ByVal value As RELAP.SimulationObjects.UnitOps.FuelRodDetails)
            m_FuelRodDetails = value
        End Set
    End Property




    Private Sub ucFuelRodEditor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If dgvFuelRodDimensions.RowCount = 0 Then
            For i = 1 To My.Application.ActiveSimulation.FormGeneralCoreInput.txtAxialNodes.Value
                dgvFuelRodDimensions.Rows.Add(i.ToString)
            Next
        End If
    End Sub

    Dim selectedcells As New List(Of Object)
    Dim selectedcells2 As New List(Of Object)



    Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If e.TabPageIndex = 3 Then
            Dim total As Integer
            dgvInitialTemperatures.Columns.Clear()
            dgvInitialTemperatures.Columns.Add("lblAxialNode_InitialTemp", "Axial Node")
            Try
                total = dgvRadialMeshSpacing.Rows(0).Cells(1).Value + dgvRadialMeshSpacing.Rows(0).Cells(2).Value + dgvRadialMeshSpacing.Rows(0).Cells(1).Value + 1
            Catch ex As Exception
                total = 0
            End Try

            For i As Integer = 0 To total
                dgvInitialTemperatures.Columns.Add("txtRadialNode" & i + 1, "Radial Node " & i + 1)
            Next

        End If
        cboControlVolumeAbove.DisplayMember = "Tag"
        cboControlVolumeBelow.DisplayMember = "Tag"
        cboComponent.DisplayMember = "Tag"
        
        Try
            cboComponent.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
            cboControlVolumeAbove.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)
            cboControlVolumeBelow.DataSource = New BindingSource(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.drawingObjects, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim obj = My.Application.ActiveSimulation.Collections.CLCS_FuelRodCollection(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject.Name)
        obj.ControlVolumeAbove = cboControlVolumeAbove.SelectedItem.value & txtVolumeAbove.Text.ToString("D2") & "0000"
        obj.ControlVolumeBelow = cboControlVolumeBelow.SelectedItem.value & txtVolumebelow.Text.ToString("D2") & "0000"
        

        If Not Me.FuelRodDetails Is Nothing Then
            Me.FuelRodDetails.FuelRodDimensions.Clear()
        End If

        For Each row As DataGridViewRow In Me.dgvFuelRodDimensions.Rows
            Me.FuelRodDetails.FuelRodDimensions.Add(row.Index + 1, New FuelRodDimensions(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(0).Value))
        Next
        For Each row As DataGridViewRow In Me.dgvHyrdraulicVolumes.Rows
            Me.FuelRodDetails.HyrdraulicVolumes.Add(row.Index + 1, New HydraulicVolumes(RELAP.App.GetUIDFromTag(row.Cells(0).Value) & row.Cells(1).Value.ToString("D2") & "0000", row.Cells(2).Value, row.Cells(3).Value))
        Next
        For Each row As DataGridViewRow In Me.dgvRadialMeshSpacing.Rows
            Me.FuelRodDetails.RadialMeshSpacing.Add(row.Index + 1, New RadialMeshSpacing(row.Cells(0).Value, row.Cells(2).Value, row.Cells(1).Value, row.Cells(3).Value))
        Next
        For Each row As DataGridViewRow In Me.dgvInitialTemperatures.Rows
            Dim str As String = ""
            For Each cell As DataGridViewCell In row.Cells
                str = cell.Value & " " & str
            Next
            Me.FuelRodDetails.InitialTemperatures.Add(row.Index + 1, str)
        Next
        obj.MaterialIndexNearCenter = cboMaterial1.SelectedItem.value
        obj.MaterialIndexNextToCenter = cboMaterial2.SelectedItem.value
        obj.MaterialIndexNthLayer = cboMaterial3.SelectedItem.value
        For Each row As DataGridViewRow In Me.dgvAxialPowerfactor.Rows
            FuelRodDetails.AxialPowerFactor.Add(row.Index + 1, row.Cells(0).Value)
        Next
        For Each row As DataGridViewRow In Me.dgvRadialPowerProfile.Rows
            FuelRodDetails.RadialPowerProfile.Add(row.Index + 1, New RadialPowerProfile(row.Cells(0).Value, row.Cells(1).Value))
        Next

        For Each row As DataGridViewRow In Me.dgvPowerHistory.Rows
            FuelRodDetails.PreviousPowerHistory.Add(row.Index + 1, New PreviousPowerHistory(row.Cells(0).Value, row.Cells(1).Value))
        Next
    End Sub

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click
        If dgvFuelRodDimensions.SelectedRows.Count = 1 Then
            selectedcells.Clear()
            For Each cell As DataGridViewCell In dgvFuelRodDimensions.SelectedRows(0).Cells
                selectedcells.Add(cell.Value)
            Next

        End If
    End Sub

    Private Sub cmdPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPaste.Click
        For Each row As DataGridViewRow In dgvFuelRodDimensions.SelectedRows
            Dim i = 0
            For i = 1 To row.Cells.Count - 1
                row.Cells(i).Value = selectedcells(i)
            Next

        Next
    End Sub

    Private Sub cmdCopytoAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopytoAll.Click
        If dgvFuelRodDimensions.SelectedRows.Count = 1 Then
            selectedcells.Clear()
            For Each cell As DataGridViewCell In dgvFuelRodDimensions.SelectedRows(0).Cells
                selectedcells.Add(cell.Value)
            Next

        End If
        For Each row As DataGridViewRow In dgvFuelRodDimensions.Rows
            Dim i = 0
            For i = 1 To row.Cells.Count - 1
                row.Cells(i).Value = selectedcells(i)
            Next


        Next
    End Sub

    Private Sub dgvFuelRodDimensions_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvFuelRodDimensions.RowHeaderMouseClick
        If dgvFuelRodDimensions.SelectedRows.Count = 1 Then
            cmdCopy.Enabled = True
            cmdCopytoAll.Enabled = True
        Else
            cmdCopy.Enabled = False
            cmdCopytoAll.Enabled = False
        End If
        If dgvFuelRodDimensions.SelectedRows.Count > 0 Then
            cmdPaste.Enabled = True
        Else
            cmdPaste.Enabled = True
        End If
    End Sub
End Class



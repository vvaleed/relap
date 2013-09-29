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
        cboMaterial1.SelectedIndex = 5
        cboMaterial2.SelectedIndex = 8
        cboMaterial3.SelectedIndex = 0


        Dim gobj As Microsoft.Msdn.Samples.GraphicObjects.FuelRodGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject

        Dim myFuelRod As RELAP.SimulationObjects.UnitOps.FuelRod = My.Application.ActiveSimulation.Collections.CLCS_FuelRodCollection(gobj.Name)

        If myFuelRod.FuelRodDetails.FuelRodDimensions.Count <> 0 Then
            cboControlVolumeAbove.SelectedText = RELAP.App.GetTagFromUID(myFuelRod.ControlVolumeAbove.Substring(0, 3))
            cboControlVolumeBelow.SelectedText = RELAP.App.GetTagFromUID(myFuelRod.ControlVolumeBelow.Substring(0, 3))
            txtVolumeAbove.Value = myFuelRod.ControlVolumeAbove.Substring(3, 2)
            txtVolumebelow.Value = myFuelRod.ControlVolumeBelow.Substring(3, 2)

            dgvFuelRodDimensions.Rows.Add(myFuelRod.FuelRodDetails.FuelRodDimensions.Count)
            For Each row As DataGridViewRow In Me.dgvFuelRodDimensions.Rows
                row.Cells(0).Value = myFuelRod.FuelRodDetails.FuelRodDimensions(row.Index + 1).FuelRodDimensionsAxialNode
                row.Cells(1).Value = myFuelRod.FuelRodDetails.FuelRodDimensions(row.Index + 1).FuelPelletRadius
                row.Cells(2).Value = myFuelRod.FuelRodDetails.FuelRodDimensions(row.Index + 1).InnerCladdingRadius
                row.Cells(3).Value = myFuelRod.FuelRodDetails.FuelRodDimensions(row.Index + 1).OuterCladdingRadius
            Next
            If myFuelRod.FuelRodDetails.HyrdraulicVolumes.Count <> 0 Then
                dgvHyrdraulicVolumes.Rows.Add(myFuelRod.FuelRodDetails.HyrdraulicVolumes.Count)
                For Each row As DataGridViewRow In Me.dgvHyrdraulicVolumes.Rows
                    row.Cells(0).Value = RELAP.App.GetUIDFromTag(myFuelRod.FuelRodDetails.HyrdraulicVolumes(row.Index + 1).ControlVolumeNumber.ToString.Substring(0, 3))
                    row.Cells(1).Value = RELAP.App.GetUIDFromTag(myFuelRod.FuelRodDetails.HyrdraulicVolumes(row.Index + 1).ControlVolumeNumber.ToString.Substring(3, 2))
                    row.Cells(2).Value = myFuelRod.FuelRodDetails.HyrdraulicVolumes(row.Index + 1).Increment
                    row.Cells(3).Value = myFuelRod.FuelRodDetails.HyrdraulicVolumes(row.Index + 1).AxialNode

                Next
            End If
            If myFuelRod.FuelRodDetails.RadialMeshSpacing.Count <> 0 Then
                dgvRadialMeshSpacing.Rows.Add(myFuelRod.FuelRodDetails.RadialMeshSpacing.Count)
                For Each row As DataGridViewRow In Me.dgvRadialMeshSpacing.Rows
                    row.Cells(0).Value = myFuelRod.FuelRodDetails.RadialMeshSpacing(row.Index + 1).NumberofIntervalsAcrossFuel
                    row.Cells(1).Value = myFuelRod.FuelRodDetails.RadialMeshSpacing(row.Index + 1).NumberofIntervalsAcrossGap
                    row.Cells(2).Value = myFuelRod.FuelRodDetails.RadialMeshSpacing(row.Index + 1).NumberofIntervalsAcrossCladding
                    row.Cells(3).Value = myFuelRod.FuelRodDetails.RadialMeshSpacing(row.Index + 1).AxialNode
                Next
            End If
            If myFuelRod.FuelRodDetails.InitialTemperatures.Count <> 0 Then
                Dim total As Integer
                dgvInitialTemperatures.Columns.Clear()
                dgvInitialTemperatures.Columns.Add("lblAxialNode_InitialTemp", "Axial Node")
                Try
                    total = Val(dgvRadialMeshSpacing.Rows(0).Cells(1).Value) + Val(dgvRadialMeshSpacing.Rows(0).Cells(2).Value) + Val(dgvRadialMeshSpacing.Rows(0).Cells(2).Value) + 1
                Catch ex As Exception
                    total = 0
                End Try

                For i As Integer = 1 To total
                    dgvInitialTemperatures.Columns.Add("txtRadialNode" & i, "Radial Node " & i)
                Next
                For i = 1 To My.Application.ActiveSimulation.FormGeneralCoreInput.txtAxialNodes.Value
                    dgvInitialTemperatures.Rows.Add(i.ToString)
                Next
                For Each row As DataGridViewRow In Me.dgvInitialTemperatures.Rows
                    Dim str As String() = myFuelRod.FuelRodDetails.InitialTemperatures(row.Index + 1).Split(" ")
                    For Each cell As DataGridViewCell In row.Cells
                        cell.Value = str(cell.ColumnIndex + 1)
                    Next
                Next
            End If
            cboMaterial1.SelectedText = myFuelRod.MaterialIndexNearCenter
            cboMaterial2.SelectedText = myFuelRod.MaterialIndexNextToCenter
            cboMaterial3.SelectedText = myFuelRod.MaterialIndexNthLayer
            If myFuelRod.FuelRodDetails.AxialPowerFactor.Count <> 0 Then
                dgvAxialPowerfactor.Rows.Add(myFuelRod.FuelRodDetails.AxialPowerFactor.Count)
                For Each row As DataGridViewRow In Me.dgvAxialPowerfactor.Rows
                    row.Cells(0).Value = myFuelRod.FuelRodDetails.AxialPowerFactor(row.Index + 1)
                Next
            End If
            If myFuelRod.FuelRodDetails.RadialPowerProfile.Count <> 0 Then


                dgvRadialPowerProfile.Rows.Add(myFuelRod.FuelRodDetails.RadialPowerProfile.Count)
                For Each row As DataGridViewRow In Me.dgvRadialPowerProfile.Rows

                    row.Cells(0).Value = myFuelRod.FuelRodDetails.RadialPowerProfile(row.Index + 1).RadialPowerFactor
                    row.Cells(1).Value = myFuelRod.FuelRodDetails.RadialPowerProfile(row.Index + 1).RadialNode
                Next
            End If
            If myFuelRod.FuelRodDetails.PreviousPowerHistory.Count <> 0 Then


                dgvPowerHistory.Rows.Add(myFuelRod.FuelRodDetails.PreviousPowerHistory.Count)
                For Each row As DataGridViewRow In Me.dgvPowerHistory.Rows
                    row.Cells(0).Value = myFuelRod.FuelRodDetails.PreviousPowerHistory(row.Index + 1).PowerHistory
                    row.Cells(1).Value = myFuelRod.FuelRodDetails.PreviousPowerHistory(row.Index + 1).Time
                Next
            End If
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
                total = Val(dgvRadialMeshSpacing.Rows(0).Cells(1).Value) + Val(dgvRadialMeshSpacing.Rows(0).Cells(2).Value) + Val(dgvRadialMeshSpacing.Rows(0).Cells(2).Value) + 1
            Catch ex As Exception
                total = 0
            End Try

            For i As Integer = 1 To total
                dgvInitialTemperatures.Columns.Add("txtRadialNode" & i, "Radial Node " & i)
            Next
            For i = 1 To My.Application.ActiveSimulation.FormGeneralCoreInput.txtAxialNodes.Value
                dgvInitialTemperatures.Rows.Add(i.ToString)

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
        obj.ControlVolumeAbove = RELAP.App.GetUIDFromTag(cboControlVolumeAbove.SelectedItem.Tag) & txtVolumeAbove.Value.ToString("D2") & "0000"
        obj.ControlVolumeBelow = RELAP.App.GetUIDFromTag(cboControlVolumeBelow.SelectedItem.Tag) & txtVolumebelow.Value.ToString("D2") & "0000"


        If Not Me.FuelRodDetails Is Nothing Then
            Me.FuelRodDetails.FuelRodDimensions.Clear()
            Me.FuelRodDetails.HyrdraulicVolumes.Clear()
            Me.FuelRodDetails.AxialPowerFactor.Clear()
            Me.FuelRodDetails.InitialTemperatures.Clear()
            Me.FuelRodDetails.RadialMeshSpacing.Clear()
            Me.FuelRodDetails.PreviousPowerHistory.Clear()
            Me.FuelRodDetails.RadialPowerProfile.Clear()
        End If

        For Each row As DataGridViewRow In Me.dgvFuelRodDimensions.Rows
            If Not row.Cells(0).Value Is Nothing Then
                Me.FuelRodDetails.FuelRodDimensions.Add(row.Index + 1, New FuelRodDimensions(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(0).Value))
            End If
        Next
        For Each row As DataGridViewRow In Me.dgvHyrdraulicVolumes.Rows
            If Not row.Cells(0).Value Is Nothing Then
                Dim tmpint As Integer
                Dim tmpstr As String
                tmpint = row.Cells(1).Value
                tmpstr = tmpint.ToString("D2")

                Me.FuelRodDetails.HyrdraulicVolumes.Add(row.Index + 1, New HydraulicVolumes(RELAP.App.GetUIDFromTag(row.Cells(0).Value) & tmpstr & "0000", row.Cells(2).Value, row.Cells(3).Value))
            End If
        Next
        For Each row As DataGridViewRow In Me.dgvRadialMeshSpacing.Rows
            If Not row.Cells(0).Value Is Nothing Then
                Me.FuelRodDetails.RadialMeshSpacing.Add(row.Index + 1, New RadialMeshSpacing(row.Cells(0).Value, row.Cells(2).Value, row.Cells(1).Value, row.Cells(3).Value))
            End If
        Next
        For Each row As DataGridViewRow In Me.dgvInitialTemperatures.Rows
            If Not row.Cells(0).Value Is Nothing Then
                Dim str As String = ""
                For Each cell As DataGridViewCell In row.Cells
                    str = cell.Value & " " & str
                Next
                Me.FuelRodDetails.InitialTemperatures.Add(row.Index + 1, str)
            End If
        Next
        obj.MaterialIndexNearCenter = cboMaterial1.SelectedItem.value
        obj.MaterialIndexNextToCenter = cboMaterial2.SelectedItem.value
        obj.MaterialIndexNthLayer = cboMaterial3.SelectedItem.value
        For Each row As DataGridViewRow In Me.dgvAxialPowerfactor.Rows
            If Not row.Cells(0).Value Is Nothing Then
                FuelRodDetails.AxialPowerFactor.Add(row.Index + 1, row.Cells(0).Value)
            End If
        Next
        For Each row As DataGridViewRow In Me.dgvRadialPowerProfile.Rows
            If Not row.Cells(0).Value Is Nothing Then
                FuelRodDetails.RadialPowerProfile.Add(row.Index + 1, New RadialPowerProfile(row.Cells(0).Value, row.Cells(1).Value))
            End If
        Next

        For Each row As DataGridViewRow In Me.dgvPowerHistory.Rows
            If Not row.Cells(0).Value Is Nothing Then
                FuelRodDetails.PreviousPowerHistory.Add(row.Index + 1, New PreviousPowerHistory(row.Cells(0).Value, row.Cells(1).Value))
            End If
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

    Private Sub dgvFuelRodDimensions_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFuelRodDimensions.CellClick
        cmdCopy.Enabled = False
        cmdPaste.Enabled = False
        cmdCopytoAll.Enabled = False
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

    Private Sub cmdCopy2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy2.Click
        If dgvInitialTemperatures.SelectedRows.Count = 1 Then
            selectedcells.Clear()
            For Each cell As DataGridViewCell In dgvInitialTemperatures.SelectedRows(0).Cells
                selectedcells.Add(cell.Value)
            Next

        End If
    End Sub

    Private Sub cmdCopytoAll2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopytoAll2.Click
        If dgvInitialTemperatures.SelectedRows.Count = 1 Then
            selectedcells.Clear()
            For Each cell As DataGridViewCell In dgvInitialTemperatures.SelectedRows(0).Cells
                selectedcells.Add(cell.Value)
            Next

        End If
        For Each row As DataGridViewRow In dgvInitialTemperatures.Rows
            Dim i = 0
            For i = 1 To row.Cells.Count - 1
                row.Cells(i).Value = selectedcells(i)
            Next
        Next
    End Sub

    Private Sub cmdPaste2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPaste2.Click
        For Each row As DataGridViewRow In dgvInitialTemperatures.SelectedRows
            Dim i = 0
            For i = 1 To row.Cells.Count - 1
                row.Cells(i).Value = selectedcells(i)
            Next
        Next
    End Sub

    Private Sub dgvInitialTemperatures_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInitialTemperatures.CellClick
        cmdCopy2.Enabled = False
        cmdPaste2.Enabled = False
        cmdCopytoAll2.Enabled = False
    End Sub

    Private Sub dgvInitialTemperatures_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvInitialTemperatures.RowHeaderMouseClick
        If dgvInitialTemperatures.SelectedRows.Count = 1 Then
            cmdCopy2.Enabled = True
            cmdCopytoAll2.Enabled = True
        Else
            cmdCopy2.Enabled = False
            cmdCopytoAll2.Enabled = False
        End If
        If dgvInitialTemperatures.SelectedRows.Count > 0 Then
            cmdPaste2.Enabled = True
        Else
            cmdPaste2.Enabled = True
        End If
    End Sub
End Class



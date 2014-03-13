Imports RELAP.RELAP.SimulationObjects.UnitOps

Public Class ucControlRodEditor


    Private m_ControlRodDetails As RELAP.SimulationObjects.UnitOps.ControlRodDetails
    Public Property ControlRodDetails() As RELAP.SimulationObjects.UnitOps.ControlRodDetails
        Get
            Return m_ControlRodDetails
        End Get
        Set(ByVal value As RELAP.SimulationObjects.UnitOps.ControlRodDetails)
            m_ControlRodDetails = value
        End Set
    End Property




    Private Sub ucControlRodEditor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


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

        Dim gobj As Microsoft.Msdn.Samples.GraphicObjects.PWRControlRodGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myControlRod As RELAP.SimulationObjects.UnitOps.PWRControlRod = My.Application.ActiveSimulation.Collections.CLCS_PWRControlRodCollection(gobj.Name)

        If myControlRod.ControlRodDetails.ControlRodDimensions.Count <> 0 Then
            cboControlVolumeAbove.SelectedText = RELAP.App.GetTagFromUID(myControlRod.VolumeAbove.Substring(0, 3))
            cboControlVolumeBelow.SelectedText = RELAP.App.GetTagFromUID(myControlRod.VolumeBelow.Substring(0, 3))
            txtVolumeAbove.Value = myControlRod.VolumeAbove.Substring(3, 2)
            txtVolumebelow.Value = myControlRod.VolumeBelow.Substring(3, 2)
            dgvFuelRodDimensions.Rows.Add(myControlRod.ControlRodDetails.ControlRodDimensions.Count)
            For Each row As DataGridViewRow In Me.dgvFuelRodDimensions.Rows
                row.Cells(0).Value = myControlRod.ControlRodDetails.ControlRodDimensions(row.Index + 1).AxialNode
                row.Cells(1).Value = myControlRod.ControlRodDetails.ControlRodDimensions(row.Index + 1).OuterRadiusofControlRodAbsorber
                row.Cells(2).Value = myControlRod.ControlRodDetails.ControlRodDimensions(row.Index + 1).OuterRadiusofSS
                row.Cells(3).Value = myControlRod.ControlRodDetails.ControlRodDimensions(row.Index + 1).InnerofZr
                row.Cells(4).Value = myControlRod.ControlRodDetails.ControlRodDimensions(row.Index + 1).OuterofZr

            Next
            If myControlRod.ControlRodDetails.HyrdraulicVolumes.Count <> 0 Then
                dgvHyrdraulicVolumes.Rows.Add(myControlRod.ControlRodDetails.HyrdraulicVolumes.Count)
                For Each row As DataGridViewRow In Me.dgvHyrdraulicVolumes.Rows
                    If row.Index < myControlRod.ControlRodDetails.HyrdraulicVolumes.Count Then
                        Dim CBox As DataGridViewComboBoxCell = CType(row.Cells(0), DataGridViewComboBoxCell)
                        CBox.Value = RELAP.App.GetTagFromUID(myControlRod.ControlRodDetails.HyrdraulicVolumes(row.Index + 1).ControlVolumeNumber.ToString.Substring(0, 3))
                        row.Cells(0).Value = CBox.Value
                        row.Cells(1).Value = (myControlRod.ControlRodDetails.HyrdraulicVolumes(row.Index + 1).ControlVolumeNumber.ToString.Substring(3, 2))
                        row.Cells(2).Value = myControlRod.ControlRodDetails.HyrdraulicVolumes(row.Index + 1).Increment
                        row.Cells(3).Value = myControlRod.ControlRodDetails.HyrdraulicVolumes(row.Index + 1).AxialNode
                    End If
                Next
            End If
            If myControlRod.ControlRodDetails.RadialMeshSpacing.Count <> 0 Then
                dgvRadialMeshSpacing.Rows.Add(myControlRod.ControlRodDetails.RadialMeshSpacing.Count)
                For Each row As DataGridViewRow In Me.dgvRadialMeshSpacing.Rows
                    If row.Index < myControlRod.ControlRodDetails.RadialMeshSpacing.Count Then
                        row.Cells(0).Value = myControlRod.ControlRodDetails.RadialMeshSpacing(row.Index + 1).NumberofIntervalsAcrossFuel
                        row.Cells(1).Value = myControlRod.ControlRodDetails.RadialMeshSpacing(row.Index + 1).NumberofIntervalsAcrossGap
                        row.Cells(2).Value = myControlRod.ControlRodDetails.RadialMeshSpacing(row.Index + 1).NumberofIntervalsAcrossCladding
                        row.Cells(3).Value = myControlRod.ControlRodDetails.RadialMeshSpacing(row.Index + 1).AxialNode
                    End If
                Next
            End If
            If myControlRod.ControlRodDetails.InitialTemperatures.Count <> 0 Then
                Dim total As Integer
                dgvInitialTemperatures.Columns.Clear()
                dgvInitialTemperatures.Columns.Add("lblAxialNode_InitialTemp", "Axial Node")
                Try
                    total = Val(dgvRadialMeshSpacing.Rows(0).Cells(0).Value) + Val(dgvRadialMeshSpacing.Rows(0).Cells(1).Value) + Val(dgvRadialMeshSpacing.Rows(0).Cells(2).Value) + 1
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
                    If row.Index < myControlRod.ControlRodDetails.InitialTemperatures.Count Then
                        Dim str As String() = myControlRod.ControlRodDetails.InitialTemperatures(row.Index + 1).Split(" ")
                        For Each cell As DataGridViewCell In row.Cells
                            If cell.ColumnIndex <> 0 Then
                                cell.Value = str(row.Cells.Count - cell.ColumnIndex - 1)
                            End If
                        Next
                    End If
                Next
            End If



        Else
            If dgvFuelRodDimensions.RowCount = 0 Then
                For i = 1 To My.Application.ActiveSimulation.FormGeneralCoreInput.txtAxialNodes.Value
                    dgvFuelRodDimensions.Rows.Add(i.ToString)
                Next
            End If
        End If
    End Sub

    Dim selectedcells As New List(Of Object)
    Dim selectedcells2 As New List(Of Object)



    Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If e.TabPageIndex = 3 And dgvInitialTemperatures.Rows.Count = 0 Then
            Dim total As Integer
            dgvInitialTemperatures.Columns.Clear()
            dgvInitialTemperatures.Columns.Add("lblAxialNode_InitialTemp", "Axial Node")
            Try
                total = Val(dgvRadialMeshSpacing.Rows(0).Cells(0).Value) + Val(dgvRadialMeshSpacing.Rows(0).Cells(1).Value) + Val(dgvRadialMeshSpacing.Rows(0).Cells(2).Value) + 1
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


        If Not Me.ControlRodDetails Is Nothing Then
            Me.ControlRodDetails.ControlRodDimensions.Clear()
            Me.ControlRodDetails.HyrdraulicVolumes.Clear()
            Me.ControlRodDetails.AxialPowerFactor.Clear()
            Me.ControlRodDetails.InitialTemperatures.Clear()
            Me.ControlRodDetails.RadialMeshSpacing.Clear()
        End If

        For Each row As DataGridViewRow In Me.dgvFuelRodDimensions.Rows
            If Not row.Cells(0).Value Is Nothing Then
                Me.ControlRodDetails.ControlRodDimensions.Add(row.Index + 1, New Geometry(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(0).Value))
            End If
        Next
        For Each row As DataGridViewRow In Me.dgvHyrdraulicVolumes.Rows
            If Not row.Cells(0).Value Is Nothing Then
                Dim tmpint As Integer
                Dim tmpstr As String
                tmpint = row.Cells(1).Value
                tmpstr = tmpint.ToString("D2")

                Me.ControlRodDetails.HyrdraulicVolumes.Add(row.Index + 1, New HydraulicVolumes(RELAP.App.GetUIDFromTag(row.Cells(0).Value) & tmpstr & "0000", row.Cells(2).Value, row.Cells(3).Value))
            End If
        Next
        For Each row As DataGridViewRow In Me.dgvRadialMeshSpacing.Rows
            If Not row.Cells(0).Value Is Nothing Then
                Me.ControlRodDetails.RadialMeshSpacing.Add(row.Index + 1, New RadialMeshSpacing(row.Cells(0).Value, row.Cells(2).Value, row.Cells(1).Value, row.Cells(3).Value))
            End If
        Next
        For Each row As DataGridViewRow In Me.dgvInitialTemperatures.Rows
            If Not row.Cells(0).Value Is Nothing Then
                Dim str As String = ""
                For Each cell As DataGridViewCell In row.Cells
                    str = cell.Value & " " & str
                Next
                Me.ControlRodDetails.InitialTemperatures.Add(row.Index + 1, str)
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




Public Class ucFuelRodEditor
   
    Private _us As RELAP.SistemasDeUnidades.Unidades

    Public Property SystemOfUnits() As RELAP.SistemasDeUnidades.Unidades
        Get
            Return _us
        End Get
        Set(ByVal value As RELAP.SistemasDeUnidades.Unidades)
            _us = value
        End Set
    End Property

    Private _nf As String

    Public Property NumberFormat() As String
        Get
            Return _nf
        End Get
        Set(ByVal value As String)
            _nf = value
        End Set
    End Property

    Private Sub ucPipeEditor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If dgvFuelRodDimensions.RowCount = 0 Then
            dgvFuelRodDimensions.Rows.Add(My.Application.ActiveSimulation.FormGeneralCoreInput.txtAxialNodes.Value)
        End If
    End Sub

    Dim selectedcells As New List(Of Object)  
    Dim selectedcells2 As New List(Of Object)
 


    Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        If e.TabPageIndex = 2 Then
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
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim obj = My.Application.ActiveSimulation.Collections.CLCS_FuelRodCollection(My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject.Name)
        obj.ControlVolumeAbove = cboControlVolumeAbove.SelectedValue & txtVolumeAbove.Text.ToString("D2") & "0000"
        obj.ControlVolumeBelow = cboControlVolumeBelow.SelectedValue & txtVolumebelow.Text.ToString("D2") & "0000"


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
End Class



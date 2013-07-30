Public Class ucHeatStructureEditor
    Private _HeatStructureMeshData As HeatStructureMeshData
    Public Property HeatStructureMeshData() As HeatStructureMeshData
        Get
            Return _HeatStructureMeshData
        End Get
        Set(ByVal value As HeatStructureMeshData)
            _HeatStructureMeshData = value
        End Set
    End Property
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

   
    
    Private Sub ucHeatStructureEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim gobj As Microsoft.Msdn.Samples.GraphicObjects.HeatStructureGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myCOTK As RELAP.SimulationObjects.UnitOps.HeatStructure = My.Application.ActiveSimulation.Collections.CLCS_HeatStructureCollection(gobj.Name)

        chkboxmeshgeometry.Checked = True

        If myCOTK.HeatStructureMeshData.MeshDataFormat1.Count <> 0 Then

        End If
    End Sub

    Private Sub chkboxmeshgeometry_CheckStateChanged(sender As Object, e As EventArgs) Handles chkboxmeshgeometry.CheckStateChanged
        Try
            If chkboxmeshgeometry.Checked = False Then
                CmbBoxSelectFormat.Hide()

                dgvformat1.Hide()
                dgvformat1.Rows.Clear()

                dgvformat2.Hide()
                dgvformat2.Rows.Clear()

                dgvNoDecay.Hide()
                dgvNoDecay.Rows.Clear()

                dgvWithDecay.Hide()
                dgvWithDecay.Rows.Clear()

                dgvComposition.Hide()
                dgvComposition.Rows.Clear()

                TextBox1.Hide()
                TextBox2.Hide()
                TextBox4.Hide()
                txtboxDecayHeat.Hide()


            ElseIf chkboxmeshgeometry.Checked = True Then
                CmbBoxSelectFormat.Show()
                dgvformat1.Show()
                dgvformat2.Show()
                dgvNoDecay.Show()
                dgvWithDecay.Show()
                dgvComposition.Show()
                TextBox1.Show()
                TextBox2.Show()
                TextBox4.Show()
                txtboxDecayHeat.Show()


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbBoxSelectFormat_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbBoxSelectFormat.SelectedValueChanged
        If CmbBoxSelectFormat.SelectedIndex = 0 Then
            dgvformat1.Show()
            dgvformat2.Rows.Clear()
            dgvformat2.Hide()

        ElseIf CmbBoxSelectFormat.SelectedIndex = 1 Then
            dgvformat1.Rows.Clear()
            dgvformat1.Hide()
            dgvformat2.Show()
        End If
    End Sub

    Private Sub txtboxDecayHeat_TextChanged(sender As Object, e As EventArgs) Handles txtboxDecayHeat.TextChanged
        If txtboxDecayHeat.Text = "" Then
            dgvNoDecay.Show()
            dgvWithDecay.Hide()
            dgvWithDecay.Rows.Clear()
        ElseIf txtboxDecayHeat.Text = "0" Then
            dgvNoDecay.Show()
            dgvWithDecay.Hide()
            dgvWithDecay.Rows.Clear()
        Else
            dgvNoDecay.Hide()
            dgvNoDecay.Rows.Clear()
            dgvWithDecay.Show()

        End If
    End Sub



    Private Sub cmdsave_Click(sender As Object, e As EventArgs) Handles cmdsave.Click

    End Sub
End Class


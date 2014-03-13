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

        ComboBoxTemp.SelectedIndex = 0
        dgvNoDecay.Show()
        dgvWithDecay.Hide()
        ChkBoxInitialTemp.Checked = True
        dgvformat1.Show()
        dgvformat2.Hide()

        If myCOTK.HeatStructureMeshData.MeshDataFormat1.Count = 0 Then
            dgvformat1.Rows.Add(1)
            dgvformat1.Rows(0).Cells(0).Value = myCOTK.NumberOfRadialMP - 1
            dgvformat1.Rows(0).Cells(1).Value = 1.5
        Else
            dgvformat1.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataFormat1.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataFormat1.Count
                Dim row As DataGridViewRow = dgvformat1.Rows(i - 1)
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataFormat1(i).NumberOfIntervals
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataFormat1(i).RightCoordinate
            Next
        End If

        If myCOTK.HeatStructureMeshData.MeshDataFormat2.Count = 0 Then
            dgvformat2.Rows.Add(1)
            dgvformat2.Rows(0).Cells(0).Value = 0
            dgvformat2.Rows(0).Cells(1).Value = myCOTK.NumberOfRadialMP - 1
        Else
            dgvformat2.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataFormat2.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataFormat2.Count
                Dim row As DataGridViewRow = dgvformat2.Rows(i - 1)
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataFormat2(i).MeshInterval
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataFormat2(i).IntervalNumber
            Next
        End If

        If myCOTK.HeatStructureMeshData.MeshDataNoDecay.Count = 0 Then
            dgvNoDecay.Rows.Add(1)
            dgvNoDecay.Rows(0).Cells(0).Value = 0.0
            dgvNoDecay.Rows(0).Cells(1).Value = myCOTK.NumberOfRadialMP - 1
        Else
            dgvNoDecay.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataNoDecay.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataNoDecay.Count
                Dim row As DataGridViewRow = dgvNoDecay.Rows(i - 1)
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataNoDecay(i).SourceValue
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataNoDecay(i).MeshIntervalNumber
            Next
        End If

        If myCOTK.HeatStructureMeshData.MeshDataWithDecay.Count = 0 Then
            dgvWithDecay.Rows.Add(1)
            dgvWithDecay.Rows(0).Cells(0).Value = 0.0
            dgvWithDecay.Rows(0).Cells(1).Value = myCOTK.NumberOfRadialMP - 1
        Else
            dgvWithDecay.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataWithDecay.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataWithDecay.Count
                Dim row As DataGridViewRow = dgvWithDecay.Rows(i - 1)
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataWithDecay(i).GammaAttenuationCo
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataWithDecay(i).MeshIntervalNumber2
            Next
        End If

        If myCOTK.HeatStructureMeshData.MeshDataComposition.Count = 0 Then
            'dgvComposition.Rows.Add(1)
            'dgvComposition.Rows(0).Cells(0).Value = 0.0
            'dgvComposition.Rows(0).Cells(1).Value = 0.0
        Else
            dgvComposition.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataComposition.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataComposition.Count
                Dim row As DataGridViewRow = dgvComposition.Rows(i - 1)
                dgvComposition.Show()
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataComposition(i).CompositionNumber
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataComposition(i).MeshIntervalNumber3
            Next
        End If

        If myCOTK.HeatStructureMeshData.MeshDataComposition2.Count = 0 Then
            'dgvComposition2.Rows.Add(1)
            'dgvComposition2.Rows(0).Cells(0).Value = 0.0
            'dgvComposition2.Rows(0).Cells(1).Value = 0.0
        Else
            dgvComposition2.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataComposition2.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataComposition2.Count
                Dim row As DataGridViewRow = dgvComposition2.Rows(i - 1)
                dgvComposition2.Show()
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataComposition2(i).CompositionNumber2
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataComposition2(i).MeshIntervalNumber4
            Next
        End If

        If myCOTK.HeatStructureMeshData.MeshDataComposition3.Count = 0 Then
            'dgvComposition3.Rows.Add(1)
            'dgvComposition3.Rows(0).Cells(0).Value = 0.0
            'dgvComposition3.Rows(0).Cells(1).Value = 0.0
        Else
            dgvComposition3.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataComposition3.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataComposition3.Count
                Dim row As DataGridViewRow = dgvComposition3.Rows(i - 1)
                dgvComposition3.Show()
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataComposition3(i).CompositionNumber3
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataComposition3(i).MeshIntervalNumber33
            Next
        End If

        If myCOTK.HeatStructureMeshData.MeshDataComposition4.Count = 0 Then
            'dgvComposition4.Rows.Add(1)
            'dgvComposition4.Rows(0).Cells(0).Value = 0.0
            'dgvComposition4.Rows(0).Cells(1).Value = 0.0
        Else
            dgvComposition4.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataComposition4.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataComposition4.Count
                Dim row As DataGridViewRow = dgvComposition4.Rows(i - 1)
                dgvComposition4.Show()
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataComposition4(i).CompositionNumber4
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataComposition4(i).MeshIntervalNumber34
            Next
        End If

        If myCOTK.HeatStructureMeshData.MeshDataComposition5.Count = 0 Then
            'dgvComposition5.Rows.Add(1)
            'dgvComposition5.Rows(0).Cells(0).Value = 0.0
            'dgvComposition5.Rows(0).Cells(1).Value = 0.0
        Else
            dgvComposition5.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataComposition5.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataComposition5.Count
                Dim row As DataGridViewRow = dgvComposition5.Rows(i - 1)
                dgvComposition5.Show()
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataComposition5(i).CompositionNumber5
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataComposition5(i).MeshIntervalNumber35
            Next
        End If

        If myCOTK.HeatStructureMeshData.MeshDataComposition6.Count = 0 Then
            'dgvComposition6.Rows.Add(1)
            'dgvComposition6.Rows(0).Cells(0).Value = 0.0
            'dgvComposition6.Rows(0).Cells(1).Value = 0.0
        Else
            dgvComposition6.Rows.Add(myCOTK.HeatStructureMeshData.MeshDataComposition6.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.MeshDataComposition6.Count
                Dim row As DataGridViewRow = dgvComposition6.Rows(i - 1)
                dgvComposition6.Show()
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.MeshDataComposition6(i).CompositionNumber6
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.MeshDataComposition6(i).MeshIntervalNumber36
            Next
        End If
        If myCOTK.HeatStructureMeshData.GapDeformation.Count = 0 Then
            dgvGapDeformation.Rows.Add(1)
            dgvGapDeformation.Rows(0).Cells(0).Value = 0.0
            dgvGapDeformation.Rows(0).Cells(1).Value = 0.0
            dgvGapDeformation.Rows(0).Cells(2).Value = 0.0
            dgvGapDeformation.Rows(0).Cells(3).Value = 0.0
            dgvGapDeformation.Rows(0).Cells(4).Value = 0.0
        Else
            dgvGapDeformation.Rows.Add(myCOTK.HeatStructureMeshData.GapDeformation.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.GapDeformation.Count
                Dim row As DataGridViewRow = dgvGapDeformation.Rows(i - 1)
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.GapDeformation(i).FuelSurfaceRoughness
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.GapDeformation(i).CladdingSurfaceRoughness
                row.Cells(2).Value = myCOTK.HeatStructureMeshData.GapDeformation(i).RadialDisplacementFission
                row.Cells(3).Value = myCOTK.HeatStructureMeshData.GapDeformation(i).RadialDisplacementCladding
                row.Cells(4).Value = myCOTK.HeatStructureMeshData.GapDeformation(i).HSnumberGapDef
            Next
        End If

        If myCOTK.HeatStructureMeshData.Temp1.Count = 0 Then
            dgvTemp1.Rows.Add(1)
            dgvTemp1.Rows(0).Cells(0).Value = 50.0
            dgvTemp1.Rows(0).Cells(1).Value = myCOTK.NumberOfRadialMP
        Else
            dgvTemp1.Rows.Add(myCOTK.HeatStructureMeshData.Temp1.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.Temp1.Count
                Dim row As DataGridViewRow = dgvTemp1.Rows(i - 1)
                row.Cells(0).Value = myCOTK.HeatStructureMeshData.Temp1(i).Temp1Temperature
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.Temp1(i).Temp1MeshPointNumber
            Next
        End If
        If DgvMat.Rows.Count = 2 Then
            TextBox8.Show()
            TextBox9.Hide()
            TextBox10.Hide()
            dgvComposition.Show()
            dgvComposition2.Show()
            dgvComposition3.Hide()
            dgvComposition4.Hide()
            dgvComposition5.Hide()
            dgvComposition6.Hide()
        End If
        If DgvMat.Rows.Count = 3 Then
            TextBox9.Show()
            TextBox8.Show()
            TextBox10.Hide()
            dgvComposition3.Show()
            dgvComposition4.Show()
            dgvComposition.Show()
            dgvComposition2.Show()
            dgvComposition5.Hide()
            dgvComposition6.Hide()
        End If
        If DgvMat.Rows.Count = 4 Then
            TextBox10.Show()
            TextBox8.Show()
            TextBox9.Show()
            dgvComposition5.Show()
            dgvComposition6.Show()
            dgvComposition.Show()
            dgvComposition2.Show()
            dgvComposition3.Show()
            dgvComposition4.Show()
        End If

        If myCOTK.HeatStructureMeshData.proHSMat.Count = 0 Then
            TextBox8.Hide()
            TextBox9.Hide()
            TextBox10.Hide()
            dgvComposition.Hide()
            dgvComposition2.Hide()
            dgvComposition3.Hide()
            dgvComposition4.Hide()
            dgvComposition5.Hide()
            dgvComposition6.Hide()
            DgvMat.Rows.Add(1)
            DgvMat.Rows(0).Cells(1).Value = 1
            DgvMat.Rows(0).Cells(2).Value = True
            DgvMat.Rows(0).Cells(3).Value = False
            DgvMat.Rows(0).Cells(3).Value = myCOTK.NumberOfRadialMP - 1
        Else
            DgvMat.Rows.Add(myCOTK.HeatStructureMeshData.proHSMat.Count)
            Dim i = 1
            For i = 1 To myCOTK.HeatStructureMeshData.proHSMat.Count

                Dim row As DataGridViewRow = DgvMat.Rows(i - 1)
                Dim CBox As DataGridViewComboBoxCell = CType(row.Cells(0), DataGridViewComboBoxCell)
                CBox.Value = myCOTK.HeatStructureMeshData.proHSMat(i).CompositionMat
                row.Cells(0).Value = CBox.Value
                row.Cells(1).Value = myCOTK.HeatStructureMeshData.proHSMat(i).MaterialNumber
                row.Cells(2).Value = myCOTK.HeatStructureMeshData.proHSMat(i).RegionIncluded
                row.Cells(3).Value = myCOTK.HeatStructureMeshData.proHSMat(i).gapmodel
                row.Cells(3).Value = myCOTK.HeatStructureMeshData.proHSMat(i).HSnum
            Next
        End If
      


        

        If HeatStructureMeshData.MetalWaterReaction = False Then
            ChkboxMetalWaterReaction.Checked = False
            txtboxOxideThickness.Clear()
            txtboxOxideThickness.BackColor = Color.Gray
            txtboxOxideThickness.ReadOnly = True
        ElseIf HeatStructureMeshData.MetalWaterReaction = True Then
            ChkboxMetalWaterReaction.Checked = True
            txtboxOxideThickness.BackColor = Color.White
            txtboxOxideThickness.ReadOnly = False
            txtboxOxideThickness.Text = HeatStructureMeshData.InitialOxideThicknes
        End If

        If HeatStructureMeshData.EnterMeshGeometry = "1" Then
            chkboxmeshgeometry.Checked = False
            CmbBoxSelectFormat.Hide()
            dgvformat1.Hide()
            dgvformat1.Rows.Clear()
            dgvformat2.Hide()
            dgvformat2.Rows.Clear()
            dgvNoDecay.Hide()
            dgvNoDecay.Rows.Clear()
            dgvWithDecay.Hide()
            dgvWithDecay.Rows.Clear()
            TextBox1.Hide()
            TextBox2.Hide()
            txtboxDecayHeat.Hide()
        ElseIf HeatStructureMeshData.EnterMeshGeometry = "0" Then
            chkboxmeshgeometry.Checked = True
            CmbBoxSelectFormat.Show()
            dgvformat1.Show()
            dgvformat2.Show()
            dgvNoDecay.Show()
            dgvWithDecay.Show()
            TextBox1.Show()
            TextBox2.Show()
            txtboxDecayHeat.Show()
            txtboxDecayHeat.Text = HeatStructureMeshData.DecayHeat
        Else
            chkboxmeshgeometry.Checked = True
            CmbBoxSelectFormat.SelectedIndex = 0
            HeatStructureMeshData.SelectFormat = "1"
            dgvformat2.Hide()
            dgvWithDecay.Hide()
            dgvTemp2.Hide()
        End If

        If HeatStructureMeshData.SelectFormat = "1" Then
            CmbBoxSelectFormat.SelectedIndex = 0
            dgvformat1.Show()
            dgvformat2.Rows.Clear()
            dgvformat2.Hide()
        ElseIf HeatStructureMeshData.SelectFormat = "2" Then
            CmbBoxSelectFormat.SelectedIndex = 1
            dgvformat1.Rows.Clear()
            dgvformat1.Hide()
            dgvformat2.Show()
        Else
            CmbBoxSelectFormat.SelectedIndex = 0
            dgvformat1.Hide()
            dgvformat2.Hide()
        End If

    End Sub

    Private Sub ChkboxGapConductance_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ChkboxGapConductance.CheckStateChanged
        If ChkboxGapConductance.Checked = False Then
            HeatStructureMeshData.GapConductanceModel = False
            txtboxInitialGapInternalPressure.Clear()
            txtboxInitialGapInternalPressure.BackColor = Color.Gray
            txtboxInitialGapInternalPressure.ReadOnly = True
            txtboxGapConductanceRefVol.Clear()
            txtboxGapConductanceRefVol.BackColor = Color.Gray
            txtboxGapConductanceRefVol.ReadOnly = True
            ChkboxDeformation.BackColor = Color.Gray
            ChkboxDeformation.Checked = False
            dgvGapDeformation.BackgroundColor = Color.Gray
            dgvGapDeformation.Enabled = False
            dgvGapDeformation.Rows.Clear()
        ElseIf ChkboxGapConductance.Checked = True Then
            HeatStructureMeshData.GapConductanceModel = True
            txtboxInitialGapInternalPressure.BackColor = Color.White
            txtboxInitialGapInternalPressure.ReadOnly = False
            txtboxGapConductanceRefVol.BackColor = Color.White
            txtboxGapConductanceRefVol.ReadOnly = False
            ChkboxDeformation.BackColor = Color.White
            ChkboxDeformation.Checked = True
            dgvGapDeformation.BackgroundColor = Color.White
            dgvGapDeformation.Enabled = True
        End If
    End Sub

    Private Sub ChkboxMetalWaterReaction_CheckStateChanged(sender As Object, e As EventArgs) Handles ChkboxMetalWaterReaction.CheckStateChanged
        If ChkboxMetalWaterReaction.Checked = False Then
            HeatStructureMeshData.MetalWaterReaction = False
            txtboxOxideThickness.Clear()
            txtboxOxideThickness.BackColor = Color.Gray
            txtboxOxideThickness.ReadOnly = True
        ElseIf ChkboxMetalWaterReaction.Checked = True Then
            HeatStructureMeshData.MetalWaterReaction = True
            txtboxOxideThickness.BackColor = Color.White
            txtboxOxideThickness.ReadOnly = False
        End If
    End Sub

    Private Sub chkboxmeshgeometry_CheckStateChanged(sender As Object, e As EventArgs) Handles chkboxmeshgeometry.CheckStateChanged
        Try
            If chkboxmeshgeometry.Checked = False Then
                HeatStructureMeshData.EnterMeshGeometry = "1"
                CmbBoxSelectFormat.Hide()
                HeatStructureMeshData.SelectFormat = "3"
                dgvformat1.Hide()
                dgvformat1.Rows.Clear()
                dgvformat2.Hide()
                dgvformat2.Rows.Clear()
                dgvNoDecay.Hide()
                dgvNoDecay.Rows.Clear()
                dgvWithDecay.Hide()
                dgvWithDecay.Rows.Clear()
                TextBox1.Hide()
                TextBox2.Hide()
                txtboxDecayHeat.Hide()
                txtboxDecayHeat.Clear()
            ElseIf chkboxmeshgeometry.Checked = True Then
                HeatStructureMeshData.EnterMeshGeometry = "0"
                CmbBoxSelectFormat.Show()
                dgvformat1.Show()
                dgvformat2.Show()
                dgvNoDecay.Show()
                dgvWithDecay.Show()
                TextBox1.Show()
                TextBox2.Show()
                txtboxDecayHeat.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbBoxSelectFormat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBoxSelectFormat.SelectedIndexChanged
        If CmbBoxSelectFormat.SelectedIndex = 0 Then
            HeatStructureMeshData.SelectFormat = "1"
            dgvformat1.Show()
            dgvformat2.Rows.Clear()
            dgvformat2.Hide()

        ElseIf CmbBoxSelectFormat.SelectedIndex = 1 Then
            HeatStructureMeshData.SelectFormat = "2"
            dgvformat1.Rows.Clear()
            dgvformat1.Hide()
            dgvformat2.Show()
        End If
    End Sub

    Private Sub ChkBoxInitialTemp_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBoxInitialTemp.CheckStateChanged
        If ChkBoxInitialTemp.Checked = False Then
            HeatStructureMeshData.EnterInitialTemp = "0"
            ComboBoxTemp.Hide()
            ComboBoxTemp.Enabled = False
            dgvTemp1.Hide()
            dgvTemp2.Hide()
            dgvTemp1.Rows.Clear()
            dgvTemp2.Rows.Clear()
        ElseIf ChkBoxInitialTemp.Checked = True Then
            HeatStructureMeshData.EnterInitialTemp = "1"
            ComboBoxTemp.Show()
            ComboBoxTemp.Enabled = True
            dgvTemp1.Show()
            dgvTemp2.Show()
        End If
    End Sub

    Private Sub ComboBoxTemp_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxTemp.SelectedValueChanged
        If ComboBoxTemp.SelectedIndex = 0 Then
            HeatStructureMeshData.SelectTemp = "0"
            dgvTemp2.Rows.Clear()
            dgvTemp2.Hide()
            dgvTemp1.Show()
        ElseIf ComboBoxTemp.SelectedIndex = 1 Then
            HeatStructureMeshData.SelectTemp = "-1"
            dgvTemp1.Rows.Clear()
            dgvTemp1.Hide()
            dgvTemp2.Show()
        Else
            HeatStructureMeshData.SelectTemp = "1"
            dgvTemp1.Rows.Clear()
            dgvTemp2.Rows.Clear()
        End If
    End Sub

    Private Sub txtboxDecayHeat_TextChanged(sender As Object, e As EventArgs) Handles txtboxDecayHeat.TextChanged
        HeatStructureMeshData.DecayHeat = txtboxDecayHeat.Text.ToString

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
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5 As Object

        HeatStructureMeshData.InitialGapInternalPressure = txtboxInitialGapInternalPressure.Text
        HeatStructureMeshData.GapConductanceReferenceVolume = txtboxGapConductanceRefVol.Text
        HeatStructureMeshData.InitialOxideThicknes = txtboxOxideThickness.Text
        HeatStructureMeshData.FormLossFactors = ChkboxDeformation.CheckState
        HeatStructureMeshData.DecayHeat = txtboxDecayHeat.Text

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.GapDeformation.Clear()
        End If
        For i = 0 To dgvGapDeformation.Rows.Count - 2
            row = dgvGapDeformation.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            Me.HeatStructureMeshData.GapDeformation.Add(row.Index + 1, New HSGapDeformation(v1, v2, v3, v4, v5))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataFormat1.Clear()
        End If
        For i = 0 To dgvformat1.Rows.Count - 2
            row = dgvformat1.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataFormat1.Add(row.Index + 1, New HSMeshDataFormat1(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataFormat2.Clear()
        End If
        For i = 0 To dgvformat2.Rows.Count - 2
            row = dgvformat2.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataFormat2.Add(row.Index + 1, New HSMeshDataFormat2(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataNoDecay.Clear()
        End If
        For i = 0 To dgvNoDecay.Rows.Count - 2
            row = dgvNoDecay.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataNoDecay.Add(row.Index + 1, New HSMeshDataNoDecay(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataWithDecay.Clear()
        End If
        For i = 0 To dgvWithDecay.Rows.Count - 2
            row = dgvWithDecay.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataWithDecay.Add(row.Index + 1, New HSMeshDataWithDecay(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.proHSMat.Clear()
        End If
        For i = 0 To DgvMat.Rows.Count - 2
            row = DgvMat.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            Me.HeatStructureMeshData.proHSMat.Add(row.Index + 1, New HSMat(v1, v2, v3, v4, v5))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataComposition.Clear()
        End If
        For i = 0 To dgvComposition.Rows.Count - 2
            row = dgvComposition.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataComposition.Add(row.Index + 1, New HSMeshDataComposition(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataComposition2.Clear()
        End If
        For i = 0 To dgvComposition2.Rows.Count - 2
            row = dgvComposition2.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataComposition2.Add(row.Index + 1, New HSMeshDataComposition2(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataComposition3.Clear()
        End If
        For i = 0 To dgvComposition3.Rows.Count - 2
            row = dgvComposition3.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataComposition3.Add(row.Index + 1, New HSMeshDataComposition3(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataComposition4.Clear()
        End If
        For i = 0 To dgvComposition4.Rows.Count - 2
            row = dgvComposition4.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataComposition4.Add(row.Index + 1, New HSMeshDataComposition4(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataComposition5.Clear()
        End If
        For i = 0 To dgvComposition5.Rows.Count - 2
            row = dgvComposition5.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataComposition5.Add(row.Index + 1, New HSMeshDataComposition5(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.MeshDataComposition6.Clear()
        End If
        For i = 0 To dgvComposition6.Rows.Count - 2
            row = dgvComposition6.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.MeshDataComposition6.Add(row.Index + 1, New HSMeshDataComposition6(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.Temp1.Clear()
        End If
        For i = 0 To dgvTemp1.Rows.Count - 2
            row = dgvTemp1.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.Temp1.Add(row.Index + 1, New HSTemp1(v1, v2))
        Next

        If Not Me.HeatStructureMeshData Is Nothing Then
            Me.HeatStructureMeshData.Temp2.Clear()
        End If
        For i = 0 To dgvTemp2.Rows.Count - 2
            row = dgvTemp2.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.HeatStructureMeshData.Temp2.Add(row.Index + 1, New HSTemp2(v1, v2))
        Next
        row.Dispose()

    End Sub
   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.TabPages.Add(1)
        'Dim dgv As New DataGridView

        'dgv.Location = New System.Drawing.Point(10, 10)
        'dgv.Size() = New System.Drawing.Size(110, 30)
        'Me.Controls.Add(dgv)
        'dgv.ColumnCount = 5
        'dgv.RowCount = 5
        Dim dgv As New DataGridView
        Dim c As Integer = 2
        Dim r As Integer = 2
        dgv.Parent = TabControl1.TabPages(TabControl1.TabPages.Count - 1)
        For cc As Integer = 0 To c - 1
            Dim nc As New DataGridViewTextBoxColumn
            nc.Name = "Column"
            dgv.Columns.Add(nc)
        Next
        dgv.Rows.Add(r - 1)
        TabControl1.TabPages(TabControl1.TabPages.Count - 1).Controls.Add(dgv)
        dgv.Columns(0).HeaderText = "temperature"
        dgv.Columns(1).HeaderText = "thermalConductivity"
        dgv.Location = New System.Drawing.Point(10, 10)
        dgv.Size() = New System.Drawing.Size(250, 150)
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        ' Me.Controls.Add(dgv)
    End Sub

    Private Sub DgvMat_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DgvMat.RowsAdded
        If DgvMat.Rows.Count = 2 Then
            TextBox8.Show()
            TextBox9.Hide()
            TextBox10.Hide()
            dgvComposition.Show()
            dgvComposition2.Show()
            dgvComposition3.Hide()
            dgvComposition4.Hide()
            dgvComposition5.Hide()
            dgvComposition6.Hide()
        End If
        If DgvMat.Rows.Count = 3 Then
            TextBox9.Show()
            TextBox8.Show()
            TextBox10.Hide()
            dgvComposition3.Show()
            dgvComposition4.Show()
            dgvComposition.Show()
            dgvComposition2.Show()
            dgvComposition5.Hide()
            dgvComposition6.Hide()
        End If
        If DgvMat.Rows.Count = 4 Then
            TextBox10.Show()
            TextBox8.Show()
            TextBox9.Show()
            dgvComposition5.Show()
            dgvComposition6.Show()
            dgvComposition.Show()
            dgvComposition2.Show()
            dgvComposition3.Show()
            dgvComposition4.Show()
        End If

    End Sub
End Class


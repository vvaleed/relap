Public Class ucHeatStructureEditor2
    Private _HeatStructureBoundaryCond As HeatStructureBoundaryCond
    Public Property HeatStructureBoundaryCond() As HeatStructureBoundaryCond
        Get
            Return _HeatStructureBoundaryCond
        End Get
        Set(ByVal value As HeatStructureBoundaryCond)
            _HeatStructureBoundaryCond = value
        End Set
    End Property
    Private _BC As RELAP.SistemasDeUnidades.Unidades
    Public Property SystemOfUnits() As RELAP.SistemasDeUnidades.Unidades
        Get
            Return _BC
        End Get
        Set(ByVal value As RELAP.SistemasDeUnidades.Unidades)
            _BC = value
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

    Private Sub ucHeatStructureEditor2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim gobj As Microsoft.MSDN.Samples.GraphicObjects.HeatStructureGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myCOTK As RELAP.SimulationObjects.UnitOps.HeatStructure = My.Application.ActiveSimulation.Collections.CLCS_HeatStructureCollection(gobj.Name)


        'default values
        dgvtab1.Rows.Add(1)
        dgvtab1.Rows(0).Cells(2).Value = DirectCast(dgvtab1.Rows(0).Cells(2), DataGridViewComboBoxCell).Items(0)
        dgvtab1.Rows(0).Cells(3).Value = 10000
        dgvtab1.Rows(0).Cells(4).Value = DirectCast(dgvtab1.Rows(0).Cells(4), DataGridViewComboBoxCell).Items(0)
        dgvtab1.Rows(0).Cells(5).Value = 1
        dgvtab1.Rows(0).Cells(6).Value = 5.0
        dgvtab1.Rows(0).Cells(7).Value = myCOTK.NumberOfAxialHS

        dgvTab2.Rows.Add(1)
        dgvTab2.Rows(0).Cells(2).Value = DirectCast(dgvTab2.Rows(0).Cells(2), DataGridViewComboBoxCell).Items(0)
        dgvTab2.Rows(0).Cells(3).Value = 10000
        dgvTab2.Rows(0).Cells(4).Value = DirectCast(dgvTab2.Rows(0).Cells(4), DataGridViewComboBoxCell).Items(0)
        dgvTab2.Rows(0).Cells(5).Value = 1
        dgvTab2.Rows(0).Cells(6).Value = 5.0
        dgvTab2.Rows(0).Cells(7).Value = myCOTK.NumberOfAxialHS
      

        If myCOTK.HeatStructureBoundaryCond.BoundaryCondTab3.Count = 0 Then
            dgvTab3.Rows.Add(1)
            dgvTab3.Rows(0).Cells(0).Value = 0
            dgvTab3.Rows(0).Cells(1).Value = 0
            dgvTab3.Rows(0).Cells(2).Value = 0
            dgvTab3.Rows(0).Cells(3).Value = 0
            dgvTab3.Rows(0).Cells(4).Value = myCOTK.NumberOfAxialHS
        Else
            dgvTab3.Rows.Add(1)
            Dim i = 1
            For Each row As DataGridViewRow In dgvTab3.Rows
                row.Cells(0).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab3(i).SourceType
                row.Cells(1).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab3(i).InternalSourceMultiplier
                row.Cells(2).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab3(i).DirectModeratorHeatingMultiplierLeft
                row.Cells(3).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab3(i).DirectModeratorHeatingMultiplierRight
                row.Cells(4).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab3(i).SourceHeatStructureNumber
                i = i + 1
            Next
        End If


        If myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4.Count = 0 Then
            dgvTab4.Rows.Add(1)
            dgvTab4.Rows(0).Cells(0).Value = 0.0
            dgvTab4.Rows(0).Cells(1).Value = 10.0
            dgvTab4.Rows(0).Cells(2).Value = 10.0
            dgvTab4.Rows(0).Cells(3).Value = 0.0
            dgvTab4.Rows(0).Cells(4).Value = 0.0
            dgvTab4.Rows(0).Cells(5).Value = 0.0
            dgvTab4.Rows(0).Cells(6).Value = 0.0
            dgvTab4.Rows(0).Cells(7).Value = 1.0
            dgvTab4.Rows(0).Cells(8).Value = 0.0
            dgvTab4.Rows(0).Cells(9).Value = 1.1
            dgvTab4.Rows(0).Cells(10).Value = 1.0
            dgvTab4.Rows(0).Cells(11).Value = myCOTK.NumberOfAxialHS
        Else
            dgvTab4.Rows.Add(1)
            'dgvTab4.Rows.Add(myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4.Count)

            Dim i = 1
            For Each row As DataGridViewRow In dgvTab4.Rows
                row.Cells(0).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftHeatedEquivalentDiameter
                row.Cells(1).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).LeftHeatedLengthForward
                row.Cells(2).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).LeftHeatedLengthReverse
                row.Cells(3).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftGridSpacerLengthForward
                row.Cells(4).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftGridSpacerLengthReverse
                row.Cells(5).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftGridLossCoefficientForward
                row.Cells(6).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftGridLossCoefficientReverse
                row.Cells(7).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftLocalBoilingFactor
                row.Cells(8).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftNaturalCirculationLength
                row.Cells(9).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftPitchtoDiameterRatio
                row.Cells(10).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftFoulingFactor
                row.Cells(11).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab4(i).leftAddHeatStructureNumber
                i = i + 1
            Next
        End If

        If myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5.Count = 0 Then
            dgvTab5.Rows.Add(1)
            dgvTab5.Rows(0).Cells(0).Value = 0.0
            dgvTab5.Rows(0).Cells(1).Value = 10.0
            dgvTab5.Rows(0).Cells(2).Value = 10.0
            dgvTab5.Rows(0).Cells(3).Value = 0.0
            dgvTab5.Rows(0).Cells(4).Value = 0.0
            dgvTab5.Rows(0).Cells(5).Value = 0.0
            dgvTab5.Rows(0).Cells(6).Value = 0.0
            dgvTab5.Rows(0).Cells(7).Value = 1.0
            dgvTab5.Rows(0).Cells(8).Value = 0.0
            dgvTab5.Rows(0).Cells(9).Value = 1.1
            dgvTab5.Rows(0).Cells(10).Value = 1.0
            dgvTab5.Rows(0).Cells(11).Value = myCOTK.NumberOfAxialHS
        Else

            dgvTab5.Rows.Add(1)
            'dgvTab5.Rows.Add(myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5.Count)
            Dim i = 1
            For Each row As DataGridViewRow In dgvTab5.Rows
                row.Cells(0).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightHeatedEquivalentDiameter
                row.Cells(1).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightHeatedLengthForward
                row.Cells(2).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightHeatedLengthReverse
                row.Cells(3).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightGridSpacerLengthForward
                row.Cells(4).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightGridSpacerLengthReverse
                row.Cells(5).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightGridLossCoefficientForward
                row.Cells(6).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightGridLossCoefficientReverse
                row.Cells(7).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightLocalBoilingFactor
                row.Cells(8).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightNaturalCirculationLength
                row.Cells(9).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightPitchtoDiameterRatio
                row.Cells(10).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightFoulingFactor
                row.Cells(11).Value = myCOTK.HeatStructureBoundaryCond.BoundaryCondTab5(i).rightAddHeatStructureNumber
                i = i + 1
            Next
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12 As Object

        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab1.Clear()
        End If

        For i = 0 To dgvtab1.Rows.Count - 2
            row = dgvtab1.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            v6 = row.Cells(5).Value
            v7 = row.Cells(6).Value
            v8 = row.Cells(7).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab1.Add(row.Index + 1, New HSBoundaryCondTab1(v1, v2, v3, v4, v5, v6, v7, v8))
        Next
        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab2.Clear()
        End If

        For i = 0 To dgvTab2.Rows.Count - 2
            row = dgvTab2.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            v6 = row.Cells(5).Value
            v7 = row.Cells(6).Value
            v8 = row.Cells(7).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab2.Add(row.Index + 1, New HSBoundaryCondTab2(v1, v2, v3, v4, v5, v6, v7, v8))
        Next

        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab3.Clear()
        End If

        For i = 0 To dgvTab3.Rows.Count - 2
            row = dgvTab3.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab3.Add(row.Index + 1, New HSBoundaryCondTab3(v1, v2, v3, v4, v5))
        Next
        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab4.Clear()
        End If

        For i = 0 To dgvTab4.Rows.Count - 2
            row = dgvTab4.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            v6 = row.Cells(5).Value
            v7 = row.Cells(6).Value
            v8 = row.Cells(7).Value
            v9 = row.Cells(8).Value
            v10 = row.Cells(9).Value
            v11 = row.Cells(10).Value
            v12 = row.Cells(11).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab4.Add(row.Index + 1, New HSBoundaryCondTab4(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12))
        Next
        If Not Me.HeatStructureBoundaryCond Is Nothing Then
            Me.HeatStructureBoundaryCond.BoundaryCondTab5.Clear()
        End If

        For i = 0 To dgvTab5.Rows.Count - 2
            row = dgvTab5.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            v5 = row.Cells(4).Value
            v6 = row.Cells(5).Value
            v7 = row.Cells(6).Value
            v8 = row.Cells(7).Value
            v9 = row.Cells(8).Value
            v10 = row.Cells(9).Value
            v11 = row.Cells(10).Value
            v12 = row.Cells(11).Value
            Me.HeatStructureBoundaryCond.BoundaryCondTab5.Add(row.Index + 1, New HSBoundaryCondTab5(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12))
        Next
        ' row.Dispose()
    End Sub

    Private Sub dgvtab1_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvtab1.RowsAdded
        Try

            Dim cbo As DataGridViewComboBoxCell = dgvtab1.Rows(e.RowIndex).Cells(0)
            cbo.Items.Clear()

            For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                cbo.Items.Add(kvp.Value.GraphicObject.Tag)

            Next
            cbo.Items.Add("Insulated")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvtab2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvTab2.RowsAdded
        Try

            Dim cbo As DataGridViewComboBoxCell = dgvTab2.Rows(e.RowIndex).Cells(0)
            cbo.Items.Clear()

            For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                cbo.Items.Add(kvp.Value.GraphicObject.Tag)

            Next
            cbo.Items.Add("Insulated")
        Catch ex As Exception

        End Try
    End Sub

End Class

Public Class ucSeparatorEditor

    Private _SeparatorJunctionsGeometry As SeparatorJunctionsGeometry
    Public Property SeparatorJunctionsGeometry() As SeparatorJunctionsGeometry
        Get
            Return _SeparatorJunctionsGeometry
        End Get
        Set(ByVal value As SeparatorJunctionsGeometry)
            _SeparatorJunctionsGeometry = value
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

    Private Sub ucSeparatorEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim gobj As Microsoft.Msdn.Samples.GraphicObjects.SeparatorGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myCOTk As RELAP.SimulationObjects.UnitOps.Separator = My.Application.ActiveSimulation.Collections.CLCS_SeparatorCollection(gobj.Name)

        CheckBoxEntermass.Checked = True
        dgvSeparator.Hide()
        If My.Application.ActiveSimulation.ComponentType = "Separator" Then
            dgvSeparator.Columns(8).Visible = False
            For i = 1 To myCOTk.NumberofJunctions - 1
                dgvSeparator.Rows.Add(i.ToString)
            Next
            If myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry.Count <> 0 Then
                Dim i = 1
                For Each row As DataGridViewRow In dgvSeparator.Rows
                    row.Cells(0).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromComponent
                    row.Cells(1).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromComponentVolumeNumber
                    row.Cells(2).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromFaceNumber
                    row.Cells(3).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToComponent
                    row.Cells(4).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToComponentVolumeNumber
                    row.Cells(5).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToFaceNumber
                    row.Cells(6).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).JunctionArea
                    row.Cells(7).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FFLossCo
                    row.Cells(8).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).RFlossCo
                    row.Cells(9).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).SubcooledDischargeCo
                    row.Cells(10).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).TwoPhaseDischargeCo
                    row.Cells(11).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).SuperheatedDischargeCo
                    row.Cells(12).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).LiquidMassFlow
                    row.Cells(13).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).VaporMassFlow
                    i = i + 1
                Next

            Else
                Dim i = 1
                For Each row As DataGridViewRow In dgvSeparator.Rows
                    'row.Cells(0).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromComponent
                    row.Cells(1).Value = 1
                    'row.Cells(2).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromFaceNumber
                    ' row.Cells(3).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToComponent
                    row.Cells(4).Value = 1
                    'row.Cells(5).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToFaceNumber
                    row.Cells(6).Value = 0.0
                    row.Cells(7).Value = 0.0
                    row.Cells(8).Value = 0.0
                    row.Cells(9).Value = 1.0
                    row.Cells(10).Value = 1.0
                    row.Cells(11).Value = 1.0
                    row.Cells(12).Value = 0.0
                    row.Cells(13).Value = 0.0
                Next
            End If
        ElseIf My.Application.ActiveSimulation.ComponentType = "Separator" Then
            dgvSeparator.Columns(8).Visible = False
            dgvSeparator.Rows.Add(3)
            'If mySEP.SeparatorJunctionsGeometry.SeparatorGeometry.Count <> 0 Then
            '    Dim i = 1
            '    For Each row As DataGridViewRow In dgvSeparator.Rows
            '        row.Cells(0).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromComponent
            '        row.Cells(1).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromComponentVolumeNumber
            '        row.Cells(2).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromFaceNumber
            '        row.Cells(3).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToComponent
            '        row.Cells(4).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToComponentVolumeNumber
            '        row.Cells(5).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToFaceNumber
            '        row.Cells(6).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).JunctionArea
            '        row.Cells(7).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).FFLossCo
            '        row.Cells(8).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).RFlossCo
            '        row.Cells(9).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).SubcooledDischargeCo
            '        row.Cells(10).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).TwoPhaseDischargeCo
            '        row.Cells(11).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).SuperheatedDischargeCo
            '        row.Cells(12).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).LiquidMassFlow
            '        row.Cells(13).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).VaporMassFlow
            '        i = i + 1
            '    Next

            'Else
            '    Dim i = 1
            '    For Each row As DataGridViewRow In dgvSeparator.Rows
            '        'row.Cells(0).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromComponent
            '        row.Cells(1).Value = 1
            '        'row.Cells(2).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromFaceNumber
            '        ' row.Cells(3).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToComponent
            '        row.Cells(4).Value = 1
            '        'row.Cells(5).Value = mySEP.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToFaceNumber
            '        row.Cells(6).Value = 0.0
            '        row.Cells(7).Value = 0.0
            '        row.Cells(8).Value = 0.0
            '        row.Cells(9).Value = 1.0
            '        row.Cells(10).Value = 1.0
            '        row.Cells(11).Value = 1.0
            '        row.Cells(12).Value = 0.0
            '        row.Cells(13).Value = 0.0
            '    Next
            'End If
        End If

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14 As Object

        If Not Me.SeparatorJunctionsGeometry Is Nothing Then
            Me.SeparatorJunctionsGeometry.SeparatorGeometry.Clear()
        End If

        For i = 0 To dgvSeparator.Rows.Count - 2
            row = dgvSeparator.Rows(i)
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
            v13 = row.Cells(12).Value
            v14 = row.Cells(13).Value
            Me.SeparatorJunctionsGeometry.SeparatorGeometry.Add(row.Index + 1, New SeparatorGeometry(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14))
        Next
    End Sub

    Private Sub dgvSeparator_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvSeparator.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvSeparator_RowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles dgvSeparator.RowsAdded
        Try

            Dim cbo As DataGridViewComboBoxCell = dgvSeparator.Rows(e.RowIndex).Cells(0)
            cbo.Items.Clear()

            For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                cbo.Items.Add(kvp.Value.GraphicObject.Tag)
            Next

            Dim cbo2 As DataGridViewComboBoxCell = dgvSeparator.Rows(e.RowIndex).Cells(3)
            cbo2.Items.Clear()

            For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                cbo2.Items.Add(kvp.Value.GraphicObject.Tag)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxEntermass_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxEntermass.CheckStateChanged
        If CheckBoxEntermass.Checked = True Then
            dgvSeparator.Columns(12).HeaderText = "Initial Liquid Mass Flow"
            dgvSeparator.Columns(13).HeaderText = "Initial Vapor Mass Flow"
        ElseIf CheckBoxEntermass.Checked = False Then
            dgvSeparator.Columns(12).HeaderText = "Initial Liquid Velocity"
            dgvSeparator.Columns(13).HeaderText = "Initial Vapor Velocity"
        End If
    End Sub


End Class

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

        CheckBoxEntermass.Checked = False
        For i = 1 To 3
            dgvSeparator.Rows.Add(i.ToString)
        Next
        If myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry.Count <> 0 Then
            Dim i = 1
            For Each row As DataGridViewRow In dgvSeparator.Rows
                ' Dim row As DataGridViewRow = dgvSeparator.Rows(i - 1)
                Dim CBox As DataGridViewComboBoxCell = CType(row.Cells(0), DataGridViewComboBoxCell)
                Dim CBox2 As DataGridViewComboBoxCell = CType(row.Cells(2), DataGridViewComboBoxCell)
                Dim CBox3 As DataGridViewComboBoxCell = CType(row.Cells(3), DataGridViewComboBoxCell)
                Dim CBox4 As DataGridViewComboBoxCell = CType(row.Cells(5), DataGridViewComboBoxCell)
                '  Dim CCol As DataGridViewComboBoxColumn = CType(dgvtab1.Columns(0), DataGridViewComboBoxColumn)

                CBox.Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromComponent
                row.Cells(0).Value = CBox.Value
                row.Cells(1).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromComponentVolumeNumber
                CBox2.Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FromFaceNumber
                row.Cells(2).Value = CBox2.Value
                CBox3.Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToComponent
                row.Cells(3).Value = CBox3.Value
                row.Cells(4).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToComponentVolumeNumber
                CBox4.Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).ToFaceNumber
                row.Cells(5).Value = CBox4.Value
                row.Cells(6).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).JunctionArea
                row.Cells(7).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).FFLossCo
                row.Cells(8).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).RFlossCo
                row.Cells(9).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).SubcooledDischargeCo
                row.Cells(10).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).LiquidMassFlow
                row.Cells(11).Value = myCOTk.SeparatorJunctionsGeometry.SeparatorGeometry(i).VaporMassFlow
            Next

        Else

            Dim i = 0
            For Each row As DataGridViewRow In dgvSeparator.Rows
                dgvSeparator.Rows(i).Cells(1).Value = 1
                dgvSeparator.Rows(i).Cells(2).Value = DirectCast(dgvSeparator.Rows(i).Cells(2), DataGridViewComboBoxCell).Items(0)
                dgvSeparator.Rows(i).Cells(4).Value = 1
                dgvSeparator.Rows(i).Cells(5).Value = DirectCast(dgvSeparator.Rows(i).Cells(5), DataGridViewComboBoxCell).Items(0)
                dgvSeparator.Rows(i).Cells(6).Value = 0.0
                dgvSeparator.Rows(i).Cells(7).Value = 0.0
                dgvSeparator.Rows(i).Cells(8).Value = 0.0
                dgvSeparator.Rows(i).Cells(9).Value = 0.5
                dgvSeparator.Rows(i).Cells(10).Value = 0.0
                dgvSeparator.Rows(i).Cells(11).Value = 0.0

                i = i + 1
            Next
        End If


    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12 As Object

        If Not Me.SeparatorJunctionsGeometry Is Nothing Then
            Me.SeparatorJunctionsGeometry.SeparatorGeometry.Clear()
        End If

        For Each row In Me.dgvSeparator.Rows
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
            Me.SeparatorJunctionsGeometry.SeparatorGeometry.Add(row.Index + 1, New SeparatorGeometry(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12))
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
            SeparatorJunctionsGeometry.EnterMassorVelocity = "1"
            dgvSeparator.Columns(10).HeaderText = "Initial Liquid Mass Flow"
            dgvSeparator.Columns(11).HeaderText = "Initial Vapor Mass Flow"
        ElseIf CheckBoxEntermass.Checked = False Then
            SeparatorJunctionsGeometry.EnterMassorVelocity = "0"
            dgvSeparator.Columns(10).HeaderText = "Initial Liquid Velocity"
            dgvSeparator.Columns(11).HeaderText = "Initial Vapor Velocity"
        End If
    End Sub


End Class

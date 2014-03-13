Public Class ucBranchEditor

    Private _BranchJunctionsGeometry As BranchJunctionsGeometry
    Public Property BranchJunctionsGeometry() As BranchJunctionsGeometry
        Get
            Return _BranchJunctionsGeometry
        End Get
        Set(ByVal value As BranchJunctionsGeometry)
            _BranchJunctionsGeometry = value
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

    Private Sub ucBranchEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim gobj As Microsoft.Msdn.Samples.GraphicObjects.BranchGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myCOTk As RELAP.SimulationObjects.UnitOps.Branch = My.Application.ActiveSimulation.Collections.CLCS_BranchCollection(gobj.Name)

        CheckBoxEntermass.Checked = False
        For i = 1 To myCOTk.NumberofInputJunctions + myCOTk.NumberofOutputJunctions - 1
            dgvBranch.Rows.Add(i.ToString)
        Next
        If myCOTk.BranchJunctionsGeometry.BranchGeometry.Count <> 0 Then
            Dim i = 1
            For Each row As DataGridViewRow In dgvBranch.Rows
                ' Dim row As DataGridViewRow = dgvbranch.Rows(i - 1)
                Dim CBox As DataGridViewComboBoxCell = CType(row.Cells(0), DataGridViewComboBoxCell)
                Dim CBox2 As DataGridViewComboBoxCell = CType(row.Cells(2), DataGridViewComboBoxCell)
                Dim CBox3 As DataGridViewComboBoxCell = CType(row.Cells(3), DataGridViewComboBoxCell)
                Dim CBox4 As DataGridViewComboBoxCell = CType(row.Cells(5), DataGridViewComboBoxCell)
                '  Dim CCol As DataGridViewComboBoxColumn = CType(dgvtab1.Columns(0), DataGridViewComboBoxColumn)

                CBox.Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).FromComponent
                row.Cells(0).Value = CBox.Value
                row.Cells(1).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).FromComponentVolumeNumber
                CBox2.Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).FromFaceNumber
                row.Cells(2).Value = CBox2.Value
                CBox3.Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).ToComponent
                row.Cells(3).Value = CBox3.Value
                row.Cells(4).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).ToComponentVolumeNumber
                CBox4.Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).ToFaceNumber
                row.Cells(5).Value = CBox4.Value
                row.Cells(6).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).JunctionArea
                row.Cells(7).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).FFLossCo
                row.Cells(8).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).RFlossCo
                row.Cells(9).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).SubcooledDischargeCo
                row.Cells(10).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).TwoPhaseDischargeCo
                row.Cells(11).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).SuperheatedDischargeCo
                row.Cells(12).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).LiquidMassFlow
                row.Cells(13).Value = myCOTk.BranchJunctionsGeometry.BranchGeometry(i).VaporMassFlow
            Next

        Else

            Dim i = 0
            For Each row As DataGridViewRow In dgvBranch.Rows
                dgvBranch.Rows(i).Cells(1).Value = 1
                dgvBranch.Rows(i).Cells(2).Value = DirectCast(dgvBranch.Rows(i).Cells(2), DataGridViewComboBoxCell).Items(0)
                dgvBranch.Rows(i).Cells(4).Value = 1
                dgvBranch.Rows(i).Cells(5).Value = DirectCast(dgvBranch.Rows(i).Cells(5), DataGridViewComboBoxCell).Items(0)
                dgvBranch.Rows(i).Cells(6).Value = 0.0
                dgvBranch.Rows(i).Cells(7).Value = 0.0
                dgvBranch.Rows(i).Cells(8).Value = 0.0
                dgvBranch.Rows(i).Cells(9).Value = 1.0
                dgvBranch.Rows(i).Cells(10).Value = 1.0
                dgvBranch.Rows(i).Cells(11).Value = 1.0
                dgvBranch.Rows(i).Cells(12).Value = 0.0
                dgvBranch.Rows(i).Cells(13).Value = 0.0

                i = i + 1
            Next
        End If
        
       
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14 As Object

        If Not Me.BranchJunctionsGeometry Is Nothing Then
            Me.BranchJunctionsGeometry.BranchGeometry.Clear()
        End If

        For Each row In Me.dgvBranch.Rows
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
            Me.BranchJunctionsGeometry.BranchGeometry.Add(row.Index + 1, New BranchGeometry(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14))
        Next
    End Sub

    Private Sub dgvBranch_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBranch.DataError
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvBranch_RowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles dgvBranch.RowsAdded
        Try

            Dim cbo As DataGridViewComboBoxCell = dgvBranch.Rows(e.RowIndex).Cells(0)
            cbo.Items.Clear()

            For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                cbo.Items.Add(kvp.Value.GraphicObject.Tag)
            Next

            Dim cbo2 As DataGridViewComboBoxCell = dgvBranch.Rows(e.RowIndex).Cells(3)
            cbo2.Items.Clear()

            For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                cbo2.Items.Add(kvp.Value.GraphicObject.Tag)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxEntermass_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxEntermass.CheckStateChanged
        If CheckBoxEntermass.Checked = True Then
            BranchJunctionsGeometry.EnterMassorVelocity = "1"
            dgvBranch.Columns(12).HeaderText = "Initial Liquid Mass Flow"
            dgvBranch.Columns(13).HeaderText = "Initial Vapor Mass Flow"
        ElseIf CheckBoxEntermass.Checked = False Then
            BranchJunctionsGeometry.EnterMassorVelocity = "0"
            dgvBranch.Columns(12).HeaderText = "Initial Liquid Velocity"
            dgvBranch.Columns(13).HeaderText = "Initial Vapor Velocity"
        End If
    End Sub

   
End Class

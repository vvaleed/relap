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

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19 As Object

        If Not Me.BranchJunctionsGeometry Is Nothing Then
            Me.BranchJunctionsGeometry.BranchGeometry.Clear()
        End If

        For i = 0 To dgvBranch.Rows.Count - 2
            row = dgvBranch.Rows(i)
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
            v15 = row.Cells(14).Value
            v16 = row.Cells(15).Value
            v17 = row.Cells(16).Value
            v18 = row.Cells(17).Value
            v19 = row.Cells(18).Value
            Me.BranchJunctionsGeometry.BranchGeometry.Add(row.Index + 1, New BranchGeometry(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19))
        Next
    End Sub

    Private Sub dgvBranch_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvBranch.RowsAdded
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
End Class

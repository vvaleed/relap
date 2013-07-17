
Public Class ucPipeEditor
    Protected m_profile As PipeProfile

    Public Property Profile() As PipeProfile
        Get
            Return m_profile
        End Get
        Set(ByVal value As PipeProfile)
            m_profile = value
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

    Private Sub ucPipeEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim gobj As Microsoft.Msdn.Samples.GraphicObjects.PipeGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myCOTK As RELAP.SimulationObjects.UnitOps.pipe = My.Application.ActiveSimulation.Collections.CLCS_PipeCollection(gobj.Name)

        For i = 1 To myCOTK.NumberOfVoulmes
            dgv.Rows.Add(i.ToString)
        Next
        For Each row As DataGridViewRow In dgv.Rows
            For i = 1 To row.Cells.Count - 1
                row.Cells(i).Value = 0
            Next
        Next

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16 As Object

        If Not Me.Profile Is Nothing Then Me.Profile.Sections.Clear()
        For Each row In Me.dgv.Rows
            'If ParseColumn(column) = "OK" Then
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
           
            Me.Profile.Sections.Add(row.Index + 1, New PipeSection(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16))
            'Else
            '    Label1.Text = DWSIM.App.GetLocalString("Erronasecao") & " " & column.Index + 1 & "."
            '    RaiseEvent StatusChanged(e, PipeEditorStatus.Erro)
            '    Exit Sub
            'End If
        Next
        '  RaiseEvent StatusChanged(e, PipeEditorStatus.OK)

        row.Dispose()
    End Sub
    Dim selectedcells As New List(Of Double)
    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        If dgv.SelectedRows.Count = 1 Then
            selectedcells.Clear()
            selectedcells.Add(dgv.SelectedRows(0).Cells(1).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(2).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(3).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(4).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(5).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(6).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(7).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(8).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(9).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(10).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(11).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(12).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(13).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(14).Value)
            selectedcells.Add(dgv.SelectedRows(0).Cells(15).Value)
        End If
    End Sub

    Private Sub cmdPaste_Click(sender As Object, e As EventArgs) Handles cmdPaste.Click
        For Each row As DataGridViewRow In dgv.SelectedRows
            row.Cells(1).Value = selectedcells(0)
            row.Cells(2).Value = selectedcells(1)
            row.Cells(3).Value = selectedcells(2)
            row.Cells(4).Value = selectedcells(3)
            row.Cells(5).Value = selectedcells(4)
            row.Cells(6).Value = selectedcells(5)
            row.Cells(7).Value = selectedcells(6)
            row.Cells(8).Value = selectedcells(7)
            row.Cells(9).Value = selectedcells(8)
            row.Cells(10).Value = selectedcells(9)
            row.Cells(11).Value = selectedcells(10)
            row.Cells(12).Value = selectedcells(11)
            row.Cells(13).Value = selectedcells(12)
            row.Cells(14).Value = selectedcells(13)
            row.Cells(15).Value = selectedcells(14)

        Next

    End Sub
End Class


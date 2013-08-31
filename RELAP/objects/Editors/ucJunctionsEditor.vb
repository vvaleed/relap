Public Class ucJunctionsEditor

    Private _JunctionsData As JunctionsData
    Public Property JunctionsData() As JunctionsData
        Get
            Return _JunctionsData
        End Get
        Set(ByVal value As JunctionsData)
            _JunctionsData = value
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

    Private Sub ComboBoxEnter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxEnter.SelectedIndexChanged
        If ComboBoxEnter.SelectedIndex = 0 Then
            JunctionsData.EnterMassorVelocity = 0
            dgvMass.Rows.Clear()
            dgvMass.Hide()
            dgvVelocity.Show()
        ElseIf ComboBoxEnter.SelectedIndex = 1 Then
            JunctionsData.EnterMassorVelocity = 1
            dgvMass.Show()
            dgvVelocity.Rows.Clear()
            dgvVelocity.Hide()
        End If
    End Sub
 
    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4 As Object

        If Not Me.JunctionsData Is Nothing Then
            Me.JunctionsData.JunctionDatavelocity.Clear()
        End If

        For i = 0 To dgvVelocity.Rows.Count - 2
            row = dgvVelocity.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            Me.JunctionsData.JunctionDatavelocity.Add(row.Index + 1, New JunctionDatavelocity(v1, v2, v3, v4))
        Next

        If Not Me.JunctionsData Is Nothing Then
            Me.JunctionsData.JunctionDataMass.Clear()
        End If

        For i = 0 To dgvMass.Rows.Count - 2
            row = dgvMass.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value
            v4 = row.Cells(3).Value
            Me.JunctionsData.JunctionDataMass.Add(row.Index + 1, New JunctionDataMass(v1, v2, v3, v4))
        Next
    End Sub

   
End Class

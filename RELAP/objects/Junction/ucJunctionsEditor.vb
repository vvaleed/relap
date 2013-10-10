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

            dgvVelocity.Columns(1).HeaderText = "Liquid Velocity"
            dgvVelocity.Columns(2).HeaderText = "Vapor Velocity"

        ElseIf ComboBoxEnter.SelectedIndex = 1 Then
            JunctionsData.EnterMassorVelocity = 1
            dgvVelocity.Columns(1).HeaderText = "Liquid Mass Flow"
            dgvVelocity.Columns(2).HeaderText = "Vapor Mass Flow"
        End If
    End Sub
 
    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3 As Object

        If Not Me.JunctionsData Is Nothing Then
            Me.JunctionsData.JunctionDatavelocity.Clear()
        End If

        For i = 0 To dgvVelocity.Rows.Count - 2
            row = dgvVelocity.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            v3 = row.Cells(2).Value

            Me.JunctionsData.JunctionDatavelocity.Add(row.Index + 1, New JunctionDatavelocity(v1, v2, v3))
        Next
    End Sub

   
    Private Sub ucJunctionsEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim gobj As Microsoft.Msdn.Samples.GraphicObjects.TimeDependentJunctionGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myCOTK As RELAP.SimulationObjects.UnitOps.TimeDependentJunction = My.Application.ActiveSimulation.Collections.CLCS_TimeDependentJunctionCollection(gobj.Name)

        If myCOTK.JunctionsData.JunctionDatavelocity.Count = 0 Then
            dgvVelocity.Rows.Add(1)
            dgvVelocity.Rows(0).Cells(0).Value = 0.0
            dgvVelocity.Rows(0).Cells(1).Value = 0.0
            dgvVelocity.Rows(0).Cells(2).Value = 0.0
        Else
            dgvVelocity.Rows.Add(myCOTK.JunctionsData.JunctionDatavelocity.Count)
            Dim i = 1
            For i = 1 To myCOTK.JunctionsData.JunctionDatavelocity.Count
                Dim row As DataGridViewRow = dgvVelocity.Rows(i - 1)
                row.Cells(0).Value = myCOTK.JunctionsData.JunctionDatavelocity(i).TimeVelocity
                row.Cells(1).Value = myCOTK.JunctionsData.JunctionDatavelocity(i).LiquidVelocity
                row.Cells(2).Value = myCOTK.JunctionsData.JunctionDatavelocity(i).VaporVelocity
            Next
        End If
    End Sub
End Class

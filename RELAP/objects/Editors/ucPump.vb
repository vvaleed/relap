Imports Microsoft.Msdn.Samples.GraphicObjects
Public Class ucPump

    Private _PumpData As PumpData
    Public Property PumpData() As PumpData
        Get
            Return _PumpData
        End Get
        Set(ByVal value As PumpData)
            _PumpData = value
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

    Private Sub ucPump_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim gobj As Microsoft.Msdn.Samples.GraphicObjects.PumpGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myCOTK As RELAP.SimulationObjects.UnitOps.Pump = My.Application.ActiveSimulation.Collections.CLCS_PumpCollection(gobj.Name)

        CmbBox1.SelectedIndex = PumpData.cmbboxindex1
        CmbBox2.SelectedIndex = PumpData.cmbboxindex2
        CmbBox3.SelectedIndex = PumpData.cmbboxindex3
        CmbBox4.SelectedIndex = PumpData.cmbboxindex4
        CmbBox5.SelectedIndex = PumpData.cmbboxindex5

        If myCOTK.PumpData.Propumpdata201.Count = 0 Then
            dgvtab201.Rows.Add(1)
            dgvtab201.Rows(0).Cells(0).Value = 0
            dgvtab201.Rows(0).Cells(1).Value = 0
        Else
            dgvtab201.Rows.Add(myCOTK.PumpData.Propumpdata201.Count)
            Dim i = 1
            For i = 1 To myCOTK.PumpData.Propumpdata201.Count
                Dim row As DataGridViewRow = dgvtab201.Rows(i - 1)
                row.Cells(0).Value = myCOTK.PumpData.Propumpdata201(i).Voidfraction1
                row.Cells(1).Value = myCOTK.PumpData.Propumpdata201(i).head
            Next
        End If

        If myCOTK.PumpData.Propumpdata202.Count = 0 Then
            dgvtab202.Rows.Add(1)
            dgvtab202.Rows(0).Cells(0).Value = 0
            dgvtab202.Rows(0).Cells(1).Value = 0
        Else
            dgvtab202.Rows.Add(myCOTK.PumpData.Propumpdata202.Count)
            Dim i = 1
            For i = 1 To myCOTK.PumpData.Propumpdata202.Count
                Dim row As DataGridViewRow = dgvtab202.Rows(i - 1)
                row.Cells(0).Value = myCOTK.PumpData.Propumpdata202(i).Voidfraction2
                row.Cells(1).Value = myCOTK.PumpData.Propumpdata202(i).Torque
            Next
        End If

        TxtTab501.Text = PumpData.TripNumberTab5
        TxtTab502.Text = PumpData.AlphanumericTab5
        TxtTab503.Text = PumpData.NumericTab5
        If myCOTK.PumpData.Propumpdata501.Count = 0 Then
            dgvTab501.Rows.Add(1)
            dgvTab501.Rows(0).Cells(0).Value = 0
            dgvTab501.Rows(0).Cells(1).Value = 0
        Else
            dgvTab501.Rows.Add(myCOTK.PumpData.Propumpdata501.Count)
            Dim i = 1
            For i = 1 To myCOTK.PumpData.Propumpdata501.Count
                Dim row As DataGridViewRow = dgvTab501.Rows(i - 1)
                row.Cells(0).Value = myCOTK.PumpData.Propumpdata501(i).SearchVariable
                row.Cells(1).Value = myCOTK.PumpData.Propumpdata501(i).PumpVelocity
            Next
        End If
    End Sub
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim row As New DataGridViewRow
        Dim cv As New RELAP.SistemasDeUnidades.Conversor
        Dim v1, v2, v3, v4, v5 As Object

        If Not Me.PumpData Is Nothing Then
            Me.PumpData.Propumpdata201.Clear()
        End If
        For i = 0 To dgvtab201.Rows.Count - 2
            row = dgvtab201.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.PumpData.Propumpdata201.Add(row.Index + 1, New pumpdata201(v1, v2))
        Next

        If Not Me.PumpData Is Nothing Then
            Me.PumpData.Propumpdata202.Clear()
        End If
        For i = 0 To dgvtab202.Rows.Count - 2
            row = dgvtab202.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.PumpData.Propumpdata202.Add(row.Index + 1, New pumpdata202(v1, v2))
        Next

        PumpData.TripNumberTab5 = TxtTab501.Text
        PumpData.AlphanumericTab5 = TxtTab502.Text
        PumpData.NumericTab5 = TxtTab503.Text
        If Not Me.PumpData Is Nothing Then
            Me.PumpData.Propumpdata501.Clear()
        End If
        For i = 0 To dgvTab501.Rows.Count - 2
            row = dgvTab501.Rows(i)
            v1 = row.Cells(0).Value
            v2 = row.Cells(1).Value
            Me.PumpData.Propumpdata501.Add(row.Index + 1, New pumpdata501(v1, v2))
        Next
    End Sub
    Private Sub CmbBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBox1.SelectedIndexChanged
        If CmbBox1.SelectedIndex = 0 Then
            PumpData.cmbboxindex1 = "0"
        ElseIf CmbBox1.SelectedIndex = 1 Then
            PumpData.cmbboxindex1 = "1"
        ElseIf CmbBox1.SelectedIndex = 2 Then
            PumpData.cmbboxindex1 = "2"
        ElseIf CmbBox1.SelectedIndex = 3 Then
            PumpData.cmbboxindex1 = "3"
        End If
    End Sub
   
    Private Sub CmbBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBox2.SelectedIndexChanged
        If CmbBox2.SelectedIndex = 0 Then
            PumpData.cmbboxindex2 = "0"
            TextBox6.Hide()
            TextBox7.Hide()
            dgvtab201.Hide()
            dgvtab201.Rows.Clear()
            dgvtab202.Hide()
            dgvtab202.Rows.Clear() 
        ElseIf CmbBox2.SelectedIndex = 1 Then
            PumpData.cmbboxindex2 = "1"
            TextBox6.Show()
            TextBox7.Show()
            dgvtab201.Show()
            dgvtab202.Show()
        ElseIf CmbBox2.SelectedIndex = 2 Then
            PumpData.cmbboxindex2 = "2"
            TextBox6.Hide()
            TextBox7.Hide()
            dgvtab201.Hide()
            dgvtab201.Rows.Clear()
            dgvtab202.Hide()
            dgvtab202.Rows.Clear()
        End If
    End Sub



    Private Sub CmbBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBox3.SelectedIndexChanged
        If CmbBox3.SelectedIndex = 0 Then
            PumpData.cmbboxindex3 = "0"
        ElseIf CmbBox3.SelectedIndex = 1 Then
            PumpData.cmbboxindex3 = "1"
        ElseIf CmbBox3.SelectedIndex = 2 Then
            PumpData.cmbboxindex3 = "2"
        ElseIf CmbBox3.SelectedIndex = 3 Then
            PumpData.cmbboxindex3 = "3"
        ElseIf CmbBox3.SelectedIndex = 4 Then
            PumpData.cmbboxindex3 = "4"
        End If
    End Sub

    Private Sub CmbBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBox4.SelectedIndexChanged
        If CmbBox4.SelectedIndex = 0 Then
            PumpData.cmbboxindex4 = "0"
        ElseIf CmbBox4.SelectedIndex = 1 Then
            PumpData.cmbboxindex4 = "1"
        ElseIf CmbBox4.SelectedIndex = 2 Then
            PumpData.cmbboxindex4 = "2"
        End If
    End Sub

    Private Sub CmbBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBox5.SelectedIndexChanged
        If CmbBox5.SelectedIndex = 0 Then
            PumpData.cmbboxindex5 = "0"
            TextBox8.Hide()
            TextBox9.Hide()
            TextBox10.Hide()
            TextBox13.Hide()
            TxtTab501.Hide()
            TxtTab502.Hide()
            TxtTab503.Hide()
            dgvTab501.Hide()
            dgvTab501.Rows.Clear()
        ElseIf CmbBox5.SelectedIndex = 1 Then
            PumpData.cmbboxindex5 = "1"
            TextBox8.Show()
            TextBox9.Show()
            TextBox10.Show()
            TextBox13.Show()
            TxtTab501.Show()
            TxtTab502.Show()
            TxtTab503.Show()
            dgvTab501.Show()
        ElseIf CmbBox5.SelectedIndex = 2 Then
            PumpData.cmbboxindex5 = "2"
            TextBox8.Hide()
            TextBox9.Hide()
            TextBox10.Hide()
            TextBox13.Hide()
            TxtTab501.Hide()
            TxtTab502.Hide()
            TxtTab503.Hide()
            dgvTab501.Hide()
            dgvTab501.Rows.Clear()
        End If
    End Sub
   
End Class

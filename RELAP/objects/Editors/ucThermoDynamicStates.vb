Public Class ucThermoDynamicStates
    Private Sub cmbothermostates_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cmbothermostates.SelectedValueChanged
        '        Pressure, Liquid Specific Internal Energy, Vapor Specific Internal Energy, Void Fraction
        'Temperature, Static Quality
        'Pressure, Static Quality
        'Pressure, Temperature
        'Pressure, Temperature, Static Quality
        'Temperature, Static Quality, Non condensable Quality
        'Pressure, Liquid Specific Internal Energy, Vapor Specific Internal Energy, Void Fraction, Non condensable Quality
        'Pressure, Liquid Temperature, Vapor Temperature, Void Fraction, Non condensable Quality
        DataGridView1.Columns.Clear()
        If cmbothermostates.SelectedIndex = 0 Then
            DataGridView1.Columns.Add("Pressure", "Pressure")
            DataGridView1.Columns.Add("LiquidSpecificInternalEnergy", "Liquid Specific Internal Energy")
            DataGridView1.Columns.Add("VaporSpecificInternalEnergy", "Vapor Specific Internal Energy")
            DataGridView1.Columns.Add("VoidFraction", "Void Fraction")
        End If
        If cmbothermostates.SelectedIndex = 1 Then
            DataGridView1.Columns.Add("Temperature", "Temperature")
            DataGridView1.Columns.Add("StaticQuality", "Static Quality")

        End If
        If cmbothermostates.SelectedIndex = 2 Then
            DataGridView1.Columns.Add("Pressure", "Pressure")
            DataGridView1.Columns.Add("StaticQuality", "Static Quality")

        End If
        If cmbothermostates.SelectedIndex = 3 Then
            DataGridView1.Columns.Add("Pressure", "Pressure")
            DataGridView1.Columns.Add("Temperature", "Temperature")

        End If
        If cmbothermostates.SelectedIndex = 4 Then
            DataGridView1.Columns.Add("Pressure", "Pressure")
            DataGridView1.Columns.Add("Temperature", "Temperature")
            DataGridView1.Columns.Add("StaticQuality", "Static Quality")
        End If
        If cmbothermostates.SelectedIndex = 5 Then
            DataGridView1.Columns.Add("Pressure", "Pressure")
            DataGridView1.Columns.Add("Temperature", "Temperature")
            DataGridView1.Columns.Add("NoncondensableQuality", "Non condensable Quality")
        End If
    End Sub
End Class

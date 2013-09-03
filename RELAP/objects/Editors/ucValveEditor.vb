Public Class ucValveEditor
    Private _ValveType As ValveType
    Public Property ValveType() As ValveType
        Get
            Return _ValveType
        End Get
        Set(ByVal value As ValveType)
            _ValveType = value
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

    Private Sub CmboboxSelectValve_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmboboxSelectValve.SelectedIndexChanged

        If CmboboxSelectValve.SelectedIndex = 0 Then
            ValveType.ValveTypeName = "chkvlv"
            TableLayoutPanel1.Show()
            TableLayoutPanel2.Hide()
            TableLayoutPanel3.Hide()
        ElseIf CmboboxSelectValve.SelectedIndex = 1 Then
            ValveType.ValveTypeName = "trpvlv"
            TableLayoutPanel1.Hide()
            TableLayoutPanel2.Show()
            TableLayoutPanel3.Hide()
        ElseIf CmboboxSelectValve.SelectedIndex = 2 Then
            ValveType.ValveTypeName = "inrvlv"
            TableLayoutPanel1.Hide()
            TableLayoutPanel2.Hide()
            TableLayoutPanel3.Show()
        End If


    End Sub
    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        ValveType.CheckType = CmbChckValve1.SelectedValue
        ValveType.checkPosition = Cmbchkvalve2.SelectedValue
        ValveType.checkbackpressure = Txtchkvalve3.Text
        ValveType.checkleakratio = Txtchkvalve4.Text

        ValveType.tripvalvetripno = TxtTripvalve1.Text

        ValveType.inertialLatchoption = CmbInertial1.SelectedValue
        ValveType.inertialInitialposition = CmbInertial2.SelectedValue
        ValveType.inertialbackpressure = TxtInertial3.Text
        ValveType.inertialLeakratio = TxtInertial4.Text
        ValveType.inertialinitialangle = TxtInertial5.Text
        ValveType.inertialminangle = TxtInertial6.Text
        ValveType.inertialmaxangle = TxtInertial7.Text
        ValveType.inertialmomentinertia = TxtInertial8.Text
        ValveType.inertialangularvelocity = TxtInertial9.Text
        ValveType.inertialmomentlength = TxtInertial10.Text
        ValveType.inertialradius = TxtInertial11.Text
        ValveType.inertialmass = TxtInertial12.Text


    End Sub


End Class

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
            ValveType.selectValveLoad = "0"
            ValveType.ValveTypeName = "chkvlv"
            TableLayoutPanel1.Show()
            TableLayoutPanel2.Hide()
            TableLayoutPanel3.Hide()
            TableLayoutPanel4.Hide()
            TableLayoutPanel5.Hide()
            TableLayoutPanel6.Hide()
            CmbChckValve1.SelectedIndex = 0
            Cmbchkvalve2.SelectedIndex = 0
            Txtchkvalve3.Text = "0.0"
            Txtchkvalve4.Text = "0.0"
        ElseIf CmboboxSelectValve.SelectedIndex = 1 Then
            ValveType.selectValveLoad = "1"
            ValveType.ValveTypeName = "trpvlv"
            TableLayoutPanel1.Hide()
            TableLayoutPanel2.Show()
            TableLayoutPanel3.Hide()
            TableLayoutPanel4.Hide()
            TableLayoutPanel5.Hide()
            TableLayoutPanel6.Hide()
            TxtTripvalve1.Text = "0"
        ElseIf CmboboxSelectValve.SelectedIndex = 2 Then
            ValveType.selectValveLoad = "2"
            ValveType.ValveTypeName = "inrvlv"
            TableLayoutPanel1.Hide()
            TableLayoutPanel2.Hide()
            TableLayoutPanel3.Show()
            TableLayoutPanel4.Hide()
            TableLayoutPanel5.Hide()
            TableLayoutPanel6.Hide()
            CmbInertial1.SelectedIndex = 0
            CmbInertial2.SelectedIndex = 0
            TxtInertial3.Text = "0.0"
            TxtInertial4.Text = "0.0"
            TxtInertial5.Text = "45.0"
            TxtInertial6.Text = "0.0"
            TxtInertial7.Text = "90.0"
            TxtInertial8.Text = "0.0"
            TxtInertial9.Text = "0.0"
            TxtInertial10.Text = "0.0"
            TxtInertial11.Text = "0.0"
            TxtInertial12.Text = "0.0"
        ElseIf CmboboxSelectValve.SelectedIndex = 3 Then
            ValveType.selectValveLoad = "3"
            ValveType.ValveTypeName = "mtrvlv"
            TableLayoutPanel1.Hide()
            TableLayoutPanel2.Hide()
            TableLayoutPanel3.Hide()
            TableLayoutPanel4.Show()
            TableLayoutPanel5.Hide()
            TableLayoutPanel6.Hide()
            motor1.Text = "0"
            motor2.Text = "0"
            motor3.Text = "0.5"
            motor4.Text = "0.5"
            motor5.Text = "0"
        ElseIf CmboboxSelectValve.SelectedIndex = 4 Then
            ValveType.selectValveLoad = "4"
            ValveType.ValveTypeName = "srvvlv"
            TableLayoutPanel1.Hide()
            TableLayoutPanel2.Hide()
            TableLayoutPanel3.Hide()
            TableLayoutPanel4.Hide()
            TableLayoutPanel5.Show()
            TableLayoutPanel6.Hide()
            Servo1.Text = "0"
            Servo2.Text = "0"
        ElseIf CmboboxSelectValve.SelectedIndex = 5 Then
            ValveType.selectValveLoad = "5"
            ValveType.ValveTypeName = "rlfvlv"
            TableLayoutPanel1.Hide()
            TableLayoutPanel2.Hide()
            TableLayoutPanel3.Hide()
            TableLayoutPanel4.Hide()
            TableLayoutPanel5.Hide()
            TableLayoutPanel6.Show()
            relief1.SelectedIndex = 0
            relief2.Text = "0.0"
            relief3.Text = "0.5"
            relief4.Text = "0.0"
            relief5.Text = "0.5"
            relief6.Text = "0.0"
            relief7.Text = "0.0"
            relief8.Text = "0.0"
            relief9.Text = "0.0"
            relief10.Text = "0.0"
            relief11.Text = "0.5"
            relief12.Text = "0.5"
            relief13.Text = "0.5"
            relief14.Text = "0.0"
            relief15.Text = "0.0"
            relief16.Text = "0.0"
            relief17.Text = "0.0"

        End If


    End Sub
    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        ValveType.CheckType = CmbChckValve1.SelectedIndex.ToString
        ValveType.checkPosition = Cmbchkvalve2.SelectedIndex.ToString
            ValveType.checkbackpressure = Txtchkvalve3.Text
            ValveType.checkleakratio = Txtchkvalve4.Text

            ValveType.tripvalvetripno = TxtTripvalve1.Text

        ValveType.inertialLatchoption = CmbInertial1.SelectedIndex.ToString
        ValveType.inertialInitialposition = CmbInertial2.SelectedIndex.ToString
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

        ValveType.pmotor1 = motor1.Text
        ValveType.pmotor2 = motor2.Text
        ValveType.pmotor3 = motor3.Text
        ValveType.pmotor4 = motor4.Text
        ValveType.pmotor5 = motor5.Text

        ValveType.pservo1 = Servo1.Text
        ValveType.pservo2 = Servo2.Text

        ValveType.prel1 = relief1.SelectedIndex.ToString()
        ValveType.prel2 = relief2.Text
        ValveType.prel3 = relief3.Text
        ValveType.prel4 = relief4.Text
        ValveType.prel5 = relief5.Text
        ValveType.prel6 = relief6.Text
        ValveType.prel7 = relief7.Text
        ValveType.prel8 = relief8.Text
        ValveType.prel9 = relief9.Text
        ValveType.prel10 = relief10.Text
        ValveType.prel11 = relief11.Text
        ValveType.prel12 = relief12.Text
        ValveType.prel13 = relief13.Text
        ValveType.prel14 = relief14.Text
        ValveType.prel15 = relief15.Text
        ValveType.prel16 = relief16.Text
        ValveType.prel17 = relief17.Text
    End Sub


    Private Sub ucValveEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ValveType.selectValveLoad = Nothing Then
        Else : CmboboxSelectValve.SelectedIndex = ValveType.selectValveLoad
        End If

        CmbChckValve1.SelectedIndex = ValveType.CheckType
        Cmbchkvalve2.SelectedIndex = ValveType.checkPosition
        Txtchkvalve3.Text = ValveType.checkbackpressure
        Txtchkvalve4.Text = ValveType.checkleakratio

        TxtTripvalve1.Text = ValveType.tripvalvetripno

        CmbInertial1.SelectedIndex = ValveType.inertialLatchoption
        CmbInertial2.SelectedIndex = ValveType.inertialInitialposition
        TxtInertial3.Text = ValveType.inertialbackpressure
        TxtInertial4.Text = ValveType.inertialLeakratio
        TxtInertial5.Text = ValveType.inertialinitialangle
        TxtInertial6.Text = ValveType.inertialminangle
        TxtInertial7.Text = ValveType.inertialmaxangle
        TxtInertial8.Text = ValveType.inertialmomentinertia
        TxtInertial9.Text = ValveType.inertialangularvelocity
        TxtInertial10.Text = ValveType.inertialmomentlength
        TxtInertial11.Text = ValveType.inertialradius
        TxtInertial12.Text = ValveType.inertialmass

        motor1.Text = ValveType.pmotor1
        motor2.Text = ValveType.pmotor2
        motor3.Text = ValveType.pmotor3
        motor4.Text = ValveType.pmotor4
        motor5.Text = ValveType.pmotor5

        Servo1.Text = ValveType.pservo1
        Servo2.Text = ValveType.pservo2

        relief1.SelectedIndex = ValveType.prel1
        relief2.Text = ValveType.prel2
        relief3.Text = ValveType.prel3
        relief4.Text = ValveType.prel4
        relief5.Text = ValveType.prel5
        relief6.Text = ValveType.prel6
        relief7.Text = ValveType.prel7
        relief8.Text = ValveType.prel8
        relief9.Text = ValveType.prel9
        relief10.Text = ValveType.prel10
        relief11.Text = ValveType.prel11
        relief12.Text = ValveType.prel12
        relief13.Text = ValveType.prel13
        relief14.Text = ValveType.prel14
        relief15.Text = ValveType.prel15
        relief16.Text = ValveType.prel16
        relief17.Text = ValveType.prel17

    End Sub

    
End Class

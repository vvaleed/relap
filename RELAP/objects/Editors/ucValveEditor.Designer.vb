<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucValveEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CmboboxSelectValve = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Cmbchkvalve2 = New System.Windows.Forms.ComboBox()
        Me.CmbChckValve1 = New System.Windows.Forms.ComboBox()
        Me.Txtchkvalve4 = New System.Windows.Forms.TextBox()
        Me.Txtchkvalve3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TxtTripvalve1 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.CmbInertial2 = New System.Windows.Forms.ComboBox()
        Me.CmbInertial1 = New System.Windows.Forms.ComboBox()
        Me.TxtInertial4 = New System.Windows.Forms.TextBox()
        Me.TxtInertial3 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TxtInertial5 = New System.Windows.Forms.TextBox()
        Me.TxtInertial6 = New System.Windows.Forms.TextBox()
        Me.TxtInertial7 = New System.Windows.Forms.TextBox()
        Me.TxtInertial8 = New System.Windows.Forms.TextBox()
        Me.TxtInertial9 = New System.Windows.Forms.TextBox()
        Me.TxtInertial10 = New System.Windows.Forms.TextBox()
        Me.TxtInertial11 = New System.Windows.Forms.TextBox()
        Me.TxtInertial12 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmboboxSelectValve
        '
        Me.CmboboxSelectValve.FormattingEnabled = True
        Me.CmboboxSelectValve.Items.AddRange(New Object() {"Check Valve", "Trip Valve", "Inertial Valve", "Motor Valve", "Servo Valve", "Relief Valve"})
        Me.CmboboxSelectValve.Location = New System.Drawing.Point(21, 29)
        Me.CmboboxSelectValve.Name = "CmboboxSelectValve"
        Me.CmboboxSelectValve.Size = New System.Drawing.Size(121, 21)
        Me.CmboboxSelectValve.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Valve Type"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 296.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Cmbchkvalve2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CmbChckValve1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Txtchkvalve4, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Txtchkvalve3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox4, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox10, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox5, 0, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(21, 67)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(430, 108)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'Cmbchkvalve2
        '
        Me.Cmbchkvalve2.FormattingEnabled = True
        Me.Cmbchkvalve2.Items.AddRange(New Object() {"Open", "Closed"})
        Me.Cmbchkvalve2.Location = New System.Drawing.Point(137, 30)
        Me.Cmbchkvalve2.Name = "Cmbchkvalve2"
        Me.Cmbchkvalve2.Size = New System.Drawing.Size(288, 21)
        Me.Cmbchkvalve2.TabIndex = 20
        '
        'CmbChckValve1
        '
        Me.CmbChckValve1.FormattingEnabled = True
        Me.CmbChckValve1.Items.AddRange(New Object() {"Static Pressure Controlled Check Valve", "Static Pressure/Flow Controlled Check Valve", "Static/Dynamic Pressure Controlled Check Valve"})
        Me.CmbChckValve1.Location = New System.Drawing.Point(137, 3)
        Me.CmbChckValve1.Name = "CmbChckValve1"
        Me.CmbChckValve1.Size = New System.Drawing.Size(289, 21)
        Me.CmbChckValve1.TabIndex = 5
        '
        'Txtchkvalve4
        '
        Me.Txtchkvalve4.Location = New System.Drawing.Point(137, 84)
        Me.Txtchkvalve4.Name = "Txtchkvalve4"
        Me.Txtchkvalve4.Size = New System.Drawing.Size(288, 20)
        Me.Txtchkvalve4.TabIndex = 19
        '
        'Txtchkvalve3
        '
        Me.Txtchkvalve3.Location = New System.Drawing.Point(137, 57)
        Me.Txtchkvalve3.Name = "Txtchkvalve3"
        Me.Txtchkvalve3.Size = New System.Drawing.Size(288, 20)
        Me.Txtchkvalve3.TabIndex = 18
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Location = New System.Drawing.Point(3, 57)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(128, 13)
        Me.TextBox4.TabIndex = 15
        Me.TextBox4.Text = "Closing Back Pressure"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(3, 30)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(128, 13)
        Me.TextBox2.TabIndex = 13
        Me.TextBox2.Text = "Check Valve Initial Position"
        '
        'TextBox10
        '
        Me.TextBox10.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox10.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox10.Location = New System.Drawing.Point(3, 3)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(128, 13)
        Me.TextBox10.TabIndex = 12
        Me.TextBox10.Text = "Check Valve Type"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Location = New System.Drawing.Point(3, 84)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(128, 13)
        Me.TextBox5.TabIndex = 16
        Me.TextBox5.Text = "Leak Ratio"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 296.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TxtTripvalve1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBox8, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(21, 67)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(430, 26)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'TxtTripvalve1
        '
        Me.TxtTripvalve1.Location = New System.Drawing.Point(137, 3)
        Me.TxtTripvalve1.Name = "TxtTripvalve1"
        Me.TxtTripvalve1.Size = New System.Drawing.Size(288, 20)
        Me.TxtTripvalve1.TabIndex = 19
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox8.Location = New System.Drawing.Point(3, 3)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(128, 13)
        Me.TextBox8.TabIndex = 12
        Me.TextBox8.Text = "Trip Number"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 296.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.CmbInertial2, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.CmbInertial1, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial4, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial3, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox6, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox7, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox9, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox11, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial5, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial6, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial7, 1, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial8, 1, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial9, 1, 8)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial10, 1, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial11, 1, 10)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtInertial12, 1, 11)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox20, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox23, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox24, 0, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox21, 0, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox22, 0, 8)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox25, 0, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox26, 0, 10)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox27, 0, 11)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(24, 67)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 12
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333335!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(430, 324)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'CmbInertial2
        '
        Me.CmbInertial2.FormattingEnabled = True
        Me.CmbInertial2.Items.AddRange(New Object() {"Open", "Closed"})
        Me.CmbInertial2.Location = New System.Drawing.Point(137, 29)
        Me.CmbInertial2.Name = "CmbInertial2"
        Me.CmbInertial2.Size = New System.Drawing.Size(288, 21)
        Me.CmbInertial2.TabIndex = 20
        '
        'CmbInertial1
        '
        Me.CmbInertial1.FormattingEnabled = True
        Me.CmbInertial1.Items.AddRange(New Object() {"opens and closes repeatedly", "opens or closes only once"})
        Me.CmbInertial1.Location = New System.Drawing.Point(137, 3)
        Me.CmbInertial1.Name = "CmbInertial1"
        Me.CmbInertial1.Size = New System.Drawing.Size(289, 21)
        Me.CmbInertial1.TabIndex = 5
        '
        'TxtInertial4
        '
        Me.TxtInertial4.Location = New System.Drawing.Point(137, 81)
        Me.TxtInertial4.Name = "TxtInertial4"
        Me.TxtInertial4.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial4.TabIndex = 19
        '
        'TxtInertial3
        '
        Me.TxtInertial3.Location = New System.Drawing.Point(137, 55)
        Me.TxtInertial3.Name = "TxtInertial3"
        Me.TxtInertial3.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial3.TabIndex = 18
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Location = New System.Drawing.Point(3, 55)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(128, 13)
        Me.TextBox6.TabIndex = 15
        Me.TextBox6.Text = "Closing Back Pressure"
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox7.Location = New System.Drawing.Point(3, 29)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(128, 13)
        Me.TextBox7.TabIndex = 13
        Me.TextBox7.Text = "Valve Initial Position"
        '
        'TextBox9
        '
        Me.TextBox9.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox9.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox9.Location = New System.Drawing.Point(3, 3)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(128, 13)
        Me.TextBox9.TabIndex = 12
        Me.TextBox9.Text = "Latch Option"
        '
        'TextBox11
        '
        Me.TextBox11.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox11.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox11.Location = New System.Drawing.Point(3, 81)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(128, 13)
        Me.TextBox11.TabIndex = 16
        Me.TextBox11.Text = "Leak Ratio"
        '
        'TxtInertial5
        '
        Me.TxtInertial5.Location = New System.Drawing.Point(137, 107)
        Me.TxtInertial5.Name = "TxtInertial5"
        Me.TxtInertial5.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial5.TabIndex = 22
        '
        'TxtInertial6
        '
        Me.TxtInertial6.Location = New System.Drawing.Point(137, 133)
        Me.TxtInertial6.Name = "TxtInertial6"
        Me.TxtInertial6.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial6.TabIndex = 21
        '
        'TxtInertial7
        '
        Me.TxtInertial7.Location = New System.Drawing.Point(137, 159)
        Me.TxtInertial7.Name = "TxtInertial7"
        Me.TxtInertial7.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial7.TabIndex = 24
        '
        'TxtInertial8
        '
        Me.TxtInertial8.Location = New System.Drawing.Point(137, 185)
        Me.TxtInertial8.Name = "TxtInertial8"
        Me.TxtInertial8.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial8.TabIndex = 26
        '
        'TxtInertial9
        '
        Me.TxtInertial9.Location = New System.Drawing.Point(137, 211)
        Me.TxtInertial9.Name = "TxtInertial9"
        Me.TxtInertial9.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial9.TabIndex = 23
        '
        'TxtInertial10
        '
        Me.TxtInertial10.Location = New System.Drawing.Point(137, 237)
        Me.TxtInertial10.Name = "TxtInertial10"
        Me.TxtInertial10.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial10.TabIndex = 25
        '
        'TxtInertial11
        '
        Me.TxtInertial11.Location = New System.Drawing.Point(137, 263)
        Me.TxtInertial11.Name = "TxtInertial11"
        Me.TxtInertial11.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial11.TabIndex = 27
        '
        'TxtInertial12
        '
        Me.TxtInertial12.Location = New System.Drawing.Point(137, 289)
        Me.TxtInertial12.Name = "TxtInertial12"
        Me.TxtInertial12.Size = New System.Drawing.Size(288, 20)
        Me.TxtInertial12.TabIndex = 28
        '
        'TextBox20
        '
        Me.TextBox20.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox20.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox20.Location = New System.Drawing.Point(3, 107)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.ReadOnly = True
        Me.TextBox20.Size = New System.Drawing.Size(128, 13)
        Me.TextBox20.TabIndex = 29
        Me.TextBox20.Text = "Initial Flapper Angle"
        '
        'TextBox23
        '
        Me.TextBox23.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox23.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox23.Location = New System.Drawing.Point(3, 133)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.ReadOnly = True
        Me.TextBox23.Size = New System.Drawing.Size(128, 13)
        Me.TextBox23.TabIndex = 32
        Me.TextBox23.Text = "Minimum Flapper Angle"
        '
        'TextBox24
        '
        Me.TextBox24.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox24.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox24.Location = New System.Drawing.Point(3, 159)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.ReadOnly = True
        Me.TextBox24.Size = New System.Drawing.Size(128, 13)
        Me.TextBox24.TabIndex = 33
        Me.TextBox24.Text = "Maximum Flapper Angle"
        '
        'TextBox21
        '
        Me.TextBox21.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox21.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox21.Location = New System.Drawing.Point(3, 185)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.ReadOnly = True
        Me.TextBox21.Size = New System.Drawing.Size(128, 13)
        Me.TextBox21.TabIndex = 30
        Me.TextBox21.Text = "Moment of Inertia"
        '
        'TextBox22
        '
        Me.TextBox22.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox22.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox22.Location = New System.Drawing.Point(3, 211)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.ReadOnly = True
        Me.TextBox22.Size = New System.Drawing.Size(128, 13)
        Me.TextBox22.TabIndex = 31
        Me.TextBox22.Text = "Initial Angular Velocity"
        '
        'TextBox25
        '
        Me.TextBox25.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox25.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox25.Location = New System.Drawing.Point(3, 237)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.ReadOnly = True
        Me.TextBox25.Size = New System.Drawing.Size(128, 13)
        Me.TextBox25.TabIndex = 34
        Me.TextBox25.Text = "Moment Length of Flapper"
        '
        'TextBox26
        '
        Me.TextBox26.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox26.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox26.Location = New System.Drawing.Point(3, 263)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.ReadOnly = True
        Me.TextBox26.Size = New System.Drawing.Size(128, 13)
        Me.TextBox26.TabIndex = 35
        Me.TextBox26.Text = "Radius of Flapper"
        '
        'TextBox27
        '
        Me.TextBox27.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox27.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox27.Location = New System.Drawing.Point(3, 289)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.ReadOnly = True
        Me.TextBox27.Size = New System.Drawing.Size(128, 13)
        Me.TextBox27.TabIndex = 36
        Me.TextBox27.Text = "Mass of Flapper"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(379, 397)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 7
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'ucValveEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmboboxSelectValve)
        Me.Name = "ucValveEditor"
        Me.Size = New System.Drawing.Size(579, 628)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmboboxSelectValve As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cmbchkvalve2 As System.Windows.Forms.ComboBox
    Friend WithEvents CmbChckValve1 As System.Windows.Forms.ComboBox
    Friend WithEvents Txtchkvalve4 As System.Windows.Forms.TextBox
    Friend WithEvents Txtchkvalve3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TxtTripvalve1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CmbInertial2 As System.Windows.Forms.ComboBox
    Friend WithEvents CmbInertial1 As System.Windows.Forms.ComboBox
    Friend WithEvents TxtInertial4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtInertial3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TxtInertial5 As System.Windows.Forms.TextBox
    Friend WithEvents TxtInertial6 As System.Windows.Forms.TextBox
    Friend WithEvents TxtInertial7 As System.Windows.Forms.TextBox
    Friend WithEvents TxtInertial8 As System.Windows.Forms.TextBox
    Friend WithEvents TxtInertial9 As System.Windows.Forms.TextBox
    Friend WithEvents TxtInertial10 As System.Windows.Forms.TextBox
    Friend WithEvents TxtInertial11 As System.Windows.Forms.TextBox
    Friend WithEvents TxtInertial12 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox27 As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button

End Class

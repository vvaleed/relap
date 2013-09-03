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
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TxtTripvalve1 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(24, 181)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(430, 26)
        Me.TableLayoutPanel2.TabIndex = 5
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
        'TxtTripvalve1
        '
        Me.TxtTripvalve1.Location = New System.Drawing.Point(137, 3)
        Me.TxtTripvalve1.Name = "TxtTripvalve1"
        Me.TxtTripvalve1.Size = New System.Drawing.Size(288, 20)
        Me.TxtTripvalve1.TabIndex = 19
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 296.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.ComboBox1, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.ComboBox2, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox1, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox3, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox6, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox7, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox9, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox11, 0, 3)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(489, 13)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(430, 108)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Open", "Closed"})
        Me.ComboBox1.Location = New System.Drawing.Point(137, 30)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(288, 21)
        Me.ComboBox1.TabIndex = 20
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Static Pressure Controlled Check Valve", "Static Pressure/Flow Controlled Check Valve", "Static/Dynamic Pressure Controlled Check Valve"})
        Me.ComboBox2.Location = New System.Drawing.Point(137, 3)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(289, 21)
        Me.ComboBox2.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(137, 84)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(288, 20)
        Me.TextBox1.TabIndex = 19
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(137, 57)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(288, 20)
        Me.TextBox3.TabIndex = 18
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Location = New System.Drawing.Point(3, 57)
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
        Me.TextBox7.Location = New System.Drawing.Point(3, 30)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(128, 13)
        Me.TextBox7.TabIndex = 13
        Me.TextBox7.Text = "Check Valve Initial Position"
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
        Me.TextBox9.Text = "Check Valve Type"
        '
        'TextBox11
        '
        Me.TextBox11.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox11.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox11.Location = New System.Drawing.Point(3, 84)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(128, 13)
        Me.TextBox11.TabIndex = 16
        Me.TextBox11.Text = "Leak Ratio"
        '
        'ucValveEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CmboboxSelectValve)
        Me.Name = "ucValveEditor"
        Me.Size = New System.Drawing.Size(998, 488)
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
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox

End Class

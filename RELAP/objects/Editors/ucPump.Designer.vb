<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPump
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
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab11 = New System.Windows.Forms.TabPage()
        Me.CmbBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.dgvtab202 = New System.Windows.Forms.DataGridView()
        Me.Voidfraction2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Torque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvtab201 = New System.Windows.Forms.DataGridView()
        Me.Voidfraction1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.head = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CmbBox2 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Tab3 = New System.Windows.Forms.TabPage()
        Me.CmbBox3 = New System.Windows.Forms.ComboBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Tab4 = New System.Windows.Forms.TabPage()
        Me.CmbBox4 = New System.Windows.Forms.ComboBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Tab5 = New System.Windows.Forms.TabPage()
        Me.CmbBox5 = New System.Windows.Forms.ComboBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.Tab11.SuspendLayout()
        Me.Tab2.SuspendLayout()
        CType(Me.dgvtab202, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvtab201, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3.SuspendLayout()
        Me.Tab4.SuspendLayout()
        Me.Tab5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tab11)
        Me.TabControl1.Controls.Add(Me.Tab2)
        Me.TabControl1.Controls.Add(Me.Tab3)
        Me.TabControl1.Controls.Add(Me.Tab4)
        Me.TabControl1.Controls.Add(Me.Tab5)
        Me.TabControl1.Location = New System.Drawing.Point(3, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(770, 440)
        Me.TabControl1.TabIndex = 0
        '
        'Tab11
        '
        Me.Tab11.Controls.Add(Me.CmbBox1)
        Me.Tab11.Controls.Add(Me.TextBox3)
        Me.Tab11.Location = New System.Drawing.Point(4, 22)
        Me.Tab11.Name = "Tab11"
        Me.Tab11.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab11.Size = New System.Drawing.Size(759, 429)
        Me.Tab11.TabIndex = 0
        Me.Tab11.Text = "Pump Table Data Indicator"
        Me.Tab11.UseVisualStyleBackColor = True
        '
        'CmbBox1
        '
        Me.CmbBox1.FormattingEnabled = True
        Me.CmbBox1.Items.AddRange(New Object() {"Use built in data for the Westinghouse pump", "Use built in data for the Bingham pump", "Enter Single Phase Homologous Tables", "Obtain Single Phase Tables from the pump component"})
        Me.CmbBox1.Location = New System.Drawing.Point(17, 34)
        Me.CmbBox1.Name = "CmbBox1"
        Me.CmbBox1.Size = New System.Drawing.Size(333, 21)
        Me.CmbBox1.TabIndex = 27
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(17, 15)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(183, 13)
        Me.TextBox3.TabIndex = 26
        Me.TextBox3.Text = "Pump Table Data Indicator"
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.TextBox7)
        Me.Tab2.Controls.Add(Me.TextBox6)
        Me.Tab2.Controls.Add(Me.dgvtab202)
        Me.Tab2.Controls.Add(Me.dgvtab201)
        Me.Tab2.Controls.Add(Me.CmbBox2)
        Me.Tab2.Controls.Add(Me.TextBox1)
        Me.Tab2.Location = New System.Drawing.Point(4, 22)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2.Size = New System.Drawing.Size(759, 429)
        Me.Tab2.TabIndex = 1
        Me.Tab2.Text = "Two Phase Index"
        Me.Tab2.UseVisualStyleBackColor = True
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(20, 66)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(183, 13)
        Me.TextBox7.TabIndex = 33
        Me.TextBox7.Text = "Pump Head Multiplier Table"
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(309, 66)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(183, 13)
        Me.TextBox6.TabIndex = 32
        Me.TextBox6.Text = "Pump Torque Multiplier Table"
        '
        'dgvtab202
        '
        Me.dgvtab202.AccessibleDescription = "                            "
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtab202.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvtab202.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtab202.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Voidfraction2, Me.Torque})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvtab202.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgvtab202.Location = New System.Drawing.Point(309, 85)
        Me.dgvtab202.Name = "dgvtab202"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvtab202.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvtab202.Size = New System.Drawing.Size(256, 316)
        Me.dgvtab202.TabIndex = 31
        '
        'Voidfraction2
        '
        Me.Voidfraction2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Voidfraction2.HeaderText = "Void Fraction"
        Me.Voidfraction2.Name = "Voidfraction2"
        '
        'Torque
        '
        Me.Torque.HeaderText = "Torque"
        Me.Torque.Name = "Torque"
        '
        'dgvtab201
        '
        Me.dgvtab201.AccessibleDescription = "                            "
        Me.dgvtab201.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtab201.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Voidfraction1, Me.head})
        Me.dgvtab201.Location = New System.Drawing.Point(20, 85)
        Me.dgvtab201.Name = "dgvtab201"
        Me.dgvtab201.Size = New System.Drawing.Size(256, 316)
        Me.dgvtab201.TabIndex = 30
        '
        'Voidfraction1
        '
        Me.Voidfraction1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Voidfraction1.HeaderText = "Void Fraction"
        Me.Voidfraction1.Name = "Voidfraction1"
        '
        'head
        '
        Me.head.HeaderText = "Head"
        Me.head.Name = "head"
        '
        'CmbBox2
        '
        Me.CmbBox2.FormattingEnabled = True
        Me.CmbBox2.Items.AddRange(New Object() {"Do not Use Two Phase Option", "Enter Two Phase Multiplier Tables", "Obtain Two Phase Tables from the pump component"})
        Me.CmbBox2.Location = New System.Drawing.Point(20, 34)
        Me.CmbBox2.Name = "CmbBox2"
        Me.CmbBox2.Size = New System.Drawing.Size(299, 21)
        Me.CmbBox2.TabIndex = 29
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(20, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(183, 13)
        Me.TextBox1.TabIndex = 28
        Me.TextBox1.Text = "Two Phase Index"
        '
        'Tab3
        '
        Me.Tab3.Controls.Add(Me.CmbBox3)
        Me.Tab3.Controls.Add(Me.TextBox2)
        Me.Tab3.Location = New System.Drawing.Point(4, 22)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab3.Size = New System.Drawing.Size(759, 429)
        Me.Tab3.TabIndex = 2
        Me.Tab3.Text = "Two Phase Difference Table Index"
        Me.Tab3.UseVisualStyleBackColor = True
        '
        'CmbBox3
        '
        Me.CmbBox3.FormattingEnabled = True
        Me.CmbBox3.Items.AddRange(New Object() {"Do not use two phase difference table", "Use built in data for the Westinghouse pump", "Use built in data for the Bingham pump", "Enter Two Phase Difference Tables", "Obtain Two Phase Difference Tables from the pump component"})
        Me.CmbBox3.Location = New System.Drawing.Point(17, 37)
        Me.CmbBox3.Name = "CmbBox3"
        Me.CmbBox3.Size = New System.Drawing.Size(309, 21)
        Me.CmbBox3.TabIndex = 29
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(17, 18)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(219, 13)
        Me.TextBox2.TabIndex = 28
        Me.TextBox2.Text = "Two Phase Difference Table Index"
        '
        'Tab4
        '
        Me.Tab4.Controls.Add(Me.CmbBox4)
        Me.Tab4.Controls.Add(Me.TextBox4)
        Me.Tab4.Location = New System.Drawing.Point(4, 22)
        Me.Tab4.Name = "Tab4"
        Me.Tab4.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab4.Size = New System.Drawing.Size(762, 414)
        Me.Tab4.TabIndex = 3
        Me.Tab4.Text = "Pump Motor Torque Table Index"
        Me.Tab4.UseVisualStyleBackColor = True
        '
        'CmbBox4
        '
        Me.CmbBox4.FormattingEnabled = True
        Me.CmbBox4.Items.AddRange(New Object() {"Do not use These tables", "Enter Motor Torque Tables", "Obtain Motor Torque Tables from the pump component"})
        Me.CmbBox4.Location = New System.Drawing.Point(17, 34)
        Me.CmbBox4.Name = "CmbBox4"
        Me.CmbBox4.Size = New System.Drawing.Size(324, 21)
        Me.CmbBox4.TabIndex = 29
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(17, 15)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(183, 13)
        Me.TextBox4.TabIndex = 28
        Me.TextBox4.Text = "Pump Motor Torque Table Index" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Tab5
        '
        Me.Tab5.Controls.Add(Me.CmbBox5)
        Me.Tab5.Controls.Add(Me.TextBox5)
        Me.Tab5.Location = New System.Drawing.Point(4, 22)
        Me.Tab5.Name = "Tab5"
        Me.Tab5.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab5.Size = New System.Drawing.Size(762, 414)
        Me.Tab5.TabIndex = 4
        Me.Tab5.Text = "Time Dependent Pump Velocity Index"
        Me.Tab5.UseVisualStyleBackColor = True
        '
        'CmbBox5
        '
        Me.CmbBox5.FormattingEnabled = True
        Me.CmbBox5.Items.AddRange(New Object() {"Do not use Time Dependent pump velocity Tables", "Enter Time Dependent pump velocity Tables", "Obtain Time Dependent pump velocity Tables from the pump component"})
        Me.CmbBox5.Location = New System.Drawing.Point(18, 37)
        Me.CmbBox5.Name = "CmbBox5"
        Me.CmbBox5.Size = New System.Drawing.Size(340, 21)
        Me.CmbBox5.TabIndex = 29
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(18, 18)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(225, 13)
        Me.TextBox5.TabIndex = 28
        Me.TextBox5.Text = "Time Dependent Pump Velocity Index"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(666, 464)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'ucPump
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ucPump"
        Me.Size = New System.Drawing.Size(776, 503)
        Me.TabControl1.ResumeLayout(False)
        Me.Tab11.ResumeLayout(False)
        Me.Tab11.PerformLayout()
        Me.Tab2.ResumeLayout(False)
        Me.Tab2.PerformLayout()
        CType(Me.dgvtab202, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvtab201, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3.ResumeLayout(False)
        Me.Tab3.PerformLayout()
        Me.Tab4.ResumeLayout(False)
        Me.Tab4.PerformLayout()
        Me.Tab5.ResumeLayout(False)
        Me.Tab5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tab11 As System.Windows.Forms.TabPage
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Friend WithEvents Tab3 As System.Windows.Forms.TabPage
    Friend WithEvents Tab4 As System.Windows.Forms.TabPage
    Friend WithEvents Tab5 As System.Windows.Forms.TabPage
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents CmbBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents CmbBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CmbBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents CmbBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents CmbBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents dgvtab202 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvtab201 As System.Windows.Forms.DataGridView
    Friend WithEvents Voidfraction2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Torque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Voidfraction1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents head As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

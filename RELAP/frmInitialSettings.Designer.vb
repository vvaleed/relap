<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInitialSettings
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form overrides dispose to clean up the component list.
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
        Me.chklistboxCondensibleGases = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optHeavyWater = New System.Windows.Forms.RadioButton()
        Me.optWater = New System.Windows.Forms.RadioButton()
        Me.optDefaultFluid = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtendtime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtminsteptime = New System.Windows.Forms.TextBox()
        Me.txtmaxsteptime = New System.Windows.Forms.TextBox()
        Me.txtcontroloption = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRestartFrequency = New System.Windows.Forms.TextBox()
        Me.txtMajorFrequency = New System.Windows.Forms.TextBox()
        Me.txtMinorFrequency = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chklistboxCondensibleGases
        '
        Me.chklistboxCondensibleGases.FormattingEnabled = True
        Me.chklistboxCondensibleGases.Items.AddRange(New Object() {"argon", "helium", "hydrogen", "nitrogen", "xenon", "krypton", "air", "sf6"})
        Me.chklistboxCondensibleGases.Location = New System.Drawing.Point(15, 25)
        Me.chklistboxCondensibleGases.Name = "chklistboxCondensibleGases"
        Me.chklistboxCondensibleGases.Size = New System.Drawing.Size(112, 124)
        Me.chklistboxCondensibleGases.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Condensible Gases"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optHeavyWater)
        Me.GroupBox1.Controls.Add(Me.optWater)
        Me.GroupBox1.Controls.Add(Me.optDefaultFluid)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(151, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(109, 101)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fluid"
        '
        'optHeavyWater
        '
        Me.optHeavyWater.AutoSize = True
        Me.optHeavyWater.Location = New System.Drawing.Point(7, 66)
        Me.optHeavyWater.Name = "optHeavyWater"
        Me.optHeavyWater.Size = New System.Drawing.Size(88, 17)
        Me.optHeavyWater.TabIndex = 0
        Me.optHeavyWater.TabStop = True
        Me.optHeavyWater.Text = "Heavy Water"
        Me.optHeavyWater.UseVisualStyleBackColor = True
        '
        'optWater
        '
        Me.optWater.AutoSize = True
        Me.optWater.Location = New System.Drawing.Point(7, 43)
        Me.optWater.Name = "optWater"
        Me.optWater.Size = New System.Drawing.Size(54, 17)
        Me.optWater.TabIndex = 0
        Me.optWater.TabStop = True
        Me.optWater.Text = "Water"
        Me.optWater.UseVisualStyleBackColor = True
        '
        'optDefaultFluid
        '
        Me.optDefaultFluid.AutoSize = True
        Me.optDefaultFluid.Checked = True
        Me.optDefaultFluid.Location = New System.Drawing.Point(7, 20)
        Me.optDefaultFluid.Name = "optDefaultFluid"
        Me.optDefaultFluid.Size = New System.Drawing.Size(84, 17)
        Me.optDefaultFluid.TabIndex = 0
        Me.optDefaultFluid.TabStop = True
        Me.optDefaultFluid.Text = "Default Fluid"
        Me.optDefaultFluid.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(151, 132)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(76, 17)
        Me.CheckBox1.TabIndex = 22
        Me.CheckBox1.Text = "Has Boron"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 184)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "End Time"
        '
        'txtendtime
        '
        Me.txtendtime.Location = New System.Drawing.Point(142, 181)
        Me.txtendtime.Name = "txtendtime"
        Me.txtendtime.Size = New System.Drawing.Size(100, 20)
        Me.txtendtime.TabIndex = 24
        Me.txtendtime.Text = "20"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Minimum Step Time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Maximum Step Time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Control Option"
        '
        'txtminsteptime
        '
        Me.txtminsteptime.Location = New System.Drawing.Point(142, 213)
        Me.txtminsteptime.Name = "txtminsteptime"
        Me.txtminsteptime.Size = New System.Drawing.Size(100, 20)
        Me.txtminsteptime.TabIndex = 28
        Me.txtminsteptime.Text = "1e-6"
        '
        'txtmaxsteptime
        '
        Me.txtmaxsteptime.Location = New System.Drawing.Point(142, 243)
        Me.txtmaxsteptime.Name = "txtmaxsteptime"
        Me.txtmaxsteptime.Size = New System.Drawing.Size(100, 20)
        Me.txtmaxsteptime.TabIndex = 29
        Me.txtmaxsteptime.Text = "0.05"
        '
        'txtcontroloption
        '
        Me.txtcontroloption.Location = New System.Drawing.Point(142, 278)
        Me.txtcontroloption.Name = "txtcontroloption"
        Me.txtcontroloption.Size = New System.Drawing.Size(100, 20)
        Me.txtcontroloption.TabIndex = 30
        Me.txtcontroloption.Text = "3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 315)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Minor Edit Frequency"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 347)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Major Edit Frequency"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 377)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Restart Frequency"
        '
        'txtRestartFrequency
        '
        Me.txtRestartFrequency.Location = New System.Drawing.Point(142, 374)
        Me.txtRestartFrequency.Name = "txtRestartFrequency"
        Me.txtRestartFrequency.Size = New System.Drawing.Size(100, 20)
        Me.txtRestartFrequency.TabIndex = 34
        Me.txtRestartFrequency.Text = "2000"
        '
        'txtMajorFrequency
        '
        Me.txtMajorFrequency.Location = New System.Drawing.Point(142, 344)
        Me.txtMajorFrequency.Name = "txtMajorFrequency"
        Me.txtMajorFrequency.Size = New System.Drawing.Size(100, 20)
        Me.txtMajorFrequency.TabIndex = 35
        Me.txtMajorFrequency.Text = "50"
        '
        'txtMinorFrequency
        '
        Me.txtMinorFrequency.Location = New System.Drawing.Point(142, 312)
        Me.txtMinorFrequency.Name = "txtMinorFrequency"
        Me.txtMinorFrequency.Size = New System.Drawing.Size(100, 20)
        Me.txtMinorFrequency.TabIndex = 36
        Me.txtMinorFrequency.Text = "1"
        '
        'frmInitialSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 405)
        Me.Controls.Add(Me.txtMinorFrequency)
        Me.Controls.Add(Me.txtMajorFrequency)
        Me.Controls.Add(Me.txtRestartFrequency)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtcontroloption)
        Me.Controls.Add(Me.txtmaxsteptime)
        Me.Controls.Add(Me.txtminsteptime)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtendtime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chklistboxCondensibleGases)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmInitialSettings"
        Me.Text = "Initial Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chklistboxCondensibleGases As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optHeavyWater As System.Windows.Forms.RadioButton
    Friend WithEvents optWater As System.Windows.Forms.RadioButton
    Friend WithEvents optDefaultFluid As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtendtime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtminsteptime As System.Windows.Forms.TextBox
    Friend WithEvents txtmaxsteptime As System.Windows.Forms.TextBox
    Friend WithEvents txtcontroloption As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRestartFrequency As System.Windows.Forms.TextBox
    Friend WithEvents txtMajorFrequency As System.Windows.Forms.TextBox
    Friend WithEvents txtMinorFrequency As System.Windows.Forms.TextBox
End Class

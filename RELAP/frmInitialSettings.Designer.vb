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
        Me.chklistboxFluid = New System.Windows.Forms.GroupBox()
        Me.optHeavyWater = New System.Windows.Forms.RadioButton()
        Me.optWater = New System.Windows.Forms.RadioButton()
        Me.optDefaultFluid = New System.Windows.Forms.RadioButton()
        Me.chklistboxBoron = New System.Windows.Forms.CheckBox()
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboDebrisBreakup = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboDebrisSource = New System.Windows.Forms.ComboBox()
        Me.txtCoupleTimeStep = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMaxHydraulicStep = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboDebrisVolume = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboCoupleStyle = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chklistboxFluid.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Non Condensible Gases"
        '
        'chklistboxFluid
        '
        Me.chklistboxFluid.Controls.Add(Me.optHeavyWater)
        Me.chklistboxFluid.Controls.Add(Me.optWater)
        Me.chklistboxFluid.Controls.Add(Me.optDefaultFluid)
        Me.chklistboxFluid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklistboxFluid.Location = New System.Drawing.Point(167, 25)
        Me.chklistboxFluid.Name = "chklistboxFluid"
        Me.chklistboxFluid.Size = New System.Drawing.Size(109, 101)
        Me.chklistboxFluid.TabIndex = 21
        Me.chklistboxFluid.TabStop = False
        Me.chklistboxFluid.Text = "Fluid"
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
        'chklistboxBoron
        '
        Me.chklistboxBoron.AutoSize = True
        Me.chklistboxBoron.Location = New System.Drawing.Point(174, 132)
        Me.chklistboxBoron.Name = "chklistboxBoron"
        Me.chklistboxBoron.Size = New System.Drawing.Size(76, 17)
        Me.chklistboxBoron.TabIndex = 22
        Me.chklistboxBoron.Text = "Has Boron"
        Me.chklistboxBoron.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "End Time"
        '
        'txtendtime
        '
        Me.txtendtime.Location = New System.Drawing.Point(142, 158)
        Me.txtendtime.Name = "txtendtime"
        Me.txtendtime.Size = New System.Drawing.Size(100, 20)
        Me.txtendtime.TabIndex = 24
        Me.txtendtime.Text = "20.0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Minimum Step Time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Maximum Step Time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(32, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Control Option"
        '
        'txtminsteptime
        '
        Me.txtminsteptime.Location = New System.Drawing.Point(142, 190)
        Me.txtminsteptime.Name = "txtminsteptime"
        Me.txtminsteptime.Size = New System.Drawing.Size(100, 20)
        Me.txtminsteptime.TabIndex = 28
        Me.txtminsteptime.Text = "1.0e-6"
        '
        'txtmaxsteptime
        '
        Me.txtmaxsteptime.Location = New System.Drawing.Point(142, 220)
        Me.txtmaxsteptime.Name = "txtmaxsteptime"
        Me.txtmaxsteptime.Size = New System.Drawing.Size(100, 20)
        Me.txtmaxsteptime.TabIndex = 29
        Me.txtmaxsteptime.Text = "0.05"
        '
        'txtcontroloption
        '
        Me.txtcontroloption.Location = New System.Drawing.Point(142, 255)
        Me.txtcontroloption.Name = "txtcontroloption"
        Me.txtcontroloption.Size = New System.Drawing.Size(100, 20)
        Me.txtcontroloption.TabIndex = 30
        Me.txtcontroloption.Text = "3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 292)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Minor Edit Frequency"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 324)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Major Edit Frequency"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 354)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Restart Frequency"
        '
        'txtRestartFrequency
        '
        Me.txtRestartFrequency.Location = New System.Drawing.Point(142, 351)
        Me.txtRestartFrequency.Name = "txtRestartFrequency"
        Me.txtRestartFrequency.Size = New System.Drawing.Size(100, 20)
        Me.txtRestartFrequency.TabIndex = 34
        Me.txtRestartFrequency.Text = "2000"
        '
        'txtMajorFrequency
        '
        Me.txtMajorFrequency.Location = New System.Drawing.Point(142, 321)
        Me.txtMajorFrequency.Name = "txtMajorFrequency"
        Me.txtMajorFrequency.Size = New System.Drawing.Size(100, 20)
        Me.txtMajorFrequency.TabIndex = 35
        Me.txtMajorFrequency.Text = "50"
        '
        'txtMinorFrequency
        '
        Me.txtMinorFrequency.Location = New System.Drawing.Point(142, 289)
        Me.txtMinorFrequency.Name = "txtMinorFrequency"
        Me.txtMinorFrequency.Size = New System.Drawing.Size(100, 20)
        Me.txtMinorFrequency.TabIndex = 36
        Me.txtMinorFrequency.Text = "1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cboCoupleStyle)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 377)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(261, 206)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Couple Settings"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboDebrisBreakup)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cboDebrisSource)
        Me.GroupBox2.Controls.Add(Me.txtCoupleTimeStep)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtMaxHydraulicStep)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cboDebrisVolume)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(223, 147)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Debris Bed"
        '
        'cboDebrisBreakup
        '
        Me.cboDebrisBreakup.FormattingEnabled = True
        Me.cboDebrisBreakup.Items.AddRange(New Object() {"Debris may be broken up", "Debris is never broken up"})
        Me.cboDebrisBreakup.Location = New System.Drawing.Point(104, 73)
        Me.cboDebrisBreakup.Name = "cboDebrisBreakup"
        Me.cboDebrisBreakup.Size = New System.Drawing.Size(100, 21)
        Me.cboDebrisBreakup.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Break Up"
        '
        'cboDebrisSource
        '
        Me.cboDebrisSource.FormattingEnabled = True
        Me.cboDebrisSource.Items.AddRange(New Object() {"No sluming", "Debris received from core components", "User-defined slumping", "Depends on components above mesh", "Corium hydro model"})
        Me.cboDebrisSource.Location = New System.Drawing.Point(104, 46)
        Me.cboDebrisSource.Name = "cboDebrisSource"
        Me.cboDebrisSource.Size = New System.Drawing.Size(100, 21)
        Me.cboDebrisSource.TabIndex = 0
        '
        'txtCoupleTimeStep
        '
        Me.txtCoupleTimeStep.Location = New System.Drawing.Point(132, 126)
        Me.txtCoupleTimeStep.Name = "txtCoupleTimeStep"
        Me.txtCoupleTimeStep.Size = New System.Drawing.Size(72, 20)
        Me.txtCoupleTimeStep.TabIndex = 34
        Me.txtCoupleTimeStep.Text = "0.5"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 129)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Couple Step"
        '
        'txtMaxHydraulicStep
        '
        Me.txtMaxHydraulicStep.Location = New System.Drawing.Point(132, 100)
        Me.txtMaxHydraulicStep.Name = "txtMaxHydraulicStep"
        Me.txtMaxHydraulicStep.Size = New System.Drawing.Size(72, 20)
        Me.txtMaxHydraulicStep.TabIndex = 34
        Me.txtMaxHydraulicStep.Text = "10"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Max Hydraulic Steps"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Source"
        '
        'cboDebrisVolume
        '
        Me.cboDebrisVolume.FormattingEnabled = True
        Me.cboDebrisVolume.Items.AddRange(New Object() {"old", "new"})
        Me.cboDebrisVolume.Location = New System.Drawing.Point(104, 19)
        Me.cboDebrisVolume.Name = "cboDebrisVolume"
        Me.cboDebrisVolume.Size = New System.Drawing.Size(100, 21)
        Me.cboDebrisVolume.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Volume"
        '
        'cboCoupleStyle
        '
        Me.cboCoupleStyle.FormattingEnabled = True
        Me.cboCoupleStyle.Items.AddRange(New Object() {"old", "new"})
        Me.cboCoupleStyle.Location = New System.Drawing.Point(127, 19)
        Me.cboCoupleStyle.Name = "cboCoupleStyle"
        Me.cboCoupleStyle.Size = New System.Drawing.Size(100, 21)
        Me.cboCoupleStyle.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Style"
        '
        'frmInitialSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 589)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.Controls.Add(Me.chklistboxBoron)
        Me.Controls.Add(Me.chklistboxFluid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chklistboxCondensibleGases)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmInitialSettings"
        Me.Text = "Initial Settings"
        Me.chklistboxFluid.ResumeLayout(False)
        Me.chklistboxFluid.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chklistboxCondensibleGases As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chklistboxFluid As System.Windows.Forms.GroupBox
    Friend WithEvents optHeavyWater As System.Windows.Forms.RadioButton
    Friend WithEvents optWater As System.Windows.Forms.RadioButton
    Friend WithEvents optDefaultFluid As System.Windows.Forms.RadioButton
    Friend WithEvents chklistboxBoron As System.Windows.Forms.CheckBox
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCoupleStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDebrisBreakup As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboDebrisSource As System.Windows.Forms.ComboBox
    Friend WithEvents txtCoupleTimeStep As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMaxHydraulicStep As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboDebrisVolume As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class

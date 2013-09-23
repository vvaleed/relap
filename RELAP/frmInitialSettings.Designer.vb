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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.DoubleInput3 = New DevComponents.Editors.DoubleInput()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DoubleInput2 = New DevComponents.Editors.DoubleInput()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCPUTimeAllocated = New DevComponents.Editors.DoubleInput()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCPURemaining2 = New DevComponents.Editors.DoubleInput()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCPURemaining1 = New DevComponents.Editors.DoubleInput()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chklistboxFluid.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DoubleInput3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DoubleInput2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCPUTimeAllocated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCPURemaining2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCPURemaining1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label2.Location = New System.Drawing.Point(20, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "End Time"
        '
        'txtendtime
        '
        Me.txtendtime.Location = New System.Drawing.Point(130, 32)
        Me.txtendtime.Name = "txtendtime"
        Me.txtendtime.Size = New System.Drawing.Size(100, 20)
        Me.txtendtime.TabIndex = 24
        Me.txtendtime.Text = "20.0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Minimum Step Time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Maximum Step Time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Control Option"
        '
        'txtminsteptime
        '
        Me.txtminsteptime.Location = New System.Drawing.Point(130, 64)
        Me.txtminsteptime.Name = "txtminsteptime"
        Me.txtminsteptime.Size = New System.Drawing.Size(100, 20)
        Me.txtminsteptime.TabIndex = 28
        Me.txtminsteptime.Text = "1.0e-6"
        '
        'txtmaxsteptime
        '
        Me.txtmaxsteptime.Location = New System.Drawing.Point(130, 94)
        Me.txtmaxsteptime.Name = "txtmaxsteptime"
        Me.txtmaxsteptime.Size = New System.Drawing.Size(100, 20)
        Me.txtmaxsteptime.TabIndex = 29
        Me.txtmaxsteptime.Text = "0.05"
        '
        'txtcontroloption
        '
        Me.txtcontroloption.Location = New System.Drawing.Point(130, 129)
        Me.txtcontroloption.Name = "txtcontroloption"
        Me.txtcontroloption.Size = New System.Drawing.Size(100, 20)
        Me.txtcontroloption.TabIndex = 30
        Me.txtcontroloption.Text = "3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Minor Edit Frequency"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 198)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Major Edit Frequency"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Restart Frequency"
        '
        'txtRestartFrequency
        '
        Me.txtRestartFrequency.Location = New System.Drawing.Point(130, 225)
        Me.txtRestartFrequency.Name = "txtRestartFrequency"
        Me.txtRestartFrequency.Size = New System.Drawing.Size(100, 20)
        Me.txtRestartFrequency.TabIndex = 34
        Me.txtRestartFrequency.Text = "2000"
        '
        'txtMajorFrequency
        '
        Me.txtMajorFrequency.Location = New System.Drawing.Point(130, 195)
        Me.txtMajorFrequency.Name = "txtMajorFrequency"
        Me.txtMajorFrequency.Size = New System.Drawing.Size(100, 20)
        Me.txtMajorFrequency.TabIndex = 35
        Me.txtMajorFrequency.Text = "50"
        '
        'txtMinorFrequency
        '
        Me.txtMinorFrequency.Location = New System.Drawing.Point(130, 163)
        Me.txtMinorFrequency.Name = "txtMinorFrequency"
        Me.txtMinorFrequency.Size = New System.Drawing.Size(100, 20)
        Me.txtMinorFrequency.TabIndex = 36
        Me.txtMinorFrequency.Text = "1"
        '
        'cboDebrisBreakup
        '
        Me.cboDebrisBreakup.FormattingEnabled = True
        Me.cboDebrisBreakup.Items.AddRange(New Object() {"Debris may be broken up", "Debris is never broken up"})
        Me.cboDebrisBreakup.Location = New System.Drawing.Point(131, 162)
        Me.cboDebrisBreakup.Name = "cboDebrisBreakup"
        Me.cboDebrisBreakup.Size = New System.Drawing.Size(100, 21)
        Me.cboDebrisBreakup.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 165)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Break Up"
        '
        'cboDebrisSource
        '
        Me.cboDebrisSource.FormattingEnabled = True
        Me.cboDebrisSource.Items.AddRange(New Object() {"No sluming", "Debris received from core components", "User-defined slumping", "Depends on components above mesh", "Corium hydro model"})
        Me.cboDebrisSource.Location = New System.Drawing.Point(131, 135)
        Me.cboDebrisSource.Name = "cboDebrisSource"
        Me.cboDebrisSource.Size = New System.Drawing.Size(100, 21)
        Me.cboDebrisSource.TabIndex = 0
        '
        'txtCoupleTimeStep
        '
        Me.txtCoupleTimeStep.Location = New System.Drawing.Point(159, 215)
        Me.txtCoupleTimeStep.Name = "txtCoupleTimeStep"
        Me.txtCoupleTimeStep.Size = New System.Drawing.Size(72, 20)
        Me.txtCoupleTimeStep.TabIndex = 34
        Me.txtCoupleTimeStep.Text = "0.5"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(21, 218)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Couple Step"
        '
        'txtMaxHydraulicStep
        '
        Me.txtMaxHydraulicStep.Location = New System.Drawing.Point(159, 189)
        Me.txtMaxHydraulicStep.Name = "txtMaxHydraulicStep"
        Me.txtMaxHydraulicStep.Size = New System.Drawing.Size(72, 20)
        Me.txtMaxHydraulicStep.TabIndex = 34
        Me.txtMaxHydraulicStep.Text = "10"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 192)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Max Hydraulic Steps"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 138)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Source"
        '
        'cboDebrisVolume
        '
        Me.cboDebrisVolume.FormattingEnabled = True
        Me.cboDebrisVolume.Location = New System.Drawing.Point(131, 108)
        Me.cboDebrisVolume.Name = "cboDebrisVolume"
        Me.cboDebrisVolume.Size = New System.Drawing.Size(100, 21)
        Me.cboDebrisVolume.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Volume"
        '
        'cboCoupleStyle
        '
        Me.cboCoupleStyle.FormattingEnabled = True
        Me.cboCoupleStyle.Items.AddRange(New Object() {"old", "new"})
        Me.cboCoupleStyle.Location = New System.Drawing.Point(131, 35)
        Me.cboCoupleStyle.Name = "cboCoupleStyle"
        Me.cboCoupleStyle.Size = New System.Drawing.Size(100, 21)
        Me.cboCoupleStyle.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Style"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(15, 166)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(281, 310)
        Me.TabControl1.TabIndex = 38
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtMinorFrequency)
        Me.TabPage1.Controls.Add(Me.txtendtime)
        Me.TabPage1.Controls.Add(Me.txtMajorFrequency)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtRestartFrequency)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtminsteptime)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtmaxsteptime)
        Me.TabPage1.Controls.Add(Me.txtcontroloption)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(273, 284)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Time Step Control"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cboDebrisBreakup)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.cboCoupleStyle)
        Me.TabPage2.Controls.Add(Me.cboDebrisSource)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtCoupleTimeStep)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.cboDebrisVolume)
        Me.TabPage2.Controls.Add(Me.txtMaxHydraulicStep)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(273, 284)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Couple Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(21, 79)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 33
        Me.Label20.Text = "Debri Bed"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.DoubleInput3)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.DoubleInput2)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.txtCPUTimeAllocated)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.txtCPURemaining2)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.txtCPURemaining1)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(273, 284)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "CPU Time Remaining"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'DoubleInput3
        '
        '
        '
        '
        Me.DoubleInput3.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DoubleInput3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DoubleInput3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.DoubleInput3.Increment = 1.0R
        Me.DoubleInput3.Location = New System.Drawing.Point(155, 143)
        Me.DoubleInput3.Name = "DoubleInput3"
        Me.DoubleInput3.ShowUpDown = True
        Me.DoubleInput3.Size = New System.Drawing.Size(80, 20)
        Me.DoubleInput3.TabIndex = 1
        Me.DoubleInput3.Value = 20.0R
        Me.DoubleInput3.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(21, 143)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(115, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "CPU Remaining Limit 2"
        Me.Label19.Visible = False
        '
        'DoubleInput2
        '
        '
        '
        '
        Me.DoubleInput2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DoubleInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DoubleInput2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.DoubleInput2.Increment = 1.0R
        Me.DoubleInput2.Location = New System.Drawing.Point(155, 117)
        Me.DoubleInput2.Name = "DoubleInput2"
        Me.DoubleInput2.ShowUpDown = True
        Me.DoubleInput2.Size = New System.Drawing.Size(80, 20)
        Me.DoubleInput2.TabIndex = 1
        Me.DoubleInput2.Value = 20.0R
        Me.DoubleInput2.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(21, 117)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(115, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "CPU Remaining Limit 2"
        Me.Label18.Visible = False
        '
        'txtCPUTimeAllocated
        '
        '
        '
        '
        Me.txtCPUTimeAllocated.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCPUTimeAllocated.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCPUTimeAllocated.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCPUTimeAllocated.Increment = 1.0R
        Me.txtCPUTimeAllocated.Location = New System.Drawing.Point(155, 91)
        Me.txtCPUTimeAllocated.Name = "txtCPUTimeAllocated"
        Me.txtCPUTimeAllocated.ShowUpDown = True
        Me.txtCPUTimeAllocated.Size = New System.Drawing.Size(80, 20)
        Me.txtCPUTimeAllocated.TabIndex = 1
        Me.txtCPUTimeAllocated.Value = 200.0R
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 91)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "CPU Time Allocated"
        '
        'txtCPURemaining2
        '
        '
        '
        '
        Me.txtCPURemaining2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCPURemaining2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCPURemaining2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCPURemaining2.Increment = 1.0R
        Me.txtCPURemaining2.Location = New System.Drawing.Point(155, 65)
        Me.txtCPURemaining2.Name = "txtCPURemaining2"
        Me.txtCPURemaining2.ShowUpDown = True
        Me.txtCPURemaining2.Size = New System.Drawing.Size(80, 20)
        Me.txtCPURemaining2.TabIndex = 1
        Me.txtCPURemaining2.Value = 20.0R
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(21, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 13)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "CPU Remaining Limit 2"
        '
        'txtCPURemaining1
        '
        '
        '
        '
        Me.txtCPURemaining1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCPURemaining1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCPURemaining1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCPURemaining1.Increment = 1.0R
        Me.txtCPURemaining1.Location = New System.Drawing.Point(155, 39)
        Me.txtCPURemaining1.Name = "txtCPURemaining1"
        Me.txtCPURemaining1.ShowUpDown = True
        Me.txtCPURemaining1.Size = New System.Drawing.Size(80, 20)
        Me.txtCPURemaining1.TabIndex = 1
        Me.txtCPURemaining1.Value = 10.0R
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(21, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(115, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "CPU Remaining Limit 1"
        '
        'frmInitialSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(303, 482)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.chklistboxBoron)
        Me.Controls.Add(Me.chklistboxFluid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chklistboxCondensibleGases)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmInitialSettings"
        Me.Text = "Initial Settings"
        Me.chklistboxFluid.ResumeLayout(False)
        Me.chklistboxFluid.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DoubleInput3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DoubleInput2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCPUTimeAllocated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCPURemaining2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCPURemaining1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cboCoupleStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtCPURemaining2 As DevComponents.Editors.DoubleInput
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCPURemaining1 As DevComponents.Editors.DoubleInput
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DoubleInput3 As DevComponents.Editors.DoubleInput
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DoubleInput2 As DevComponents.Editors.DoubleInput
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCPUTimeAllocated As DevComponents.Editors.DoubleInput
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class

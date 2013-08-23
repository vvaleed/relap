<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucHeatStructureEditor
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
        Me.chkboxmeshgeometry = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dgvformat1 = New System.Windows.Forms.DataGridView()
        Me.Numberofintervals = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightCoordinate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvformat2 = New System.Windows.Forms.DataGridView()
        Me.MeshInterval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IntervalNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvNoDecay = New System.Windows.Forms.DataGridView()
        Me.SourceValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeshIntervalNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtboxDecayHeat = New System.Windows.Forms.TextBox()
        Me.dgvWithDecay = New System.Windows.Forms.DataGridView()
        Me.GammaAttenuationCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeshIntervalNumber2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvComposition = New System.Windows.Forms.DataGridView()
        Me.CompositionNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeshIntervalNumber3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.CmbBoxSelectFormat = New System.Windows.Forms.ComboBox()
        Me.cmdsave = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.Tab3 = New System.Windows.Forms.TabPage()
        Me.ComboBoxTemp = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvTemp1 = New System.Windows.Forms.DataGridView()
        Me.Temp1Temperature = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Temp1MeshPointNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvTemp2 = New System.Windows.Forms.DataGridView()
        Me.Temp2GammaAttenCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Temp2MeshIntervalNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.ChkboxDeformation = New System.Windows.Forms.CheckBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.txtboxOxideThickness = New System.Windows.Forms.TextBox()
        Me.ChkboxMetalWaterReaction = New System.Windows.Forms.CheckBox()
        Me.txtboxGapConductanceRefVol = New System.Windows.Forms.TextBox()
        Me.txtboxInitialGapInternalPressure = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ChkboxGapConductance = New System.Windows.Forms.CheckBox()
        Me.dgvGapDeformation = New System.Windows.Forms.DataGridView()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.FuelSurfaceRoughness = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CladdingSurfaceRoughness = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RadialDisplacementFission = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RadialDisplacementCladding = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HSnumberGapDef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvformat1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvformat2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNoDecay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWithDecay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvComposition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Tab2.SuspendLayout()
        Me.Tab3.SuspendLayout()
        CType(Me.dgvTemp1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTemp2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.dgvGapDeformation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkboxmeshgeometry
        '
        Me.chkboxmeshgeometry.AutoSize = True
        Me.chkboxmeshgeometry.Location = New System.Drawing.Point(17, 18)
        Me.chkboxmeshgeometry.Name = "chkboxmeshgeometry"
        Me.chkboxmeshgeometry.Size = New System.Drawing.Size(128, 17)
        Me.chkboxmeshgeometry.TabIndex = 0
        Me.chkboxmeshgeometry.Text = "Enter Mesh Geometry"
        Me.chkboxmeshgeometry.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(17, 47)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 13)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "Select Format"
        '
        'dgvformat1
        '
        Me.dgvformat1.AccessibleDescription = "                            "
        Me.dgvformat1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvformat1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Numberofintervals, Me.RightCoordinate})
        Me.dgvformat1.Location = New System.Drawing.Point(17, 106)
        Me.dgvformat1.Name = "dgvformat1"
        Me.dgvformat1.Size = New System.Drawing.Size(256, 125)
        Me.dgvformat1.TabIndex = 4
        '
        'Numberofintervals
        '
        Me.Numberofintervals.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Numberofintervals.HeaderText = "Number of Intervals"
        Me.Numberofintervals.Name = "Numberofintervals"
        '
        'RightCoordinate
        '
        Me.RightCoordinate.HeaderText = "Right Coordinate"
        Me.RightCoordinate.Name = "RightCoordinate"
        '
        'dgvformat2
        '
        Me.dgvformat2.AccessibleDescription = "                            "
        Me.dgvformat2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvformat2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MeshInterval, Me.IntervalNumber})
        Me.dgvformat2.Location = New System.Drawing.Point(17, 106)
        Me.dgvformat2.Name = "dgvformat2"
        Me.dgvformat2.Size = New System.Drawing.Size(256, 125)
        Me.dgvformat2.TabIndex = 5
        '
        'MeshInterval
        '
        Me.MeshInterval.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.MeshInterval.HeaderText = "Mesh Interval"
        Me.MeshInterval.Name = "MeshInterval"
        '
        'IntervalNumber
        '
        Me.IntervalNumber.HeaderText = "Interval Number"
        Me.IntervalNumber.Name = "IntervalNumber"
        '
        'dgvNoDecay
        '
        Me.dgvNoDecay.AccessibleDescription = "                            "
        Me.dgvNoDecay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNoDecay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SourceValue, Me.MeshIntervalNumber})
        Me.dgvNoDecay.Location = New System.Drawing.Point(363, 106)
        Me.dgvNoDecay.Name = "dgvNoDecay"
        Me.dgvNoDecay.Size = New System.Drawing.Size(256, 125)
        Me.dgvNoDecay.TabIndex = 6
        '
        'SourceValue
        '
        Me.SourceValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SourceValue.HeaderText = "Source Value"
        Me.SourceValue.Name = "SourceValue"
        '
        'MeshIntervalNumber
        '
        Me.MeshIntervalNumber.HeaderText = "Mesh Interval Number"
        Me.MeshIntervalNumber.Name = "MeshIntervalNumber"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(363, 47)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 13)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "Decay Heat"
        '
        'txtboxDecayHeat
        '
        Me.txtboxDecayHeat.Location = New System.Drawing.Point(363, 67)
        Me.txtboxDecayHeat.Name = "txtboxDecayHeat"
        Me.txtboxDecayHeat.Size = New System.Drawing.Size(100, 20)
        Me.txtboxDecayHeat.TabIndex = 8
        '
        'dgvWithDecay
        '
        Me.dgvWithDecay.AccessibleDescription = "                            "
        Me.dgvWithDecay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWithDecay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GammaAttenuationCo, Me.MeshIntervalNumber2})
        Me.dgvWithDecay.Location = New System.Drawing.Point(363, 106)
        Me.dgvWithDecay.Name = "dgvWithDecay"
        Me.dgvWithDecay.Size = New System.Drawing.Size(256, 125)
        Me.dgvWithDecay.TabIndex = 9
        '
        'GammaAttenuationCo
        '
        Me.GammaAttenuationCo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.GammaAttenuationCo.HeaderText = "Gamma Attenuation Co."
        Me.GammaAttenuationCo.Name = "GammaAttenuationCo"
        '
        'MeshIntervalNumber2
        '
        Me.MeshIntervalNumber2.HeaderText = "Mesh Interval Number"
        Me.MeshIntervalNumber2.Name = "MeshIntervalNumber2"
        '
        'dgvComposition
        '
        Me.dgvComposition.AccessibleDescription = "                            "
        Me.dgvComposition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComposition.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompositionNumber, Me.MeshIntervalNumber3})
        Me.dgvComposition.Location = New System.Drawing.Point(17, 283)
        Me.dgvComposition.Name = "dgvComposition"
        Me.dgvComposition.Size = New System.Drawing.Size(256, 125)
        Me.dgvComposition.TabIndex = 10
        '
        'CompositionNumber
        '
        Me.CompositionNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CompositionNumber.HeaderText = "Composition Number"
        Me.CompositionNumber.Name = "CompositionNumber"
        '
        'MeshIntervalNumber3
        '
        Me.MeshIntervalNumber3.HeaderText = "Mesh Interval Number"
        Me.MeshIntervalNumber3.Name = "MeshIntervalNumber3"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(17, 264)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(100, 13)
        Me.TextBox4.TabIndex = 11
        Me.TextBox4.Text = "Composition Data"
        '
        'CmbBoxSelectFormat
        '
        Me.CmbBoxSelectFormat.FormattingEnabled = True
        Me.CmbBoxSelectFormat.Items.AddRange(New Object() {"Number of Intervals, Right Coordinate", "Mesh Interval, Interval number"})
        Me.CmbBoxSelectFormat.Location = New System.Drawing.Point(17, 66)
        Me.CmbBoxSelectFormat.Name = "CmbBoxSelectFormat"
        Me.CmbBoxSelectFormat.Size = New System.Drawing.Size(256, 21)
        Me.CmbBoxSelectFormat.TabIndex = 12
        '
        'cmdsave
        '
        Me.cmdsave.Location = New System.Drawing.Point(738, 438)
        Me.cmdsave.Name = "cmdsave"
        Me.cmdsave.Size = New System.Drawing.Size(75, 23)
        Me.cmdsave.TabIndex = 13
        Me.cmdsave.Text = "Save"
        Me.cmdsave.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tab1)
        Me.TabControl1.Controls.Add(Me.Tab2)
        Me.TabControl1.Controls.Add(Me.Tab3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(729, 462)
        Me.TabControl1.TabIndex = 14
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.chkboxmeshgeometry)
        Me.Tab2.Controls.Add(Me.TextBox1)
        Me.Tab2.Controls.Add(Me.dgvWithDecay)
        Me.Tab2.Controls.Add(Me.dgvNoDecay)
        Me.Tab2.Controls.Add(Me.TextBox2)
        Me.Tab2.Controls.Add(Me.txtboxDecayHeat)
        Me.Tab2.Controls.Add(Me.dgvComposition)
        Me.Tab2.Controls.Add(Me.TextBox4)
        Me.Tab2.Controls.Add(Me.CmbBoxSelectFormat)
        Me.Tab2.Controls.Add(Me.dgvformat1)
        Me.Tab2.Controls.Add(Me.dgvformat2)
        Me.Tab2.Location = New System.Drawing.Point(4, 22)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2.Size = New System.Drawing.Size(721, 436)
        Me.Tab2.TabIndex = 0
        Me.Tab2.Text = "Mesh Geometry"
        Me.Tab2.UseVisualStyleBackColor = True
        '
        'Tab3
        '
        Me.Tab3.Controls.Add(Me.ComboBoxTemp)
        Me.Tab3.Controls.Add(Me.Label1)
        Me.Tab3.Controls.Add(Me.dgvTemp1)
        Me.Tab3.Controls.Add(Me.dgvTemp2)
        Me.Tab3.Location = New System.Drawing.Point(4, 22)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab3.Size = New System.Drawing.Size(721, 436)
        Me.Tab3.TabIndex = 1
        Me.Tab3.Text = "Initial Temperature Data"
        Me.Tab3.UseVisualStyleBackColor = True
        '
        'ComboBoxTemp
        '
        Me.ComboBoxTemp.FormattingEnabled = True
        Me.ComboBoxTemp.Items.AddRange(New Object() {"Same Distribution For All Heat Structures", "Separate Distribution For Each Heat Structure"})
        Me.ComboBoxTemp.Location = New System.Drawing.Point(27, 51)
        Me.ComboBoxTemp.Name = "ComboBoxTemp"
        Me.ComboBoxTemp.Size = New System.Drawing.Size(256, 21)
        Me.ComboBoxTemp.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Enter Initial Temperature Conditions"
        '
        'dgvTemp1
        '
        Me.dgvTemp1.AccessibleDescription = "                            "
        Me.dgvTemp1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTemp1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Temp1Temperature, Me.Temp1MeshPointNumber})
        Me.dgvTemp1.Location = New System.Drawing.Point(27, 105)
        Me.dgvTemp1.Name = "dgvTemp1"
        Me.dgvTemp1.Size = New System.Drawing.Size(256, 125)
        Me.dgvTemp1.TabIndex = 10
        '
        'Temp1Temperature
        '
        Me.Temp1Temperature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Temp1Temperature.HeaderText = "Temperature"
        Me.Temp1Temperature.Name = "Temp1Temperature"
        '
        'Temp1MeshPointNumber
        '
        Me.Temp1MeshPointNumber.HeaderText = "Mesh Point Number"
        Me.Temp1MeshPointNumber.Name = "Temp1MeshPointNumber"
        '
        'dgvTemp2
        '
        Me.dgvTemp2.AccessibleDescription = "                            "
        Me.dgvTemp2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTemp2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Temp2GammaAttenCo, Me.Temp2MeshIntervalNumber})
        Me.dgvTemp2.Location = New System.Drawing.Point(27, 105)
        Me.dgvTemp2.Name = "dgvTemp2"
        Me.dgvTemp2.Size = New System.Drawing.Size(256, 125)
        Me.dgvTemp2.TabIndex = 12
        '
        'Temp2GammaAttenCo
        '
        Me.Temp2GammaAttenCo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Temp2GammaAttenCo.HeaderText = "Gamma Attenuation Co."
        Me.Temp2GammaAttenCo.Name = "Temp2GammaAttenCo"
        '
        'Temp2MeshIntervalNumber
        '
        Me.Temp2MeshIntervalNumber.HeaderText = "Mesh Interval Number"
        Me.Temp2MeshIntervalNumber.Name = "Temp2MeshIntervalNumber"
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.TextBox6)
        Me.Tab1.Controls.Add(Me.dgvGapDeformation)
        Me.Tab1.Controls.Add(Me.ChkboxDeformation)
        Me.Tab1.Controls.Add(Me.TextBox7)
        Me.Tab1.Controls.Add(Me.txtboxOxideThickness)
        Me.Tab1.Controls.Add(Me.ChkboxMetalWaterReaction)
        Me.Tab1.Controls.Add(Me.txtboxGapConductanceRefVol)
        Me.Tab1.Controls.Add(Me.txtboxInitialGapInternalPressure)
        Me.Tab1.Controls.Add(Me.TextBox5)
        Me.Tab1.Controls.Add(Me.TextBox3)
        Me.Tab1.Controls.Add(Me.ChkboxGapConductance)
        Me.Tab1.Location = New System.Drawing.Point(4, 22)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab1.Size = New System.Drawing.Size(721, 436)
        Me.Tab1.TabIndex = 2
        Me.Tab1.Text = "Gap Conductance Model"
        Me.Tab1.UseVisualStyleBackColor = True
        '
        'ChkboxDeformation
        '
        Me.ChkboxDeformation.AutoSize = True
        Me.ChkboxDeformation.Location = New System.Drawing.Point(20, 211)
        Me.ChkboxDeformation.Name = "ChkboxDeformation"
        Me.ChkboxDeformation.Size = New System.Drawing.Size(159, 17)
        Me.ChkboxDeformation.TabIndex = 32
        Me.ChkboxDeformation.Text = "Calculate Form Loss Factors"
        Me.ChkboxDeformation.UseVisualStyleBackColor = True
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(20, 145)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(286, 13)
        Me.TextBox7.TabIndex = 31
        Me.TextBox7.Text = "Initial Oxide thickness on cladding's outer surface" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtboxOxideThickness
        '
        Me.txtboxOxideThickness.Location = New System.Drawing.Point(20, 164)
        Me.txtboxOxideThickness.Name = "txtboxOxideThickness"
        Me.txtboxOxideThickness.Size = New System.Drawing.Size(100, 20)
        Me.txtboxOxideThickness.TabIndex = 30
        '
        'ChkboxMetalWaterReaction
        '
        Me.ChkboxMetalWaterReaction.AutoSize = True
        Me.ChkboxMetalWaterReaction.Location = New System.Drawing.Point(20, 122)
        Me.ChkboxMetalWaterReaction.Name = "ChkboxMetalWaterReaction"
        Me.ChkboxMetalWaterReaction.Size = New System.Drawing.Size(177, 17)
        Me.ChkboxMetalWaterReaction.TabIndex = 29
        Me.ChkboxMetalWaterReaction.Text = "Calculate Metal Water Reaction"
        Me.ChkboxMetalWaterReaction.UseVisualStyleBackColor = True
        '
        'txtboxGapConductanceRefVol
        '
        Me.txtboxGapConductanceRefVol.Location = New System.Drawing.Point(227, 69)
        Me.txtboxGapConductanceRefVol.Name = "txtboxGapConductanceRefVol"
        Me.txtboxGapConductanceRefVol.Size = New System.Drawing.Size(100, 20)
        Me.txtboxGapConductanceRefVol.TabIndex = 28
        '
        'txtboxInitialGapInternalPressure
        '
        Me.txtboxInitialGapInternalPressure.Location = New System.Drawing.Point(20, 69)
        Me.txtboxInitialGapInternalPressure.Name = "txtboxInitialGapInternalPressure"
        Me.txtboxInitialGapInternalPressure.Size = New System.Drawing.Size(100, 20)
        Me.txtboxInitialGapInternalPressure.TabIndex = 27
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(227, 49)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(220, 13)
        Me.TextBox5.TabIndex = 26
        Me.TextBox5.Text = "Gap Conductance Reference Volume"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(20, 49)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(183, 13)
        Me.TextBox3.TabIndex = 25
        Me.TextBox3.Text = "Initial Gap Internal Pressure"
        '
        'ChkboxGapConductance
        '
        Me.ChkboxGapConductance.AutoSize = True
        Me.ChkboxGapConductance.Location = New System.Drawing.Point(20, 21)
        Me.ChkboxGapConductance.Name = "ChkboxGapConductance"
        Me.ChkboxGapConductance.Size = New System.Drawing.Size(167, 17)
        Me.ChkboxGapConductance.TabIndex = 24
        Me.ChkboxGapConductance.Text = "Use Gap Conductance Model"
        Me.ChkboxGapConductance.UseVisualStyleBackColor = True
        '
        'dgvGapDeformation
        '
        Me.dgvGapDeformation.AccessibleDescription = "                            "
        Me.dgvGapDeformation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGapDeformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGapDeformation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FuelSurfaceRoughness, Me.CladdingSurfaceRoughness, Me.RadialDisplacementFission, Me.RadialDisplacementCladding, Me.HSnumberGapDef})
        Me.dgvGapDeformation.Location = New System.Drawing.Point(20, 274)
        Me.dgvGapDeformation.Name = "dgvGapDeformation"
        Me.dgvGapDeformation.Size = New System.Drawing.Size(684, 125)
        Me.dgvGapDeformation.TabIndex = 33
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(20, 255)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(286, 13)
        Me.TextBox6.TabIndex = 34
        Me.TextBox6.Text = "Gap Deformation Data" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'FuelSurfaceRoughness
        '
        Me.FuelSurfaceRoughness.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FuelSurfaceRoughness.HeaderText = "Fuel Surface Roughness"
        Me.FuelSurfaceRoughness.Name = "FuelSurfaceRoughness"
        '
        'CladdingSurfaceRoughness
        '
        Me.CladdingSurfaceRoughness.HeaderText = "Cladding Surface Roughness"
        Me.CladdingSurfaceRoughness.Name = "CladdingSurfaceRoughness"
        '
        'RadialDisplacementFission
        '
        Me.RadialDisplacementFission.HeaderText = "Radial Displacement due to Fission Gas-induced Fuel"
        Me.RadialDisplacementFission.Name = "RadialDisplacementFission"
        '
        'RadialDisplacementCladding
        '
        Me.RadialDisplacementCladding.HeaderText = "Radial Displacement due to Cladding Creepdown"
        Me.RadialDisplacementCladding.Name = "RadialDisplacementCladding"
        '
        'HSnumberGapDef
        '
        Me.HSnumberGapDef.HeaderText = "Heat Structure Number"
        Me.HSnumberGapDef.Name = "HSnumberGapDef"
        '
        'ucHeatStructureEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdsave)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ucHeatStructureEditor"
        Me.Size = New System.Drawing.Size(821, 465)
        CType(Me.dgvformat1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvformat2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNoDecay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWithDecay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvComposition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Tab2.ResumeLayout(False)
        Me.Tab2.PerformLayout()
        Me.Tab3.ResumeLayout(False)
        Me.Tab3.PerformLayout()
        CType(Me.dgvTemp1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTemp2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        CType(Me.dgvGapDeformation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkboxmeshgeometry As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvformat1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvformat2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvNoDecay As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents txtboxDecayHeat As System.Windows.Forms.TextBox
    Friend WithEvents dgvWithDecay As System.Windows.Forms.DataGridView
    Friend WithEvents Numberofintervals As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightCoordinate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MeshInterval As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IntervalNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvComposition As System.Windows.Forms.DataGridView
    Friend WithEvents SourceValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MeshIntervalNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GammaAttenuationCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MeshIntervalNumber2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompositionNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MeshIntervalNumber3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents CmbBoxSelectFormat As System.Windows.Forms.ComboBox
    Friend WithEvents cmdsave As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Friend WithEvents Tab3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvTemp1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTemp2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Temp1Temperature As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temp1MeshPointNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboBoxTemp As System.Windows.Forms.ComboBox
    Friend WithEvents Temp2GammaAttenCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temp2MeshIntervalNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tab1 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents dgvGapDeformation As System.Windows.Forms.DataGridView
    Friend WithEvents FuelSurfaceRoughness As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CladdingSurfaceRoughness As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadialDisplacementFission As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadialDisplacementCladding As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HSnumberGapDef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkboxDeformation As System.Windows.Forms.CheckBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents txtboxOxideThickness As System.Windows.Forms.TextBox
    Friend WithEvents ChkboxMetalWaterReaction As System.Windows.Forms.CheckBox
    Friend WithEvents txtboxGapConductanceRefVol As System.Windows.Forms.TextBox
    Friend WithEvents txtboxInitialGapInternalPressure As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ChkboxGapConductance As System.Windows.Forms.CheckBox

End Class

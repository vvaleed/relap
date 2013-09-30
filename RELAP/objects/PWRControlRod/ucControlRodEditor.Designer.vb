<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucControlRodEditor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdCopytoAll = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdPaste = New System.Windows.Forms.Button()
        Me.dgvFuelRodDimensions = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.dgvHyrdraulicVolumes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cboComponent = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtVolume = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.txtIncrement = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.txtAxialNode = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvRadialMeshSpacing = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtNumberofIntervals = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.txtNumberofIntervalsAcrossGap = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.txtIntervalsAcrossCladding = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.lblAxialNodeNumber = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cmdCopytoAll2 = New System.Windows.Forms.Button()
        Me.cmdCopy2 = New System.Windows.Forms.Button()
        Me.cmdPaste2 = New System.Windows.Forms.Button()
        Me.dgvInitialTemperatures = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.lblAxialNode_InitialTemp = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txtVolumeAbove = New DevComponents.Editors.IntegerInput()
        Me.txtVolumebelow = New DevComponents.Editors.IntegerInput()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cboControlVolumeAbove = New System.Windows.Forms.ComboBox()
        Me.cboControlVolumeBelow = New System.Windows.Forms.ComboBox()
        Me.lblAxialNode = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.txtOuterRadiusofAbsorber = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.txtOuterRadiusofStainlessSteel = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.txtInnerRadiusofZircaloyGuideTube = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.txtOuterRadiusofZircaloyGuideTube = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFuelRodDimensions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        CType(Me.dgvHyrdraulicVolumes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvRadialMeshSpacing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvInitialTemperatures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVolumeAbove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVolumebelow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(19, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(633, 292)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmdCopytoAll)
        Me.TabPage1.Controls.Add(Me.cmdCopy)
        Me.TabPage1.Controls.Add(Me.cmdPaste)
        Me.TabPage1.Controls.Add(Me.dgvFuelRodDimensions)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(625, 266)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Geometry"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdCopytoAll
        '
        Me.cmdCopytoAll.Enabled = False
        Me.cmdCopytoAll.Location = New System.Drawing.Point(317, 198)
        Me.cmdCopytoAll.Name = "cmdCopytoAll"
        Me.cmdCopytoAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdCopytoAll.TabIndex = 12
        Me.cmdCopytoAll.Text = "Copy to All"
        Me.cmdCopytoAll.UseVisualStyleBackColor = True
        '
        'cmdCopy
        '
        Me.cmdCopy.Enabled = False
        Me.cmdCopy.Location = New System.Drawing.Point(141, 198)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(75, 23)
        Me.cmdCopy.TabIndex = 10
        Me.cmdCopy.Text = "Copy"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'cmdPaste
        '
        Me.cmdPaste.Enabled = False
        Me.cmdPaste.Location = New System.Drawing.Point(222, 198)
        Me.cmdPaste.Name = "cmdPaste"
        Me.cmdPaste.Size = New System.Drawing.Size(75, 23)
        Me.cmdPaste.TabIndex = 11
        Me.cmdPaste.Text = "Paste"
        Me.cmdPaste.UseVisualStyleBackColor = True
        '
        'dgvFuelRodDimensions
        '
        Me.dgvFuelRodDimensions.AllowUserToAddRows = False
        Me.dgvFuelRodDimensions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFuelRodDimensions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFuelRodDimensions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFuelRodDimensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuelRodDimensions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lblAxialNode, Me.txtOuterRadiusofAbsorber, Me.txtOuterRadiusofStainlessSteel, Me.txtInnerRadiusofZircaloyGuideTube, Me.txtOuterRadiusofZircaloyGuideTube})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFuelRodDimensions.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFuelRodDimensions.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvFuelRodDimensions.Location = New System.Drawing.Point(21, 24)
        Me.dgvFuelRodDimensions.Name = "dgvFuelRodDimensions"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFuelRodDimensions.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFuelRodDimensions.Size = New System.Drawing.Size(586, 150)
        Me.dgvFuelRodDimensions.TabIndex = 0
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.dgvHyrdraulicVolumes)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(625, 266)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "Hydraulic Volumes"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'dgvHyrdraulicVolumes
        '
        Me.dgvHyrdraulicVolumes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHyrdraulicVolumes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHyrdraulicVolumes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cboComponent, Me.txtVolume, Me.txtIncrement, Me.txtAxialNode})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHyrdraulicVolumes.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvHyrdraulicVolumes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvHyrdraulicVolumes.Location = New System.Drawing.Point(34, 48)
        Me.dgvHyrdraulicVolumes.Name = "dgvHyrdraulicVolumes"
        Me.dgvHyrdraulicVolumes.Size = New System.Drawing.Size(565, 150)
        Me.dgvHyrdraulicVolumes.TabIndex = 0
        '
        'cboComponent
        '
        Me.cboComponent.HeaderText = "Component"
        Me.cboComponent.Name = "cboComponent"
        '
        'txtVolume
        '
        '
        '
        '
        Me.txtVolume.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtVolume.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtVolume.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVolume.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtVolume.HeaderText = "Volume"
        Me.txtVolume.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtVolume.Name = "txtVolume"
        '
        'txtIncrement
        '
        '
        '
        '
        Me.txtIncrement.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtIncrement.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtIncrement.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIncrement.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtIncrement.HeaderText = "Increment"
        Me.txtIncrement.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtIncrement.Name = "txtIncrement"
        '
        'txtAxialNode
        '
        '
        '
        '
        Me.txtAxialNode.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtAxialNode.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtAxialNode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAxialNode.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtAxialNode.HeaderText = "Axial Node"
        Me.txtAxialNode.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtAxialNode.Name = "txtAxialNode"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvRadialMeshSpacing)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(625, 266)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Radial Mesh Spacing"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvRadialMeshSpacing
        '
        Me.dgvRadialMeshSpacing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRadialMeshSpacing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRadialMeshSpacing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRadialMeshSpacing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txtNumberofIntervals, Me.txtNumberofIntervalsAcrossGap, Me.txtIntervalsAcrossCladding, Me.lblAxialNodeNumber})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRadialMeshSpacing.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRadialMeshSpacing.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvRadialMeshSpacing.Location = New System.Drawing.Point(17, 26)
        Me.dgvRadialMeshSpacing.Name = "dgvRadialMeshSpacing"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRadialMeshSpacing.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvRadialMeshSpacing.Size = New System.Drawing.Size(564, 175)
        Me.dgvRadialMeshSpacing.TabIndex = 0
        '
        'txtNumberofIntervals
        '
        '
        '
        '
        Me.txtNumberofIntervals.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumberofIntervals.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtNumberofIntervals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumberofIntervals.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtNumberofIntervals.HeaderText = "Number of Intervals across Fuel"
        Me.txtNumberofIntervals.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtNumberofIntervals.Name = "txtNumberofIntervals"
        '
        'txtNumberofIntervalsAcrossGap
        '
        '
        '
        '
        Me.txtNumberofIntervalsAcrossGap.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumberofIntervalsAcrossGap.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtNumberofIntervalsAcrossGap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumberofIntervalsAcrossGap.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtNumberofIntervalsAcrossGap.HeaderText = "Number of intervals across gap"
        Me.txtNumberofIntervalsAcrossGap.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtNumberofIntervalsAcrossGap.Name = "txtNumberofIntervalsAcrossGap"
        '
        'txtIntervalsAcrossCladding
        '
        '
        '
        '
        Me.txtIntervalsAcrossCladding.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntervalsAcrossCladding.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtIntervalsAcrossCladding.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIntervalsAcrossCladding.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtIntervalsAcrossCladding.HeaderText = "Number of intervals across cladding"
        Me.txtIntervalsAcrossCladding.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtIntervalsAcrossCladding.Name = "txtIntervalsAcrossCladding"
        '
        'lblAxialNodeNumber
        '
        '
        '
        '
        Me.lblAxialNodeNumber.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.lblAxialNodeNumber.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.lblAxialNodeNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAxialNodeNumber.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.lblAxialNodeNumber.HeaderText = "Axial Node"
        Me.lblAxialNodeNumber.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.lblAxialNodeNumber.Name = "lblAxialNodeNumber"
        Me.lblAxialNodeNumber.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.lblAxialNodeNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cmdCopytoAll2)
        Me.TabPage3.Controls.Add(Me.cmdCopy2)
        Me.TabPage3.Controls.Add(Me.cmdPaste2)
        Me.TabPage3.Controls.Add(Me.dgvInitialTemperatures)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(625, 266)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Initial Temperatures"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cmdCopytoAll2
        '
        Me.cmdCopytoAll2.Enabled = False
        Me.cmdCopytoAll2.Location = New System.Drawing.Point(340, 207)
        Me.cmdCopytoAll2.Name = "cmdCopytoAll2"
        Me.cmdCopytoAll2.Size = New System.Drawing.Size(75, 23)
        Me.cmdCopytoAll2.TabIndex = 15
        Me.cmdCopytoAll2.Text = "Copy to All"
        Me.cmdCopytoAll2.UseVisualStyleBackColor = True
        '
        'cmdCopy2
        '
        Me.cmdCopy2.Enabled = False
        Me.cmdCopy2.Location = New System.Drawing.Point(164, 207)
        Me.cmdCopy2.Name = "cmdCopy2"
        Me.cmdCopy2.Size = New System.Drawing.Size(75, 23)
        Me.cmdCopy2.TabIndex = 13
        Me.cmdCopy2.Text = "Copy"
        Me.cmdCopy2.UseVisualStyleBackColor = True
        '
        'cmdPaste2
        '
        Me.cmdPaste2.Enabled = False
        Me.cmdPaste2.Location = New System.Drawing.Point(245, 207)
        Me.cmdPaste2.Name = "cmdPaste2"
        Me.cmdPaste2.Size = New System.Drawing.Size(75, 23)
        Me.cmdPaste2.TabIndex = 14
        Me.cmdPaste2.Text = "Paste"
        Me.cmdPaste2.UseVisualStyleBackColor = True
        '
        'dgvInitialTemperatures
        '
        Me.dgvInitialTemperatures.AllowUserToAddRows = False
        Me.dgvInitialTemperatures.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInitialTemperatures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInitialTemperatures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInitialTemperatures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lblAxialNode_InitialTemp})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInitialTemperatures.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvInitialTemperatures.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvInitialTemperatures.Location = New System.Drawing.Point(30, 28)
        Me.dgvInitialTemperatures.Name = "dgvInitialTemperatures"
        Me.dgvInitialTemperatures.Size = New System.Drawing.Size(539, 150)
        Me.dgvInitialTemperatures.TabIndex = 0
        '
        'lblAxialNode_InitialTemp
        '
        Me.lblAxialNode_InitialTemp.HeaderText = "Axial Node"
        Me.lblAxialNode_InitialTemp.Name = "lblAxialNode_InitialTemp"
        Me.lblAxialNode_InitialTemp.ReadOnly = True
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(23, 316)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(231, 20)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "Control volume located just above control rod"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(23, 342)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(231, 20)
        Me.LabelX5.TabIndex = 3
        Me.LabelX5.Text = "Control volume located just below control rod"
        '
        'txtVolumeAbove
        '
        '
        '
        '
        Me.txtVolumeAbove.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtVolumeAbove.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVolumeAbove.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtVolumeAbove.Location = New System.Drawing.Point(391, 315)
        Me.txtVolumeAbove.Name = "txtVolumeAbove"
        Me.txtVolumeAbove.ShowUpDown = True
        Me.txtVolumeAbove.Size = New System.Drawing.Size(80, 20)
        Me.txtVolumeAbove.TabIndex = 4
        '
        'txtVolumebelow
        '
        '
        '
        '
        Me.txtVolumebelow.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtVolumebelow.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVolumebelow.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtVolumebelow.Location = New System.Drawing.Point(391, 341)
        Me.txtVolumebelow.Name = "txtVolumebelow"
        Me.txtVolumebelow.ShowUpDown = True
        Me.txtVolumebelow.Size = New System.Drawing.Size(80, 20)
        Me.txtVolumebelow.TabIndex = 4
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(528, 335)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cboControlVolumeAbove
        '
        Me.cboControlVolumeAbove.FormattingEnabled = True
        Me.cboControlVolumeAbove.Location = New System.Drawing.Point(260, 314)
        Me.cboControlVolumeAbove.Name = "cboControlVolumeAbove"
        Me.cboControlVolumeAbove.Size = New System.Drawing.Size(121, 21)
        Me.cboControlVolumeAbove.TabIndex = 5
        '
        'cboControlVolumeBelow
        '
        Me.cboControlVolumeBelow.FormattingEnabled = True
        Me.cboControlVolumeBelow.Location = New System.Drawing.Point(260, 342)
        Me.cboControlVolumeBelow.Name = "cboControlVolumeBelow"
        Me.cboControlVolumeBelow.Size = New System.Drawing.Size(121, 21)
        Me.cboControlVolumeBelow.TabIndex = 5
        '
        'lblAxialNode
        '
        Me.lblAxialNode.HeaderText = "Axial Node"
        Me.lblAxialNode.Name = "lblAxialNode"
        '
        'txtOuterRadiusofAbsorber
        '
        '
        '
        '
        Me.txtOuterRadiusofAbsorber.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtOuterRadiusofAbsorber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOuterRadiusofAbsorber.HeaderText = "Outer Radius of Absorber"
        Me.txtOuterRadiusofAbsorber.Increment = 1.0R
        Me.txtOuterRadiusofAbsorber.Name = "txtOuterRadiusofAbsorber"
        '
        'txtOuterRadiusofStainlessSteel
        '
        '
        '
        '
        Me.txtOuterRadiusofStainlessSteel.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtOuterRadiusofStainlessSteel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOuterRadiusofStainlessSteel.HeaderText = "Outer radius of stainless steelsheath"
        Me.txtOuterRadiusofStainlessSteel.Increment = 1.0R
        Me.txtOuterRadiusofStainlessSteel.Name = "txtOuterRadiusofStainlessSteel"
        '
        'txtInnerRadiusofZircaloyGuideTube
        '
        '
        '
        '
        Me.txtInnerRadiusofZircaloyGuideTube.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtInnerRadiusofZircaloyGuideTube.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInnerRadiusofZircaloyGuideTube.HeaderText = "Inner radius of zircaloy guide tube"
        Me.txtInnerRadiusofZircaloyGuideTube.Increment = 1.0R
        Me.txtInnerRadiusofZircaloyGuideTube.Name = "txtInnerRadiusofZircaloyGuideTube"
        '
        'txtOuterRadiusofZircaloyGuideTube
        '
        '
        '
        '
        Me.txtOuterRadiusofZircaloyGuideTube.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtOuterRadiusofZircaloyGuideTube.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOuterRadiusofZircaloyGuideTube.HeaderText = "Outer radius of zircaloy guide tube"
        Me.txtOuterRadiusofZircaloyGuideTube.Increment = 1.0R
        Me.txtOuterRadiusofZircaloyGuideTube.Name = "txtOuterRadiusofZircaloyGuideTube"
        '
        'ucControlRodEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboControlVolumeBelow)
        Me.Controls.Add(Me.cboControlVolumeAbove)
        Me.Controls.Add(Me.txtVolumebelow)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.txtVolumeAbove)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.LabelX4)
        Me.Name = "ucControlRodEditor"
        Me.Size = New System.Drawing.Size(688, 382)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvFuelRodDimensions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        CType(Me.dgvHyrdraulicVolumes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvRadialMeshSpacing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvInitialTemperatures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVolumeAbove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVolumebelow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvFuelRodDimensions As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents dgvRadialMeshSpacing As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvInitialTemperatures As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents lblAxialNode_InitialTemp As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents txtVolumebelow As DevComponents.Editors.IntegerInput
    Friend WithEvents txtVolumeAbove As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCopytoAll As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdPaste As System.Windows.Forms.Button
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents dgvHyrdraulicVolumes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cboComponent As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtVolume As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents txtIncrement As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents txtAxialNode As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents txtNumberofIntervals As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents txtNumberofIntervalsAcrossGap As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents txtIntervalsAcrossCladding As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents lblAxialNodeNumber As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents cmdCopytoAll2 As System.Windows.Forms.Button
    Friend WithEvents cmdCopy2 As System.Windows.Forms.Button
    Friend WithEvents cmdPaste2 As System.Windows.Forms.Button
    Friend WithEvents cboControlVolumeAbove As System.Windows.Forms.ComboBox
    Friend WithEvents cboControlVolumeBelow As System.Windows.Forms.ComboBox
    Friend WithEvents lblAxialNode As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents txtOuterRadiusofAbsorber As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents txtOuterRadiusofStainlessSteel As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents txtInnerRadiusofZircaloyGuideTube As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents txtOuterRadiusofZircaloyGuideTube As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn

End Class

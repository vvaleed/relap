﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucFuelRodEditor
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdCopytoAll = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdPaste = New System.Windows.Forms.Button()
        Me.dgvFuelRodDimensions = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.lblAxialNode = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.txtFuelPelletRadius = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.txtInnerCladdingRadius = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.txtOuterCladdingRadius = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
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
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.cboMaterial3 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem23 = New DevComponents.Editors.ComboItem()
        Me.ComboItem24 = New DevComponents.Editors.ComboItem()
        Me.ComboItem25 = New DevComponents.Editors.ComboItem()
        Me.ComboItem26 = New DevComponents.Editors.ComboItem()
        Me.ComboItem27 = New DevComponents.Editors.ComboItem()
        Me.ComboItem28 = New DevComponents.Editors.ComboItem()
        Me.ComboItem29 = New DevComponents.Editors.ComboItem()
        Me.ComboItem30 = New DevComponents.Editors.ComboItem()
        Me.ComboItem31 = New DevComponents.Editors.ComboItem()
        Me.ComboItem32 = New DevComponents.Editors.ComboItem()
        Me.ComboItem33 = New DevComponents.Editors.ComboItem()
        Me.cboMaterial2 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ComboItem13 = New DevComponents.Editors.ComboItem()
        Me.ComboItem14 = New DevComponents.Editors.ComboItem()
        Me.ComboItem15 = New DevComponents.Editors.ComboItem()
        Me.ComboItem16 = New DevComponents.Editors.ComboItem()
        Me.ComboItem17 = New DevComponents.Editors.ComboItem()
        Me.ComboItem18 = New DevComponents.Editors.ComboItem()
        Me.ComboItem19 = New DevComponents.Editors.ComboItem()
        Me.ComboItem20 = New DevComponents.Editors.ComboItem()
        Me.ComboItem21 = New DevComponents.Editors.ComboItem()
        Me.ComboItem22 = New DevComponents.Editors.ComboItem()
        Me.cboMaterial1 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem34 = New DevComponents.Editors.ComboItem()
        Me.ComboItem35 = New DevComponents.Editors.ComboItem()
        Me.ComboItem36 = New DevComponents.Editors.ComboItem()
        Me.ComboItem37 = New DevComponents.Editors.ComboItem()
        Me.ComboItem38 = New DevComponents.Editors.ComboItem()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem11 = New DevComponents.Editors.ComboItem()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvAxialPowerfactor = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtAxialPowerFactor = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.dgvRadialPowerProfile = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtRadialPowerFactor = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.txtRadialnode = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.dgvPowerHistory = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtPowerHistory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.txtVolumeAbove = New DevComponents.Editors.IntegerInput()
        Me.txtVolumebelow = New DevComponents.Editors.IntegerInput()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cboControlVolumeAbove = New System.Windows.Forms.ComboBox()
        Me.cboControlVolumeBelow = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFuelRodDimensions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        CType(Me.dgvHyrdraulicVolumes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvRadialMeshSpacing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvInitialTemperatures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvAxialPowerfactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.dgvRadialPowerProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        CType(Me.dgvPowerHistory, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
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
        Me.TabPage1.Text = "Fuel Rod Dimensions"
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
        Me.dgvFuelRodDimensions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lblAxialNode, Me.txtFuelPelletRadius, Me.txtInnerCladdingRadius, Me.txtOuterCladdingRadius})
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
        'lblAxialNode
        '
        Me.lblAxialNode.HeaderText = "Axial Node"
        Me.lblAxialNode.Name = "lblAxialNode"
        '
        'txtFuelPelletRadius
        '
        '
        '
        '
        Me.txtFuelPelletRadius.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFuelPelletRadius.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtFuelPelletRadius.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFuelPelletRadius.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtFuelPelletRadius.DisplayFormat = "0.0000"
        Me.txtFuelPelletRadius.HeaderText = "Fuel Pellet Radius"
        Me.txtFuelPelletRadius.Increment = 1.0R
        Me.txtFuelPelletRadius.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtFuelPelletRadius.Name = "txtFuelPelletRadius"
        '
        'txtInnerCladdingRadius
        '
        '
        '
        '
        Me.txtInnerCladdingRadius.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtInnerCladdingRadius.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtInnerCladdingRadius.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInnerCladdingRadius.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtInnerCladdingRadius.DisplayFormat = "0.0000"
        Me.txtInnerCladdingRadius.HeaderText = "Inner cladding radius"
        Me.txtInnerCladdingRadius.Increment = 1.0R
        Me.txtInnerCladdingRadius.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtInnerCladdingRadius.Name = "txtInnerCladdingRadius"
        '
        'txtOuterCladdingRadius
        '
        '
        '
        '
        Me.txtOuterCladdingRadius.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtOuterCladdingRadius.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtOuterCladdingRadius.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOuterCladdingRadius.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtOuterCladdingRadius.DisplayFormat = "0.0000"
        Me.txtOuterCladdingRadius.HeaderText = "Outer cladding radius"
        Me.txtOuterCladdingRadius.Increment = 1.0R
        Me.txtOuterCladdingRadius.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtOuterCladdingRadius.Name = "txtOuterCladdingRadius"
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
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.cboMaterial3)
        Me.TabPage4.Controls.Add(Me.cboMaterial2)
        Me.TabPage4.Controls.Add(Me.cboMaterial1)
        Me.TabPage4.Controls.Add(Me.LabelX3)
        Me.TabPage4.Controls.Add(Me.LabelX2)
        Me.TabPage4.Controls.Add(Me.LabelX1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(625, 266)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Material Specification"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'cboMaterial3
        '
        Me.cboMaterial3.DisplayMember = "Text"
        Me.cboMaterial3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMaterial3.FormattingEnabled = True
        Me.cboMaterial3.ItemHeight = 14
        Me.cboMaterial3.Items.AddRange(New Object() {Me.ComboItem23, Me.ComboItem24, Me.ComboItem25, Me.ComboItem26, Me.ComboItem27, Me.ComboItem28, Me.ComboItem29, Me.ComboItem30, Me.ComboItem31, Me.ComboItem32, Me.ComboItem33})
        Me.cboMaterial3.Location = New System.Drawing.Point(216, 105)
        Me.cboMaterial3.Name = "cboMaterial3"
        Me.cboMaterial3.Size = New System.Drawing.Size(121, 20)
        Me.cboMaterial3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboMaterial3.TabIndex = 1
        '
        'ComboItem23
        '
        Me.ComboItem23.Text = "Unirradiated fuel, UO2"
        Me.ComboItem23.Value = "6"
        '
        'ComboItem24
        '
        Me.ComboItem24.Text = "Cracked fuel, UO2"
        Me.ComboItem24.Value = "7"
        '
        'ComboItem25
        '
        Me.ComboItem25.Text = "Relocated fuel, UO2"
        Me.ComboItem25.Value = "8"
        '
        'ComboItem26
        '
        Me.ComboItem26.Text = "Steam-gas atmosphere."
        Me.ComboItem26.Value = "9"
        '
        'ComboItem27
        '
        Me.ComboItem27.Text = "Metallic uranium"
        Me.ComboItem27.Value = "13"
        '
        'ComboItem28
        '
        Me.ComboItem28.Text = "Disabled"
        Me.ComboItem28.Value = "14"
        '
        'ComboItem29
        '
        Me.ComboItem29.Text = "Aluminum"
        Me.ComboItem29.Value = "15"
        '
        'ComboItem30
        '
        Me.ComboItem30.Text = "Al2O3"
        Me.ComboItem30.Value = "16"
        '
        'ComboItem31
        '
        Me.ComboItem31.Text = "Lithium"
        Me.ComboItem31.Value = "17"
        '
        'ComboItem32
        '
        Me.ComboItem32.Text = "Stainless steel 3304"
        Me.ComboItem32.Value = "19"
        '
        'ComboItem33
        '
        Me.ComboItem33.Text = "Control rod absorber material (Ag/In/Cd or B4C"
        Me.ComboItem33.Value = "20"
        '
        'cboMaterial2
        '
        Me.cboMaterial2.DisplayMember = "Text"
        Me.cboMaterial2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMaterial2.FormattingEnabled = True
        Me.cboMaterial2.ItemHeight = 14
        Me.cboMaterial2.Items.AddRange(New Object() {Me.ComboItem12, Me.ComboItem13, Me.ComboItem14, Me.ComboItem15, Me.ComboItem16, Me.ComboItem17, Me.ComboItem18, Me.ComboItem19, Me.ComboItem20, Me.ComboItem21, Me.ComboItem22})
        Me.cboMaterial2.Location = New System.Drawing.Point(216, 79)
        Me.cboMaterial2.Name = "cboMaterial2"
        Me.cboMaterial2.Size = New System.Drawing.Size(121, 20)
        Me.cboMaterial2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboMaterial2.TabIndex = 1
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "Unirradiated fuel, UO2"
        Me.ComboItem12.Value = "6"
        '
        'ComboItem13
        '
        Me.ComboItem13.Text = "Cracked fuel, UO2"
        Me.ComboItem13.Value = "7"
        '
        'ComboItem14
        '
        Me.ComboItem14.Text = "Relocated fuel, UO2"
        Me.ComboItem14.Value = "8"
        '
        'ComboItem15
        '
        Me.ComboItem15.Text = "Steam-gas atmosphere."
        Me.ComboItem15.Value = "9"
        '
        'ComboItem16
        '
        Me.ComboItem16.Text = "Metallic uranium"
        Me.ComboItem16.Value = "13"
        '
        'ComboItem17
        '
        Me.ComboItem17.Text = "Disabled"
        Me.ComboItem17.Value = "14"
        '
        'ComboItem18
        '
        Me.ComboItem18.Text = "Aluminum"
        Me.ComboItem18.Value = "15"
        '
        'ComboItem19
        '
        Me.ComboItem19.Text = "Al2O3"
        Me.ComboItem19.Value = "16"
        '
        'ComboItem20
        '
        Me.ComboItem20.Text = "Lithium"
        Me.ComboItem20.Value = "17"
        '
        'ComboItem21
        '
        Me.ComboItem21.Text = "Stainless steel 3304"
        Me.ComboItem21.Value = "19"
        '
        'ComboItem22
        '
        Me.ComboItem22.Text = "Control rod absorber material (Ag/In/Cd or B4C"
        Me.ComboItem22.Value = "20"
        '
        'cboMaterial1
        '
        Me.cboMaterial1.DisplayMember = "Text"
        Me.cboMaterial1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboMaterial1.FormattingEnabled = True
        Me.cboMaterial1.ItemHeight = 14
        Me.cboMaterial1.Items.AddRange(New Object() {Me.ComboItem34, Me.ComboItem35, Me.ComboItem36, Me.ComboItem37, Me.ComboItem38, Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4, Me.ComboItem5, Me.ComboItem6, Me.ComboItem7, Me.ComboItem8, Me.ComboItem9, Me.ComboItem10, Me.ComboItem11})
        Me.cboMaterial1.Location = New System.Drawing.Point(216, 53)
        Me.cboMaterial1.Name = "cboMaterial1"
        Me.cboMaterial1.Size = New System.Drawing.Size(121, 20)
        Me.cboMaterial1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboMaterial1.TabIndex = 1
        '
        'ComboItem34
        '
        Me.ComboItem34.Text = "Zircaloy"
        Me.ComboItem34.Value = "1"
        '
        'ComboItem35
        '
        Me.ComboItem35.Text = "Zr-U-O misture (liquid)"
        Me.ComboItem35.Value = "2"
        '
        'ComboItem36
        '
        Me.ComboItem36.Text = "Zr-U-O misture (frozen)"
        Me.ComboItem36.Value = "3"
        '
        'ComboItem37
        '
        Me.ComboItem37.Text = "Tungston"
        Me.ComboItem37.Value = "4"
        '
        'ComboItem38
        '
        Me.ComboItem38.Text = "ZrO2"
        Me.ComboItem38.Value = "5"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Unirradiated fuel, UO2"
        Me.ComboItem1.Value = "6"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Cracked fuel, UO2"
        Me.ComboItem2.Value = "7"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "Relocated fuel, UO2"
        Me.ComboItem3.Value = "8"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "Steam-gas atmosphere."
        Me.ComboItem4.Value = "9"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "Metallic uranium"
        Me.ComboItem5.Value = "13"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "Disabled"
        Me.ComboItem6.Value = "14"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "Aluminum"
        Me.ComboItem7.Value = "15"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "Al2O3"
        Me.ComboItem8.Value = "16"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "Lithium"
        Me.ComboItem9.Value = "17"
        '
        'ComboItem10
        '
        Me.ComboItem10.Text = "Stainless steel 3304"
        Me.ComboItem10.Value = "19"
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "Control rod absorber material (Ag/In/Cd or B4C"
        Me.ComboItem11.Value = "20"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(28, 105)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(202, 20)
        Me.LabelX3.TabIndex = 0
        Me.LabelX3.Text = "Material layer 3"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(28, 79)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(202, 20)
        Me.LabelX2.TabIndex = 0
        Me.LabelX2.Text = "Material layer 2"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(28, 53)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(202, 20)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Material layer closest to center of rod."
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgvAxialPowerfactor)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(625, 266)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Axial Power Profile Data"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvAxialPowerfactor
        '
        Me.dgvAxialPowerfactor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAxialPowerfactor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAxialPowerfactor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txtAxialPowerFactor})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAxialPowerfactor.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvAxialPowerfactor.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvAxialPowerfactor.Location = New System.Drawing.Point(32, 17)
        Me.dgvAxialPowerfactor.Name = "dgvAxialPowerfactor"
        Me.dgvAxialPowerfactor.Size = New System.Drawing.Size(240, 150)
        Me.dgvAxialPowerfactor.TabIndex = 0
        '
        'txtAxialPowerFactor
        '
        '
        '
        '
        Me.txtAxialPowerFactor.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtAxialPowerFactor.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtAxialPowerFactor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAxialPowerFactor.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtAxialPowerFactor.HeaderText = "Axial power factor at axial nodes"
        Me.txtAxialPowerFactor.Increment = 0.1R
        Me.txtAxialPowerFactor.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtAxialPowerFactor.MaxValue = 1.4R
        Me.txtAxialPowerFactor.MinValue = 0.1R
        Me.txtAxialPowerFactor.Name = "txtAxialPowerFactor"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.dgvRadialPowerProfile)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(625, 266)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Radial Power Profile"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'dgvRadialPowerProfile
        '
        Me.dgvRadialPowerProfile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRadialPowerProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRadialPowerProfile.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txtRadialPowerFactor, Me.txtRadialnode})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRadialPowerProfile.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvRadialPowerProfile.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvRadialPowerProfile.Location = New System.Drawing.Point(34, 26)
        Me.dgvRadialPowerProfile.Name = "dgvRadialPowerProfile"
        Me.dgvRadialPowerProfile.Size = New System.Drawing.Size(403, 150)
        Me.dgvRadialPowerProfile.TabIndex = 0
        '
        'txtRadialPowerFactor
        '
        '
        '
        '
        Me.txtRadialPowerFactor.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtRadialPowerFactor.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtRadialPowerFactor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRadialPowerFactor.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtRadialPowerFactor.HeaderText = "Radial Power Factor"
        Me.txtRadialPowerFactor.Increment = 1.0R
        Me.txtRadialPowerFactor.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtRadialPowerFactor.Name = "txtRadialPowerFactor"
        '
        'txtRadialnode
        '
        '
        '
        '
        Me.txtRadialnode.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtRadialnode.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtRadialnode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRadialnode.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtRadialnode.HeaderText = "Radial Node"
        Me.txtRadialnode.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtRadialnode.Name = "txtRadialnode"
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.dgvPowerHistory)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(625, 266)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Previous Power History"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'dgvPowerHistory
        '
        Me.dgvPowerHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPowerHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPowerHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txtPowerHistory, Me.txtTime})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPowerHistory.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvPowerHistory.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvPowerHistory.Location = New System.Drawing.Point(40, 28)
        Me.dgvPowerHistory.Name = "dgvPowerHistory"
        Me.dgvPowerHistory.Size = New System.Drawing.Size(445, 150)
        Me.dgvPowerHistory.TabIndex = 0
        '
        'txtPowerHistory
        '
        Me.txtPowerHistory.HeaderText = "Power history"
        Me.txtPowerHistory.Name = "txtPowerHistory"
        '
        'txtTime
        '
        Me.txtTime.HeaderText = "Time"
        Me.txtTime.Name = "txtTime"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(23, 316)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(213, 20)
        Me.LabelX4.TabIndex = 3
        Me.LabelX4.Text = "Control volume located just above fuel rod"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(23, 342)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(213, 20)
        Me.LabelX5.TabIndex = 3
        Me.LabelX5.Text = "Control volume located just below fuel rod"
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
        'ucFuelRodEditor
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
        Me.Name = "ucFuelRodEditor"
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
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvAxialPowerfactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.dgvRadialPowerProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        CType(Me.dgvPowerHistory, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents cboMaterial3 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem23 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem24 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem25 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem26 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem27 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem28 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem29 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem30 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem31 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem32 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem33 As DevComponents.Editors.ComboItem
    Friend WithEvents cboMaterial2 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem13 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem14 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem15 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem16 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem17 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem18 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem19 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem20 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem21 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem22 As DevComponents.Editors.ComboItem
    Friend WithEvents cboMaterial1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents dgvAxialPowerfactor As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtAxialPowerFactor As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents dgvRadialPowerProfile As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtRadialPowerFactor As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents txtRadialnode As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents dgvPowerHistory As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtPowerHistory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtVolumebelow As DevComponents.Editors.IntegerInput
    Friend WithEvents txtVolumeAbove As DevComponents.Editors.IntegerInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCopytoAll As System.Windows.Forms.Button
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdPaste As System.Windows.Forms.Button
    Friend WithEvents lblAxialNode As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents txtFuelPelletRadius As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents txtInnerCladdingRadius As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents txtOuterCladdingRadius As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
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
    Friend WithEvents ComboItem34 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem35 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem36 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem37 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem38 As DevComponents.Editors.ComboItem
    Friend WithEvents cmdCopytoAll2 As System.Windows.Forms.Button
    Friend WithEvents cmdCopy2 As System.Windows.Forms.Button
    Friend WithEvents cmdPaste2 As System.Windows.Forms.Button
    Friend WithEvents cboControlVolumeAbove As System.Windows.Forms.ComboBox
    Friend WithEvents cboControlVolumeBelow As System.Windows.Forms.ComboBox

End Class

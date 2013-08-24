<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucHeatStructureEditor2
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvtab1 = New System.Windows.Forms.DataGridView()
        Me.leftBoundaryVolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeftIncrement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeftBoundaryConditionType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.leftSurfaceAreaSelection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftSurfaceArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftHeatStructureNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvTab2 = New System.Windows.Forms.DataGridView()
        Me.RightBoundaryVolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightIncrement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightBoundaryConditionType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.RightSurfaceAreaSelection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightSurfaceArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightHeatStructureNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvTab3 = New System.Windows.Forms.DataGridView()
        Me.SourceType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InternalSourceMultiplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirectModeratorHeatingMultiplierLeft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirectModeratorHeatingMultiplierRight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourceHeatStructureNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvTab4 = New System.Windows.Forms.DataGridView()
        Me.leftHeatedEquivalentDiameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeftHeatedLengthForward = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeftHeatedLengthReverse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftGridSpacerLengthForward = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftGridSpacerLengthReverse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftGridLossCoefficientForward = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftGridLossCoefficientReverse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftLocalBoilingFactor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftNaturalCirculationLength = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftPitchtoDiameterRatio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftFoulingFactor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftAddHeatStructureNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvTab5 = New System.Windows.Forms.DataGridView()
        Me.rightHeatedEquivalentDiameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightHeatedLengthForward = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightHeatedLengthReverse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightGridSpacerLengthForward = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightGridSpacerLengthReverse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightGridLossCoefficientForward = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightGridLossCoefficientReverse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightLocalBoilingFactor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightNaturalCirculationLength = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightPitchtoDiameterRatio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightFoulingFactor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rightAddHeatStructureNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvtab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvTab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvTab3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvTab4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvTab5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(975, 425)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvtab1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(967, 399)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Left Boundary Conditions"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvtab1
        '
        Me.dgvtab1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvtab1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvtab1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtab1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.leftBoundaryVolumeNumber, Me.LeftIncrement, Me.LeftBoundaryConditionType, Me.leftSurfaceAreaSelection, Me.leftSurfaceArea, Me.leftHeatStructureNumber})
        Me.dgvtab1.Location = New System.Drawing.Point(22, 17)
        Me.dgvtab1.Name = "dgvtab1"
        Me.dgvtab1.Size = New System.Drawing.Size(917, 376)
        Me.dgvtab1.TabIndex = 0
        '
        'leftBoundaryVolumeNumber
        '
        Me.leftBoundaryVolumeNumber.FillWeight = 60.0!
        Me.leftBoundaryVolumeNumber.HeaderText = "Boundary Volume Number"
        Me.leftBoundaryVolumeNumber.Name = "leftBoundaryVolumeNumber"
        '
        'LeftIncrement
        '
        Me.LeftIncrement.FillWeight = 59.08629!
        Me.LeftIncrement.HeaderText = "Increment"
        Me.LeftIncrement.Name = "LeftIncrement"
        '
        'LeftBoundaryConditionType
        '
        Me.LeftBoundaryConditionType.FillWeight = 59.08629!
        Me.LeftBoundaryConditionType.HeaderText = "Boundary Condition Type"
        Me.LeftBoundaryConditionType.Items.AddRange(New Object() {"Default", "Insulated Boundary", "Verticle bundle without crossflow", "Verticle bundle with crossflow", "Flat plate above fluid", "Horizontal bundle"})
        Me.LeftBoundaryConditionType.Name = "LeftBoundaryConditionType"
        Me.LeftBoundaryConditionType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeftBoundaryConditionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'leftSurfaceAreaSelection
        '
        Me.leftSurfaceAreaSelection.FillWeight = 59.08629!
        Me.leftSurfaceAreaSelection.HeaderText = "Surface Area Selection"
        Me.leftSurfaceAreaSelection.Name = "leftSurfaceAreaSelection"
        '
        'leftSurfaceArea
        '
        Me.leftSurfaceArea.FillWeight = 59.08629!
        Me.leftSurfaceArea.HeaderText = "Surface Area"
        Me.leftSurfaceArea.Name = "leftSurfaceArea"
        '
        'leftHeatStructureNumber
        '
        Me.leftHeatStructureNumber.FillWeight = 59.08629!
        Me.leftHeatStructureNumber.HeaderText = "Heat Structure Number"
        Me.leftHeatStructureNumber.Name = "leftHeatStructureNumber"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvTab2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(967, 399)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Right Boundary Conditions"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvTab2
        '
        Me.dgvTab2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTab2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvTab2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTab2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RightBoundaryVolumeNumber, Me.RightIncrement, Me.RightBoundaryConditionType, Me.RightSurfaceAreaSelection, Me.RightSurfaceArea, Me.RightHeatStructureNumber})
        Me.dgvTab2.Location = New System.Drawing.Point(21, 17)
        Me.dgvTab2.Name = "dgvTab2"
        Me.dgvTab2.Size = New System.Drawing.Size(917, 376)
        Me.dgvTab2.TabIndex = 1
        '
        'RightBoundaryVolumeNumber
        '
        Me.RightBoundaryVolumeNumber.FillWeight = 33.0!
        Me.RightBoundaryVolumeNumber.HeaderText = "Boundary Volume Number"
        Me.RightBoundaryVolumeNumber.Name = "RightBoundaryVolumeNumber"
        '
        'RightIncrement
        '
        Me.RightIncrement.FillWeight = 33.40101!
        Me.RightIncrement.HeaderText = "Increment"
        Me.RightIncrement.Name = "RightIncrement"
        '
        'RightBoundaryConditionType
        '
        Me.RightBoundaryConditionType.FillWeight = 33.40101!
        Me.RightBoundaryConditionType.HeaderText = "Boundary Condition Type"
        Me.RightBoundaryConditionType.Items.AddRange(New Object() {"Default", "Insulated Boundary", "Verticle bundle without crossflow", "Verticle bundle with crossflow", "Flat plate above fluid", "Horizontal bundle"})
        Me.RightBoundaryConditionType.Name = "RightBoundaryConditionType"
        Me.RightBoundaryConditionType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RightBoundaryConditionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'RightSurfaceAreaSelection
        '
        Me.RightSurfaceAreaSelection.FillWeight = 33.40101!
        Me.RightSurfaceAreaSelection.HeaderText = "Surface Area Selection"
        Me.RightSurfaceAreaSelection.Name = "RightSurfaceAreaSelection"
        '
        'RightSurfaceArea
        '
        Me.RightSurfaceArea.FillWeight = 33.40101!
        Me.RightSurfaceArea.HeaderText = "Surface Area"
        Me.RightSurfaceArea.Name = "RightSurfaceArea"
        '
        'RightHeatStructureNumber
        '
        Me.RightHeatStructureNumber.FillWeight = 33.40101!
        Me.RightHeatStructureNumber.HeaderText = "Heat Structure Number"
        Me.RightHeatStructureNumber.Name = "RightHeatStructureNumber"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvTab3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(967, 399)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Source Data"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvTab3
        '
        Me.dgvTab3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTab3.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvTab3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTab3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SourceType, Me.InternalSourceMultiplier, Me.DirectModeratorHeatingMultiplierLeft, Me.DirectModeratorHeatingMultiplierRight, Me.SourceHeatStructureNumber})
        Me.dgvTab3.Location = New System.Drawing.Point(28, 24)
        Me.dgvTab3.Name = "dgvTab3"
        Me.dgvTab3.Size = New System.Drawing.Size(915, 372)
        Me.dgvTab3.TabIndex = 0
        '
        'SourceType
        '
        Me.SourceType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SourceType.HeaderText = "Source Type"
        Me.SourceType.Name = "SourceType"
        '
        'InternalSourceMultiplier
        '
        Me.InternalSourceMultiplier.HeaderText = "Internal Source Multiplier"
        Me.InternalSourceMultiplier.Name = "InternalSourceMultiplier"
        '
        'DirectModeratorHeatingMultiplierLeft
        '
        Me.DirectModeratorHeatingMultiplierLeft.HeaderText = "Direct Moderator Heating Multiplier For Left Boundary"
        Me.DirectModeratorHeatingMultiplierLeft.Name = "DirectModeratorHeatingMultiplierLeft"
        '
        'DirectModeratorHeatingMultiplierRight
        '
        Me.DirectModeratorHeatingMultiplierRight.HeaderText = "Direct Moderator Heating Multiplier For Right Boundary"
        Me.DirectModeratorHeatingMultiplierRight.Name = "DirectModeratorHeatingMultiplierRight"
        '
        'SourceHeatStructureNumber
        '
        Me.SourceHeatStructureNumber.HeaderText = "Heat Structure Number"
        Me.SourceHeatStructureNumber.Name = "SourceHeatStructureNumber"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvTab4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(967, 399)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Additional Left Boundary Conditions"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvTab4
        '
        Me.dgvTab4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTab4.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvTab4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTab4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.leftHeatedEquivalentDiameter, Me.LeftHeatedLengthForward, Me.LeftHeatedLengthReverse, Me.leftGridSpacerLengthForward, Me.leftGridSpacerLengthReverse, Me.leftGridLossCoefficientForward, Me.leftGridLossCoefficientReverse, Me.leftLocalBoilingFactor, Me.leftNaturalCirculationLength, Me.leftPitchtoDiameterRatio, Me.leftFoulingFactor, Me.leftAddHeatStructureNumber})
        Me.dgvTab4.Location = New System.Drawing.Point(28, 21)
        Me.dgvTab4.Name = "dgvTab4"
        Me.dgvTab4.Size = New System.Drawing.Size(913, 375)
        Me.dgvTab4.TabIndex = 0
        '
        'leftHeatedEquivalentDiameter
        '
        Me.leftHeatedEquivalentDiameter.HeaderText = "Heated Equivalent Diameter"
        Me.leftHeatedEquivalentDiameter.Name = "leftHeatedEquivalentDiameter"
        '
        'LeftHeatedLengthForward
        '
        Me.LeftHeatedLengthForward.HeaderText = "Heated Length Forward"
        Me.LeftHeatedLengthForward.Name = "LeftHeatedLengthForward"
        '
        'LeftHeatedLengthReverse
        '
        Me.LeftHeatedLengthReverse.HeaderText = "Heated Length Reverse"
        Me.LeftHeatedLengthReverse.Name = "LeftHeatedLengthReverse"
        '
        'leftGridSpacerLengthForward
        '
        Me.leftGridSpacerLengthForward.HeaderText = "Grid Spacer Length Forward"
        Me.leftGridSpacerLengthForward.Name = "leftGridSpacerLengthForward"
        '
        'leftGridSpacerLengthReverse
        '
        Me.leftGridSpacerLengthReverse.HeaderText = "Grid Spacer Length Reverse"
        Me.leftGridSpacerLengthReverse.Name = "leftGridSpacerLengthReverse"
        '
        'leftGridLossCoefficientForward
        '
        Me.leftGridLossCoefficientForward.HeaderText = "Grid Loss Coefficient Forward"
        Me.leftGridLossCoefficientForward.Name = "leftGridLossCoefficientForward"
        '
        'leftGridLossCoefficientReverse
        '
        Me.leftGridLossCoefficientReverse.HeaderText = "Grid Loss Coefficient Reverse"
        Me.leftGridLossCoefficientReverse.Name = "leftGridLossCoefficientReverse"
        '
        'leftLocalBoilingFactor
        '
        Me.leftLocalBoilingFactor.HeaderText = "Local Boiling Factor"
        Me.leftLocalBoilingFactor.Name = "leftLocalBoilingFactor"
        '
        'leftNaturalCirculationLength
        '
        Me.leftNaturalCirculationLength.HeaderText = "Natural Circulation Length"
        Me.leftNaturalCirculationLength.Name = "leftNaturalCirculationLength"
        '
        'leftPitchtoDiameterRatio
        '
        Me.leftPitchtoDiameterRatio.HeaderText = "Pitch to Diameter Ratio"
        Me.leftPitchtoDiameterRatio.Name = "leftPitchtoDiameterRatio"
        '
        'leftFoulingFactor
        '
        Me.leftFoulingFactor.HeaderText = "Fouling Factor"
        Me.leftFoulingFactor.Name = "leftFoulingFactor"
        '
        'leftAddHeatStructureNumber
        '
        Me.leftAddHeatStructureNumber.HeaderText = "Heat Structure Number"
        Me.leftAddHeatStructureNumber.Name = "leftAddHeatStructureNumber"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgvTab5)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(967, 399)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Additional Right Boundary Conditions"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvTab5
        '
        Me.dgvTab5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTab5.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvTab5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTab5.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rightHeatedEquivalentDiameter, Me.rightHeatedLengthForward, Me.rightHeatedLengthReverse, Me.rightGridSpacerLengthForward, Me.rightGridSpacerLengthReverse, Me.rightGridLossCoefficientForward, Me.rightGridLossCoefficientReverse, Me.rightLocalBoilingFactor, Me.rightNaturalCirculationLength, Me.rightPitchtoDiameterRatio, Me.rightFoulingFactor, Me.rightAddHeatStructureNumber})
        Me.dgvTab5.Location = New System.Drawing.Point(25, 23)
        Me.dgvTab5.Name = "dgvTab5"
        Me.dgvTab5.Size = New System.Drawing.Size(913, 373)
        Me.dgvTab5.TabIndex = 1
        '
        'rightHeatedEquivalentDiameter
        '
        Me.rightHeatedEquivalentDiameter.HeaderText = "Heated Equivalent Diameter"
        Me.rightHeatedEquivalentDiameter.Name = "rightHeatedEquivalentDiameter"
        '
        'rightHeatedLengthForward
        '
        Me.rightHeatedLengthForward.HeaderText = "Heated Length Forward"
        Me.rightHeatedLengthForward.Name = "rightHeatedLengthForward"
        '
        'rightHeatedLengthReverse
        '
        Me.rightHeatedLengthReverse.HeaderText = "Heated Length Reverse"
        Me.rightHeatedLengthReverse.Name = "rightHeatedLengthReverse"
        '
        'rightGridSpacerLengthForward
        '
        Me.rightGridSpacerLengthForward.HeaderText = "Grid Spacer Length Forward"
        Me.rightGridSpacerLengthForward.Name = "rightGridSpacerLengthForward"
        '
        'rightGridSpacerLengthReverse
        '
        Me.rightGridSpacerLengthReverse.HeaderText = "Grid Spacer Length Reverse"
        Me.rightGridSpacerLengthReverse.Name = "rightGridSpacerLengthReverse"
        '
        'rightGridLossCoefficientForward
        '
        Me.rightGridLossCoefficientForward.HeaderText = "Grid Loss Coefficient Forward"
        Me.rightGridLossCoefficientForward.Name = "rightGridLossCoefficientForward"
        '
        'rightGridLossCoefficientReverse
        '
        Me.rightGridLossCoefficientReverse.HeaderText = "Grid Loss Coefficient Reverse"
        Me.rightGridLossCoefficientReverse.Name = "rightGridLossCoefficientReverse"
        '
        'rightLocalBoilingFactor
        '
        Me.rightLocalBoilingFactor.HeaderText = "Local Boiling Factor"
        Me.rightLocalBoilingFactor.Name = "rightLocalBoilingFactor"
        '
        'rightNaturalCirculationLength
        '
        Me.rightNaturalCirculationLength.HeaderText = "Natural Circulation Length"
        Me.rightNaturalCirculationLength.Name = "rightNaturalCirculationLength"
        '
        'rightPitchtoDiameterRatio
        '
        Me.rightPitchtoDiameterRatio.HeaderText = "Pitch to Diameter Ratio"
        Me.rightPitchtoDiameterRatio.Name = "rightPitchtoDiameterRatio"
        '
        'rightFoulingFactor
        '
        Me.rightFoulingFactor.HeaderText = "Fouling Factor"
        Me.rightFoulingFactor.Name = "rightFoulingFactor"
        '
        'rightAddHeatStructureNumber
        '
        Me.rightAddHeatStructureNumber.HeaderText = "Heat Structure Number"
        Me.rightAddHeatStructureNumber.Name = "rightAddHeatStructureNumber"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(806, 434)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'ucHeatStructureEditor2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ucHeatStructureEditor2"
        Me.Size = New System.Drawing.Size(978, 486)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvtab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvTab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvTab3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvTab4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvTab5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvtab1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents dgvTab2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTab3 As System.Windows.Forms.DataGridView
    Friend WithEvents SourceType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InternalSourceMultiplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DirectModeratorHeatingMultiplierLeft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DirectModeratorHeatingMultiplierRight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceHeatStructureNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvTab4 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTab5 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents rightHeatedEquivalentDiameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightHeatedLengthForward As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightHeatedLengthReverse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightGridSpacerLengthForward As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightGridSpacerLengthReverse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightGridLossCoefficientForward As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightGridLossCoefficientReverse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightLocalBoilingFactor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightNaturalCirculationLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightPitchtoDiameterRatio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightFoulingFactor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rightAddHeatStructureNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftBoundaryVolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeftIncrement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeftBoundaryConditionType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents leftSurfaceAreaSelection As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftSurfaceArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftHeatStructureNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightBoundaryVolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightIncrement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightBoundaryConditionType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents RightSurfaceAreaSelection As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightSurfaceArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightHeatStructureNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftHeatedEquivalentDiameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeftHeatedLengthForward As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeftHeatedLengthReverse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftGridSpacerLengthForward As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftGridSpacerLengthReverse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftGridLossCoefficientForward As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftGridLossCoefficientReverse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftLocalBoilingFactor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftNaturalCirculationLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftPitchtoDiameterRatio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftFoulingFactor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftAddHeatStructureNumber As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

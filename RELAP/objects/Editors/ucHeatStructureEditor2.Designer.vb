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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgvtab1 = New System.Windows.Forms.DataGridView()
        Me.dgvTab2 = New System.Windows.Forms.DataGridView()
        Me.dgvTab3 = New System.Windows.Forms.DataGridView()
        Me.leftBoundaryVolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeftIncrement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeftBoundaryConditionType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftSurfaceAreaSelection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftSurfaceArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leftHeatStructureNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightBoundaryVolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightIncrement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightBoundaryConditionType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightSurfaceAreaSelection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightSurfaceArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightHeatStructureNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourceType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InternalSourceMultiplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirectModeratorHeatingMultiplierLeft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirectModeratorHeatingMultiplierRight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SourceHeatStructureNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgvtab1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTab2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTab3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTab4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(3, 15)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(975, 456)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvtab1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(967, 430)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Left Boundary Conditions"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvTab2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(967, 430)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Right Boundary Conditions"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvTab3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(967, 430)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Source Data"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvTab4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(967, 430)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Additional Left Boundary Conditions"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.DataGridView1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(967, 430)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Additional Right Boundary Conditions"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgvtab1
        '
        Me.dgvtab1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvtab1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvtab1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.leftBoundaryVolumeNumber, Me.LeftIncrement, Me.LeftBoundaryConditionType, Me.leftSurfaceAreaSelection, Me.leftSurfaceArea, Me.leftHeatStructureNumber})
        Me.dgvtab1.Location = New System.Drawing.Point(22, 17)
        Me.dgvtab1.Name = "dgvtab1"
        Me.dgvtab1.Size = New System.Drawing.Size(917, 240)
        Me.dgvtab1.TabIndex = 0
        '
        'dgvTab2
        '
        Me.dgvTab2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvTab2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTab2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RightBoundaryVolumeNumber, Me.RightIncrement, Me.RightBoundaryConditionType, Me.RightSurfaceAreaSelection, Me.RightSurfaceArea, Me.RightHeatStructureNumber})
        Me.dgvTab2.Location = New System.Drawing.Point(21, 17)
        Me.dgvTab2.Name = "dgvTab2"
        Me.dgvTab2.Size = New System.Drawing.Size(917, 240)
        Me.dgvTab2.TabIndex = 1
        '
        'dgvTab3
        '
        Me.dgvTab3.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvTab3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTab3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SourceType, Me.InternalSourceMultiplier, Me.DirectModeratorHeatingMultiplierLeft, Me.DirectModeratorHeatingMultiplierRight, Me.SourceHeatStructureNumber})
        Me.dgvTab3.Location = New System.Drawing.Point(27, 24)
        Me.dgvTab3.Name = "dgvTab3"
        Me.dgvTab3.Size = New System.Drawing.Size(915, 255)
        Me.dgvTab3.TabIndex = 0
        '
        'leftBoundaryVolumeNumber
        '
        Me.leftBoundaryVolumeNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.leftBoundaryVolumeNumber.FillWeight = 200.0!
        Me.leftBoundaryVolumeNumber.HeaderText = "Boundary Volume Number"
        Me.leftBoundaryVolumeNumber.MinimumWidth = 374
        Me.leftBoundaryVolumeNumber.Name = "leftBoundaryVolumeNumber"
        Me.leftBoundaryVolumeNumber.Width = 374
        '
        'LeftIncrement
        '
        Me.LeftIncrement.HeaderText = "Increment"
        Me.LeftIncrement.Name = "LeftIncrement"
        '
        'LeftBoundaryConditionType
        '
        Me.LeftBoundaryConditionType.HeaderText = "Boundary Condition Type"
        Me.LeftBoundaryConditionType.Name = "LeftBoundaryConditionType"
        '
        'leftSurfaceAreaSelection
        '
        Me.leftSurfaceAreaSelection.HeaderText = "Surface Area Selection"
        Me.leftSurfaceAreaSelection.Name = "leftSurfaceAreaSelection"
        '
        'leftSurfaceArea
        '
        Me.leftSurfaceArea.HeaderText = "Surface Area"
        Me.leftSurfaceArea.Name = "leftSurfaceArea"
        '
        'leftHeatStructureNumber
        '
        Me.leftHeatStructureNumber.HeaderText = "Heat Structure Number"
        Me.leftHeatStructureNumber.Name = "leftHeatStructureNumber"
        '
        'RightBoundaryVolumeNumber
        '
        Me.RightBoundaryVolumeNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.RightBoundaryVolumeNumber.FillWeight = 200.0!
        Me.RightBoundaryVolumeNumber.HeaderText = "Boundary Volume Number"
        Me.RightBoundaryVolumeNumber.MinimumWidth = 374
        Me.RightBoundaryVolumeNumber.Name = "RightBoundaryVolumeNumber"
        Me.RightBoundaryVolumeNumber.Width = 374
        '
        'RightIncrement
        '
        Me.RightIncrement.HeaderText = "Increment"
        Me.RightIncrement.Name = "RightIncrement"
        '
        'RightBoundaryConditionType
        '
        Me.RightBoundaryConditionType.HeaderText = "Boundary Condition Type"
        Me.RightBoundaryConditionType.Name = "RightBoundaryConditionType"
        '
        'RightSurfaceAreaSelection
        '
        Me.RightSurfaceAreaSelection.HeaderText = "Surface Area Selection"
        Me.RightSurfaceAreaSelection.Name = "RightSurfaceAreaSelection"
        '
        'RightSurfaceArea
        '
        Me.RightSurfaceArea.HeaderText = "Surface Area"
        Me.RightSurfaceArea.Name = "RightSurfaceArea"
        '
        'RightHeatStructureNumber
        '
        Me.RightHeatStructureNumber.HeaderText = "Heat Structure Number"
        Me.RightHeatStructureNumber.Name = "RightHeatStructureNumber"
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
        'dgvTab4
        '
        Me.dgvTab4.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvTab4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTab4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.leftHeatedEquivalentDiameter, Me.LeftHeatedLengthForward, Me.LeftHeatedLengthReverse, Me.leftGridSpacerLengthForward, Me.leftGridSpacerLengthReverse, Me.leftGridLossCoefficientForward, Me.leftGridLossCoefficientReverse, Me.leftLocalBoilingFactor, Me.leftNaturalCirculationLength, Me.leftPitchtoDiameterRatio, Me.leftFoulingFactor, Me.leftAddHeatStructureNumber})
        Me.dgvTab4.Location = New System.Drawing.Point(29, 21)
        Me.dgvTab4.Name = "dgvTab4"
        Me.dgvTab4.Size = New System.Drawing.Size(913, 298)
        Me.dgvTab4.TabIndex = 0
        '
        'leftHeatedEquivalentDiameter
        '
        Me.leftHeatedEquivalentDiameter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
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
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        Me.DataGridView1.Location = New System.Drawing.Point(21, 23)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(913, 298)
        Me.DataGridView1.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Heated Equivalent Diameter"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Heated Length Forward"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Heated Length Reverse"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Grid Spacer Length Forward"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Grid Spacer Length Reverse"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Grid Loss Coefficient Forward"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Grid Loss Coefficient Reverse"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Local Boiling Factor"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Natural Circulation Length"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Pitch to Diameter Ratio"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Fouling Factor"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Heat Structure Number"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'ucHeatStructureEditor2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ucHeatStructureEditor2"
        Me.Size = New System.Drawing.Size(978, 486)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgvtab1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTab2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTab3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTab4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents leftBoundaryVolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeftIncrement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeftBoundaryConditionType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftSurfaceAreaSelection As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftSurfaceArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents leftHeatStructureNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightBoundaryVolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightIncrement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightBoundaryConditionType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightSurfaceAreaSelection As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightSurfaceArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightHeatStructureNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InternalSourceMultiplier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DirectModeratorHeatingMultiplierLeft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DirectModeratorHeatingMultiplierRight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SourceHeatStructureNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvTab4 As System.Windows.Forms.DataGridView
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
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

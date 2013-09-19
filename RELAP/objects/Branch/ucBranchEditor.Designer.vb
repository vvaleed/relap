<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBranchEditor
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
        Me.dgvBranch = New System.Windows.Forms.DataGridView()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.CheckBoxEntermass = New System.Windows.Forms.CheckBox()
        Me.FromComponent = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.FromComponentVolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FromFaceNumber = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ToComponent = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ToComponentVolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToFaceNumber = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.JunctionArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FFLossCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFlossCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubcooledDischargeCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TwoPhaseDischargeCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperheatedDischargeCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LiquidMassFlow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VaporMassFlow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBranch
        '
        Me.dgvBranch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBranch.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBranch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FromComponent, Me.FromComponentVolumeNumber, Me.FromFaceNumber, Me.ToComponent, Me.ToComponentVolumeNumber, Me.ToFaceNumber, Me.JunctionArea, Me.FFLossCo, Me.RFlossCo, Me.SubcooledDischargeCo, Me.TwoPhaseDischargeCo, Me.SuperheatedDischargeCo, Me.LiquidMassFlow, Me.VaporMassFlow})
        Me.dgvBranch.Location = New System.Drawing.Point(3, 35)
        Me.dgvBranch.Name = "dgvBranch"
        Me.dgvBranch.Size = New System.Drawing.Size(1273, 374)
        Me.dgvBranch.TabIndex = 0
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(1169, 424)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'CheckBoxEntermass
        '
        Me.CheckBoxEntermass.AutoSize = True
        Me.CheckBoxEntermass.Location = New System.Drawing.Point(18, 12)
        Me.CheckBoxEntermass.Name = "CheckBoxEntermass"
        Me.CheckBoxEntermass.Size = New System.Drawing.Size(109, 17)
        Me.CheckBoxEntermass.TabIndex = 2
        Me.CheckBoxEntermass.Text = "Enter Mass Flows"
        Me.CheckBoxEntermass.UseVisualStyleBackColor = True
        '
        'FromComponent
        '
        Me.FromComponent.HeaderText = "From Component"
        Me.FromComponent.Name = "FromComponent"
        '
        'FromComponentVolumeNumber
        '
        Me.FromComponentVolumeNumber.HeaderText = "Component Volume Number"
        Me.FromComponentVolumeNumber.Name = "FromComponentVolumeNumber"
        '
        'FromFaceNumber
        '
        Me.FromFaceNumber.HeaderText = "Face Number"
        Me.FromFaceNumber.Items.AddRange(New Object() {"inlet x-coordinate", "outlet x-coordinate", "inlet y-coordinate", "outlet y-coordinate", "inlet z-coordinate", "outlet z-coordinate"})
        Me.FromFaceNumber.Name = "FromFaceNumber"
        '
        'ToComponent
        '
        Me.ToComponent.HeaderText = "To Component"
        Me.ToComponent.Name = "ToComponent"
        '
        'ToComponentVolumeNumber
        '
        Me.ToComponentVolumeNumber.HeaderText = "Component Volume Number"
        Me.ToComponentVolumeNumber.Name = "ToComponentVolumeNumber"
        '
        'ToFaceNumber
        '
        Me.ToFaceNumber.HeaderText = "Face Number"
        Me.ToFaceNumber.Items.AddRange(New Object() {"inlet x-coordinate", "outlet x-coordinate", "inlet y-coordinate", "outlet y-coordinate", "inlet z-coordinate", "outlet z-coordinate"})
        Me.ToFaceNumber.Name = "ToFaceNumber"
        '
        'JunctionArea
        '
        Me.JunctionArea.HeaderText = "Junction Area"
        Me.JunctionArea.Name = "JunctionArea"
        '
        'FFLossCo
        '
        Me.FFLossCo.HeaderText = "Forward Flow Energy Loss Coefficient"
        Me.FFLossCo.Name = "FFLossCo"
        '
        'RFlossCo
        '
        Me.RFlossCo.HeaderText = "Reverse Flow Energy Loss Coefficient"
        Me.RFlossCo.Name = "RFlossCo"
        '
        'SubcooledDischargeCo
        '
        Me.SubcooledDischargeCo.HeaderText = "Subcooled Discharge Coefficient"
        Me.SubcooledDischargeCo.Name = "SubcooledDischargeCo"
        '
        'TwoPhaseDischargeCo
        '
        Me.TwoPhaseDischargeCo.HeaderText = "Two Phase Discharge Coefficient"
        Me.TwoPhaseDischargeCo.Name = "TwoPhaseDischargeCo"
        '
        'SuperheatedDischargeCo
        '
        Me.SuperheatedDischargeCo.HeaderText = "Superheated Discharge Coefficient"
        Me.SuperheatedDischargeCo.Name = "SuperheatedDischargeCo"
        '
        'LiquidMassFlow
        '
        Me.LiquidMassFlow.HeaderText = "Initial Liquid Velocity"
        Me.LiquidMassFlow.Name = "LiquidMassFlow"
        '
        'VaporMassFlow
        '
        Me.VaporMassFlow.HeaderText = "Initial Vapor Velocity"
        Me.VaporMassFlow.Name = "VaporMassFlow"
        '
        'ucBranchEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CheckBoxEntermass)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.dgvBranch)
        Me.Name = "ucBranchEditor"
        Me.Size = New System.Drawing.Size(1279, 489)
        CType(Me.dgvBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvBranch As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents CheckBoxEntermass As System.Windows.Forms.CheckBox
    Friend WithEvents FromComponent As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents FromComponentVolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FromFaceNumber As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ToComponent As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ToComponentVolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToFaceNumber As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents JunctionArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FFLossCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFlossCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubcooledDischargeCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TwoPhaseDischargeCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuperheatedDischargeCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LiquidMassFlow As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VaporMassFlow As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

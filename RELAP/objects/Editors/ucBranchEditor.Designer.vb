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
        Me.FromComponent = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.FromComponentVolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FromFaceNumber = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ToComponent = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ToComponentVolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToFaceNumber = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.JunctionArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FFLossCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFlossCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PVterm = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CCFLModel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.StratificationModel = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ChokingModel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AreaChange = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.VelocityMomentumEquation = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MomentumFlux = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SubcooledDischargeCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TwoPhaseDischargeCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperheatedDischargeCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdSave = New System.Windows.Forms.Button()
        CType(Me.dgvBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBranch
        '
        Me.dgvBranch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBranch.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBranch.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FromComponent, Me.FromComponentVolumeNumber, Me.FromFaceNumber, Me.ToComponent, Me.ToComponentVolumeNumber, Me.ToFaceNumber, Me.JunctionArea, Me.FFLossCo, Me.RFlossCo, Me.PVterm, Me.CCFLModel, Me.StratificationModel, Me.ChokingModel, Me.AreaChange, Me.VelocityMomentumEquation, Me.MomentumFlux, Me.SubcooledDischargeCo, Me.TwoPhaseDischargeCo, Me.SuperheatedDischargeCo})
        Me.dgvBranch.Location = New System.Drawing.Point(3, 3)
        Me.dgvBranch.Name = "dgvBranch"
        Me.dgvBranch.Size = New System.Drawing.Size(1273, 406)
        Me.dgvBranch.TabIndex = 0
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
        'PVterm
        '
        Me.PVterm.HeaderText = "Modified PV Term"
        Me.PVterm.Name = "PVterm"
        '
        'CCFLModel
        '
        Me.CCFLModel.HeaderText = "CCFL Model"
        Me.CCFLModel.Name = "CCFLModel"
        '
        'StratificationModel
        '
        Me.StratificationModel.HeaderText = "Horizontal Stratification Entrainment Model"
        Me.StratificationModel.Items.AddRange(New Object() {"Do not use this model", "upward oriented junction", "downward oriented junction", "centrally located junction"})
        Me.StratificationModel.Name = "StratificationModel"
        '
        'ChokingModel
        '
        Me.ChokingModel.HeaderText = "Choking Model"
        Me.ChokingModel.Name = "ChokingModel"
        '
        'AreaChange
        '
        Me.AreaChange.HeaderText = "Area Change"
        Me.AreaChange.Items.AddRange(New Object() {"No Area Change", "Smooth Area Change", "Full Abrupt Area Change", "Partial Abrupt Area Change"})
        Me.AreaChange.Name = "AreaChange"
        '
        'VelocityMomentumEquation
        '
        Me.VelocityMomentumEquation.HeaderText = "Velocity Momentum Equation"
        Me.VelocityMomentumEquation.Items.AddRange(New Object() {"Two velocity Momentum Equations", "Single velocity Momentum Equations"})
        Me.VelocityMomentumEquation.Name = "VelocityMomentumEquation"
        Me.VelocityMomentumEquation.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.VelocityMomentumEquation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'MomentumFlux
        '
        Me.MomentumFlux.HeaderText = "Momentum Flux"
        Me.MomentumFlux.Items.AddRange(New Object() {"To and From Volume", "Only From Volume", "Only To Volume", "Do not use Momentum Flux"})
        Me.MomentumFlux.Name = "MomentumFlux"
        Me.MomentumFlux.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MomentumFlux.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(1169, 424)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'ucBranchEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.dgvBranch)
        Me.Name = "ucBranchEditor"
        Me.Size = New System.Drawing.Size(1279, 489)
        CType(Me.dgvBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvBranch As System.Windows.Forms.DataGridView
    Friend WithEvents FromComponent As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents FromComponentVolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FromFaceNumber As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ToComponent As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ToComponentVolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToFaceNumber As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents JunctionArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FFLossCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFlossCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PVterm As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CCFLModel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents StratificationModel As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ChokingModel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AreaChange As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents VelocityMomentumEquation As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents MomentumFlux As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SubcooledDischargeCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TwoPhaseDischargeCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuperheatedDischargeCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdSave As System.Windows.Forms.Button

End Class

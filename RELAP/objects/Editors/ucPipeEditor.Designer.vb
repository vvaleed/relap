<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPipeEditor
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.cmdPaste = New System.Windows.Forms.Button()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdCopy2 = New System.Windows.Forms.Button()
        Me.cmdPaste2 = New System.Windows.Forms.Button()
        Me.VolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlowArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LengthofVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VolumeofVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Azimuthalangle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerticalAngle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ElevationChange = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HydraulicDiameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WallRoughness = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThermalStratificationModel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LevelTrackingModel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.WaterPackingScheme = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.VerticalStratificationModel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InterphaseFriction = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ComputeWallFriction = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EquilibriumTemperature = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VolumeNumber, Me.FlowArea, Me.LengthofVolume, Me.VolumeofVolume, Me.Azimuthalangle, Me.VerticalAngle, Me.ElevationChange, Me.HydraulicDiameter, Me.WallRoughness, Me.ThermalStratificationModel, Me.LevelTrackingModel, Me.WaterPackingScheme, Me.VerticalStratificationModel, Me.InterphaseFriction, Me.ComputeWallFriction, Me.EquilibriumTemperature})
        Me.dgv.Location = New System.Drawing.Point(7, 15)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(1042, 289)
        Me.dgv.TabIndex = 4
        '
        'cmdCopy
        '
        Me.cmdCopy.Enabled = False
        Me.cmdCopy.Location = New System.Drawing.Point(143, 309)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(75, 23)
        Me.cmdCopy.TabIndex = 6
        Me.cmdCopy.Text = "Copy"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'cmdPaste
        '
        Me.cmdPaste.Enabled = False
        Me.cmdPaste.Location = New System.Drawing.Point(244, 309)
        Me.cmdPaste.Name = "cmdPaste"
        Me.cmdPaste.Size = New System.Drawing.Size(75, 23)
        Me.cmdPaste.TabIndex = 8
        Me.cmdPaste.Text = "Paste"
        Me.cmdPaste.UseVisualStyleBackColor = True
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.dgv2.Location = New System.Drawing.Point(7, 339)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.Size = New System.Drawing.Size(1042, 263)
        Me.dgv2.TabIndex = 4
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Volume Number"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Volume Flow Area"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Length of Volume"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Volume of Volume"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Azimuthal angle"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Vertical Angle"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'cmdCopy2
        '
        Me.cmdCopy2.Enabled = False
        Me.cmdCopy2.Location = New System.Drawing.Point(143, 624)
        Me.cmdCopy2.Name = "cmdCopy2"
        Me.cmdCopy2.Size = New System.Drawing.Size(75, 23)
        Me.cmdCopy2.TabIndex = 6
        Me.cmdCopy2.Text = "Copy"
        Me.cmdCopy2.UseVisualStyleBackColor = True
        '
        'cmdPaste2
        '
        Me.cmdPaste2.Enabled = False
        Me.cmdPaste2.Location = New System.Drawing.Point(244, 624)
        Me.cmdPaste2.Name = "cmdPaste2"
        Me.cmdPaste2.Size = New System.Drawing.Size(75, 23)
        Me.cmdPaste2.TabIndex = 8
        Me.cmdPaste2.Text = "Paste"
        Me.cmdPaste2.UseVisualStyleBackColor = True
        '
        'VolumeNumber
        '
        Me.VolumeNumber.HeaderText = "Volume Number"
        Me.VolumeNumber.Name = "VolumeNumber"
        Me.VolumeNumber.ReadOnly = True
        '
        'FlowArea
        '
        Me.FlowArea.HeaderText = "Volume Flow Area"
        Me.FlowArea.Name = "FlowArea"
        '
        'LengthofVolume
        '
        Me.LengthofVolume.HeaderText = "Length of Volume"
        Me.LengthofVolume.Name = "LengthofVolume"
        '
        'VolumeofVolume
        '
        Me.VolumeofVolume.HeaderText = "Volume of Volume"
        Me.VolumeofVolume.Name = "VolumeofVolume"
        '
        'Azimuthalangle
        '
        Me.Azimuthalangle.HeaderText = "Azimuthal angle"
        Me.Azimuthalangle.Name = "Azimuthalangle"
        '
        'VerticalAngle
        '
        Me.VerticalAngle.HeaderText = "Vertical Angle"
        Me.VerticalAngle.Name = "VerticalAngle"
        '
        'ElevationChange
        '
        Me.ElevationChange.HeaderText = "Elevation Change"
        Me.ElevationChange.Name = "ElevationChange"
        '
        'HydraulicDiameter
        '
        Me.HydraulicDiameter.HeaderText = "Hydraulic Diameter"
        Me.HydraulicDiameter.Name = "HydraulicDiameter"
        '
        'WallRoughness
        '
        Me.WallRoughness.HeaderText = "Wall Roughness"
        Me.WallRoughness.Name = "WallRoughness"
        '
        'ThermalStratificationModel
        '
        Me.ThermalStratificationModel.HeaderText = "Thermal Stratification Model "
        Me.ThermalStratificationModel.Name = "ThermalStratificationModel"
        Me.ThermalStratificationModel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ThermalStratificationModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'LevelTrackingModel
        '
        Me.LevelTrackingModel.HeaderText = "Level Tracking Model"
        Me.LevelTrackingModel.Name = "LevelTrackingModel"
        Me.LevelTrackingModel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LevelTrackingModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'WaterPackingScheme
        '
        Me.WaterPackingScheme.HeaderText = "Water Packing Scheme "
        Me.WaterPackingScheme.Name = "WaterPackingScheme"
        Me.WaterPackingScheme.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WaterPackingScheme.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'VerticalStratificationModel
        '
        Me.VerticalStratificationModel.HeaderText = "Vertical Stratification Model "
        Me.VerticalStratificationModel.Name = "VerticalStratificationModel"
        Me.VerticalStratificationModel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.VerticalStratificationModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'InterphaseFriction
        '
        Me.InterphaseFriction.HeaderText = "Interphase Friction"
        Me.InterphaseFriction.Name = "InterphaseFriction"
        Me.InterphaseFriction.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InterphaseFriction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ComputeWallFriction
        '
        Me.ComputeWallFriction.HeaderText = "Compute WallFriction"
        Me.ComputeWallFriction.Name = "ComputeWallFriction"
        Me.ComputeWallFriction.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ComputeWallFriction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'EquilibriumTemperature
        '
        Me.EquilibriumTemperature.HeaderText = "Equilibrium Temperature"
        Me.EquilibriumTemperature.Name = "EquilibriumTemperature"
        Me.EquilibriumTemperature.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EquilibriumTemperature.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ucPipeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdPaste2)
        Me.Controls.Add(Me.cmdPaste)
        Me.Controls.Add(Me.cmdCopy2)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.dgv)
        Me.Name = "ucPipeEditor"
        Me.Size = New System.Drawing.Size(1052, 661)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdPaste As System.Windows.Forms.Button
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCopy2 As System.Windows.Forms.Button
    Friend WithEvents cmdPaste2 As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FlowArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LengthofVolume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VolumeofVolume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Azimuthalangle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerticalAngle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ElevationChange As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HydraulicDiameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WallRoughness As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThermalStratificationModel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents LevelTrackingModel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents WaterPackingScheme As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents VerticalStratificationModel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InterphaseFriction As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ComputeWallFriction As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EquilibriumTemperature As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class

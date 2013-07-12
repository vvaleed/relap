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
        Me.VolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Azimuthalangle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Flowarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HyrdraulicDiameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Junctionflowarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LengthofVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerticalAngle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VolumeofVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WallRoughness = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VolumeNumber, Me.Azimuthalangle, Me.Flowarea, Me.HyrdraulicDiameter, Me.Junctionflowarea, Me.LengthofVolume, Me.VerticalAngle, Me.VolumeofVolume, Me.WallRoughness})
        Me.dgv.Location = New System.Drawing.Point(7, 15)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(970, 289)
        Me.dgv.TabIndex = 4
        '
        'VolumeNumber
        '
        Me.VolumeNumber.HeaderText = "Volume Number"
        Me.VolumeNumber.Name = "VolumeNumber"
        Me.VolumeNumber.ReadOnly = True
        '
        'Azimuthalangle
        '
        Me.Azimuthalangle.HeaderText = "Azimuthal Angle"
        Me.Azimuthalangle.Name = "Azimuthalangle"
        '
        'Flowarea
        '
        Me.Flowarea.HeaderText = "Flow Area"
        Me.Flowarea.Name = "Flowarea"
        '
        'HyrdraulicDiameter
        '
        Me.HyrdraulicDiameter.HeaderText = "Hyrdraulic Diameter"
        Me.HyrdraulicDiameter.Name = "HyrdraulicDiameter"
        '
        'Junctionflowarea
        '
        Me.Junctionflowarea.HeaderText = "Junction Flow Area"
        Me.Junctionflowarea.Name = "Junctionflowarea"
        '
        'LengthofVolume
        '
        Me.LengthofVolume.HeaderText = "Length of Volume"
        Me.LengthofVolume.Name = "LengthofVolume"
        '
        'VerticalAngle
        '
        Me.VerticalAngle.HeaderText = "Vertical Angle"
        Me.VerticalAngle.Name = "VerticalAngle"
        '
        'VolumeofVolume
        '
        Me.VolumeofVolume.HeaderText = "Volume of Volume"
        Me.VolumeofVolume.Name = "VolumeofVolume"
        '
        'WallRoughness
        '
        Me.WallRoughness.HeaderText = "Wall Roughness"
        Me.WallRoughness.Name = "WallRoughness"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(27, 310)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(143, 309)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Copy to All"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(333, 311)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 7
        '
        'ucPipeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.dgv)
        Me.Name = "ucPipeEditor"
        Me.Size = New System.Drawing.Size(987, 388)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents VolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Azimuthalangle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Flowarea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HyrdraulicDiameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Junctionflowarea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LengthofVolume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerticalAngle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VolumeofVolume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WallRoughness As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPipeEditor
    Inherits System.Windows.Forms.Form

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
        Me.UcPipeEditor1 = New Global.RELAP.ucPipeEditor()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.VolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Azimuthalangle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Flowarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HyrdraulicDiameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Junctionflowarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LengthofVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerticalAngle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VolumeofVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WallRoughness = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UcPipeEditor1
        '
        Me.UcPipeEditor1.Location = New System.Drawing.Point(65, 51)
        Me.UcPipeEditor1.Name = "UcPipeEditor1"
        Me.UcPipeEditor1.NumberFormat = Nothing
        Me.UcPipeEditor1.Profile = Nothing
        Me.UcPipeEditor1.Size = New System.Drawing.Size(150, 150)
        Me.UcPipeEditor1.SystemOfUnits = Nothing
        Me.UcPipeEditor1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VolumeNumber, Me.Azimuthalangle, Me.Flowarea, Me.HyrdraulicDiameter, Me.Junctionflowarea, Me.LengthofVolume, Me.VerticalAngle, Me.VolumeofVolume, Me.WallRoughness})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(970, 289)
        Me.DataGridView1.TabIndex = 1
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
        'frmPipeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 327)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.UcPipeEditor1)
        Me.Name = "frmPipeEditor"
        Me.Text = "Pipe Editor"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcPipeEditor1 As ucPipeEditor
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents VolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Azimuthalangle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Flowarea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HyrdraulicDiameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Junctionflowarea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LengthofVolume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerticalAngle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VolumeofVolume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WallRoughness As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

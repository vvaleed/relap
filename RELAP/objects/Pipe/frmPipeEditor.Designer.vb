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
        Me.VolumeNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LengthofVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Flowarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HyrdraulicDiameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Junctionflowarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VerticalAngle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VolumeofVolume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WallRoughness = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UcPipeEditor1 = New ucPipeEditor()
        Me.SuspendLayout()
        '
        'VolumeNumber
        '
        Me.VolumeNumber.HeaderText = "Volume Number"
        Me.VolumeNumber.Name = "VolumeNumber"
        Me.VolumeNumber.ReadOnly = True
        '
        'LengthofVolume
        '
        Me.LengthofVolume.HeaderText = "Azimuthal Angle"
        Me.LengthofVolume.Name = "LengthofVolume"
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
        'UcPipeEditor1
        '
        Me.UcPipeEditor1.Location = New System.Drawing.Point(10, 12)
        Me.UcPipeEditor1.Name = "UcPipeEditor1"
        Me.UcPipeEditor1.NumberFormat = Nothing
        Me.UcPipeEditor1.Profile = Nothing
        Me.UcPipeEditor1.Size = New System.Drawing.Size(1074, 650)
        Me.UcPipeEditor1.SystemOfUnits = Nothing
        Me.UcPipeEditor1.TabIndex = 4
        '
        'frmPipeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1065, 664)
        Me.Controls.Add(Me.UcPipeEditor1)
        Me.Name = "frmPipeEditor"
        Me.Text = "Pipe Editor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VolumeNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Azimuthalangle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Flowarea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HyrdraulicDiameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Junctionflowarea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LengthofVolume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VerticalAngle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VolumeofVolume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WallRoughness As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UcPipeEditor1 As ucPipeEditor
End Class
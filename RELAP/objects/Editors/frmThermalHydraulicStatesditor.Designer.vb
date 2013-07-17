<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThermalHydraulicStates
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
        Me.UcThermoDynamicStates1 = New ucThermoDynamicStates()
        Me.SuspendLayout()
        '
        'UcThermoDynamicStates1
        '
        Me.UcThermoDynamicStates1.Location = New System.Drawing.Point(29, 29)
        Me.UcThermoDynamicStates1.Name = "UcThermoDynamicStates1"
        Me.UcThermoDynamicStates1.Size = New System.Drawing.Size(664, 266)
        Me.UcThermoDynamicStates1.TabIndex = 0
        '
        'frmThermalHydraulicStates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 310)
        Me.Controls.Add(Me.UcThermoDynamicStates1)
        Me.Name = "frmThermalHydraulicStates"
        Me.Text = "Thermo Hydraulic States Editor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcThermoDynamicStates1 As ucThermoDynamicStates
End Class
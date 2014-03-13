<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlRodEditor
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
        Me.UcControlRodEditor1 = New ucControlRodEditor()
        Me.SuspendLayout()
        '
        'UcControlRodEditor1
        '
        Me.UcControlRodEditor1.ControlRodDetails = Nothing
        Me.UcControlRodEditor1.Location = New System.Drawing.Point(22, 12)
        Me.UcControlRodEditor1.Name = "UcControlRodEditor1"
        Me.UcControlRodEditor1.Size = New System.Drawing.Size(688, 382)
        Me.UcControlRodEditor1.TabIndex = 0
        '
        'frmControlRodEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 411)
        Me.Controls.Add(Me.UcControlRodEditor1)
        Me.Name = "frmControlRodEditor"
        Me.Text = "Control Rod Editor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcControlRodEditor1 As ucControlRodEditor
End Class

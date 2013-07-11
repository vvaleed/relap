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
        Me.UcPipeEditor1 = New ucPipeEditor()
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
        'frmPipeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.UcPipeEditor1)
        Me.Name = "frmPipeEditor"
        Me.Text = "frmPipeEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcPipeEditor1 As ucPipeEditor
End Class

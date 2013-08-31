<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBranchEditor
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
        Me.UcBranchEditor1 = New ucBranchEditor()
        Me.SuspendLayout()
        '
        'UcBranchEditor1
        '
        Me.UcBranchEditor1.Location = New System.Drawing.Point(41, 27)
        Me.UcBranchEditor1.Name = "UcBranchEditor1"
        Me.UcBranchEditor1.Size = New System.Drawing.Size(150, 150)
        Me.UcBranchEditor1.TabIndex = 0
        '
        'frmBranchEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.UcBranchEditor1)
        Me.Name = "frmBranchEditor"
        Me.Text = "frmBranchEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcBranchEditor1 As ucBranchEditor
End Class

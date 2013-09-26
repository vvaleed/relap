<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formSeparatorEditor
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
        Me.UcSeparatorEditor1 = New ucSeparatorEditor()
        Me.SuspendLayout()
        '
        'UcSeparatorEditor1
        '
        Me.UcSeparatorEditor1.Location = New System.Drawing.Point(12, 12)
        Me.UcSeparatorEditor1.Name = "UcSeparatorEditor1"
        Me.UcSeparatorEditor1.NumberFormat = Nothing
        Me.UcSeparatorEditor1.SeparatorJunctionsGeometry = Nothing
        Me.UcSeparatorEditor1.Size = New System.Drawing.Size(1199, 332)
        Me.UcSeparatorEditor1.SystemOfUnits = Nothing
        Me.UcSeparatorEditor1.TabIndex = 0
        '
        'formSeparatorEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1223, 356)
        Me.Controls.Add(Me.UcSeparatorEditor1)
        Me.Name = "formSeparatorEditor"
        Me.Text = "formSeparatorEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcSeparatorEditor1 As ucSeparatorEditor
End Class

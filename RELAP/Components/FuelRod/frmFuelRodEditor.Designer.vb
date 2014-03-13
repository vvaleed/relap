<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFuelRodEditor
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
        Me.UcFuelRodEditor1 = New ucFuelRodEditor()
        Me.SuspendLayout()
        '
        'UcFuelRodEditor1
        '
        Me.UcFuelRodEditor1.Location = New System.Drawing.Point(12, 12)
        Me.UcFuelRodEditor1.Name = "UcFuelRodEditor1"

        Me.UcFuelRodEditor1.Size = New System.Drawing.Size(688, 382)
        Me.UcFuelRodEditor1.TabIndex = 0
        '
        'frmFuelRodEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 414)
        Me.Controls.Add(Me.UcFuelRodEditor1)
        Me.Name = "frmFuelRodEditor"
        Me.Text = "Fuel Rod Editor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcFuelRodEditor1 As ucFuelRodEditor

End Class

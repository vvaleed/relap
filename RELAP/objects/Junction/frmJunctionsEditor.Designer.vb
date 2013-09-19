<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJunctionsEditor
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
        Me.UcJunctionsEditor2 = New ucJunctionsEditor()
        Me.SuspendLayout()
        '
        'UcJunctionsEditor2
        '
        Me.UcJunctionsEditor2.JunctionsData = Nothing
        Me.UcJunctionsEditor2.Location = New System.Drawing.Point(12, 12)
        Me.UcJunctionsEditor2.Name = "UcJunctionsEditor2"
        Me.UcJunctionsEditor2.NumberFormat = Nothing
        Me.UcJunctionsEditor2.Size = New System.Drawing.Size(492, 359)
        Me.UcJunctionsEditor2.SystemOfUnits = Nothing
        Me.UcJunctionsEditor2.TabIndex = 0
        '
        'frmJunctionsEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 383)
        Me.Controls.Add(Me.UcJunctionsEditor2)
        Me.Name = "frmJunctionsEditor"
        Me.Text = "frmJunctionsEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcJunctionsEditor2 As ucJunctionsEditor
End Class

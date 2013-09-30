<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnnulusEditor
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
        Me.UcAnnulusEditor1 = New ucAnnulusEditor()
        Me.SuspendLayout()
        '
        'UcAnnulusEditor1
        '
        Me.UcAnnulusEditor1.Location = New System.Drawing.Point(12, 12)
        Me.UcAnnulusEditor1.Name = "UcAnnulusEditor1"
        Me.UcAnnulusEditor1.NumberFormat = Nothing
        Me.UcAnnulusEditor1.Profile = Nothing
        Me.UcAnnulusEditor1.Size = New System.Drawing.Size(1066, 684)
        Me.UcAnnulusEditor1.SystemOfUnits = Nothing
        Me.UcAnnulusEditor1.TabIndex = 0
        '
        'frmAnnulusEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 708)
        Me.Controls.Add(Me.UcAnnulusEditor1)
        Me.Name = "frmAnnulusEditor"
        Me.Text = "frmAnnulusEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcAnnulusEditor1 As ucAnnulusEditor
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValveEditor
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
        Me.UcValveEditor1 = New ucValveEditor()
        Me.SuspendLayout()
        '
        'UcValveEditor1
        '
        Me.UcValveEditor1.Location = New System.Drawing.Point(12, 12)
        Me.UcValveEditor1.Name = "UcValveEditor1"
        Me.UcValveEditor1.NumberFormat = Nothing
        Me.UcValveEditor1.Size = New System.Drawing.Size(838, 633)
        Me.UcValveEditor1.SystemOfUnits = Nothing
        Me.UcValveEditor1.TabIndex = 0
        Me.UcValveEditor1.ValveType = Nothing
        '
        'frmValveEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 657)
        Me.Controls.Add(Me.UcValveEditor1)
        Me.Name = "frmValveEditor"
        Me.Text = "frmValveEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcValveEditor1 As ucValveEditor
End Class

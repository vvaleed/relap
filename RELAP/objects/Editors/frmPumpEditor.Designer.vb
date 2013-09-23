<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPumpEditor
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
        Me.UcPump1 = New ucPump()
        Me.SuspendLayout()
        '
        'UcPump1
        '
        Me.UcPump1.Location = New System.Drawing.Point(1, 0)
        Me.UcPump1.Name = "UcPump1"
        Me.UcPump1.NumberFormat = Nothing
        Me.UcPump1.PumpData = Nothing
        Me.UcPump1.Size = New System.Drawing.Size(794, 503)
        Me.UcPump1.SystemOfUnits = Nothing
        Me.UcPump1.TabIndex = 0
        '
        'frmPumpEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 510)
        Me.Controls.Add(Me.UcPump1)
        Me.Name = "frmPumpEditor"
        Me.Text = "Pump Data"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcPump1 As ucPump
End Class

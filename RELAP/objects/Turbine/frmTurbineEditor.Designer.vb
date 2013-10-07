<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTurbineEditor
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
        Me.UcTurbineEditor1 = New ucTurbineEditor()
        Me.SuspendLayout()
        '
        'UcTurbineEditor1
        '
        Me.UcTurbineEditor1.Location = New System.Drawing.Point(3, 3)
        Me.UcTurbineEditor1.Name = "UcTurbineEditor1"
        Me.UcTurbineEditor1.NumberFormat = Nothing
        Me.UcTurbineEditor1.Size = New System.Drawing.Size(1293, 461)
        Me.UcTurbineEditor1.SystemOfUnits = Nothing
        Me.UcTurbineEditor1.TabIndex = 0
        Me.UcTurbineEditor1.TurbineJunctionsGeometry = Nothing
        '
        'frmTurbineEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1291, 458)
        Me.Controls.Add(Me.UcTurbineEditor1)
        Me.Name = "frmTurbineEditor"
        Me.Text = "frmTurbineEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcTurbineEditor1 As ucTurbineEditor
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHeatStructureEditor
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
        Me.UcHeatStructureEditor1 = New ucHeatStructureEditor()
        Me.SuspendLayout()
        '
        'UcHeatStructureEditor1
        '
        Me.UcHeatStructureEditor1.HeatStructureMeshData = Nothing
        Me.UcHeatStructureEditor1.Location = New System.Drawing.Point(12, 9)
        Me.UcHeatStructureEditor1.Name = "UcHeatStructureEditor1"
        Me.UcHeatStructureEditor1.NumberFormat = Nothing
        Me.UcHeatStructureEditor1.Size = New System.Drawing.Size(1263, 539)
        Me.UcHeatStructureEditor1.SystemOfUnits = Nothing
        Me.UcHeatStructureEditor1.TabIndex = 0
        '
        'frmHeatStructureEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1277, 560)
        Me.Controls.Add(Me.UcHeatStructureEditor1)
        Me.Name = "frmHeatStructureEditor"
        Me.Text = "frmHeatStructureEditor"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcHeatStructureEditor1 As ucHeatStructureEditor

End Class

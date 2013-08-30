<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHeatStructureEditor2
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
        Me.UcHeatStructureEditor21 = New ucHeatStructureEditor2()
        Me.SuspendLayout()
        '
        'UcHeatStructureEditor21
        '
        Me.UcHeatStructureEditor21.HeatStructureBoundaryCond = Nothing
        Me.UcHeatStructureEditor21.Location = New System.Drawing.Point(0, -1)
        Me.UcHeatStructureEditor21.Name = "UcHeatStructureEditor21"
        Me.UcHeatStructureEditor21.NumberFormat = Nothing
        Me.UcHeatStructureEditor21.Size = New System.Drawing.Size(994, 471)
        Me.UcHeatStructureEditor21.SystemOfUnits = Nothing
        Me.UcHeatStructureEditor21.TabIndex = 0
        '
        'frmHeatStructureEditor2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 470)
        Me.Controls.Add(Me.UcHeatStructureEditor21)
        Me.Name = "frmHeatStructureEditor2"
        Me.Text = "Heat Structure Boundry Conditions"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UcHeatStructureEditor21 As ucHeatStructureEditor2
End Class

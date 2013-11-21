<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaterials
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Me.CmboboxSelectMaterial = New System.Windows.Forms.ComboBox()
        Me.TxtBoxSelectMaterial = New System.Windows.Forms.TextBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CmboboxSelectMaterial
        '
        Me.CmboboxSelectMaterial.FormattingEnabled = True
        Me.CmboboxSelectMaterial.Items.AddRange(New Object() {"s-steel", "c-steel", "uo2", "zr", "Insert Table"})
        Me.CmboboxSelectMaterial.Location = New System.Drawing.Point(12, 31)
        Me.CmboboxSelectMaterial.Name = "CmboboxSelectMaterial"
        Me.CmboboxSelectMaterial.Size = New System.Drawing.Size(121, 21)
        Me.CmboboxSelectMaterial.TabIndex = 0
        '
        'TxtBoxSelectMaterial
        '
        Me.TxtBoxSelectMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBoxSelectMaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBoxSelectMaterial.Location = New System.Drawing.Point(12, 12)
        Me.TxtBoxSelectMaterial.Name = "TxtBoxSelectMaterial"
        Me.TxtBoxSelectMaterial.ReadOnly = True
        Me.TxtBoxSelectMaterial.Size = New System.Drawing.Size(100, 13)
        Me.TxtBoxSelectMaterial.TabIndex = 1
        Me.TxtBoxSelectMaterial.Text = "Select Material"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(214, 337)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'frmMaterials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 381)
        Me.CloseButton = False
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.TxtBoxSelectMaterial)
        Me.Controls.Add(Me.CmboboxSelectMaterial)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMaterials"
        Me.Text = "Materials"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmboboxSelectMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents TxtBoxSelectMaterial As System.Windows.Forms.TextBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInitialSettings
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
        Me.chklistboxCondensibleGases = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optDefaultFluid = New System.Windows.Forms.RadioButton()
        Me.optWater = New System.Windows.Forms.RadioButton()
        Me.optHeavyWater = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chklistboxCondensibleGases
        '
        Me.chklistboxCondensibleGases.FormattingEnabled = True
        Me.chklistboxCondensibleGases.Items.AddRange(New Object() {"argon", "helium", "hydrogen", "nitrogen", "xenon", "krypton", "air", "sf6"})
        Me.chklistboxCondensibleGases.Location = New System.Drawing.Point(15, 25)
        Me.chklistboxCondensibleGases.Name = "chklistboxCondensibleGases"
        Me.chklistboxCondensibleGases.Size = New System.Drawing.Size(112, 124)
        Me.chklistboxCondensibleGases.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Condensible Gases"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optHeavyWater)
        Me.GroupBox1.Controls.Add(Me.optWater)
        Me.GroupBox1.Controls.Add(Me.optDefaultFluid)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 165)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(109, 101)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fluid"
        '
        'optDefaultFluid
        '
        Me.optDefaultFluid.AutoSize = True
        Me.optDefaultFluid.Location = New System.Drawing.Point(7, 20)
        Me.optDefaultFluid.Name = "optDefaultFluid"
        Me.optDefaultFluid.Size = New System.Drawing.Size(84, 17)
        Me.optDefaultFluid.TabIndex = 0
        Me.optDefaultFluid.TabStop = True
        Me.optDefaultFluid.Text = "Default Fluid"
        Me.optDefaultFluid.UseVisualStyleBackColor = True
        '
        'optWater
        '
        Me.optWater.AutoSize = True
        Me.optWater.Location = New System.Drawing.Point(7, 43)
        Me.optWater.Name = "optWater"
        Me.optWater.Size = New System.Drawing.Size(54, 17)
        Me.optWater.TabIndex = 0
        Me.optWater.TabStop = True
        Me.optWater.Text = "Water"
        Me.optWater.UseVisualStyleBackColor = True
        '
        'optHeavyWater
        '
        Me.optHeavyWater.AutoSize = True
        Me.optHeavyWater.Location = New System.Drawing.Point(7, 66)
        Me.optHeavyWater.Name = "optHeavyWater"
        Me.optHeavyWater.Size = New System.Drawing.Size(88, 17)
        Me.optHeavyWater.TabIndex = 0
        Me.optHeavyWater.TabStop = True
        Me.optHeavyWater.Text = "Heavy Water"
        Me.optHeavyWater.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(22, 272)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(76, 17)
        Me.CheckBox1.TabIndex = 22
        Me.CheckBox1.Text = "Has Boron"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmInitialSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(139, 405)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chklistboxCondensibleGases)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmInitialSettings"
        Me.Text = "Initial Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chklistboxCondensibleGases As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optHeavyWater As System.Windows.Forms.RadioButton
    Friend WithEvents optWater As System.Windows.Forms.RadioButton
    Friend WithEvents optDefaultFluid As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class

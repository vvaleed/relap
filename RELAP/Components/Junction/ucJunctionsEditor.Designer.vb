<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucJunctionsEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ComboBoxEnter = New System.Windows.Forms.ComboBox()
        Me.dgvVelocity = New System.Windows.Forms.DataGridView()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.TimeVelocity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LiquidVelocity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VaporVelocity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        CType(Me.dgvVelocity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxEnter
        '
        Me.ComboBoxEnter.FormattingEnabled = True
        Me.ComboBoxEnter.Items.AddRange(New Object() {"Enter Velocities", "Enter Mass Flow Rates"})
        Me.ComboBoxEnter.Location = New System.Drawing.Point(19, 39)
        Me.ComboBoxEnter.Name = "ComboBoxEnter"
        Me.ComboBoxEnter.Size = New System.Drawing.Size(182, 21)
        Me.ComboBoxEnter.TabIndex = 0
        '
        'dgvVelocity
        '
        Me.dgvVelocity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVelocity.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvVelocity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVelocity.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TimeVelocity, Me.LiquidVelocity, Me.VaporVelocity})
        Me.dgvVelocity.Location = New System.Drawing.Point(19, 87)
        Me.dgvVelocity.Name = "dgvVelocity"
        Me.dgvVelocity.Size = New System.Drawing.Size(442, 222)
        Me.dgvVelocity.TabIndex = 2
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(386, 315)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 3
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'TimeVelocity
        '
        Me.TimeVelocity.HeaderText = "Time"
        Me.TimeVelocity.Name = "TimeVelocity"
        '
        'LiquidVelocity
        '
        Me.LiquidVelocity.HeaderText = "Liquid Velocity"
        Me.LiquidVelocity.Name = "LiquidVelocity"
        '
        'VaporVelocity
        '
        Me.VaporVelocity.HeaderText = "Vapor Velocity"
        Me.VaporVelocity.Name = "VaporVelocity"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(18, 20)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(183, 13)
        Me.TextBox3.TabIndex = 26
        Me.TextBox3.Text = "Select Velocities or Mass Flow"
        '
        'ucJunctionsEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.dgvVelocity)
        Me.Controls.Add(Me.ComboBoxEnter)
        Me.Name = "ucJunctionsEditor"
        Me.Size = New System.Drawing.Size(489, 349)
        CType(Me.dgvVelocity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBoxEnter As System.Windows.Forms.ComboBox
    Friend WithEvents dgvVelocity As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents TimeVelocity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LiquidVelocity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VaporVelocity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox

End Class

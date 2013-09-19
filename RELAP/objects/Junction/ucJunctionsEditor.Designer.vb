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
        Me.dgvMass = New System.Windows.Forms.DataGridView()
        Me.TimeMass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LiquidMassFlow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VaporMassFlow = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InterfaceVelocitym = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvVelocity = New System.Windows.Forms.DataGridView()
        Me.TimeVelocity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LiquidVelocity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VaporVelocity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InterfaceVelocityv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdSave = New System.Windows.Forms.Button()
        CType(Me.dgvMass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVelocity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxEnter
        '
        Me.ComboBoxEnter.FormattingEnabled = True
        Me.ComboBoxEnter.Items.AddRange(New Object() {"Enter Velocities", "Enter Mass Flow Rates"})
        Me.ComboBoxEnter.Location = New System.Drawing.Point(19, 16)
        Me.ComboBoxEnter.Name = "ComboBoxEnter"
        Me.ComboBoxEnter.Size = New System.Drawing.Size(182, 21)
        Me.ComboBoxEnter.TabIndex = 0
        '
        'dgvMass
        '
        Me.dgvMass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMass.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvMass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMass.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TimeMass, Me.LiquidMassFlow, Me.VaporMassFlow, Me.InterfaceVelocitym})
        Me.dgvMass.Location = New System.Drawing.Point(19, 60)
        Me.dgvMass.Name = "dgvMass"
        Me.dgvMass.Size = New System.Drawing.Size(442, 174)
        Me.dgvMass.TabIndex = 1
        '
        'TimeMass
        '
        Me.TimeMass.HeaderText = "Time"
        Me.TimeMass.Name = "TimeMass"
        '
        'LiquidMassFlow
        '
        Me.LiquidMassFlow.HeaderText = "Liquid Mass Flow"
        Me.LiquidMassFlow.Name = "LiquidMassFlow"
        '
        'VaporMassFlow
        '
        Me.VaporMassFlow.HeaderText = "Vapor Mass Flow"
        Me.VaporMassFlow.Name = "VaporMassFlow"
        '
        'InterfaceVelocitym
        '
        Me.InterfaceVelocitym.HeaderText = "Interface Velocity"
        Me.InterfaceVelocitym.Name = "InterfaceVelocitym"
        '
        'dgvVelocity
        '
        Me.dgvVelocity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVelocity.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvVelocity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVelocity.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TimeVelocity, Me.LiquidVelocity, Me.VaporVelocity, Me.InterfaceVelocityv})
        Me.dgvVelocity.Location = New System.Drawing.Point(19, 60)
        Me.dgvVelocity.Name = "dgvVelocity"
        Me.dgvVelocity.Size = New System.Drawing.Size(442, 174)
        Me.dgvVelocity.TabIndex = 2
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
        'InterfaceVelocityv
        '
        Me.InterfaceVelocityv.HeaderText = "Interface Velocity"
        Me.InterfaceVelocityv.Name = "InterfaceVelocityv"
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
        'ucJunctionsEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.dgvVelocity)
        Me.Controls.Add(Me.ComboBoxEnter)
        Me.Controls.Add(Me.dgvMass)
        Me.Name = "ucJunctionsEditor"
        Me.Size = New System.Drawing.Size(489, 349)
        CType(Me.dgvMass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVelocity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBoxEnter As System.Windows.Forms.ComboBox
    Friend WithEvents dgvMass As System.Windows.Forms.DataGridView
    Friend WithEvents TimeMass As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LiquidMassFlow As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VaporMassFlow As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InterfaceVelocitym As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvVelocity As System.Windows.Forms.DataGridView
    Friend WithEvents TimeVelocity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LiquidVelocity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VaporVelocity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InterfaceVelocityv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdSave As System.Windows.Forms.Button

End Class

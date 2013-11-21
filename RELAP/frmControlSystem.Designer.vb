<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlSystem
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
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.ComponentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboComponentType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtScalingFactor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtInitialValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkComputeIntialConditions = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cboLimiterControl = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtMinValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtMaxValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv1
        '
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ComponentName, Me.cboComponentType, Me.txtScalingFactor, Me.txtInitialValue, Me.chkComputeIntialConditions, Me.cboLimiterControl, Me.txtMinValue, Me.txtMaxValue})
        Me.dgv1.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv1.Location = New System.Drawing.Point(0, 0)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(858, 133)
        Me.dgv1.TabIndex = 0
        '
        'ComponentName
        '
        Me.ComponentName.HeaderText = "Component Name"
        Me.ComponentName.Name = "ComponentName"
        '
        'cboComponentType
        '
        Me.cboComponentType.HeaderText = "Component Type"
        Me.cboComponentType.Items.AddRange(New Object() {"SUM", "MULT", "DIV", "DIFFREND ", "INTEGRAL", "DELAY", "TRIPUNIT", "TRIPDLAY", "POWERI ", "POWERR ", "POWERX", "PROP-INT", "LAG", "LEAD-LAG ", "CONSTANT ", "SHAFT", "PUMPCTL", "STEAMCTL ", "FEEDCTL", "DELETE"})
        Me.cboComponentType.Name = "cboComponentType"
        '
        'txtScalingFactor
        '
        Me.txtScalingFactor.HeaderText = "Scaling Factor"
        Me.txtScalingFactor.Name = "txtScalingFactor"
        '
        'txtInitialValue
        '
        Me.txtInitialValue.HeaderText = "Initial Value"
        Me.txtInitialValue.Name = "txtInitialValue"
        '
        'chkComputeIntialConditions
        '
        Me.chkComputeIntialConditions.HeaderText = "Compute Initial Conditions"
        Me.chkComputeIntialConditions.Name = "chkComputeIntialConditions"
        '
        'cboLimiterControl
        '
        Me.cboLimiterControl.HeaderText = "Limiter Control"
        Me.cboLimiterControl.Items.AddRange(New Object() {"Omit", "Minimum Value", "Maximum Value", "Both"})
        Me.cboLimiterControl.Name = "cboLimiterControl"
        '
        'txtMinValue
        '
        Me.txtMinValue.HeaderText = "Minimum Value"
        Me.txtMinValue.Name = "txtMinValue"
        '
        'txtMaxValue
        '
        Me.txtMaxValue.HeaderText = "Maximum Value"
        Me.txtMaxValue.Name = "txtMaxValue"
        '
        'dgv2
        '
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgv2.Location = New System.Drawing.Point(0, 140)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.Size = New System.Drawing.Size(858, 138)
        Me.dgv2.TabIndex = 1
        '
        'frmControlSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 278)
        Me.CloseButton = False
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.dgv1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmControlSystem"
        Me.Text = "Control System Data Input"
        Me.TopMost = True
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComponentName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboComponentType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtScalingFactor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtInitialValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkComputeIntialConditions As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboLimiterControl As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtMinValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtMaxValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv2 As System.Windows.Forms.DataGridView
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlotRequest
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtPlotVariableName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboObjects = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboPlotScale = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboPosition = New System.Windows.Forms.DataGridViewComboBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cboObjects, Me.cboPlotScale, Me.cboPosition})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 56)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(296, 286)
        Me.DataGridView1.TabIndex = 35
        '
        'txtPlotVariableName
        '
        Me.txtPlotVariableName.Location = New System.Drawing.Point(110, 12)
        Me.txtPlotVariableName.Name = "txtPlotVariableName"
        Me.txtPlotVariableName.Size = New System.Drawing.Size(100, 20)
        Me.txtPlotVariableName.TabIndex = 36
        Me.txtPlotVariableName.Text = "mflowj"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Plot Variable Name:"
        '
        'cboObjects
        '
        Me.cboObjects.HeaderText = "Object"
        Me.cboObjects.Name = "cboObjects"
        '
        'cboPlotScale
        '
        Me.cboPlotScale.HeaderText = "Plot Scale"
        Me.cboPlotScale.Items.AddRange(New Object() {"Linear", "Logarithmic"})
        Me.cboPlotScale.Name = "cboPlotScale"
        '
        'cboPosition
        '
        Me.cboPosition.HeaderText = "Position"
        Me.cboPosition.Items.AddRange(New Object() {"Left", "Right"})
        Me.cboPosition.Name = "cboPosition"
        '
        'frmPlotRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 479)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPlotVariableName)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPlotRequest"
        Me.Text = "Plot Request Data"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtPlotVariableName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboObjects As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboPlotScale As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboPosition As System.Windows.Forms.DataGridViewComboBoxColumn
End Class

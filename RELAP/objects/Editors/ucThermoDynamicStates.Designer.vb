<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucThermoDynamicStates
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblthermostates = New System.Windows.Forms.Label()
        Me.cmbothermostates = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(27, 22)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(606, 132)
        Me.DataGridView1.TabIndex = 5
        '
        'lblthermostates
        '
        Me.lblthermostates.AutoSize = true
        Me.lblthermostates.Location = New System.Drawing.Point(24, 157)
        Me.lblthermostates.Name = "lblthermostates"
        Me.lblthermostates.Size = New System.Drawing.Size(215, 13)
        Me.lblthermostates.TabIndex = 4
        Me.lblthermostates.Text = "Please Select Initial Thermodynamics States"
        '
        'cmbothermostates
        '
        Me.cmbothermostates.FormattingEnabled = true
        Me.cmbothermostates.Items.AddRange(New Object() {"Pressure, Liquid Specific Internal Energy, Vapor Specific Internal Energy, Void F"& _ 
                "raction", "Temperature, Static Quality", "Pressure, Static Quality", "Pressure, Temperature", "Pressure, Temperature, Static Quality", "Temperature, Static Quality, Non condensable Quality", "Pressure, Liquid Specific Internal Energy, Vapor Specific Internal Energy, Void F"& _ 
                "raction, Non condensable Quality", "Pressure, Liquid Temperature, Vapor Temperature, Void Fraction, Non condensable Q"& _ 
                "uality"})
        Me.cmbothermostates.Location = New System.Drawing.Point(27, 185)
        Me.cmbothermostates.Name = "cmbothermostates"
        Me.cmbothermostates.Size = New System.Drawing.Size(606, 21)
        Me.cmbothermostates.TabIndex = 3
        '
        'ucThermoDynamicStates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblthermostates)
        Me.Controls.Add(Me.cmbothermostates)
        Me.Name = "ucThermoDynamicStates"
        Me.Size = New System.Drawing.Size(664, 234)
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lblthermostates As System.Windows.Forms.Label
    Friend WithEvents cmbothermostates As System.Windows.Forms.ComboBox

End Class

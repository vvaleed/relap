<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucHeatStructureEditor
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
        Me.chkboxmeshgeometry = New System.Windows.Forms.CheckBox()
        Me.chklistboxSelectFormat = New System.Windows.Forms.CheckedListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridViewformat1 = New System.Windows.Forms.DataGridView()
        Me.Numberofintervals = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RightCoordinate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewformat2 = New System.Windows.Forms.DataGridView()
        Me.MeshInterval = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IntervalNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewNoDecay = New System.Windows.Forms.DataGridView()
        Me.SourceValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeshIntervalNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.DataGridViewWithDecay = New System.Windows.Forms.DataGridView()
        Me.GammaAttenuationCo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeshIntervalNumber2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComposition = New System.Windows.Forms.DataGridView()
        Me.CompositionNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MeshIntervalNumber3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridViewformat1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewformat2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewNoDecay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewWithDecay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewComposition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkboxmeshgeometry
        '
        Me.chkboxmeshgeometry.AutoSize = True
        Me.chkboxmeshgeometry.Location = New System.Drawing.Point(34, 29)
        Me.chkboxmeshgeometry.Name = "chkboxmeshgeometry"
        Me.chkboxmeshgeometry.Size = New System.Drawing.Size(128, 17)
        Me.chkboxmeshgeometry.TabIndex = 0
        Me.chkboxmeshgeometry.Text = "Enter Mesh Geometry"
        Me.chkboxmeshgeometry.UseVisualStyleBackColor = True
        '
        'chklistboxSelectFormat
        '
        Me.chklistboxSelectFormat.BackColor = System.Drawing.SystemColors.Menu
        Me.chklistboxSelectFormat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chklistboxSelectFormat.FormattingEnabled = True
        Me.chklistboxSelectFormat.Items.AddRange(New Object() {"Number of intervals, Right coordinate", "Mesh interval, Interval number"})
        Me.chklistboxSelectFormat.Location = New System.Drawing.Point(34, 78)
        Me.chklistboxSelectFormat.Name = "chklistboxSelectFormat"
        Me.chklistboxSelectFormat.Size = New System.Drawing.Size(199, 30)
        Me.chklistboxSelectFormat.TabIndex = 2
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(34, 59)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 13)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "Select Format"
        '
        'DataGridViewformat1
        '
        Me.DataGridViewformat1.AccessibleDescription = "                            "
        Me.DataGridViewformat1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewformat1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Numberofintervals, Me.RightCoordinate})
        Me.DataGridViewformat1.Location = New System.Drawing.Point(34, 114)
        Me.DataGridViewformat1.Name = "DataGridViewformat1"
        Me.DataGridViewformat1.Size = New System.Drawing.Size(256, 125)
        Me.DataGridViewformat1.TabIndex = 4
        '
        'Numberofintervals
        '
        Me.Numberofintervals.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Numberofintervals.HeaderText = "Number of Intervals"
        Me.Numberofintervals.Name = "Numberofintervals"
        '
        'RightCoordinate
        '
        Me.RightCoordinate.HeaderText = "Right Coordinate"
        Me.RightCoordinate.Name = "RightCoordinate"
        '
        'DataGridViewformat2
        '
        Me.DataGridViewformat2.AccessibleDescription = "                            "
        Me.DataGridViewformat2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewformat2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MeshInterval, Me.IntervalNumber})
        Me.DataGridViewformat2.Location = New System.Drawing.Point(34, 259)
        Me.DataGridViewformat2.Name = "DataGridViewformat2"
        Me.DataGridViewformat2.Size = New System.Drawing.Size(256, 125)
        Me.DataGridViewformat2.TabIndex = 5
        '
        'MeshInterval
        '
        Me.MeshInterval.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.MeshInterval.HeaderText = "Mesh Interval"
        Me.MeshInterval.Name = "MeshInterval"
        '
        'IntervalNumber
        '
        Me.IntervalNumber.HeaderText = "Interval Number"
        Me.IntervalNumber.Name = "IntervalNumber"
        '
        'DataGridViewNoDecay
        '
        Me.DataGridViewNoDecay.AccessibleDescription = "                            "
        Me.DataGridViewNoDecay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewNoDecay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SourceValue, Me.MeshIntervalNumber})
        Me.DataGridViewNoDecay.Location = New System.Drawing.Point(344, 114)
        Me.DataGridViewNoDecay.Name = "DataGridViewNoDecay"
        Me.DataGridViewNoDecay.Size = New System.Drawing.Size(256, 125)
        Me.DataGridViewNoDecay.TabIndex = 6
        '
        'SourceValue
        '
        Me.SourceValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SourceValue.HeaderText = "Source Value"
        Me.SourceValue.Name = "SourceValue"
        '
        'MeshIntervalNumber
        '
        Me.MeshIntervalNumber.HeaderText = "Mesh Interval Number"
        Me.MeshIntervalNumber.Name = "MeshIntervalNumber"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(344, 78)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 13)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "Decay Heat"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(416, 75)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 8
        '
        'DataGridViewWithDecay
        '
        Me.DataGridViewWithDecay.AccessibleDescription = "                            "
        Me.DataGridViewWithDecay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewWithDecay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GammaAttenuationCo, Me.MeshIntervalNumber2})
        Me.DataGridViewWithDecay.Location = New System.Drawing.Point(344, 259)
        Me.DataGridViewWithDecay.Name = "DataGridViewWithDecay"
        Me.DataGridViewWithDecay.Size = New System.Drawing.Size(256, 125)
        Me.DataGridViewWithDecay.TabIndex = 9
        '
        'GammaAttenuationCo
        '
        Me.GammaAttenuationCo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.GammaAttenuationCo.HeaderText = "Gamma Attenuation Co."
        Me.GammaAttenuationCo.Name = "GammaAttenuationCo"
        '
        'MeshIntervalNumber2
        '
        Me.MeshIntervalNumber2.HeaderText = "Mesh Interval Number"
        Me.MeshIntervalNumber2.Name = "MeshIntervalNumber2"
        '
        'DataGridViewComposition
        '
        Me.DataGridViewComposition.AccessibleDescription = "                            "
        Me.DataGridViewComposition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewComposition.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CompositionNumber, Me.MeshIntervalNumber3})
        Me.DataGridViewComposition.Location = New System.Drawing.Point(640, 114)
        Me.DataGridViewComposition.Name = "DataGridViewComposition"
        Me.DataGridViewComposition.Size = New System.Drawing.Size(256, 125)
        Me.DataGridViewComposition.TabIndex = 10
        '
        'CompositionNumber
        '
        Me.CompositionNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CompositionNumber.HeaderText = "Composition Number"
        Me.CompositionNumber.Name = "CompositionNumber"
        '
        'MeshIntervalNumber3
        '
        Me.MeshIntervalNumber3.HeaderText = "Mesh Interval Number"
        Me.MeshIntervalNumber3.Name = "MeshIntervalNumber3"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(640, 82)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(100, 13)
        Me.TextBox4.TabIndex = 11
        Me.TextBox4.Text = "Composition Data"
        '
        'ucHeatStructureEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.DataGridViewComposition)
        Me.Controls.Add(Me.DataGridViewWithDecay)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.DataGridViewNoDecay)
        Me.Controls.Add(Me.DataGridViewformat2)
        Me.Controls.Add(Me.DataGridViewformat1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.chklistboxSelectFormat)
        Me.Controls.Add(Me.chkboxmeshgeometry)
        Me.Name = "ucHeatStructureEditor"
        Me.Size = New System.Drawing.Size(912, 422)
        CType(Me.DataGridViewformat1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewformat2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewNoDecay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewWithDecay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewComposition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkboxmeshgeometry As System.Windows.Forms.CheckBox
    Friend WithEvents chklistboxSelectFormat As System.Windows.Forms.CheckedListBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewformat1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewformat2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewNoDecay As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewWithDecay As System.Windows.Forms.DataGridView
    Friend WithEvents Numberofintervals As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RightCoordinate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MeshInterval As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IntervalNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComposition As System.Windows.Forms.DataGridView
    Friend WithEvents SourceValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MeshIntervalNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GammaAttenuationCo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MeshIntervalNumber2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CompositionNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MeshIntervalNumber3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucFuelRodEditor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvFuelRodDimensions = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.lblAxialNode = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.txtFuelPelletRadius = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.txtInnerCladdingRadius = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.txtOuterCladdingRadius = New DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvRadialMeshSpacing = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.lblAxialNodeNumber = New DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn()
        Me.txtNumberofIntervals = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.txtNumberofIntervalsAcrossGap = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.txtIntervalsAcrossCladding = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvFuelRodDimensions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvRadialMeshSpacing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(19, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(633, 292)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvFuelRodDimensions)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(625, 266)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Fuel Rod Dimensions"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvFuelRodDimensions
        '
        Me.dgvFuelRodDimensions.AllowUserToAddRows = False
        Me.dgvFuelRodDimensions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFuelRodDimensions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFuelRodDimensions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFuelRodDimensions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFuelRodDimensions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lblAxialNode, Me.txtFuelPelletRadius, Me.txtInnerCladdingRadius, Me.txtOuterCladdingRadius})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFuelRodDimensions.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFuelRodDimensions.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvFuelRodDimensions.Location = New System.Drawing.Point(21, 24)
        Me.dgvFuelRodDimensions.Name = "dgvFuelRodDimensions"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFuelRodDimensions.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFuelRodDimensions.Size = New System.Drawing.Size(586, 150)
        Me.dgvFuelRodDimensions.TabIndex = 0
        '
        'lblAxialNode
        '
        Me.lblAxialNode.HeaderText = "Axial Node"
        Me.lblAxialNode.Name = "lblAxialNode"
        '
        'txtFuelPelletRadius
        '
        '
        '
        '
        Me.txtFuelPelletRadius.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFuelPelletRadius.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtFuelPelletRadius.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFuelPelletRadius.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtFuelPelletRadius.HeaderText = "Fuel Pellet Radius"
        Me.txtFuelPelletRadius.Increment = 1.0R
        Me.txtFuelPelletRadius.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtFuelPelletRadius.Name = "txtFuelPelletRadius"
        '
        'txtInnerCladdingRadius
        '
        '
        '
        '
        Me.txtInnerCladdingRadius.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtInnerCladdingRadius.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtInnerCladdingRadius.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInnerCladdingRadius.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtInnerCladdingRadius.HeaderText = "Inner cladding radius"
        Me.txtInnerCladdingRadius.Increment = 1.0R
        Me.txtInnerCladdingRadius.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtInnerCladdingRadius.Name = "txtInnerCladdingRadius"
        '
        'txtOuterCladdingRadius
        '
        '
        '
        '
        Me.txtOuterCladdingRadius.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtOuterCladdingRadius.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtOuterCladdingRadius.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOuterCladdingRadius.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtOuterCladdingRadius.HeaderText = "Outer cladding radius"
        Me.txtOuterCladdingRadius.Increment = 1.0R
        Me.txtOuterCladdingRadius.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtOuterCladdingRadius.Name = "txtOuterCladdingRadius"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvRadialMeshSpacing)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(625, 266)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Radial Mesh Spacing"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvRadialMeshSpacing
        '
        Me.dgvRadialMeshSpacing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRadialMeshSpacing.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRadialMeshSpacing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRadialMeshSpacing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lblAxialNodeNumber, Me.txtNumberofIntervals, Me.txtNumberofIntervalsAcrossGap, Me.txtIntervalsAcrossCladding})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRadialMeshSpacing.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRadialMeshSpacing.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvRadialMeshSpacing.Location = New System.Drawing.Point(17, 26)
        Me.dgvRadialMeshSpacing.Name = "dgvRadialMeshSpacing"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRadialMeshSpacing.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRadialMeshSpacing.Size = New System.Drawing.Size(564, 175)
        Me.dgvRadialMeshSpacing.TabIndex = 0
        '
        'lblAxialNodeNumber
        '
        Me.lblAxialNodeNumber.HeaderText = "Axial Node"
        Me.lblAxialNodeNumber.Name = "lblAxialNodeNumber"
        Me.lblAxialNodeNumber.ReadOnly = True
        '
        'txtNumberofIntervals
        '
        '
        '
        '
        Me.txtNumberofIntervals.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumberofIntervals.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtNumberofIntervals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumberofIntervals.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtNumberofIntervals.HeaderText = "Number of Intervals across Fuel"
        Me.txtNumberofIntervals.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtNumberofIntervals.Name = "txtNumberofIntervals"
        Me.txtNumberofIntervals.ReadOnly = True
        '
        'txtNumberofIntervalsAcrossGap
        '
        '
        '
        '
        Me.txtNumberofIntervalsAcrossGap.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumberofIntervalsAcrossGap.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtNumberofIntervalsAcrossGap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumberofIntervalsAcrossGap.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtNumberofIntervalsAcrossGap.HeaderText = "Number of intervals across gap"
        Me.txtNumberofIntervalsAcrossGap.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtNumberofIntervalsAcrossGap.Name = "txtNumberofIntervalsAcrossGap"
        Me.txtNumberofIntervalsAcrossGap.ReadOnly = True
        '
        'txtIntervalsAcrossCladding
        '
        '
        '
        '
        Me.txtIntervalsAcrossCladding.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtIntervalsAcrossCladding.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtIntervalsAcrossCladding.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIntervalsAcrossCladding.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtIntervalsAcrossCladding.HeaderText = "Number of intervals across cladding"
        Me.txtIntervalsAcrossCladding.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtIntervalsAcrossCladding.Name = "txtIntervalsAcrossCladding"
        Me.txtIntervalsAcrossCladding.ReadOnly = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(625, 266)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Initial Temperatures"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ucFuelRodEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "ucFuelRodEditor"
        Me.Size = New System.Drawing.Size(688, 385)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvFuelRodDimensions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvRadialMeshSpacing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvFuelRodDimensions As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents lblAxialNode As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents txtFuelPelletRadius As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents txtInnerCladdingRadius As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents txtOuterCladdingRadius As DevComponents.DotNetBar.Controls.DataGridViewDoubleInputColumn
    Friend WithEvents dgvRadialMeshSpacing As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents lblAxialNodeNumber As DevComponents.DotNetBar.Controls.DataGridViewLabelXColumn
    Friend WithEvents txtNumberofIntervals As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents txtNumberofIntervalsAcrossGap As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents txtIntervalsAcrossCladding As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage

End Class

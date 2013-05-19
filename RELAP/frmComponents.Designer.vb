<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmObjListView
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmObjListView))
        Me.col1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.col0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'col1
        '
        Me.col1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.col1.HeaderText = "col1"
        Me.col1.Name = "col1"
        Me.col1.ReadOnly = True
        Me.col1.Width = 40
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.White
        Me.ImageList2.Images.SetKeyName(0, "compressor copy1.png")
        Me.ImageList2.Images.SetKeyName(1, "cooler copy1.png")
        Me.ImageList2.Images.SetKeyName(2, "heater copy1.png")
        Me.ImageList2.Images.SetKeyName(3, "node_in copy1.png")
        Me.ImageList2.Images.SetKeyName(4, "node_out copy1.png")
        Me.ImageList2.Images.SetKeyName(5, "pipe copy1.png")
        Me.ImageList2.Images.SetKeyName(6, "pump copy1.png")
        Me.ImageList2.Images.SetKeyName(7, "r_conv1.png")
        Me.ImageList2.Images.SetKeyName(8, "r_cstr.png")
        Me.ImageList2.Images.SetKeyName(9, "r_equil1.png")
        Me.ImageList2.Images.SetKeyName(10, "r_gibbs1.png")
        Me.ImageList2.Images.SetKeyName(11, "r_pfr.png")
        Me.ImageList2.Images.SetKeyName(12, "reciclo_mini.png")
        Me.ImageList2.Images.SetKeyName(13, "tank copy1.png")
        Me.ImageList2.Images.SetKeyName(14, "turbina copy.png")
        Me.ImageList2.Images.SetKeyName(15, "valve copy1.png")
        Me.ImageList2.Images.SetKeyName(16, "vessel copy1.png")
        Me.ImageList2.Images.SetKeyName(17, "arrow_right.png")
        Me.ImageList2.Images.SetKeyName(18, "arrow_right2.png")
        Me.ImageList2.Images.SetKeyName(19, "ajuste_mini.png")
        Me.ImageList2.Images.SetKeyName(20, "especificacao_mini.png")
        Me.ImageList2.Images.SetKeyName(21, "reciclo_e.png")
        Me.ImageList2.Images.SetKeyName(22, "comp_separator.png")
        Me.ImageList2.Images.SetKeyName(23, "orifice2.png")
        Me.ImageList2.Images.SetKeyName(24, "greyscale_20.gif")
        Me.ImageList2.Images.SetKeyName(25, "colan2.jpg")
        '
        'col0
        '
        Me.col0.HeaderText = "col0"
        Me.col0.Name = "col0"
        Me.col0.ReadOnly = True
        Me.col0.Visible = False
        '
        'col2
        '
        Me.col2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col2.HeaderText = "col2"
        Me.col2.Name = "col2"
        Me.col2.ReadOnly = True
        Me.col2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col0, Me.col1, Me.col2})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 40
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(355, 437)
        Me.DataGridView1.TabIndex = 5
        '
        'frmObjListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 437)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmObjListView"
        Me.Text = "Components"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents col1 As System.Windows.Forms.DataGridViewImageColumn
    Public WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents col0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class

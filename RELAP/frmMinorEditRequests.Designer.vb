<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMinorEditRequests
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
        Me.cboVariableCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboParameter = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtParameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtVolume = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cboVariableCode, Me.cboParameter, Me.txtParameter, Me.txtVolume})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(580, 150)
        Me.DataGridView1.TabIndex = 0
        '
        'cboVariableCode
        '
        Me.cboVariableCode.HeaderText = "Variable Code"
        Me.cboVariableCode.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})
        Me.cboVariableCode.Name = "cboVariableCode"
        Me.cboVariableCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cboVariableCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cboParameter
        '
        Me.cboParameter.HeaderText = "Parameter"
        Me.cboParameter.Name = "cboParameter"
        Me.cboParameter.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'txtParameter
        '
        Me.txtParameter.HeaderText = "Parameter"
        Me.txtParameter.Name = "txtParameter"
        Me.txtParameter.Visible = False
        '
        'txtVolume
        '
        '
        '
        '
        Me.txtVolume.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtVolume.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtVolume.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVolume.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtVolume.HeaderText = "Volume"
        Me.txtVolume.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtVolume.Name = "txtVolume"
        '
        'frmMinorEditRequests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 197)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMinorEditRequests"
        Me.Text = "Minor Edit Requests"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cboVariableCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboParameter As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtParameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtVolume As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrips
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
        Me.cboVariableCode1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboParameter1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboRelationship = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboVariableCode2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboParameter2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtAdditiveConstant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkLatch = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtTimeof = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtParamter1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtParameter2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cboVariableCode1, Me.cboParameter1, Me.cboRelationship, Me.cboVariableCode2, Me.cboParameter2, Me.txtAdditiveConstant, Me.chkLatch, Me.txtTimeof, Me.txtParamter1, Me.txtParameter2})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(840, 116)
        Me.DataGridView1.TabIndex = 0
        '
        'cboVariableCode1
        '
        Me.cboVariableCode1.HeaderText = "Variable 1"
        Me.cboVariableCode1.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})
        Me.cboVariableCode1.Name = "cboVariableCode1"
        Me.cboVariableCode1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cboVariableCode1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cboParameter1
        '
        Me.cboParameter1.HeaderText = "Parameter 1"
        Me.cboParameter1.Name = "cboParameter1"
        '
        'cboRelationship
        '
        Me.cboRelationship.HeaderText = "Relationship"
        Me.cboRelationship.Items.AddRange(New Object() {"EQ", "LT", "GT", "LE", "GE", "NE"})
        Me.cboRelationship.Name = "cboRelationship"
        '
        'cboVariableCode2
        '
        Me.cboVariableCode2.HeaderText = "Variable 2"
        Me.cboVariableCode2.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})
        Me.cboVariableCode2.Name = "cboVariableCode2"
        '
        'cboParameter2
        '
        Me.cboParameter2.HeaderText = "Parameter 2"
        Me.cboParameter2.Name = "cboParameter2"
        '
        'txtAdditiveConstant
        '
        Me.txtAdditiveConstant.HeaderText = "Additive Constant"
        Me.txtAdditiveConstant.Name = "txtAdditiveConstant"
        '
        'chkLatch
        '
        Me.chkLatch.HeaderText = "Latch"
        Me.chkLatch.Name = "chkLatch"
        '
        'txtTimeof
        '
        Me.txtTimeof.HeaderText = "Timeof Quantity"
        Me.txtTimeof.Name = "txtTimeof"
        '
        'txtParamter1
        '
        Me.txtParamter1.HeaderText = "Parameter 1"
        Me.txtParamter1.Name = "txtParamter1"
        Me.txtParamter1.Visible = False
        '
        'txtParameter2
        '
        Me.txtParameter2.HeaderText = "Parameter 2"
        Me.txtParameter2.Name = "txtParameter2"
        Me.txtParameter2.Visible = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView2.Location = New System.Drawing.Point(0, 140)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(840, 109)
        Me.DataGridView2.TabIndex = 1
        '
        'frmTrips
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 249)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTrips"
        Me.Text = "Trips"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cboVariableCode1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboParameter1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboRelationship As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboVariableCode2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboParameter2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtAdditiveConstant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkLatch As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txtTimeof As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtParamter1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtParameter2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
End Class

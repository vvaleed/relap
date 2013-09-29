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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboVariableCode1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboParameter1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtVolume1 = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.cboRelationship = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboVariableCode2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboParameter2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtVolume2 = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.txtAdditiveConstant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkLatch = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtTimeof = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtParamter1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtParameter2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cboTrip1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboOperator = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboTrip2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.chkLatch2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtTimeofQuantity2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lblSerial, Me.cboVariableCode1, Me.cboParameter1, Me.txtVolume1, Me.cboRelationship, Me.cboVariableCode2, Me.cboParameter2, Me.txtVolume2, Me.txtAdditiveConstant, Me.chkLatch, Me.txtTimeof, Me.txtParamter1, Me.txtParameter2})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(892, 116)
        Me.DataGridView1.TabIndex = 0
        '
        'lblSerial
        '
        Me.lblSerial.HeaderText = "Serial"
        Me.lblSerial.Name = "lblSerial"
        Me.lblSerial.ReadOnly = True
        Me.lblSerial.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
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
        'txtVolume1
        '
        '
        '
        '
        Me.txtVolume1.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtVolume1.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtVolume1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVolume1.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtVolume1.HeaderText = "Volume 1"
        Me.txtVolume1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtVolume1.Name = "txtVolume1"
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
        'txtVolume2
        '
        '
        '
        '
        Me.txtVolume2.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtVolume2.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.txtVolume2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVolume2.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.txtVolume2.HeaderText = "Volume 2"
        Me.txtVolume2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.txtVolume2.Name = "txtVolume2"
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
        'DataGridViewX1
        '
        Me.DataGridViewX1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cboTrip1, Me.cboOperator, Me.cboTrip2, Me.chkLatch2, Me.txtTimeofQuantity2})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(0, 116)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.Size = New System.Drawing.Size(892, 110)
        Me.DataGridViewX1.TabIndex = 1
        '
        'cboTrip1
        '
        Me.cboTrip1.HeaderText = "Trip 1"
        Me.cboTrip1.Name = "cboTrip1"
        '
        'cboOperator
        '
        Me.cboOperator.HeaderText = "Operator"
        Me.cboOperator.Items.AddRange(New Object() {"AND", "OR", "XOR", "DISCARD", "RESET"})
        Me.cboOperator.Name = "cboOperator"
        '
        'cboTrip2
        '
        Me.cboTrip2.HeaderText = "Trip 2"
        Me.cboTrip2.Name = "cboTrip2"
        '
        'chkLatch2
        '
        Me.chkLatch2.HeaderText = "Latch"
        Me.chkLatch2.Name = "chkLatch2"
        '
        'txtTimeofQuantity2
        '
        Me.txtTimeofQuantity2.HeaderText = "Timeof Quantity"
        Me.txtTimeofQuantity2.Name = "txtTimeofQuantity2"
        '
        'frmTrips
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 229)
        Me.Controls.Add(Me.DataGridViewX1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmTrips"
        Me.Text = "Trips"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents lblSerial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboVariableCode1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboParameter1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtVolume1 As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents cboRelationship As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboVariableCode2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboParameter2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtVolume2 As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents txtAdditiveConstant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkLatch As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txtTimeof As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtParamter1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtParameter2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboTrip1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboOperator As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboTrip2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents chkLatch2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txtTimeofQuantity2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

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
        Me.cboObjects = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboPlotVariable = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtVolume = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.cboPlotScale = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboPosition = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.cboRestartPlotSettings = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.cboVariableCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.txtParameter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboParameter = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cboObjects, Me.cboPlotVariable, Me.txtVolume, Me.cboPlotScale, Me.cboPosition})
        Me.DataGridView1.Location = New System.Drawing.Point(158, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(522, 120)
        Me.DataGridView1.TabIndex = 35
        '
        'cboObjects
        '
        Me.cboObjects.HeaderText = "Object"
        Me.cboObjects.Name = "cboObjects"
        '
        'cboPlotVariable
        '
        Me.cboPlotVariable.HeaderText = "Plot Variable Name"
        Me.cboPlotVariable.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})
        Me.cboPlotVariable.Name = "cboPlotVariable"
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
        'cboRestartPlotSettings
        '
        Me.cboRestartPlotSettings.FormattingEnabled = True
        Me.cboRestartPlotSettings.Items.AddRange(New Object() {"NONE", "NCMPRESS", "CMPRESS"})
        Me.cboRestartPlotSettings.Location = New System.Drawing.Point(23, 43)
        Me.cboRestartPlotSettings.Name = "cboRestartPlotSettings"
        Me.cboRestartPlotSettings.Size = New System.Drawing.Size(121, 21)
        Me.cboRestartPlotSettings.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Restart Plot Settings"
        '
        'DataGridView2
        '
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cboVariableCode, Me.txtParameter, Me.cboParameter})
        Me.DataGridView2.Location = New System.Drawing.Point(686, 27)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(346, 120)
        Me.DataGridView2.TabIndex = 41
        '
        'cboVariableCode
        '
        Me.cboVariableCode.HeaderText = "Variable Code"
        Me.cboVariableCode.Items.AddRange(New Object() {"BRCHV", "DAMLEV", "DZFRCQ", "EFFOXD", "H2OXD2", "HOOP", "OXDEO", "RCI", "RCO", "RNALF", "RNOXD", "ROCRST", "RPEL", "RULIQ", "WFROSR", "WFROUO", "WFROZR", "WREMSR", "WREMUO", "WREMZR"})
        Me.cboVariableCode.Name = "cboVariableCode"
        Me.cboVariableCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cboVariableCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'txtParameter
        '
        Me.txtParameter.HeaderText = "Parameter"
        Me.txtParameter.Name = "txtParameter"
        '
        'cboParameter
        '
        Me.cboParameter.HeaderText = "Parameter"
        Me.cboParameter.Name = "cboParameter"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(683, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Expanded Plot Variables"
        '
        'frmPlotRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 159)
        Me.CloseButton = False
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboRestartPlotSettings)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPlotRequest"
        Me.Text = "Plot Request Data"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cboRestartPlotSettings As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboVariableCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtParameter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboParameter As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboObjects As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboPlotVariable As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents txtVolume As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents cboPlotScale As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents cboPosition As System.Windows.Forms.DataGridViewComboBoxColumn
End Class

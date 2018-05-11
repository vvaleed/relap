Public Class frmControlSystem
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent


    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellEndEdit

        '        TRIPUNIT()
        '        TRIPDLAY()
        '        POWERI()
        '        POWERR()
        '        POWERX()
        '        PROP(-Int())
        '        LAG()
        '        LEAD(-LAG)
        '        CONSTANT()
        '        SHAFT()
        '        PUMPCTL()
        '        STEAMCTL()
        '        FEEDCTL()
        '        DELETE()
        dgv2.Columns.Clear()
        If e.ColumnIndex = 1 Then
            Select Case dgv1.Rows(e.RowIndex).Cells(1).Value
                Case "SUM"
                    dgv2.Columns.Add("Contant1", "Constant 1")
                    dgv2.Columns.Add("Contant2", "Constant 2")
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})
                    dgv2.Columns.Add(cbo)

                    dgv2.Columns.Add("Contant3", "Integer Name")

                Case "MULT"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})
                    dgv2.Columns.Add(cbo)
                    dgv2.Columns.Add("Contant1", "Integer Name")

                Case "DIV"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name 1"
                    cbo.Name = "VariableName"
                    cbo.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})
                    dgv2.Columns.Add(cbo)
                    dgv2.Columns.Add("Contant1", "Integer Name 1")

                    Dim cbo1 As New DataGridViewComboBoxColumn
                    cbo1.HeaderText = "Variable Name 2"
                    cbo1.Name = "VariableName"
                    cbo1.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})

                    dgv2.Columns.Add(cbo1)

                    dgv2.Columns.Add("Contant2", "Integer Name 2")
                Case "DIFFEREND"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})
                    dgv2.Columns.Add(cbo)

                    dgv2.Columns.Add("Contant1", "Integer Name")
                Case "INTEGRAL"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})

                    dgv2.Columns.Add(cbo)

                    dgv2.Columns.Add("Contant1", "Integer Name")
                Case "DELAY"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.AddRange(New Object() {"COUNT", "CPUTIME", "DT", "DTCRNT", "EMASS", "ERRMAX", "NULL", "SYSTMS", "STDTRN", "SYSMER", "TESTDA", "TIME", "TIMEOF", "TMASS", " ", "ACPGTG", "ACPNIT", "ACQTANK", "ACRHON", "ACTTANK", "ACVDM", "ACVGTG", "ACVLIQ", "AHFGTF", "AHFGTG", "AHFTG", "AHGTF", "AVGTG", "AVISCN", "BETAV", "CDIM", "DIM", "DMGDT", "GDRY", "OMEGA", "PMPHEAD", "PMPMT", "PMPNRT", "PMPTRQ", "PMPVEL", "THETA", "TUREFF", "TURPOW", "TURTRQ", "TURVEL", "VLVAREA", "VLVSTEM", "XCO", "XCU", "XI", " ", "AVOL", "BETAFF", "BETAGG", "BORON", "B", "CSUBPF", "CSUBPG", "DRFDP", "DRFDUF", "DRGDP", "DRGDUG", "DRGDXA", "DSNDDP", "DTDP", "DTDXA", "DTFDUF", "DTGDP", "DTGDUG", "DTGDXA", "FLOREG", "FWALF", "FWALG", "GAMMAC", "GAMMAI", "GAMMAW", "GAMANHY", "HVMIX", "P", "PECLTV", "PPS", "Q", "QUALA", "QUALE", "QUALHY", "QUALS", "QWG", "RHO", "RHOF", "RHOG", "RHOM", "SATHF", "SATHG", "SATTEMP", "SIGMA", "SOUNDE", "TEMPF", "TEMPG", "THCONF", "THCONG", "TSATT", "UF", "UG", "VAPGEN", "VELF", "VELG", "VISCF", "VISCG", "VOIDF", "VOIDG", "VOIDLA", "VOIDLB", "VOLLEV", "VVOL", "C0J", "CHOKEF", "FIJ", "FJUNFT", "FJUNRT", "FLORGJ", "FORMFJ", "FORMGJ", "FWALFJ", "FWALGJ", "IREGJ", "MFLOWJ", "QUALAJ", "RHOFJ", "RHOGJ", "SONICJ", "UFJ", "UGJ", "VELFJ", "VELGJ", "VGJJ", "VOIDFJ", "VOIDGJ", "VOIDJ", "XEJ", " ", "HTCHF", "HTHTC", "HTMODE", "HTRG", "HTRNR", "HTTEMP", "HTVAT", "PECL", "STANT", " ", "FINES", "TCHFQF", "TREWET", "ZQBOT", "ZQTOP", " ", "RKPOWA", "RKFIPOW", "RKGAPOW", "RKREAC", "RKRECPER", "RKTPOW", " ", "GNTBLVAL", "CNTRLVAR", " ", "BGMAT", "BGMCT", "BGNHG", "BGTFPRN", "BGTFPRS", "BGTH", "BGTHQ", "BGTHQU", "BGTHU", "CRUCB", "REPOOL", "SHQIN", "SHQOUT", "TCORAV"})

                    dgv2.Columns.Add(cbo)

                    dgv2.Columns.Add("Contant1", "Integer Name")
                    dgv2.Columns.Add("Contant2", "Delay Time (s)")
                    dgv2.Columns.Add("Contant3", "No. of hold positions")
                Case "TRIPUNIT"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Trip Number"
                    cbo.Name = "VariableName"
                    cbo.Items.Add("1")
                    cbo.Items.Add("0")
                    cbo.Items.Add("-1")
                    dgv2.Columns.Add(cbo)

            End Select


        End If
    End Sub
End Class
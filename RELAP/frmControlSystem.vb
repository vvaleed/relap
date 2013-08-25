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
                    cbo.Items.Add("C0J")
                    cbo.Items.Add("CHOKEF")
                    cbo.Items.Add("FIJ")
                    cbo.Items.Add("FJUNFT")
                    cbo.Items.Add("FJUNRT")
                    cbo.Items.Add("FLORGJ")
                    cbo.Items.Add("FORMFJ")
                    cbo.Items.Add("FORMGJ")
                    cbo.Items.Add("FWALFJ")
                    cbo.Items.Add("FWALGJ")
                    cbo.Items.Add("IREGJ")
                    cbo.Items.Add("MFLOWJ")
                    cbo.Items.Add("QUALAJ")
                    cbo.Items.Add("RHOFJ")
                    cbo.Items.Add("RHOGJ")
                    cbo.Items.Add("SONICJ")
                    cbo.Items.Add("UFJ")
                    cbo.Items.Add("UGJ")
                    cbo.Items.Add("VELFJ")
                    cbo.Items.Add("VELGJ")
                    cbo.Items.Add("VGJJ")
                    cbo.Items.Add("VOIDFJ")
                    cbo.Items.Add("VOIDGJ")
                    cbo.Items.Add("VOIDJ")
                    cbo.Items.Add("XEJ")
                    dgv2.Columns.Add(cbo)

                    dgv2.Columns.Add("Contant3", "Integer Name")

                Case "MULT"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.Add("C0J")
                    cbo.Items.Add("CHOKEF")
                    cbo.Items.Add("FIJ")
                    cbo.Items.Add("FJUNFT")
                    cbo.Items.Add("FJUNRT")
                    cbo.Items.Add("FLORGJ")
                    cbo.Items.Add("FORMFJ")
                    cbo.Items.Add("FORMGJ")
                    cbo.Items.Add("FWALFJ")
                    cbo.Items.Add("FWALGJ")
                    cbo.Items.Add("IREGJ")
                    cbo.Items.Add("MFLOWJ")
                    cbo.Items.Add("QUALAJ")
                    cbo.Items.Add("RHOFJ")
                    cbo.Items.Add("RHOGJ")
                    cbo.Items.Add("SONICJ")
                    cbo.Items.Add("UFJ")
                    cbo.Items.Add("UGJ")
                    cbo.Items.Add("VELFJ")
                    cbo.Items.Add("VELGJ")
                    cbo.Items.Add("VGJJ")
                    cbo.Items.Add("VOIDFJ")
                    cbo.Items.Add("VOIDGJ")
                    cbo.Items.Add("VOIDJ")
                    cbo.Items.Add("XEJ")
                    dgv2.Columns.Add(cbo)

                    dgv2.Columns.Add("Contant1", "Integer Name")

                Case "DIV"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name 1"
                    cbo.Name = "VariableName"
                    cbo.Items.Add("C0J")
                    cbo.Items.Add("CHOKEF")
                    cbo.Items.Add("FIJ")
                    cbo.Items.Add("FJUNFT")
                    cbo.Items.Add("FJUNRT")
                    cbo.Items.Add("FLORGJ")
                    cbo.Items.Add("FORMFJ")
                    cbo.Items.Add("FORMGJ")
                    cbo.Items.Add("FWALFJ")
                    cbo.Items.Add("FWALGJ")
                    cbo.Items.Add("IREGJ")
                    cbo.Items.Add("MFLOWJ")
                    cbo.Items.Add("QUALAJ")
                    cbo.Items.Add("RHOFJ")
                    cbo.Items.Add("RHOGJ")
                    cbo.Items.Add("SONICJ")
                    cbo.Items.Add("UFJ")
                    cbo.Items.Add("UGJ")
                    cbo.Items.Add("VELFJ")
                    cbo.Items.Add("VELGJ")
                    cbo.Items.Add("VGJJ")
                    cbo.Items.Add("VOIDFJ")
                    cbo.Items.Add("VOIDGJ")
                    cbo.Items.Add("VOIDJ")
                    cbo.Items.Add("XEJ")
                    dgv2.Columns.Add(cbo)

                    dgv2.Columns.Add("Contant1", "Integer Name 1")

                    Dim cbo1 As New DataGridViewComboBoxColumn
                    cbo1.HeaderText = "Variable Name 2"
                    cbo1.Name = "VariableName"
                    cbo1.Items.Add("C0J")
                    cbo1.Items.Add("CHOKEF")
                    cbo1.Items.Add("FIJ")
                    cbo1.Items.Add("FJUNFT")
                    cbo1.Items.Add("FJUNRT")
                    cbo1.Items.Add("FLORGJ")
                    cbo1.Items.Add("FORMFJ")
                    cbo1.Items.Add("FORMGJ")
                    cbo1.Items.Add("FWALFJ")
                    cbo1.Items.Add("FWALGJ")
                    cbo1.Items.Add("IREGJ")
                    cbo1.Items.Add("MFLOWJ")
                    cbo1.Items.Add("QUALAJ")
                    cbo1.Items.Add("RHOFJ")
                    cbo1.Items.Add("RHOGJ")
                    cbo1.Items.Add("SONICJ")
                    cbo1.Items.Add("UFJ")
                    cbo1.Items.Add("UGJ")
                    cbo1.Items.Add("VELFJ")
                    cbo1.Items.Add("VELGJ")
                    cbo1.Items.Add("VGJJ")
                    cbo1.Items.Add("VOIDFJ")
                    cbo1.Items.Add("VOIDGJ")
                    cbo1.Items.Add("VOIDJ")
                    cbo1.Items.Add("XEJ")
                    dgv2.Columns.Add(cbo1)

                    dgv2.Columns.Add("Contant2", "Integer Name 2")
                Case "DIFFEREND"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.Add("C0J")
                    cbo.Items.Add("CHOKEF")
                    cbo.Items.Add("FIJ")
                    cbo.Items.Add("FJUNFT")
                    cbo.Items.Add("FJUNRT")
                    cbo.Items.Add("FLORGJ")
                    cbo.Items.Add("FORMFJ")
                    cbo.Items.Add("FORMGJ")
                    cbo.Items.Add("FWALFJ")
                    cbo.Items.Add("FWALGJ")
                    cbo.Items.Add("IREGJ")
                    cbo.Items.Add("MFLOWJ")
                    cbo.Items.Add("QUALAJ")
                    cbo.Items.Add("RHOFJ")
                    cbo.Items.Add("RHOGJ")
                    cbo.Items.Add("SONICJ")
                    cbo.Items.Add("UFJ")
                    cbo.Items.Add("UGJ")
                    cbo.Items.Add("VELFJ")
                    cbo.Items.Add("VELGJ")
                    cbo.Items.Add("VGJJ")
                    cbo.Items.Add("VOIDFJ")
                    cbo.Items.Add("VOIDGJ")
                    cbo.Items.Add("VOIDJ")
                    cbo.Items.Add("XEJ")
                    dgv2.Columns.Add(cbo)

                    dgv2.Columns.Add("Contant1", "Integer Name")
                Case "INTEGRAL"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.Add("C0J")
                    cbo.Items.Add("CHOKEF")
                    cbo.Items.Add("FIJ")
                    cbo.Items.Add("FJUNFT")
                    cbo.Items.Add("FJUNRT")
                    cbo.Items.Add("FLORGJ")
                    cbo.Items.Add("FORMFJ")
                    cbo.Items.Add("FORMGJ")
                    cbo.Items.Add("FWALFJ")
                    cbo.Items.Add("FWALGJ")
                    cbo.Items.Add("IREGJ")
                    cbo.Items.Add("MFLOWJ")
                    cbo.Items.Add("QUALAJ")
                    cbo.Items.Add("RHOFJ")
                    cbo.Items.Add("RHOGJ")
                    cbo.Items.Add("SONICJ")
                    cbo.Items.Add("UFJ")
                    cbo.Items.Add("UGJ")
                    cbo.Items.Add("VELFJ")
                    cbo.Items.Add("VELGJ")
                    cbo.Items.Add("VGJJ")
                    cbo.Items.Add("VOIDFJ")
                    cbo.Items.Add("VOIDGJ")
                    cbo.Items.Add("VOIDJ")
                    cbo.Items.Add("XEJ")
                    dgv2.Columns.Add(cbo)

                    dgv2.Columns.Add("Contant1", "Integer Name")
                Case "DELAY"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.Add("C0J")
                    cbo.Items.Add("CHOKEF")
                    cbo.Items.Add("FIJ")
                    cbo.Items.Add("FJUNFT")
                    cbo.Items.Add("FJUNRT")
                    cbo.Items.Add("FLORGJ")
                    cbo.Items.Add("FORMFJ")
                    cbo.Items.Add("FORMGJ")
                    cbo.Items.Add("FWALFJ")
                    cbo.Items.Add("FWALGJ")
                    cbo.Items.Add("IREGJ")
                    cbo.Items.Add("MFLOWJ")
                    cbo.Items.Add("QUALAJ")
                    cbo.Items.Add("RHOFJ")
                    cbo.Items.Add("RHOGJ")
                    cbo.Items.Add("SONICJ")
                    cbo.Items.Add("UFJ")
                    cbo.Items.Add("UGJ")
                    cbo.Items.Add("VELFJ")
                    cbo.Items.Add("VELGJ")
                    cbo.Items.Add("VGJJ")
                    cbo.Items.Add("VOIDFJ")
                    cbo.Items.Add("VOIDGJ")
                    cbo.Items.Add("VOIDJ")
                    cbo.Items.Add("XEJ")
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
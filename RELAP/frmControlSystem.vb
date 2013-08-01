Public Class frmControlSystem
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent


    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellEndEdit
        '        SUM()
        '        MULT()
        '        DIV()
        '        DIFFRENI()
        '        DIFFREND()
        '        INTEGRAL()
        'FUNCTION 
        '        STDFNCTN()
        '        DELAY()
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
                    cbo.Items.Add("mflowj")
                    cbo.Items.Add("")
                    dgv2.Columns.Add(cbo)
                    Dim cboObjects As New DataGridViewComboBoxColumn
                    cboObjects.Items.Clear()

                    For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
                        cboObjects.Items.Add(kvp.Value.GraphicObject.Tag)

                    Next
                    dgv2.Columns.Add(cboObjects)


                Case "MULT"
                    Dim cbo As New DataGridViewComboBoxColumn
                    cbo.HeaderText = "Variable Name"
                    cbo.Name = "VariableName"
                    cbo.Items.Add("mflowj")



            End Select
            If dgv1.Rows(e.RowIndex).Cells(1).Value = "SUM" Then

            Else

            End If

        End If
    End Sub
End Class
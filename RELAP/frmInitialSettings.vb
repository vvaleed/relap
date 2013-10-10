Public Class frmInitialSettings
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
   


    Private Sub frmInitialSettings_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        cboDebrisVolume.Items.Clear()

        For Each kvp As KeyValuePair(Of String, SimulationObjects_BaseClass) In My.Application.ActiveSimulation.Collections.ObjectCollection
            cboDebrisVolume.Items.Add(kvp.Value.GraphicObject.Tag)
        Next
    End Sub

    Private Sub frmInitialSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chklistboxCondensibleGases.SetItemChecked(6, True)
        cboCoupleStyle.SelectedIndex = 0
        cboDebrisSource.SelectedIndex = 1
        cboDebrisBreakup.SelectedIndex = 1

    End Sub


    Public Sub Save()
        Try

      
        For Each oControl As Control In TabControl1.Controls
            If TypeOf oControl Is TabPage Then
                Dim otabpage As TabPage = CType(oControl, TabPage)
                For Each _control As Control In otabpage.Controls
                    If TypeOf _control Is TextBox Or TypeOf _control Is DevComponents.Editors.DoubleInput Then
                        'Dim txtbox As TextBox = CType(_control, TextBox)
                        My.Application.ActiveSimulation.Options.ins_clcTextboxes.Add(_control.Text)

                    End If
                    If TypeOf _control Is ComboBox Then
                        Dim txtbox As ComboBox = CType(_control, ComboBox)
                        ' My.Application.ActiveSimulation.Options.ins_clcComboBox.Add(txtbox.Text)
                    End If

                Next
            End If

        Next
        For i = 0 To chklistboxCondensibleGases.CheckedIndices.Count - 1
            My.Application.ActiveSimulation.Options.ins_chklistCondensibleGases.Add(chklistboxCondensibleGases.CheckedIndices(i))
        Next
        ' My.Application.ActiveSimulation.Options.ins_chklistCondensibleGases = chklistboxCondensibleGases.CheckedIndices
        My.Application.ActiveSimulation.Options.ins_hasboron = chklistboxBoron.Checked
        My.Application.ActiveSimulation.Options.ins_defaultfluid = optDefaultFluid.Checked
        My.Application.ActiveSimulation.Options.ins_water = optWater.Checked
        My.Application.ActiveSimulation.Options.ins_heavywater = optHeavyWater.Checked
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loadsettings()
        For Each oControl As Control In TabControl1.Controls
            Dim i = 0
            If TypeOf oControl Is TabPage Then
                Dim otabpage As TabPage = CType(oControl, TabPage)
                For Each _control As Control In otabpage.Controls
                    If (TypeOf _control Is TextBox Or TypeOf _control Is DevComponents.Editors.DoubleInput) And My.Application.ActiveSimulation.Options.ins_clcTextboxes.Count > 0 Then
                        'Dim txtbox As TextBox = CType(_control, TextBox)
                        'My.Application.ActiveSimulation.Options.ins_clcTextboxes.Add(_control.Text)
                        _control.Text = My.Application.ActiveSimulation.Options.ins_clcTextboxes(i)
                        i = i + 1
                    End If
                    If TypeOf _control Is ComboBox Then
                        Dim txtbox As ComboBox = CType(_control, ComboBox)
                        '  My.Application.ActiveSimulation.Options.ins_clcComboBox.Add(txtbox.Text)
                        'txtbox.Text = My.Application.ActiveSimulation.Options.ins_clcComboBox(i)
                        i = i + 1
                    End If

                Next
            End If

        Next

        For i As Integer = 0 To My.Application.ActiveSimulation.Options.ins_chklistCondensibleGases.Count - 1
            chklistboxCondensibleGases.SetItemChecked(My.Application.ActiveSimulation.Options.ins_chklistCondensibleGases.Item(i), True)
        Next


        chklistboxBoron.Checked = My.Application.ActiveSimulation.Options.ins_hasboron
        optDefaultFluid.Checked = My.Application.ActiveSimulation.Options.ins_defaultfluid
        optWater.Checked = My.Application.ActiveSimulation.Options.ins_water
        optHeavyWater.Checked = My.Application.ActiveSimulation.Options.ins_heavywater
    End Sub



   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Save()
    End Sub
End Class
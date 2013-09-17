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

   

  
    Private Sub frmInitialSettings_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
       
    End Sub
End Class
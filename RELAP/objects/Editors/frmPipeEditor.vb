Public Class frmPipeEditor

    Private Sub frmPipeEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim gobj As Microsoft.Msdn.Samples.GraphicObjects.PipeGraphic = My.Application.ActiveSimulation.FormSurface.FlowsheetDesignSurface.SelectedObject
        Dim myCOTK As RELAP.SimulationObjects.UnitOps.pipe = My.Application.ActiveSimulation.Collections.CLCS_PipeCollection(gobj.Name)
        Dim d As Double
        For i = 1 To myCOTK.NumberOfVoulmes
            dgv.Rows.Add(i.ToString)
        Next

        
    End Sub
End Class
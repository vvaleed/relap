Public Class frmObjListView
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
    'Inherits System.Windows.Forms.Form

    '  Dim formc As FormFlowsheet

    Dim loaded As Boolean = False

    Private Sub frmObjListView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Me.DataGridView1
            .Rows.Clear()
            '.Rows.Add(New Object() {"CorrentedeMatria", Me.ImageList2.Images(17), "CorrentedeMatria"})
            '.Rows.Add(New Object() {"Correntedeenergia", Me.ImageList2.Images(18), "Correntedeenergia"})
            '.Rows.Add(New Object() {"Misturador", Me.ImageList2.Images(3), "Misturador"})
            '.Rows.Add(New Object() {"Divisor", Me.ImageList2.Images(4), "Divisor"})
            '.Rows.Add(New Object() {"Resfriador", Me.ImageList2.Images(1), "Resfriador"})
            '.Rows.Add(New Object() {"Aquecedor", Me.ImageList2.Images(2), "Aquecedor"})
            '.Rows.Add(New Object() {"Tubulao", Me.ImageList2.Images(5), "Tubulao"})
            '.Rows.Add(New Object() {"Vlvula", Me.ImageList2.Images(15), "Vlvula"})
            '.Rows.Add(New Object() {"Bomba", Me.ImageList2.Images(6), "Bomba"})
            '.Rows.Add(New Object() {"CompressorAdiabtico", Me.ImageList2.Images(0), "CompressorAdiabtico"})
            '.Rows.Add(New Object() {"TurbinaAdiabtica", Me.ImageList2.Images(14), "TurbinaAdiabtica"})
            '.Rows.Add(New Object() {"HeatExchanger", Me.ImageList2.Images(2), "HeatExchanger"})
            '.Rows.Add(New Object() {"ShortcutColumn", Me.ImageList2.Images(16), "ShortcutColumn"})
            '.Rows.Add(New Object() {"DistillationColumn", Me.ImageList2.Images(16), "DistillationColumn"})
            '.Rows.Add(New Object() {"AbsorptionColumn", Me.ImageList2.Images(16), "AbsorptionColumn"})
            '.Rows.Add(New Object() {"ReboiledAbsorber", Me.ImageList2.Images(16), "ReboiledAbsorber"})
            '.Rows.Add(New Object() {"RefluxedAbsorber", Me.ImageList2.Images(16), "RefluxedAbsorber"})
            '.Rows.Add(New Object() {"ComponentSeparator", Me.ImageList2.Images(22), "ComponentSeparator"})
            .Rows.Add(New Object() {"Tanque", Me.ImageList2.Images(13), "Time Dependant Volume"})
            '.Rows.Add(New Object() {"VasoSeparadorGL", Me.ImageList2.Images(16), "VasoSeparadorGL"})
            '.Rows.Add(New Object() {"ReatorConversao", Me.ImageList2.Images(7), "ReatorConversao"})
            '.Rows.Add(New Object() {"ReatorEquilibrio", Me.ImageList2.Images(9), "ReatorEquilibrio"})
            '.Rows.Add(New Object() {"ReatorGibbs", Me.ImageList2.Images(10), "ReatorGibbs"})
            '.Rows.Add(New Object() {"ReatorCSTR", Me.ImageList2.Images(8), "ReatorCSTR"})
            '.Rows.Add(New Object() {"ReatorPFR", Me.ImageList2.Images(11), "ReatorPFR"})
            '.Rows.Add(New Object() {"OrificePlate", Me.ImageList2.Images(23), "OrificePlate"})
            '.Rows.Add(New Object() {"Ajuste", Me.ImageList2.Images(19), "Ajuste"})
            '.Rows.Add(New Object() {"Especificao", Me.ImageList2.Images(20), "Especificao"})
            '.Rows.Add(New Object() {"Reciclo", Me.ImageList2.Images(12), "Reciclo"})
            '.Rows.Add(New Object() {"EnergyRecycle", Me.ImageList2.Images(21), "EnergyRecycle"})
            '.Rows.Add(New Object() {"CustomUnitOp", Me.ImageList2.Images(24), "CustomUnitOp"})
            '.Rows.Add(New Object() {"CapeOpenUnitOperation", Me.ImageList2.Images(25), "CapeOpenUnitOperation"})
            '.Sort(.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
            .Refresh()

        End With

    End Sub

    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        Try
            Dim hit As DataGridView.HitTestInfo = Me.DataGridView1.HitTest(e.X, e.Y)
            Me.DataGridView1.DoDragDrop(Me.DataGridView1.Rows(hit.RowIndex), DragDropEffects.Copy)
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class frmObjListView
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
    'Inherits System.Windows.Forms.Form

    '  Dim formc As FormFlowsheet

    Dim loaded As Boolean = False

    Private Sub frmObjListView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With Me.DataGridView1
            .Rows.Clear()

            .Rows.Add(New Object() {"SingleVolume", Me.ImageList2.Images(13), "Single Volume"})
            .Rows.Add(New Object() {"Tanque", Me.ImageList2.Images(13), "Time Dependent Volume"})
            .Rows.Add(New Object() {"SingleJunction", Me.ImageList2.Images(26), "Single Junction"})
            .Rows.Add(New Object() {"TimeDependentJunction", Me.ImageList2.Images(26), "Time Dependent Junction"})

            .Rows.Add(New Object() {"Tubulao", Me.ImageList2.Images(5), "Pipe"})
            .Rows.Add(New Object() {"Branch", Me.ImageList2.Images(16), "Branch"})
            .Rows.Add(New Object() {"Separator", Me.ImageList2.Images(16), "Separator"})
            .Rows.Add(New Object() {"Vlvula", Me.ImageList2.Images(15), "Valve"})
            .Rows.Add(New Object() {"Bomba", Me.ImageList2.Images(6), "Pump"})

            .Rows.Add(New Object() {"HeatStructure", Me.ImageList2.Images(26), "HeatStructure"})




            .Rows.Add(New Object() {"FuelRod", Me.ImageList2.Images(5), "Fuel Rod"})
            .Rows.Add(New Object() {"Simulator", Me.ImageList2.Images(16), "Simulator"})
            .Rows.Add(New Object() {"PWRControlRod", Me.ImageList2.Images(8), "PWR Control Rod"})
            .Rows.Add(New Object() {"Shroud", Me.ImageList2.Images(9), "Shroud"})

            ' .Sort(.Columns(2), System.ComponentModel.ListSortDirection.Ascending)
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
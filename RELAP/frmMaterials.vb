Public Class frmMaterials
    ' Inherits WeifenLuo.WinFormsUI.Docking.DockContent


    Private _checkMaterial As Double
    Public Property checkMaterial() As Double
        Get
            Return _checkMaterial
        End Get
        Set(ByVal value As Double)
            _checkMaterial = value
        End Set
    End Property

    Private Sub frmMaterials_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CmboboxSelectMaterial.SelectedIndex = 0

    End Sub

    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Me._checkMaterial = 1
    End Sub
End Class
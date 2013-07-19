Imports System.Windows.Forms.Design
Imports System.Drawing.Design
Imports System.ComponentModel
Namespace RELAP.Editors
    Public Class UIVolumeSelector
        Inherits System.Drawing.Design.UITypeEditor

        Private editorService As IWindowsFormsEditorService

        Public selectedMSID As String = ""
        Public selectedMSName As String = ""
        Dim loaded As Boolean = False
        Dim form As FormFlowsheet

        Public WithEvents ListView2 As System.Windows.Forms.ListView
        Public WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader

        Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As UITypeEditorEditStyle
            If Not context Is Nothing AndAlso Not context.Instance Is Nothing Then
                Return UITypeEditorEditStyle.DropDown
            End If
            Return UITypeEditorEditStyle.None
        End Function

        Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            If (provider IsNot Nothing) Then
                editorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)),  _
                IWindowsFormsEditorService)
            End If

            If (editorService IsNot Nothing) Then

                Me.ListView2 = New System.Windows.Forms.ListView
                Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
                '
                'ListView2
                '
                Me.ListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
                Me.ListView2.Dock = System.Windows.Forms.DockStyle.Fill
                Me.ListView2.FullRowSelect = True
                Me.ListView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
                Me.ListView2.HideSelection = False
                Me.ListView2.LabelWrap = False
                Me.ListView2.Location = New System.Drawing.Point(0, 0)
                Me.ListView2.MultiSelect = False
                Me.ListView2.Name = "ListView2"
                Me.ListView2.ShowGroups = False
                Me.ListView2.TabIndex = 1
                Me.ListView2.UseCompatibleStateImageBehavior = False
                Me.ListView2.View = System.Windows.Forms.View.Details
                Me.ListView2.BorderStyle = BorderStyle.None
                Me.ListView2.Margin = New System.Windows.Forms.Padding(0)
                '
                'ColumnHeader3
                '
                Me.ColumnHeader3.Text = "Name"
                Me.ColumnHeader3.AutoResize(ColumnHeaderAutoResizeStyle.None)
                Me.ColumnHeader3.Width = Me.ListView2.Width

                form = My.Application.ActiveSimulation

                Me.ListView2.Items.Clear()
                For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
                    If obj.UID = form.FromComponent Then

                    End If
                Next
                For Each mstr As SimulationObjects.UnitOps.SingleJunction In form.Collections.CLCS_SingleJunctionCollection.Values
                    If Not mstr.GraphicObject.OutputConnectors(0).IsAttached Then
                        Dim lvi As New ListViewItem()
                        With lvi
                            .Text = mstr.GraphicObject.Tag
                            .Tag = mstr.UID
                            .Name = mstr.UID
                        End With
                        ListView2.Items.Add(lvi)
                    End If
                Next
                Me.ListView2.SelectedItems.Clear()

                'Me.ListView2.Items(selectedRSID).Selected = True

                Me.loaded = True

                Me.selectedMSName = value

                editorService.DropDownControl(ListView2)

                value = Me.selectedMSName

            End If

            Return value

        End Function

        Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged
            If Me.loaded Then
                If Me.ListView2.SelectedItems.Count > 0 Then
                    Me.selectedMSID = Me.ListView2.SelectedItems(0).Name
                    Me.selectedMSName = Me.ListView2.SelectedItems(0).Text
                    Me.editorService.CloseDropDown()
                End If
            End If
        End Sub

        Private Sub ListView2_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.VisibleChanged
            Me.ColumnHeader3.Width = Me.ListView2.Width
        End Sub

    End Class
End Namespace
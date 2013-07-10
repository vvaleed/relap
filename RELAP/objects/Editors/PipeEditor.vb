﻿Imports System.Windows.Forms.Design
Imports System.Drawing.Design
Imports System.ComponentModel
Namespace RELAP.Editors
    Public Class PipeEditor
        Inherits System.Drawing.Design.UITypeEditor

        Private editorService As IWindowsFormsEditorService

        Public Overrides Function GetEditStyle(ByVal context As System.ComponentModel.ITypeDescriptorContext) As UITypeEditorEditStyle
            Return UITypeEditorEditStyle.Modal
        End Function

        Public Overrides Function EditValue(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal provider As IServiceProvider, ByVal value As Object) As Object

            If (provider IsNot Nothing) Then
                editorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)),  _
                IWindowsFormsEditorService)
            End If

            If (editorService IsNot Nothing) Then
                Dim selectionControl As New frmPipeEditor

                selectionControl.PipeEditor1.SystemOfUnits = My.Application.ActiveSimulation.Options.SelectedUnitSystem
                selectionControl.PipeEditor1.NumberFormat = My.Application.ActiveSimulation.Options.NumberFormat
                selectionControl.PipeEditor1.Profile = value

                editorService.ShowDialog(selectionControl)

                value = selectionControl.PipeEditor1.Profile

            End If

            Return value

        End Function

    End Class
End Namespace
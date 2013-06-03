Imports Microsoft.Msdn.Samples.GraphicObjects
Imports System.Collections.Generic
Imports System.ComponentModel
Imports PropertyGridEx
Imports WeifenLuo.WinFormsUI.Docking
Imports LukeSw.Windows.Forms
'Imports RELAP.RELAP.Flowsheet.FlowsheetSolver
'Imports RELAP.RELAP.SimulationObjects
Imports System.Drawing.Drawing2D

Public Class frmSurface
    Inherits DockContent

    Private m_connecting As Boolean = False
    Private m_stPoint As New Point

    Private ChildParent As FormFlowsheet
    Public PGEx2 As PropertyGridEx.PropertyGridEx
    Public PGEx1 As PropertyGridEx.PropertyGridEx

    Public m_startobj, m_endobj As GraphicObject
    Public uid As String
    Public m_qt As RELAP.GraphicObjects.QuickTableGraphic

    Public ticks As Integer

    Public Function ReturnForm(ByVal str As String) As IDockContent

        If str = Me.ToString Then
            Return Me
        Else
            Return Nothing
        End If

    End Function

    Public Sub SetupGraphicsSurface()
        'load up the design surface with the default bounds and margins
        Dim defSettings As Printing.PageSettings = _
            designSurfacePrintDocument.DefaultPageSettings
        With defSettings

            Dim bounds As Rectangle = .Bounds
            Dim horizRes As Integer = .PrinterResolution.X

            Dim vertRes As Integer = .PrinterResolution.Y

            Me.FlowsheetDesignSurface.SurfaceBounds = bounds

            'Me.FlowsheetDesignSurface.GridSize = 50
            Me.FlowsheetDesignSurface.SurfaceMargins = _
                New Rectangle(bounds.Left + .Margins.Left, _
                    bounds.Top + .Margins.Top, _
                    bounds.Width - .Margins.Left - .Margins.Right, _
                    bounds.Height - .Margins.Top - .Margins.Bottom)
        End With


    End Sub

    Private Sub designSurfacePrintDocument_PrintPage(ByVal sender As System.Object, _
            ByVal e As System.Drawing.Printing.PrintPageEventArgs) _
            Handles designSurfacePrintDocument.PrintPage
        Dim drawobj As GraphicObjectCollection = Me.FlowsheetDesignSurface.drawingObjects
        Me.FlowsheetDesignSurface.drawingObjects.PrintObjects(e.Graphics, -FlowsheetDesignSurface.HorizontalScroll.Value, -FlowsheetDesignSurface.VerticalScroll.Value)
    End Sub

    Private Sub frmSurface_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        uid = 0
        ChildParent = Me.ParentForm
        PGEx1 = Me.ChildParent.FormProps.PGEx1
        PGEx2 = Me.ChildParent.FormProps.PGEx2

        'If Not ChildParent.Options.SelectedPropertyPackage Is Nothing Then Me.LabelPP.Text = "PP: " & ChildParent.Options.SelectedPropertyPackage.ComponentName

    End Sub

    '
    '
    '
    '
    '   FUNCAO MOUSECLICK NO FLUXOGRAMA / UPDATE SELECTED OBJECT
    '
    '
    '
    '

    Public Sub UpdateSelectedObject()

        If Not Me.FlowsheetDesignSurface.SelectedObject Is Nothing Then
            ChildParent.FormProps.SuspendLayout()
            If Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_Tabela Then
                ChildParent.FormProps.LblNomeObj.Text = RELAP.App.GetLocalString("Tabela")
                ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString("TabeladeDados")
                ChildParent.FormProps.LblStatusObj.Text = "-"
                ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            ElseIf Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_MasterTable Then
                ChildParent.FormProps.LblNomeObj.Text = RELAP.App.GetLocalString("MasterTable")
                ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString("MasterTable")
                ChildParent.FormProps.LblStatusObj.Text = "-"
                ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            ElseIf Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_Figura Then
                ChildParent.FormProps.LblNomeObj.Text = RELAP.App.GetLocalString("Figura")
                ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString("ImagemBitmap")
                ChildParent.FormProps.LblStatusObj.Text = "-"
                ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            ElseIf Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_Texto Then
                ChildParent.FormProps.LblNomeObj.Text = RELAP.App.GetLocalString("Texto")
                ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString("CaixadeTexto")
                ChildParent.FormProps.LblStatusObj.Text = "-"
                ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            Else
                '   Dim nodes = ChildParent.FormObjList.TreeViewObj.Nodes.Find(Me.FlowsheetDesignSurface.SelectedObject.Tag, True)
                ChildParent.FormProps.LblNomeObj.Text = Me.FlowsheetDesignSurface.SelectedObject.Tag
                ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString(ChildParent.Collections.ObjectCollection.Item(Me.FlowsheetDesignSurface.SelectedObject.Name).Descricao)
                Select Case Me.FlowsheetDesignSurface.SelectedObject.Status
                    Case Status.Calculated
                        ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("Calculado")
                        ChildParent.FormProps.LblStatusObj.ForeColor = Color.SteelBlue
                    Case Status.Calculating
                        ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("Calculando")
                        ChildParent.FormProps.LblStatusObj.ForeColor = Color.YellowGreen
                    Case Status.ErrorCalculating
                        ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("NoCalculado")
                        ChildParent.FormProps.LblStatusObj.ForeColor = Color.Red
                    Case Status.Inactive
                        ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("Inativo")
                        ChildParent.FormProps.LblStatusObj.ForeColor = Color.Gray
                    Case Status.Idle
                        ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("Calculado")
                        ChildParent.FormProps.LblStatusObj.ForeColor = Color.SteelBlue
                End Select
            End If
            ChildParent.PopulatePGEx2(Me.FlowsheetDesignSurface.SelectedObject)
            Try
                If Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_Tabela Then
                    CType(Me.FlowsheetDesignSurface.SelectedObject, RELAP.GraphicObjects.TableGraphic).PopulateGrid(PGEx1)
                ElseIf Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_MasterTable Then
                    CType(Me.FlowsheetDesignSurface.SelectedObject, RELAP.GraphicObjects.MasterTableGraphic).PopulateGrid(PGEx1, ChildParent)
                Else
                    ChildParent.Collections.ObjectCollection(Me.FlowsheetDesignSurface.SelectedObject.Name).PopulatePropertyGrid(PGEx1, ChildParent.Options.SelectedUnitSystem)
                End If
               
                ChildParent.FormProps.ResumeLayout()
            Catch ex As Exception
                PGEx1.SelectedObject = Nothing
                VDialog.Show(ex.Message & " - " & ex.StackTrace, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PGEx2.Refresh()
                PGEx1.Refresh()
            End Try

        Else

            PGEx2.SelectedObject = Nothing
            PGEx1.SelectedObject = Nothing

        End If

    End Sub

    Private Sub FlowsheetDesignSurface_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles FlowsheetDesignSurface.KeyDown

        If e.KeyCode = Keys.Delete Then
            Call Me.ChildParent.DeleteSelectedObject(sender, e)


        End If

        If Not Me.FlowsheetDesignSurface.SelectedObject Is Nothing Then
            For Each go As GraphicObject In Me.FlowsheetDesignSurface.SelectedObjects.Values
                If e.KeyCode = Keys.Up Then
                    If e.Modifiers = Keys.Control Then
                        go.Y = go.Y - 1
                    Else
                        go.Y = go.Y - 5
                    End If
                ElseIf e.KeyCode = Keys.Down Then
                    If e.Modifiers = Keys.Control Then
                        go.Y = go.Y + 1
                    Else
                        go.Y = go.Y + 5
                    End If
                ElseIf e.KeyCode = Keys.Left Then
                    If e.Modifiers = Keys.Control Then
                        go.X = go.X - 1
                    Else
                        go.X = go.X - 5
                    End If
                ElseIf e.KeyCode = Keys.Right Then
                    If e.Modifiers = Keys.Control Then
                        go.X = go.X + 1
                    Else
                        go.X = go.X + 5
                    End If
                End If
            Next
            Me.FlowsheetDesignSurface.Invalidate()
        Else
            If e.KeyCode = Keys.Up Then
                If Me.FlowsheetDesignSurface.VerticalScroll.Value > 4 * Me.FlowsheetDesignSurface.VerticalScroll.SmallChange Then
                    Me.FlowsheetDesignSurface.VerticalScroll.Value -= 4 * Me.FlowsheetDesignSurface.VerticalScroll.SmallChange
                Else
                    Me.FlowsheetDesignSurface.VerticalScroll.Value = 0
                End If
            ElseIf e.KeyCode = Keys.Down Then
                Me.FlowsheetDesignSurface.VerticalScroll.Value += 4 * Me.FlowsheetDesignSurface.VerticalScroll.SmallChange
            ElseIf e.KeyCode = Keys.Left Then
                If Me.FlowsheetDesignSurface.HorizontalScroll.Value > 4 * Me.FlowsheetDesignSurface.HorizontalScroll.SmallChange Then
                    Me.FlowsheetDesignSurface.HorizontalScroll.Value -= 4 * Me.FlowsheetDesignSurface.HorizontalScroll.SmallChange
                Else
                    Me.FlowsheetDesignSurface.HorizontalScroll.Value = 0
                End If
            ElseIf e.KeyCode = Keys.Right Then
                Me.FlowsheetDesignSurface.HorizontalScroll.Value += 4 * Me.FlowsheetDesignSurface.HorizontalScroll.SmallChange
            End If
            Me.FlowsheetDesignSurface.Invalidate()
            Me.FlowsheetDesignSurface.Invalidate()
        End If

    End Sub

    Private Sub FlowsheetDesignSurface_SelectionChanged(ByVal sender As Object, _
            ByVal e As Microsoft.MSDN.Samples.DesignSurface.SelectionChangedEventArgs) Handles FlowsheetDesignSurface.SelectionChanged

        Try
            If Not e.SelectedObject Is Nothing Then
                If Not e.SelectedObject.IsConnector Then
                    If Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_Tabela Then
                        ChildParent.FormProps.LblNomeObj.Text = RELAP.App.GetLocalString("Tabela")
                        ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString("TabeladeDados")
                        ChildParent.FormProps.LblStatusObj.Text = "-"
                        ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                    ElseIf Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_MasterTable Then
                        ChildParent.FormProps.LblNomeObj.Text = "MasterTable"
                        ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString("MasterTable")
                        ChildParent.FormProps.LblStatusObj.Text = "-"
                        ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                    ElseIf Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_Figura Then
                        ChildParent.FormProps.LblNomeObj.Text = RELAP.App.GetLocalString("Figura")
                        ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString("ImagemBitmap")
                        ChildParent.FormProps.LblStatusObj.Text = "-"
                        ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                    ElseIf Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_Texto Then
                        ChildParent.FormProps.LblNomeObj.Text = RELAP.App.GetLocalString("Texto")
                        ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString("CaixadeTexto")
                        ChildParent.FormProps.LblStatusObj.Text = "-"
                        ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                    Else
                        '   Dim nodes = ChildParent.FormObjList.TreeViewObj.Nodes.Find(e.SelectedObject.Tag, True)
                        ChildParent.FormProps.LblNomeObj.Text = e.SelectedObject.Tag
                        ChildParent.FormProps.LblTipoObj.Text = RELAP.App.GetLocalString(ChildParent.Collections.ObjectCollection.Item(e.SelectedObject.Name).Descricao)
                        If e.SelectedObject.Active = False Then
                            ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("Inativo")
                            ChildParent.FormProps.LblStatusObj.ForeColor = Color.DimGray
                        Else
                            Select Case Me.FlowsheetDesignSurface.SelectedObject.Status
                                Case Status.Calculated
                                    ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("Calculado")
                                    ChildParent.FormProps.LblStatusObj.ForeColor = Color.SteelBlue
                                Case Status.Calculating
                                    ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("Calculando")
                                    ChildParent.FormProps.LblStatusObj.ForeColor = Color.YellowGreen
                                Case Status.ErrorCalculating
                                    ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("NoCalculado")
                                    ChildParent.FormProps.LblStatusObj.ForeColor = Color.Red
                                Case Status.Inactive
                                    ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("Inativo")
                                    ChildParent.FormProps.LblStatusObj.ForeColor = Color.Gray
                                Case Status.Idle
                                    ChildParent.FormProps.LblStatusObj.Text = RELAP.App.GetLocalString("Calculado")
                                    ChildParent.FormProps.LblStatusObj.ForeColor = Color.SteelBlue
                            End Select
                        End If
                    End If
                    If Not Me.FlowsheetDesignSurface.SelectedObject Is Nothing Then
                        If Me.FlowsheetDesignSurface.SelectedObject.IsConnector = False Then
                            ChildParent.PopulatePGEx2(Me.FlowsheetDesignSurface.SelectedObject)
                            Try
                                If Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_Tabela Then
                                    CType(Me.FlowsheetDesignSurface.SelectedObject, RELAP.GraphicObjects.TableGraphic).PopulateGrid(PGEx1)
                                ElseIf Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.GO_MasterTable Then
                                    CType(Me.FlowsheetDesignSurface.SelectedObject, RELAP.GraphicObjects.MasterTableGraphic).PopulateGrid(PGEx1, ChildParent)
                                Else
                                    If Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.Tank Or Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.Pipe Then
                                        'Dim frm As New frmebt
                                        'frm.Show()

                                    Else
                                        'frmebt.Visible = False
                                    End If
                                    ChildParent.Collections.ObjectCollection(Me.FlowsheetDesignSurface.SelectedObject.Name).PopulatePropertyGrid(PGEx1, ChildParent.Options.SelectedUnitSystem)
                                End If
                                ChildParent.FormProps.ResumeLayout()
                            Catch ex As Exception
                                PGEx1.SelectedObject = Nothing
                            Finally
                                ChildParent.FormSurface.Select()
                            End Try
                        Else
                            Me.FlowsheetDesignSurface.SelectedObject = Nothing
                        End If
                    Else
                        PGEx2.SelectedObject = Nothing
                        PGEx1.SelectedObject = Nothing
                    End If
                    PGEx2.Refresh()
                    PGEx1.Refresh()
                Else
                    ChildParent.FormProps.LblNomeObj.Text = RELAP.App.GetLocalString("Nenhumselecionado")
                    ChildParent.FormProps.LblTipoObj.Text = "-"
                    ChildParent.FormProps.LblStatusObj.Text = "-"
                    ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
                    'ChildParent.FormObjList.TreeViewObj.CollapseAll()
                    'ChildParent.FormObjList.TreeViewObj.SelectedNode = Nothing
                End If
            Else
                PGEx2.SelectedObject = Nothing
                PGEx1.SelectedObject = Nothing
            End If
        Catch
            'ChildParent.FormObjList.TreeViewObj.CollapseAll()
            'ChildParent.FormObjList.TreeViewObj.SelectedNode = Nothing
        End Try
        If Me.FlowsheetDesignSurface.SelectedObject Is Nothing Then
            ChildParent.FormProps.LblNomeObj.Text = RELAP.App.GetLocalString("Nenhumselecionado")
            ChildParent.FormProps.LblTipoObj.Text = "-"
            ChildParent.FormProps.LblStatusObj.Text = "-"
            ChildParent.FormProps.LblStatusObj.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        If Me.FlowsheetDesignSurface.SelectedObject.Rotation + 90 >= 360 Then
            Me.FlowsheetDesignSurface.SelectedObject.Rotation = Math.Truncate((Me.FlowsheetDesignSurface.SelectedObject.Rotation + 90) / 360)
        Else
            Me.FlowsheetDesignSurface.SelectedObject.Rotation = Me.FlowsheetDesignSurface.SelectedObject.Rotation + 90
        End If
        Me.FlowsheetDesignSurface.Invalidate()
    End Sub

    Private Sub BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BToolStripMenuItem.Click
        If Me.FlowsheetDesignSurface.SelectedObject.Rotation + 180 >= 360 Then
            Me.FlowsheetDesignSurface.SelectedObject.Rotation = Math.Truncate((Me.FlowsheetDesignSurface.SelectedObject.Rotation + 180) / 360)
        Else
            Me.FlowsheetDesignSurface.SelectedObject.Rotation = Me.FlowsheetDesignSurface.SelectedObject.Rotation + 180
        End If
        Me.FlowsheetDesignSurface.Invalidate()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        If Me.FlowsheetDesignSurface.SelectedObject.Rotation + 270 >= 360 Then
            Me.FlowsheetDesignSurface.SelectedObject.Rotation = Math.Truncate((Me.FlowsheetDesignSurface.SelectedObject.Rotation + 270) / 360)
        Else
            Me.FlowsheetDesignSurface.SelectedObject.Rotation = Me.FlowsheetDesignSurface.SelectedObject.Rotation + 270
        End If
        Me.FlowsheetDesignSurface.Invalidate()
    End Sub

    Private Sub FlowsheetDesignSurface_StatusUpdate(ByVal sender As Object, ByVal e As Microsoft.MSDN.Samples.DesignSurface.StatusUpdateEventArgs) Handles FlowsheetDesignSurface.StatusUpdate
        ChildParent.TSTBZoom.Text = Format(FlowsheetDesignSurface.Zoom, "#%")
    End Sub

    Private Sub FlowsheetDesignSurface_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FlowsheetDesignSurface.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then

            If Me.FlowsheetDesignSurface.QuickConnect And My.Computer.Keyboard.CtrlKeyDown Then
                Dim mousePT As New Point(ChildParent.gscTogoc(e.X, e.Y))
                Dim mpx = mousePT.X
                Dim mpy = mousePT.Y
                Me.m_stPoint = mousePT
                Dim myCTool As New ConnectToolGraphic(mousePT)
                myCTool.Name = "CTOOL1234567890"
                myCTool.Width = mousePT.X
                myCTool.Height = mousePT.Y
                Me.m_startobj = Me.FlowsheetDesignSurface.drawingObjects.FindObjectAtPoint(mousePT)
                Me.FlowsheetDesignSurface.drawingObjects.Add(myCTool)
                Me.m_connecting = True
            Else
                Me.FlowsheetDesignSurface.SelectRectangle = True
            End If

            Me.FlowsheetDesignSurface.Invalidate()

        End If

    End Sub

    Public Sub FlowsheetDesignSurface_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FlowsheetDesignSurface.MouseUp

        If Me.m_connecting Then

            Me.m_connecting = False

            Me.FlowsheetDesignSurface.drawingObjects.Remove(Me.FlowsheetDesignSurface.drawingObjects.FindObjectWithName("CTOOL1234567890"))

            Me.m_endobj = Me.FlowsheetDesignSurface.drawingObjects.FindObjectAtPoint(ChildParent.gscTogoc(e.X, e.Y))

            Me.FlowsheetDesignSurface.SelectRectangle = True
            Me.FlowsheetDesignSurface.Invalidate()

            If Not m_startobj Is Nothing And Not m_endobj Is Nothing Then
                If m_startobj.Name <> m_endobj.Name Then Call ChildParent.ConnectObject(Me.m_startobj, Me.m_endobj)
            End If
        End If

        If e.Button = Windows.Forms.MouseButtons.Left Then

            If Not ChildParent.ClickedToolStripMenuItem Is Nothing Then
                If ChildParent.InsertingObjectToPFD Then

                    Dim gObj As GraphicObject = Nothing
                    Dim fillclr As Color = Color.WhiteSmoke
                    Dim lineclr As Color = Color.Red
                    Dim mousePT As Point = ChildParent.gscTogoc(e.X, e.Y)
                    Dim mpx = mousePT.X '- SplitContainer1.SplitterDistance
                    Dim mpy = mousePT.Y '- ToolStripContainer1.TopToolStripPanel.Height
                    Dim tobj As TipoObjeto = TipoObjeto.Nenhum

                    Select Case ChildParent.ClickedToolStripMenuItem.Name

                        Case "TSMIMaterialStream"
                            tobj = TipoObjeto.MaterialStream
                        Case "TSMIEnergyStream"
                            tobj = TipoObjeto.EnergyStream
                        Case "TSMIMixer"
                            tobj = TipoObjeto.NodeIn
                        Case "TSMISplitter"
                            tobj = TipoObjeto.NodeOut
                        Case "TSMICompressor"
                            tobj = TipoObjeto.Compressor
                        Case "TSMIExpander"
                            tobj = TipoObjeto.Expander
                        Case "TSMIPump"
                            tobj = TipoObjeto.Pump
                        Case "TSMIPipe"
                            tobj = TipoObjeto.Pipe
                        Case "TSMIValve"
                            tobj = TipoObjeto.Valve
                        Case "TSMISeparator"
                            tobj = TipoObjeto.Vessel
                        Case "TSMIHeater"
                            tobj = TipoObjeto.Heater
                        Case "TSMICooler"
                            tobj = TipoObjeto.Cooler
                        Case "TSMIOrificePlate"
                            tobj = TipoObjeto.OrificePlate
                        Case "TSMIComponentSeparator"
                            tobj = TipoObjeto.ComponentSeparator
                        Case "TSMIHeatExchanger"
                            tobj = TipoObjeto.HeatExchanger
                        Case "TSMITank"
                            tobj = TipoObjeto.Tank
                        Case "TSMIColShortcut"
                            tobj = TipoObjeto.ShortcutColumn
                        Case "TSMIColDist"
                            tobj = TipoObjeto.DistillationColumn
                        Case "TSMIColAbs"
                            tobj = TipoObjeto.AbsorptionColumn
                        Case "TSMIColAbsReb"
                            tobj = TipoObjeto.ReboiledAbsorber
                        Case "TSMIColAbsCond"
                            tobj = TipoObjeto.RefluxedAbsorber
                        Case "TSMIReactorConv"
                            tobj = TipoObjeto.RCT_Conversion
                        Case "TSMIReactorEquilibrium"
                            tobj = TipoObjeto.RCT_Equilibrium
                        Case "TSMIReactorGibbs"
                            tobj = TipoObjeto.RCT_Gibbs
                        Case "TSMIReactorCSTR"
                            tobj = TipoObjeto.RCT_CSTR
                        Case "TSMIReactorPFR"
                            tobj = TipoObjeto.RCT_PFR
                        Case "TSMIRecycle"
                            tobj = TipoObjeto.OT_Reciclo
                        Case "TSMIEnergyRecycle"
                            tobj = TipoObjeto.OT_EnergyRecycle
                        Case "TSMIAdjust"
                            tobj = TipoObjeto.OT_Ajuste
                        Case "TSMISpecification"
                            tobj = TipoObjeto.OT_Especificacao
                        Case "TSMICUO"
                            tobj = TipoObjeto.CustomUO
                        Case "TSMICOUO"
                            tobj = TipoObjeto.CapeOpenUO
                    End Select

                    AddObjectToSurface(tobj, mpx, mpy)

                    ChildParent.ClickedToolStripMenuItem = Nothing
                    ChildParent.InsertingObjectToPFD = False

                End If

            End If

            'If Not Me.FlowsheetDesignSurface.SelectedObject Is Nothing Then

            '    If Me.FlowsheetDesignSurface.SelectedObject.IsConnector = False Then

            '        ChildParent.PopulatePGEx2(Me.FlowsheetDesignSurface.SelectedObject)
            '        Try
            '            ChildParent.Collections.ObjectCollection(Me.FlowsheetDesignSurface.SelectedObject.Name).PopulatePropertyGrid(PGEx1, ChildParent.Options.SelectedUnitSystem)
            '            ChildParent.FormProps.ResumeLayout()
            '        Catch ex As Exception
            '            PGEx1.SelectedObject = Nothing
            '            'VDialog.Show(ex.Message & " - " & ex.StackTrace, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Finally
            '            ChildParent.FormSurface.Select()
            '        End Try

            '    Else

            '        Me.FlowsheetDesignSurface.SelectedObject = Nothing

            '    End If


            'Else

            '    PGEx2.SelectedObject = Nothing
            '    PGEx1.SelectedObject = Nothing

            'End If
            'PGEx2.Refresh()
            'PGEx1.Refresh()

        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then

            If Not Me.FlowsheetDesignSurface.SelectedObject Is Nothing Then

                Me.CMS_Sel.Items("TSMI_Label").Text = Me.FlowsheetDesignSurface.SelectedObject.Tag
                Me.CMS_Sel.Show(MousePosition)

            Else

                Me.CMS_NoSel.Show(MousePosition)

            End If

        End If

    End Sub

    Private Sub FlowsheetDesignSurface_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FlowsheetDesignSurface.MouseMove

        Dim px As Point = ChildParent.gscTogoc(e.Location.X, e.Location.Y)
        Dim px2 As Point = ChildParent.gscTogoc(e.Location.X + 20, e.Location.Y + 20)

        If Me.m_connecting Then

            Dim myCTool As ConnectToolGraphic = Me.FlowsheetDesignSurface.drawingObjects.FindObjectWithName("CTOOL1234567890")

            Dim mousePT As New Point(ChildParent.gscTogoc(e.X, e.Y))

            myCTool.Width = mousePT.X
            myCTool.Height = mousePT.Y

            Me.FlowsheetDesignSurface.Invalidate()

        Else

            Dim gobj As GraphicObject = Me.FlowsheetDesignSurface.drawingObjects.FindObjectAtPoint(px)

            If Not gobj Is Nothing Then

                If Me.m_qt Is Nothing And Not _
                    gobj.TipoObjeto = TipoObjeto.GO_TabelaRapida And Not _
                    gobj.TipoObjeto = TipoObjeto.GO_MasterTable And Not _
                    gobj.TipoObjeto = TipoObjeto.GO_Tabela And Not _
                    gobj.TipoObjeto = TipoObjeto.GO_Figura And Not _
                    gobj.TipoObjeto = TipoObjeto.GO_Texto And Not _
                    gobj.TipoObjeto = TipoObjeto.Nenhum Then




                ElseIf gobj.TipoObjeto = TipoObjeto.GO_TabelaRapida Then

                    If Me.FlowsheetDesignSurface.drawingObjects.Contains(Me.m_qt) Then
                        Me.FlowsheetDesignSurface.drawingObjects.Remove(Me.m_qt)
                    End If
                    Me.m_qt = Nothing
                    Me.ticks = 0
                    Me.FlowsheetDesignSurface.Invalidate()

                End If

            Else

                Try
                    If Me.FlowsheetDesignSurface.drawingObjects.Contains(Me.m_qt) Then
                        Me.FlowsheetDesignSurface.drawingObjects.Remove(Me.m_qt)
                    End If
                    Me.m_qt = Nothing
                    Me.ticks = 0
                    Me.FlowsheetDesignSurface.Invalidate()
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try

            End If

        End If

        If Not Me.m_qt Is Nothing Then Me.m_qt.SetPosition(px2)
        Me.FlowsheetDesignSurface.Invalidate()

    End Sub





    Private Sub CMS_Sel_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMS_Sel.Opened

        Dim naoLimparListaDeDesconectar As Boolean = False

        Me.CMS_ItemsToDisconnect.Items.Clear()
        Me.CMS_ItemsToConnect.Items.Clear()

        Me.DesconectarDeToolStripMenuItem.Visible = False
        Me.ConectarAToolStripMenuItem.Visible = False
        Me.ToolStripSeparator3.Visible = False

        If Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto <> TipoObjeto.GO_Figura And _
            Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto <> TipoObjeto.GO_Tabela And _
            Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto <> TipoObjeto.GO_MasterTable And _
            Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto <> TipoObjeto.GO_TabelaRapida And _
            Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto <> TipoObjeto.DistillationColumn And _
            Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto <> TipoObjeto.AbsorptionColumn And _
             Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto <> TipoObjeto.ReboiledAbsorber And _
             Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto <> TipoObjeto.RefluxedAbsorber And _
            Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto <> TipoObjeto.GO_Texto Then

            Me.RecalcularToolStripMenuItem.Visible = True
            Me.ToolStripSeparator6.Visible = True
            Me.TabelaToolStripMenuItem.Visible = True
            Me.ClonarToolStripMenuItem.Visible = True
            Me.ExcluirToolStripMenuItem.Visible = True
            Me.HorizontalmenteToolStripMenuItem.Visible = True
            Try
                Dim obj As SimulationObjects_BaseClass = ChildParent.Collections.ObjectCollection(Me.FlowsheetDesignSurface.SelectedObject.Name)
                If Me.IsObjectDownstreamConnectable(obj.GraphicObject.Tag) Then
                    Dim arr As ArrayList = Me.ReturnDownstreamConnectibles(obj.GraphicObject.Tag)
                    Me.CMS_ItemsToConnect.Items.Clear()
                    If arr.Count <> 0 Then
                        Dim i As Integer = 0
                        Do
                            Me.CMS_ItemsToConnect.Items.Add(arr(i))
                            i = i + 1
                            Me.ConectarAToolStripMenuItem.Visible = True
                            Me.ToolStripSeparator3.Visible = True
                            Me.ConectarAToolStripMenuItem.DropDown = Me.CMS_ItemsToConnect
                        Loop Until i = arr.Count
                    End If
                Else
                    Dim arr As ArrayList = Me.ReturnDownstreamDisconnectables(obj.GraphicObject.Tag)
                    Me.CMS_ItemsToDisconnect.Items.Clear()
                    If arr.Count <> 0 Then
                        naoLimparListaDeDesconectar = True
                        Dim i As Integer = 0
                        Do
                            Me.CMS_ItemsToDisconnect.Items.Add(arr(i))
                            i = i + 1
                        Loop Until i = arr.Count
                        Me.DesconectarDeToolStripMenuItem.Visible = True
                        Me.ToolStripSeparator3.Visible = True
                        Me.DesconectarDeToolStripMenuItem.DropDown = Me.CMS_ItemsToDisconnect
                    End If
                End If
                If Me.IsObjectUpstreamConnectable(obj.GraphicObject.Tag) = False Then
                    Dim arr As ArrayList = Me.ReturnUpstreamDisconnectables(obj.GraphicObject.Tag)
                    If naoLimparListaDeDesconectar = False Then Me.CMS_ItemsToDisconnect.Items.Clear()
                    If arr.Count <> 0 Then
                        Dim i As Integer = 0
                        Do
                            Me.CMS_ItemsToDisconnect.Items.Add(arr(i))
                            i = i + 1
                        Loop Until i = arr.Count
                        Me.DesconectarDeToolStripMenuItem.Visible = True
                        Me.ToolStripSeparator3.Visible = True
                        Me.DesconectarDeToolStripMenuItem.DropDown = Me.CMS_ItemsToDisconnect
                    End If
                End If
                If obj.GraphicObject.FlippedH Then
                    Me.HorizontalmenteToolStripMenuItem.Checked = True
                Else
                    Me.HorizontalmenteToolStripMenuItem.Checked = False
                End If
                If obj.Tabela Is Nothing Then
                    Me.MostrarToolStripMenuItem.Checked = False
                Else
                    Me.MostrarToolStripMenuItem.Checked = True
                End If

                If Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.MaterialStream Then
                    EditCompTSMI.Visible = True
                Else
                    EditCompTSMI.Visible = False
                End If

            Catch ex As Exception
                CMS_Sel.Hide()
            End Try

        ElseIf Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.AbsorptionColumn Or _
        Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.DistillationColumn Or _
        Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.ReboiledAbsorber Or _
        Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.RefluxedAbsorber Then

            Me.RecalcularToolStripMenuItem.Visible = True
            Me.ToolStripSeparator6.Visible = True

            Me.ConectarAToolStripMenuItem.Visible = False
            Me.DesconectarDeToolStripMenuItem.Visible = False
            Me.EditCompTSMI.Visible = False

            Me.TabelaToolStripMenuItem.Visible = True
            Me.ClonarToolStripMenuItem.Visible = True
            Me.ExcluirToolStripMenuItem.Visible = True
            Me.HorizontalmenteToolStripMenuItem.Visible = True
            Dim obj As SimulationObjects_BaseClass = ChildParent.Collections.ObjectCollection(Me.FlowsheetDesignSurface.SelectedObject.Name)

            If obj.GraphicObject.FlippedH Then
                Me.HorizontalmenteToolStripMenuItem.Checked = True
            Else
                Me.HorizontalmenteToolStripMenuItem.Checked = False
            End If
            If obj.Tabela Is Nothing Then
                Me.MostrarToolStripMenuItem.Checked = False
            Else
                Me.MostrarToolStripMenuItem.Checked = True
            End If

        Else

            Me.TSMI_Label.Text = "Tabela"
            Me.TabelaToolStripMenuItem.Visible = False
            Me.ClonarToolStripMenuItem.Visible = False
            Me.HorizontalmenteToolStripMenuItem.Visible = False
            Me.ExcluirToolStripMenuItem.Visible = False
            Me.RecalcularToolStripMenuItem.Visible = False
            Me.ToolStripSeparator6.Visible = False
            Me.EditCompTSMI.Visible = False

        End If
        'Me.InverterToolStripMenuItem.Visible = False

    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Me.ChildParent = My.Application.ActiveSimulation
        With ChildParent.FormProps
            .LblStatusObj.Text = "-"
            .LblStatusObj.ForeColor = Color.Black
            .LblNomeObj.Text = RELAP.App.GetLocalString("Fluxograma")
            .LblTipoObj.Text = "-"
        End With

        ChildParent.FormProps.FTSProps.SelectedItem = ChildParent.FormProps.TSObj

        With ChildParent.FormProps.PGEx2

            .PropertySort = PropertySort.NoSort
            .ShowCustomProperties = True
            Try
                .Item.Clear()
            Catch ex As Exception
            Finally
                .Item.Clear()
            End Try
            .Item.Add(RELAP.App.GetLocalString("Cordofundo"), FlowsheetDesignSurface, "BackColor", False, "", "", True)
            With .Item(.Item.Count - 1)
                .DefaultType = GetType(System.Drawing.Color)
            End With
            .Item.Add(RELAP.App.GetLocalString("Cordagrade"), FlowsheetDesignSurface, "GridColor", False, "", "", True)
            With .Item(.Item.Count - 1)
                .DefaultType = GetType(System.Drawing.Color)
            End With
            .Item.Add(RELAP.App.GetLocalString("Espessuradagrade"), FlowsheetDesignSurface, "GridLineWidth", False, "", "", True)
            .Item.Add(RELAP.App.GetLocalString("SnapToGrid"), FlowsheetDesignSurface, "SnapToGrid", False, "", "", True)
            .Item.Add(RELAP.App.GetLocalString("GridSize"), FlowsheetDesignSurface, "GridSize", False, "", "", True)
            .Item.Add(RELAP.App.GetLocalString("Largura"), FlowsheetDesignSurface.SurfaceBounds, "Width", False, "", "", True)
            .Item.Add(RELAP.App.GetLocalString("Altura"), FlowsheetDesignSurface.SurfaceBounds, "Height", False, "", "", True)
            .Item.Add(RELAP.App.GetLocalString("Larguradeimpresso"), FlowsheetDesignSurface.SurfaceMargins, "Width", False, "", "", True)
            .Item.Add(RELAP.App.GetLocalString("Alturadeimpresso"), FlowsheetDesignSurface.SurfaceMargins, "Height", False, "", "", True)

            .Refresh()
        End With

    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        PreviewDialog.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.ticks += 1
    End Sub

    'Private Sub ClonarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClonarToolStripMenuItem.Click

    '    ChildParent = My.Application.ActiveSimulation

    '    Dim obj As SimulationObjects_BaseClass = ChildParent.Collections.ObjectCollection(Me.FlowsheetDesignSurface.SelectedObject.Name)
    '    Dim gObj As GraphicObject = Me.FlowsheetDesignSurface.SelectedObject
    '    Dim newobj As SimulationObjects_BaseClass = obj.Clone
    '    newobj.Tabela = Nothing
    '    newobj.TabelaRapida = Nothing

    '    Dim mpx = Me.FlowsheetDesignSurface.SelectedObject.X + Me.FlowsheetDesignSurface.SelectedObject.Width * 1.1
    '    Dim mpy = Me.FlowsheetDesignSurface.SelectedObject.Y + Me.FlowsheetDesignSurface.SelectedObject.Height * 1.1

    '    Select Case Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto

    '        Case TipoObjeto.OT_Ajuste
    '            Dim myDWOBJ As RELAP.SimulationObjects.SpecialOps.Adjust = CType(newobj, RELAP.SimulationObjects.SpecialOps.Adjust)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "ADJ-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.AdjustCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_AdjustCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.OT_Especificacao
    '            Dim myDWOBJ As RELAP.SimulationObjects.SpecialOps.Spec = CType(newobj, RELAP.SimulationObjects.SpecialOps.Spec)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "SPEC-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.SpecCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_SpecCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.OT_Reciclo
    '            Dim myDWOBJ As RELAP.SimulationObjects.SpecialOps.Recycle = CType(newobj, RELAP.SimulationObjects.SpecialOps.Recycle)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "REC-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.RecycleCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_RecycleCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.OT_EnergyRecycle
    '            Dim myDWOBJ As RELAP.SimulationObjects.SpecialOps.EnergyRecycle = CType(newobj, RELAP.SimulationObjects.SpecialOps.EnergyRecycle)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "EREC-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.EnergyRecycleCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_EnergyRecycleCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.NodeIn
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Mixer = CType(newobj, RELAP.SimulationObjects.UnitOps.Mixer)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "MIX-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeMX").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeMX").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.MixerCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_MixerCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.NodeEn
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.EnergyMixer = CType(newobj, RELAP.SimulationObjects.UnitOps.EnergyMixer)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "MIX-ME_-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeME").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeME").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.MixerENCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_EnergyMixerCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.NodeOut
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Splitter = CType(newobj, RELAP.SimulationObjects.UnitOps.Splitter)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "SPLT-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeSP").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeSP").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.SplitterCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_SplitterCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.Pump
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Pump = CType(newobj, RELAP.SimulationObjects.UnitOps.Pump)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "PUMP-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodePU").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodePU").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.PumpCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_PumpCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.Tank
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Tank = CType(newobj, RELAP.SimulationObjects.UnitOps.Tank)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "TANK-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.TankCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_TankCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.Vessel
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Vessel = CType(newobj, RELAP.SimulationObjects.UnitOps.Vessel)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "SEP-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeSE").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeSE").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.SeparatorCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_VesselCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.MaterialStream
    '            Dim myDWOBJ As RELAP.SimulationObjects.Streams.MaterialStream = CType(newobj, RELAP.SimulationObjects.Streams.MaterialStream)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "MSTR-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeMS").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeMS").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.MaterialStreamCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_MaterialStreamCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.EnergyStream
    '            Dim myDWOBJ As RELAP.SimulationObjects.Streams.EnergyStream = CType(newobj, RELAP.SimulationObjects.Streams.EnergyStream)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "ESTR-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeEN").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeEN").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.EnergyStreamCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_EnergyStreamCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.Compressor
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Compressor = CType(newobj, RELAP.SimulationObjects.UnitOps.Compressor)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "COMP-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeCO").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeCO").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.CompressorCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_CompressorCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.Expander
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Expander = CType(newobj, RELAP.SimulationObjects.UnitOps.Expander)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "EXP-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeTU").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeTU").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.TurbineCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_TurbineCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.Cooler
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Cooler = CType(newobj, RELAP.SimulationObjects.UnitOps.Cooler)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "COOL-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeCL").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeCL").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.CoolerCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_CoolerCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.Heater
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Heater = CType(newobj, RELAP.SimulationObjects.UnitOps.Heater)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "HEAT-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeHT").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeHT").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.HeaterCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_HeaterCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.Pipe
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Pipe = CType(newobj, RELAP.SimulationObjects.UnitOps.Pipe)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "PIPE-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodePI").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodePI").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.PipeCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_PipeCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.Valve
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.Valve = CType(newobj, RELAP.SimulationObjects.UnitOps.Valve)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "VALV-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeVA").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeVA").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.ValveCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_ValveCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.RCT_Conversion
    '            Dim myDWOBJ As RELAP.SimulationObjects.Reactors.Reactor_Conversion = CType(newobj, RELAP.SimulationObjects.Reactors.Reactor_Conversion)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "RC-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRCONV").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRCONV").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.ReactorConversionCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_ReactorConversionCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.RCT_Equilibrium
    '            Dim myDWOBJ As RELAP.SimulationObjects.Reactors.Reactor_Equilibrium = CType(newobj, RELAP.SimulationObjects.Reactors.Reactor_Equilibrium)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "RE-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeREQ").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeREQ").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.ReactorEquilibriumCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_ReactorEquilibriumCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.RCT_Gibbs
    '            Dim myDWOBJ As RELAP.SimulationObjects.Reactors.Reactor_Gibbs = CType(newobj, RELAP.SimulationObjects.Reactors.Reactor_Gibbs)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "RG-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRGIB").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRGIB").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.ReactorGibbsCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_ReactorGibbsCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.RCT_CSTR
    '            Dim myDWOBJ As RELAP.SimulationObjects.Reactors.Reactor_CSTR = CType(newobj, RELAP.SimulationObjects.Reactors.Reactor_CSTR)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "CSTR-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRCSTR").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRCSTR").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.ReactorCSTRCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_ReactorCSTRCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.RCT_PFR
    '            Dim myDWOBJ As RELAP.SimulationObjects.Reactors.Reactor_PFR = CType(newobj, RELAP.SimulationObjects.Reactors.Reactor_PFR)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "PFR-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRPFR").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRPFR").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.ReactorPFRCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_ReactorPFRCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.HeatExchanger
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.HeatExchanger = CType(newobj, RELAP.SimulationObjects.UnitOps.HeatExchanger)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "HE-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeHE").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeHE").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.HeatExchangerCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_HeatExchangerCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.ShortcutColumn
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.ShortcutColumn = CType(newobj, RELAP.SimulationObjects.UnitOps.ShortcutColumn)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "SC-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeSC").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeSC").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.ShortcutColumnCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_ShortcutColumnCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.DistillationColumn
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.DistillationColumn = CType(newobj, RELAP.SimulationObjects.UnitOps.DistillationColumn)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "DC-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeDC").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeDC").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.DistillationColumnCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_DistillationColumnCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.AbsorptionColumn
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.AbsorptionColumn = CType(newobj, RELAP.SimulationObjects.UnitOps.AbsorptionColumn)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "ABS-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeAC").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeAC").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.AbsorptionColumnCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_AbsorptionColumnCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.ReboiledAbsorber
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.ReboiledAbsorber = CType(newobj, RELAP.SimulationObjects.UnitOps.ReboiledAbsorber)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "RBA-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRBA").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRBA").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.ReboiledAbsorberCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_ReboiledAbsorberCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.RefluxedAbsorber
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.RefluxedAbsorber = CType(newobj, RELAP.SimulationObjects.UnitOps.RefluxedAbsorber)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "RFA-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRFA").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeRFA").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.RefluxedAbsorberCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_RefluxedAbsorberCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.ComponentSeparator
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.ComponentSeparator = CType(newobj, RELAP.SimulationObjects.UnitOps.ComponentSeparator)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "CS-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeCSEP").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeCSEP").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.ComponentSeparatorCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_ComponentSeparatorCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.OrificePlate
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.OrificePlate = CType(newobj, RELAP.SimulationObjects.UnitOps.OrificePlate)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "OP-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeOPL").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeOPL").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.OrificePlateCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_OrificePlateCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.CustomUO
    '            Dim myDWOBJ As RELAP.SimulationObjects.UnitOps.CustomUO = CType(newobj, RELAP.SimulationObjects.UnitOps.CustomUO)
    '            With myDWOBJ.GraphicObject
    '                .Calculated = False
    '                .Name = "UO-" & Guid.NewGuid.ToString
    '                .Tag = gObj.Tag & "_CLONE"
    '                .X = mpx
    '                .Y = mpy
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeUO").Nodes.Add(.Name, .Tag).Name = .Name
    '                ChildParent.FormObjList.TreeViewObj.Nodes("NodeUO").Nodes(.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
    '                For Each con As ConnectionPoint In .InputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                For Each con As ConnectionPoint In .OutputConnectors
    '                    con.AttachedConnector = Nothing
    '                    con.IsAttached = False
    '                Next
    '                If Not .SpecialConnectors Is Nothing Then
    '                    For Each con As ConnectionPoint In .SpecialConnectors
    '                        con.AttachedConnector = Nothing
    '                        con.IsAttached = False
    '                    Next
    '                End If
    '                .EnergyConnector.AttachedConnector = Nothing
    '                .EnergyConnector.IsAttached = False
    '            End With
    '            myDWOBJ.Nome = myDWOBJ.GraphicObject.Name
    '            ChildParent.Collections.CustomUOCollection.Add(myDWOBJ.GraphicObject.Name, myDWOBJ.GraphicObject)
    '            ChildParent.Collections.ObjectCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            ChildParent.Collections.CLCS_CustomUOCollection.Add(myDWOBJ.Nome, myDWOBJ)
    '            Me.FlowsheetDesignSurface.drawingObjects.Add(myDWOBJ.GraphicObject)
    '        Case TipoObjeto.CapeOpenUO
    '            VDialog.Show("Cloning is not supported by CAPE-OPEN Unit Operations.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Select
    '    Me.FlowsheetDesignSurface.Invalidate()

    '    Dim arrays(ChildParent.Collections.ObjectCollection.Count - 1) As String
    '    Dim aNode, aNode2 As TreeNode
    '    Dim i As Integer = 0
    '    For Each aNode In ChildParent.FormObjList.TreeViewObj.Nodes
    '        For Each aNode2 In aNode.Nodes
    '            arrays(i) = aNode2.Text
    '            i += 1
    '        Next
    '    Next
    '    ChildParent.FormObjList.ACSC.Clear()
    '    ChildParent.FormObjList.ACSC.AddRange(arrays)
    '    ChildParent.FormObjList.TBSearch.AutoCompleteCustomSource = ChildParent.FormObjList.ACSC

    'End Sub

    Private Sub CMS_ItemsToDisconnect_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CMS_ItemsToDisconnect.ItemClicked

        Call Me.ChildParent.DisconnectObject(Me.FlowsheetDesignSurface.SelectedObject, FormFlowsheet.SearchSurfaceObjectsByTag(e.ClickedItem.Text, Me.FlowsheetDesignSurface))

    End Sub

    Private Sub CMS_ItemsToConnect_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CMS_ItemsToConnect.ItemClicked

        Call Me.ChildParent.ConnectObject(Me.FlowsheetDesignSurface.SelectedObject, FormFlowsheet.SearchSurfaceObjectsByTag(e.ClickedItem.Text, Me.FlowsheetDesignSurface))

    End Sub

    Function IsObjectDownstreamConnectable(ByVal objTag As String) As Boolean

        Dim obj As GraphicObject = FormFlowsheet.SearchSurfaceObjectsByTag(objTag, Me.FlowsheetDesignSurface)

        If Not obj Is Nothing Then

            Dim cp As ConnectionPoint
            For Each cp In obj.OutputConnectors
                If cp.IsAttached = False Then Return True
            Next

        End If

        Return False

    End Function

    Function IsObjectUpstreamConnectable(ByVal objTag As String) As Boolean

        Dim obj As GraphicObject = FormFlowsheet.SearchSurfaceObjectsByTag(objTag, Me.FlowsheetDesignSurface)

        If Not obj Is Nothing Then

            Dim cp As ConnectionPoint
            For Each cp In obj.InputConnectors
                If cp.IsAttached = False Then Return True
            Next

        End If

        Return False

    End Function

    Function ReturnDownstreamConnectibles(ByVal objtag As String)

        Dim refobj As GraphicObject = FormFlowsheet.SearchSurfaceObjectsByTag(objtag, Me.FlowsheetDesignSurface)

        Dim obj As SimulationObjects_BaseClass
        Dim cp As ConnectionPoint

        Dim conables As New ArrayList

        For Each obj In Me.ChildParent.Collections.ObjectCollection.Values
            If obj.GraphicObject.Tag <> refobj.Tag Then
                If obj.GraphicObject.TipoObjeto <> TipoObjeto.GO_Texto And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.GO_TabelaRapida And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.GO_MasterTable And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.GO_Tabela And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.OT_Ajuste And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.OT_Especificacao And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.DistillationColumn And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.AbsorptionColumn And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.RefluxedAbsorber And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.ReboiledAbsorber And _
                    obj.GraphicObject.TipoObjeto <> TipoObjeto.Nenhum Then

                    If refobj.TipoObjeto = TipoObjeto.MaterialStream Then
                        For Each cp In obj.GraphicObject.InputConnectors
                            If Not cp.IsAttached And Not conables.Contains(obj.GraphicObject.Tag) And Not _
                            obj.GraphicObject.TipoObjeto = TipoObjeto.MaterialStream And Not _
                            obj.GraphicObject.TipoObjeto = TipoObjeto.EnergyStream And _
                            cp.Type = ConType.ConIn Then conables.Add(obj.GraphicObject.Tag)
                        Next
                    ElseIf refobj.TipoObjeto = TipoObjeto.EnergyStream Then
                        If obj.GraphicObject.TipoObjeto <> TipoObjeto.Heater And _
                        obj.GraphicObject.TipoObjeto <> TipoObjeto.Pump And _
                        obj.GraphicObject.TipoObjeto <> TipoObjeto.Compressor And _
                        obj.GraphicObject.TipoObjeto <> TipoObjeto.MaterialStream Then
                            cp = obj.GraphicObject.EnergyConnector
                            If Not cp.IsAttached And Not conables.Contains(obj.GraphicObject.Tag) Then conables.Add(obj.GraphicObject.Tag)
                        ElseIf obj.GraphicObject.TipoObjeto = TipoObjeto.MaterialStream Then

                        Else
                            For Each cp In obj.GraphicObject.InputConnectors
                                If Not cp.IsAttached And Not conables.Contains(obj.GraphicObject.Tag) And Not _
                                obj.GraphicObject.TipoObjeto = TipoObjeto.MaterialStream And Not _
                                obj.GraphicObject.TipoObjeto = TipoObjeto.EnergyStream And _
                                cp.Type = ConType.ConEn Then conables.Add(obj.GraphicObject.Tag)
                            Next
                        End If
                    Else
                        For Each cp In obj.GraphicObject.InputConnectors
                            If Not cp.IsAttached And Not conables.Contains(obj.GraphicObject.Tag) Then conables.Add(obj.GraphicObject.Tag)
                        Next
                        If obj.GraphicObject.TipoObjeto = TipoObjeto.MaterialStream Then
                            cp = obj.GraphicObject.InputConnectors(0)
                            If Not cp.IsAttached And Not conables.Contains(obj.GraphicObject.Tag) Then conables.Add(obj.GraphicObject.Tag)
                        ElseIf obj.GraphicObject.TipoObjeto = TipoObjeto.EnergyStream Then
                            cp = obj.GraphicObject.InputConnectors(0)
                            If Not cp.IsAttached And Not refobj.EnergyConnector.IsAttached And Not conables.Contains(obj.GraphicObject.Tag) Then conables.Add(obj.GraphicObject.Tag)
                        End If
                    End If
                End If
            End If
        Next

        Return conables

    End Function

    Function ReturnDownstreamDisconnectables(ByVal objTag As String) As ArrayList

        Dim obj As GraphicObject = FormFlowsheet.SearchSurfaceObjectsByTag(objTag, Me.FlowsheetDesignSurface)

        Dim conables As New ArrayList

        If Not obj Is Nothing Then

            Dim cp As ConnectionPoint
            For Each cp In obj.OutputConnectors
                If cp.AttachedConnector.AttachedTo.TipoObjeto <> TipoObjeto.AbsorptionColumn And cp.AttachedConnector.AttachedTo.TipoObjeto <> TipoObjeto.DistillationColumn And _
                cp.AttachedConnector.AttachedTo.TipoObjeto <> TipoObjeto.RefluxedAbsorber And cp.AttachedConnector.AttachedTo.TipoObjeto <> TipoObjeto.ReboiledAbsorber Then
                    If cp.IsAttached = True And Not conables.Contains(cp.AttachedConnector.AttachedTo.Tag) Then conables.Add(cp.AttachedConnector.AttachedTo.Tag)
                End If
            Next
        End If

        Return conables

    End Function

    Function ReturnUpstreamDisconnectables(ByVal objTag As String) As ArrayList

        Dim obj As GraphicObject = FormFlowsheet.SearchSurfaceObjectsByTag(objTag, Me.FlowsheetDesignSurface)

        Dim conables As New ArrayList

        If Not obj Is Nothing Then

            Dim cp As ConnectionPoint
            For Each cp In obj.InputConnectors
                If cp.AttachedConnector.AttachedTo.TipoObjeto <> TipoObjeto.AbsorptionColumn And cp.AttachedConnector.AttachedTo.TipoObjeto <> TipoObjeto.DistillationColumn And _
                cp.AttachedConnector.AttachedTo.TipoObjeto <> TipoObjeto.RefluxedAbsorber And cp.AttachedConnector.AttachedTo.TipoObjeto <> TipoObjeto.ReboiledAbsorber Then
                    If cp.IsAttached = True And Not conables.Contains(cp.AttachedConnector.AttachedFrom.Tag) Then conables.Add(cp.AttachedConnector.AttachedFrom.Tag)
                End If
            Next

        End If

        Return conables

    End Function

   

    Private Sub ExcluirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirToolStripMenuItem.Click
        Call Me.ChildParent.DeleteSelectedObject(sender, e)
    End Sub

    Private Sub HorizontalmenteToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalmenteToolStripMenuItem.Click
        If Me.HorizontalmenteToolStripMenuItem.Checked Then
            Me.FlowsheetDesignSurface.SelectedObject.FlippedH = True
        Else
            Me.FlowsheetDesignSurface.SelectedObject.FlippedH = False
        End If
        Me.FlowsheetDesignSurface.Invalidate()
    End Sub

    Public Function AddObjectToSurface(ByVal type As TipoObjeto, ByVal x As Integer, ByVal y As Integer, Optional ByVal tag As String = "") As String

        ChildParent = My.Application.ActiveSimulation

        If ChildParent.Collections.ObjectCounter Is Nothing Then ChildParent.Collections.InitializeCounter()

        Dim gObj As GraphicObject = Nothing
        Dim fillclr As Color = Color.WhiteSmoke
        Dim lineclr As Color = Color.Red
        Dim mpx = x '- SplitContainer1.SplitterDistance
        Dim mpy = y '- ToolStripContainer1.TopToolStripPanel.Height

        Select Case type


            Case TipoObjeto.Tank
                Dim myTank As New TankGraphic(mpx, mpy, 50, 50, 0)
                myTank.LineWidth = 2
                myTank.Fill = True
                myTank.FillColor = fillclr
                myTank.LineColor = lineclr
                myTank.Tag = "TMDPVOL-" & Format(ChildParent.Collections.ObjectCounter("TANK"), "00#")
                ChildParent.Collections.UpdateCounter("TANK")
                If tag <> "" Then myTank.Tag = tag
                gObj = myTank
                gObj.Name = "TQ-" & Guid.NewGuid.ToString
                ChildParent.Collections.TankCollection.Add(gObj.Name, myTank)
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes.Add(gObj.Name, gObj.Tag).Name = gObj.Name
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes(gObj.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
                'OBJETO RELAP
                Dim myCOTK As RELAP.SimulationObjects.UnitOps.Tank = New RELAP.SimulationObjects.UnitOps.Tank(myTank.Name, "Tanque")
                myCOTK.GraphicObject = myTank
                ChildParent.Collections.ObjectCollection.Add(myTank.Name, myCOTK)
                ChildParent.Collections.CLCS_TankCollection.Add(myTank.Name, myCOTK)
            Case TipoObjeto.Cooler
                Dim myCooler As New CoolerGraphic(mpx, mpy, 50, 50, 0)
                myCooler.LineWidth = 2
                myCooler.Fill = True
                myCooler.FillColor = fillclr
                myCooler.LineColor = lineclr
                myCooler.Tag = "SNGLJUN-" & Format(ChildParent.Collections.ObjectCounter("SingleJunction"), "00#")
                ChildParent.Collections.UpdateCounter("SingleJunction")
                If tag <> "" Then myCooler.Tag = tag
                gObj = myCooler
                gObj.Name = "SNGLJUN-" & Guid.NewGuid.ToString
                ChildParent.Collections.CoolerCollection.Add(gObj.Name, myCooler)
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes.Add(gObj.Name, gObj.Tag).Name = gObj.Name
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes(gObj.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
                'OBJETO RELAP
                Dim myCOTK As RELAP.SimulationObjects.UnitOps.cooler = New RELAP.SimulationObjects.UnitOps.cooler(myCooler.Name, "Resfriador")
                myCOTK.GraphicObject = myCooler
                ChildParent.Collections.ObjectCollection.Add(myCooler.Name, myCOTK)
                ChildParent.Collections.CLCS_CoolerCollection.Add(myCooler.Name, myCOTK)
            Case TipoObjeto.Pipe
                Dim myPipe As New PipeGraphic(mpx, mpy, 50, 50, 0)
                myPipe.LineWidth = 2
                myPipe.Fill = True
                myPipe.FillColor = fillclr
                myPipe.LineColor = lineclr
                myPipe.Tag = "PIPE-" & Format(ChildParent.Collections.ObjectCounter("Pipe"), "00#")
                ChildParent.Collections.UpdateCounter("Pipe")
                If tag <> "" Then myPipe.Tag = tag
                gObj = myPipe
                gObj.Name = "PIPE-" & Guid.NewGuid.ToString
                ChildParent.Collections.PipeCollection.Add(gObj.Name, myPipe)
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes.Add(gObj.Name, gObj.Tag).Name = gObj.Name
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes(gObj.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
                'OBJETO RELAP
                Dim myCOTK As RELAP.SimulationObjects.UnitOps.pipe = New RELAP.SimulationObjects.UnitOps.pipe(myPipe.Name, "Pipe")
                myCOTK.GraphicObject = myPipe
                ChildParent.Collections.ObjectCollection.Add(myPipe.Name, myCOTK)
                ChildParent.Collections.CLCS_PipeCollection.Add(myPipe.Name, myCOTK)
            Case TipoObjeto.Valve
                Dim myValve As New ValveGraphic(mpx, mpy, 50, 50, 0)
                myValve.LineWidth = 2
                myValve.Fill = True
                myValve.FillColor = fillclr
                myValve.LineColor = lineclr
                myValve.Tag = "VALVE-" & Format(ChildParent.Collections.ObjectCounter("Valve"), "00#")
                ChildParent.Collections.UpdateCounter("Valve")
                If tag <> "" Then myValve.Tag = tag
                gObj = myValve
                gObj.Name = "VALVE-" & Guid.NewGuid.ToString
                ChildParent.Collections.ValveCollection.Add(gObj.Name, myValve)
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes.Add(gObj.Name, gObj.Tag).Name = gObj.Name
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes(gObj.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
                'OBJETO RELAP
                Dim myCOTK As RELAP.SimulationObjects.UnitOps.Valve = New RELAP.SimulationObjects.UnitOps.Valve(myValve.Name, "Valve")
                myCOTK.GraphicObject = myValve
                ChildParent.Collections.ObjectCollection.Add(myValve.Name, myCOTK)
                ChildParent.Collections.CLCS_ValveCollection.Add(myValve.Name, myCOTK)
            Case TipoObjeto.FuelRod
                Dim myTank As New FuelRodGraphic(mpx, mpy, 50, 50, 0)
                myTank.LineWidth = 2
                myTank.Fill = True
                myTank.FillColor = fillclr
                myTank.LineColor = lineclr
                myTank.Tag = "FUELROD-" & Format(ChildParent.Collections.ObjectCounter("FuelRod"), "00#")
                ChildParent.Collections.UpdateCounter("FuelRod")
                If tag <> "" Then myTank.Tag = tag
                gObj = myTank
                gObj.Name = "TQ-" & Guid.NewGuid.ToString
                ChildParent.Collections.FuelRodCollection.Add(gObj.Name, myTank)
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes.Add(gObj.Name, gObj.Tag).Name = gObj.Name
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes(gObj.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
                'OBJETO RELAP
                Dim myCOTK As RELAP.SimulationObjects.UnitOps.FuelRod = New RELAP.SimulationObjects.UnitOps.FuelRod(myTank.Name, "FuelRod")
                myCOTK.GraphicObject = myTank
                ChildParent.Collections.ObjectCollection.Add(myTank.Name, myCOTK)
                ChildParent.Collections.CLCS_FuelRodCollection.Add(myTank.Name, myCOTK)
            Case TipoObjeto.Simulator
                Dim myTank As New SimulatorGraphic(mpx, mpy, 50, 50, 0)
                myTank.LineWidth = 2
                myTank.Fill = True
                myTank.FillColor = fillclr
                myTank.LineColor = lineclr
                myTank.Tag = "Simulator-" & Format(ChildParent.Collections.ObjectCounter("Simulator"), "00#")
                ChildParent.Collections.UpdateCounter("Simulator")
                If tag <> "" Then myTank.Tag = tag
                gObj = myTank
                gObj.Name = "TQ-" & Guid.NewGuid.ToString
                ChildParent.Collections.SimulatorCollection.Add(gObj.Name, myTank)
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes.Add(gObj.Name, gObj.Tag).Name = gObj.Name
                'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes(gObj.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
                'OBJETO RELAP
                Dim myCOTK As RELAP.SimulationObjects.UnitOps.Simulator = New RELAP.SimulationObjects.UnitOps.Simulator(myTank.Name, "Simulator")
                myCOTK.GraphicObject = myTank
                ChildParent.Collections.ObjectCollection.Add(myTank.Name, myCOTK)
                ChildParent.Collections.CLCS_SimulatorCollection.Add(myTank.Name, myCOTK)



        End Select
        'ChildParent.FormObjList.TreeViewObj.Refresh()

        If Not gObj Is Nothing Then
            Me.FlowsheetDesignSurface.drawingObjects.Add(gObj)
            Me.FlowsheetDesignSurface.Invalidate()
            Application.DoEvents()
            Dim arrays(ChildParent.Collections.ObjectCollection.Count - 1) As String
            '   Dim aNode, aNode2 As TreeNode
            Dim i As Integer = 0
            'For Each aNode In ChildParent.FormObjList.TreeViewObj.Nodes
            '    For Each aNode2 In aNode.Nodes
            '        arrays(i) = aNode2.Text
            '        i += 1
            '    Next
            'Next
            'ChildParent.FormObjList.ACSC.Clear()
            'ChildParent.FormObjList.ACSC.AddRange(arrays)
            'ChildParent.FormObjList.TBSearch.AutoCompleteCustomSource = ChildParent.FormObjList.ACSC
        End If

        Me.FlowsheetDesignSurface.Cursor = Cursors.Arrow

        Return gObj.Name

    End Function

    Private Sub FlowsheetDesignSurface_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles FlowsheetDesignSurface.DragEnter
        Dim i As Integer
        For i = 0 To e.Data.GetFormats().Length - 1
            If e.Data.GetFormats()(i).Equals _
               ("System.Windows.Forms.DataGridViewRow") Then
                'The data from the drag source is moved to the target.
                e.Effect = DragDropEffects.Copy
            End If
        Next
    End Sub

    Private Sub FlowsheetDesignSurface_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles FlowsheetDesignSurface.DragDrop
        If e.Effect = DragDropEffects.Copy Then
            Dim obj As DataGridViewRow = e.Data.GetData("System.Windows.Forms.DataGridViewRow")
            Dim tobj As TipoObjeto = TipoObjeto.Nenhum
            Dim p As Point = Me.FlowsheetDesignSurface.PointToClient(New Point(e.X, e.Y))
            Dim mousePT As Point = ChildParent.gscTogoc(p.X, p.Y)
            Dim mpx = mousePT.X
            Dim mpy = mousePT.Y
            Dim text As String = ChildParent.FormObjListView.DataGridView1.Rows(obj.Index).Cells(0).Value.ToString.TrimEnd(" ")
            Select Case text
                Case "FuelRod"
                    tobj = TipoObjeto.FuelRod
                Case "Simulator"
                    tobj = TipoObjeto.Simulator
                Case "Ajuste"
                    tobj = TipoObjeto.OT_Ajuste
                Case "Especificao"
                    tobj = TipoObjeto.OT_Especificacao
                Case "Reciclo"
                    tobj = TipoObjeto.OT_Reciclo
                Case "EnergyRecycle"
                    tobj = TipoObjeto.OT_EnergyRecycle
                Case "Misturador"
                    tobj = TipoObjeto.NodeIn
                Case "Divisor"
                    tobj = TipoObjeto.NodeOut
                Case "Bomba"
                    tobj = TipoObjeto.Pump
                Case "Tanque"
                    tobj = TipoObjeto.Tank
                Case "VasoSeparadorGL"
                    tobj = TipoObjeto.Vessel
                Case "CorrentedeMatria"
                    tobj = TipoObjeto.MaterialStream
                Case "Correntedeenergia"
                    tobj = TipoObjeto.EnergyStream
                Case "CompressorAdiabtico"
                    tobj = TipoObjeto.Compressor
                Case "TurbinaAdiabtica"
                    tobj = TipoObjeto.Expander
                Case "Resfriador"
                    tobj = TipoObjeto.Cooler
                Case "Aquecedor"
                    tobj = TipoObjeto.Heater
                Case "Tubulao"
                    tobj = TipoObjeto.Pipe
                Case "Vlvula"
                    tobj = TipoObjeto.Valve
                Case "ReatorConversao"
                    tobj = TipoObjeto.RCT_Conversion
                Case "ReatorEquilibrio"
                    tobj = TipoObjeto.RCT_Equilibrium
                Case "ReatorGibbs"
                    tobj = TipoObjeto.RCT_Gibbs
                Case "ReatorCSTR"
                    tobj = TipoObjeto.RCT_CSTR
                Case "ReatorPFR"
                    tobj = TipoObjeto.RCT_PFR
                Case "HeatExchanger"
                    tobj = TipoObjeto.HeatExchanger
                Case "ShortcutColumn"
                    tobj = TipoObjeto.ShortcutColumn
                Case "DistillationColumn"
                    tobj = TipoObjeto.DistillationColumn
                Case "AbsorptionColumn"
                    tobj = TipoObjeto.AbsorptionColumn
                Case "ReboiledAbsorber"
                    tobj = TipoObjeto.ReboiledAbsorber
                Case "RefluxedAbsorber"
                    tobj = TipoObjeto.RefluxedAbsorber
                Case "ComponentSeparator"
                    tobj = TipoObjeto.ComponentSeparator
                Case "OrificePlate"
                    tobj = TipoObjeto.OrificePlate
                Case "CustomUnitOp"
                    tobj = TipoObjeto.CustomUO
                Case "CapeOpenUnitOperation"
                    tobj = TipoObjeto.CapeOpenUO
            End Select

            AddObjectToSurface(tobj, mpx, mpy)
        End If
    End Sub

    Public calcstart As Date

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Dim ts As TimeSpan = Date.Now - calcstart

        '  Me.LabelTime.Text = Format(ts.Hours, "0#") & ":" & Format(ts.Minutes, "0#") & ":" & Format(ts.Seconds, "0#") & "." & Format(ts.Milliseconds, "####")

    End Sub

    'Private Sub RecalcularToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecalcularToolStripMenuItem.Click

    '    ChildParent = My.Application.ActiveSimulation
    '    Dim obj As SimulationObjects_BaseClass = ChildParent.Collections.ObjectCollection(Me.FlowsheetDesignSurface.SelectedObject.Name)
    '    CalculateObject(ChildParent, obj.Nome)

    'End Sub

    Private Sub FlowsheetDesignSurface_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlowsheetDesignSurface.MouseEnter

    End Sub

    'Private Sub EditCompTSMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCompTSMI.Click

    '    If Me.FlowsheetDesignSurface.SelectedObject.TipoObjeto = TipoObjeto.MaterialStream Then

    '        Dim mystr As RELAP.SimulationObjects.Streams.MaterialStream = ChildParent.Collections.CLCS_MaterialStreamCollection(ChildParent.FormSurface.FlowsheetDesignSurface.SelectedObject.Name)

    '        If Not mystr.GraphicObject.InputConnectors(0).IsAttached Then

    '            Dim selectionControl As New CompositionEditorForm
    '            selectionControl.Text = mystr.GraphicObject.Tag & RELAP.App.GetLocalString("EditComp")
    '            selectionControl.Componentes = mystr.Fases(0).Componentes

    '            selectionControl.ShowDialog(Me)

    '            mystr.Fases(0).Componentes = selectionControl.Componentes

    '            selectionControl.Dispose()
    '            selectionControl = Nothing

    '            Application.DoEvents()
    '            CalculateMaterialStream(ChildParent, mystr)
    '            Call ChildParent.FormSurface.UpdateSelectedObject()
    '            Call ChildParent.FormSurface.FlowsheetDesignSurface.Invalidate()
    '            Application.DoEvents()
    '            ProcessCalculationQueue(ChildParent)

    '        Else

    '            VDialog.Show("The composition of this Material Stream is not editable.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        End If

    '    End If

    'End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        DrawToBitmapScaled(2)
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        DrawToBitmapScaled(1)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        DrawToBitmapScaled(0.5)
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        DrawToBitmapScaled(3)
    End Sub

    Sub DrawToBitmapScaled(ByVal scale As Double)

        Dim rect As Rectangle = New Rectangle(0, 0, scale * (Me.FlowsheetDesignSurface.Width - 14), scale * (Me.FlowsheetDesignSurface.Height - 14))
        Dim img As Image = New Bitmap(rect.Width, rect.Height)
        Dim g As Graphics = Graphics.FromImage(img)

        Try
            g.SmoothingMode = SmoothingMode.AntiAlias
            'get the dpi settings of the graphics context,
            'for example; 96dpi on screen, 600dpi for the printer
            'used to adjust grid and margin sizing.
            Me.FlowsheetDesignSurface.m_HorizRes = g.DpiX
            Me.FlowsheetDesignSurface.m_VertRes = g.DpiY

            Me.FlowsheetDesignSurface.DrawGrid(g)

            'handle the possibility that the viewport is scrolled,
            'adjust my origin coordintates to compensate
            Dim pt As Point = Me.FlowsheetDesignSurface.AutoScrollPosition
            g.TranslateTransform(pt.X * scale, pt.Y * scale)

            'draw the actual objects onto the page, on top of the grid

            For Each gr As GraphicObject In Me.FlowsheetDesignSurface.SelectedObjects.Values
                Me.FlowsheetDesignSurface.drawingObjects.DrawSelectedObject(g, gr, scale * Me.FlowsheetDesignSurface.Zoom)
            Next

            With Me.FlowsheetDesignSurface.drawingObjects
                'pass the graphics resolution onto the objects
                'so that images and other objects can be sized
                'correct taking the dpi into consideration.
                .HorizontalResolution = g.DpiX
                .VerticalResolution = g.DpiY
                'doesn't really draw the selected object, but instead the
                'selection indicator, a dotted outline around the selected object
                .DrawObjects(g, scale * Me.FlowsheetDesignSurface.Zoom)
                If Not Me.FlowsheetDesignSurface.SelectedObject Is Nothing Then
                    If Not Me.FlowsheetDesignSurface.SelectedObjects.ContainsKey(Me.FlowsheetDesignSurface.SelectedObject.Name) Then
                        .DrawSelectedObject(g, Me.FlowsheetDesignSurface.SelectedObject, scale * Me.FlowsheetDesignSurface.Zoom)
                    End If
                End If
            End With

            Clipboard.SetImage(img)

            '  Me.ChildParent.WriteToLog("Image created and sent to clipboard sucessfully.", Color.Blue, RELAP.FormClasses.TipoAviso.Informacao)

        Catch ex As Exception

            '  Me.ChildParent.WriteToLog("Error capturing flowsheet snapshot: " & ex.ToString, Color.Red, RELAP.FormClasses.TipoAviso.Erro)

        Finally

            img.Dispose()
            g.Dispose()

        End Try


    End Sub


End Class

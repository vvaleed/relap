'    Copyright 2008-2011 Daniel Wagner O. de Medeiros
'
'    This file is part of RELAP.
'
'    RELAP is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    RELAP is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with RELAP.  If not, see <http://www.gnu.org/licenses/>.

Imports Microsoft.Msdn.Samples.GraphicObjects
Imports System.Collections.Generic
Imports System.ComponentModel
Imports PropertyGridEx
Imports WeifenLuo.WinFormsUI
Imports System.Drawing
Imports LukeSw.Windows.Forms
Imports System.IO
'Imports RELAP.RELAP.Flowsheet.FlowsheetSolver
'Imports RELAP.RELAP.SimulationObjects.PropertyPackages
Imports Microsoft.Win32
'Imports RELAP.RELAP.SimulationObjects
Imports RELAP.RELAP.ClassesBasicasTermodinamica
Imports System.Runtime.Serialization.Formatters.Binary
Imports RELAP.RELAP.FormClasses

<System.Serializable()> Public Class FormFlowsheet

    Inherits System.Windows.Forms.Form

    'CAPE-OPEN PME/COSE Interfaces
    'Implements CapeOpen.ICapeCOSEUtilities, CapeOpen.ICapeMaterialTemplateSystem, CapeOpen.ICapeDiagnostic,  _
    '            CapeOpen.ICapeFlowsheetMonitoring, CapeOpen.ICapeSimulationContext, CapeOpen.ICapeIdentification

#Region "    Variable Declarations "

    'Public FrmStSim1 As New FormStSim
    'Public FrmPCBulk As New FormPCBulk
    'Public FrmHypGen As New FormHypGen
    'Public FrmReport As New FormReportConfig

    Public m_IsLoadedFromFile As Boolean = False
    Public m_overrideCloseQuestion As Boolean = False
    Public m_simultadjustsolverenabled As Boolean = True
    Public ComponentType As String
    Public FromComponent As String
    Public ToComponent As String
    Public FormSurface As New frmSurface
    Public FormProps As New frmProps
    Public FormControlSystem As New frmControlSystem
    Public FormInitialSettings As New frmInitialSettings
    Public FormMaterials As New frmMaterials
    Public FormPlotReqest As New frmPlotRequest
    Public FormMinorEditRequests As New frmMinorEditRequests
    Public FormTrips As New frmTrips
    'Public FormEBT As New frmEBT
    'Public FormObjList As New frmObjList
    'Public FormLog As New frmLog
    'Public FormMatList As New frmMatList
    Public FormObjListView As New frmObjListView
    'Public FormSpreadsheet As New SpreadsheetForm

    'Public FormOutput As New frmOutput
    'Public FormQueue As New frmQueue
    'Public FormCOReports As New frmCOReports
    'Public FormWatch As New frmWatch

    'Public FormCritPt As New FrmCritpt
    'Public FormStabAn As New FrmStabAn
    'Public FormHid As New FormHYD
    'Public FormPE As New FormPhEnv
    'Public FormBE As New FormBinEnv
    'Public FormPSVS As New FrmPsvSize
    'Public FormVS As New FrmDAVP
    'Public FormColdP As New FrmColdProperties

    'Public FormSensAnalysis0 As New FormSensAnalysis
    'Public FormOptimization0 As New FormOptimization

    'Public FormCL As FormCLM

    Public WithEvents Options As New RELAP.FormClasses.ClsFormOptions

    Public Conversor As New RELAP.SistemasDeUnidades.Conversor

    Public CalculationQueue As Generic.Queue(Of RELAP.Outros.StatusChangeEventArgs)

    Public FlowsheetStates As Dictionary(Of Date, FlowsheetState)

    Public CheckedToolstripButton As ToolStripButton
    Public ClickedToolStripMenuItem As ToolStripMenuItem
    Public InsertingObjectToPFD As Boolean = False

    Public prevcolor1, prevcolor2 As Color

    Public Collections As New RELAP.FormClasses.ClsObjectCollections

    Public ID As String

#End Region

#Region "    Form Event Handlers "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ID = Guid.NewGuid().ToString

    End Sub

    Private Sub FormChild_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        My.Application.ActiveSimulation = Me
       

    End Sub

    Private Sub FormChild2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        'dispose objects
        For Each obj As SimulationObjects_BaseClass In Me.Collections.ObjectCollection.Values
            If obj.disposedValue = False Then obj.Dispose()
        Next

        Dim path As String = My.Settings.BackupFolder + System.IO.Path.DirectorySeparatorChar + Me.Options.BackupFileName

        If My.Settings.BackupFiles.Contains(path) Then
            My.Settings.BackupFiles.Remove(path)
            My.Settings.Save()
            Try
                If File.Exists(path) Then File.Delete(path)
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            End Try
        End If

        Dim cnt As Integer = FormMain.MdiChildren.Length

        If cnt = 0 Then

            FormMain.ToolStripButton1.Enabled = False
            FormMain.SaveAllToolStripButton.Enabled = False
            FormMain.SaveToolStripButton.Enabled = False
            FormMain.SaveToolStripMenuItem.Enabled = False
            FormMain.SaveAllToolStripMenuItem.Enabled = False
            FormMain.SaveAsToolStripMenuItem.Enabled = False
            FormMain.ToolStripButton1.Enabled = False

        Else

            FormMain.ToolStripButton1.Enabled = True
            FormMain.SaveAllToolStripButton.Enabled = True
            FormMain.SaveToolStripButton.Enabled = True
            FormMain.SaveToolStripMenuItem.Enabled = True
            FormMain.SaveAllToolStripMenuItem.Enabled = True
            FormMain.SaveAsToolStripMenuItem.Enabled = True
            FormMain.ToolStripButton1.Enabled = True

        End If

    End Sub

    Private Sub FormChild2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If FormMain.SairDiretoERRO Then Exit Sub

        If Me.m_overrideCloseQuestion = False Then

            Dim x = VDialog.Show(RELAP.App.GetLocalString("Desejasalvarasaltera"), RELAP.App.GetLocalString("Fechando") & " " & Me.Options.SimNome & " (" & System.IO.Path.GetFileName(Me.Options.FilePath) & ") ...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            If x = MsgBoxResult.Yes Then

                Call FormMain.SaveFileDialog_NoBG()
                Me.m_overrideCloseQuestion = True
                Me.Close()

            ElseIf x = MsgBoxResult.Cancel Then

                e.Cancel = True

            Else

                Me.m_overrideCloseQuestion = True
                Me.Close()

            End If

        End If

    End Sub

  

    Private Sub FormChild_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim rand As New Random
        Dim str As String = rand.Next(10000000, 99999999)

        Me.Options.BackupFileName = str & ".dwbcs"

        Me.CalculationQueue = New Generic.Queue(Of RELAP.Outros.StatusChangeEventArgs)

        Me.StatusBarTextProvider1.InstanceStatusBar = My.Forms.FormMain.ToolStripStatusLabel1

        Me.TSTBZoom.Text = Format(Me.FormSurface.FlowsheetDesignSurface.Zoom, "#%")
      

        If Not Me.m_IsLoadedFromFile Then

            Me.Options.SimAutor = My.User.Name

            'For Each pp As RELAP.SimulationObjects.PropertyPackages.PropertyPackage In Me.Options.PropertyPackages.Values
            '    If pp.ConfigForm Is Nothing Then pp.ReconfigureConfigForm()
            'Next

            Me.Options.NotSelectedComponents = New Dictionary(Of String, RELAP.ClassesBasicasTermodinamica.ConstantProperties)

            Dim tmpc As RELAP.ClassesBasicasTermodinamica.ConstantProperties
            For Each tmpc In FormMain.AvailableComponents.Values
                Dim newc As New RELAP.ClassesBasicasTermodinamica.ConstantProperties
                newc = tmpc
                Me.Options.NotSelectedComponents.Add(tmpc.Name, newc)
            Next

            Me.FormProps.PGEx1.ToolbarVisible = False

            Dim Frm = ParentForm

            ' Set DockPanel properties
            dckPanel.ActiveAutoHideContent = Nothing
            dckPanel.Parent = Me

            'FormStatus.Show(dckPanel)
            '  FormLog.Show(dckPanel)
            FormObjListView.Show(dckPanel)

            '  FormObjList.Show(dckPanel)
            FormProps.Show(dckPanel)
            '  FormMatList.Show(dckPanel)
            '  FormSpreadsheet.Show(dckPanel)
            FormSurface.Show(dckPanel)
            FormInitialSettings.Show(dckPanel)
            FormMaterials.Show(dckPanel)
            FormTrips.Show(dckPanel)
            FormPlotReqest.Show(dckPanel)
            FormMinorEditRequests.Show(dckPanel)
            FormControlSystem.Show(dckPanel)
            Try
                FormObjListView.DockState = Docking.DockState.DockRight
                FormInitialSettings.DockState = Docking.DockState.DockLeftAutoHide
                FormMaterials.DockState = Docking.DockState.DockLeftAutoHide
                FormPlotReqest.DockState = Docking.DockState.DockBottomAutoHide
                FormMinorEditRequests.DockState = Docking.DockState.DockBottomAutoHide
                FormControlSystem.DockState = Docking.DockState.DockBottomAutoHide
                FormTrips.DockState = Docking.DockState.DockBottomAutoHide
                'FormWatch.DockState = Docking.DockState.DockRight
                'FormWatch.DockState = Docking.DockState.DockBottom
                'FormCOReports.DockState = Docking.DockState.DockLeft
                'FormCOReports.DockState = Docking.DockState.DockBottom
                'FormOutput.DockState = Docking.DockState.DockLeft
                'FormOutput.DockState = Docking.DockState.DockBottom
                'FormQueue.DockState = Docking.DockState.DockRight
                'FormQueue.DockState = Docking.DockState.DockBottom
            Catch ex As Exception

            End Try
            
            dckPanel.BringToFront()

            dckPanel.UpdateDockWindowZOrder(DockStyle.Fill, True)

            Me.FormSurface.FlowsheetDesignSurface.Zoom = 1
            Me.FormSurface.FlowsheetDesignSurface.VerticalScroll.Maximum = 7000
            Me.FormSurface.FlowsheetDesignSurface.VerticalScroll.Value = 3500
            Me.FormSurface.FlowsheetDesignSurface.HorizontalScroll.Maximum = 10000
            Me.FormSurface.FlowsheetDesignSurface.HorizontalScroll.Value = 5000

            Me.Invalidate()
            Application.DoEvents()
          
        Else

            If Me.Collections.AdjustCollection Is Nothing Then
                Me.Collections.AdjustCollection = New Dictionary(Of String, AdjustGraphic)
                '  Me.Collections.CLCS_AdjustCollection = New Dictionary(Of String, RELAP.SimulationObjects.SpecialOps.Adjust)
                Me.Collections.SpecCollection = New Dictionary(Of String, SpecGraphic)
                '  Me.Collections.CLCS_SpecCollection = New Dictionary(Of String, RELAP.SimulationObjects.SpecialOps.Spec)
                Me.Collections.RecycleCollection = New Dictionary(Of String, RecycleGraphic)
                ' Me.Collections.CLCS_RecycleCollection = New Dictionary(Of String, RELAP.SimulationObjects.SpecialOps.Recycle)
            End If

            '  Dim node, node2 As TreeNode
            'For Each node In Me.FormObjList.TreeViewObj.Nodes
            '    For Each node2 In node.Nodes
            '        node2.ContextMenuStrip = Me.FormObjList.ContextMenuStrip1
            '    Next
            'Next

        End If


        'load plugins
        'CreatePluginsList()
       

    End Sub

    Private Sub FormChild_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim array1(FormMain.AvailableUnitSystems.Count - 1) As String
        FormMain.AvailableUnitSystems.Keys.CopyTo(array1, 0)
      
        ToolStripComboBoxUnitSystem.Items.Clear()
        ToolStripComboBoxUnitSystem.Items.AddRange(array1)
        cboOutputUnits.Items.Clear()
        cboOutputUnits.Items.AddRange(array1)
        If Not Me.m_IsLoadedFromFile Then
            'With Me.FrmStSim1
            '    '.Text = Me.Text & " - Assistente de Configuração"
            '    '.MdiParent = My.Forms.FormParent
            '    .WindowState = FormWindowState.Normal
            '    .StartPosition = FormStartPosition.CenterScreen
            '    .ShowDialog(Me)
            '    'MUST CALL THE DISPOSE METHOD!!!!!!!!!
            'End With
        Else
            ' Dim array1(FormMain.AvailableUnitSystems.Count - 1) As String
            FormMain.AvailableUnitSystems.Keys.CopyTo(array1, 0)
            Me.ToolStripComboBoxUnitSystem.Items.Clear()
            Me.ToolStripComboBoxUnitSystem.Items.AddRange(array1)

            If Me.ToolStripComboBoxUnitSystem.Items.Contains(Me.Options.SelectedUnitSystem.nome) Then
                Me.ToolStripComboBoxUnitSystem.SelectedItem = Me.Options.SelectedUnitSystem.nome
            Else
                If Me.Options.SelectedUnitSystem.nome <> "" Then
                    AddUnitSystem(Me.Options.SelectedUnitSystem)
                Else
                    Me.ToolStripComboBoxUnitSystem.SelectedIndex = 0
                    Me.ToolStripComboBoxUnitSystem.SelectedItem = Me.Options.SelectedUnitSystem.nome
                End If
            End If

           
        End If

        ' Me.FormLog.Grid1.Sort(Me.FormLog.Grid1.Columns(1), ListSortDirection.Descending)
        cboProblemType.SelectedIndex = 0
        cboProblemOption.SelectedIndex = 1
        cboInputCheck.SelectedIndex = 0
        ToolStripComboBoxUnitSystem.SelectedIndex = 1
        cboOutputUnits.SelectedIndex = 0
        Me.WindowState = FormWindowState.Maximized
        My.Application.ActiveSimulation = Me

    End Sub

#End Region

#Region "    Functions "

    Function RET_CN(ByVal index As Integer) As String

        Dim i As Integer = 0
        Dim sub1 As RELAP.ClassesBasicasTermodinamica.ConstantProperties
        For Each sub1 In Me.Options.SelectedComponents.Values
            If index = i Then Return sub1.Name
            i += 1
        Next

        Return Nothing

    End Function

    Function RET_CI(ByVal name As String) As Integer

        Dim i As Integer = 0
        Dim sub1 As RELAP.ClassesBasicasTermodinamica.ConstantProperties
        For Each sub1 In Me.Options.SelectedComponents.Values
            If name = sub1.Name Then Return i
            i += 1
        Next

        Return Nothing

    End Function

    Function RET_NAMES() As ArrayList

        Dim vn As New ArrayList

        Dim sub1 As RELAP.ClassesBasicasTermodinamica.ConstantProperties
        For Each sub1 In Me.Options.SelectedComponents.Values
            vn.Add(sub1.Name)
        Next

        Return vn

    End Function

    Public Sub AddUnitSystem(ByVal su As RELAP.SistemasDeUnidades.Unidades)

        Dim myarraylist As New ArrayList
        If My.Settings.UserUnits <> "" Then

            Dim formatter As New BinaryFormatter()
            Dim bytearray() As Byte
            bytearray = System.Text.Encoding.ASCII.GetBytes(My.Settings.UserUnits)
            formatter = New BinaryFormatter()
            Dim stream As New IO.MemoryStream(bytearray)
            myarraylist = CType(formatter.Deserialize(stream), ArrayList)
            stream.Close()

        End If

        myarraylist.Add(su)
        FormMain.AvailableUnitSystems.Add(su.nome, su)
        ' Me.FrmStSim1.ComboBox2.Items.Add(su.nome)
        Me.ToolStripComboBoxUnitSystem.Items.Add(su.nome)

        Dim bytearray2(100000) As Byte
        Dim stream2 As New IO.MemoryStream(bytearray2)
        Dim formatter2 As New BinaryFormatter()
        formatter2.Serialize(stream2, myarraylist)
        stream2.Close()
        My.Settings.UserUnits = System.Text.Encoding.ASCII.GetString(bytearray2)

    End Sub


    'Public Sub AddComponentsRows(ByRef MaterialStream As RELAP.SimulationObjects.Streams.MaterialStream)
    '    If Me.Options.SelectedComponents.Count = 0 Then
    '        VDialog.Show(RELAP.App.GetLocalString("Nohcomponentesaadici"))
    '    Else
    '        Dim comp As RELAP.ClassesBasicasTermodinamica.ConstantProperties
    '        For Each phase As RELAP.ClassesBasicasTermodinamica.Fase In MaterialStream.Fases.Values
    '            For Each comp In Me.Options.SelectedComponents.Values
    '                With phase
    '                    .Componentes.Add(comp.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp.Name, ""))
    '                    .Componentes(comp.Name).ConstantProperties = comp
    '                End With
    '            Next
    '        Next
    '    End If
    'End Sub

    Public Function FT(ByRef prop As String, ByVal unit As String)
        Return prop & " (" & unit & ")"
    End Function

    Public Enum ID_Type
        Name
        Tag
    End Enum

    Public Shared Function ElementExists(ByVal tipo As ID_Type, ByVal Name As String, ByVal Collection As System.Collections.Generic.Dictionary(Of String, MaterialStreamGraphic)) As Boolean

        Dim value As Boolean = False
        Dim gObj As GraphicObject

        For Each gObj In Collection.Values
            If tipo = ID_Type.Name Then
                If gObj.Name.ToString = Name Then value = True
            Else
                If gObj.Tag.ToString = Name Then value = True
            End If
        Next
        gObj = Nothing

        Return value

    End Function

    Public Shared Function ElementExists_ES(ByVal tipo As ID_Type, ByVal Name As String, ByVal Collection As System.Collections.Generic.Dictionary(Of String, EnergyStreamGraphic)) As Boolean

        Dim value As Boolean = False
        Dim gObj As GraphicObject

        For Each gObj In Collection.Values
            If tipo = ID_Type.Name Then
                If gObj.Name.ToString = Name Then value = True
            Else
                If gObj.Tag.ToString = Name Then value = True
            End If
        Next
        gObj = Nothing

        Return value

    End Function

    Public Shared Function SearchSurfaceObjectsByName(ByVal Name As String, ByVal Surface As Microsoft.Msdn.Samples.DesignSurface.GraphicsSurface) As GraphicObject

        Dim gObj As GraphicObject = Nothing
        Dim gObj2 As GraphicObject = Nothing
        For Each gObj In Surface.drawingObjects
            If gObj.Name.ToString = Name Then
                gObj2 = gObj
                Exit For
            End If
        Next
        Return gObj2

    End Function

    Public Shared Function SearchSurfaceObjectsByTag(ByVal Name As String, ByVal Surface As Microsoft.Msdn.Samples.DesignSurface.GraphicsSurface) As GraphicObject

        Dim gObj As GraphicObject = Nothing
        Dim gObj2 As GraphicObject = Nothing
        For Each gObj In Surface.drawingObjects
            If gObj.Tag.ToString = Name Then
                gObj2 = gObj
                Exit For
            End If
        Next
        Return gObj2

    End Function

    Public Function GetFlowsheetGraphicObject(ByVal tag As String) As GraphicObject

        Dim gObj As GraphicObject = Nothing
        Dim gObj2 As GraphicObject = Nothing
        For Each gObj In Me.FormSurface.FlowsheetDesignSurface.drawingObjects
            If gObj.Tag.ToString = tag Then
                gObj2 = gObj
                Exit For
            End If
        Next

        Return gObj2

    End Function

    Public Function GetFlowsheetSimulationObject(ByVal tag As String) As SimulationObjects_BaseClass

        For Each obj As SimulationObjects_BaseClass In Me.Collections.ObjectCollection.Values
            If obj.GraphicObject.Tag = tag Then
                Return obj
            End If
        Next

        Return Nothing

    End Function

    Public Sub SetLabelText(ByVal labeltag As String, ByVal labeltext As String)
        CType(GetFlowsheetGraphicObject(labeltag), TextGraphic).SetText(labeltext)
    End Sub

    Public Function gscTogoc(ByVal X As Integer, ByVal Y As Integer) As Point
        Dim myNewPoint As Point
        myNewPoint.X = CInt((X - Me.FormSurface.FlowsheetDesignSurface.AutoScrollPosition.X) / Me.FormSurface.FlowsheetDesignSurface.Zoom)
        myNewPoint.Y = CInt((Y - Me.FormSurface.FlowsheetDesignSurface.AutoScrollPosition.Y) / Me.FormSurface.FlowsheetDesignSurface.Zoom)
        Return myNewPoint
    End Function

    'Public Sub WriteToLog(ByVal texto As String, ByVal cor As Color, ByVal tipo As RELAP.FormClasses.TipoAviso)

    '    If Not My.MyApplication.CommandLineMode Then

    '        Dim img As Bitmap
    '        Dim strtipo As String
    '        Select Case tipo
    '            Case RELAP.FormClasses.TipoAviso.Aviso
    '                img = My.Resources._error
    '                strtipo = RELAP.App.GetLocalString("Aviso")
    '            Case RELAP.FormClasses.TipoAviso.Erro
    '                img = My.Resources.exclamation
    '                strtipo = RELAP.App.GetLocalString("Erro")
    '            Case Else
    '                img = My.Resources.information
    '                strtipo = RELAP.App.GetLocalString("Mensagem")
    '        End Select

    '        If Me.FormLog.GridDT.Columns.Count < 4 Then
    '            Me.FormLog.GridDT.Columns.Add("Imagem", GetType(Bitmap))
    '            Me.FormLog.GridDT.Columns.Add("Data")
    '            Me.FormLog.GridDT.Columns.Add("Tipo")
    '            Me.FormLog.GridDT.Columns.Add("Mensagem")
    '            Me.FormLog.GridDT.Columns.Add("Cor", GetType(Color))
    '            Me.FormLog.GridDT.Columns.Add("Indice")
    '        ElseIf Me.FormLog.GridDT.Columns.Count = 4 Then
    '            Me.FormLog.GridDT.Columns.Add("Cor", GetType(Color))
    '            Me.FormLog.GridDT.Columns.Add("Indice")
    '        ElseIf Me.FormLog.GridDT.Columns.Count = 5 Then
    '            Me.FormLog.GridDT.Columns.Add("Indice")
    '        End If
    '        Me.FormLog.GridDT.PrimaryKey = New DataColumn() {Me.FormLog.GridDT.Columns("Indice")}
    '        With Me.FormLog.GridDT.Columns("Indice")
    '            .AutoIncrement = True
    '            .AutoIncrementSeed = 1
    '            .AutoIncrementStep = 1
    '            .Unique = True
    '        End With

    '        Me.FormLog.GridDT.Rows.Add(New Object() {img, Date.Now, strtipo, texto, cor, Me.FormLog.GridDT.Rows.Count})
    '        'Me.FormLog.Grid1.Rows.Add(New Object() {img, Date.Now, strtipo, texto})

    '    Else

    '        'command line mode
    '        'MsgBox(texto)

    '        If Not Me.FormCL Is Nothing Then
    '            Me.FormCL.LBLogMsg.Items.Insert(0, Date.Now.ToString & " " & texto)
    '        End If

    '    End If

    'End Sub

    'Public Sub WriteMessage(ByVal message As String)
    '    WriteToLog(message, Color.Black, RELAP.FormClasses.TipoAviso.Informacao)
    'End Sub

    Public Sub UpdateStatusLabel(ByVal message As String)
        'Me.FormSurface.LabelCalculator.Text = message
    End Sub

    Public Sub CheckCollections()

        'Creates all the graphic collections.
        If Collections.SubSystemCollection Is Nothing Then Collections.SubSystemCollection = New Dictionary(Of String, SubSystemGraphic)
        If Collections.MixerCollection Is Nothing Then Collections.MixerCollection = New Dictionary(Of String, NodeInGraphic)
        If Collections.SplitterCollection Is Nothing Then Collections.SplitterCollection = New Dictionary(Of String, NodeOutGraphic)
        If Collections.MaterialStreamCollection Is Nothing Then Collections.MaterialStreamCollection = New Dictionary(Of String, MaterialStreamGraphic)
        If Collections.EnergyStreamCollection Is Nothing Then Collections.EnergyStreamCollection = New Dictionary(Of String, EnergyStreamGraphic)
        If Collections.PumpCollection Is Nothing Then Collections.PumpCollection = New Dictionary(Of String, PumpGraphic)
        If Collections.SeparatorCollection Is Nothing Then Collections.SeparatorCollection = New Dictionary(Of String, VesselGraphic)
        If Collections.CompressorCollection Is Nothing Then Collections.CompressorCollection = New Dictionary(Of String, CompressorGraphic)
        If Collections.PipeCollection Is Nothing Then Collections.PipeCollection = New Dictionary(Of String, PipeGraphic)
        If Collections.BranchCollection Is Nothing Then Collections.BranchCollection = New Dictionary(Of String, BranchGraphic)
        If Collections.ValveCollection Is Nothing Then Collections.ValveCollection = New Dictionary(Of String, ValveGraphic)
        If Collections.SingleVolumeCollection Is Nothing Then Collections.SingleVolumeCollection = New Dictionary(Of String, SingleVolumeGraphic)
        If Collections.SingleJunctionCollection Is Nothing Then Collections.SingleJunctionCollection = New Dictionary(Of String, SingleJunctionGraphic)
        If Collections.TimeDependentJunctionCollection Is Nothing Then Collections.TimeDependentJunctionCollection = New Dictionary(Of String, TimeDependentJunctionGraphic)
        If Collections.HeaterCollection Is Nothing Then Collections.HeaterCollection = New Dictionary(Of String, HeaterGraphic)
        If Collections.TankCollection Is Nothing Then Collections.TankCollection = New Dictionary(Of String, TankGraphic)
        If Collections.ConnectorCollection Is Nothing Then Collections.ConnectorCollection = New Dictionary(Of String, ConnectorGraphic)
        If Collections.TPSeparatorCollection Is Nothing Then Collections.TPSeparatorCollection = New Dictionary(Of String, TPVesselGraphic)
        If Collections.TurbineCollection Is Nothing Then Collections.TurbineCollection = New Dictionary(Of String, TurbineGraphic)
        If Collections.MixerENCollection Is Nothing Then Collections.MixerENCollection = New Dictionary(Of String, NodeEnGraphic)
        If Collections.AdjustCollection Is Nothing Then Collections.AdjustCollection = New Dictionary(Of String, AdjustGraphic)
        If Collections.SpecCollection Is Nothing Then Collections.SpecCollection = New Dictionary(Of String, SpecGraphic)
        If Collections.RecycleCollection Is Nothing Then Collections.RecycleCollection = New Dictionary(Of String, RecycleGraphic)
        If Collections.ReactorConversionCollection Is Nothing Then Collections.ReactorConversionCollection = New Dictionary(Of String, ReactorConversionGraphic)
        If Collections.ReactorEquilibriumCollection Is Nothing Then Collections.ReactorEquilibriumCollection = New Dictionary(Of String, ReactorEquilibriumGraphic)
        If Collections.ReactorGibbsCollection Is Nothing Then Collections.ReactorGibbsCollection = New Dictionary(Of String, ReactorGibbsGraphic)
        If Collections.ReactorCSTRCollection Is Nothing Then Collections.ReactorCSTRCollection = New Dictionary(Of String, ReactorCSTRGraphic)
        If Collections.ReactorPFRCollection Is Nothing Then Collections.ReactorPFRCollection = New Dictionary(Of String, ReactorPFRGraphic)
        If Collections.HeatStructureCollection Is Nothing Then Collections.HeatStructureCollection = New Dictionary(Of String, HeatStructureGraphic)
        If Collections.ShortcutColumnCollection Is Nothing Then Collections.ShortcutColumnCollection = New Dictionary(Of String, ShorcutColumnGraphic)
        If Collections.DistillationColumnCollection Is Nothing Then Collections.DistillationColumnCollection = New Dictionary(Of String, DistillationColumnGraphic)
        If Collections.AbsorptionColumnCollection Is Nothing Then Collections.AbsorptionColumnCollection = New Dictionary(Of String, AbsorptionColumnGraphic)
        If Collections.RefluxedAbsorberCollection Is Nothing Then Collections.RefluxedAbsorberCollection = New Dictionary(Of String, RefluxedAbsorberGraphic)
        If Collections.ReboiledAbsorberCollection Is Nothing Then Collections.ReboiledAbsorberCollection = New Dictionary(Of String, ReboiledAbsorberGraphic)
        If Collections.EnergyRecycleCollection Is Nothing Then Collections.EnergyRecycleCollection = New Dictionary(Of String, EnergyRecycleGraphic)
        If Collections.ComponentSeparatorCollection Is Nothing Then Collections.ComponentSeparatorCollection = New Dictionary(Of String, ComponentSeparatorGraphic)
        If Collections.OrificePlateCollection Is Nothing Then Collections.OrificePlateCollection = New Dictionary(Of String, OrificePlateGraphic)
        If Collections.CustomUOCollection Is Nothing Then Collections.CustomUOCollection = New Dictionary(Of String, CustomUOGraphic)

        If Collections.ObjectCollection Is Nothing Then Collections.ObjectCollection = New Dictionary(Of String, SimulationObjects_BaseClass)

        'Creates all the actual unit operations collections.

    End Sub

#End Region

#Region "    Click Event Handlers "

    Private Sub InserObjectTSMIClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles _
    TSMIAdjust.Click, TSMIColAbs.Click, TSMIColAbsCond.Click, TSMIColAbsReb.Click, TSMIColDist.Click, _
     TSMIColShortcut.Click, TSMIComponentSeparator.Click, TSMICompressor.Click, TSMICooler.Click, _
     TSMIEnergyRecycle.Click, TSMIEnergyStream.Click, TSMIExpander.Click, TSMIHeater.Click, _
     TSMIHeatStructure.Click, TSMIMaterialStream.Click, TSMIMixer.Click, TSMIOrificePlate.Click, _
     TSMIPipe.Click, TSMIPump.Click, TSMIReactorConv.Click, TSMIReactorCSTR.Click, TSMIReactorEquilibrium.Click, _
     TSMIReactorGibbs.Click, TSMIReactorPFR.Click, TSMIRecycle.Click, TSMISeparator.Click, _
     TSMISpecification.Click, TSMISplitter.Click, TSMITank.Click, TSMIValve.Click, TSMICUO.Click, TSMICOUO.Click

        Me.InsertingObjectToPFD = True
        Me.FormSurface.FlowsheetDesignSurface.Cursor = Cursors.Hand

        Me.ClickedToolStripMenuItem = sender

    End Sub

    Private Sub InsertObjectButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Not Me.CheckedToolstripButton Is Nothing Then
            Try
                Me.CheckedToolstripButton.Checked = False
            Catch ex As Exception

            End Try
        End If

        Me.CheckedToolstripButton = sender

        If Me.CheckedToolstripButton.Name = "TSBSelect" Then
            Me.InsertingObjectToPFD = False
            Me.FormSurface.FlowsheetDesignSurface.Cursor = Cursors.Default
        ElseIf Me.CheckedToolstripButton.Checked = True Then
            Me.InsertingObjectToPFD = True
            Me.FormSurface.FlowsheetDesignSurface.Cursor = Cursors.Hand
        Else
            Me.InsertingObjectToPFD = False
            Me.FormSurface.FlowsheetDesignSurface.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub ToolStripButton6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Me.FormSurface.pageSetup.ShowDialog()
        Me.FormSurface.SetupGraphicsSurface()
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Me.FormSurface.PreviewDialog.ShowDialog()
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        Me.FormSurface.setupPrint.ShowDialog()
    End Sub

    Private Sub TSBTexto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBTexto.Click
        Dim myTextObject As New TextGraphic(-Me.FormSurface.FlowsheetDesignSurface.AutoScrollPosition.X + 30, _
            -Me.FormSurface.FlowsheetDesignSurface.AutoScrollPosition.Y + 30, _
            RELAP.App.GetLocalString("caixa_de_texto"), _
            New Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel, 0, False), _
            Color.Black)
        Dim gObj As GraphicObject = Nothing
        gObj = myTextObject
        gObj.Tag = "LABEL-" & Guid.NewGuid.ToString
        gObj.AutoSize = True
        gObj.TipoObjeto = TipoObjeto.GO_Texto
        Me.FormSurface.FlowsheetDesignSurface.drawingObjects.Add(gObj)
        Me.FormSurface.FlowsheetDesignSurface.Invalidate()

    End Sub

    Private Sub ToolStripButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton19.Click
        Dim myMasterTable As New RELAP.GraphicObjects.MasterTableGraphic(-Me.FormSurface.FlowsheetDesignSurface.AutoScrollPosition.X + 30, _
           -Me.FormSurface.FlowsheetDesignSurface.AutoScrollPosition.Y + 30)
        Dim gObj As GraphicObject = Nothing
        gObj = myMasterTable
        gObj.Tag = "MASTERTABLE-" & Guid.NewGuid.ToString
        gObj.AutoSize = True
        gObj.TipoObjeto = TipoObjeto.GO_MasterTable
        Me.FormSurface.FlowsheetDesignSurface.drawingObjects.Add(gObj)
        Me.FormSurface.FlowsheetDesignSurface.Invalidate()
    End Sub

    Private Sub TSBtabela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBtabela.Click
        With Me.OpenFileName
            .CheckFileExists = True
            .CheckPathExists = True
            .Title = RELAP.App.GetLocalString("Adicionarfigura")
            .Filter = "Images|*.bmp;*.jpg;*.png;*.gif"
            .AddExtension = True
            .Multiselect = False
            .RestoreDirectory = True
            Dim res As DialogResult = .ShowDialog
            If res = Windows.Forms.DialogResult.OK Then
                Dim img = System.Drawing.Image.FromFile(.FileName)
                Dim gObj As GraphicObject = Nothing
                If Not img Is Nothing Then
                    Dim myEmbeddedImage As New EmbeddedImageGraphic(-Me.FormSurface.FlowsheetDesignSurface.AutoScrollPosition.X, _
                                    -Me.FormSurface.FlowsheetDesignSurface.AutoScrollPosition.X, img)
                    gObj = myEmbeddedImage
                    gObj.Tag = RELAP.App.GetLocalString("FIGURA") & Guid.NewGuid.ToString
                    gObj.AutoSize = True
                End If
                Me.FormSurface.FlowsheetDesignSurface.drawingObjects.Add(gObj)
                Me.FormSurface.FlowsheetDesignSurface.Invalidate()
            End If
        End With
        Me.TSBtabela.Checked = False
    End Sub

    'Private Sub PropriedadesDosComponentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropriedadesDosComponentesToolStripMenuItem.Click
    '    Dim frmpc As New FormPureComp
    '    frmpc.ShowDialog(Me)
    'End Sub

    'Private Sub PontoCríticoRealToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PontoCríticoRealToolStripMenuItem.Click
    '    Me.FormCritPt.ShowDialog(Me)
    'End Sub

    'Private Sub DiagramaDeFasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiagramaDeFasesToolStripMenuItem.Click
    '    Me.FormStabAn.ShowDialog(Me)
    'End Sub

    'Private Sub tsbAtivar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'If Me.tsbAtivar.Checked = True Then
    '    Me.tsbDesat.Checked = False
    '    Me.tsbAtivar.Checked = True
    '    Me.Options.CalculatorActivated = True
    '    Me.FormSurface.LabelCalculator.Text = RELAP.App.GetLocalString("CalculadorOcioso")
    '    '  Me.WriteToLog(RELAP.App.GetLocalString("Calculadorativado"), Color.DimGray, RELAP.FormClasses.TipoAviso.Informacao)
    '    If Not Me.CalculationQueue Is Nothing Then
    '        If Me.CalculationQueue.Count >= 1 Then
    '            Dim msgres As MsgBoxResult = VDialog.Show(RELAP.App.GetLocalString("Existemobjetosespera"), _
    '            RELAP.App.GetLocalString("Objetosnafiladeclcul"), _
    '            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '            If msgres = MsgBoxResult.Yes Then
    '                '   ProcessCalculationQueue(Me)
    '            End If
    '        End If
    '    End If
    '    'Else
    '    '    Me.tsbDesat.Checked = True
    '    '    Me.Options.CalculatorActivated = False
    '    '    Me.FormSurface.LabelSimMode.Text = RELAP.App.GetLocalString("CalculadorDesativado1")
    '    '    Me.WriteToLog(RELAP.App.GetLocalString("Calculadordesativado"), Color.DimGray, RELAP.FormClasses.TipoAviso.Informacao)
    '    'End If
    'End Sub

    'Private Sub tsbDesat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'If Me.tsbDesat.Checked = True Then
    '    Me.tsbAtivar.Checked = False
    '    Me.tsbDesat.Checked = True
    '    Me.Options.CalculatorActivated = False
    '    Me.FormSurface.LabelCalculator.Text = RELAP.App.GetLocalString("CalculadorDesativado1")
    '    'Else
    '    'Me.tsbAtivar.Checked = True
    '    'Me.Options.CalculatorActivated = True
    '    'Me.FormSurface.LabelSimMode.Text = RELAP.App.GetLocalString("CalculadorOcioso")
    '    'End If
    'End Sub

    'Private Sub HYDVerificaçãoDasCondiçõesDeFormaçãoDeHidratosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HYDVerificaçãoDasCondiçõesDeFormaçãoDeHidratosToolStripMenuItem.Click
    '    Me.FormHid.ShowDialog(Me)
    'End Sub

    'Private Sub DiagramaDeFasesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiagramaDeFasesToolStripMenuItem1.Click
    '    Me.FormPE = New FormPhEnv
    '    Me.FormPE.ShowDialog(Me)
    'End Sub

    'Private Sub DiagramaBinárioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiagramaBinárioToolStripMenuItem.Click
    '    Me.FormBE = New FormBinEnv
    '    Me.FormBE.ShowDialog(Me)
    'End Sub
    Private Sub FecharSimulaçãoAtualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    'Private Sub PSVSizingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PSVSizingToolStripMenuItem.Click
    '    Me.FormPSVS.ShowDialog(Me)
    'End Sub

    'Private Sub FlashVesselSizingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlashVesselSizingToolStripMenuItem.Click
    '    Me.FormVS.ShowDialog(Me)
    'End Sub

    'Private Sub PropriedadesDePetróleosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropriedadesDePetróleosToolStripMenuItem.Click
    '    Me.FormColdP.ShowDialog(Me)
    'End Sub

    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        My.MyApplication.CalculatorStopRequested = True
    End Sub

    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '     CalculateAll(Me)
    End Sub

    Private Sub ToolStripButton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CalculationQueue.Clear()
    End Sub

    'Private Sub AnáliseDeSensibilidadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnáliseDeSensibilidadeToolStripMenuItem.Click
    '    Me.FormSensAnalysis0.ShowDialog(Me)
    'End Sub

    'Private Sub MultivariateOptimizerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultivariateOptimizerToolStripMenuItem.Click
    '    Me.FormOptimization0.ShowDialog(Me)
    'End Sub

    'Private Sub GerenciadorDeReaçõesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GerenciadorDeReaçõesToolStripMenuItem.Click
    '    Dim rm As New FormReacManager
    '    rm.ShowDialog()
    'End Sub

    'Private Sub CaracterizaçãoDePetróleosFraçõesC7ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaracterizaçãoDePetróleosFraçõesC7ToolStripMenuItem.Click
    '    Me.FrmPCBulk.ShowDialog(Me)
    'End Sub

    'Private Sub CaracterizaçãoDePetróleosCurvasDeDestilaçãoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaracterizaçãoDePetróleosCurvasDeDestilaçãoToolStripMenuItem.Click
    '    Dim frmdc As New DCCharacterizationWizard
    '    frmdc.ShowDialog(Me)
    'End Sub

    'Private Sub GeradorDeHipotéticosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeradorDeHipotéticosToolStripMenuItem.Click
    '    Me.FrmHypGen = New FormHypGen
    '    Me.FrmHypGen.ShowDialog(Me)
    'End Sub

    'Private Sub CriadorDeComponenteDoUsuárioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CriadorDeComponenteDoUsuárioToolStripMenuItem.Click
    '    Dim fcc As New FormCompCreator
    '    fcc.ShowDialog(Me)
    'End Sub



    Private Sub ToolStripComboBoxUnitSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBoxUnitSystem.SelectedIndexChanged
        Try
            If FormMain.AvailableUnitSystems.ContainsKey(Me.ToolStripComboBoxUnitSystem.SelectedItem.ToString) Then
                Me.Options.SelectedUnitSystem = FormMain.AvailableUnitSystems.Item(Me.ToolStripComboBoxUnitSystem.SelectedItem.ToString)
            End If
            Me.FormSurface.UpdateSelectedObject()
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
    '    Dim frmUnit As New FormUnitGen
    '    frmUnit.ShowDialog(Me)
    'End Sub





    'Private Sub ExibirSaídaDoConsoleToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExibirSaídaDoConsoleToolStripMenuItem.CheckedChanged
    '    If ExibirSaídaDoConsoleToolStripMenuItem.Checked Then
    '        FormOutput.Show(dckPanel)
    '    Else
    '        FormOutput.Hide()
    '    End If
    'End Sub

    'Private Sub ExibirListaDeItensACalcularToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExibirListaDeItensACalcularToolStripMenuItem.CheckedChanged
    '    If ExibirListaDeItensACalcularToolStripMenuItem.Checked Then
    '        FormQueue.Show(dckPanel)
    '    Else
    '        FormQueue.Hide()
    '    End If
    'End Sub

    'Private Sub ExibirRelatóriosDosObjetosCAPEOPENToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExibirRelatóriosDosObjetosCAPEOPENToolStripMenuItem.CheckedChanged
    '    If ExibirRelatóriosDosObjetosCAPEOPENToolStripMenuItem.Checked Then
    '        FormCOReports.Show(dckPanel)
    '    Else
    '        FormCOReports.Hide()
    '    End If
    'End Sub

    'Private Sub PainelDeVariáveisToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PainelDeVariáveisToolStripMenuItem.CheckedChanged
    '    If PainelDeVariáveisToolStripMenuItem.Checked Then
    '        FormWatch.Show(dckPanel)
    '    Else
    '        FormWatch.Hide()
    '    End If
    'End Sub

    Private Sub ToolStripButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton16.CheckStateChanged
        If ToolStripButton16.Checked Then
            Me.FormSurface.FlowsheetDesignSurface.SnapToGrid = True
        Else
            Me.FormSurface.FlowsheetDesignSurface.SnapToGrid = False
        End If
    End Sub

    Private Sub ToolStripButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton17.Click
        If ToolStripButton17.Checked Then
            Me.FormSurface.FlowsheetDesignSurface.QuickConnect = True
        Else
            Me.FormSurface.FlowsheetDesignSurface.QuickConnect = False
        End If
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.FormSurface.FlowsheetDesignSurface.Zoom += 0.05
        Me.TSTBZoom.Text = Format(Me.FormSurface.FlowsheetDesignSurface.Zoom, "#%")
        Me.FormSurface.FlowsheetDesignSurface.Invalidate()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.FormSurface.FlowsheetDesignSurface.Zoom -= 0.05
        Me.TSTBZoom.Text = Format(Me.FormSurface.FlowsheetDesignSurface.Zoom, "#%")
        Me.FormSurface.FlowsheetDesignSurface.Invalidate()
    End Sub

    'Private Sub ComponentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComponentesToolStripMenuItem.Click
    '    Me.FrmStSim1.ShowDialog(Me)
    'End Sub

    'Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
    '    Call Me.ComponentesToolStripMenuItem_Click(sender, e)
    'End Sub

    'Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
    '    Call Me.GerarRelatórioToolStripMenuItem_Click(sender, e)
    'End Sub

    'Private Sub GerarRelatórioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GerarRelatórioToolStripMenuItem.Click
    '    Me.FrmReport.ShowDialog(Me)
    'End Sub


    'Private Sub CAPEOPENFlowsheetMonitoringObjectsMOsToolStripMenuItem_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles CAPEOPENFlowsheetMonitoringObjectsMOsToolStripMenuItem.MouseHover

    '    If Me.CAPEOPENFlowsheetMonitoringObjectsMOsToolStripMenuItem.DropDownItems.Count = 0 Then

    '        Dim tsmi As New ToolStripMenuItem
    '        With tsmi
    '            .Text = "Please wait..."
    '            .DisplayStyle = ToolStripItemDisplayStyle.Text
    '            .AutoToolTip = False
    '        End With
    '        Me.CAPEOPENFlowsheetMonitoringObjectsMOsToolStripMenuItem.DropDownItems.Add(tsmi)

    '        Application.DoEvents()

    '        If FormMain.COMonitoringObjects.Count = 0 Then
    '            FormMain.SearchCOMOs()
    '        End If

    '        Me.CAPEOPENFlowsheetMonitoringObjectsMOsToolStripMenuItem.DropDownItems.Clear()

    '        tsmi = Nothing

    '        Application.DoEvents()

    '        'load CAPE-OPEN Flowsheet Monitoring Objects
    '        CreateCOMOList()

    '    End If


    'End Sub

    Private Sub ToolStripButton18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton18.Click

        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim rect As Rectangle = New Rectangle(0, 0, Me.FormSurface.FlowsheetDesignSurface.Width - 14, Me.FormSurface.FlowsheetDesignSurface.Height - 14)
            Dim img As Image = New Bitmap(rect.Width, rect.Height)
            Me.FormSurface.FlowsheetDesignSurface.DrawToBitmap(img, Me.FormSurface.FlowsheetDesignSurface.Bounds)
            img.Save(Me.SaveFileDialog1.FileName, Imaging.ImageFormat.Png)
            img.Dispose()
        End If

    End Sub

    Private Sub ToolStripButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton20.Click
        Me.FormSurface.FlowsheetDesignSurface.ZoomAll()
        Me.TSTBZoom.Text = Format(Me.FormSurface.FlowsheetDesignSurface.Zoom, "#%")
    End Sub

    Private Sub TSTBZoom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TSTBZoom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.FormSurface.FlowsheetDesignSurface.Zoom = CInt(Me.TSTBZoom.Text.Replace("%", "")) / 100
            Me.TSTBZoom.Text = Format(Me.FormSurface.FlowsheetDesignSurface.Zoom, "#%")
            Me.FormSurface.FlowsheetDesignSurface.Invalidate()
        End If
    End Sub


    'Private Sub GerenciadorDeAmostrasDePetróleoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GerenciadorDeAmostrasDePetróleoToolStripMenuItem.Click
    '    Dim frmam As New FormAssayManager
    '    frmam.ShowDialog(Me)
    '    Try
    '        frmam.Close()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub ToolStripButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSaveState.Click

    '    FormMain.SaveState(Me)

    'End Sub

    'Private Sub RestoreState_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim tsmi As ToolStripMenuItem = sender

    '    FormMain.RestoreState(Me, FlowsheetStates(tsmi.Tag))

    'End Sub

    Private Sub RemoveState_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim tsmi As ToolStripMenuItem = sender

        FlowsheetStates.Remove(tsmi.Tag)

        '    UpdateStateList()

    End Sub

    'Sub UpdateStateList()

    '    With Me.tsbRestoreStates.DropDownItems

    '        .Clear()

    '        For Each k As Date In Me.FlowsheetStates.Keys

    '            Dim tsmi As ToolStripMenuItem = .Add(Me.FlowsheetStates(k).Description & " (" & k.ToString & ")")
    '            tsmi.Tag = k
    '            tsmi.Image = Me.FlowsheetStates(k).Snapshot
    '            AddHandler tsmi.Click, AddressOf RestoreState_ItemClick

    '            Dim tsmiR As ToolStripMenuItem = tsmi.DropDownItems.Add(RELAP.App.GetLocalString("RestoreState"))
    '            tsmiR.Tag = k
    '            tsmiR.Image = My.Resources.arrow_in
    '            AddHandler tsmiR.Click, AddressOf RestoreState_ItemClick

    '            Dim tsmiE As ToolStripMenuItem = tsmi.DropDownItems.Add(RELAP.App.GetLocalString("Excluir"))
    '            tsmiE.Tag = k
    '            tsmiE.Image = My.Resources.cross
    '            AddHandler tsmiE.Click, AddressOf RemoveState_ItemClick

    '        Next

    '    End With

    'End Sub

    'Private Sub ToolStripButton21_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClearStates.Click

    '    If Not Me.FlowsheetStates Is Nothing Then
    '        Me.FlowsheetStates.Clear()
    '        UpdateStateList()
    '    End If

    'End Sub

    'Private Sub tsbSimultAdjustSolver_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    m_simultadjustsolverenabled = tsbSimultAdjustSolver.Checked
    'End Sub

#End Region

#Region "    Connect/Disconnect Objects "

    Public Sub DeleteSelectedObject(ByVal sender As System.Object, ByVal e As System.EventArgs, Optional ByVal confirmation As Boolean = True)

        If Not Me.FormSurface.FlowsheetDesignSurface.SelectedObject Is Nothing Then
            Dim SelectedObj As GraphicObject = Me.FormSurface.FlowsheetDesignSurface.SelectedObject
            Dim namesel As String = SelectedObj.Name
            If Not Me.FormSurface.FlowsheetDesignSurface.SelectedObject.IsConnector Then
                Dim msgresult As MsgBoxResult
                If confirmation Then
                    If SelectedObj.TipoObjeto = TipoObjeto.GO_Figura Then
                        msgresult = VDialog.Show(RELAP.App.GetLocalString("Excluirafiguraseleci"), RELAP.App.GetLocalString("Excluirobjeto"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    ElseIf SelectedObj.TipoObjeto = TipoObjeto.GO_Tabela Then
                        VDialog.Show(RELAP.App.GetLocalString("Atabelapodeseroculta") & vbCrLf & RELAP.App.GetLocalString("doobjetoqualelaperte"), RELAP.App.GetLocalString("Nopossvelexcluirtabe"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf SelectedObj.TipoObjeto = TipoObjeto.GO_Texto Then
                        msgresult = VDialog.Show(RELAP.App.GetLocalString("Excluiracaixadetexto"), RELAP.App.GetLocalString("Excluirobjeto"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Else
                        msgresult = VDialog.Show(RELAP.App.GetLocalString("Excluir") & Me.FormSurface.FlowsheetDesignSurface.SelectedObject.Tag & "?", RELAP.App.GetLocalString("Excluirobjeto"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    End If
                Else
                    msgresult = MsgBoxResult.Yes
                End If
                If msgresult = MsgBoxResult.Yes Then

                    If SelectedObj.IsEnergyStream Then

                        'DeCalculateObject(Me, SelectedObj)
                        Dim InCon, OutCon As ConnectionPoint
                        For Each InCon In Me.FormSurface.FlowsheetDesignSurface.SelectedObject.InputConnectors
                            If InCon.IsAttached = True Then
                                If InCon.AttachedConnector.AttachedFrom.EnergyConnector.IsAttached Then
                                    With InCon.AttachedConnector.AttachedFrom.EnergyConnector
                                        .IsAttached = False
                                        Me.FormSurface.FlowsheetDesignSurface.SelectedObject = .AttachedConnector
                                        Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                                        .AttachedConnector = Nothing
                                    End With
                                Else
                                    With InCon.AttachedConnector.AttachedFrom.OutputConnectors(InCon.AttachedConnector.AttachedFromConnectorIndex)
                                        .IsAttached = False
                                        Me.FormSurface.FlowsheetDesignSurface.SelectedObject = .AttachedConnector
                                        Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                                        .AttachedConnector = Nothing
                                    End With
                                End If
                            End If
                        Next
                        Me.FormSurface.FlowsheetDesignSurface.SelectedObject = SelectedObj
                        For Each OutCon In Me.FormSurface.FlowsheetDesignSurface.SelectedObject.OutputConnectors
                            If OutCon.IsAttached = True Then
                                With OutCon.AttachedConnector.AttachedTo.InputConnectors(OutCon.AttachedConnector.AttachedToConnectorIndex)
                                    .IsAttached = False
                                    Me.FormSurface.FlowsheetDesignSurface.SelectedObject = .AttachedConnector
                                    Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                                    .AttachedConnector = Nothing
                                End With
                            End If
                        Next
                        Me.FormSurface.FlowsheetDesignSurface.SelectedObject = SelectedObj

                        Me.Collections.EnergyStreamCollection.Remove(namesel)
                        ' Me.FormObjList.TreeViewObj.Nodes("NodeEN").Nodes.RemoveByKey(namesel)
                        'RELAP
                        ' Me.Collections.CLCS_EnergyStreamCollection(namesel).Dispose()
                        ' Me.Collections.CLCS_EnergyStreamCollection.Remove(namesel)
                        Me.Collections.ObjectCollection.Remove(namesel)
                        Me.Collections.ObjectCollection.Remove(namesel)
                        Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                    Else

                        If SelectedObj.TipoObjeto = TipoObjeto.GO_Figura Then
                            Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                        ElseIf SelectedObj.TipoObjeto = TipoObjeto.GO_Tabela Then
                            'Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                        ElseIf SelectedObj.TipoObjeto = TipoObjeto.GO_MasterTable Then
                            Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                        ElseIf SelectedObj.TipoObjeto = TipoObjeto.GO_Texto Then
                            Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                        ElseIf SelectedObj.TipoObjeto = TipoObjeto.GO_TabelaRapida Then
                            Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                        Else
                            Dim obj As SimulationObjects_BaseClass = Me.Collections.ObjectCollection(SelectedObj.Name)
                            If Not obj.Tabela Is Nothing Then
                                'deletar tabela
                                Me.FormSurface.FlowsheetDesignSurface.drawingObjects.Remove(obj.Tabela)
                            End If
                            ' DeCalculateObject(Me, SelectedObj)
                            If Me.FormSurface.FlowsheetDesignSurface.SelectedObject.EnergyConnector.IsAttached = True Then
                                With Me.FormSurface.FlowsheetDesignSurface.SelectedObject.EnergyConnector.AttachedConnector.AttachedTo.InputConnectors(0)
                                    .IsAttached = False
                                    Me.FormSurface.FlowsheetDesignSurface.SelectedObject = .AttachedConnector
                                    Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                                    .AttachedConnector = Nothing
                                End With
                            End If
                            Me.FormSurface.FlowsheetDesignSurface.SelectedObject = SelectedObj
                            Dim InCon, OutCon As ConnectionPoint
                            For Each InCon In Me.FormSurface.FlowsheetDesignSurface.SelectedObject.InputConnectors
                                Try
                                    If InCon.IsAttached = True Then
                                        With InCon.AttachedConnector.AttachedFrom.OutputConnectors(InCon.AttachedConnector.AttachedFromConnectorIndex)
                                            .IsAttached = False
                                            Me.FormSurface.FlowsheetDesignSurface.SelectedObject = .AttachedConnector
                                            Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                                            .AttachedConnector = Nothing
                                        End With
                                    End If
                                Catch ex As Exception

                                End Try
                            Next
                            Me.FormSurface.FlowsheetDesignSurface.SelectedObject = SelectedObj
                            For Each OutCon In Me.FormSurface.FlowsheetDesignSurface.SelectedObject.OutputConnectors
                                Try
                                    If OutCon.IsAttached = True Then
                                        With OutCon.AttachedConnector.AttachedTo.InputConnectors(OutCon.AttachedConnector.AttachedToConnectorIndex)
                                            .IsAttached = False
                                            Me.FormSurface.FlowsheetDesignSurface.SelectedObject = .AttachedConnector
                                            Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                                            .AttachedConnector = Nothing
                                        End With
                                    End If
                                Catch ex As Exception

                                End Try
                            Next

                            Me.FormSurface.FlowsheetDesignSurface.SelectedObject = SelectedObj

                            'dispose object
                            Me.Collections.ObjectCollection(namesel).Dispose()
                            Select Case SelectedObj.TipoObjeto

                            End Select

                            Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()

                        End If

                        Dim arrays(Me.Collections.ObjectCollection.Count - 1) As String
                        ' Dim aNode, aNode2 As TreeNode
                        Dim i As Integer = 0
                        'For Each aNode In Me.FormObjList.TreeViewObj.Nodes
                        '    For Each aNode2 In aNode.Nodes
                        '        Try
                        '            arrays(i) = aNode2.Text
                        '        Catch ex As Exception
                        '        End Try
                        '        i += 1
                        '    Next
                        'Next
                        'Me.FormObjList.ACSC.Clear()
                        'Me.FormObjList.ACSC.AddRange(arrays)
                        'Me.FormObjList.TBSearch.AutoCompleteCustomSource = Me.FormObjList.ACSC

                    End If
                End If
            End If
        End If
    End Sub

    Public Sub DeleteObject(ByVal tag As String, Optional ByVal confirmation As Boolean = True)

        Dim gobj As GraphicObject = Me.GetFlowsheetGraphicObject(tag)

        If Not gobj Is Nothing Then
            Me.FormSurface.FlowsheetDesignSurface.SelectedObject = gobj
            Me.DeleteSelectedObject(Me, New EventArgs(), confirmation)
        End If

    End Sub

    Public Sub DisconnectObject(ByRef gObjFrom As GraphicObject, ByRef gObjTo As GraphicObject)

        Dim conObj As ConnectorGraphic = Nothing
        Dim SelObj As GraphicObject = gObjFrom
        Dim ObjToDisconnect As GraphicObject = Nothing
        Try
            ObjToDisconnect = gObjTo
        Catch
            VDialog.Show(RELAP.App.GetLocalString("Erroaodeterminarobje"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Not ObjToDisconnect Is Nothing Then
            Dim conptObj As ConnectionPoint = Nothing
            For Each conptObj In SelObj.InputConnectors
                If conptObj.IsAttached = True Then
                    If Not conptObj.AttachedConnector Is Nothing Then
                        If conptObj.AttachedConnector.AttachedFrom.Name.ToString = ObjToDisconnect.Name.ToString Then
                            '    DeCalculateDisconnectedObject(Me, SelObj, "In")
                            conptObj.AttachedConnector.AttachedFrom.OutputConnectors(conptObj.AttachedConnector.AttachedFromConnectorIndex).IsAttached = False
                            conptObj.AttachedConnector.AttachedFrom.OutputConnectors(conptObj.AttachedConnector.AttachedFromConnectorIndex).AttachedConnector = Nothing
                            Me.FormSurface.FlowsheetDesignSurface.SelectedObjects.Clear()
                            Me.FormSurface.FlowsheetDesignSurface.SelectedObject = conptObj.AttachedConnector
                            conptObj.IsAttached = False
                            Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                            Exit Sub
                        End If
                    End If
                End If
            Next
            For Each conptObj In SelObj.OutputConnectors
                If conptObj.IsAttached = True Then
                    If Not conptObj.AttachedConnector Is Nothing Then
                        If conptObj.AttachedConnector.AttachedTo.Name.ToString = ObjToDisconnect.Name.ToString Then
                            '    DeCalculateDisconnectedObject(Me, SelObj, "Out")
                            conptObj.AttachedConnector.AttachedTo.InputConnectors(conptObj.AttachedConnector.AttachedToConnectorIndex).IsAttached = False
                            conptObj.AttachedConnector.AttachedTo.InputConnectors(conptObj.AttachedConnector.AttachedToConnectorIndex).AttachedConnector = Nothing
                            Me.FormSurface.FlowsheetDesignSurface.SelectedObject = conptObj.AttachedConnector
                            conptObj.IsAttached = False
                            Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                            Exit Sub
                        End If
                    End If
                End If
            Next
            If SelObj.EnergyConnector.IsAttached = True Then
                If SelObj.EnergyConnector.AttachedConnector.AttachedFrom.Name.ToString = ObjToDisconnect.Name.ToString Then
                    '   DeCalculateDisconnectedObject(Me, SelObj, "Out")
                    SelObj.EnergyConnector.AttachedConnector.AttachedFrom.OutputConnectors(SelObj.EnergyConnector.AttachedConnector.AttachedFromConnectorIndex).IsAttached = False
                    SelObj.EnergyConnector.AttachedConnector.AttachedFrom.OutputConnectors(SelObj.EnergyConnector.AttachedConnector.AttachedFromConnectorIndex).AttachedConnector = Nothing
                    Me.FormSurface.FlowsheetDesignSurface.SelectedObject = SelObj.EnergyConnector.AttachedConnector
                    SelObj.EnergyConnector.IsAttached = False
                    Me.FormSurface.FlowsheetDesignSurface.DeleteSelectedObject()
                    Exit Sub
                End If
            End If
        End If

    End Sub

    Public Sub ConnectObject(ByRef gObjFrom As GraphicObject, ByRef gObjTo As GraphicObject, Optional ByVal fidx As Integer = -1, Optional ByVal tidx As Integer = -1)

        If gObjFrom.TipoObjeto <> TipoObjeto.GO_Figura And gObjFrom.TipoObjeto <> TipoObjeto.GO_Tabela And _
        gObjFrom.TipoObjeto <> TipoObjeto.GO_Tabela And gObjFrom.TipoObjeto <> TipoObjeto.GO_TabelaRapida And _
        gObjFrom.TipoObjeto <> TipoObjeto.Nenhum And _
        gObjTo.TipoObjeto <> TipoObjeto.GO_Figura And gObjTo.TipoObjeto <> TipoObjeto.GO_Tabela And _
        gObjTo.TipoObjeto <> TipoObjeto.GO_Tabela And gObjTo.TipoObjeto <> TipoObjeto.GO_TabelaRapida And _
        gObjTo.TipoObjeto <> TipoObjeto.Nenhum And gObjTo.TipoObjeto <> TipoObjeto.GO_MasterTable And gObjTo.TipoObjeto <> TipoObjeto.HeatStructure Then

            Dim con1OK As Boolean = False
            Dim con2OK As Boolean = False

            'For Each gObj In Me.FormSurface.FlowsheetDesignSurface.drawingObjects

            '    If gObjConnectFrom_Tag = gObj.Tag.ToString Then gObjFrom = gObj
            '    If gObjConnectTo_Tag = gObj.Tag.ToString Then gObjTo = gObj

            'Next

            ' karwai by waleed and afnan

            'singlejunction
            If gObjTo.TipoObjeto = TipoObjeto.SingleJunction Then
                Me.Collections.CLCS_SingleJunctionCollection(gObjTo.Name).FromComponent = Me.Collections.ObjectCollection(gObjFrom.Name).UID
                FromComponent = Me.Collections.ObjectCollection(gObjFrom.Name).UID
                '  gObjTo.
            End If
            If gObjFrom.TipoObjeto = TipoObjeto.SingleJunction Then
                Me.Collections.CLCS_SingleJunctionCollection(gObjFrom.Name).ToComponent = Me.Collections.ObjectCollection(gObjTo.Name).UID
                ToComponent = Me.Collections.ObjectCollection(gObjTo.Name).UID
                '  gObjTo.
            End If

            'time dependent junction
            If gObjTo.TipoObjeto = TipoObjeto.TimeDependentJunction Then
                Me.Collections.CLCS_TimeDependentJunctionCollection(gObjTo.Name).FromComponent = Me.Collections.ObjectCollection(gObjFrom.Name).UID
                FromComponent = Me.Collections.ObjectCollection(gObjFrom.Name).UID
                '  gObjTo.
            End If
            If gObjFrom.TipoObjeto = TipoObjeto.TimeDependentJunction Then
                Me.Collections.CLCS_TimeDependentJunctionCollection(gObjFrom.Name).ToComponent = Me.Collections.ObjectCollection(gObjTo.Name).UID
                ToComponent = Me.Collections.ObjectCollection(gObjTo.Name).UID
                '  gObjTo.
            End If

            'valve
            If gObjTo.TipoObjeto = TipoObjeto.Valve Then
                Me.Collections.CLCS_ValveCollection(gObjTo.Name).FromComponent = Me.Collections.ObjectCollection(gObjFrom.Name).UID
                FromComponent = Me.Collections.ObjectCollection(gObjFrom.Name).UID
                '  gObjTo.
            End If
            If gObjFrom.TipoObjeto = TipoObjeto.Valve Then
                Me.Collections.CLCS_ValveCollection(gObjFrom.Name).ToComponent = Me.Collections.ObjectCollection(gObjTo.Name).UID
                ToComponent = Me.Collections.ObjectCollection(gObjTo.Name).UID
                '  gObjTo.
            End If
            'posicionar pontos nos primeiros slots livres
            Dim StartPos, EndPos As New Point
            Dim InConSlot, OutConSlot As New ConnectionPoint
            If Not gObjFrom Is Nothing Then
                If Not gObjTo Is Nothing Then
                    If gObjFrom.TipoObjeto = TipoObjeto.MaterialStream And gObjTo.TipoObjeto = TipoObjeto.MaterialStream Then
                        VDialog.Show(RELAP.App.GetLocalString("Nopossvelrealizaress"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    ElseIf gObjFrom.TipoObjeto = TipoObjeto.EnergyStream And gObjTo.TipoObjeto = TipoObjeto.EnergyStream Then
                        VDialog.Show(RELAP.App.GetLocalString("Nopossvelrealizaress"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    ElseIf Not gObjFrom.TipoObjeto = TipoObjeto.MaterialStream And Not gObjFrom.TipoObjeto = TipoObjeto.EnergyStream Then
                        If Not gObjTo.TipoObjeto = TipoObjeto.EnergyStream And Not gObjTo.TipoObjeto = TipoObjeto.MaterialStream Then
                            'VDialog.Show(RELAP.App.GetLocalString("Nopossvelrealizaress"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'Exit Sub
                        End If
                    ElseIf gObjFrom.TipoObjeto = TipoObjeto.MaterialStream And gObjTo.TipoObjeto = TipoObjeto.EnergyStream Then
                        VDialog.Show(RELAP.App.GetLocalString("Nopossvelrealizaress"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    ElseIf gObjFrom.TipoObjeto = TipoObjeto.EnergyStream And gObjTo.TipoObjeto = TipoObjeto.MaterialStream Then
                        VDialog.Show(RELAP.App.GetLocalString("Nopossvelrealizaress"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    If gObjTo.IsEnergyStream = False Then
                        If Not gObjFrom.IsEnergyStream Then
                            If tidx = -1 Then
                                For Each InConSlot In gObjTo.InputConnectors
                                    If Not InConSlot.IsAttached And InConSlot.Type = ConType.ConIn Then
                                        EndPos = InConSlot.Position
                                        InConSlot.IsAttached = True
                                        con2OK = True
                                        Exit For
                                    End If
                                Next
                            Else
                                If Not gObjTo.InputConnectors(tidx).IsAttached And gObjTo.InputConnectors(tidx).Type = ConType.ConIn Then
                                    InConSlot = gObjTo.InputConnectors(tidx)
                                    EndPos = InConSlot.Position
                                    InConSlot.IsAttached = True
                                    con2OK = True
                                End If
                            End If
                        Else
                            If tidx = -1 Then
                                For Each InConSlot In gObjTo.InputConnectors
                                    If Not InConSlot.IsAttached And InConSlot.Type = ConType.ConEn Then
                                        EndPos = InConSlot.Position
                                        InConSlot.IsAttached = True
                                        con2OK = True
                                        Exit For
                                    End If
                                Next
                            Else
                                If Not gObjTo.InputConnectors(tidx).IsAttached And gObjTo.InputConnectors(tidx).Type = ConType.ConEn Then
                                    InConSlot = gObjTo.InputConnectors(tidx)
                                    EndPos = InConSlot.Position
                                    InConSlot.IsAttached = True
                                    con2OK = True
                                End If
                            End If
                            If Not con2OK Then
                                VDialog.Show(RELAP.App.GetLocalString("Correntesdeenergiasp") & vbCrLf & RELAP.App.GetLocalString("MisturadoresMatriaEn"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                        If fidx = -1 Then
                            For Each OutConSlot In gObjFrom.OutputConnectors
                                If Not OutConSlot.IsAttached Then
                                    StartPos = OutConSlot.Position
                                    OutConSlot.IsAttached = True
                                    If con2OK Then con1OK = True
                                    Exit For
                                End If
                            Next
                        Else
                            If Not gObjFrom.OutputConnectors(fidx).IsAttached Then
                                OutConSlot = gObjFrom.OutputConnectors(fidx)
                                StartPos = OutConSlot.Position
                                OutConSlot.IsAttached = True
                                If con2OK Then con1OK = True
                            End If
                        End If
                    Else
                        Select Case gObjFrom.TipoObjeto
                            Case TipoObjeto.SingleVolume
                                GoTo 100
                            Case TipoObjeto.SingleJunction
                                GoTo 100
                            Case TipoObjeto.TimeDependentJunction
                                GoTo 100
                            Case TipoObjeto.Pipe
                                GoTo 100
                            Case TipoObjeto.Branch
                                GoTo 100
                            Case TipoObjeto.Tank
                                GoTo 100

                            Case TipoObjeto.FuelRod
                                GoTo 100
                            Case TipoObjeto.Simulator
                                GoTo 100
                            Case TipoObjeto.Expander
                                GoTo 100
                            Case TipoObjeto.ShortcutColumn
                                GoTo 100
                            Case TipoObjeto.DistillationColumn
                                GoTo 100
                            Case TipoObjeto.AbsorptionColumn
                                GoTo 100
                            Case TipoObjeto.ReboiledAbsorber
                                GoTo 100
                            Case TipoObjeto.RefluxedAbsorber
                                GoTo 100
                            Case TipoObjeto.OT_EnergyRecycle
                                GoTo 100
                            Case TipoObjeto.ComponentSeparator
                                GoTo 100
                            Case TipoObjeto.CustomUO
                                GoTo 100
                            Case TipoObjeto.CapeOpenUO
                                GoTo 100
                            Case Else
                                VDialog.Show(RELAP.App.GetLocalString("Correntesdeenergiasp2") & vbCrLf & RELAP.App.GetLocalString("TubulaesTurbinaseRes"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                        End Select
100:                    If gObjFrom.TipoObjeto <> TipoObjeto.CapeOpenUO And gObjFrom.TipoObjeto <> TipoObjeto.CustomUO And gObjFrom.TipoObjeto <> TipoObjeto.DistillationColumn _
                            And gObjFrom.TipoObjeto <> TipoObjeto.AbsorptionColumn And gObjFrom.TipoObjeto <> TipoObjeto.OT_EnergyRecycle _
                            And gObjFrom.TipoObjeto <> TipoObjeto.RefluxedAbsorber And gObjFrom.TipoObjeto <> TipoObjeto.ReboiledAbsorber And gObjFrom.TipoObjeto <> TipoObjeto.HeatStructure Then
                            If Not gObjFrom.EnergyConnector.IsAttached Then
                                StartPos = gObjFrom.EnergyConnector.Position
                                gObjFrom.EnergyConnector.IsAttached = True
                                con1OK = True
                                OutConSlot = gObjFrom.EnergyConnector
                                EndPos = gObjTo.InputConnectors(0).Position
                                gObjTo.InputConnectors(0).IsAttached = True
                                con2OK = True
                                InConSlot = gObjTo.InputConnectors(0)
                            End If
                        Else
                            If tidx = -1 Then
                                For Each InConSlot In gObjTo.InputConnectors
                                    If Not InConSlot.IsAttached And InConSlot.Type = ConType.ConIn Then
                                        EndPos = InConSlot.Position
                                        InConSlot.IsAttached = True
                                        con2OK = True
                                        Exit For
                                    End If
                                Next
                            Else
                                If Not gObjTo.InputConnectors(tidx).IsAttached And gObjTo.InputConnectors(tidx).Type = ConType.ConIn Then
                                    InConSlot = gObjTo.InputConnectors(tidx)
                                    EndPos = InConSlot.Position
                                    InConSlot.IsAttached = True
                                    con2OK = True
                                End If
                            End If
                            If fidx = -1 Then
                                For Each OutConSlot In gObjFrom.OutputConnectors
                                    If Not OutConSlot.IsAttached And OutConSlot.Type = ConType.ConEn Then
                                        StartPos = OutConSlot.Position
                                        OutConSlot.IsAttached = True
                                        If con2OK Then con1OK = True
                                        Exit For
                                    End If
                                Next
                            Else
                                If Not gObjFrom.OutputConnectors(fidx).IsAttached Then
                                    OutConSlot = gObjFrom.OutputConnectors(fidx)
                                    StartPos = OutConSlot.Position
                                    OutConSlot.IsAttached = True
                                    If con2OK Then con1OK = True
                                End If
                            End If
                        End If
                    End If
                Else
                    VDialog.Show(RELAP.App.GetLocalString("Nohobjetosaseremcone"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Else
                VDialog.Show(RELAP.App.GetLocalString("Nohobjetosaseremcone"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If con1OK = True And con2OK = True Then
                'desenhar conector
                Dim myCon As New ConnectorGraphic(StartPos, EndPos, 1, Color.DarkRed)
                OutConSlot.AttachedConnector = myCon
                InConSlot.AttachedConnector = myCon
                With myCon
                    .IsConnector = True
                    .AttachedFrom = gObjFrom
                    If gObjFrom.IsEnergyStream Then
                        .AttachedFromEnergy = True
                    End If
                    .AttachedFromConnectorIndex = gObjFrom.OutputConnectors.IndexOf(OutConSlot)
                    .AttachedTo = gObjTo
                    If gObjTo.IsEnergyStream Then
                        .AttachedToEnergy = True
                    End If
                    .AttachedToConnectorIndex = gObjTo.InputConnectors.IndexOf(InConSlot)
                    If Not myCon Is Nothing Then
                        Me.FormSurface.FlowsheetDesignSurface.drawingObjects.Add(myCon)
                        Me.FormSurface.FlowsheetDesignSurface.Invalidate()
                    End If
                End With
            Else
                VDialog.Show(RELAP.App.GetLocalString("Todasasconexespossve"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else


        End If
        Me.FormSurface.FlowsheetDesignSurface.Invalidate()
    End Sub

#End Region

#Region "    Property Grid 2 Populate Functions "

    Public Function PopulatePGEx2(ByRef gobj As GraphicObject)

        If gobj.TipoObjeto = TipoObjeto.GO_Tabela Then

            Dim gobj2 As RELAP.GraphicObjects.TableGraphic = CType(gobj, RELAP.GraphicObjects.TableGraphic)

            With Me.FormProps.PGEx2

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True
                .Item.Clear()

                .Item.Add(RELAP.App.GetLocalString("Cor"), gobj2, "LineColor", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Cordotextodatabela"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Cabealho"), gobj2, "HeaderFont", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Fontedotextodocabeal"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Font)
                End With
                .Item.Add(RELAP.App.GetLocalString("Coluna1Fonte"), gobj2, "FontCol1", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Fontedotextodacoluna"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Font)
                End With
                .Item.Add(RELAP.App.GetLocalString("Coluna2Fonte"), gobj2, "FontCol2", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Fontedotextodacoluna2"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Font)
                End With
                .Item.Add(RELAP.App.GetLocalString("Coluna3Fonte"), gobj2, "FontCol3", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Fontedotextodacoluna3"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Font)
                End With

                .Item.Add(RELAP.App.GetLocalString("Tratamentodotexto"), gobj2, "TextRenderStyle", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Tipodesuavizaoaplica"), True)
                .Item.Add(RELAP.App.GetLocalString("Estilodaborda"), gobj2, "BorderStyle", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Estilodabordatraceja"), True)
                .Item.Add(RELAP.App.GetLocalString("Cordaborda"), gobj2, "BorderColor", False, RELAP.App.GetLocalString("Aparncia2"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Espaamento"), gobj2, "Padding", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Espaamentoentreotext"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(Integer)
                End With
                .Item.Add(RELAP.App.GetLocalString("Rotao"), gobj2, "Rotation", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Inclinaodatabelaemre"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Int32)
                End With

                .Item.Add(RELAP.App.GetLocalString("Gradiente2"), gobj2, "IsGradientBackground", False, RELAP.App.GetLocalString("Fundo"), "Selecione se deve ser utilizado um gradiente no fundo da tabela", True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(RELAP.App.GetLocalString("Corsemgradiente"), gobj2, "FillColor", False, RELAP.App.GetLocalString("Fundo"), RELAP.App.GetLocalString("Corsemgradiente"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Cor1gradiente"), gobj2, "BackgroundGradientColor1", False, RELAP.App.GetLocalString("Fundo"), RELAP.App.GetLocalString("Cor1dogradientecasoa"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Cor2gradiente"), gobj2, "BackgroundGradientColor2", False, RELAP.App.GetLocalString("Fundo"), RELAP.App.GetLocalString("Cor2dogradientecasoa"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Opacidade0255"), gobj2, "Opacity", False, RELAP.App.GetLocalString("Fundo"), RELAP.App.GetLocalString("Nveldetransparnciada"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(Integer)
                End With

            End With

            gobj2 = Nothing
            FormProps.FTSProps.SelectedItem = FormProps.TSProps

        ElseIf gobj.TipoObjeto = TipoObjeto.GO_MasterTable Then

            Dim gobj2 As RELAP.GraphicObjects.MasterTableGraphic = CType(gobj, RELAP.GraphicObjects.MasterTableGraphic)

            With Me.FormProps.PGEx2

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True
                .Item.Clear()

                .Item.Add(RELAP.App.GetLocalString("Cor"), gobj2, "LineColor", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Cordotextodatabela"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Cabealho"), gobj2, "HeaderFont", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Fontedotextodocabeal"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Font)
                End With
                .Item.Add(RELAP.App.GetLocalString("Coluna1Fonte"), gobj2, "FontCol1", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Fontedotextodacoluna"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Font)
                End With
                .Item.Add(RELAP.App.GetLocalString("Coluna2Fonte"), gobj2, "FontCol2", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Fontedotextodacoluna2"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Font)
                End With
                .Item.Add(RELAP.App.GetLocalString("Coluna3Fonte"), gobj2, "FontCol3", False, RELAP.App.GetLocalString("Formataodotexto1"), RELAP.App.GetLocalString("Fontedotextodacoluna3"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Font)
                End With

                .Item.Add(RELAP.App.GetLocalString("HeaderText"), gobj2, "HeaderText", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString(""), True)
                .Item.Add(RELAP.App.GetLocalString("Tratamentodotexto"), gobj2, "TextRenderStyle", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Tipodesuavizaoaplica"), True)
                .Item.Add(RELAP.App.GetLocalString("Estilodaborda"), gobj2, "BorderStyle", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Estilodabordatraceja"), True)
                .Item.Add(RELAP.App.GetLocalString("Cordaborda"), gobj2, "BorderColor", False, RELAP.App.GetLocalString("Aparncia2"), "", True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Espaamento"), gobj2, "Padding", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Espaamentoentreotext"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(Integer)
                End With
                .Item.Add(RELAP.App.GetLocalString("Rotao"), gobj2, "Rotation", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Inclinaodatabelaemre"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Int32)
                End With

                .Item.Add(RELAP.App.GetLocalString("Gradiente2"), gobj2, "IsGradientBackground", False, RELAP.App.GetLocalString("Fundo"), "Selecione se deve ser utilizado um gradiente no fundo da tabela", True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(RELAP.App.GetLocalString("Corsemgradiente"), gobj2, "FillColor", False, RELAP.App.GetLocalString("Fundo"), RELAP.App.GetLocalString("Corsemgradiente"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Cor1gradiente"), gobj2, "BackgroundGradientColor1", False, RELAP.App.GetLocalString("Fundo"), RELAP.App.GetLocalString("Cor1dogradientecasoa"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Cor2gradiente"), gobj2, "BackgroundGradientColor2", False, RELAP.App.GetLocalString("Fundo"), RELAP.App.GetLocalString("Cor2dogradientecasoa"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Opacidade0255"), gobj2, "Opacity", False, RELAP.App.GetLocalString("Fundo"), RELAP.App.GetLocalString("Nveldetransparnciada"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(Integer)
                End With

            End With

            gobj2 = Nothing
            FormProps.FTSProps.SelectedItem = FormProps.TSProps

        ElseIf gobj.TipoObjeto = TipoObjeto.GO_Texto Then

            Dim gobj2 As TextGraphic = CType(gobj, TextGraphic)

            With Me.FormProps.PGEx2

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True
                .Item.Clear()

                .Item.Add(RELAP.App.GetLocalString("Nome"), gobj.Tag, False, RELAP.App.GetLocalString("Descrio1"), RELAP.App.GetLocalString("Nomedoobjeto"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Boolean)
                End With

                .Item.Add(RELAP.App.GetLocalString("Texto"), gobj2, "Text", False, "", RELAP.App.GetLocalString("Textoaserexibidonaca"), True)
                With .Item(.Item.Count - 1)
                    '   .CustomEditor = New System.ComponentModel.Design.MultilineStringEditor
                    .DefaultType = GetType(String)
                End With
                .Item.Add(RELAP.App.GetLocalString("Tratamentodotexto"), gobj2, "TextRenderStyle", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Tipodesuavizaoaplica"), True)
                .Item.Add(RELAP.App.GetLocalString("Cor"), gobj2, "Color", False, "", RELAP.App.GetLocalString("Cordotexto"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Fonte"), gobj2, "Font", False, "", RELAP.App.GetLocalString("Fontedotexto"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Font)
                End With

            End With

            gobj2 = Nothing
            FormProps.FTSProps.SelectedItem = FormProps.TSObj

        ElseIf gobj.TipoObjeto = TipoObjeto.GO_Figura Then

            Dim gobj2 As EmbeddedImageGraphic = CType(gobj, EmbeddedImageGraphic)

            With Me.FormProps.PGEx2

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True
                .Item.Clear()

                .Item.Add(RELAP.App.GetLocalString("Autodimensionar"), gobj2, RELAP.App.GetLocalString("AutoSize"), False, "", RELAP.App.GetLocalString("SelecioLiquidrueparaque"), True)
                .Item.Add(RELAP.App.GetLocalString("Altura"), gobj2, "Height", False, "", RELAP.App.GetLocalString("Alturadafiguraempixe"), True)
                .Item.Add(RELAP.App.GetLocalString("Largura"), gobj2, "Width", False, "", RELAP.App.GetLocalString("Larguradafiguraempix"), True)
                .Item.Add(RELAP.App.GetLocalString("Rotao"), gobj2, "Rotation", False, "", RELAP.App.GetLocalString("Rotaodafigurade0a360"), True)

            End With

            gobj2 = Nothing
            FormProps.FTSProps.SelectedItem = FormProps.TSObj

        ElseIf gobj.TipoObjeto = TipoObjeto.GO_Animation Then

            Dim gobj2 As EmbeddedAnimationGraphic = CType(gobj, EmbeddedAnimationGraphic)

            With Me.FormProps.PGEx2

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True
                .Item.Clear()

                .Item.Add(RELAP.App.GetLocalString("Autodimensionar"), gobj2, RELAP.App.GetLocalString("AutoSize"), False, "", RELAP.App.GetLocalString("SelecioLiquidrueparaque"), True)
                .Item.Add(RELAP.App.GetLocalString("Altura"), gobj2, "Height", False, "", RELAP.App.GetLocalString("Alturadafiguraempixe"), True)
                .Item.Add(RELAP.App.GetLocalString("Largura"), gobj2, "Width", False, "", RELAP.App.GetLocalString("Larguradafiguraempix"), True)
                .Item.Add(RELAP.App.GetLocalString("Rotao"), gobj2, "Rotation", False, "", RELAP.App.GetLocalString("Rotaodafigurade0a360"), True)

            End With

            gobj2 = Nothing
            FormProps.FTSProps.SelectedItem = FormProps.TSObj

        Else

            With Me.FormProps.PGEx2

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True
                .Item.Clear()

                .Item.Add(RELAP.App.GetLocalString("Nome"), gobj.Tag, False, RELAP.App.GetLocalString("Descrio1"), RELAP.App.GetLocalString("Nomedoobjeto"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Boolean)
                End With

                .Item.Add(RELAP.App.GetLocalString("Gradiente2"), gobj, "GradientMode", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("SelecioLiquidrueparaapl"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Boolean)
                End With
                .Item.Add("Gradiente_Cor1", gobj, "GradientColor1", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Cor1dogradienteseapl"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add("Gradiente_Cor2", gobj, "GradientColor2", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Cor2dogradienteseapl"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("Cor"), gobj, "FillColor", False, RELAP.App.GetLocalString("Aparncia2"), "Cor de fundo, caso o modo de gradiente não esteja ativado", True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Drawing.Color)
                End With
                .Item.Add(RELAP.App.GetLocalString("EspessuradaBorda"), gobj, "LineWidth", False, RELAP.App.GetLocalString("Aparncia2"), RELAP.App.GetLocalString("Espessuradabordadoob"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Int32)
                End With

                .Item.Add(RELAP.App.GetLocalString("Comprimento"), gobj, "Width", False, RELAP.App.GetLocalString("Tamanho3"), RELAP.App.GetLocalString("Comprimentodoobjetoe"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Int32)
                End With
                .Item.Add(RELAP.App.GetLocalString("Altura"), gobj, "Height", False, RELAP.App.GetLocalString("Tamanho3"), RELAP.App.GetLocalString("Alturadoobjetoempixe"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Int32)
                End With
                .Item.Add(RELAP.App.GetLocalString("Rotao"), gobj, "Rotation", False, RELAP.App.GetLocalString("Tamanho3"), RELAP.App.GetLocalString("Rotaodoobjetode0a360"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Int32)
                End With

                .Item.Add("X", gobj, "X", False, RELAP.App.GetLocalString("Coordenadas4"), RELAP.App.GetLocalString("Coordenadahorizontal"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Int32)
                End With
                .Item.Add("Y", gobj, "Y", False, RELAP.App.GetLocalString("Coordenadas4"), RELAP.App.GetLocalString("Coordenadaverticaldo"), True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(System.Int32)
                End With

            End With

            FormProps.FTSProps.SelectedItem = FormProps.TSProps

        End If

        Return 1

    End Function

#End Region

   

   
    Private Sub tsmiGroupComponents_Click(sender As Object, e As EventArgs) Handles tsmiGroupComponents.Click

        '  
        FormSurface.AddSubsytemToSurface(FormSurface.FlowsheetDesignSurface.SelectedObjects.Values(0).X, FormSurface.FlowsheetDesignSurface.SelectedObjects.Values(0).Y)
        For Each gObj In FormSurface.FlowsheetDesignSurface.SelectedObjects.Values



            DeleteObject(gObj.Tag)


            'Collections.UpdateCounter("SubSystem")
            'GetFlowsheetGraphicObject(gObj.Tag)
            ' Collections.SubSystemCollection.Add(gObj.Name, gObj)
            'Collections.TankCollection.Add(gObj.Name, gObj)
            'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes.Add(gObj.Name, gObj.Tag).Name = gObj.Name
            'ChildParent.FormObjList.TreeViewObj.Nodes("NodeTQ").Nodes(gObj.Name).ContextMenuStrip = ChildParent.FormObjList.ContextMenuStrip1
            'OBJETO RELAP
            If gObj.TipoObjeto = TipoObjeto.Tank Then
                Dim myCOTK As RELAP.SimulationObjects.UnitOps.Tank = New RELAP.SimulationObjects.UnitOps.Tank(gObj.Name, "Tanque")
                myCOTK.GraphicObject = gObj

                '  Collections.ObjectCollection.Add(gObj.Name, myCOTK)
                ' Collections.CLCS_SubSystemCollection.Add(gObj.Name, myCOTK)
            End If

            
        Next
    End Sub
End Class

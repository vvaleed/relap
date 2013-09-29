'    Copyright 2008 Daniel Wagner O. de Medeiros
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

'Imports RELAP.SimulationObjects
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports FileHelpers
Imports RELAP.RELAP.ClassesBasicasTermodinamica
Imports System.Runtime.Serialization.Formatters
Imports System.IO
Imports ICSharpCode.SharpZipLib.Core
Imports ICSharpCode.SharpZipLib.Zip
Imports WeifenLuo.WinFormsUI.Docking
'Imports RELAP.RELAP.SimulationObjects.PropertyPackages
Imports System.Runtime.Serialization.Formatters.Binary
Imports LukeSw.Windows.Forms
Imports Infralution.Localization
Imports System.Globalization
Imports RELAP.RELAP.FormClasses

Imports System.Xml.Serialization
Imports System.Xml
Imports System.Reflection
Imports Microsoft.Win32
'Imports RELAP.RELAP.SimulationObjects
Imports System.Text

Public Class FormMain

    Inherits Form
    Public univID As Integer = 0
    Public Shared m_childcount As Integer = 1
    Public filename As String
    Public sairdevez As Boolean = False
    Public SairDiretoERRO As Boolean = False
    Public loadedCSDB As Boolean = False
    Public pathsep As Char

    Public WithEvents FrmLoadSave As New FormLS
    ' Public FrmOptions As FormOptions
    'Public FrmRec As FormRecoverFiles

    Private dropdownlist As ArrayList

    Private dlok As Boolean = False

    Private tmpform2 As FormFlowsheet

    Public AvailableComponents As New Dictionary(Of String, RELAP.ClassesBasicasTermodinamica.ConstantProperties)
    Public AvailableUnitSystems As New Dictionary(Of String, RELAP.SistemasDeUnidades.Unidades)
    ' Public PropertyPackages As New Dictionary(Of String, RELAP.SimulationObjects.PropertyPackages.PropertyPackage)

    'Public UtilityPlugins As New Dictionary(Of String, Interfaces.IUtilityPlugin)
    ' Public COMonitoringObjects As New Dictionary(Of String, RELAP.SimulationObjects.UnitOps.Auxiliary.CapeOpen.CapeOpenUnitOpInfo)

#Region "    Form Events"
    Dim kl As Integer
    Dim kk As Integer
    Dim first1 As Boolean

    Private Sub FormMain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Integer
            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add the files to the list.
            For i = 0 To MyFiles.Length - 1
                Select Case Path.GetExtension(MyFiles(i)).ToLower
                    Case ".RELAP"
                        Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Abrindosimulao") + " " + MyFiles(i) + "..."
                        Application.DoEvents()
                        Me.LoadF(MyFiles(i))

                End Select
            Next
        End If
    End Sub

    Private Sub FormMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub FormParent_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not Me.SairDiretoERRO Then
            If Me.MdiChildren.Length > 0 Then
                Dim ms As MsgBoxResult = VDialog.Show(RELAP.App.GetLocalString("Existemsimulaesabert"), RELAP.App.GetLocalString("Ateno"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If ms = MsgBoxResult.No Then e.Cancel = True
            End If
        End If

        'If My.Settings.ShowDonateForm Then
        '    Dim fd As New FormDonate
        '    fd.ShowDialog(Me)
        'End If

        'Check if RELAP is running in Portable mode, then save settings to file.
        If File.Exists(My.Application.Info.DirectoryPath & Path.DirectorySeparatorChar & "default.ini") Then
            RELAP.App.SaveSettings()
            My.Application.SaveMySettingsOnExit = False
        Else
            My.Application.SaveMySettingsOnExit = True
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Settings.BackupFolder = "" Then My.Settings.BackupFolder = My.Computer.FileSystem.SpecialDirectories.Temp & "\RELAP"
        If My.Settings.BackupActivated Then
            Me.TimerBackup.Interval = My.Settings.BackupInterval * 60000
            Me.TimerBackup.Enabled = True
        End If

        Me.Text = RELAP.App.GetLocalString("FormParent_FormText") '& My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & " Beta" '& " [" & My.Application.Culture.EnglishName & ", DC " & My.Computer.FileSystem.GetFileInfo(My.Application.Info.DirectoryPath & "\RELAP.exe").LastWriteTimeUtc & " UTC]"

        Global.EWSoftware.StatusBarText.StatusBarTextProvider.ApplicationStatusBar = Me.ToolStripStatusLabel1

        Me.StatusBarTextProvider1.InstanceStatusBar = Me.ToolStripStatusLabel1

        Me.dropdownlist = New ArrayList
        Me.UpdateMRUList()

        'load plugins from 'Plugins' folder

        'Dim pluginlist As List(Of Interfaces.IUtilityPlugin) = GetPlugins(LoadPluginAssemblies())

        'For Each ip As Interfaces.IUtilityPlugin In pluginlist
        '    Me.UtilityPlugins.Add(ip.UniqueID, ip)
        'Next

        ''load external property packages from 'propertypackages' folder, if there is any
        'Dim epplist As List(Of PropertyPackage) = GetExternalPPs(LoadExternalPPs())

        'For Each pp As PropertyPackage In epplist
        '    PropertyPackages.Add(pp.ComponentName, pp)
        'Next

        'Search and populate CAPE-OPEN Flowsheet Monitoring Object collection
        'SearchCOMOs() 'doing this only when the user hovers the mouse over the plugins toolstrip menu item

        If My.Settings.ScriptPaths Is Nothing Then My.Settings.ScriptPaths = New Collections.Specialized.StringCollection()

    End Sub

    'Sub SearchCOMOs()

    '    Dim keys As String() = My.Computer.Registry.ClassesRoot.OpenSubKey("CLSID", False).GetSubKeyNames()

    '    For Each k In keys
    '        Dim mykey As RegistryKey = My.Computer.Registry.ClassesRoot.OpenSubKey("CLSID", False).OpenSubKey(k, False)
    '        Dim mykeys As String() = mykey.GetSubKeyNames()
    '        For Each s As String In mykeys
    '            If s = "Implemented Categories" Then
    '                Dim arr As Array = mykey.OpenSubKey("Implemented Categories").GetSubKeyNames()
    '                For Each s2 As String In arr
    '                    If s2.ToLower = "{7ba1af89-b2e4-493d-bd80-2970bf4cbe99}" Then
    '                        'this is a CAPE-OPEN MO
    '                        Dim myuo As New RELAP.SimulationObjects.UnitOps.Auxiliary.CapeOpen.CapeOpenUnitOpInfo
    '                        With myuo
    '                            .AboutInfo = mykey.OpenSubKey("CapeDescription").GetValue("About")
    '                            .CapeVersion = mykey.OpenSubKey("CapeDescription").GetValue("CapeVersion")
    '                            .Description = mykey.OpenSubKey("CapeDescription").GetValue("Description")
    '                            .HelpURL = mykey.OpenSubKey("CapeDescription").GetValue("HelpURL")
    '                            .Name = mykey.OpenSubKey("CapeDescription").GetValue("Name")
    '                            .VendorURL = mykey.OpenSubKey("CapeDescription").GetValue("VendorURL")
    '                            .Version = mykey.OpenSubKey("CapeDescription").GetValue("ComponentVersion")
    '                            Try
    '                                .TypeName = mykey.OpenSubKey("ProgID").GetValue("")
    '                            Catch ex As Exception
    '                            End Try
    '                            Try
    '                                .Location = mykey.OpenSubKey("InProcServer32").GetValue("")
    '                            Catch ex As Exception
    '                                .Location = mykey.OpenSubKey("LocalServer32").GetValue("")
    '                            End Try
    '                        End With
    '                        Me.COMonitoringObjects.Add(myuo.TypeName, myuo)
    '                    End If
    '                Next
    '            End If
    '        Next
    '        mykey.Close()
    '    Next

    'End Sub

    Private Function LoadPluginAssemblies() As List(Of Assembly)

        Dim pluginassemblylist As List(Of Assembly) = New List(Of Assembly)

        If Directory.Exists(Path.Combine(Environment.CurrentDirectory, "plugins")) Then

            Dim dinfo As New DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "plugins"))

            Dim files() As FileInfo = dinfo.GetFiles("*.dll")

            If Not files Is Nothing Then
                For Each fi As FileInfo In files
                    pluginassemblylist.Add(Assembly.LoadFile(fi.FullName))
                Next
            End If

        End If

        Return pluginassemblylist

    End Function

    'Function GetPlugins(ByVal alist As List(Of Assembly)) As List(Of Interfaces.IUtilityPlugin)

    '    Dim availableTypes As New List(Of Type)()

    '    For Each currentAssembly As Assembly In alist
    '        Try
    '            availableTypes.AddRange(currentAssembly.GetTypes())
    '        Catch ex As ReflectionTypeLoadException
    '            Dim errstr As New StringBuilder()
    '            For Each lex As Exception In ex.LoaderExceptions
    '                errstr.AppendLine(lex.ToString)
    '            Next
    '            VDialog.Show(errstr.ToString, "Error loading plugin", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    Next

    '    Dim pluginlist As List(Of Type) = availableTypes.FindAll(AddressOf isPlugin)

    '    Return pluginlist.ConvertAll(Of Interfaces.IUtilityPlugin)(Function(t As Type) TryCast(Activator.CreateInstance(t), Interfaces.IUtilityPlugin))

    'End Function

    'Function isPlugin(ByVal t As Type)
    '    Dim interfaceTypes As New List(Of Type)(t.GetInterfaces())
    '    Return (interfaceTypes.Contains(GetType(Interfaces.IUtilityPlugin)))
    'End Function

    'Private Function LoadExternalPPs() As List(Of Assembly)

    '    Dim pluginassemblylist As List(Of Assembly) = New List(Of Assembly)

    '    If Directory.Exists(Path.Combine(Environment.CurrentDirectory, "propertypackages")) Then

    '        Dim dinfo As New DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "propertypackages"))

    '        Dim files() As FileInfo = dinfo.GetFiles("*.dll")

    '        If Not files Is Nothing Then
    '            For Each fi As FileInfo In files
    '                pluginassemblylist.Add(Assembly.LoadFile(fi.FullName))
    '            Next
    '        End If

    '    End If

    '    Return pluginassemblylist

    'End Function

    'Function GetExternalPPs(ByVal alist As List(Of Assembly)) As List(Of PropertyPackage)

    '    Dim availableTypes As New List(Of Type)()

    '    For Each currentAssembly As Assembly In alist
    '        Try
    '            availableTypes.AddRange(currentAssembly.GetTypes())
    '        Catch ex As Exception
    '            VDialog.Show(ex.Message.ToCharArray, "Error loading plugin", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    Next

    '    Dim ppList As List(Of Type) = availableTypes.FindAll(AddressOf isPP)

    '    Return ppList.ConvertAll(Of PropertyPackage)(Function(t As Type) TryCast(Activator.CreateInstance(t), PropertyPackage))

    'End Function

    'Function isPP(ByVal t As Type)
    '    Return (t Is GetType(PropertyPackage))
    'End Function

    Private Sub UpdateMRUList()

        'process MRU file list

        If My.Settings.MostRecentFiles.Count > 10 Then
            My.Settings.MostRecentFiles.RemoveAt(0)
        End If

        Dim j As Integer = 0
        For Each k As String In Me.dropdownlist
            Dim tsmi As ToolStripItem = Me.FileToolStripMenuItem.DropDownItems(CInt(k - j))
            If tsmi.DisplayStyle = ToolStripItemDisplayStyle.Text Or TypeOf tsmi Is ToolStripSeparator Then
                Me.FileToolStripMenuItem.DropDownItems.Remove(tsmi)
                j = j + 1
            End If
        Next

        Me.dropdownlist.Clear()

        If Not My.Settings.MostRecentFiles Is Nothing Then
            For Each str As String In My.Settings.MostRecentFiles
                Dim tsmi As New ToolStripMenuItem
                With tsmi
                    .Text = str
                    .Tag = str
                    .DisplayStyle = ToolStripItemDisplayStyle.Text
                End With
                Me.FileToolStripMenuItem.DropDownItems.Insert(Me.FileToolStripMenuItem.DropDownItems.Count - 1, tsmi)
                Me.dropdownlist.Add(Me.FileToolStripMenuItem.DropDownItems.Count - 2)
                AddHandler tsmi.Click, AddressOf Me.OpenRecent_click
            Next
            If My.Settings.MostRecentFiles.Count > 0 Then
                Me.FileToolStripMenuItem.DropDownItems.Insert(Me.FileToolStripMenuItem.DropDownItems.Count - 1, New ToolStripSeparator())
                Me.dropdownlist.Add(Me.FileToolStripMenuItem.DropDownItems.Count - 2)
            End If
        Else
            My.Settings.MostRecentFiles = New System.Collections.Specialized.StringCollection
        End If
    End Sub

    'Sub AddPropPacks()

    '    Dim FPP As FPROPSPropertyPackage = New FPROPSPropertyPackage()
    '    FPP.ComponentName = RELAP.App.GetLocalString("FPP")
    '    FPP.ComponentDescription = RELAP.App.GetLocalString("DescFPP")
    '    PropertyPackages.Add(FPP.ComponentName.ToString, FPP)

    '    Dim STPP As SteamTablesPropertyPackage = New SteamTablesPropertyPackage()
    '    STPP.ComponentName = RELAP.App.GetLocalString("TabelasdeVaporSteamT")
    '    STPP.ComponentDescription = RELAP.App.GetLocalString("DescSteamTablesPP")
    '    PropertyPackages.Add(STPP.ComponentName.ToString, STPP)

    '    Dim PCSAFTPP As PCSAFTPropertyPackage = New PCSAFTPropertyPackage()
    '    PCSAFTPP.ComponentName = "PC-SAFT"
    '    PCSAFTPP.ComponentDescription = RELAP.App.GetLocalString("DescPCSAFTPP")
    '    PropertyPackages.Add(PCSAFTPP.ComponentName.ToString, PCSAFTPP)

    '    Dim PRPP As PengRobinsonPropertyPackage = New PengRobinsonPropertyPackage()
    '    PRPP.ComponentName = "Peng-Robinson (PR)"
    '    PRPP.ComponentDescription = RELAP.App.GetLocalString("DescPengRobinsonPP")
    '    PropertyPackages.Add(PRPP.ComponentName.ToString, PRPP)

    '    Dim PRSV2PP As PRSV2PropertyPackage = New PRSV2PropertyPackage()
    '    PRSV2PP.ComponentName = "Peng-Robinson-Stryjek-Vera 2 (PRSV2-M)"
    '    PRSV2PP.ComponentDescription = RELAP.App.GetLocalString("DescPRSV2PP")
    '    PropertyPackages.Add(PRSV2PP.ComponentName.ToString, PRSV2PP)

    '    Dim PRSV2PPVL As PRSV2VLPropertyPackage = New PRSV2VLPropertyPackage()
    '    PRSV2PPVL.ComponentName = "Peng-Robinson-Stryjek-Vera 2 (PRSV2-VL)"
    '    PRSV2PPVL.ComponentDescription = RELAP.App.GetLocalString("DescPRSV2VLPP")
    '    PropertyPackages.Add(PRSV2PPVL.ComponentName.ToString, PRSV2PPVL)

    '    Dim PRIWVTPP As PengRobinsonIWVTPropertyPackage = New PengRobinsonIWVTPropertyPackage()
    '    PRIWVTPP.ComponentName = RELAP.App.GetLocalString("PRIWVT")
    '    PRIWVTPP.ComponentDescription = RELAP.App.GetLocalString("DescPengRobinsonIWVTPP")
    '    PropertyPackages.Add(PRIWVTPP.ComponentName.ToString, PRIWVTPP)

    '    Dim SRKPP As SRKPropertyPackage = New SRKPropertyPackage()
    '    SRKPP.ComponentName = "Soave-Redlich-Kwong (SRK)"
    '    SRKPP.ComponentDescription = RELAP.App.GetLocalString("DescSoaveRedlichKwongSRK")
    '    PropertyPackages.Add(SRKPP.ComponentName.ToString, SRKPP)

    '    Dim PRLKPP As PengRobinsonLKPropertyPackage = New PengRobinsonLKPropertyPackage()
    '    PRLKPP.ComponentName = "Peng-Robinson / Lee-Kesler (PR/LK)"
    '    PRLKPP.ComponentDescription = RELAP.App.GetLocalString("DescPRLK")

    '    PropertyPackages.Add(PRLKPP.ComponentName.ToString, PRLKPP)

    '    Dim UPP As UNIFACPropertyPackage = New UNIFACPropertyPackage()
    '    UPP.ComponentName = "UNIFAC"
    '    UPP.ComponentDescription = RELAP.App.GetLocalString("DescUPP")

    '    PropertyPackages.Add(UPP.ComponentName.ToString, UPP)

    '    Dim ULLPP As UNIFACLLPropertyPackage = New UNIFACLLPropertyPackage()
    '    ULLPP.ComponentName = "UNIFAC-LL"
    '    ULLPP.ComponentDescription = RELAP.App.GetLocalString("DescUPP")

    '    PropertyPackages.Add(ULLPP.ComponentName.ToString, ULLPP)

    '    Dim MUPP As MODFACPropertyPackage = New MODFACPropertyPackage()
    '    MUPP.ComponentName = "Modified UNIFAC (Dortmund)"
    '    MUPP.ComponentDescription = RELAP.App.GetLocalString("DescMUPP")

    '    PropertyPackages.Add(MUPP.ComponentName.ToString, MUPP)

    '    Dim NRTLPP As NRTLPropertyPackage = New NRTLPropertyPackage()
    '    NRTLPP.ComponentName = "NRTL"
    '    NRTLPP.ComponentDescription = RELAP.App.GetLocalString("DescNRTLPP")

    '    PropertyPackages.Add(NRTLPP.ComponentName.ToString, NRTLPP)

    '    Dim UQPP As UNIQUACPropertyPackage = New UNIQUACPropertyPackage()
    '    UQPP.ComponentName = "UNIQUAC"
    '    UQPP.ComponentDescription = RELAP.App.GetLocalString("DescUNIQUACPP")

    '    PropertyPackages.Add(UQPP.ComponentName.ToString, UQPP)

    '    Dim CSLKPP As ChaoSeaderPropertyPackage = New ChaoSeaderPropertyPackage()
    '    CSLKPP.ComponentName = "Chao-Seader"
    '    CSLKPP.ComponentDescription = RELAP.App.GetLocalString("DescCSLKPP")

    '    PropertyPackages.Add(CSLKPP.ComponentName.ToString, CSLKPP)

    '    Dim GSLKPP As GraysonStreedPropertyPackage = New GraysonStreedPropertyPackage()
    '    GSLKPP.ComponentName = "Grayson-Streed"
    '    GSLKPP.ComponentDescription = RELAP.App.GetLocalString("DescGSLKPP")

    '    PropertyPackages.Add(GSLKPP.ComponentName.ToString, GSLKPP)

    '    Dim RPP As RaoultPropertyPackage = New RaoultPropertyPackage()
    '    RPP.ComponentName = RELAP.App.GetLocalString("LeideRaoultGsSoluoId")
    '    RPP.ComponentDescription = RELAP.App.GetLocalString("DescRPP")

    '    PropertyPackages.Add(RPP.ComponentName.ToString, RPP)

    '    Dim LKPPP As LKPPropertyPackage = New LKPPropertyPackage()
    '    LKPPP.ComponentName = "Lee-Kesler-Plöcker"
    '    LKPPP.ComponentDescription = RELAP.App.GetLocalString("DescLKPPP")

    '    PropertyPackages.Add(LKPPP.ComponentName.ToString, LKPPP)

    '    'Check if RELAP is running in Portable mode, if not then load the COSMO-SAC Property Package.
    '    If Not File.Exists(My.Application.Info.DirectoryPath & Path.DirectorySeparatorChar & "default.ini") Then

    '        Dim CSPP As COSMOSACPropertyPackage = New COSMOSACPropertyPackage()
    '        CSPP.ComponentName = "COSMO-SAC (JCOSMO)"
    '        CSPP.ComponentDescription = RELAP.App.GetLocalString("DescCSPP")

    '        PropertyPackages.Add(CSPP.ComponentName.ToString, CSPP)

    '    End If

    '    Dim COPP As CAPEOPENPropertyPackage = New CAPEOPENPropertyPackage()
    '    COPP.ComponentName = "CAPE-OPEN"
    '    COPP.ComponentDescription = RELAP.App.GetLocalString("DescCOPP")

    '    PropertyPackages.Add(COPP.ComponentName.ToString, COPP)

    'End Sub

    Private Sub FormParent_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        If Me.MdiChildren.Length >= 1 Then
            Me.ToolStripButton1.Enabled = True
            Me.SaveAllToolStripButton.Enabled = True
            Me.SaveToolStripButton.Enabled = True
            Me.SaveToolStripMenuItem.Enabled = True
            Me.SaveAllToolStripMenuItem.Enabled = True
            Me.SaveAsToolStripMenuItem.Enabled = True
            Me.ToolStripButton1.Enabled = True
            Me.CloseAllToolstripMenuItem.Enabled = True
            If Not Me.ActiveMdiChild Is Nothing Then
                If TypeOf Me.ActiveMdiChild Is FormFlowsheet Then My.Application.ActiveSimulation = Me.ActiveMdiChild
            End If
        End If
    End Sub

    Private Sub FormParent_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Dim cmdLine() As String = System.Environment.GetCommandLineArgs()
        If UBound(cmdLine) = 1 And Not cmdLine(0).StartsWith("-") Then
            Try
                Me.filename = cmdLine(1)
                Try
                    Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Abrindosimulao") + " (" + Me.filename + ")"
                    Application.DoEvents()
                    Select Case Path.GetExtension(Me.filename).ToLower()
                        Case ".RELAP"
                            Me.LoadF(Me.filename)
                            'Case ".dwcsd"
                            '    Dim NewMDIChild As New FormCompoundCreator()
                            '    NewMDIChild.MdiParent = Me
                            '    NewMDIChild.Show()
                            '    Dim objStreamReader As New FileStream(Me.filename, FileMode.Open)
                            '    Dim x As New BinaryFormatter()
                            '    NewMDIChild.mycase = x.Deserialize(objStreamReader)
                            '    objStreamReader.Close()
                            '    NewMDIChild.WriteData()
                            'Case ".dwrsd"
                            '    Dim NewMDIChild As New FormDataRegression()
                            '    NewMDIChild.MdiParent = Me
                            '    NewMDIChild.Show()
                            '    Dim objStreamReader As New FileStream(Me.filename, FileMode.Open)
                            '    Dim x As New BinaryFormatter()
                            '    NewMDIChild.currcase = x.Deserialize(objStreamReader)
                            '    objStreamReader.Close()
                            '    NewMDIChild.LoadCase(NewMDIChild.currcase, False)
                    End Select
                Catch ex As Exception
                    VDialog.Show(RELAP.App.GetLocalString("Erroaoabrirarquivo") & " " & ex.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Me.ToolStripStatusLabel1.Text = ""
                End Try
            Catch ex As Exception
                VDialog.Show(ex.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'If My.Settings.BackupFiles.Count > 0 Then
            '    Me.FrmRec = New FormRecoverFiles
            '    Me.FrmRec.ShowDialog(Me)
            'Else
            '    If My.Settings.ShowTips Then
            '        Dim frmw As New FormWelcome
            '        frmw.ShowDialog(Me)
            '    End If
            'End If

        End If

        'check for updates
        ' If My.Settings.CheckForUpdates Then Me.bgUpdater.RunWorkerAsync()

    End Sub

#End Region

#Region "    Load Databases / Property Packages"

    Private Function GetComponents()

        'try to find chemsep xml database
        If File.Exists(My.Application.Info.DirectoryPath & Path.DirectorySeparatorChar & "default.ini") Then
            'PORTABLE MODE
            My.Settings.ChemSepDatabasePath = My.Application.Info.DirectoryPath & Path.DirectorySeparatorChar & "chemsepdb" & Path.DirectorySeparatorChar & "chemsep1.xml"
        Else
            Try
                Dim cspath As String = My.Computer.Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("ChemSepL").GetValue("")
                cspath += Path.DirectorySeparatorChar + "pcd" + Path.DirectorySeparatorChar + "chemsep1.xml"
                If File.Exists(cspath) Then
                    My.Settings.ChemSepDatabasePath = cspath
                End If
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
            End Try
        End If

        Try
            'load chempsep database, if existent
            '  If File.Exists(My.Settings.ChemSepDatabasePath) Then Me.LoadCSDB(My.Settings.ChemSepDatabasePath)
        Catch ex As Exception
            VDialog.Show(ex.ToString, "Error loading ChemSep database")
        End Try

        'load RELAP XML database
        '  Me.LoadRELAPDB(My.Application.Info.DirectoryPath & pathsep & "data" & pathsep & "databases" & pathsep & "RELAP.xml")

        'load Biodiesel XML database
        'Me.LoadBDDB(My.Application.Info.DirectoryPath & pathsep & "data" & pathsep & "databases" & pathsep & "biod_db.xml")

        Dim invaliddbs As New List(Of String)

        'load user databases
        'For Each fpath As String In My.Settings.UserDatabases
        '    Try
        '        Dim componentes As ConstantProperties()
        '        componentes = RELAP.Databases.UserDB.Read(fpath)
        '        If componentes.Length > 0 Then
        '            If My.Settings.ReplaceComps Then
        '                For Each c As ConstantProperties In componentes
        '                    If Not Me.AvailableComponents.ContainsKey(c.Name) Then
        '                        Me.AvailableComponents.Add(c.Name, c)
        '                    Else
        '                        Me.AvailableComponents(c.Name) = c
        '                    End If
        '                Next
        '            Else
        '                For Each c As ConstantProperties In componentes
        '                    If Not Me.AvailableComponents.ContainsKey(c.Name) Then
        '                        Me.AvailableComponents.Add(c.Name, c)
        '                    End If
        '                Next
        '            End If
        '        End If
        '    Catch ex As System.Runtime.Serialization.SerializationException
        '        invaliddbs.Add(fpath)
        '    Catch ex As FileNotFoundException
        '        invaliddbs.Add(fpath)
        '    End Try
        'Next

        'remove non-existent or broken user databases from the list
        For Each str As String In invaliddbs
            My.Settings.UserDatabases.Remove(str)
        Next

        Return Nothing

    End Function

    'Public Sub LoadCSDB(ByVal filename As String)
    '    If File.Exists(filename) Then
    '        Dim csdb As New RELAP.Databases.ChemSep
    '        Dim cpa() As RELAP.ClassesBasicasTermodinamica.ConstantProperties
    '        csdb.Load(filename)
    '        cpa = csdb.Transfer()
    '        For Each cp As RELAP.ClassesBasicasTermodinamica.ConstantProperties In cpa
    '            If Not Me.AvailableComponents.ContainsKey(cp.Name) Then Me.AvailableComponents.Add(cp.Name, cp)
    '        Next
    '        loadedCSDB = True
    '    End If
    'End Sub

    'Public Sub LoadRELAPDB(ByVal filename As String)
    '    If File.Exists(filename) Then
    '        Dim dwdb As New RELAP.Databases.RELAP
    '        Dim cpa() As RELAP.ClassesBasicasTermodinamica.ConstantProperties
    '        'Try
    '        dwdb.Load(filename)
    '        cpa = dwdb.Transfer()
    '        For Each cp As RELAP.ClassesBasicasTermodinamica.ConstantProperties In cpa
    '            If Not Me.AvailableComponents.ContainsKey(cp.Name) Then Me.AvailableComponents.Add(cp.Name, cp)
    '        Next
    '        'Catch ex As Exception
    '        'End Try
    '    End If
    'End Sub

    'Public Sub LoadBDDB(ByVal filename As String)
    '    If File.Exists(filename) Then
    '        Dim bddb As New RELAP.Databases.Biodiesel
    '        Dim cpa() As RELAP.ClassesBasicasTermodinamica.ConstantProperties
    '        'Try
    '        bddb.Load(filename)
    '        cpa = bddb.Transfer()
    '        For Each cp As RELAP.ClassesBasicasTermodinamica.ConstantProperties In cpa
    '            If Not Me.AvailableComponents.ContainsKey(cp.Name) Then Me.AvailableComponents.Add(cp.Name, cp)
    '        Next
    '        'Catch ex As Exception
    '        'End Try
    '    End If
    'End Sub

    'Public Function CopyPropertyPackages() As Object

    '    Dim col As New System.Collections.Generic.Dictionary(Of String, RELAP.SimulationObjects.PropertyPackages.PropertyPackage)

    '    For Each pp As PropertyPackage In Me.PropertyPackages.Values
    '        col.Add(pp.ComponentName, CType(pp.Clone, PropertyPackage))
    '    Next

    '    Return col

    'End Function

#End Region

#Region "    Open/Save Files"

    'Shared Sub SaveState(ByRef flowsheet As FormFlowsheet)

    '    Dim st As New FlowsheetState()

    '    Dim rect As Rectangle = New Rectangle(0, 0, flowsheet.FormSurface.FlowsheetDesignSurface.Width - 14, flowsheet.FormSurface.FlowsheetDesignSurface.Height - 14)
    '    st.Snapshot = New Bitmap(rect.Width, rect.Height)
    '    flowsheet.FormSurface.FlowsheetDesignSurface.DrawToBitmap(st.Snapshot, flowsheet.FormSurface.FlowsheetDesignSurface.Bounds)

    '    Dim fs As New FormState
    '    fs.TextBox2.Text = Date.Now.ToString
    '    fs.TextBox1.Text = "state_" & Date.Now.ToString
    '    fs.PictureBox1.Image = st.Snapshot

    '    fs.btnOK.Text = RELAP.App.GetLocalString("SaveState")

    '    If fs.ShowDialog(flowsheet) = Windows.Forms.DialogResult.OK Then

    '        Dim frmwait As New FormLS

    '        Try

    '            frmwait.Show(flowsheet)

    '            Application.DoEvents()

    '            Dim mySerializer As Binary.BinaryFormatter = New Binary.BinaryFormatter(Nothing, New System.Runtime.Serialization.StreamingContext())

    '            Using stream As New MemoryStream()
    '                mySerializer.Serialize(stream, flowsheet.Collections)
    '                st.Collections = stream.ToArray()
    '            End Using

    '            Application.DoEvents()

    '            Using stream As New MemoryStream()
    '                mySerializer.Serialize(stream, flowsheet.FormSurface.FlowsheetDesignSurface.drawingObjects)
    '                st.GraphicObjects = stream.ToArray()
    '            End Using

    '            Application.DoEvents()

    '            Using stream As New MemoryStream()
    '                mySerializer.Serialize(stream, flowsheet.Options)
    '                st.Options = stream.ToArray()
    '            End Using

    '            Using stream As New MemoryStream()
    '                TreeViewDataAccess.SaveTreeViewData(flowsheet.FormObjList.TreeViewObj, stream)
    '                st.TreeViewObjects = stream.ToArray()
    '            End Using

    '            Application.DoEvents()

    '            flowsheet.FormSpreadsheet.CopyToDT()

    '            Using stream As New MemoryStream()
    '                mySerializer.Serialize(stream, flowsheet.FormSpreadsheet.dt1)
    '                st.SpreadsheetDT1 = stream.ToArray()
    '                mySerializer.Serialize(stream, flowsheet.FormSpreadsheet.dt2)
    '                st.SpreadsheetDT1 = stream.ToArray()
    '            End Using

    '            Application.DoEvents()

    '            Using stream As New MemoryStream()
    '                mySerializer.Serialize(stream, flowsheet.FormSpreadsheet.dt2)
    '                st.SpreadsheetDT1 = stream.ToArray()
    '            End Using

    '            Application.DoEvents()

    '            Using stream As New MemoryStream()
    '                mySerializer.Serialize(stream, flowsheet.FormWatch.items)
    '                st.WatchItems = stream.ToArray()
    '            End Using

    '            Application.DoEvents()

    '            If flowsheet.FlowsheetStates Is Nothing Then
    '                flowsheet.FlowsheetStates = New Dictionary(Of Date, FlowsheetState)
    '            End If

    '            st.Description = fs.TextBox1.Text

    '            st.SaveDate = Date.Now

    '            flowsheet.FlowsheetStates.Add(st.SaveDate, st)

    '            flowsheet.UpdateStateList()

    '            flowsheet.WriteToLog(RELAP.App.GetLocalString("SaveStateOK"), Color.Blue, TipoAviso.Informacao)

    '        Catch ex As Exception

    '            flowsheet.WriteToLog(RELAP.App.GetLocalString("SaveStateError") & " " & ex.Message.ToString, Color.Red, TipoAviso.Erro)

    '            st = Nothing

    '        Finally

    '            frmwait.Close()

    '        End Try

    '    End If

    'End Sub

    'Shared Sub RestoreState(ByRef flowsheet As FormFlowsheet, ByVal st As FlowsheetState)

    '    Dim fs As New FormState
    '    fs.TextBox1.Enabled = False
    '    fs.TextBox2.Enabled = False
    '    fs.TextBox2.Text = st.SaveDate
    '    fs.TextBox1.Text = st.Description
    '    fs.PictureBox1.Image = st.Snapshot

    '    fs.btnOK.Text = RELAP.App.GetLocalString("RestoreState")

    '    If fs.ShowDialog(flowsheet) = Windows.Forms.DialogResult.OK Then

    '        Dim frmwait As New FormLS

    '        Try

    '            frmwait.Show(flowsheet)

    '            Application.DoEvents()

    '            flowsheet.SuspendLayout()

    '            Dim mySerializer As Binary.BinaryFormatter = New Binary.BinaryFormatter(Nothing, New System.Runtime.Serialization.StreamingContext())

    '            Using stream As New MemoryStream(st.GraphicObjects)
    '                flowsheet.FormSurface.FlowsheetDesignSurface.m_drawingObjects = Nothing
    '                flowsheet.FormSurface.FlowsheetDesignSurface.m_drawingObjects = DirectCast(mySerializer.Deserialize(stream), Microsoft.Msdn.Samples.GraphicObjects.GraphicObjectCollection)
    '            End Using

    '            Application.DoEvents()

    '            Using stream As New MemoryStream(st.Collections)
    '                flowsheet.Collections = Nothing
    '                flowsheet.Collections = DirectCast(mySerializer.Deserialize(stream), RELAP.FormClasses.ClsObjectCollections)
    '            End Using

    '            Application.DoEvents()

    '            Using stream As New MemoryStream(st.Options)
    '                flowsheet.Options = Nothing
    '                flowsheet.Options = DirectCast(mySerializer.Deserialize(stream), RELAP.FormClasses.ClsFormOptions)
    '            End Using

    '            Application.DoEvents()

    '            Using stream As New MemoryStream(st.TreeViewObjects)
    '                flowsheet.FormObjList.TreeViewObj.Nodes.Clear()
    '                TreeViewDataAccess.LoadTreeViewData(flowsheet.FormObjList.TreeViewObj, stream)
    '            End Using

    '            Application.DoEvents()

    '            If Not st.SpreadsheetDT1 Is Nothing Then
    '                Using stream As New MemoryStream(st.SpreadsheetDT1)
    '                    flowsheet.FormSpreadsheet.dt1 = DirectCast(mySerializer.Deserialize(stream), Object(,))
    '                End Using
    '            End If

    '            Application.DoEvents()

    '            If Not st.SpreadsheetDT2 Is Nothing Then
    '                Using stream As New MemoryStream(st.SpreadsheetDT2)
    '                    flowsheet.FormSpreadsheet.dt2 = DirectCast(mySerializer.Deserialize(stream), Object(,))
    '                End Using
    '            End If

    '            Application.DoEvents()

    '            Using stream As New MemoryStream(st.WatchItems)
    '                flowsheet.FormWatch.items = DirectCast(mySerializer.Deserialize(stream), Dictionary(Of Integer, RELAP.Outros.WatchItem))
    '                flowsheet.FormWatch.PopulateList()
    '            End Using

    '            Application.DoEvents()

    '            flowsheet.CheckCollections()

    '            Application.DoEvents()

    '            With flowsheet.Collections
    '                Dim gObj As Microsoft.Msdn.Samples.GraphicObjects.GraphicObject
    '                For Each gObj In flowsheet.FormSurface.FlowsheetDesignSurface.drawingObjects
    '                    Select Case gObj.TipoObjeto
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Compressor
    '                            .CLCS_CompressorCollection(gObj.Name).GraphicObject = gObj
    '                            .CompressorCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Cooler
    '                            .CLCS_CoolerCollection(gObj.Name).GraphicObject = gObj
    '                            .CoolerCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.EnergyStream
    '                            .CLCS_EnergyStreamCollection(gObj.Name).GraphicObject = gObj
    '                            .EnergyStreamCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Heater
    '                            .CLCS_HeaterCollection(gObj.Name).GraphicObject = gObj
    '                            .HeaterCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.MaterialStream
    '                            .CLCS_MaterialStreamCollection(gObj.Name).GraphicObject = gObj
    '                            .MaterialStreamCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.NodeEn
    '                            .CLCS_EnergyMixerCollection(gObj.Name).GraphicObject = gObj
    '                            .MixerENCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.NodeIn
    '                            .CLCS_MixerCollection(gObj.Name).GraphicObject = gObj
    '                            .MixerCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.NodeOut
    '                            .CLCS_SplitterCollection(gObj.Name).GraphicObject = gObj
    '                            .SplitterCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Pipe
    '                            .CLCS_PipeCollection(gObj.Name).GraphicObject = gObj
    '                            .PipeCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Pump
    '                            .CLCS_PumpCollection(gObj.Name).GraphicObject = gObj
    '                            .PumpCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Tank
    '                            .CLCS_TankCollection(gObj.Name).GraphicObject = gObj
    '                            .TankCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.FuelRod
    '                            .CLCS_TankCollection(gObj.Name).GraphicObject = gObj
    '                            .TankCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Expander
    '                            .CLCS_TurbineCollection(gObj.Name).GraphicObject = gObj
    '                            .TurbineCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Valve
    '                            .CLCS_ValveCollection(gObj.Name).GraphicObject = gObj
    '                            .ValveCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Vessel
    '                            .CLCS_VesselCollection(gObj.Name).GraphicObject = gObj
    '                            .SeparatorCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.GO_Tabela
    '                            .ObjectCollection(gObj.Tag).Tabela = gObj
    '                            CType(gObj, RELAP.GraphicObjects.TableGraphic).BaseOwner = .ObjectCollection(gObj.Tag)
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.Expander
    '                            .CLCS_TurbineCollection(gObj.Name).GraphicObject = gObj
    '                            .TurbineCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.OT_Ajuste
    '                            .CLCS_AdjustCollection(gObj.Name).GraphicObject = gObj
    '                            .AdjustCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.OT_Reciclo
    '                            .CLCS_RecycleCollection(gObj.Name).GraphicObject = gObj
    '                            .RecycleCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.OT_Especificacao
    '                            .CLCS_SpecCollection(gObj.Name).GraphicObject = gObj
    '                            .SpecCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.RCT_Conversion
    '                            .CLCS_ReactorConversionCollection(gObj.Name).GraphicObject = gObj
    '                            .ReactorConversionCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.RCT_Equilibrium
    '                            .CLCS_ReactorEquilibriumCollection(gObj.Name).GraphicObject = gObj
    '                            .ReactorEquilibriumCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.RCT_Gibbs
    '                            .CLCS_ReactorGibbsCollection(gObj.Name).GraphicObject = gObj
    '                            .ReactorGibbsCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.RCT_CSTR
    '                            .CLCS_ReactorCSTRCollection(gObj.Name).GraphicObject = gObj
    '                            .ReactorCSTRCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.RCT_PFR
    '                            .CLCS_ReactorPFRCollection(gObj.Name).GraphicObject = gObj
    '                            .ReactorPFRCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.HeatStructure
    '                            .CLCS_HeatStructureCollection(gObj.Name).GraphicObject = gObj
    '                            .HeatStructureCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.ShortcutColumn
    '                            .CLCS_ShortcutColumnCollection(gObj.Name).GraphicObject = gObj
    '                            .ShortcutColumnCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.DistillationColumn
    '                            .CLCS_DistillationColumnCollection(gObj.Name).GraphicObject = gObj
    '                            .DistillationColumnCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.AbsorptionColumn
    '                            .CLCS_AbsorptionColumnCollection(gObj.Name).GraphicObject = gObj
    '                            .AbsorptionColumnCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.RefluxedAbsorber
    '                            .CLCS_RefluxedAbsorberCollection(gObj.Name).GraphicObject = gObj
    '                            .RefluxedAbsorberCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.ReboiledAbsorber
    '                            .CLCS_ReboiledAbsorberCollection(gObj.Name).GraphicObject = gObj
    '                            .ReboiledAbsorberCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.OT_EnergyRecycle
    '                            .CLCS_EnergyRecycleCollection(gObj.Name).GraphicObject = gObj
    '                            .EnergyRecycleCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.GO_TabelaRapida
    '                            .ObjectCollection(CType(gObj, RELAP.GraphicObjects.QuickTableGraphic).BaseOwner.Nome).TabelaRapida = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.ComponentSeparator
    '                            .CLCS_ComponentSeparatorCollection(gObj.Name).GraphicObject = gObj
    '                            .ComponentSeparatorCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.OrificePlate
    '                            .CLCS_OrificePlateCollection(gObj.Name).GraphicObject = gObj
    '                            .OrificePlateCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.CustomUO
    '                            .CLCS_CustomUOCollection(gObj.Name).GraphicObject = gObj
    '                            .CustomUOCollection(gObj.Name) = gObj
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.CapeOpenUO
    '                            .CLCS_CapeOpenUOCollection(gObj.Name).GraphicObject = gObj
    '                            .CapeOpenUOCollection(gObj.Name) = gObj
    '                    End Select
    '                Next
    '            End With

    '            Application.DoEvents()

    '            Dim refill As Boolean = False

    '            'refill (quick)table items for backwards compatibility
    '            For Each obj As SimulationObjects_BaseClass In flowsheet.Collections.ObjectCollection.Values
    '                With obj
    '                    If .NodeTableItems.Count > 0 Then
    '                        For Each nvi As RELAP.Outros.NodeItem In .NodeTableItems.Values
    '                            Try
    '                                If Not nvi.Text.Contains("PROP_") Then
    '                                    refill = True
    '                                    Exit For
    '                                End If
    '                            Catch ex As Exception

    '                            End Try
    '                        Next
    '                    End If
    '                    If refill Then
    '                        .NodeTableItems.Clear()
    '                        .QTNodeTableItems.Clear()
    '                        .FillNodeItems()
    '                        .QTFillNodeItems()
    '                    End If
    '                End With
    '            Next

    '            Application.DoEvents()

    '            flowsheet.FrmStSim1.Init(True)

    '            Application.DoEvents()

    '            flowsheet.ResumeLayout()

    '            flowsheet.FormSurface.FlowsheetDesignSurface.Invalidate()

    '            flowsheet.WriteToLog(RELAP.App.GetLocalString("RestoreStateOK"), Color.Blue, TipoAviso.Informacao)

    '        Catch ex As Exception

    '            flowsheet.WriteToLog(RELAP.App.GetLocalString("RestoreStateError") & " " & ex.Message.ToString, Color.Red, TipoAviso.Erro)

    '            st = Nothing

    '        Finally

    '            frmwait.Close()

    '        End Try

    '    End If

    'End Sub


    Function ReturnForm(ByVal str As String) As IDockContent
        Select Case str
            Case "RELAP.frmProps"
                Return Me.tmpform2.FormProps
            Case "RELAP.frmObjList"
                '      Return Me.tmpform2.FormObjList
            Case "RELAP.frmPlotRequest"
                Return Me.tmpform2.FormPlotReqest
            Case "RELAP.frmSurface"
                Return Me.tmpform2.FormSurface
            Case "RELAP.frmInitialSettings"
                Return Me.tmpform2.FormInitialSettings
            Case "RELAP.frmMaterials"
                Return Me.tmpform2.FormMaterials
            Case "RELAP.frmObjListView"
                Return Me.tmpform2.FormObjListView
            Case "RELAP.frmWatch"
                '   Return Me.tmpform2.FormWatch
        End Select
        Return Nothing
    End Function

    Sub LoadF(ByVal caminho As String)

        If System.IO.File.Exists(caminho) Then

            Dim rnd As New Random()
            Dim fn As String = rnd.Next(10000, 99999)

            Dim diretorio As String = Path.GetDirectoryName(caminho)
            Dim arquivo As String = Path.GetFileName(caminho)
            Dim arquivoCAB As String = "RELAP" + fn

            Dim ziperror As Boolean = False
            Dim loadedok As Boolean = False
            Try
                Dim zp As New ZipFile(caminho)
                zp = Nothing
                'is a zip file
            Catch ex As Exception
                ziperror = True
            End Try

            loadedok = Me.LoadAndExtractZIP(caminho)

            If Not loadedok Then Exit Sub

            Me.SuspendLayout()
            'form.Text = "Simulação " & m_childcount
            m_childcount += 1

            Dim form As FormFlowsheet = New FormFlowsheet()
            My.Application.CAPEOPENMode = False
            My.Application.ActiveSimulation = form

            'is not a zip file
            If ziperror Then
                Try
                    If Not RELAP.App.IsRunningOnMono() Then
                        'Call Me.LoadAndExtractCAB(caminho)
                    Else
                        MsgBox("This file is not loadable when running RELAP on Mono.", MsgBoxStyle.Critical, "Error!")
                        Exit Sub
                    End If
                Catch ex As Exception
                    VDialog.Show(ex.Message, RELAP.App.GetLocalString("Erroaoabrirarquivo"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    form = Nothing
                End Try
            End If

            Dim mySerializer As Binary.BinaryFormatter = New Binary.BinaryFormatter(Nothing, New System.Runtime.Serialization.StreamingContext())
            Dim fs3 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\3.bin", FileMode.Open)

            Try
                form.FormSurface.FlowsheetDesignSurface.m_drawingObjects = Nothing
                form.FormSurface.FlowsheetDesignSurface.m_drawingObjects = DirectCast(mySerializer.Deserialize(fs3), Microsoft.Msdn.Samples.GraphicObjects.GraphicObjectCollection)
            Catch ex As System.Runtime.Serialization.SerializationException
                Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                VDialog.Show(ex.Message)
            Finally
                fs3.Close()
            End Try

            Dim fs As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\1.bin", FileMode.Open)

            Try
                form.Collections = Nothing
                form.Collections = DirectCast(mySerializer.Deserialize(fs), RELAP.FormClasses.ClsObjectCollections)
            Catch ex As System.Runtime.Serialization.SerializationException
                Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                VDialog.Show(ex.Message)
            Finally
                fs.Close()
            End Try

            Dim fs2 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\2.bin", FileMode.Open)

            Try
                form.Options = Nothing
                form.Options = DirectCast(mySerializer.Deserialize(fs2), RELAP.FormClasses.ClsFormOptions)
                'If form.Options.PropertyPackages.Count = 0 Then form.Options.PropertyPackages = Me.PropertyPackages
                form.FormInitialSettings.loadsettings()
            Catch ex As System.Runtime.Serialization.SerializationException
                Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                VDialog.Show(ex.Message)
            Finally
                fs2.Close()
            End Try

            'Try
            '    form.FormObjList.TreeViewObj.Nodes.Clear()
            '    TreeViewDataAccess.LoadTreeViewData(form.FormObjList.TreeViewObj, My.Computer.FileSystem.SpecialDirectories.Temp & "\5.bin")
            'Catch ex As System.Runtime.Serialization.SerializationException
            '    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
            '    VDialog.Show(ex.Message)
            'Finally

            '  End Try

            Dim fs7 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\7.bin", FileMode.Open)

            Try
                form.Text = DirectCast(mySerializer.Deserialize(fs7), String)
            Catch ex As System.Runtime.Serialization.SerializationException
                Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                VDialog.Show(ex.Message)
            Finally
                fs7.Close()
            End Try

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\8.bin") Then
                Dim fs8 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\8.bin", FileMode.Open)
                Try
                    'form.FormLog.GridDT.Rows.Clear()
                    'form.FormLog.GridDT = DirectCast(mySerializer.Deserialize(fs8), DataTable)
                Catch ex As System.Runtime.Serialization.SerializationException
                    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                    VDialog.Show(ex.Message)
                Finally
                    fs8.Close()
                End Try
            End If

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\9.bin") Then
                Dim fs9 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\9.bin", FileMode.Open)
                Try
                    '       form.FormSpreadsheet.dt1 = DirectCast(mySerializer.Deserialize(fs9), Object(,))
                Catch ex As System.Runtime.Serialization.SerializationException
                    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                    VDialog.Show(ex.Message)
                Finally
                    fs9.Close()
                End Try
            End If

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\10.bin") Then
                Dim fs10 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\10.bin", FileMode.Open)
                Try
                    '    form.FormSpreadsheet.dt2 = DirectCast(mySerializer.Deserialize(fs10), Object(,))
                Catch ex As System.Runtime.Serialization.SerializationException
                    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                    VDialog.Show(ex.Message)
                Finally
                    fs10.Close()
                End Try
            End If

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\11.bin") Then
                Dim fs11 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\11.bin", FileMode.Open)
                Try
                    'form.FormWatch.items = DirectCast(mySerializer.Deserialize(fs11), Dictionary(Of Integer, RELAP.Outros.WatchItem))
                    'form.FormWatch.PopulateList()
                Catch ex As System.Runtime.Serialization.SerializationException
                    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                    VDialog.Show(ex.Message)
                Finally
                    fs11.Close()
                End Try
            End If

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\13.bin") Then
                Dim fs13 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\13.bin", FileMode.Open)
                Try
                    form.FlowsheetStates = DirectCast(mySerializer.Deserialize(fs13), Dictionary(Of Date, FlowsheetState))
                    '     form.UpdateStateList()
                Catch ex As System.Runtime.Serialization.SerializationException
                    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                    VDialog.Show(ex.Message)
                Finally
                    fs13.Close()
                End Try
            End If

            form.CheckCollections()

            With form.Collections
                Dim gObj As Microsoft.Msdn.Samples.GraphicObjects.GraphicObject
                For Each gObj In form.FormSurface.FlowsheetDesignSurface.drawingObjects
                    Select Case gObj.TipoObjeto



                    End Select
                Next
            End With

            My.Application.ActiveSimulation = form

            Dim refill As Boolean = False

            'refill (quick)table items for backwards compatibility
            For Each obj As SimulationObjects_BaseClass In form.Collections.ObjectCollection.Values
                With obj
                    If .NodeTableItems.Count > 0 Then
                        For Each nvi As RELAP.Outros.NodeItem In .NodeTableItems.Values
                            Try
                                If Not nvi.Text.Contains("PROP_") Then
                                    refill = True
                                    Exit For
                                End If
                            Catch ex As Exception

                            End Try
                        Next
                    End If
                    If refill Then
                        .NodeTableItems.Clear()
                        .QTNodeTableItems.Clear()
                        .FillNodeItems()
                        .QTFillNodeItems()
                    End If
                End With
            Next

            form.MdiParent = Me
            form.m_IsLoadedFromFile = True

            Me.tmpform2 = form
            form.dckPanel.SuspendLayout(True)
            '
            form.FormProps.DockPanel = Nothing
            '
            form.FormSurface.DockPanel = Nothing

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\4.xml") Then form.dckPanel.LoadFromXml(My.Computer.FileSystem.SpecialDirectories.Temp & "\4.xml", New DeserializeDockContent(AddressOf Me.ReturnForm))

            ''Set DockPanel and Form  properties

            form.dckPanel.ActiveAutoHideContent = Nothing
            form.dckPanel.Parent = form

            form.Options.FilePath = Me.filename
            '  form.WriteToLog(RELAP.App.GetLocalString("Arquivo") & Me.filename & RELAP.App.GetLocalString("carregadocomsucesso"), Color.Blue, RELAP.FormClasses.TipoAviso.Informacao)
            form.Text += " (" + Me.filename + ")"

            form.FormObjListView.Show(form.dckPanel)
            '
            form.FormSurface.Show(form.dckPanel)
            '
            form.FormProps.Show(form.dckPanel)
            form.FormInitialSettings.Show(form.dckPanel)
            form.FormMaterials.Show(form.dckPanel)
            form.FormPlotReqest.Show(form.dckPanel)
            '

            form.dckPanel.ResumeLayout(True, True)
            form.dckPanel.BringToFront()

            Me.ResumeLayout()

            Dim repositionpfd As Boolean = True

            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\12.bin") Then
                repositionpfd = False
            End If

            If Not My.Settings.MostRecentFiles.Contains(caminho) Then
                My.Settings.MostRecentFiles.Add(caminho)
                Me.UpdateMRUList()
            End If

            form.MdiParent = Me
            form.Show()
            form.MdiParent = Me

            My.Application.ActiveSimulation = form

            If Not repositionpfd Then
                Dim text As String() = File.ReadAllLines(My.Computer.FileSystem.SpecialDirectories.Temp & "\12.bin")
                form.FormSurface.FlowsheetDesignSurface.Zoom = text(0)
                'form.TSTBZoom.Text = CStr(CInt(text(0) * 100)) & "%"
                form.FormSurface.FlowsheetDesignSurface.VerticalScroll.Maximum = 7000
                form.FormSurface.FlowsheetDesignSurface.VerticalScroll.Value = CInt(text(1))
                form.FormSurface.FlowsheetDesignSurface.HorizontalScroll.Maximum = 10000
                form.FormSurface.FlowsheetDesignSurface.HorizontalScroll.Value = CInt(text(2))
            Else
                form.FormSurface.FlowsheetDesignSurface.Zoom = 1
                form.FormSurface.FlowsheetDesignSurface.VerticalScroll.Maximum = 7000
                form.FormSurface.FlowsheetDesignSurface.VerticalScroll.Value = 3500
                form.FormSurface.FlowsheetDesignSurface.HorizontalScroll.Maximum = 10000
                form.FormSurface.FlowsheetDesignSurface.HorizontalScroll.Value = 5000
                For Each obj As Microsoft.Msdn.Samples.GraphicObjects.GraphicObject In form.FormSurface.FlowsheetDesignSurface.drawingObjects
                    obj.X += 5000
                    obj.Y += 3500
                Next
            End If

            form.Invalidate()
            Application.DoEvents()

            'form = Nothing
            Me.ToolStripStatusLabel1.Text = ""

            'delete files

            Dim filespath As String = My.Computer.FileSystem.SpecialDirectories.Temp & pathsep

            If File.Exists(filespath & "1.bin") Then File.Delete(filespath & "1.bin")
            If File.Exists(filespath & "2.bin") Then File.Delete(filespath & "2.bin")
            If File.Exists(filespath & "3.bin") Then File.Delete(filespath & "3.bin")
            If File.Exists(filespath & "4.xml") Then File.Delete(filespath & "4.xml")
            If File.Exists(filespath & "5.bin") Then File.Delete(filespath & "5.bin")
            If File.Exists(filespath & "7.bin") Then File.Delete(filespath & "7.bin")
            If File.Exists(filespath & "8.bin") Then File.Delete(filespath & "8.bin")
            If File.Exists(filespath & "9.bin") Then File.Delete(filespath & "9.bin")
            If File.Exists(filespath & "10.bin") Then File.Delete(filespath & "10.bin")
            If File.Exists(filespath & "11.bin") Then File.Delete(filespath & "11.bin")
            If File.Exists(filespath & "12.bin") Then File.Delete(filespath & "12.bin")
            If File.Exists(filespath & "13.bin") Then File.Delete(filespath & "13.bin")

        Else

            VDialog.Show(RELAP.App.GetLocalString("Oarquivonoexisteoufo"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If


    End Sub

    Function LoadFileForCommandLine(ByVal caminho As String) As FormFlowsheet

        If System.IO.File.Exists(caminho) Then

            Dim rnd As New Random()
            Dim fn As String = rnd.Next(10000, 99999)

            Dim diretorio As String = Path.GetDirectoryName(caminho)
            Dim arquivo As String = Path.GetFileName(caminho)
            Dim arquivoCAB As String = "RELAP" + fn

            Dim formc As FormFlowsheet = New FormFlowsheet()

            'Try

            'Me.SuspendLayout()
            'form.Text = "Simulação " & m_childcount
            'm_childcount += 1

            Dim ziperror As Boolean = False
            Try
                Dim zp As New ZipFile(caminho)
                'is a zip file
                zp = Nothing
                Call Me.LoadAndExtractZIP(caminho)
            Catch ex As Exception
                ziperror = True
            End Try

            'is not a zip file
            If ziperror Then
                Try
                    If Not RELAP.App.IsRunningOnMono() Then
                        'Call Me.LoadAndExtractCAB(caminho)
                    Else
                        MsgBox("This file is not loadable when running RELAP on Mono.", MsgBoxStyle.Critical, "Error!")
                        Return Nothing
                        Exit Function
                    End If
                Catch ex As Exception
                    VDialog.Show(ex.Message, RELAP.App.GetLocalString("Erroaoabrirarquivo"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    formc = Nothing
                End Try
            End If


            ' Insert code to set properties and fields of the object.
            Dim mySerializer As Binary.BinaryFormatter = New Binary.BinaryFormatter(Nothing, New System.Runtime.Serialization.StreamingContext())
            ' To write to a file, create a StreamWriter object.
            Dim fs3 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\3.bin", FileMode.Open)
            Try
                formc.FormSurface.FlowsheetDesignSurface.m_drawingObjects = Nothing
                formc.FormSurface.FlowsheetDesignSurface.m_drawingObjects = DirectCast(mySerializer.Deserialize(fs3), Microsoft.Msdn.Samples.GraphicObjects.GraphicObjectCollection)
            Catch ex As System.Runtime.Serialization.SerializationException
                Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                VDialog.Show(ex.Message)
            Finally
                fs3.Close()
            End Try
            Dim fs As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\1.bin", FileMode.Open)
            Try
                formc.Collections = Nothing
                formc.Collections = DirectCast(mySerializer.Deserialize(fs), RELAP.FormClasses.ClsObjectCollections)
            Catch ex As System.Runtime.Serialization.SerializationException
                Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                VDialog.Show(ex.Message)
            Finally
                fs.Close()
            End Try
            Dim fs2 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\2.bin", FileMode.Open)
            Try
                formc.Options = Nothing
                formc.Options = DirectCast(mySerializer.Deserialize(fs2), RELAP.FormClasses.ClsFormOptions)
                '  If formc.Options.PropertyPackages.Count = 0 Then formc.Options.PropertyPackages = Me.PropertyPackages
            Catch ex As System.Runtime.Serialization.SerializationException
                Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                VDialog.Show(ex.Message)
            Finally
                fs2.Close()
            End Try
            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\9.bin") Then
                Dim fs9 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\9.bin", FileMode.Open)
                Try
                    '   formc.FormSpreadsheet.dt1 = DirectCast(mySerializer.Deserialize(fs9), Object(,))
                Catch ex As System.Runtime.Serialization.SerializationException
                    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                    VDialog.Show(ex.Message)
                Finally
                    fs9.Close()
                End Try
            End If
            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\10.bin") Then
                Dim fs10 As New FileStream(My.Computer.FileSystem.SpecialDirectories.Temp & "\10.bin", FileMode.Open)
                Try
                    '   formc.FormSpreadsheet.dt2 = DirectCast(mySerializer.Deserialize(fs10), Object(,))
                Catch ex As System.Runtime.Serialization.SerializationException
                    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
                    VDialog.Show(ex.Message)
                Finally
                    fs10.Close()
                End Try
            End If

            With formc.Collections
                Dim gObj As Microsoft.Msdn.Samples.GraphicObjects.GraphicObject
                For Each gObj In formc.FormSurface.FlowsheetDesignSurface.drawingObjects
                    Select Case gObj.TipoObjeto


                    End Select
                Next
            End With

            My.Application.ActiveSimulation = formc

            Dim refill As Boolean = False

            'refill (quick)table items for backwards compatibility
            For Each obj As SimulationObjects_BaseClass In formc.Collections.ObjectCollection.Values
                With obj
                    If .NodeTableItems.Count > 0 Then
                        For Each nvi As RELAP.Outros.NodeItem In .NodeTableItems.Values
                            If Not nvi.Text.Contains("PROP_") Then
                                refill = True
                                Exit For
                            End If
                        Next
                    End If
                    If refill Then
                        .NodeTableItems.Clear()
                        .QTNodeTableItems.Clear()
                        .FillNodeItems()
                        .QTFillNodeItems()
                    End If
                End With
            Next

            'form.MdiParent = Me
            formc.m_IsLoadedFromFile = True

            'Me.tmpform2 = form
            'form.dckPanel.SuspendLayout(True)
            'form.FormLog.DockPanel = Nothing
            'form.FormObjList.DockPanel = Nothing
            'form.FormProps.DockPanel = Nothing
            'form.FormMatList.DockPanel = Nothing
            'form.FormSurface.DockPanel = Nothing
            'If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\4.xml") Then form.dckPanel.LoadFromXml(My.Computer.FileSystem.SpecialDirectories.Temp & "\4.xml", New DeserializeDockContent(AddressOf Me.ReturnForm))
            ' ''Set DockPanel properties
            'form.dckPanel.ActiveAutoHideContent = Nothing
            'form.dckPanel.Parent = form

            'form.Options.FilePath = Me.filename
            'form.WriteToLog(RELAP.App.GetLocalString("Arquivo") & Me.filename & RELAP.App.GetLocalString("carregadocomsucesso"), Color.Blue, RELAP.FormClasses.TipoAviso.Informacao)
            'form.Text += " (" + Me.filename + ")"
            'form.Show()

            'form.FormLog.Show(form.dckPanel)
            'form.FormMatList.Show(form.dckPanel)
            'form.FormSurface.Show(form.dckPanel)
            'form.FormObjList.Show(form.dckPanel)
            'form.FormProps.Show(form.dckPanel)
            'form.dckPanel.ResumeLayout(True, True)
            'form.dckPanel.BringToFront()

            'Me.ResumeLayout()

            'If Not My.Settings.MostRecentFiles.Contains(caminho) Then
            '    My.Settings.MostRecentFiles.Add(caminho)
            '    Me.UpdateMRUList()
            'End If

            'Catch ex As Exception
            '    VDialog.Show("Erro ao carregar arquivo: " & ex.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            'form = Nothing
            'Me.ToolStripStatusLabel1.Text = ""
            'End Try

            Return formc

        Else

            Return Nothing

        End If

        Return Nothing

    End Function

    '/ '/ Generates a random string with the given length
    '/ '/ Size of the string '/ If true, generate lowercase string
    '/ Random string
    Private Function RandomString(ByVal size As Integer, ByVal lowerCase As Boolean) As String
        Dim builder As New StringBuilder()
        Dim random As New Random()
        Dim ch As Char
        Dim i As Integer
        For i = 0 To size - 1
            ch = Convert.ToChar(Convert.ToInt32((26 * random.NextDouble() + 65)))
            builder.Append(ch)
        Next
        If lowerCase Then
            Return builder.ToString().ToLower()
        End If
        Return builder.ToString()
    End Function 'RandomString 

    Sub SaveF(ByVal caminho As String, ByRef form As FormFlowsheet)

        Dim rndfolder As String = My.Computer.FileSystem.SpecialDirectories.Temp & pathsep & RandomString(8, True) & pathsep

        Directory.CreateDirectory(rndfolder)

        ' Insert code to set properties and fields of the object.
        Dim mySerializer As Binary.BinaryFormatter = New Binary.BinaryFormatter(Nothing, New System.Runtime.Serialization.StreamingContext())
        ' To write to a file, create a StreamWriter object.
        Dim fs As New FileStream(rndfolder & "1.bin", FileMode.Create)
        Try
            mySerializer.Serialize(fs, form.Collections)
        Catch ex As Exception
            Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
            VDialog.Show(ex.Message)
        Finally
            fs.Close()
        End Try
        Dim fs2 As New FileStream(rndfolder & "2.bin", FileMode.Create)
        Try
            form.FormInitialSettings.Save()
            mySerializer.Serialize(fs2, form.Options)
        Catch ex As System.Runtime.Serialization.SerializationException
            Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
            VDialog.Show(ex.Message)
        Finally
            fs2.Close()
        End Try
        Dim fs3 As New FileStream(rndfolder & "3.bin", FileMode.Create)
        Try
            mySerializer.Serialize(fs3, form.FormSurface.FlowsheetDesignSurface.drawingObjects)
        Catch ex As System.Runtime.Serialization.SerializationException
            Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
            VDialog.Show(ex.Message)
        Finally
            fs3.Close()
        End Try
        Try
            form.dckPanel.SaveAsXml(rndfolder & "4.xml")
        Catch ex As Exception
            Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
            VDialog.Show(ex.Message)
        Finally

        End Try
        ' Dim fs5 As New FileStream(rndfolder & "5.bin", FileMode.Create)
        Try
            'mySerializer.Serialize(fs5, frmInitialSettings)
            '   TreeViewDataAccess.SaveTreeViewData(form.FormObjList.TreeViewObj, rndfolder & "5.bin")
        Catch ex As System.Runtime.Serialization.SerializationException
            Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
            VDialog.Show(ex.Message)
        Finally

        End Try
        Dim fs7 As New FileStream(rndfolder & "7.bin", FileMode.Create)
        Try
            mySerializer.Serialize(fs7, form.Options.SimNome)
        Catch ex As System.Runtime.Serialization.SerializationException
            Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
            VDialog.Show(ex.Message)
        Finally
            fs7.Close()
        End Try
        ' Dim fs8 As New FileStream(rndfolder & "8.bin", FileMode.Create)
        'Try
        '    mySerializer.Serialize(fs8, form.FormLog.GridDT)
        'Catch ex As System.Runtime.Serialization.SerializationException
        '    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
        '    VDialog.Show(ex.Message)
        'Finally
        '    fs8.Close()
        'End Try
        'form.FormSpreadsheet.CopyToDT()
        ' Dim fs9 As New FileStream(rndfolder & "9.bin", FileMode.Create)
        'Try
        '    mySerializer.Serialize(fs9, form.FormSpreadsheet.dt1)
        'Catch ex As System.Runtime.Serialization.SerializationException
        '    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
        '    VDialog.Show(ex.Message)
        'Finally
        '    fs9.Close()
        'End Try
        'Dim fs10 As New FileStream(rndfolder & "10.bin", FileMode.Create)
        'Try
        '    mySerializer.Serialize(fs10, form.Formbr-readsheet.dt2)
        'Catch ex As System.Runtime.Serialization.SerializationException
        '    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
        '    VDialog.Show(ex.Message)
        'Finally
        '    fs10.Close()
        'End Try
        ' Dim fs11 As New FileStream(rndfolder & "11.bin", FileMode.Create)
        'Try
        '    mySerializer.Serialize(fs11, form.FormWatch.items)
        'Catch ex As System.Runtime.Serialization.SerializationException
        '    Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
        '    VDialog.Show(ex.Message)
        'Finally
        '    fs11.Close()
        'End Try

        Dim flsconfig As New StringBuilder()

        With flsconfig
            .AppendLine(form.FormSurface.FlowsheetDesignSurface.Zoom)
            .AppendLine(form.FormSurface.FlowsheetDesignSurface.VerticalScroll.Value)
            .AppendLine(form.FormSurface.FlowsheetDesignSurface.HorizontalScroll.Value)
        End With

        File.WriteAllText(rndfolder & "12.bin", flsconfig.ToString)

        Dim fs13 As New FileStream(rndfolder & "13.bin", FileMode.Create)
        Try
            If form.FlowsheetStates Is Nothing Then form.FlowsheetStates = New Dictionary(Of Date, FlowsheetState)
            mySerializer.Serialize(fs13, form.FlowsheetStates)
        Catch ex As System.Runtime.Serialization.SerializationException
            Console.WriteLine("Failed to serialize. Reason: " & ex.Message)
            VDialog.Show(ex.Message)
        Finally
            fs13.Close()
        End Try

        Dim pwd As String = Nothing
        If form.Options.UsePassword Then pwd = form.Options.Password

        Try
            Call Me.SaveZIP(caminho, rndfolder, pwd)
        Catch ex As Exception
            '    form.WriteToLog("Error saving file: " & ex.Message, Color.Red, RELAP.FormClasses.TipoAviso.Erro)
        End Try

        Dim ext As String = Path.GetExtension(caminho)

        If ext <> ".dwbcs" Then

            'lista dos mais recentes, modificar
            With My.Settings.MostRecentFiles
                If Not .Contains(Me.filename) Then
                    If My.Settings.MostRecentFiles.Count = 3 Then
                        .Item(2) = .Item(1)
                        .Item(1) = .Item(0)
                        .Item(0) = Me.filename
                    ElseIf My.Settings.MostRecentFiles.Count = 2 Then
                        .Add(.Item(1))
                        .Item(1) = .Item(0)
                        .Item(0) = Me.filename
                    ElseIf My.Settings.MostRecentFiles.Count = 1 Then
                        .Add(.Item(0))
                        .Item(0) = Me.filename
                    ElseIf My.Settings.MostRecentFiles.Count = 0 Then
                        .Add(Me.filename)
                    End If
                End If
            End With

            'processar lista de arquivos recentes
            If Not My.Settings.MostRecentFiles.Contains(caminho) Then
                My.Settings.MostRecentFiles.Add(caminho)
                If Not My.Application.CommandLineArgs.Count > 1 Then Me.UpdateMRUList()
            End If

            form.Options.FilePath = Me.filename
            form.Text = form.Options.SimNome + " (" + form.Options.FilePath + ")"
            '  form.WriteToLog(RELAP.App.GetLocalString("Arquivo") & Me.filename & RELAP.App.GetLocalString("salvocomsucesso"), Color.Blue, RELAP.FormClasses.TipoAviso.Informacao)

        End If

    End Sub

    Private Function IsZipFilePasswordProtected(ByVal ZipFile As String) As Boolean
        Using fsIn As New FileStream(ZipFile, FileMode.Open, FileAccess.Read)
            Using zipInStream As New ZipInputStream(fsIn)
                Dim zEntry As ZipEntry = zipInStream.GetNextEntry()
                Return zEntry.IsCrypted
            End Using
        End Using
    End Function

    Function LoadAndExtractZIP(ByVal caminho As String) As Boolean

        Dim pathtosave As String = My.Computer.FileSystem.SpecialDirectories.Temp + Path.DirectorySeparatorChar

        If (caminho.Length < 1) Then
            MsgBox("Usage UnzipFile NameOfFile")
            Return False
        ElseIf Not File.Exists(caminho) Then
            MsgBox("Cannot find file '{0}'", caminho)
            Return False
        Else
            Dim pwd As String = Nothing
            'If IsZipFilePasswordProtected(caminho) Then
            '    Dim fp As New FormPassword
            '    If fp.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '        pwd = fp.tbPassword.Text
            '    End If
            'End If

            Try
                Using stream As ZipInputStream = New ZipInputStream(File.OpenRead(caminho))
                    stream.Password = pwd
                    Dim entry As ZipEntry
Label_00CC:
                    entry = stream.GetNextEntry()
                    Do While (Not entry Is Nothing)
                        Dim fileName As String = Path.GetFileName(entry.Name)
                        If (fileName <> String.Empty) Then
                            Using stream2 As FileStream = File.Create(pathtosave + Path.GetFileName(entry.Name))
                                Dim count As Integer = 2048
                                Dim buffer As Byte() = New Byte(2048) {}
                                Do While True
                                    count = stream.Read(buffer, 0, buffer.Length)
                                    If (count <= 0) Then
                                        GoTo Label_00CC
                                    End If
                                    stream2.Write(buffer, 0, count)
                                Loop
                            End Using
                        End If
                        entry = stream.GetNextEntry
                    Loop
                End Using
                Return True
            Catch ex As Exception
                VDialog.Show(ex.Message, RELAP.App.GetLocalString("Erroaoabrirarquivo"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End If

    End Function

    Sub SaveZIP(ByVal caminho As String, ByVal filespath As String, ByVal password As String)

        Dim i_Files As ArrayList = New ArrayList()
        If File.Exists(filespath & "1.bin") Then i_Files.Add(filespath & "1.bin")
        If File.Exists(filespath & "2.bin") Then i_Files.Add(filespath & "2.bin")
        If File.Exists(filespath & "3.bin") Then i_Files.Add(filespath & "3.bin")
        If File.Exists(filespath & "4.xml") Then i_Files.Add(filespath & "4.xml")
        If File.Exists(filespath & "5.bin") Then i_Files.Add(filespath & "5.bin")
        If File.Exists(filespath & "7.bin") Then i_Files.Add(filespath & "7.bin")
        If File.Exists(filespath & "8.bin") Then i_Files.Add(filespath & "8.bin")
        If File.Exists(filespath & "9.bin") Then i_Files.Add(filespath & "9.bin")
        If File.Exists(filespath & "10.bin") Then i_Files.Add(filespath & "10.bin")
        If File.Exists(filespath & "11.bin") Then i_Files.Add(filespath & "11.bin")
        If File.Exists(filespath & "12.bin") Then i_Files.Add(filespath & "12.bin")
        If File.Exists(filespath & "13.bin") Then i_Files.Add(filespath & "13.bin")

        Dim astrFileNames() As String = i_Files.ToArray(GetType(String))
        Dim strmZipOutputStream As ZipOutputStream

        strmZipOutputStream = New ZipOutputStream(File.Create(caminho))

        ' Compression Level: 0-9
        ' 0: no(Compression)
        ' 9: maximum compression
        strmZipOutputStream.SetLevel(9)

        'save with password, if set
        strmZipOutputStream.Password = password

        Dim strFile As String

        For Each strFile In astrFileNames

            Dim strmFile As FileStream = File.OpenRead(strFile)
            Dim abyBuffer(strmFile.Length - 1) As Byte

            strmFile.Read(abyBuffer, 0, abyBuffer.Length)
            Dim objZipEntry As ZipEntry = New ZipEntry(strFile)

            objZipEntry.DateTime = DateTime.Now
            objZipEntry.Size = strmFile.Length
            strmFile.Close()
            strmZipOutputStream.PutNextEntry(objZipEntry)
            strmZipOutputStream.Write(abyBuffer, 0, abyBuffer.Length)

        Next

        strmZipOutputStream.Finish()
        strmZipOutputStream.Close()

        Dim ext As String = Path.GetExtension(caminho)
        Dim diretorio As String = Path.GetDirectoryName(caminho)

        If ext <> ".dwbcs" Then
            If File.Exists(caminho) Then
                File.Copy(caminho, diretorio + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(caminho) + ".dwbak", True)
            End If
        End If

        Directory.Delete(filespath, True)

    End Sub

    Sub LoadFileDialog()

        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Select Case Me.OpenFileDialog1.FilterIndex
                Case 1
sim:                Dim myStream As System.IO.FileStream
                    myStream = Me.OpenFileDialog1.OpenFile()
                    If Not (myStream Is Nothing) Then
                        Dim nome = myStream.Name
                        myStream.Close()
                        Me.filename = nome
                        Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Abrindosimulao") + " " + nome + "..."
                        Application.DoEvents()
                        Me.LoadF(Me.filename)
                    End If
                    '                Case 2
                    'csd:                Dim NewMDIChild As New FormCompoundCreator()
                    '                    NewMDIChild.MdiParent = Me
                    '                    NewMDIChild.Show()
                    '                    Dim objStreamReader As New FileStream(Me.OpenFileDialog1.FileName, FileMode.Open)
                    '                    Dim x As New BinaryFormatter()
                    '                    NewMDIChild.mycase = x.Deserialize(objStreamReader)
                    '                    objStreamReader.Close()
                    '                    NewMDIChild.WriteData()
                    '                    If Not My.Settings.MostRecentFiles.Contains(Me.OpenFileDialog1.FileName) Then
                    '                        My.Settings.MostRecentFiles.Add(Me.OpenFileDialog1.FileName)
                    '                        Me.UpdateMRUList()
                    '                    End If
                    '                Case 3
                    'rsd:                Dim NewMDIChild As New FormDataRegression()
                    '                    NewMDIChild.MdiParent = Me
                    '                    NewMDIChild.Show()
                    '                    Dim objStreamReader As New FileStream(Me.OpenFileDialog1.FileName, FileMode.Open)
                    '                    Dim x As New BinaryFormatter()
                    '                    NewMDIChild.currcase = x.Deserialize(objStreamReader)
                    '                    objStreamReader.Close()
                    '                    NewMDIChild.LoadCase(NewMDIChild.currcase, False)
                    '                    If Not My.Settings.MostRecentFiles.Contains(Me.OpenFileDialog1.FileName) Then
                    '                        My.Settings.MostRecentFiles.Add(Me.OpenFileDialog1.FileName)
                    '                        Me.UpdateMRUList()
                    '                    End If
                Case 4
                    Select Case Path.GetExtension(Me.OpenFileDialog1.FileName).ToLower()
                        Case ".relap"
                            GoTo sim

                    End Select
            End Select
        End If

    End Sub

    Sub SaveFileDialog()

        If TypeOf Me.ActiveMdiChild Is FormFlowsheet Then
            Dim myStream As System.IO.FileStream
            If Me.SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                myStream = Me.SaveFileDialog1.OpenFile()
                Me.filename = myStream.Name
                myStream.Close()
                If Not (myStream Is Nothing) Then
                    Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Salvandosimulao") + " (" + Me.filename + ")"
                    Application.DoEvents()
                    Me.bgSaveFile.RunWorkerAsync()
                End If
            End If
            'ElseIf TypeOf Me.ActiveMdiChild Is FormCompoundCreator Then
            '    If Me.SaveStudyDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            '        Dim objStreamWriter As New FileStream(Me.SaveStudyDlg.FileName, FileMode.OpenOrCreate)
            '        Dim x As New BinaryFormatter
            '        x.Serialize(objStreamWriter, CType(Me.ActiveMdiChild, FormCompoundCreator).mycase)
            '        objStreamWriter.Close()
            '    End If
            'ElseIf TypeOf Me.ActiveMdiChild Is FormDataRegression Then
            '    If Me.SaveRegStudyDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            '        Dim objStreamWriter As New FileStream(Me.SaveRegStudyDlg.FileName, FileMode.OpenOrCreate)
            '        Dim x As New BinaryFormatter
            '        x.Serialize(objStreamWriter, CType(Me.ActiveMdiChild, FormDataRegression).StoreCase())
            '        objStreamWriter.Close()
            '    End If
        End If



    End Sub

    Sub SaveFileDialog_NoBG()

        Dim myStream As System.IO.FileStream

        Me.SaveFileDialog1.Filter = RELAP.App.GetLocalString("SimulaesdoRELAPRELAP")
        Me.SaveFileDialog1.AddExtension = True
        If Me.SaveFileDialog1.FilterIndex = 1 Then
            If Me.SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                myStream = Me.SaveFileDialog1.OpenFile()
                Me.filename = myStream.Name
                myStream.Close()
                If Not (myStream Is Nothing) Then
                    'FrmLoadSave = New FormLS
                    'With FrmLoadSave
                    '    .Text = "RELAP"
                    '    .Label1.Text = RELAP.App.GetLocalString("Salvandosimulao")
                    '    .WindowState = FormWindowState.Normal
                    '    .TopMost = True
                    '    .StartPosition = FormStartPosition.CenterScreen
                    '    .Show(Me)
                    'End With
                    Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Salvandosimulao") + " (" + Me.filename + ")"
                    Application.DoEvents()
                    Me.SaveF(Me.filename, Me.ActiveMdiChild)
                End If
            End If
        End If

    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click, OpenToolStripMenuItem.Click

        Call Me.LoadFileDialog()

    End Sub

    Private Sub bgLoadFile_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgLoadFile.DoWork
        Dim bw As BackgroundWorker = CType(sender, BackgroundWorker)
        ' Start the time-consuming operation.
        Me.LoadF(Me.filename)
    End Sub

    Private Sub bgSaveFile_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgSaveFile.DoWork
        Dim bw As BackgroundWorker = CType(sender, BackgroundWorker)
        ' Start the time-consuming operation.
        Me.SaveF(Me.filename, Me.ActiveMdiChild)
    End Sub

    Private Sub bgLoadFile_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgLoadFile.RunWorkerCompleted
        If Not (e.Error Is Nothing) Then
            ' There was an error during the operation.
            'FrmLoadSave.Hide()
            VDialog.Show("Erro ao carregar arquivo: " & e.Error.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Me.Close()
        Else
            'Me.FrmLoadSave.Close()
        End If
        Me.ToolStripStatusLabel1.Text = ""
    End Sub

    Private Sub bgSaveFile_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgSaveFile.RunWorkerCompleted
        If Not (e.Error Is Nothing) Then
            ' There was an error during the operation.
            VDialog.Show("Erro ao salvar arquivo: " & e.Error.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            'lista dos mais recentes, modificar

            With My.Settings.MostRecentFiles
                If Not .Contains(Me.filename) Then
                    .Item(2) = .Item(1)
                    .Item(1) = .Item(0)
                    .Item(0) = Me.filename
                End If
            End With

            'processar lista de arquivos recentes


        End If
        Me.ToolStripStatusLabel1.Text = ""
    End Sub

#End Region

#Region "    Click Handlers"

    Private Sub LR1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Dim myLink As LinkLabel = CType(sender, LinkLabel)

        If myLink.Text <> RELAP.App.GetLocalString("vazio") Then
            Dim nome = myLink.Tag.ToString
            Me.filename = nome
            Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Abrindosimulao") + " (" + nome + ")"
            Application.DoEvents()
            Try
                Select Case Path.GetExtension(Me.filename).ToLower
                    Case ".RELAP"
                        Me.LoadF(Me.filename)
                        'Case ".dwcsd"
                        '    Dim NewMDIChild As New FormCompoundCreator()
                        '    NewMDIChild.MdiParent = Me
                        '    NewMDIChild.Show()
                        '    Dim objStreamReader As New FileStream(Me.filename, FileMode.Open)
                        '    Dim x As New BinaryFormatter()
                        '    NewMDIChild.mycase = x.Deserialize(objStreamReader)
                        '    objStreamReader.Close()
                        '    NewMDIChild.WriteData()
                        'Case ".dwrsd"
                        '    Dim NewMDIChild As New FormDataRegression()
                        '    NewMDIChild.MdiParent = Me
                        '    NewMDIChild.Show()
                        '    Dim objStreamReader As New FileStream(Me.filename, FileMode.Open)
                        '    Dim x As New BinaryFormatter()
                        '    NewMDIChild.currcase = x.Deserialize(objStreamReader)
                        '    objStreamReader.Close()
                        '    NewMDIChild.LoadCase(NewMDIChild.currcase, False)
                End Select
            Catch ex As Exception
                VDialog.Show("Erro ao carregar arquivo: " & ex.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.ToolStripStatusLabel1.Text = ""
            End Try
            'Me.bgLoadFile.RunWorkerAsync()
        End If
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click, NewToolStripMenuItem.Click, NovoToolStripMenuItem.Click
        Dim NewMDIChild As New FormFlowsheet
        Try




            'Set the Parent Form of the Child window.
            NewMDIChild.MdiParent = Me
            'Display the new form.
            NewMDIChild.Text = "Simulation" & m_childcount
            'System.Threading.Thread.Sleep(1000)
            NewMDIChild.Show()
            Application.DoEvents()
            Me.ActivateMdiChild(NewMDIChild)
            m_childcount += 1

        Catch ex As Exception
            ' MsgBox(ex.Message)
            NewMDIChild.WindowState = FormWindowState.Maximized
        End Try
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
        If Me.CascadeToolStripMenuItem.Checked = True Then
            Me.TileVerticalToolStripMenuItem.Checked = False
            Me.TileHorizontalToolStripMenuItem.Checked = False
        Else
            Me.TileHorizontalToolStripMenuItem.Checked = False
            Me.TileVerticalToolStripMenuItem.Checked = False
            Me.CascadeToolStripMenuItem.Checked = True
        End If
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
        If Me.TileVerticalToolStripMenuItem.Checked = True Then
            Me.TileHorizontalToolStripMenuItem.Checked = False
            Me.CascadeToolStripMenuItem.Checked = False
        Else
            Me.TileHorizontalToolStripMenuItem.Checked = False
            Me.TileVerticalToolStripMenuItem.Checked = True
            Me.CascadeToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
        If Me.TileHorizontalToolStripMenuItem.Checked = True Then
            Me.TileVerticalToolStripMenuItem.Checked = False
            Me.CascadeToolStripMenuItem.Checked = False
        Else
            Me.TileHorizontalToolStripMenuItem.Checked = True
            Me.TileVerticalToolStripMenuItem.Checked = False
            Me.CascadeToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmAbout As New AboutBox
        frmAbout.ShowDialog(Me)
    End Sub

    Private Sub LinkLabel7_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Call Me.OpenToolStripButton_Click(sender, e)
    End Sub

    Private Sub LinkLabel5_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Call Me.NewToolStripButton_Click(sender, e)
    End Sub

    Private Sub OpenRecent_click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim myLink As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If myLink.Text <> RELAP.App.GetLocalString("vazio") Then
            If File.Exists(myLink.Tag.ToString) Then
                Dim nome = myLink.Tag.ToString
                Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Abrindosimulao") + " (" + nome + ")"
                Me.filename = nome
                Application.DoEvents()
                Dim objStreamReader As FileStream = Nothing
                Try
                    Select Case Path.GetExtension(nome).ToLower()
                        Case ".RELAP"
                            Me.LoadF(nome)
                            'Case ".dwcsd"
                            '    Dim NewMDIChild As New FormCompoundCreator()
                            '    NewMDIChild.MdiParent = Me
                            '    NewMDIChild.Show()
                            '    objStreamReader = New FileStream(nome, FileMode.Open)
                            '    Dim x As New BinaryFormatter()
                            '    NewMDIChild.mycase = x.Deserialize(objStreamReader)
                            '    objStreamReader.Close()
                            '    NewMDIChild.WriteData()
                            'Case ".dwrsd"
                            '    Dim NewMDIChild As New FormDataRegression()
                            '    NewMDIChild.MdiParent = Me
                            '    NewMDIChild.Show()
                            '    objStreamReader = New FileStream(nome, FileMode.Open)
                            '    Dim x As New BinaryFormatter()
                            '    NewMDIChild.currcase = x.Deserialize(objStreamReader)
                            '    objStreamReader.Close()
                            '    NewMDIChild.LoadCase(NewMDIChild.currcase, False)
                    End Select
                Catch ex As Exception
                    VDialog.Show("Erro ao carregar arquivo: " & ex.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Me.ToolStripStatusLabel1.Text = ""
                    If objStreamReader IsNot Nothing Then objStreamReader.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub SaveAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAllToolStripButton.Click, SaveAllToolStripMenuItem.Click
        If Me.MdiChildren.Length > 0 Then
            Dim result As MsgBoxResult = VDialog.Show(RELAP.App.GetLocalString("Istoirsalvartodasass"), RELAP.App.GetLocalString("Ateno2"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = MsgBoxResult.Yes Then
                For Each form0 As Form In Me.MdiChildren
                    If TypeOf form0 Is FormFlowsheet Then
                        Dim form2 As FormFlowsheet = form0
                        If form2.Options.FilePath <> "" Then
                            Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Salvandosimulao") + " (" + Me.filename + ")"
                            Try
                                SaveF(form2.Options.FilePath, form2)
                            Catch ex As Exception
                                VDialog.Show(ex.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                Me.ToolStripStatusLabel1.Text = ""
                            End Try
                        Else
                            Dim myStream As System.IO.FileStream
                            If Me.SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                myStream = Me.SaveFileDialog1.OpenFile()
                                myStream.Close()
                                If Not (myStream Is Nothing) Then
                                    Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Salvandosimulao") + " (" + Me.filename + ")"
                                    Try
                                        SaveF(myStream.Name, form2)
                                    Catch ex As Exception
                                        VDialog.Show(ex.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Finally
                                        Me.ToolStripStatusLabel1.Text = ""
                                    End Try
                                End If
                            End If
                        End If
                        'ElseIf TypeOf form0 Is FormCompoundCreator Then
                        '    If Me.SaveStudyDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        '        Dim objStreamWriter As New FileStream(Me.SaveStudyDlg.FileName, FileMode.OpenOrCreate)
                        '        Dim x As New BinaryFormatter
                        '        x.Serialize(objStreamWriter, CType(form0, FormCompoundCreator).mycase)
                        '        objStreamWriter.Close()
                        '    End If
                        'ElseIf TypeOf form0 Is FormDataRegression Then
                        '    If Me.SaveRegStudyDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        '        Dim objStreamWriter As New FileStream(Me.SaveRegStudyDlg.FileName, FileMode.OpenOrCreate)
                        '        Dim x As New BinaryFormatter
                        '        x.Serialize(objStreamWriter, CType(form0, FormDataRegression).StoreCase())
                        '        objStreamWriter.Close()
                        '    End If
                    End If
                Next
            End If
        Else
            VDialog.Show(RELAP.App.GetLocalString("Noexistemsimulaesase"), RELAP.App.GetLocalString("Informao"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click, SaveToolStripMenuItem.Click

        If Not Me.ActiveMdiChild Is Nothing Then
            If TypeOf Me.ActiveMdiChild Is FormFlowsheet Then
                Dim form2 As FormFlowsheet = Me.ActiveMdiChild
                If form2.Options.FilePath <> "" Then
                    Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Salvandosimulao") + " (" + Me.filename + ")"
                    Application.DoEvents()
                    Try
                        Me.filename = form2.Options.FilePath
                        SaveF(form2.Options.FilePath, form2)
                    Catch ex As Exception
                        VDialog.Show(ex.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        Me.ToolStripStatusLabel1.Text = ""
                    End Try
                Else
                    Dim myStream As System.IO.FileStream
                    If Me.SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        myStream = Me.SaveFileDialog1.OpenFile()
                        Me.filename = myStream.Name
                        myStream.Close()
                        If Not (myStream Is Nothing) Then
                            Me.ToolStripStatusLabel1.Text = RELAP.App.GetLocalString("Salvandosimulao") + " (" + Me.filename + ")"
                            Application.DoEvents()
                            Try
                                SaveF(myStream.Name, form2)
                            Catch ex As Exception
                                VDialog.Show(ex.Message, RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Finally
                                Me.ToolStripStatusLabel1.Text = ""
                            End Try
                        End If
                    End If
                End If
                'ElseIf TypeOf Me.ActiveMdiChild Is FormCompoundCreator Then
                '    If Me.SaveStudyDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                '        Dim objStreamWriter As New FileStream(Me.SaveStudyDlg.FileName, FileMode.OpenOrCreate)
                '        Dim x As New BinaryFormatter
                '        x.Serialize(objStreamWriter, CType(Me.ActiveMdiChild, FormCompoundCreator).mycase)
                '        objStreamWriter.Close()
                '    End If
                'ElseIf TypeOf Me.ActiveMdiChild Is FormDataRegression Then
                '    If Me.SaveRegStudyDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                '        Dim objStreamWriter As New FileStream(Me.SaveRegStudyDlg.FileName, FileMode.OpenOrCreate)
                '        Dim x As New BinaryFormatter
                '        x.Serialize(objStreamWriter, CType(Me.ActiveMdiChild, FormDataRegression).StoreCase())
                '        objStreamWriter.Close()
                '    End If
            End If
        Else
            VDialog.Show(RELAP.App.GetLocalString("Noexistemsimulaesati"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click, SaveAsToolStripMenuItem.Click
        Call Me.SaveFileDialog()
    End Sub

    Private Sub FecharTodasAsSimulaçõesAbertasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolstripMenuItem.Click
        If Me.MdiChildren.Length > 0 Then
            Dim form2 As Form
            For Each form2 In Me.MdiChildren
                Application.DoEvents()
                Try
                    form2.Close()
                Catch ex As Exception
                    Console.WriteLine(ex.ToString)
                End Try
                Application.DoEvents()
            Next
        Else
            VDialog.Show(RELAP.App.GetLocalString("Noexistemsimulaesase"), RELAP.App.GetLocalString("Informao"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BlogDeDesenvolvimentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlogDeDesenvolvimentoToolStripMenuItem.Click
        'System.Diagnostics.Process.Start("http://RELAP.inforside.com.br")
    End Sub

    Private Sub DownloadsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadsToolStripMenuItem.Click
        'System.Diagnostics.Process.Start("http://sourceforge.net/project/showfiles.php?group_id=233626")
    End Sub

    Private Sub WikiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WikiToolStripMenuItem.Click
        ' System.Diagnostics.Process.Start("http://apps.sourceforge.net/mediawiki/RELAP/")
    End Sub

    Private Sub FórumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForumToolStripMenuItem.Click
        ' System.Diagnostics.Process.Start("http://sourceforge.net/forum/?group_id=233626")
    End Sub

    Private Sub RastreamentoDeBugsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RastreamentoDeBugsToolStripMenuItem.Click
        'System.Diagnostics.Process.Start("http://sourceforge.net/tracker/?group_id=233626")
    End Sub

    Private Sub DonateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DonateToolStripMenuItem.Click
        'System.Diagnostics.Process.Start("http://sourceforge.net/project/project_donations.php?group_id=233626")
    End Sub

    Private Sub MostrarBarraDeFerramentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MostrarBarraDeFerramentasToolStripMenuItem.Click
        If Me.MostrarBarraDeFerramentasToolStripMenuItem.Checked Then
            Me.ToolStrip1.Visible = True
        Else
            Me.ToolStrip1.Visible = False
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        '   Me.PreferênciasDoRELAPToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.CascadeToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Me.TileVerticleToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Me.TileHorizontalToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Me.DonateToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        Me.AboutToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        My.Computer.Keyboard.SendKeys("{F1}", True)
    End Sub

    Private Sub RegistrarTiposCOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarTiposCOMToolStripMenuItem.Click

        Dim windir As String = Environment.GetEnvironmentVariable("SystemRoot")
        Process.Start(windir & "\Microsoft.NET\Framework\v2.0.50727\RegAsm.exe", "/codebase /silent " & Chr(34) & My.Application.Info.DirectoryPath & " \RELAP.exe" & Chr(34))

    End Sub

    Private Sub DeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeToolStripMenuItem.Click

        Dim windir As String = Environment.GetEnvironmentVariable("SystemRoot")
        Process.Start(windir & "\Microsoft.NET\Framework\v2.0.50727\RegAsm.exe", "/u " & Chr(34) & My.Application.Info.DirectoryPath & " \RELAP.exe" & Chr(34))

    End Sub

    Private Sub tslupd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tslupd.Click
        Dim myfile As String = My.Computer.FileSystem.SpecialDirectories.Temp & Path.DirectorySeparatorChar & "RELAP" & Path.DirectorySeparatorChar & "RELAP.txt"
        Dim txt() As String = File.ReadAllLines(myfile)
        Dim build As Integer, bdate As Date, fname As String, dlpath As String, changelog As String = ""
        build = txt(0)
        bdate = Date.Parse(txt(1), New CultureInfo("en-US"))
        dlpath = txt(2)
        fname = txt(3)
        For i As Integer = 4 To txt.Length - 1
            changelog += txt(i) + vbCrLf
        Next
        Dim strb As New StringBuilder()
        With strb
            .AppendLine(RELAP.App.GetLocalString("BuildNumber") & ": " & build & vbCrLf)
            .AppendLine(RELAP.App.GetLocalString("BuildDate") & ": " & bdate.ToString(My.Application.Culture.DateTimeFormat.ShortDatePattern, My.Application.Culture) & vbCrLf)
            .AppendLine(RELAP.App.GetLocalString("Changes") & ": " & vbCrLf & changelog & vbCrLf)
            .AppendLine(RELAP.App.GetLocalString("DownloadQuestion"))
        End With
        Dim msgresult As MsgBoxResult = VDialog.Show(strb.ToString, RELAP.App.GetLocalString("NewVersionAvailable"), MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If msgresult = MsgBoxResult.Yes Then
            'Me.sfdUpdater.FileName = fname
            'If Me.sfdUpdater.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            'Try
            'My.Computer.Network.DownloadFile(dlpath, Me.sfdUpdater.FileName, "", "", True, 100000, True, FileIO.UICancelOption.DoNothing)
            Process.Start(dlpath)
            tslupd.Visible = False
            'Catch ex As Exception
            'VDialog.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
            'End If
        End If
    End Sub

    'Private Sub NovoEstudoDoCriadorDeComponentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovoEstudoDoCriadorDeComponentesToolStripMenuItem.Click
    '    Dim NewMDIChild As New FormCompoundCreator()
    '    'Set the Parent Form of the Child window.
    '    NewMDIChild.MdiParent = Me
    '    'Display the new form.
    '    NewMDIChild.Text = "CompCreator" & m_childcount
    '    Me.ActivateMdiChild(NewMDIChild)
    '    NewMDIChild.Show()
    '    m_childcount += 1
    'End Sub

    'Private Sub NovoEstudoDeRegressãoDeDadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NovoEstudoDeRegressãoDeDadosToolStripMenuItem.Click
    '    Dim NewMDIChild As New FormDataRegression()
    '    'Set the Parent Form of the Child window.
    '    NewMDIChild.MdiParent = Me
    '    'Display the new form.
    '    NewMDIChild.Text = "DataRegression" & m_childcount
    '    Me.ActivateMdiChild(NewMDIChild)
    '    NewMDIChild.Show()
    '    m_childcount += 1
    'End Sub

    'Private Sub PreferênciasDoRELAPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreferênciasDoRELAPToolStripMenuItem.Click
    '    Me.FrmOptions = New FormOptions
    '    Me.FrmOptions.ShowDialog(Me)
    'End Sub

#End Region

#Region "    Backup/Update"

    Private Sub TimerBackup_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerBackup.Tick

        Dim folder As String = My.Settings.BackupFolder
        If Not Directory.Exists(folder) And folder <> "" Then
            Try
                Directory.CreateDirectory(folder)
            Catch ex As Exception
                VDialog.Show(RELAP.App.GetLocalString("Erroaocriardiretriop") & vbCrLf & RELAP.App.GetLocalString("Verifiquesevoctemonv"), _
                             RELAP.App.GetLocalString("Cpiasdesegurana"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        If Directory.Exists(folder) Then
            '     If Not Me.bgSaveBackup.IsBusy Then Me.bgSaveBackup.RunWorkerAsync()
        End If

    End Sub

    Private Sub bgSaveBackup_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgSaveBackup.DoWork
        Dim bw As BackgroundWorker = CType(sender, BackgroundWorker)
        ' Start the time-consuming operation.
        Dim folder As String = My.Settings.BackupFolder
        Dim path As String = ""
        For Each form0 As Form In Me.MdiChildren
            If TypeOf form0 Is FormFlowsheet Then
                path = folder + "\" + CType(form0, FormFlowsheet).Options.BackupFileName
                Me.SaveF(path, form0)
                If Not My.Settings.BackupFiles.Contains(path) Then
                    My.Settings.BackupFiles.Add(path)
                    My.Settings.Save()
                End If
            End If
        Next
    End Sub

    Private Sub bgSaveBackup_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgSaveBackup.RunWorkerCompleted
        If Not (e.Error Is Nothing) Then
            ' There was an error during the operation.
            VDialog.Show("Erro ao salvar cópias de segurança: " & e.Error.Message & vbCrLf & RELAP.App.GetLocalString("Paranovermaisesseavi"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            My.Application.Log.WriteException(e.Error)
        End If
    End Sub

    Private Sub bgUpdater_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

        Dim myfile As String = My.Computer.FileSystem.SpecialDirectories.Temp & Path.DirectorySeparatorChar & "RELAP" & Path.DirectorySeparatorChar & "RELAP.txt"
        Dim webp As New System.Net.WebProxy
        webp.UseDefaultCredentials = True
        Dim webcl As New System.Net.WebClient()
        webcl.Proxy = webp
        webcl.DownloadFile("http://RELAP.inforside.com.br/RELAP.txt", myfile)
        dlok = True

    End Sub

    Private Sub bgUpdater_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If dlok Then
            Dim myfile As String = My.Computer.FileSystem.SpecialDirectories.Temp & Path.DirectorySeparatorChar & "RELAP" & Path.DirectorySeparatorChar & "RELAP.txt"
            If File.Exists(myfile) Then
                Dim txt() As String = File.ReadAllLines(myfile)
                Dim build As Integer
                build = txt(0)
                If My.Application.Info.Version.Build < CInt(build) Then
                    tslupd.Visible = True
                    tslupd.Text = RELAP.App.GetLocalString("NewVersionAvailable")
                End If
            End If
        End If
    End Sub

#End Region
    Private ChildParent As FormFlowsheet
    Function boolto10(ByVal val) As String
        If val = True Then
            Return "1"
        Else
            Return "0"
        End If
    End Function

    Function boolto01(ByVal val) As String
        If val = True Then
            Return "0"
        Else
            Return "1"
        End If
    End Function

    Function GetUIDFromTag(ByVal tag) As String
        For Each obj As SimulationObjects_BaseClass In My.Application.ActiveSimulation.Collections.ObjectCollection.Values
            If obj.GraphicObject.Tag = tag Then
                Return obj.UID
            End If
        Next
        Return 0
    End Function

    Private Sub GenerateInputFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateInputFileOnlyToolStripMenuItem.Click
        Dim collect As New RELAP.FormClasses.ClsObjectCollections
        Dim ChildParent = My.Application.ActiveSimulation

        univID = 1

        Dim frmInitialSettings = My.Application.ActiveSimulation.FormInitialSettings
        Dim frmMaterials = My.Application.ActiveSimulation.FormMaterials

        ' input file generation code

        If frmInitialSettings.optWater.Checked = True Then

        End If

        SaveFileDialog1.Filter = "RELAP CODE File (*.i)|*.i"
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim generate As StreamWriter = File.CreateText(SaveFileDialog1.FileName)
            Dim output As String = Nothing
            Dim output1 As String = Nothing
            Dim output2 As String = Nothing
            Dim output3 As String = Nothing
            Dim output4 As String = Nothing
            Dim output5 As String = Nothing
            Dim output6 As String = Nothing
            Dim output7 As String = Nothing
            Dim output8 As String = Nothing
            Dim output9 As String = Nothing
            Dim output10 As String = Nothing
            Dim fluidchk As String = Nothing
            Dim boronchk As String = Nothing
            Dim filename As String() = SaveFileDialog1.FileName.Split("\")

            generate.WriteLine("= " & filename(filename.Length - 1))
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*          CODE GENERATED BY RELAP-GUI V-PRE RELEASE")
            generate.WriteLine("*          COPY RIGHT @ PIEAS PAKISTAN")
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*======================================================================")
            generate.WriteLine(("*FILE :" & SaveFileDialog1.FileName & "   ") + DateTime.Now)
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*          PROBLEM TYPE AND OPTIONS card")
            generate.WriteLine("*======================================================================")

            ' card 100
            output = ChildParent.cboProblemType.SelectedItem.ToString.ToLower

            output = output & " " & ChildParent.cboProblemOption.SelectedItem.ToString.ToLower

            output = "100 " & output
            generate.WriteLine(output)

            ' card 101
            generate.WriteLine("101 " & ChildParent.cboInputCheck.SelectedItem.ToString.ToLower)



            ' card 102 unit selection
            output = ChildParent.ToolStripComboBoxUnitSystem.SelectedItem.ToString.ToLower & " " & ChildParent.cboOutputUnits.SelectedItem.ToString.ToLower

            generate.WriteLine("102 " & output)
            generate.WriteLine("104 " & My.Application.ActiveSimulation.FormPlotReqest.cboRestartPlotSettings.SelectedText)
            generate.WriteLine("105 10.0 40.0 200.0")
            generate.WriteLine("105 " & My.Application.ActiveSimulation.FormInitialSettings.txtCPURemaining1.Text & " " & My.Application.ActiveSimulation.FormInitialSettings.txtCPURemaining2.Text & " " & My.Application.ActiveSimulation.FormInitialSettings.txtCPUTimeAllocated.Text)

            ' 110  noncondensible gas
            Dim gascount As Integer = 1
            Dim i = 1
            'If frmInitialSettings.chklistboxCondensibleGases.SelectedItems.Count = 0 Then
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*          Non condensible gases card")
            generate.WriteLine("*======================================================================")

            output = ""
            For i = 0 To frmInitialSettings.chklistboxCondensibleGases.CheckedItems.Count - 1
                output = output & " " & frmInitialSettings.chklistboxCondensibleGases.CheckedItems(i).ToString
            Next
            generate.WriteLine("110 " & output)
            generate.WriteLine("115 " & "1.0")
            generate.WriteLine("50000000 couple" & frmInitialSettings.cboCoupleStyle.SelectedText)
            generate.WriteLine("51010000 1 " & RELAP.App.GetUIDFromTag(frmInitialSettings.cboDebrisVolume.SelectedText) & " " & frmInitialSettings.cboDebrisSource.SelectedValue & " " & frmInitialSettings.cboDebrisBreakup.SelectedValue & " " & frmInitialSettings.txtMaxHydraulicStep.Text & " " & frmInitialSettings.txtCoupleTimeStep.Text)




            'card 201

            output = frmInitialSettings.txtendtime.Text & " " & frmInitialSettings.txtminsteptime.Text & " " & frmInitialSettings.txtmaxsteptime.Text & " " & frmInitialSettings.txtcontroloption.Text & " " & frmInitialSettings.txtMinorFrequency.Text & " " & frmInitialSettings.txtMajorFrequency.Text & " " & frmInitialSettings.txtRestartFrequency.Text
            generate.WriteLine("201 " & output)

            generate.WriteLine("*======================================================================")
            generate.WriteLine("*                         PLOT REQUEST")
            generate.WriteLine("*======================================================================")

            'card 203
            i = 1
            Dim row As DataGridViewRow
            For j = 0 To My.Application.ActiveSimulation.FormPlotReqest.DataGridView1.Rows.Count - 2
                row = My.Application.ActiveSimulation.FormPlotReqest.DataGridView1.Rows(j)
                Dim _uid = RELAP.App.GetUIDFromTag(row.Cells(0).Value)
                If row.Cells(0).Value = "HS000" Then
                    If row.Cells(1).Value = "Linear" Then
                        If row.Cells(3).Value = "Right" Then
                            output = "2030001" & i & " " & row.Cells(1).Value.ToLower() & " " & _uid & "000101 2"
                        Else
                            output = "2030001" & i & " " & row.Cells(1).Value.ToLower() & " " & _uid & "000101 1"
                        End If

                    Else
                        If row.Cells(3).Value = "Right" Then
                            output = "2030001" & i & " " & row.Cells(1).Value.ToLower() & " " & _uid & "000101 -2"
                        Else
                            output = "2030001" & i & " " & row.Cells(1).Value.ToLower() & " " & _uid & "000101 -1"
                        End If

                    End If
                Else
                    If row.Cells(1).Value = "Linear" Then
                        If row.Cells(3).Value = "Right" Then
                            output = "2030001" & i & " " & row.Cells(1).Value.ToLower() & " " & _uid & "000000 2"
                        Else
                            output = "2030001" & i & " " & row.Cells(1).Value.ToLower() & " " & _uid & "000000 1"
                        End If

                    Else
                        If row.Cells(3).Value = "Right" Then
                            output = "2030001" & i & " " & row.Cells(1).Value.ToLower() & " " & _uid & "000000 -2"
                        Else
                            output = "2030001" & i & " " & row.Cells(1).Value.ToLower() & " " & _uid & "000000 -1"
                        End If

                    End If
                End If
                i = i + 1
                generate.WriteLine(output)
            Next
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*                            Minor Edits ")
            generate.WriteLine("*======================================================================")

            Dim card As Integer = 301
            For Each temprow As DataGridViewRow In My.Application.ActiveSimulation.FormMinorEditRequests.DataGridView1.Rows
                If Not temprow.Cells(0).Value Is Nothing Then
                    generate.WriteLine(card & " " & temprow.Cells(0).Value & " " & temprow.Cells(1).Value)
                    card = card + 1
                End If
            Next
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*                            Trips ")
            generate.WriteLine("*======================================================================")

            card = 501
            For Each temprow As DataGridViewRow In My.Application.ActiveSimulation.FormTrips.DataGridView1.Rows
                If temprow.Cells(0).Value.ToString <> "" Then
                    card = 500 + temprow.Cells(0).Value
                    Dim latch As String
                    If temprow.Cells(0).Value.ToString.ToLower = "true" Then
                        latch = "l"
                    Else
                        latch = "n"
                    End If
                    generate.WriteLine(card & " " & temprow.Cells(1).Value & " " & RELAP.App.GetUIDFromTag(temprow.Cells(10).Value) & temprow.Cells(3).Value.ToString("D2") & " " & temprow.Cells(4).Value & " " & temprow.Cells(5).Value & " " & RELAP.App.GetUIDFromTag(temprow.Cells(11).Value) & temprow.Cells(7).Value.ToString("D2") & " " & temprow.Cells(8).Value & " " & latch & " " & temprow.Cells(10).Value)

                End If
            Next
            card = 601
            For Each temprow As DataGridViewRow In My.Application.ActiveSimulation.FormTrips.DataGridViewX1.Rows
                'If temprow.Cells(0).Value.ToString <> "" Then
                '    generate.WriteLine(card & " " & temprow.Cells(0).Value & " " & (temprow.Cells(1).Value) & " " & temprow.Cells(2).Value & " " & (temprow.Cells(3).Value) & " " & temprow.Cells(4).Value)

                '      End If

                card = card + 1
            Next


            generate.WriteLine("*======================================================================")
            generate.WriteLine("*                            Expanded Plot Variables ")
            generate.WriteLine("*======================================================================")
            card = 20800001
            For Each temprow As DataGridViewRow In My.Application.ActiveSimulation.FormPlotReqest.DataGridView2.Rows
                '     If temprow.Cells(0).Value.ToString <> "" Then
                generate.WriteLine(card & " " & temprow.Cells(0).Value & " " & (temprow.Cells(1).Value))

                ' End If
                card = card + 1
            Next
            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.Tank) In ChildParent.Collections.CLCS_TankCollection
                '  MsgBox(kvp.Key)
                'kvp.Value.FlowArea.cardno()
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Time Dependent Volume '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ tmdpvol")

                output = ((((((((kvp.Value.UID & "0101 " & kvp.Value.FlowArea.ToString("F") & " ") & kvp.Value.LengthofVolume.ToString("F") & " ") & kvp.Value.VolumeofVolume.ToString("F") & " ") & kvp.Value.Azimuthalangle.ToString("F") & " ") & kvp.Value.InclinationAngle.ToString("F") & " ") & kvp.Value.ElevationChange.ToString("F") & " ") & kvp.Value.WallRoughness.ToString("F") & " ") & kvp.Value.HydraulicDiameter.ToString("F") & " ") & "0000000"
                generate.WriteLine(output)

                If frmInitialSettings.optDefaultFluid.Checked = True Then
                    fluidchk = "0"
                ElseIf frmInitialSettings.optWater.Checked = True Then
                    fluidchk = "1"
                ElseIf frmInitialSettings.optHeavyWater.Checked = True Then
                    fluidchk = "2"
                End If

                If frmInitialSettings.chklistboxBoron.Checked = False Then
                    boronchk = "0"
                Else : boronchk = "1"
                End If

                If kvp.Value.ThermoDynamicStates.State.Count > 0 Then
                    generate.WriteLine(kvp.Value.UID & "0200 " & fluidchk & boronchk & kvp.Value.ThermoDynamicStates.State(1).StateType)
                End If
                Dim Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, ThermoDynamicState) In kvp.Value.ThermoDynamicStates.State
                    generate.WriteLine(kvp.Value.UID & "020" & Counter & kvp2.Value.StatesString)
                    Counter = Counter + 1
                Next kvp2
                univID = univID + 1

            Next kvp

            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.SingleVolume) In ChildParent.Collections.CLCS_SingleVolumeCollection

                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Single Volume '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ snglvol")

                output = kvp.Value.UID & "0101 " & kvp.Value.FlowArea.ToString("F") & " " & kvp.Value.LengthofVolume.ToString("F") & " " & kvp.Value.VolumeofVolume.ToString("F") & " " & kvp.Value.Azimuthalangle.ToString("F") & " " & kvp.Value.InclinationAngle.ToString("F") & " " & kvp.Value.ElevationChange.ToString("F") & " " & kvp.Value.WallRoughness.ToString("F") & " " & kvp.Value.HydraulicDiameter.ToString("F") & " "
                output3 = boolto10(kvp.Value.PipeInterphaseFriction)
                output4 = boolto10(kvp.Value.RodInterphaseFriction)
                If output4 = "1" Then
                    output2 = "1"
                Else : output2 = "0"
                End If
                output1 = boolto10(kvp.Value.ThermalStratificationModel) & boolto10(kvp.Value.LevelTrackingModel) & boolto01(kvp.Value.WaterPackingScheme) & boolto01(kvp.Value.VerticalStratificationModel) & output2 & boolto01(kvp.Value.ComputeWallFriction) & boolto10(kvp.Value.EquilibriumTemperature)
                generate.WriteLine(output & output1)

                If frmInitialSettings.optDefaultFluid.Checked = True Then
                    fluidchk = "0"
                ElseIf frmInitialSettings.optWater.Checked = True Then
                    fluidchk = "1"
                ElseIf frmInitialSettings.optHeavyWater.Checked = True Then
                    fluidchk = "2"
                End If

                If frmInitialSettings.chklistboxBoron.Checked = False Then
                    boronchk = "0"
                Else : boronchk = "1"
                End If

                If kvp.Value.ThermoDynamicStates.State.Count > 0 Then
                    output = fluidchk & boronchk & kvp.Value.ThermoDynamicStates.State(1).StateType
                End If

                For Each kvp2 As KeyValuePair(Of Integer, ThermoDynamicState) In kvp.Value.ThermoDynamicStates.State
                    generate.WriteLine(kvp.Value.UID & "0200" & " " & output & kvp2.Value.StatesString)
                Next kvp2
                univID = univID + 1

            Next kvp


            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.SingleJunction) In ChildParent.Collections.CLCS_SingleJunctionCollection
                '  MsgBox(kvp.Key)
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Single Junction '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ sngljun")

                output = kvp.Value.UID & "0101 " & kvp.Value.FromComponent & CInt(kvp.Value.FromVolume).ToString("D2") & "000" & kvp.Value.FromDirection & " " & kvp.Value.ToComponent & CInt(kvp.Value.ToVolume).ToString("D2") & "000" & kvp.Value.ToDirection & " " & kvp.Value.JunctionArea & " " & kvp.Value.FflowLossCo & " " & kvp.Value.RflowLossCo & " " & "0000100" '& " " & kvp.Value.SubcooledDishargeCo & " " & kvp.Value.TwoPhaseDischargeCo & " " & kvp.Value.SuperheatedDishargeCo
                generate.WriteLine(output)

                If kvp.Value.EnterVelocityOrMassFlowRate = False Then
                    output = (((kvp.Value.UID & "0201 " & "0" & " ") & kvp.Value.InitialLiquidVelocity & " ") & kvp.Value.InitialVaporVelocity & " ") & kvp.Value.InterphaseVelocity
                ElseIf kvp.Value.EnterVelocityOrMassFlowRate = True Then
                    output = (((kvp.Value.UID & "0201 " & "1" & " ") & kvp.Value.InitialLiquidMassFlowRate & " ") & kvp.Value.InitialVaporMassFlowRate & " ") & kvp.Value.InterphaseVelocity
                End If
                generate.WriteLine(output)

                univID = univID + 1

            Next kvp

            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.TimeDependentJunction) In ChildParent.Collections.CLCS_TimeDependentJunctionCollection
                '  MsgBox(kvp.Key)
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Time Dependent Junction '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ tmdpjun")

                output = kvp.Value.UID & "0101 " & kvp.Value.FromComponent & CInt(kvp.Value.FromVolume).ToString("D2") & "000" & kvp.Value.FromDirection & " " & kvp.Value.ToComponent & CInt(kvp.Value.ToVolume).ToString("D2") & "000" & kvp.Value.ToDirection & " " & kvp.Value.JunctionArea
                generate.WriteLine(output)

                output = kvp.Value.UID & "0200 " & kvp.Value.JunctionsData.EnterMassorVelocity
                generate.WriteLine(output)

                Dim Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, JunctionDatavelocity) In kvp.Value.JunctionsData.JunctionDatavelocity
                    output = kvp.Value.UID & "0" & "20" & Counter & " " & kvp2.Value.TimeVelocity.ToString("F") & " " & kvp2.Value.LiquidVelocity.ToString("F") & " " & kvp2.Value.VaporVelocity.ToString("F") & " " & kvp2.Value.InterfaceVelocityv.ToString("F")
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, JunctionDataMass) In kvp.Value.JunctionsData.JunctionDataMass
                    output = kvp.Value.UID & "0" & "20" & Counter & " " & kvp2.Value.TimeMass.ToString("F") & " " & kvp2.Value.LiquidMassFlow.ToString("F") & " " & kvp2.Value.VaporMassFlow.ToString("F") & " " & kvp2.Value.InterfaceVelocitym.ToString("F")
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                univID = univID + 1
                '  MsgBox(kvp.Value.ComponentName)
            Next kvp

            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.Valve) In ChildParent.Collections.CLCS_ValveCollection
                '  MsgBox(kvp.Key)
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Valve '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ valve")
                output1 = boolto10(kvp.Value.pvterm)
                output2 = boolto10(kvp.Value.CCFL)
                If kvp.Value.StratificationModel.ToString = "Dont_use_this_model" Then
                    output3 = "0"
                ElseIf kvp.Value.StratificationModel.ToString = "upward_oriented_junction" Then
                    output3 = "1"
                ElseIf kvp.Value.StratificationModel.ToString = "downward_oriented_junction" Then
                    output3 = "2"
                ElseIf kvp.Value.StratificationModel.ToString = "centrally_located_junction" Then
                    output3 = "3"
                End If
                output4 = boolto01(kvp.Value.chokingModel)
                If kvp.Value.AreaChange.ToString = "No_Area_Change" Then
                    output5 = "0"
                ElseIf kvp.Value.AreaChange.ToString = "Smooth_Area_Change" Then
                    output5 = "0"
                ElseIf kvp.Value.AreaChange.ToString = "Full_Abrupt_Area_Change" Then
                    output5 = "1"
                ElseIf kvp.Value.AreaChange.ToString = "Partial_Abrupt_Area_Change" Then
                    output5 = "2"
                End If
                If kvp.Value.MomentumEquation.ToString = "Two_velocity_Momentum_Equations" Then
                    output6 = "0"
                ElseIf kvp.Value.MomentumEquation.ToString = "Single_velocity_Momentum_Equations" Then
                    output6 = "1"
                End If
                If kvp.Value.MomentumFlux.ToString = "To_and_From_Volume" Then
                    output7 = "0"
                ElseIf kvp.Value.MomentumFlux.ToString = "Only_From_Volume" Then
                    output7 = "1"
                ElseIf kvp.Value.MomentumFlux.ToString = "Only_To_Volume" Then
                    output7 = "2"
                ElseIf kvp.Value.MomentumFlux.ToString = "Do_not_use_Momentum_Flux" Then
                    output7 = "3"
                End If
                output = kvp.Value.FromComponent & CInt(kvp.Value.FromVolume).ToString("D2") & "000" & kvp.Value.FromDirection & " " & kvp.Value.ToComponent & CInt(kvp.Value.ToVolume).ToString("D2") & "000" & kvp.Value.ToDirection & " " & kvp.Value.JunctionArea & " " & kvp.Value.FflowLossCo & " " & kvp.Value.RflowLossCo & " " & output1 & output2 & output3 & output4 & output5 & output6 & output7
                generate.WriteLine(kvp.Value.UID & "0101 " & output)

                If kvp.Value.EnterVelocityOrMassFlowRate = False Then
                    output = (((kvp.Value.UID & "0201 " & "0" & " ") & " " & kvp.Value.InitialLiquidVelocity & " ") & kvp.Value.InitialVaporVelocity & " ") & kvp.Value.InterphaseVelocity
                ElseIf kvp.Value.EnterVelocityOrMassFlowRate = True Then
                    output = (((kvp.Value.UID & "0201 " & "1" & " ") & " " & kvp.Value.InitialLiquidMassFlowRate & " ") & kvp.Value.InitialVaporMassFlowRate & " ") & kvp.Value.InterphaseVelocity
                End If
                generate.WriteLine(output)

                univID = univID + 1

                generate.WriteLine(kvp.Value.UID & "0300 " + kvp.Value.ValveType.ValveTypeName)

                If kvp.Value.ValveType.ValveTypeName = Nothing Then
                    MsgBox("Select Valve type")
                    output = ""

                ElseIf kvp.Value.ValveType.ValveTypeName = "chkvlv" Then
                    'Static Pressure Controlled Check Valve
                    'Static Pressure/Flow Controlled Check Valve
                    'Static/Dynamic Pressure Controlled Check Valve

                    If kvp.Value.ValveType.CheckType = "0" Then
                        output1 = "+1"
                    ElseIf kvp.Value.ValveType.CheckType = "1" Then
                        output1 = "0"
                    ElseIf kvp.Value.ValveType.CheckType = "2" Then
                        output1 = "-1"
                    Else
                        output1 = "0"
                    End If
                    output = output1 & " " & kvp.Value.ValveType.checkPosition & " " & CDbl(kvp.Value.ValveType.checkbackpressure).ToString("F") & " " & CDbl(kvp.Value.ValveType.checkleakratio).ToString("F")
                ElseIf kvp.Value.ValveType.ValveTypeName = "trpvlv" Then
                    output = kvp.Value.ValveType.tripvalvetripno
                ElseIf kvp.Value.ValveType.ValveTypeName = "inrvlv" Then
                    output = kvp.Value.ValveType.inertialLatchoption & " " & kvp.Value.ValveType.inertialInitialposition & " " & CDbl(kvp.Value.ValveType.inertialbackpressure).ToString("F") & " " & CDbl(kvp.Value.ValveType.inertialLeakratio).ToString("F") & " " & CDbl(kvp.Value.ValveType.inertialinitialangle).ToString("F") & " " & CDbl(kvp.Value.ValveType.inertialminangle).ToString("F") & " " & CDbl(kvp.Value.ValveType.inertialmaxangle).ToString("F") & " " & CDbl(kvp.Value.ValveType.inertialmomentinertia).ToString("F") & " " & CDbl(kvp.Value.ValveType.inertialangularvelocity).ToString("F") & " " & CDbl(kvp.Value.ValveType.inertialmomentlength).ToString("F") & " " & CDbl(kvp.Value.ValveType.inertialradius).ToString("F") & " " & CDbl(kvp.Value.ValveType.inertialmass).ToString("F")
                ElseIf kvp.Value.ValveType.ValveTypeName = "mtrvlv" Then
                    output = kvp.Value.ValveType.pmotor1 & " " & kvp.Value.ValveType.pmotor2 & " " & CDbl(kvp.Value.ValveType.pmotor3).ToString("F") & " " & CDbl(kvp.Value.ValveType.pmotor4).ToString("F") & " " & kvp.Value.ValveType.pmotor5
                ElseIf kvp.Value.ValveType.ValveTypeName = "srvvlv" Then
                    output = kvp.Value.ValveType.pservo1 & " " & kvp.Value.ValveType.pservo2
                ElseIf kvp.Value.ValveType.ValveTypeName = "rlfvlv" Then
                    output = kvp.Value.ValveType.prel1 & " " & CDbl(kvp.Value.ValveType.prel2).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel3).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel4).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel5).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel6).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel7).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel8).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel9).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel10).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel11).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel12).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel13).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel14).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel15).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel16).ToString("F") & " " & CDbl(kvp.Value.ValveType.prel17).ToString("F")
                End If
                generate.WriteLine(kvp.Value.UID & "0301 " & output)
                Dim counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, ValveCSUB) In kvp.Value.ValveType.ProValveCSUB
                    generate.WriteLine(kvp.Value.UID & "04" & counter.ToString("D2") & " " & kvp2.Value.NormalizedFlowArea.ToString("F") & " " & kvp2.Value.ForwardCSUBV.ToString("F") & " " & kvp2.Value.ReverseCSUBV.ToString("F"))
                    counter = counter + 1
                Next kvp2
                univID = univID + 1

            Next kvp

            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.Pump) In ChildParent.Collections.CLCS_PumpCollection
                '  MsgBox(kvp.Key)
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Pump '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ pump")

                output = ((((((kvp.Value.UID & "0101 " & kvp.Value.FlowArea & " ") & kvp.Value.LengthofVolume & " ") & kvp.Value.VolumeofVolume & " ") & kvp.Value.Azimuthalangle & " ") & kvp.Value.InclinationAngle & " ") & kvp.Value.ElevationChange & " ") & "0"
                generate.WriteLine(output)

                output1 = boolto10(kvp.Value.CCFL)
                output2 = boolto01(kvp.Value.chokingModel)
                If kvp.Value.AreaChange.ToString = "No_Area_Change" Then
                    output3 = "0"
                ElseIf kvp.Value.AreaChange.ToString = "Smooth_Area_Change" Then
                    output3 = "0"
                ElseIf kvp.Value.AreaChange.ToString = "Full_Abrupt_Area_Change" Then
                    output3 = "1"
                ElseIf kvp.Value.AreaChange.ToString = "Partial_Abrupt_Area_Change" Then
                    output3 = "2"
                End If
                If kvp.Value.MomentumEquation.ToString = "Two_velocity_Momentum_Equations" Then
                    output4 = "0"
                ElseIf kvp.Value.MomentumEquation.ToString = "Single_velocity_Momentum_Equations" Then
                    output4 = "1"
                End If
                output = kvp.Value.UID & "0108 " & kvp.Value.FromComponent & CInt(kvp.Value.FromVolume).ToString("D2") & "000" & kvp.Value.FromDirection & " " & kvp.Value.JunctionArea & " " & kvp.Value.FflowLossCo & " " & kvp.Value.RflowLossCo & " " & "0" & output1 & "0" & output2 & output3 & output4 & "0"
                generate.WriteLine(output)

                output1 = boolto10(kvp.Value.OCCFL)
                output2 = boolto01(kvp.Value.OchokingModel)
                If kvp.Value.OAreaChange.ToString = "No_Area_Change" Then
                    output3 = "0"
                ElseIf kvp.Value.OAreaChange.ToString = "Smooth_Area_Change" Then
                    output3 = "0"
                ElseIf kvp.Value.OAreaChange.ToString = "Full_Abrupt_Area_Change" Then
                    output3 = "1"
                ElseIf kvp.Value.OAreaChange.ToString = "Partial_Abrupt_Area_Change" Then
                    output3 = "2"
                End If
                If kvp.Value.OMomentumEquation.ToString = "Two_velocity_Momentum_Equations" Then
                    output4 = "0"
                ElseIf kvp.Value.OMomentumEquation.ToString = "Single_velocity_Momentum_Equations" Then
                    output4 = "1"
                End If
                output = kvp.Value.UID & "0109 " & kvp.Value.ToComponent & CInt(kvp.Value.ToVolume).ToString("D2") & "000" & kvp.Value.ToDirection & " " & kvp.Value.OJunctionArea & " " & kvp.Value.OFflowLossCo & " " & kvp.Value.ORflowLossCo & " " & "0" & output1 & "0" & output2 & output3 & output4 & "0"
                generate.WriteLine(output)
                If frmInitialSettings.optDefaultFluid.Checked = True Then
                    fluidchk = "0"
                ElseIf frmInitialSettings.optWater.Checked = True Then
                    fluidchk = "1"
                ElseIf frmInitialSettings.optHeavyWater.Checked = True Then
                    fluidchk = "2"
                End If

                If frmInitialSettings.chklistboxBoron.Checked = False Then
                    boronchk = "0"
                Else : boronchk = "1"
                End If

                If kvp.Value.ThermoDynamicStates.State.Count > 0 Then
                    output = fluidchk & boronchk & kvp.Value.ThermoDynamicStates.State(1).StateType
                End If

                For Each kvp2 As KeyValuePair(Of Integer, ThermoDynamicState) In kvp.Value.ThermoDynamicStates.State
                    generate.WriteLine(kvp.Value.UID & "0200" & " " & output & kvp2.Value.StatesString)
                Next

                If kvp.Value.EnterVelocityOrMassFlowRate = False Then
                    output = (((kvp.Value.UID & "0201 " & "0" & " ") & kvp.Value.InitialLiquidVelocity.ToString("F") & " ") & kvp.Value.InitialVaporVelocity.ToString("F") & " ") & "0"
                    generate.WriteLine(output)
                ElseIf kvp.Value.EnterVelocityOrMassFlowRate = True Then
                    output = (((kvp.Value.UID & "0201 " & "1" & " ") & kvp.Value.InitialLiquidMassFlowRate.ToString("F") & " ") & kvp.Value.InitialVaporMassFlowRate.ToString("F") & " ") & "0"
                    generate.WriteLine(output)
                End If

                If kvp.Value.OEnterVelocityOrMassFlowRate = False Then
                    output = (((kvp.Value.UID & "0202 " & "0" & " ") & kvp.Value.OInitialLiquidVelocity.ToString("F") & " ") & kvp.Value.OInitialVaporVelocity.ToString("F") & " ") & "0"
                    generate.WriteLine(output)
                ElseIf kvp.Value.OEnterVelocityOrMassFlowRate = True Then
                    output = (((kvp.Value.UID & "0202 " & "1" & " ") & kvp.Value.OInitialLiquidMassFlowRate.ToString("F") & " ") & kvp.Value.OInitialVaporMassFlowRate.ToString("F") & " ") & "0"
                    generate.WriteLine(output)
                End If
                'pump index
                If kvp.Value.PumpData.cmbboxindex1 = Nothing Then
                    kvp.Value.PumpData.cmbboxindex1 = 0
                End If
                output1 = kvp.Value.PumpData.cmbboxindex1 - 2

                If kvp.Value.PumpData.cmbboxindex2 = Nothing Then
                    kvp.Value.PumpData.cmbboxindex2 = 0
                End If
                output2 = kvp.Value.PumpData.cmbboxindex2 - 1

                If kvp.Value.PumpData.cmbboxindex3 = Nothing Then
                    kvp.Value.PumpData.cmbboxindex3 = 0
                End If
                output3 = kvp.Value.PumpData.cmbboxindex3 - 3

                If kvp.Value.PumpData.cmbboxindex4 = Nothing Then
                    kvp.Value.PumpData.cmbboxindex4 = 0
                End If
                output4 = kvp.Value.PumpData.cmbboxindex4 - 1

                If kvp.Value.PumpData.cmbboxindex5 = Nothing Then
                    kvp.Value.PumpData.cmbboxindex5 = 0
                End If
                output5 = kvp.Value.PumpData.cmbboxindex5 - 1
                generate.WriteLine(kvp.Value.UID & "0301 " & output1 & " " & output2 & " " & output3 & " " & output4 & " " & output5 & " ")
                generate.WriteLine(kvp.Value.UID & "0302 " & kvp.Value.Ratedpumpvelocity.ToString("F") & " " & kvp.Value.RatioRatedVelocity.ToString("F") & " " & kvp.Value.RatedFlow.ToString("F") & " " & kvp.Value.RatedHead.ToString("F") & " " & kvp.Value.RatedTorque.ToString("F") & " " & kvp.Value.MomentofInertia.ToString("F") & " " & kvp.Value.RatedDensity.ToString("F") & " " & kvp.Value.RatedMotorTorque.ToString("F") & " " & kvp.Value.TF2.ToString("F") & " " & kvp.Value.TF0.ToString("F") & " " & kvp.Value.TF1.ToString("F") & " " & kvp.Value.TF3.ToString("F"))

                If output2 = 0 Then
                    generate.WriteLine(kvp.Value.UID & "3000 0")
                    Dim counter = 1
                    For Each kvp2 As KeyValuePair(Of Integer, pumpdata201) In kvp.Value.PumpData.Propumpdata201
                        generate.WriteLine(kvp.Value.UID & "30" & counter.ToString("D2") & " " & kvp2.Value.Voidfraction1.ToString("F") & " " & kvp2.Value.head.ToString("F"))
                        counter = counter + 1
                    Next kvp2
                    generate.WriteLine(kvp.Value.UID & "3100 0")
                    counter = 1
                    For Each kvp2 As KeyValuePair(Of Integer, pumpdata202) In kvp.Value.PumpData.Propumpdata202
                        generate.WriteLine(kvp.Value.UID & "31" & counter.ToString("D2") & " " & kvp2.Value.Voidfraction2.ToString("F") & " " & kvp2.Value.Torque.ToString("F"))
                        counter = counter + 1
                    Next kvp2
                End If

                If output5 = 0 Then
                    generate.WriteLine(kvp.Value.UID & "6100 " & kvp.Value.PumpData.TripNumberTab5 & " " & kvp.Value.PumpData.AlphanumericTab5 & " " & kvp.Value.PumpData.NumericTab5)
                    Dim counter = 1
                    For Each kvp2 As KeyValuePair(Of Integer, pumpdata501) In kvp.Value.PumpData.Propumpdata501
                        generate.WriteLine(kvp.Value.UID & "61" & counter.ToString("D2") & " " & kvp2.Value.SearchVariable.ToString("F") & " " & kvp2.Value.PumpVelocity.ToString("F"))
                        counter = counter + 1
                    Next kvp2
                End If

                univID = univID + 1
            Next kvp




            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.pipe) In ChildParent.Collections.CLCS_PipeCollection
                '  MsgBox(kvp.Key)
                'kvp.Value.FlowArea.cardno()
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component PIPE '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ pipe")
                output = kvp.Value.UID & "0001 " & kvp.Value.NumberOfVoulmes
                generate.WriteLine(output)
                Dim counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output = kvp.Value.UID & "010" & counter & " " & kvp2.Value.FlowArea.ToString("F") & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output = kvp.Value.UID & "030" & counter & " " & kvp2.Value.LengthofVolume.ToString("F") & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output = kvp.Value.UID & "040" & counter & " " & kvp2.Value.VolumeofVolume.ToString("F") & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output = kvp.Value.UID & "050" & counter & " " & kvp2.Value.Azimuthalangle.ToString("F") & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output = kvp.Value.UID & "060" & counter & " " & kvp2.Value.VerticalAngle.ToString("F") & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                'counter = 1
                'For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                '    output = kvp.Value.UID & "070" & counter & " " & kvp2.Value.ElevationChange & " " & vol
                '    generate.WriteLine(output)
                '    counter = counter + 1
                'Next kvp2

                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output = kvp.Value.UID & "080" & counter & " " & kvp2.Value.WallRoughness.ToString("F") & " " & kvp2.Value.HydraulicDiameter.ToString("F") & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output1 = boolto10(kvp2.Value.ThermalStratificationModel)
                    output2 = boolto10(kvp2.Value.LevelTrackingModel)
                    output3 = boolto10(kvp2.Value.WaterPackingScheme)
                    output4 = boolto10(kvp2.Value.VerticalStratificationModel)
                    output5 = boolto10(kvp2.Value.InterphaseFriction)
                    output6 = boolto10(kvp2.Value.ComputeWallFriction)
                    output7 = boolto10(kvp2.Value.EquilibriumTemperature)
                    output = kvp.Value.UID & "100" & counter & " " & output1 & output2 & output3 & output4 & output5 & output6 & output7 & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeJunctions) In kvp.Value.Profile.Junctions
                    output = kvp.Value.UID & "020" & counter & " " & kvp2.Value.JunctionFlowArea.ToString("F") & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeJunctions) In kvp.Value.Profile.Junctions
                    output = kvp.Value.UID & "090" & counter & " " & kvp2.Value.FflowLossCo.ToString("F") & " " & kvp2.Value.RflowLossCo.ToString("F") & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeJunctions) In kvp.Value.Profile.Junctions
                    output1 = boolto10(kvp2.Value.PVterm)
                    output2 = boolto10(kvp2.Value.CCFLModel)
                    output3 = boolto10(kvp2.Value.ChokingModel)
                    If kvp2.Value.SmoothAreaChange = "Smooth Area Change" Then
                        output4 = "0"
                    ElseIf kvp2.Value.SmoothAreaChange = "Full Abrupt Area Change" Then
                        output4 = "1"
                    ElseIf kvp2.Value.SmoothAreaChange = "Partial Abrupt Area Change" Then
                        output4 = "2"
                    End If

                    If kvp2.Value.TwoVelocityMomentumEquations = "Two velocity Momentum Equations" Then
                        output5 = "0"
                    ElseIf kvp2.Value.TwoVelocityMomentumEquations = "Single velocity Momentum Equations" Then
                        output5 = "2"
                    End If

                    If kvp2.Value.MomentumFlux = "To and From Volume" Then
                        output6 = "0"
                    ElseIf kvp2.Value.MomentumFlux = "Only From Volume" Then
                        output6 = "1"
                    ElseIf kvp2.Value.MomentumFlux = "Only To Volume" Then
                        output6 = "2"
                    ElseIf kvp2.Value.MomentumFlux = "Do not use Momentum Flux" Then
                        output6 = "3"
                    End If

                    output = kvp.Value.UID & "110" & counter & " " & output1 & output2 & "0" & output3 & output4 & output5 & output6 & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2

                If kvp.Value.ThermoDynamicStates.State.Count > 0 Then
                    output1 = fluidchk & boronchk & kvp.Value.ThermoDynamicStates.State(1).StateType
                End If
                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, ThermoDynamicState) In kvp.Value.ThermoDynamicStates.State
                    generate.WriteLine(kvp.Value.UID & "120" & counter & " " & output1 & kvp2.Value.StatesString)
                    counter = counter + 1
                Next kvp2

                For Each kvp2 As KeyValuePair(Of Integer, PipeJunctions) In kvp.Value.Profile.Junctions
                    output1 = boolto10(kvp2.Value.EnterVelocityOrMassFlowRate)
                    output = kvp.Value.UID & "1300 " & output1
                Next kvp2
                generate.WriteLine(output)
                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeJunctions) In kvp.Value.Profile.Junctions
                    If kvp2.Value.EnterVelocityOrMassFlowRate = False Then
                        output1 = kvp2.Value.InitialLiquidVelocity.ToString("F") & " " & kvp2.Value.InitialVaporVelocity.ToString("F")
                    ElseIf kvp2.Value.EnterVelocityOrMassFlowRate = True Then
                        output1 = kvp2.Value.InitialLiquidMassFlowRate.ToString("F") & " " & kvp2.Value.InitialVaporMassFlowRate.ToString("F")
                    End If
                    output = kvp.Value.UID & "130" & counter & " " & output1 & " " & kvp2.Value.InterphaseVelocity.ToString("F") & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2
            Next kvp

            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.Branch) In ChildParent.Collections.CLCS_BranchCollection

                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Branch '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ branch")

                generate.WriteLine(kvp.Value.UID & "0001 " & kvp.Value.NumberofJunctions & " " & kvp.Value.BranchJunctionsGeometry.EnterMassorVelocity)

                output = kvp.Value.UID & "0101 " & kvp.Value.FlowArea.ToString("F") & " " & kvp.Value.LengthofVolume.ToString("F") & " " & kvp.Value.VolumeofVolume.ToString("F") & " " & kvp.Value.Azimuthalangle.ToString("F") & " " & kvp.Value.InclinationAngle.ToString("F") & " " & kvp.Value.ElevationChange.ToString("F") & " " & kvp.Value.WallRoughness.ToString("F") & " " & kvp.Value.HydraulicDiameter.ToString("F") & " "
                output3 = boolto10(kvp.Value.PipeInterphaseFriction)
                output4 = boolto10(kvp.Value.RodInterphaseFriction)
                If output4 = "1" Then
                    output2 = "1"
                Else : output2 = "0"
                End If
                output1 = boolto10(kvp.Value.ThermalStratificationModel) & boolto10(kvp.Value.LevelTrackingModel) & boolto01(kvp.Value.WaterPackingScheme) & boolto01(kvp.Value.VerticalStratificationModel) & output2 & boolto01(kvp.Value.ComputeWallFriction) & boolto10(kvp.Value.EquilibriumTemperature)
                generate.WriteLine(output & output1)

                If frmInitialSettings.optDefaultFluid.Checked = True Then
                    fluidchk = "0"
                ElseIf frmInitialSettings.optWater.Checked = True Then
                    fluidchk = "1"
                ElseIf frmInitialSettings.optHeavyWater.Checked = True Then
                    fluidchk = "2"
                End If

                If frmInitialSettings.chklistboxBoron.Checked = False Then
                    boronchk = "0"
                Else : boronchk = "1"
                End If

                If kvp.Value.ThermoDynamicStates.State.Count > 0 Then
                    output = fluidchk & boronchk & kvp.Value.ThermoDynamicStates.State(1).StateType
                End If

                For Each kvp2 As KeyValuePair(Of Integer, ThermoDynamicState) In kvp.Value.ThermoDynamicStates.State
                    generate.WriteLine(kvp.Value.UID & "0200" & " " & output & kvp2.Value.StatesString)
                Next kvp2
                output1 = boolto10(kvp.Value.pvterm)
                output2 = boolto10(kvp.Value.CCFL)
                If kvp.Value.StratificationModel.ToString = "Dont_use_this_model" Then
                    output3 = "0"
                ElseIf kvp.Value.StratificationModel.ToString = "upward_oriented_junction" Then
                    output3 = "1"
                ElseIf kvp.Value.StratificationModel.ToString = "downward_oriented_junction" Then
                    output3 = "2"
                ElseIf kvp.Value.StratificationModel.ToString = "centrally_located_junction" Then
                    output3 = "3"
                End If
                output4 = boolto01(kvp.Value.chokingModel)
                If kvp.Value.AreaChange.ToString = "No_Area_Change" Then
                    output5 = "0"
                ElseIf kvp.Value.AreaChange.ToString = "Smooth_Area_Change" Then
                    output5 = "0"
                ElseIf kvp.Value.AreaChange.ToString = "Full_Abrupt_Area_Change" Then
                    output5 = "1"
                ElseIf kvp.Value.AreaChange.ToString = "Partial_Abrupt_Area_Change" Then
                    output5 = "2"
                End If
                If kvp.Value.MomentumEquation.ToString = "Two_velocity_Momentum_Equations" Then
                    output6 = "0"
                ElseIf kvp.Value.MomentumEquation.ToString = "Single_velocity_Momentum_Equations" Then
                    output6 = "1"
                End If
                If kvp.Value.MomentumFlux.ToString = "To_and_From_Volume" Then
                    output7 = "0"
                ElseIf kvp.Value.MomentumFlux.ToString = "Only_From_Volume" Then
                    output7 = "1"
                ElseIf kvp.Value.MomentumFlux.ToString = "Only_To_Volume" Then
                    output7 = "2"
                ElseIf kvp.Value.MomentumFlux.ToString = "Do_not_use_Momentum_Flux" Then
                    output7 = "3"
                End If
                output8 = output1 & output2 & output3 & output4 & output5 & output6 & output7
                Dim counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, BranchGeometry) In kvp.Value.BranchJunctionsGeometry.BranchGeometry
                    If kvp2.Value.FromFaceNumber = "inlet x-coordinate" Then
                        kvp2.Value.FromFaceNumber = "1"
                    ElseIf kvp2.Value.FromFaceNumber = "outlet x-coordinate" Then
                        kvp2.Value.FromFaceNumber = "2"
                    ElseIf kvp2.Value.FromFaceNumber = "inlet y-coordinate" Then
                        kvp2.Value.FromFaceNumber = "3"
                    ElseIf kvp2.Value.FromFaceNumber = "outlet y-coordinate" Then
                        kvp2.Value.FromFaceNumber = "4"
                    ElseIf kvp2.Value.FromFaceNumber = "inlet z-coordinate" Then
                        kvp2.Value.FromFaceNumber = "5"
                    ElseIf kvp2.Value.FromFaceNumber = "outlet z-coordinate" Then
                        kvp2.Value.FromFaceNumber = "6"
                    End If
                    If kvp2.Value.ToFaceNumber = "inlet x-coordinate" Then
                        kvp2.Value.ToFaceNumber = "1"
                    ElseIf kvp2.Value.ToFaceNumber = "outlet x-coordinate" Then
                        kvp2.Value.ToFaceNumber = "2"
                    ElseIf kvp2.Value.ToFaceNumber = "inlet y-coordinate" Then
                        kvp2.Value.ToFaceNumber = "3"
                    ElseIf kvp2.Value.ToFaceNumber = "outlet y-coordinate" Then
                        kvp2.Value.ToFaceNumber = "4"
                    ElseIf kvp2.Value.ToFaceNumber = "inlet z-coordinate" Then
                        kvp2.Value.ToFaceNumber = "5"
                    ElseIf kvp2.Value.ToFaceNumber = "outlet z-coordinate" Then
                        kvp2.Value.ToFaceNumber = "6"
                    End If
                    output9 = RELAP.App.GetUIDFromTag(kvp2.Value.FromComponent)
                    output10 = RELAP.App.GetUIDFromTag(kvp2.Value.ToComponent)
                    generate.WriteLine(kvp.Value.UID & counter & "101 " & output9 & CInt(kvp2.Value.FromComponentVolumeNumber).ToString("D2") & "000" & kvp2.Value.FromFaceNumber & " " & output10 & CInt(kvp2.Value.ToComponentVolumeNumber).ToString("D2") & "000" & kvp2.Value.ToFaceNumber & " " & kvp2.Value.JunctionArea.ToString("F") & " " & kvp2.Value.FFLossCo.ToString("F") & " " & kvp2.Value.RFlossCo.ToString("F") & " " & output8 & " " & kvp2.Value.SubcooledDischargeCo.ToString("F") & " " & kvp2.Value.TwoPhaseDischargeCo.ToString("F") & " " & kvp2.Value.SuperheatedDischargeCo.ToString("F"))
                    counter = counter + 1
                Next kvp2
                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, BranchGeometry) In kvp.Value.BranchJunctionsGeometry.BranchGeometry
                    generate.WriteLine(kvp.Value.UID & counter & "201 " & kvp2.Value.LiquidMassFlow.ToString("F") & " " & kvp2.Value.VaporMassFlow.ToString("F") & " 0")
                    counter = counter + 1
                Next kvp2
                univID = univID + 1

            Next kvp

            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.Separator) In ChildParent.Collections.CLCS_SeparatorCollection

                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Separator '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ separatr")

                generate.WriteLine(kvp.Value.UID & "0001 " & kvp.Value.NumberofJunctions & " " & kvp.Value.SeparatorJunctionsGeometry.EnterMassorVelocity)

                If kvp.Value.SeparatorOption.ToString = "Simple_Separator" Then
                    output1 = "0"
                ElseIf kvp.Value.SeparatorOption.ToString = "General_Electric_dryer_model_Separator" Then
                    output1 = "1"
                ElseIf kvp.Value.SeparatorOption.ToString = "General_Electric_two_stage_Separator" Then
                    output1 = "2"
                ElseIf kvp.Value.SeparatorOption.ToString = "General_Electric_three_stage_Separator" Then
                    output1 = "3"
                End If
                If output1 = "2" Or output1 = "3" Then
                    generate.WriteLine(kvp.Value.UID & "0002 " & output1 & " " & kvp.Value.Noseparator)
                Else
                    generate.WriteLine(kvp.Value.UID & "0002 " & output1)
                End If
                output = (kvp.Value.UID & "0101 " & kvp.Value.FlowArea.ToString("F") & " " & kvp.Value.LengthofVolume.ToString("F") & " " & kvp.Value.VolumeofVolume.ToString("F") & " " & kvp.Value.Azimuthalangle.ToString("F") & " " & kvp.Value.InclinationAngle.ToString("F") & " " & kvp.Value.ElevationChange.ToString("F") & " " & kvp.Value.WallRoughness.ToString("F") & " " & kvp.Value.HydraulicDiameter.ToString("F") & " 0")
                generate.WriteLine(output)

                If frmInitialSettings.optDefaultFluid.Checked = True Then
                    fluidchk = "0"
                ElseIf frmInitialSettings.optWater.Checked = True Then
                    fluidchk = "1"
                ElseIf frmInitialSettings.optHeavyWater.Checked = True Then
                    fluidchk = "2"
                End If

                If frmInitialSettings.chklistboxBoron.Checked = False Then
                    boronchk = "0"
                Else : boronchk = "1"
                End If

                If kvp.Value.ThermoDynamicStates.State.Count > 0 Then
                    output = fluidchk & boronchk & kvp.Value.ThermoDynamicStates.State(1).StateType
                End If

                For Each kvp2 As KeyValuePair(Of Integer, ThermoDynamicState) In kvp.Value.ThermoDynamicStates.State
                    generate.WriteLine(kvp.Value.UID & "0200" & " " & output & kvp2.Value.StatesString)
                Next kvp2

                If kvp.Value.AreaChange.ToString = "No_Area_Change" Then
                    output5 = "0"
                ElseIf kvp.Value.AreaChange.ToString = "Smooth_Area_Change" Then
                    output5 = "0"
                ElseIf kvp.Value.AreaChange.ToString = "Full_Abrupt_Area_Change" Then
                    output5 = "1"
                ElseIf kvp.Value.AreaChange.ToString = "Partial_Abrupt_Area_Change" Then
                    output5 = "2"
                End If
                If kvp.Value.MomentumEquation.ToString = "Two_velocity_Momentum_Equations" Then
                    output6 = "0"
                ElseIf kvp.Value.MomentumEquation.ToString = "Single_velocity_Momentum_Equations" Then
                    output6 = "1"
                End If
                If kvp.Value.MomentumFlux.ToString = "To_and_From_Volume" Then
                    output7 = "0"
                ElseIf kvp.Value.MomentumFlux.ToString = "Only_From_Volume" Then
                    output7 = "1"
                ElseIf kvp.Value.MomentumFlux.ToString = "Only_To_Volume" Then
                    output7 = "2"
                ElseIf kvp.Value.MomentumFlux.ToString = "Do_not_use_Momentum_Flux" Then
                    output7 = "3"
                End If
                output8 = output5 & output6 & output7
                Dim counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, SeparatorGeometry) In kvp.Value.SeparatorJunctionsGeometry.SeparatorGeometry
                    If kvp2.Value.FromFaceNumber = "inlet x-coordinate" Then
                        kvp2.Value.FromFaceNumber = "1"
                    ElseIf kvp2.Value.FromFaceNumber = "outlet x-coordinate" Then
                        kvp2.Value.FromFaceNumber = "2"
                    ElseIf kvp2.Value.FromFaceNumber = "inlet y-coordinate" Then
                        kvp2.Value.FromFaceNumber = "3"
                    ElseIf kvp2.Value.FromFaceNumber = "outlet y-coordinate" Then
                        kvp2.Value.FromFaceNumber = "4"
                    ElseIf kvp2.Value.FromFaceNumber = "inlet z-coordinate" Then
                        kvp2.Value.FromFaceNumber = "5"
                    ElseIf kvp2.Value.FromFaceNumber = "outlet z-coordinate" Then
                        kvp2.Value.FromFaceNumber = "6"
                    End If
                    If kvp2.Value.ToFaceNumber = "inlet x-coordinate" Then
                        kvp2.Value.ToFaceNumber = "1"
                    ElseIf kvp2.Value.ToFaceNumber = "outlet x-coordinate" Then
                        kvp2.Value.ToFaceNumber = "2"
                    ElseIf kvp2.Value.ToFaceNumber = "inlet y-coordinate" Then
                        kvp2.Value.ToFaceNumber = "3"
                    ElseIf kvp2.Value.ToFaceNumber = "outlet y-coordinate" Then
                        kvp2.Value.ToFaceNumber = "4"
                    ElseIf kvp2.Value.ToFaceNumber = "inlet z-coordinate" Then
                        kvp2.Value.ToFaceNumber = "5"
                    ElseIf kvp2.Value.ToFaceNumber = "outlet z-coordinate" Then
                        kvp2.Value.ToFaceNumber = "6"
                    End If
                    output1 = RELAP.App.GetUIDFromTag(kvp2.Value.FromComponent)
                    output2 = RELAP.App.GetUIDFromTag(kvp2.Value.ToComponent)
                    generate.WriteLine(kvp.Value.UID & counter & "101 " & output1 & CInt(kvp2.Value.FromComponentVolumeNumber).ToString("D2") & "000" & kvp2.Value.FromFaceNumber & " " & output2 & CInt(kvp2.Value.ToComponentVolumeNumber).ToString("D2") & "000" & kvp2.Value.ToFaceNumber & " " & kvp2.Value.JunctionArea.ToString("F") & " " & kvp2.Value.FFLossCo.ToString("F") & " " & kvp2.Value.RFlossCo.ToString("F") & " " & output8 & " " & kvp2.Value.SubcooledDischargeCo.ToString("F"))
                    counter = counter + 1
                Next kvp2
                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, SeparatorGeometry) In kvp.Value.SeparatorJunctionsGeometry.SeparatorGeometry
                    generate.WriteLine(kvp.Value.UID & counter & "201 " & kvp2.Value.LiquidMassFlow.ToString("F") & " " & kvp2.Value.VaporMassFlow.ToString("F") & " 0")
                    counter = counter + 1
                Next kvp2
                univID = univID + 1

            Next kvp

            If frmMaterials.checkMaterial = 1 Then
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Materials ")
                generate.WriteLine("*======================================================================")
                'generate.WriteLine(frmMaterials.CmboboxSelectMaterial.SelectedItem.ToString)
                generate.WriteLine("20100" & frmMaterials.CmboboxSelectMaterial.SelectedIndex + 1 & "00" & " " & frmMaterials.CmboboxSelectMaterial.SelectedItem.ToString)
            End If

            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.HeatStructure) In ChildParent.Collections.CLCS_HeatStructureCollection
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Heat Structure '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                output1 = kvp.Value.GeometryType.ToString
                If output1 = "Rectangular" Then
                    output2 = "1"
                ElseIf output1 = "Cylinderical" Then
                    output2 = "2"
                ElseIf output1 = "Spherical" Then
                    output2 = "3"
                End If
                output = kvp.Value.NumberOfAxialHS & " " & kvp.Value.NumberOfRadialMP & " " & output2 & " " & kvp.Value.HeatStructureMeshData.EnterInitialTemp & " " & kvp.Value.LeftBoundaryCO.ToString("F")
                generate.WriteLine("1" & kvp.Value.UID & "0" & "000 " & output)

                If kvp.Value.HeatStructureMeshData.GapConductanceModel.ToString = True Then
                    generate.WriteLine("1" & kvp.Value.UID & "0" & "001 " & kvp.Value.HeatStructureMeshData.InitialGapInternalPressure & " " & kvp.Value.HeatStructureMeshData.GapConductanceReferenceVolume)
                    generate.WriteLine("1" & kvp.Value.UID & "0" & "003 " & kvp.Value.HeatStructureMeshData.InitialOxideThicknes)
                    output = boolto10(kvp.Value.HeatStructureMeshData.FormLossFactors)
                    generate.WriteLine("1" & kvp.Value.UID & "0" & "004 " & output)
                End If
                Dim Counter = 11
                For Each kvp2 As KeyValuePair(Of Integer, HSGapDeformation) In kvp.Value.HeatStructureMeshData.GapDeformation
                    output = "1" & kvp.Value.UID & "00" & Counter & " " & kvp2.Value.FuelSurfaceRoughness.ToString("F") & " " & kvp2.Value.CladdingSurfaceRoughness.ToString("F") & " " & kvp2.Value.RadialDisplacementFission.ToString("F") & " " & kvp2.Value.RadialDisplacementCladding.ToString("F") & " " & kvp2.Value.HSnumberGapDef
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                generate.WriteLine("1" & kvp.Value.UID & "0" & "100 " & kvp.Value.HeatStructureMeshData.EnterMeshGeometry & " " & kvp.Value.HeatStructureMeshData.SelectFormat)

                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, HSMeshDataFormat1) In kvp.Value.HeatStructureMeshData.MeshDataFormat1
                    output = "1" & kvp.Value.UID & "0" & "10" & Counter & " " & kvp2.Value.NumberOfIntervals & " " & kvp2.Value.RightCoordinate.ToString("F")
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, HSMeshDataFormat2) In kvp.Value.HeatStructureMeshData.MeshDataFormat2
                    output = "1" & kvp.Value.UID & "0" & "10" & Counter & " " & kvp2.Value.MeshInterval.ToString("F") & " " & kvp2.Value.IntervalNumber
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, HSMeshDataComposition) In kvp.Value.HeatStructureMeshData.MeshDataComposition
                    output = "1" & kvp.Value.UID & "0" & "20" & Counter & " " & kvp2.Value.CompositionNumber & " " & kvp2.Value.MeshIntervalNumber3
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                If kvp.Value.HeatStructureMeshData.DecayHeat = "0" Then
                    Counter = 1
                    For Each kvp2 As KeyValuePair(Of Integer, HSMeshDataNoDecay) In kvp.Value.HeatStructureMeshData.MeshDataNoDecay
                        output = "1" & kvp.Value.UID & "0" & "30" & Counter & " " & kvp2.Value.SourceValue & " " & kvp2.Value.MeshIntervalNumber
                        generate.WriteLine(output)
                        Counter = Counter + 1
                    Next kvp2
                ElseIf kvp.Value.HeatStructureMeshData.DecayHeat = "" Then
                    Counter = 1
                    For Each kvp2 As KeyValuePair(Of Integer, HSMeshDataNoDecay) In kvp.Value.HeatStructureMeshData.MeshDataNoDecay
                        output = "1" & kvp.Value.UID & "0" & "30" & Counter & " " & kvp2.Value.SourceValue.ToString("F") & " " & kvp2.Value.MeshIntervalNumber
                        generate.WriteLine(output)
                        Counter = Counter + 1
                    Next kvp2

                Else
                    generate.WriteLine("1" & kvp.Value.UID & "0" & "300 " & kvp.Value.HeatStructureMeshData.DecayHeat)
                    Counter = 1
                    For Each kvp2 As KeyValuePair(Of Integer, HSMeshDataWithDecay) In kvp.Value.HeatStructureMeshData.MeshDataWithDecay
                        output = "1" & kvp.Value.UID & "0" & "30" & Counter & " " & kvp2.Value.GammaAttenuationCo.ToString("F") & " " & kvp2.Value.MeshIntervalNumber2
                        generate.WriteLine(output)
                        Counter = Counter + 1
                    Next kvp2
                End If

                generate.WriteLine("1" & kvp.Value.UID & "0" & "400" & " " & kvp.Value.HeatStructureMeshData.SelectTemp)
                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, HSTemp1) In kvp.Value.HeatStructureMeshData.Temp1
                    output = "1" & kvp.Value.UID & "0" & "40" & Counter & " " & kvp2.Value.Temp1Temperature.ToString("F") & " " & kvp2.Value.Temp1MeshPointNumber
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, HSBoundaryCondTab1) In kvp.Value.HeatStructureBoundaryCond.BoundaryCondTab1

                    If kvp2.Value.LeftBoundaryConditionType.ToString = "Default" Then
                        kvp2.Value.LeftBoundaryConditionType = "101"
                    ElseIf kvp2.Value.LeftBoundaryConditionType.ToString = "Insulated Boundary" Then
                        kvp2.Value.LeftBoundaryConditionType = "0"
                    ElseIf kvp2.Value.LeftBoundaryConditionType.ToString = "Verticle bundle without crossflow" Then
                        kvp2.Value.LeftBoundaryConditionType = "110"
                    ElseIf kvp2.Value.LeftBoundaryConditionType.ToString = "Verticle bundle with crossflow" Then
                        kvp2.Value.LeftBoundaryConditionType = "111"
                    ElseIf kvp2.Value.LeftBoundaryConditionType.ToString = "Flat plate above fluid" Then
                        kvp2.Value.LeftBoundaryConditionType = "130"
                    ElseIf kvp2.Value.LeftBoundaryConditionType.ToString = "Horizontal bundle" Then
                        kvp2.Value.LeftBoundaryConditionType = "134"
                    Else
                        kvp2.Value.LeftBoundaryConditionType = "1"
                    End If

                    If kvp2.Value.leftAverageVolumeVelocity.ToString = "Taken from x-coordinate" Then
                        kvp2.Value.leftAverageVolumeVelocity = "0"
                    ElseIf kvp2.Value.leftAverageVolumeVelocity.ToString = "Taken from y-coordinate" Then
                        kvp2.Value.leftAverageVolumeVelocity = "2"
                    ElseIf kvp2.Value.leftAverageVolumeVelocity.ToString = "Taken from z-coordinate" Then
                        kvp2.Value.leftAverageVolumeVelocity = "1"
                    Else
                        kvp2.Value.leftAverageVolumeVelocity = "0"
                    End If

                    output1 = GetUIDFromTag(kvp2.Value.leftComponent)
                    If output1 <> 0 Then
                        output2 = output1 & CInt(kvp2.Value.leftComponentVolumeNumber).ToString("D2") & "000" & kvp2.Value.leftAverageVolumeVelocity & " " & kvp2.Value.LeftIncrement
                    Else
                        output2 = "0 0"
                    End If
                    output = "1" & kvp.Value.UID & "0" & "50" & Counter & " " & output2 & " " & kvp2.Value.LeftBoundaryConditionType & " " & kvp2.Value.LeftSurfaceAreaSelection & " " & kvp2.Value.LeftSurfaceArea.ToString("F") & " " & kvp2.Value.LeftHeatStructureNumber
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, HSBoundaryCondTab2) In kvp.Value.HeatStructureBoundaryCond.BoundaryCondTab2
                    If kvp2.Value.RightBoundaryConditionType.ToString = "Default" Then
                        kvp2.Value.RightBoundaryConditionType = "101"
                    ElseIf kvp2.Value.RightBoundaryConditionType.ToString = "Insulated Boundary" Then
                        kvp2.Value.RightBoundaryConditionType = "0"
                    ElseIf kvp2.Value.RightBoundaryConditionType.ToString = "Verticle bundle without crossflow" Then
                        kvp2.Value.RightBoundaryConditionType = "110"
                    ElseIf kvp2.Value.RightBoundaryConditionType.ToString = "Verticle bundle with crossflow" Then
                        kvp2.Value.RightBoundaryConditionType = "111"
                    ElseIf kvp2.Value.RightBoundaryConditionType.ToString = "Flat plate above fluid" Then
                        kvp2.Value.RightBoundaryConditionType = "130"
                    ElseIf kvp2.Value.RightBoundaryConditionType.ToString = "Horizontal bundle" Then
                        kvp2.Value.RightBoundaryConditionType = "134"
                    Else
                        kvp2.Value.RightBoundaryConditionType = "1"
                    End If
                    If kvp2.Value.rightAverageVolumeVelocity.ToString = "Taken from x-coordinate" Then
                        kvp2.Value.rightAverageVolumeVelocity = "0"
                    ElseIf kvp2.Value.rightAverageVolumeVelocity.ToString = "Taken from y-coordinate" Then
                        kvp2.Value.rightAverageVolumeVelocity = "2"
                    ElseIf kvp2.Value.rightAverageVolumeVelocity.ToString = "Taken from z-coordinate" Then
                        kvp2.Value.rightAverageVolumeVelocity = "1"
                    Else
                        kvp2.Value.rightAverageVolumeVelocity = "0"
                    End If

                    output1 = GetUIDFromTag(kvp2.Value.rightComponent)
                    If output1 <> 0 Then
                        output2 = output1 & CInt(kvp2.Value.rightComponentVolumeNumber).ToString("D2") & "000" & kvp2.Value.rightAverageVolumeVelocity & " " & kvp2.Value.RightIncrement
                    Else
                        output2 = "0 0"
                    End If
                    output = "1" & kvp.Value.UID & "0" & "60" & Counter & " " & output2 & " " & kvp2.Value.RightBoundaryConditionType & " " & kvp2.Value.RightSurfaceAreaSelection & " " & kvp2.Value.RightSurfaceArea.ToString("F") & " " & kvp2.Value.RightHeatStructureNumber
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2


                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, HSBoundaryCondTab3) In kvp.Value.HeatStructureBoundaryCond.BoundaryCondTab3
                    output = "1" & kvp.Value.UID & "0" & "70" & Counter & " " & kvp2.Value.SourceType & " " & kvp2.Value.InternalSourceMultiplier & " " & kvp2.Value.DirectModeratorHeatingMultiplierLeft & " " & kvp2.Value.DirectModeratorHeatingMultiplierRight & " " & kvp2.Value.SourceHeatStructureNumber
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                generate.WriteLine("1" & kvp.Value.UID & "0" & "800 " & "1")
                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, HSBoundaryCondTab4) In kvp.Value.HeatStructureBoundaryCond.BoundaryCondTab4
                    output = "1" & kvp.Value.UID & "0" & "80" & Counter & " " & kvp2.Value.leftHeatedEquivalentDiameter.ToString("F") & " " & kvp2.Value.LeftHeatedLengthForward.ToString("F") & " " & kvp2.Value.LeftHeatedLengthReverse.ToString("F") & " " & kvp2.Value.leftGridSpacerLengthForward.ToString("F") & " " & kvp2.Value.leftGridSpacerLengthReverse.ToString("F") & " " & kvp2.Value.leftGridLossCoefficientForward.ToString("F") & " " & kvp2.Value.leftGridLossCoefficientReverse.ToString("F") & " " & kvp2.Value.leftLocalBoilingFactor.ToString("F") & " " & kvp2.Value.leftNaturalCirculationLength.ToString("F") & " " & kvp2.Value.leftPitchtoDiameterRatio.ToString("F") & " " & kvp2.Value.leftFoulingFactor.ToString("F") & " " & kvp2.Value.leftAddHeatStructureNumber
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2

                generate.WriteLine("1" & kvp.Value.UID & "0" & "900 " & "1")
                Counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, HSBoundaryCondTab5) In kvp.Value.HeatStructureBoundaryCond.BoundaryCondTab5
                    output = "1" & kvp.Value.UID & "0" & "90" & Counter & " " & kvp2.Value.rightHeatedEquivalentDiameter.ToString("F") & " " & kvp2.Value.rightHeatedLengthForward.ToString("F") & " " & kvp2.Value.rightHeatedLengthReverse.ToString("F") & " " & kvp2.Value.rightGridSpacerLengthForward.ToString("F") & " " & kvp2.Value.rightGridSpacerLengthReverse.ToString("F") & " " & kvp2.Value.rightGridLossCoefficientForward.ToString("F") & " " & kvp2.Value.rightGridLossCoefficientReverse.ToString("F") & " " & kvp2.Value.rightLocalBoilingFactor.ToString("F") & " " & kvp2.Value.rightNaturalCirculationLength.ToString("F") & " " & kvp2.Value.rightPitchtoDiameterRatio.ToString("F") & " " & kvp2.Value.rightFoulingFactor.ToString("F") & " " & kvp2.Value.rightAddHeatStructureNumber
                    generate.WriteLine(output)
                    Counter = Counter + 1
                Next kvp2
            Next kvp
            Try


                generate.WriteLine("*======================================================================")
                generate.WriteLine("*          General Core Input                                          ")
                generate.WriteLine("*======================================================================")
                Dim str As String = My.Application.ActiveSimulation.FormGeneralCoreInput.cboReactorEnvironment.SelectedItem.Value
                generate.WriteLine("40000100 " & My.Application.ActiveSimulation.FormGeneralCoreInput.txtAxialNodes.Value & " 1 " & My.Application.ActiveSimulation.FormGeneralCoreInput.cboReactorEnvironment.SelectedItem.Value & " " & My.Application.ActiveSimulation.FormGeneralCoreInput.cboPowerHistoryTy.SelectedItem.Value & " " & My.Application.ActiveSimulation.FormGeneralCoreInput.cboOxideShatteringTrip.SelectedText)

                card = 40000201
                For Each row In My.Application.ActiveSimulation.FormGeneralCoreInput.dgvAxialNodeHeights.Rows
                    generate.WriteLine(card & " " & row.Cells(1).Value & " " & row.Cells(0).Value)
                    card = card + 1
                Next


                generate.WriteLine("40000300 " & ChildParent.FormGeneralCoreInput.txtTemperatureforFailure.Value & " " & ChildParent.FormGeneralCoreInput.txtFractionofOxidation.Value & " " & ChildParent.FormGeneralCoreInput.txtHoopStrainThreshold.Value & " " & ChildParent.FormGeneralCoreInput.cboModelsforFailure.SelectedItem.Value)

                generate.WriteLine("40000310 " & ChildParent.FormGeneralCoreInput.txtFractionofSurfaceArea.Text & " " & ChildParent.FormGeneralCoreInput.txtSurfaceTemperature.Value & " " & ChildParent.FormGeneralCoreInput.txtVelocityofDrops.Value)

                'generate.WriteLine("40000320 " & ChildParent.FormGeneralCoreInput.txtMultiplicationFactor.Text & " " & ChildParent.FormGeneralCoreInput.txtMinimumFractionalFlowArea.Text)

                'generate.WriteLine("40000330 " & ChildParent.FormGeneralCoreInput.cboFuelRodDisintegration.SelectedItem.Value & " " & ChildParent.FormGeneralCoreInput.txtTemperatureaboveSaturation.Text)

                generate.WriteLine("40000400 " & ChildParent.FormGeneralCoreInput.txtGammaHeatingFraction.Text)

                generate.WriteLine("40000500 " & ChildParent.FormGeneralCoreInput.txtRuptureStrain.Text & " " & ChildParent.FormGeneralCoreInput.txtTransitionStrain.Text & " " & ChildParent.FormGeneralCoreInput.txtLimitsStrain.Text & " " & ChildParent.FormGeneralCoreInput.cboPressureDropFlag.SelectedItem.Value)

                generate.WriteLine("40000600 " & ChildParent.FormGeneralCoreInput.cboSourceofData.Text & " " & ChildParent.FormGeneralCoreInput.txtTableorControlVariableNumber.Text)
                output = "40001000 "
                For Each row In ChildParent.FormGeneralCoreInput.dgvGridSpacer.Rows
                    output = output & " " & row.Cells(6).Value
                Next
                generate.WriteLine(output)
                card = 40001001
                For Each row In ChildParent.FormGeneralCoreInput.dgvGridSpacer.Rows
                    If row.Cells(2).Value <> "" Then
                        Dim material As String
                        If row.Cells(1).Value = "Zircaloy" Then
                            material = 0
                        Else
                            material = 1
                        End If
                        generate.WriteLine(card & " " & material & " " & row.Cells(2).Value & " " & row.Cells(3).Value & " " & row.Cells(4).Value & " " & row.Cells(0).Value)
                        card = card + 1
                    End If
                Next

                generate.WriteLine("40001100 " & ChildParent.FormGeneralCoreInput.cboCoreSlumpingModel.SelectedItem.Value)

                card = 40001101
                Dim tempint As Integer
                Dim tempstr As String
                For Each row In ChildParent.FormGeneralCoreInput.dgvCoreBypassVolumes.Rows
                    tempint = row.Cells(1).Value
                    tempstr = tempint.ToString("D2")
                    generate.WriteLine(card & " " & RELAP.App.GetUIDFromTag(row.Cells(0).Value) & tempstr & "0000")
                    card = card + 1

                Next

                card = 40001201
                For Each row In ChildParent.FormGeneralCoreInput.dgvCoreBypassVolumes.Rows
                    If row.Cells(2).Value <> "" Then
                        generate.WriteLine(card & " " & row.Cells(2).Value)
                        card = card + 1
                    End If

                Next

                generate.WriteLine("40002000 " & ChildParent.FormGeneralCoreInput.txtControlVolume1.Value.ToString("D2") & ChildParent.FormGeneralCoreInput.txtControlVolume1.Value.ToString("D2") & "0000 " & RELAP.App.GetUIDFromTag(ChildParent.FormGeneralCoreInput.cboComponentatTopCenter.SelectedItem.Tag) & ChildParent.FormGeneralCoreInput.txtControlVolume2.Value.ToString("D2") & "0000 " & ChildParent.FormGeneralCoreInput.txtMinimumFlowArea.Text)
            Catch ex As Exception

            End Try
            Try


                Dim a As Integer = 1
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*          Control Components                                          ")
                generate.WriteLine("*======================================================================")
                Dim i1 = 1
                Dim dgvrow As DataGridViewRow

                Dim frm As frmControlSystem = My.Application.ActiveSimulation.FormControlSystem

                For j = 0 To frm.dgv1.Rows.Count - 2
                    dgvrow = My.Application.ActiveSimulation.FormControlSystem.dgv1.Rows(j)
                    Dim _uid = RELAP.App.GetUIDFromTag(dgvrow.Cells(0).Value)
                    If dgvrow.Cells(5).Value = "Both" Then
                        output = "2050010" & i & " " & dgvrow.Cells(0).Value & " " & dgvrow.Cells(1).Value & " " & dgvrow.Cells(2).Value & " " & dgvrow.Cells(3).Value & " " & dgvrow.Cells(4).Value & " " & "2" & " " & dgvrow.Cells(6).Value & " " & dgvrow.Cells(7).Value
                    End If
                    i = i + 1
                    generate.WriteLine(output)

                    If dgvrow.Cells(1).Value = "SUM" Then

                        Dim dgvrow1 As DataGridViewRow
                        For k = 0 To frm.dgv2.Rows.Count - 2
                            dgvrow1 = My.Application.ActiveSimulation.FormControlSystem.dgv2.Rows(k)
                            Dim _uid1 = RELAP.App.GetUIDFromTag(dgvrow1.Cells(0).Value)
                            output = "2050010" & i & " " & dgvrow1.Cells(0).Value & " " & dgvrow1.Cells(1).Value & " " & dgvrow1.Cells(2).Value & " " & dgvrow1.Cells(3).Value

                            i = i + 1
                            generate.WriteLine(output)
                        Next

                    ElseIf dgvrow.Cells(1).Value = "MULT" Then
                        Dim dgvrow1 As DataGridViewRow
                        For k = 0 To frm.dgv2.Rows.Count - 2
                            dgvrow1 = My.Application.ActiveSimulation.FormControlSystem.dgv2.Rows(k)
                            Dim _uid1 = RELAP.App.GetUIDFromTag(dgvrow1.Cells(0).Value)
                            output = "2050010" & i & " " & dgvrow1.Cells(0).Value & " " & dgvrow1.Cells(1).Value

                            i = i + 1
                            generate.WriteLine(output)
                        Next
                    ElseIf dgvrow.Cells(1).Value = "DIFFEREND" Then
                        Dim dgvrow1 As DataGridViewRow
                        For k = 0 To frm.dgv2.Rows.Count - 2
                            dgvrow1 = My.Application.ActiveSimulation.FormControlSystem.dgv2.Rows(k)
                            Dim _uid1 = RELAP.App.GetUIDFromTag(dgvrow1.Cells(0).Value)
                            output = "2050010" & i & " " & dgvrow1.Cells(0).Value & " " & dgvrow1.Cells(1).Value

                            i = i + 1
                            generate.WriteLine(output)
                        Next
                    ElseIf dgvrow.Cells(1).Value = "INTEGRAL" Then
                        Dim dgvrow1 As DataGridViewRow
                        For k = 0 To frm.dgv2.Rows.Count - 2
                            dgvrow1 = My.Application.ActiveSimulation.FormControlSystem.dgv2.Rows(k)
                            Dim _uid1 = RELAP.App.GetUIDFromTag(dgvrow1.Cells(0).Value)
                            output = "2050010" & i & " " & dgvrow1.Cells(0).Value & " " & dgvrow1.Cells(1).Value

                            i = i + 1
                            generate.WriteLine(output)
                        Next
                    ElseIf dgvrow.Cells(1).Value = "DIV" Then

                        Dim dgvrow1 As DataGridViewRow
                        For k = 0 To frm.dgv2.Rows.Count - 2
                            dgvrow1 = My.Application.ActiveSimulation.FormControlSystem.dgv2.Rows(k)
                            Dim _uid1 = RELAP.App.GetUIDFromTag(dgvrow1.Cells(0).Value)
                            output = "2050010" & i & " " & dgvrow1.Cells(0).Value & " " & dgvrow1.Cells(1).Value & " " & dgvrow1.Cells(2).Value & " " & dgvrow1.Cells(3).Value

                            i = i + 1
                            generate.WriteLine(output)
                        Next
                    ElseIf dgvrow.Cells(1).Value = "DELAY" Then

                        Dim dgvrow1 As DataGridViewRow
                        For k = 0 To frm.dgv2.Rows.Count - 2
                            dgvrow1 = My.Application.ActiveSimulation.FormControlSystem.dgv2.Rows(k)
                            Dim _uid1 = RELAP.App.GetUIDFromTag(dgvrow1.Cells(0).Value)
                            output = "2050010" & i & " " & dgvrow1.Cells(0).Value & " " & dgvrow1.Cells(1).Value & " " & dgvrow1.Cells(2).Value & " " & dgvrow1.Cells(3).Value

                            i = i + 1
                            generate.WriteLine(output)
                        Next
                    ElseIf dgvrow.Cells(1).Value = "TRIPUNIT" Then

                        Dim dgvrow1 As DataGridViewRow
                        For k = 0 To frm.dgv2.Rows.Count - 2
                            dgvrow1 = My.Application.ActiveSimulation.FormControlSystem.dgv2.Rows(k)
                            Dim _uid1 = RELAP.App.GetUIDFromTag(dgvrow1.Cells(0).Value)
                            output = "2050010" & i & " " & dgvrow1.Cells(0).Value

                            i = i + 1
                            generate.WriteLine(output)
                        Next

                    End If

                Next

                For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.FuelRod) In ChildParent.Collections.CLCS_FuelRodCollection
                    generate.WriteLine("*======================================================================")
                    generate.WriteLine("*         Component Fuel Rod '" & kvp.Value.GraphicObject.Tag & "'")
                    generate.WriteLine("*======================================================================")
                    Dim temp As Int16
                    temp = kvp.Value.UID
                    Dim CID As String
                    CID = temp.ToString("D2")
                    generate.WriteLine("40" & CID & "0000 """ + kvp.Value.GraphicObject.Tag & """ fuel")

                    generate.WriteLine("40" & CID & "0100 " & kvp.Value.NumberOfRods & " " & kvp.Value.FuelRodPitch & " " & kvp.Value.AverageBurnup)
                    generate.WriteLine("40" & CID & "0200 " & kvp.Value.PlenumLength & " " & kvp.Value.PlenumVoidVolume & " " & kvp.Value.LowerPlenumVoidVolume)
                    card = Val("40" & CID & "0301")
                    For Each row2 As KeyValuePair(Of Integer, RELAP.SimulationObjects.UnitOps.FuelRodDimensions) In kvp.Value.FuelRodDetails.FuelRodDimensions
                        generate.WriteLine(card & " " & row2.Value.FuelPelletRadius & " " & row2.Value.InnerCladdingRadius & " " & row2.Value.OuterCladdingRadius & " " & row2.Value.FuelRodDimensionsAxialNode)
                        card = card + 1
                    Next
                    generate.WriteLine("40" & CID & "0400 " & kvp.Value.ControlVolumeAbove & " " & kvp.Value.ControlVolumeBelow)

                    card = Val("40" & CID & "0401")
                    For Each row2 As KeyValuePair(Of Integer, RELAP.SimulationObjects.UnitOps.HydraulicVolumes) In kvp.Value.FuelRodDetails.HyrdraulicVolumes
                        generate.WriteLine(card & " " & row2.Value.ControlVolumeNumber & " " & row2.Value.Increment & " " & row2.Value.AxialNode)
                        card = card + 1
                    Next

                    card = Val("40" & CID & "0501")
                    For Each row2 As KeyValuePair(Of Integer, RELAP.SimulationObjects.UnitOps.RadialMeshSpacing) In kvp.Value.FuelRodDetails.RadialMeshSpacing
                        generate.WriteLine(card & " " & row2.Value.NumberofIntervalsAcrossFuel & " " & row2.Value.NumberofIntervalsAcrossGap & " " & row2.Value.NumberofIntervalsAcrossCladding & " " & row2.Value.AxialNode)
                        card = card + 1
                    Next
                    card = Val("40" & CID & "0601")
                    For Each row2 As KeyValuePair(Of Integer, String) In kvp.Value.FuelRodDetails.InitialTemperatures
                        generate.WriteLine(card & " " & row2.Value)
                        card = card + 1
                    Next
                    generate.WriteLine("40" & CID & "0801 " & kvp.Value.MaterialIndexNearCenter & " " & kvp.Value.MaterialIndexNextToCenter & " " & kvp.Value.MaterialIndexNthLayer)

                    generate.WriteLine("40" & CID & "1100 " & kvp.Value.Fraction)

                    generate.WriteLine("40" & CID & "1310 " & kvp.Value.TimeForWhichAxialPowerProfileApplies)

                    card = Val("40" & CID & "1311")
                    For Each row2 As KeyValuePair(Of Integer, Double) In kvp.Value.FuelRodDetails.AxialPowerFactor
                        generate.WriteLine(card & " " & row2.Value)
                        card = card + 1
                    Next
                    card = Val("40" & CID & "1401")
                    For Each row2 As KeyValuePair(Of Integer, RELAP.SimulationObjects.UnitOps.RadialPowerProfile) In kvp.Value.FuelRodDetails.RadialPowerProfile
                        generate.WriteLine(card & " " & row2.Value.RadialPowerFactor & " " & row2.Value.RadialNode)
                        card = card + 1
                    Next
                    generate.WriteLine("40" & CID & "1500 " & kvp.Value.ShutdownTime & " " & kvp.Value.FractionOfFuelDensity)
                    card = Val("40" & CID & "1601")
                    For Each row2 As KeyValuePair(Of Integer, RELAP.SimulationObjects.UnitOps.PreviousPowerHistory) In kvp.Value.FuelRodDetails.PreviousPowerHistory
                        generate.WriteLine(card & " " & row2.Value.PowerHistory & " " & row2.Value.Time)
                        card = card + 1
                    Next
                    generate.WriteLine("40" & CID & "3000 " & kvp.Value.HeliumGasInventory & " " & kvp.Value.InternalGasPressure)
                Next kvp
            Catch ex As Exception

            End Try
            Try

                'For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.PWRControlRod) In ChildParent.Collections.CLCS_
                '    generate.WriteLine("*======================================================================")
                '    generate.WriteLine("*         Component Fuel Rod '" & kvp.Value.GraphicObject.Tag & "'")
                '    generate.WriteLine("*======================================================================")
                '    Dim temp As Int16
                '    temp = kvp.Value.UID
                '    Dim CID As String
                '    CID = temp.ToString("D2")
                '    generate.WriteLine("40" & CID & "0000 """ + kvp.Value.GraphicObject.Tag & """ fuel")
                'Next
            Catch ex As Exception

            End Try
            generate.WriteLine(".")
            generate.Close()
            MsgBox("File Saved")

            Exit Sub

        End If

    End Sub






    Private Sub GenerateInputFileAndRunToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GenerateInputFileAndRunToolStripMenuItem.Click

        If My.Settings.RELAPPath = "" Then
            FolderBrowserDialog1.Description = "Select RELAP's Installation Folder"
            If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                My.Settings.RELAPPath = FolderBrowserDialog1.SelectedPath
                My.Settings.Save()
            End If
        End If
        GenerateInputFileToolStripMenuItem_Click(Nothing, Nothing)
        Dim temppath As String
        temppath = "C:\Users\ne1145\Desktop\relap2\RELAP34EXPERIMENTAL\simpl.i"
        Dim olddate As DateTime = DateTime.Now
        ' System.DateTime = "2006-06-06"
        Dim lol As DateTime
        lol = "2006-06-06 " & TimeOfDay
        SetDeviceTime(lol)
        Dim RetVal
        Dim pathstring As String
        Dim txtRestart, txtOutput, txtInput As String

        Dim ichar As Integer

        '   
        'txtInput = temppath
        txtInput = SaveFileDialog1.FileName
        txtOutput = txtInput.Substring(0, txtInput.Length - 2)

        '  Copy input file name without extension into name of output and restart files
        ichar = 1

        txtRestart = txtOutput & ".r"
        txtOutput = txtOutput & ".o"


        pathstring = " -i " & txtInput & " -o " _
        & txtOutput & " -r " & txtRestart _
        & " -w " & My.Settings.RELAPPath & "\tpfh2o -d " & My.Settings.RELAPPath & "\tpfd2o"
        '  If chkNGUI = 1 Then pathstring = pathstring & " -n gui "

        If Dir$(txtRestart) <> "" Then
            Kill(txtRestart)
        End If

        If Dir$(txtOutput) <> "" Then
            Kill(txtOutput)
        End If
        ' Check to make sure that relap5.exe, tpfh2o, and tpfd2o files are in folder


        If Dir$(My.Settings.RELAPPath & "\relap5.EXE") <> "" And _
           Dir$(My.Settings.RELAPPath & "\tpfh2o") <> "" And _
           Dir$(My.Settings.RELAPPath & "\tpfd2o") <> "" Then
            Dim startInfo As ProcessStartInfo

            startInfo = New ProcessStartInfo

            startInfo.EnvironmentVariables("rslicense") = "228165458269493124064444"

            startInfo.FileName = My.Settings.RELAPPath & "\relap5.EXE"
            startInfo.Arguments = pathstring
            startInfo.UseShellExecute = False

            Dim shell2 As Process

            shell2 = New Process

            shell2.StartInfo = startInfo

            shell2.Start()

            ' RetVal = Shell(pathstring, vbMaximizedFocus)
        Else
            If Dir$(My.Settings.RELAPPath & "\relap5.EXE") = "" Then
                MsgBox("RELAP5.EXE is not in " & My.Settings.RELAPPath & " folder", vbOKOnly, "Error")
            End If
            If Dir$(My.Settings.RELAPPath & "\tpfh2o") = "" Then
                MsgBox("Light water property file, tpfd2o is not in " & My.Settings.RELAPPath & " folder", vbOKOnly, "Error")
            End If
            If Dir$(My.Settings.RELAPPath & "\tpfd2o") = "" Then
                MsgBox("Light water property file, tpfh2o is not in " & My.Settings.RELAPPath & " folder", vbOKOnly, "Error")
            End If
        End If
        System.Threading.Thread.Sleep(6000)
        SetDeviceTime(olddate)
    End Sub
    'System time structure used to pass to P/Invoke...
    <StructLayoutAttribute(LayoutKind.Sequential)> _
    Private Structure SYSTEMTIME
        Public year As Short
        Public month As Short
        Public dayOfWeek As Short
        Public day As Short
        Public hour As Short
        Public minute As Short
        Public second As Short
        Public milliseconds As Short
    End Structure

    'P/Invoke dec for setting the system time...
    <DllImport("kernel32.dll")> _
    Private Shared Function SetLocalTime(ByRef time As SYSTEMTIME) As Boolean

    End Function
    Public Sub SetDeviceTime(ByVal p_NewDate As Date)
        'Populate structure...
        'Substitute <your date="" object=""> with your date object returned via GPRS...

        Dim st As SYSTEMTIME
        st.year = p_NewDate.Year
        st.month = p_NewDate.Month
        st.dayOfWeek = p_NewDate.DayOfWeek
        st.day = p_NewDate.Day
        st.hour = p_NewDate.Hour
        st.minute = p_NewDate.Minute
        st.second = p_NewDate.Second
        st.milliseconds = p_NewDate.Millisecond

        'Set the new time...
        Dim bool As Boolean = False

        bool = SetLocalTime(st)

        If bool = True Then

        End If
    End Sub

End Class

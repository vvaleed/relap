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
    '                        Case Microsoft.Msdn.Samples.GraphicObjects.TipoObjeto.HeatExchanger
    '                            .CLCS_HeatExchangerCollection(gObj.Name).GraphicObject = gObj
    '                            .HeatExchangerCollection(gObj.Name) = gObj
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
                form.FormSurface.FlowsheetDesignSurface.m_drawingObjects = DirectCast(mySerializer.Deserialize(fs3), Microsoft.MSDN.Samples.GraphicObjects.GraphicObjectCollection)
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
                Dim gObj As Microsoft.MSDN.Samples.GraphicObjects.GraphicObject
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
                For Each obj As Microsoft.MSDN.Samples.GraphicObjects.GraphicObject In form.FormSurface.FlowsheetDesignSurface.drawingObjects
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
                formc.FormSurface.FlowsheetDesignSurface.m_drawingObjects = DirectCast(mySerializer.Deserialize(fs3), Microsoft.MSDN.Samples.GraphicObjects.GraphicObjectCollection)
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
                Dim gObj As Microsoft.MSDN.Samples.GraphicObjects.GraphicObject
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
        Try
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
        '    mySerializer.Serialize(fs10, form.FormSpreadsheet.dt2)
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

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click, NewToolStripMenuItem.Click

        Dim NewMDIChild As New FormFlowsheet()

        'Set the Parent Form of the Child window.
        NewMDIChild.MdiParent = Me
        'Display the new form.
        NewMDIChild.Text = "Simulation" & m_childcount
        NewMDIChild.Show()
        Application.DoEvents()
        Me.ActivateMdiChild(NewMDIChild)
        m_childcount += 1

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
        System.Diagnostics.Process.Start("http://RELAP.inforside.com.br")
    End Sub

    Private Sub DownloadsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadsToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://sourceforge.net/project/showfiles.php?group_id=233626")
    End Sub

    Private Sub WikiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WikiToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://apps.sourceforge.net/mediawiki/RELAP/")
    End Sub

    Private Sub FórumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FórumToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://sourceforge.net/forum/?group_id=233626")
    End Sub

    Private Sub RastreamentoDeBugsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RastreamentoDeBugsToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://sourceforge.net/tracker/?group_id=233626")
    End Sub

    Private Sub DonateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DonateToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://sourceforge.net/project/project_donations.php?group_id=233626")
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
            If Not Me.bgSaveBackup.IsBusy Then Me.bgSaveBackup.RunWorkerAsync()
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
    Function boolto10(val) As String
        If val = True Then
            Return "1"
        Else
            Return "0"
        End If
    End Function

    Private Sub GenerateInputFileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GenerateInputFileOnlyToolStripMenuItem.Click
        Dim collect As New RELAP.FormClasses.ClsObjectCollections
        Dim ChildParent = My.Application.ActiveSimulation



        univID = 1

        Dim frmInitialSettings = My.Application.ActiveSimulation.FormInitialSettings

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


            generate.WriteLine("*======================================================================")
            generate.WriteLine("*          CODE GENERATED BY RELAP-GUI V-PRE RELEASE")
            generate.WriteLine("*          COPY RIGHT @ PIEAS PAKISTAN")
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*======================================================================")
            generate.WriteLine(("*FILE :" & SaveFileDialog1.FileName & "   ") + DateTime.Now)
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*======================================================================")
            '  generate.WriteLine("= " + Class1.initial.tb_title)
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*          PROBLEM TYPE AND OPTIONS card")
            generate.WriteLine("*======================================================================")

            ' card 100
            output = ChildParent.cboProblemType.SelectedItem

            output = output & " " & ChildParent.cboProblemOption.SelectedItem

            output = "100 " & output
            generate.WriteLine(output)

            ' card 101
            generate.WriteLine("101 " & ChildParent.cboInputCheck.SelectedItem)



            ' card 102 unit selection
            output = ChildParent.ToolStripComboBoxUnitSystem.SelectedItem & " " & ChildParent.cboOutputUnits.SelectedItem

            generate.WriteLine("102 " & output)

            ' 110  noncondensible gas
            Dim gascount As Integer = 1
            'If frmInitialSettings.chklistboxCondensibleGases.SelectedItems.Count = 0 Then
            generate.WriteLine("*======================================================================")
            generate.WriteLine("*          Non condensible gases card")
            generate.WriteLine("*======================================================================")

            output = frmInitialSettings.chklistboxCondensibleGases.CheckedItems(0).ToString

            generate.WriteLine("110 " & output)
            generate.WriteLine("115 " & "1.0")

            'Else
            '    For i = 0 To frmInitialSettings.chklistboxCondensibleGases.SelectedItems.Count - 1
            '        output = output & frmInitialSettings.chklistboxCondensibleGases.Items(frmInitialSettings.chklistboxCondensibleGases.SelectedIndices(i))
            '    Next
            '    generate.WriteLine(output)
            '    '     output = frmInitialSettings.chklistboxCondensibleGases.SelectedItems.Item(frmInitialSettings.chklistboxCondensibleGases.SelectedIndices.
            'End If
            'If Class1.initial.cbair = "True" Or Class1.initial.cbargon = "True" Or Class1.initial.cbcrypton = "True" Or Class1.initial.cbhelium = "True" Or Class1.initial.cbhydrogen = "True" Or Class1.initial.cbnitrogen = "True" Or Class1.initial.cbsf6 = "True" Or Class1.initial.cbxenon = "True" Then
            '    generate.WriteLine("*======================================================================")
            '    generate.WriteLine("*          Non condensible gases card")
            '    generate.WriteLine("*======================================================================")

            '    output = ""

            '    If Class1.initial.cbair = "True" And gascount <= 5 Then
            '        output = "air "
            '        gascount += 1
            '    End If
            '    If Class1.initial.cbargon = "True" And gascount <= 5 Then
            '        output = output & " argon"
            '        gascount += 1
            '    End If
            '    If Class1.initial.cbcrypton = "True" And gascount <= 5 Then
            '        output = output & " crypton"
            '        gascount += 1
            '    End If
            '    If Class1.initial.cbhelium = "True" And gascount <= 5 Then
            '        output = output & " helium"
            '        gascount += 1
            '    End If
            '    If Class1.initial.cbhydrogen = "True" And gascount <= 5 Then
            '        output = output & " hydrogen"
            '        gascount += 1
            '    End If
            '    If Class1.initial.cbnitrogen = "True" And gascount <= 5 Then
            '        output = output & " nitrogen"
            '        gascount += 1
            '    End If
            '    If Class1.initial.cbsf6 = "True" And gascount <= 5 Then
            '        output = output & " sf6"
            '        gascount += 1
            '    End If
            '    If Class1.initial.cbxenon = "True" And gascount <= 5 Then
            '        output = output & " xenon"
            '        gascount += 1
            '    End If
            '    generate.WriteLine("110 " & output)
            'End If


            'card 201
            generate.WriteLine("*")
            output = frmInitialSettings.txtendtime.Text & " " & frmInitialSettings.txtminsteptime.Text & " " & frmInitialSettings.txtmaxsteptime.Text & " " & frmInitialSettings.txtcontroloption.Text & " " & frmInitialSettings.txtMinorFrequency.Text & " " & frmInitialSettings.txtMajorFrequency.Text & " " & frmInitialSettings.txtRestartFrequency.Text
            generate.WriteLine("201 " & output)
            Dim i = 1
            Dim row As DataGridViewRow
            For j = 0 To My.Application.ActiveSimulation.FormPlotReqest.DataGridView1.Rows.Count - 2
                row = My.Application.ActiveSimulation.FormPlotReqest.DataGridView1.Rows(j)
                If row.Cells(1).Value = "Linear" Then
                    If row.Cells(2).Value = "Right" Then
                        output = "2030001" & i & " " & My.Application.ActiveSimulation.FormPlotReqest.txtPlotVariableName.Text & " " & My.Application.ActiveSimulation.FormPlotReqest.objs(i - 1) & "000000 2"
                    Else
                        output = "2030001" & i & " " & My.Application.ActiveSimulation.FormPlotReqest.txtPlotVariableName.Text & " " & My.Application.ActiveSimulation.FormPlotReqest.objs(i - 1) & "000000 1"
                    End If

                Else
                    If row.Cells(2).Value = "Right" Then
                        output = "2030001" & i & " " & My.Application.ActiveSimulation.FormPlotReqest.txtPlotVariableName.Text & " " & My.Application.ActiveSimulation.FormPlotReqest.objs(i - 1) & "000000 -2"
                    Else
                        output = "2030001" & i & " " & My.Application.ActiveSimulation.FormPlotReqest.txtPlotVariableName.Text & " " & My.Application.ActiveSimulation.FormPlotReqest.objs(i - 1) & "000000 -1"
                    End If

                End If
                i = i + 1
                generate.WriteLine(output)
            Next


            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.Tank) In ChildParent.Collections.CLCS_TankCollection
                '  MsgBox(kvp.Key)
                'kvp.Value.FlowArea.cardno()
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Time Dependent Volume '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ TMDPVOL")

                output = ((((((((kvp.Value.UID & "0101 " & kvp.Value.FlowArea & " ") & kvp.Value.LengthofVolume & " ") & kvp.Value.VolumeofVolume & " ") & kvp.Value.Azimuthalangle & " ") & kvp.Value.InclinationAngle & " ") & kvp.Value.ElevationChange & " ") & kvp.Value.WallRoughness & " ") & kvp.Value.HydraulicDiameter & " ") & "0000000"
                generate.WriteLine(output)


                univID = univID + 1
                '  MsgBox(kvp.Value.ComponentName)
            Next kvp


            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.SingleJunction) In ChildParent.Collections.CLCS_SingleJunctionCollection
                '  MsgBox(kvp.Key)
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Single Junction '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ sngljun")

                output = (((((kvp.Value.UID & "0101 " & kvp.Value.FromComponent & " ") & kvp.Value.ToComponent & " ") & kvp.Value.JunctionArea & " ") & kvp.Value.FflowLossCo & " ") & kvp.Value.RflowLossCo & " ") & "0000100"
                generate.WriteLine(output)

                If kvp.Value.EnterVelocityOrMassFlowRate = False Then
                    output = (((kvp.Value.UID & "0201 " & "0" & " ") & kvp.Value.InitialLiquidVelocity & " ") & kvp.Value.InitialVaporVelocity & " ") & kvp.Value.InterphaseVelocity
                ElseIf kvp.Value.EnterVelocityOrMassFlowRate = True Then
                    output = (((kvp.Value.UID & "0201 " & "1" & " ") & kvp.Value.InitialLiquidMassFlowRate & " ") & kvp.Value.InitialVaporMassFlowRate & " ") & kvp.Value.InterphaseMassFlowRate
                End If
                generate.WriteLine(output)

                univID = univID + 1
                '  MsgBox(kvp.Value.ComponentName)
            Next kvp

            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.Pump) In ChildParent.Collections.CLCS_PumpCollection
                '  MsgBox(kvp.Key)
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Pump '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ pump")

                output1 = boolto10(kvp.Value.EquilibriumTemperature)

                output = ((((((kvp.Value.UID & "0101 " & kvp.Value.FlowArea & " ") & kvp.Value.LengthofVolume & " ") & kvp.Value.VolumeofVolume & " ") & kvp.Value.Azimuthalangle & " ") & kvp.Value.InclinationAngle & " ") & kvp.Value.ElevationChange & " ") & "000000" & output1
                generate.WriteLine(output)

                output1 = boolto10(kvp.Value.CCFLModel)
                output2 = boolto10(kvp.Value.ChokingModel)
                If kvp.Value.SmoothAreaChange = True Then
                    output3 = "0"
                ElseIf kvp.Value.FullAbruptAreaChange = True Then
                    output3 = "1"
                ElseIf kvp.Value.PartialAbruptAreaChange = True Then
                    output3 = "2"
                Else
                    output3 = "0"
                End If

                If kvp.Value.TwoVelocityMomentumEquations = True Then
                    output4 = "0"
                ElseIf kvp.Value.SingleVelocityMomentumEquations = True Then
                    output4 = "2"
                Else
                    output4 = "1"
                End If

                output = (((kvp.Value.UID & "0108 " & kvp.Value.JunctionArea & " ") & kvp.Value.FflowLossCo & " ") & kvp.Value.RflowLossCo & " ") & "0" & output1 & "0" & output2 & output3 & output4 & "0"
                generate.WriteLine(output)

                output1 = boolto10(kvp.Value.OCCFLModel)
                output2 = boolto10(kvp.Value.OChokingModel)
                If kvp.Value.OSmoothAreaChange = True Then
                    output3 = "0"
                ElseIf kvp.Value.OFullAbruptAreaChange = True Then
                    output3 = "1"
                ElseIf kvp.Value.OPartialAbruptAreaChange = True Then
                    output3 = "2"
                Else
                    output3 = "0"
                End If

                If kvp.Value.OTwoVelocityMomentumEquations = True Then
                    output4 = "0"
                ElseIf kvp.Value.OSingleVelocityMomentumEquations = True Then
                    output4 = "2"
                Else
                    output4 = "1"
                End If

                output = (((kvp.Value.UID & "0109 " & kvp.Value.OJunctionArea & " ") & kvp.Value.OFflowLossCo & " ") & kvp.Value.ORflowLossCo & " ") & "0" & output1 & "0" & output2 & output3 & output4 & "0"
                generate.WriteLine(output)

                univID = univID + 1
            Next kvp


            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.FuelRod) In ChildParent.Collections.CLCS_FuelRodCollection
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component Fuel Rod '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                Dim temp As Int16
                temp = kvp.Value.UID
                Dim CID As String
                CID = temp.ToString("D2")
                generate.WriteLine("40" & CID & "0000 """ + kvp.Value.GraphicObject.Tag & """ fuel")

                output = "40" & CID & "0100 " & kvp.Value.NumberOfRods & " " & kvp.Value.FuelRodPitch & " " & kvp.Value.AverageBurnup
                generate.WriteLine(output)
                output = "40" & CID & "0200" & kvp.Value.PlenumLength & " " & kvp.Value.PlenumVoidVolume & " " & kvp.Value.LowerPlenumVoidVolume
                generate.WriteLine(output)
                output = "40" & CID & "0400" & kvp.Value.ControlVolumeAbove & " " & kvp.Value.ControlVolumeBelow
                generate.WriteLine(output)

            Next kvp

            For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.pipe) In ChildParent.Collections.CLCS_PipeCollection
                '  MsgBox(kvp.Key)
                'kvp.Value.FlowArea.cardno()
                generate.WriteLine("*======================================================================")
                generate.WriteLine("*         Component PIPE '" & kvp.Value.GraphicObject.Tag & "'")
                generate.WriteLine("*======================================================================")
                generate.WriteLine(kvp.Value.UID & "0000 """ + kvp.Value.GraphicObject.Tag & """ PIPE")
                output = kvp.Value.UID & "0001 " & kvp.Value.NumberOfVoulmes
                generate.WriteLine(output)
                Dim counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output = kvp.Value.UID & "010" & counter & " " & kvp2.Value.FlowArea & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2
                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output = kvp.Value.UID & "020" & counter & " " & kvp2.Value.JunctionFlowArea & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2
                counter = 1
                For Each kvp2 As KeyValuePair(Of Integer, PipeSection) In kvp.Value.Profile.Sections
                    output = kvp.Value.UID & "030" & counter & " " & kvp2.Value.LengthofVolume & " " & counter
                    generate.WriteLine(output)
                    counter = counter + 1
                Next kvp2



                univID = univID + 1
                '  MsgBox(kvp.Value.ComponentName)
            Next kvp

            generate.Close()
            MsgBox("File Saved")

            Exit Sub
            ' 105 mass fraction of gas
            '    If Class1.initial.cbair = "True" Or Class1.initial.cbargon = "True" And Class1.initial.cbcrypton = "True" Or Class1.initial.cbhelium = "True" Or Class1.initial.cbhydrogen = "True" Or Class1.initial.cbnitrogen = "True" Or Class1.initial.cbsf6 = "True" Or Class1.initial.cbxenon = "True" Then
            '        generate.WriteLine("*======================================================================")
            '        generate.WriteLine("*     non condensible gases mass fractions card")
            '        generate.WriteLine("*======================================================================")



            '        output = ""
            '        gascount = 1
            '        If Class1.initial.cbair = "True" And gascount <= 5 Then
            '            output = Class1.initial.tbair
            '            gascount += 1
            '        End If
            '        If Class1.initial.cbargon = "True" And gascount <= 5 Then
            '            output = (output & " ") + Class1.initial.tbargon
            '            gascount += 1
            '        End If
            '        If Class1.initial.cbcrypton = "True" And gascount <= 5 Then
            '            output = (output & " ") + Class1.initial.tbcrypton
            '            gascount += 1
            '        End If
            '        If Class1.initial.cbhelium = "True" And gascount <= 5 Then
            '            output = (output & " ") + Class1.initial.tbhelium
            '            gascount += 1
            '        End If
            '        If Class1.initial.cbhydrogen = "True" And gascount <= 5 Then
            '            output = (output & " ") + Class1.initial.tbhydrogen
            '            gascount += 1
            '        End If
            '        If Class1.initial.cbnitrogen = "True" And gascount <= 5 Then
            '            output = (output & " ") + Class1.initial.tbnitrogen
            '            gascount += 1
            '        End If
            '        If Class1.initial.cbsf6 = "True" And gascount <= 5 Then
            '            output = (output & " ") + Class1.initial.tbsf6
            '            gascount += 1
            '        End If
            '        If Class1.initial.cbxenon = "True" And gascount <= 5 Then
            '            output = (output & " ") + Class1.initial.tbxenon
            '            gascount += 1
            '        End If



            '        generate.WriteLine("115 " & output)
            '    End If
            '    ' 200 time initial



            '    If Class1.initial.cmbprobtype = "0" Or Class1.initial.cmbprobtype = "1" Then

            '        generate.WriteLine("*======================================================================")
            '        generate.WriteLine("*         initial time control card")
            '        generate.WriteLine("*======================================================================")
            '        generate.WriteLine("200 " + Class1.initial.tbinitime)
            '    End If

            '    ' time step control   201    299
            '    If Convert.ToInt32(Class1.lb_time_count) > 0 Then
            '        generate.WriteLine("*======================================================================")
            '        generate.WriteLine("*         time step control cards")
            '        generate.WriteLine("*======================================================================")
            '    End If
            '    For i As Integer = 1 To Convert.ToInt32(Class1.lb_time_count)
            '        If i < 10 Then
            '            generate.WriteLine(("20" & i & " ") + Class1.timecontrol(i - 1))
            '        End If
            '        If i >= 10 Then
            '            generate.WriteLine(("2" & i & " ") + Class1.timecontrol(i - 1))
            '        End If
            '    Next

            '    ' plot request

            '    generate.WriteLine("*======================================================================")
            '    generate.WriteLine("*         Plot request")
            '    generate.WriteLine("*======================================================================")
            '    For i As Integer = 0 To Class1.plotcounter - 1
            '        If i < 39 Then
            '            generate.WriteLine("20300" & Class1.lbplot(i).ToString())
            '        End If
            '    Next

            '    If True Then
            '        generate.WriteLine("*======================================================================")
            '        generate.WriteLine("*        Hydrodynamic Component DATA")
            '        generate.WriteLine("*======================================================================")
            '    End If
            '    Dim counter As Integer = 1
            '    Dim common As Double

            '    ' single VOLUME
            '    For i As Integer = 0 To 99
            '        If Class1.sngl_vol(i).gbname IsNot Nothing Then

            '            Class1.sngl_vol(i).id = Class1.sngl_vol(i).gbname.Substring(10, 3).ToString()
            '            counter = 1
            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*         Component SNGL Volume " + Class1.sngl_vol(i).id)
            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine(Class1.sngl_vol(i).id + "0000 " + Class1.sngl_vol(i).Nameid & " snglvol")
            '            ' single colue geometry card
            '            output = Nothing
            '            output = (((((((((Class1.sngl_vol(i).id + "0101" & " ") + Class1.sngl_vol(i).VFA & " ") + Class1.sngl_vol(i).LOV & " ") + Class1.sngl_vol(i).VOV & " ") + Class1.sngl_vol(i).AA & " ") + Class1.sngl_vol(i).IA & " ") + Class1.sngl_vol(i).EC & " ") + Class1.sngl_vol(i).WR & " ") + Class1.sngl_vol(i).HD & " ") + Class1.sngl_vol(i).VCFt + Class1.sngl_vol(i).VCFl + Class1.sngl_vol(i).VCFp + Class1.sngl_vol(i).VCFv + Class1.sngl_vol(i).VCFb + Class1.sngl_vol(i).VCFf + Class1.sngl_vol(i).VCFe

            '            generate.WriteLine(output)
            '            generate.WriteLine((Class1.sngl_vol(i).id + "0141 " + Class1.sngl_vol(i).SF & " ") + Class1.sngl_vol(i).VRC)
            '            ' initial condition SNGLVOL

            '            If Class1.sngl_vol(i).IC_TS = "0" Then
            '                output = ((Class1.sngl_vol(i).IC_P + " " + Class1.sngl_vol(i).IC_IEL & " ") + Class1.sngl_vol(i).IC_IEV & " ") + Class1.sngl_vol(i).IC_VVF
            '            ElseIf Class1.sngl_vol(i).IC_TS = "1" Then
            '                output = Class1.sngl_vol(i).IC_T + " " + Class1.sngl_vol(i).IC_SQE

            '            ElseIf Class1.sngl_vol(i).IC_TS = "2" Then
            '                output = Class1.sngl_vol(i).IC_P + " " + Class1.sngl_vol(i).IC_QE

            '            ElseIf Class1.sngl_vol(i).IC_TS = "3" Then
            '                output = Class1.sngl_vol(i).IC_P + " " + Class1.sngl_vol(i).IC_T

            '            ElseIf Class1.sngl_vol(i).IC_TS = "4" Then

            '                output = (Class1.sngl_vol(i).IC_P + " " + Class1.sngl_vol(i).IC_T & " ") + Class1.sngl_vol(i).IC_SQE

            '            ElseIf Class1.sngl_vol(i).IC_TS = "5" Then
            '                output = (Class1.sngl_vol(i).IC_T + " " + Class1.sngl_vol(i).IC_SQ & " ") + Class1.sngl_vol(i).IC_NCQE

            '            ElseIf Class1.sngl_vol(i).IC_TS = "6" Then
            '                output = (((Class1.sngl_vol(i).IC_P + " " + Class1.sngl_vol(i).IC_IEL & " ") + Class1.sngl_vol(i).IC_IEV & " ") + Class1.sngl_vol(i).IC_VVF & " ") + Class1.sngl_vol(i).IC_NCQ
            '            End If



            '            generate.WriteLine(Class1.sngl_vol(i).id + "0200 " + Class1.sngl_vol(i).IC_E + Class1.sngl_vol(i).IC_B + Class1.sngl_vol(i).IC_TS & " " & output)

            '        End If
            '    Next

            '    ' single junction generate


            '    For i As Integer = 0 To 99
            '        If Class1.singjunc(i).gbname IsNot Nothing Then
            '            Class1.singjunc(i).cmbhydroid = Class1.singjunc(i).gbname.Substring(10, 3).ToString()


            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*         Component Junction  " + Class1.singjunc(i).cmbhydroid)
            '            generate.WriteLine("*======================================================================")


            '            '
            '            '                        if (Class1.singjunc[i].cmbjuntype == "0")
            '            '                            output = "sngjun";
            '            '                        else
            '            '                            output = "TMDPJUN";
            '            '                     

            '            generate.WriteLine(Class1.singjunc(i).cmbhydroid + "0000 " + Class1.singjunc(i).txtname & " sngljun")

            '            ' goemetry card
            '            '  counter = 1;


            '            output = (Class1.singjunc(i).cmbhydroid + "0101" & " ") + Class1.singjunc(i).txtfromid

            '            If Convert.ToInt32(Class1.singjunc(i).txtvolumenumberfrom) <= 9 Then
            '                Class1.singjunc(i).txtvolumenumberfrom = "0" & Convert.ToInt32(Class1.singjunc(i).txtvolumenumberfrom).ToString()
            '            ElseIf Convert.ToInt32(Class1.singjunc(i).txtvolumenumberfrom) > 9 Then
            '                Class1.singjunc(i).txtvolumenumberfrom = Convert.ToInt32(Class1.singjunc(i).txtvolumenumberfrom).ToString()
            '            End If

            '            If Convert.ToInt32(Class1.singjunc(i).txtvolumenumberto) <= 9 Then
            '                Class1.singjunc(i).txtvolumenumberto = "0" & Convert.ToInt32(Class1.singjunc(i).txtvolumenumberto).ToString()
            '            ElseIf Convert.ToInt32(Class1.singjunc(i).txtvolumenumberto) > 9 Then
            '                Class1.singjunc(i).txtvolumenumberto = Convert.ToInt32(Class1.singjunc(i).txtvolumenumberto).ToString()
            '            End If

            '            If Convert.ToBoolean(Class1.singjunc(i).cbformatfrom) = False Then
            '                output = (output & "0") + Class1.singjunc(i).cmbconsidefrom & "0000" & " "
            '            Else
            '                If Class1.singjunc(i).cmbconsidefrom = "0" AndAlso Class1.singjunc(i).cmbconfacexfrom = "0" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberfrom & "0001" & " "
            '                ElseIf Class1.singjunc(i).cmbconsidefrom = "1" AndAlso Class1.singjunc(i).cmbconfacexfrom = "0" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberfrom & "0002" & " "
            '                ElseIf Class1.singjunc(i).cmbconsidefrom = "0" AndAlso Class1.singjunc(i).cmbconfacexfrom = "1" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberfrom & "0003" & " "
            '                ElseIf Class1.singjunc(i).cmbconsidefrom = "1" AndAlso Class1.singjunc(i).cmbconfacexfrom = "1" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberfrom & "0004" & " "
            '                ElseIf Class1.singjunc(i).cmbconsidefrom = "0" AndAlso Class1.singjunc(i).cmbconfacexfrom = "2" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberfrom & "0005" & " "
            '                ElseIf Class1.singjunc(i).cmbconsidefrom = "1" AndAlso Class1.singjunc(i).cmbconfacexfrom = "2" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberfrom & "0006" & " "
            '                End If
            '            End If

            '            'if (Convert.ToInt32(Class1.singjunc[i].txtvolumenumberfrom) < 10)
            '            '    output = output + "0" + Class1.singjunc[i].txtvolumenumberfrom.ToString();
            '            'else if (Convert.ToInt32(Class1.singjunc[i].txtvolumenumberfrom) >= 10)
            '            '    output = output + Class1.singjunc[i].txtvolumenumberfrom.ToString();

            '            'if (Class1.singjunc[i].cmbconsidefrom == "0" & Class1.singjunc[i].cmbconfacexfrom == "0")
            '            '    output = output + "0001" + " ";
            '            'else if (Class1.singjunc[i].cmbconsidefrom == "1" & Class1.singjunc[i].cmbconfacexfrom == "0")
            '            '    output = output + "0002" + " ";
            '            'else if (Class1.singjunc[i].cmbconsidefrom == "0" & Class1.singjunc[i].cmbconfacexfrom == "1")
            '            '    output = output + "0003" + " ";
            '            'else if (Class1.singjunc[i].cmbconsidefrom == "1" & Class1.singjunc[i].cmbconfacexfrom == "1")
            '            '    output = output + "0004" + " ";
            '            'else if (Class1.singjunc[i].cmbconsidefrom == "0" & Class1.singjunc[i].cmbconfacexfrom == "2")
            '            '    output = output + "0005" + " ";
            '            'else if (Class1.singjunc[i].cmbconsidefrom == "1" & Class1.singjunc[i].cmbconfacexfrom == "2")
            '            '    output = output + "0006" + " ";

            '            output = output + Class1.singjunc(i).txttoid

            '            If Convert.ToBoolean(Class1.singjunc(i).cbformatto) = False Then
            '                output = (output & "0") + Class1.singjunc(i).cmbconsideto & "0000" & " "
            '            Else
            '                If Class1.singjunc(i).cmbconsideto = "0" AndAlso Class1.singjunc(i).cmbconfacexto = "0" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberto & "0001" & " "
            '                ElseIf Class1.singjunc(i).cmbconsideto = "1" AndAlso Class1.singjunc(i).cmbconfacexto = "0" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberto & "0002" & " "
            '                ElseIf Class1.singjunc(i).cmbconsideto = "0" AndAlso Class1.singjunc(i).cmbconfacexto = "1" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberto & "0003" & " "
            '                ElseIf Class1.singjunc(i).cmbconsideto = "1" AndAlso Class1.singjunc(i).cmbconfacexto = "1" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberto & "0004" & " "
            '                ElseIf Class1.singjunc(i).cmbconsideto = "0" AndAlso Class1.singjunc(i).cmbconfacexto = "2" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberto & "0005" & " "
            '                ElseIf Class1.singjunc(i).cmbconsideto = "1" AndAlso Class1.singjunc(i).cmbconfacexto = "2" Then
            '                    output = output + Class1.singjunc(i).txtvolumenumberto & "0006" & " "
            '                End If
            '            End If


            '            'if (Convert.ToInt32(Class1.singjunc[i].txtvolumenumberto) < 10)
            '            '    output = output + "0" + Class1.singjunc[i].txtvolumenumberto.ToString();
            '            'else if (Convert.ToInt32(Class1.singjunc[i].txtvolumenumberto) >= 10)
            '            '    output = output + Class1.singjunc[i].txtvolumenumberto.ToString();

            '            'if (Class1.singjunc[i].cmbconsideto == "0" & Class1.singjunc[i].cmbconfacexto == "0")
            '            '    output = output + "0001" + " ";
            '            'else if (Class1.singjunc[i].cmbconsideto == "1" & Class1.singjunc[i].cmbconfacexto == "0")
            '            '    output = output + "0002" + " ";
            '            'else if (Class1.singjunc[i].cmbconsideto == "0" & Class1.singjunc[i].cmbconfacexto == "1")
            '            '    output = output + "0003" + " ";
            '            'else if (Class1.singjunc[i].cmbconsideto == "1" & Class1.singjunc[i].cmbconfacexto == "1")
            '            '    output = output + "0004" + " ";
            '            'else if (Class1.singjunc[i].cmbconsideto == "0" & Class1.singjunc[i].cmbconfacexto == "2")
            '            '    output = output + "0005" + " ";
            '            'else if (Class1.singjunc[i].cmbconsideto == "1" & Class1.singjunc[i].cmbconfacexto == "2")
            '            '    output = output + "0006" + " ";


            '            output = (((output & " ") + Class1.singjunc(i).txtjarea & " ") + Class1.singjunc(i).txtffelc & " ") + Class1.singjunc(i).txtrfelc & " "

            '            ' counter++;
            '            ' generate.WriteLine(Class1.singjunc[i].cmbhydroid + "010" + counter + " " + Class1.singjunc[i].txttoid  + "0" + Class1.singjunc[i].cmbconsideto  + "0000");
            '            ' counter++;
            '            'generate.WriteLine(Class1.singjunc[i].cmbhydroid + "010" + counter + " " + Class1.singjunc[i].txtjarea);
            '            ' counter++;
            '            'generate.WriteLine(Class1.singjunc[i].cmbhydroid + "010" + counter + " " + Class1.singjunc[i].txtffelc);
            '            ' counter++;
            '            'generate.WriteLine(Class1.singjunc[i].cmbhydroid + "010" + counter + " " + Class1.singjunc[i].txtrfelc);
            '            '  counter++;

            '            If Class1.singjunc(i).cbjetjun = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If
            '            If Class1.singjunc(i).cbmodpv = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.singjunc(i).cbccfl = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If
            '            output = output + Class1.singjunc(i).cmbhorstrat

            '            If Class1.singjunc(i).cbchoking = "False" Then
            '                output = output & "1"
            '            Else
            '                output = output & "0"
            '            End If
            '            output = output + Class1.singjunc(i).cmbareachange

            '            If Class1.singjunc(i).cbhomo = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "2"
            '            End If
            '            output = output + Class1.singjunc(i).cmbmf
            '            output = (((output & " ") + Class1.singjunc(i).txtsubdc & " ") + Class1.singjunc(i).txttpdc & " ") + Class1.singjunc(i).txtshdc

            '            generate.WriteLine(output)
            '            '
            '            '                              generate.WriteLine(Class1.singjunc[i].cmbhydroid + "010" + counter + " " +  output  );
            '            '                              counter++;
            '            '                              generate.WriteLine(Class1.singjunc[i].cmbhydroid + "010" + counter + " " + Class1.singjunc[i].txtsubdc);
            '            '                              counter++;
            '            '                              generate.WriteLine(Class1.singjunc[i].cmbhydroid + "010" + counter + " " + Class1.singjunc[i].txttpdc);
            '            '                              counter++;
            '            '                              generate.WriteLine(Class1.singjunc[i].cmbhydroid + "010" + counter + " " + Class1.singjunc[i].txtshdc);
            '            '                    // diameter and ccfl data


            '            If Class1.singjunc(i).cbccfl = "True" Then
            '                generate.WriteLine((((Class1.singjunc(i).cmbhydroid + "0110 " + Class1.singjunc(i).txtdj & " ") + Class1.singjunc(i).txtfcf & " ") + Class1.singjunc(i).txtgi & " ") + Class1.singjunc(i).txtslope)
            '            End If

            '            ' else
            '            ' generate.WriteLine(Class1.singjunc[i].cmbhydroid + "0110 " + Class1.singjunc[i].txtdj);  

            '            If Class1.singjunc(i).cbformloss = "True" Then
            '                generate.WriteLine((((Class1.singjunc(i).cmbhydroid + "0111 " + Class1.singjunc(i).txtbf & " ") + Class1.singjunc(i).txtcf & " ") + Class1.singjunc(i).txtbr & " ") + Class1.singjunc(i).txtcr)
            '            End If


            '            generate.WriteLine((((Class1.singjunc(i).cmbhydroid + "0201 " + Class1.singjunc(i).cmbvelmfr & " ") + Class1.singjunc(i).txtliq & " ") + Class1.singjunc(i).txtvap & " ") + Class1.singjunc(i).txtint)
            '        End If
            '    Next




            '    ' *******  PIPE code:

            '    ' &&&&&&&&&&&&&&&&&&&&&***********************&&&&&&&&&&&&&&&&&
            '    For i As Integer = 0 To 99
            '        If Class1.pipeannulus(i, 1).gbname IsNot Nothing Then
            '            Class1.pipeannulus(i, 1).cmbhydroid = Class1.pipeannulus(i, 1).gbname.Substring(10, 3).ToString()
            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*         Component PIPE " + Class1.pipeannulus(i, 1).cmbhydroid)
            '            generate.WriteLine("*======================================================================")

            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "0000 " + Class1.pipeannulus(i, 1).txtname & " pipe"
            '            generate.WriteLine(output)
            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "0001 " + Class1.pipeannulus(i, 1).txtnv
            '            generate.WriteLine(output)
            '            output = Nothing

            '            ' card X coordinate Volume Flow Area    101
            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = output + Class1.pipeannulus(i, 1).txtvfa
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1


            '                If Class1.pipeannulus(i, j - 1).txtvfa <> Class1.pipeannulus(i, j).txtvfa Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.pipeannulus(i, j).txtvfa
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.pipeannulus(i, j).txtvfa <> Class1.pipeannulus(i, j + 1).txtvfa And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            If Class1.pipeannulus(i, 1).txtnv = "2" AndAlso Class1.pipeannulus(i, 1).txtvfa <> Class1.pipeannulus(i, 2).txtvfa Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.pipeannulus(i, 1).txtvfa <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvfa Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvfa & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvfa & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            End If
            '            '
            '            '                        output = output + Class1.pipeannulus[i, Convert.ToInt32(Class1.pipeannulus[i, 1].txtnv)].txtvfa;
            '            '                        kl = Convert.ToInt32(Class1.pipeannulus[i, 1].txtnv) - kk;
            '            '                        output = output + " " + kl.ToString();
            '            '
            '            '                        

            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "0101 " & output
            '            generate.WriteLine(output)

            '            first1 = True

            '            ''' junction flow area 
            '            If Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) >= 2 Then

            '                kl = 0
            '                kk = 0
            '                output = Nothing
            '                output = Class1.pipeannulus(i, 1).txtjfa
            '                ' 1 ";
            '                For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 2


            '                    If Class1.pipeannulus(i, j - 1).txtjfa <> Class1.pipeannulus(i, j).txtjfa Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = output + Class1.pipeannulus(i, j).txtjfa
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If Class1.pipeannulus(i, j).txtjfa <> Class1.pipeannulus(i, j + 1).txtjfa And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                    End If
            '                Next
            '                If Class1.pipeannulus(i, 1).txtnv = "3" AndAlso Class1.pipeannulus(i, 1).txtjfa <> Class1.pipeannulus(i, 2).txtjfa Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.pipeannulus(i, 1).txtjfa <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtjfa Then
            '                    output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtjfa & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtjfa & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                End If
            '                output = Class1.pipeannulus(i, 1).cmbhydroid + "0201 " & output
            '                generate.WriteLine(output)
            '            End If

            '            ' card X coordinate Volume Length

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.pipeannulus(i, 1).txtvl
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1


            '                If Class1.pipeannulus(i, j - 1).txtvl <> Class1.pipeannulus(i, j).txtvl Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.pipeannulus(i, j).txtvl
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.pipeannulus(i, j).txtvl <> Class1.pipeannulus(i, j + 1).txtvl And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                End If
            '            Next
            '            If Class1.pipeannulus(i, 1).txtnv = "2" AndAlso Class1.pipeannulus(i, 1).txtvl <> Class1.pipeannulus(i, 2).txtvl Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.pipeannulus(i, 1).txtvl <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvl Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvl & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvl & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            End If
            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "0301 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate Volume volume

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.pipeannulus(i, 1).txtvv
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1


            '                If Class1.pipeannulus(i, j - 1).txtvv <> Class1.pipeannulus(i, j).txtvv Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.pipeannulus(i, j).txtvv
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.pipeannulus(i, j).txtvv <> Class1.pipeannulus(i, j + 1).txtvv And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                End If
            '            Next
            '            If Class1.pipeannulus(i, 1).txtnv = "2" AndAlso Class1.pipeannulus(i, 1).txtvv <> Class1.pipeannulus(i, 2).txtvv Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.pipeannulus(i, 1).txtvv <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvv Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvv & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvv & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            End If
            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "0401 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate Volume azimuthal angle

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.pipeannulus(i, 1).txtvaa
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1


            '                If Class1.pipeannulus(i, j - 1).txtvaa <> Class1.pipeannulus(i, j).txtvaa Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.pipeannulus(i, j).txtvaa
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.pipeannulus(i, j).txtvaa <> Class1.pipeannulus(i, j + 1).txtvaa And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            If Class1.pipeannulus(i, 1).txtnv = "2" AndAlso Class1.pipeannulus(i, 1).txtvaa <> Class1.pipeannulus(i, 2).txtvaa Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.pipeannulus(i, 1).txtvaa <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvaa Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvaa & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvaa & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            End If
            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "0501 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate Volume vertical angle

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.pipeannulus(i, 1).txtvva
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1


            '                If Class1.pipeannulus(i, j - 1).txtvva <> Class1.pipeannulus(i, j).txtvva Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.pipeannulus(i, j).txtvva
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.pipeannulus(i, j).txtvva <> Class1.pipeannulus(i, j + 1).txtvva And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            If Class1.pipeannulus(i, 1).txtnv = "2" AndAlso Class1.pipeannulus(i, 1).txtvva <> Class1.pipeannulus(i, 2).txtvva Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.pipeannulus(i, 1).txtvva <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvva Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvva & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            End If
            '            ' output = output + Class1.pipeannulus[i, Convert.ToInt32(Class1.pipeannulus[i, 1].txtnv)].txtvva + " " + Class1.pipeannulus[i, 1].txtnv.ToString();
            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "0601 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate Volume elevation change

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.pipeannulus(i, 1).txtvec
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1


            '                If Class1.pipeannulus(i, j - 1).txtvec <> Class1.pipeannulus(i, j).txtvec Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.pipeannulus(i, j).txtvec
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.pipeannulus(i, j).txtvec <> Class1.pipeannulus(i, j + 1).txtvec And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            If Class1.pipeannulus(i, 1).txtnv = "2" AndAlso Class1.pipeannulus(i, 1).txtvec <> Class1.pipeannulus(i, 2).txtvec Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.pipeannulus(i, 1).txtvec <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvec Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvec & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvec & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            End If
            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "0701 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate wall roughness
            '            ' if (Class1.pipeannulus[i, j - 1].txtvwr != Class1.pipeannulus[i, j].txtvwr | Class1.pipeannulus[i, j - 1].txtvhd != Class1.pipeannulus[i, j].txtvhd )
            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.pipeannulus(i, 1).txtvwr + " " + Class1.pipeannulus(i, 1).txtvhd
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1


            '                If Class1.pipeannulus(i, j - 1).txtvwr <> Class1.pipeannulus(i, j).txtvwr Or Class1.pipeannulus(i, j - 1).txtvhd <> Class1.pipeannulus(i, j).txtvhd Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    ' output = output + Class1.pipeannulus[i, j].txtvwr;
            '                    output = (output + Class1.pipeannulus(i, j).txtvwr & " ") + Class1.pipeannulus(i, j).txtvhd
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If (Class1.pipeannulus(i, j + 1).txtvwr <> Class1.pipeannulus(i, j).txtvwr Or Class1.pipeannulus(i, j + 1).txtvhd <> Class1.pipeannulus(i, j).txtvhd) And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            'if (Class1.pipeannulus[i,  1].txtvwr != Class1.pipeannulus[i, Convert.ToInt32(Class1.pipeannulus[i, 1].txtnv)].txtvwr | Class1.pipeannulus[i,  1].txtvhd != Class1.pipeannulus[i, Convert.ToInt32(Class1.pipeannulus[i, 1].txtnv)].txtvhd)
            '            If Class1.pipeannulus(i, 1).txtnv = "2" AndAlso Class1.pipeannulus(i, 1).txtvwr <> Class1.pipeannulus(i, 2).txtvwr OrElse Class1.pipeannulus(i, 1).txtvhd <> Class1.pipeannulus(i, 2).txtvhd Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.pipeannulus(i, 1).txtvwr <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvwr Or Class1.pipeannulus(i, 1).txtvhd <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvhd Then
            '                output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvwr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvhd & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvwr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvhd & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            End If

            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "0801 " & output
            '            generate.WriteLine(output)

            '            first1 = True

            '            ' juction loss coeffient
            '            If Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) >= 2 Then

            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = Class1.pipeannulus(i, 1).txtjaf + " " + Class1.pipeannulus(i, 1).txtjar
            '                ' 1 ";
            '                For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 2


            '                    If Class1.pipeannulus(i, j - 1).txtjaf <> Class1.pipeannulus(i, j).txtjaf Or Class1.pipeannulus(i, j - 1).txtjar <> Class1.pipeannulus(i, j).txtjar Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = (output + Class1.pipeannulus(i, j).txtjaf & " ") + Class1.pipeannulus(i, j).txtjar
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.pipeannulus(i, j).txtjaf <> Class1.pipeannulus(i, j + 1).txtjaf Or Class1.pipeannulus(i, j).txtjar <> Class1.pipeannulus(i, j + 1).txtjar) And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If

            '                    End If
            '                Next
            '                If Class1.pipeannulus(i, 1).txtnv = "3" AndAlso Class1.pipeannulus(i, 1).txtjaf <> Class1.pipeannulus(i, 2).txtjaf OrElse Class1.pipeannulus(i, 1).txtjar <> Class1.pipeannulus(i, 2).txtjar Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.pipeannulus(i, 1).txtjaf <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtjaf Or Class1.pipeannulus(i, 1).txtjar <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtjar Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtjaf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtjaf & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtjaf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtjaf & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                End If

            '                output = Class1.pipeannulus(i, 1).cmbhydroid + "0901 " & output
            '                generate.WriteLine(output)
            '            End If


            '            ' x-coordinate controol cards cards ccc1001-ccc1099




            '            kk = 0
            '            kl = 0
            '            first1 = True
            '            output = Nothing
            '            If Class1.pipeannulus(i, 1).cbtftm = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.pipeannulus(i, 1).cbcbmltm = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.pipeannulus(i, 1).cbwps = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If
            '            If Class1.pipeannulus(i, 1).cbvsmnew = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.pipeannulus(i, 1).cmbifnew = "0" Then
            '                output = output & "0"
            '            ElseIf Class1.pipeannulus(i, 1).cmbifnew = "1" Then
            '                output = output & "1"
            '            End If

            '            If Class1.pipeannulus(i, 1).cbwf = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.pipeannulus(i, 1).cbneqb = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1
            '                If Class1.pipeannulus(i, j - 1).cbtftm <> Class1.pipeannulus(i, j).cbtftm Or Class1.pipeannulus(i, j - 1).cbcbmltm <> Class1.pipeannulus(i, j).cbcbmltm Or Class1.pipeannulus(i, j - 1).cbwps <> Class1.pipeannulus(i, j).cbwps Or Class1.pipeannulus(i, j - 1).cbvsmnew <> Class1.pipeannulus(i, j).cbvsmnew Or Class1.pipeannulus(i, j - 1).cmbifnew <> Class1.pipeannulus(i, j).cmbifnew Or Class1.pipeannulus(i, j - 1).cbwf <> Class1.pipeannulus(i, j).cbwf Or Class1.pipeannulus(i, j - 1).cbneqb <> Class1.pipeannulus(i, j).cbneqb Then

            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If

            '                    'output = output + Class1.pipeannulus[i, j].txtjaf + " " + Class1.pipeannulus[i, j].txtjar;

            '                    If Class1.pipeannulus(i, j).cbtftm = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.pipeannulus(i, j).cbcbmltm = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.pipeannulus(i, j).cbwps = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If
            '                    If Class1.pipeannulus(i, j).cbvsmnew = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If
            '                    If Class1.pipeannulus(i, j).cmbifnew = "0" Then
            '                        output = output & "0"
            '                    ElseIf Class1.pipeannulus(i, j).cmbifnew = "1" Then
            '                        output = output & "1"
            '                    End If

            '                    If Class1.pipeannulus(i, j).cbwf = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.pipeannulus(i, j).cbneqb = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If (Class1.pipeannulus(i, j + 1).cbtftm <> Class1.pipeannulus(i, j).cbtftm Or Class1.pipeannulus(i, j + 1).cbcbmltm <> Class1.pipeannulus(i, j).cbcbmltm Or Class1.pipeannulus(i, j + 1).cbwps <> Class1.pipeannulus(i, j).cbwps Or Class1.pipeannulus(i, j + 1).cbvsmnew <> Class1.pipeannulus(i, j).cbvsmnew Or Class1.pipeannulus(i, j + 1).cmbifnew <> Class1.pipeannulus(i, j).cmbifnew Or Class1.pipeannulus(i, j + 1).cbwf <> Class1.pipeannulus(i, j).cbwf Or Class1.pipeannulus(i, j + 1).cbneqb <> Class1.pipeannulus(i, j).cbneqb) And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If



            '                End If
            '            Next
            '            If Class1.pipeannulus(i, 1).txtnv = "2" AndAlso (Class1.pipeannulus(i, 1).cbtftm <> Class1.pipeannulus(i, 2).cbtftm Or Class1.pipeannulus(i, 1).cbcbmltm <> Class1.pipeannulus(i, 2).cbcbmltm Or Class1.pipeannulus(i, 1).cbwps <> Class1.pipeannulus(i, 2).cbwps Or Class1.pipeannulus(i, 1).cbvsmnew <> Class1.pipeannulus(i, 2).cbvsmnew Or Class1.pipeannulus(i, 1).cmbifnew <> Class1.pipeannulus(i, 2).cmbifnew Or Class1.pipeannulus(i, 1).cbwf <> Class1.pipeannulus(i, 2).cbwf Or Class1.pipeannulus(i, 1).cbneqb <> Class1.pipeannulus(i, 2).cbneqb) Then
            '                output = output & " 1 "
            '            End If


            '            If Class1.pipeannulus(i, 1).cbtftm <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbtftm Or Class1.pipeannulus(i, 1).cbcbmltm <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbcbmltm Or Class1.pipeannulus(i, 1).cbwps <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbwps Or Class1.pipeannulus(i, 1).cbvsmnew <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbvsmnew Or Class1.pipeannulus(i, 1).cmbifnew <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbifnew Or Class1.pipeannulus(i, 1).cbwf <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbwf Or Class1.pipeannulus(i, 1).cbneqb <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbneqb Then
            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbtftm = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbcbmltm = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbwps = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbvsmnew = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbifnew = "0" Then
            '                    output = output & "0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbifnew = "1" Then
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbwf = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbneqb = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()


            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbtftm = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbcbmltm = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbwps = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbvsmnew = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbifnew = "0" Then
            '                    output = output & "0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbifnew = "1" Then
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbwf = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbneqb = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            End If

            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "1001 " & output
            '            generate.WriteLine(output)

            '            ' juction control flages @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            '            If Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) >= 2 Then
            '                kk = 0
            '                kl = 0
            '                output = Nothing
            '                first1 = True

            '                If Class1.pipeannulus(i, 1).cbmodpv = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, 1).cbccfl = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, 1).cbhse = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.pipeannulus(i, 1).cbchoking = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                output = output + Class1.pipeannulus(i, 1).cmbareachange

            '                If Class1.pipeannulus(i, 1).cbhomo = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "2"
            '                End If
            '                output = output + Class1.pipeannulus(i, 1).cmbmf

            '                For j As Integer = 2 To (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1) - 1
            '                    If Class1.pipeannulus(i, j - 1).cbmodpv <> Class1.pipeannulus(i, j).cbmodpv Or Class1.pipeannulus(i, j - 1).cbccfl <> Class1.pipeannulus(i, j).cbccfl Or Class1.pipeannulus(i, j - 1).cbchoking <> Class1.pipeannulus(i, j).cbchoking Or Class1.pipeannulus(i, j - 1).cmbareachange <> Class1.pipeannulus(i, j).cmbareachange Or Class1.pipeannulus(i, j - 1).cbhomo <> Class1.pipeannulus(i, j).cbhomo Or Class1.pipeannulus(i, j - 1).cmbmf <> Class1.pipeannulus(i, j).cmbmf Or Class1.pipeannulus(i, j - 1).cbvsmnew <> Class1.pipeannulus(i, j).cbvsmnew Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        'output = output + Class1.pipeannulus[i, j].txtjaf + " " + Class1.pipeannulus[i, j].txtjar;
            '                        If Class1.pipeannulus(i, j).cbmodpv = "False" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "1"
            '                        End If

            '                        If Class1.pipeannulus(i, j).cbccfl = "False" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "1"
            '                        End If

            '                        If Class1.pipeannulus(i, j).cbhse = "False" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "1"
            '                        End If

            '                        If Class1.pipeannulus(i, j).cbchoking = "True" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "1"
            '                        End If
            '                        output = output + Class1.pipeannulus(i, j).cmbareachange

            '                        If Class1.pipeannulus(i, j).cbhomo = "False" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "2"
            '                        End If
            '                        output = output + Class1.pipeannulus(i, j).cmbmf


            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.pipeannulus(i, j + 1).cbmodpv <> Class1.pipeannulus(i, j).cbmodpv Or Class1.pipeannulus(i, j + 1).cbccfl <> Class1.pipeannulus(i, j).cbccfl Or Class1.pipeannulus(i, j + 1).cbchoking <> Class1.pipeannulus(i, j).cbchoking Or Class1.pipeannulus(i, j + 1).cmbareachange <> Class1.pipeannulus(i, j).cmbareachange Or Class1.pipeannulus(i, j + 1).cbhomo <> Class1.pipeannulus(i, j).cbhomo Or Class1.pipeannulus(i, j + 1).cmbmf <> Class1.pipeannulus(i, j).cmbmf Or Class1.pipeannulus(i, j + 1).cbhse <> Class1.pipeannulus(i, j).cbhse) And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If

            '                    End If
            '                Next

            '                If Class1.pipeannulus(i, 1).txtnv = "3" AndAlso (Class1.pipeannulus(i, 2).cbmodpv <> Class1.pipeannulus(i, 1).cbmodpv Or Class1.pipeannulus(i, 2).cbccfl <> Class1.pipeannulus(i, 1).cbccfl Or Class1.pipeannulus(i, 2).cbchoking <> Class1.pipeannulus(i, 1).cbchoking Or Class1.pipeannulus(i, 2).cmbareachange <> Class1.pipeannulus(i, 1).cmbareachange Or Class1.pipeannulus(i, 2).cbhomo <> Class1.pipeannulus(i, 1).cbhomo Or Class1.pipeannulus(i, 2).cmbmf <> Class1.pipeannulus(i, 1).cmbmf Or Class1.pipeannulus(i, 2).cbhse <> Class1.pipeannulus(i, 1).cbhse) Then
            '                    output = output & " 1 "
            '                End If


            '                If Class1.pipeannulus(i, 1).cbmodpv <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbmodpv Or Class1.pipeannulus(i, 1).cbccfl <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbccfl Or Class1.pipeannulus(i, 1).cbchoking <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbchoking Or Class1.pipeannulus(i, 1).cmbareachange <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cmbareachange Or Class1.pipeannulus(i, 1).cbhomo <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbhomo Or Class1.pipeannulus(i, 1).cmbmf <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cmbmf Or Class1.pipeannulus(i, 1).cbhse <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbhse Then
            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbmodpv = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbccfl = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbhse = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If


            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbchoking = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cmbareachange

            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbhomo = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "2"
            '                    End If

            '                    output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cmbmf
            '                    output = output & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbmodpv = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbccfl = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbhse = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbchoking = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cmbareachange

            '                    If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cbhomo = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "2"
            '                    End If

            '                    output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).cmbmf

            '                    output = output & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                End If
            '                output = Class1.pipeannulus(i, 1).cmbhydroid + "1101 " & output
            '                generate.WriteLine(output)
            '            End If

            '            ' initial conditions ******************************************************************
            '            kk = 0
            '            kl = 0
            '            output = Nothing
            '            first1 = True

            '            output = Class1.pipeannulus(i, 1).cmbfluid

            '            If Class1.pipeannulus(i, 1).cbboron = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            output = output + Class1.pipeannulus(i, 1).cmbithstate & " "

            '            If Class1.pipeannulus(i, 1).cmbithstate = "0" Then
            '                output = (((output + Class1.pipeannulus(i, 1).txtpr & " ") + Class1.pipeannulus(i, 1).txtlsie & " ") + Class1.pipeannulus(i, 1).txtvsie & " ") + Class1.pipeannulus(i, 1).txtvvf & " " & "0.0"
            '            ElseIf Class1.pipeannulus(i, 1).cmbithstate = "1" Then
            '                output = (output + Class1.pipeannulus(i, 1).txtt & " ") + Class1.pipeannulus(i, 1).txtsqeq & " 0.0" & " 0.0" & " 0.0"

            '            ElseIf Class1.pipeannulus(i, 1).cmbithstate = "2" Then
            '                output = (output + Class1.pipeannulus(i, 1).txtpr & " ") + Class1.pipeannulus(i, 1).txtsqeq & " 0.0" & " 0.0" & " 0.0"


            '            ElseIf Class1.pipeannulus(i, 1).cmbithstate = "3" Then
            '                output = (output + Class1.pipeannulus(i, 1).txtpr & " ") + Class1.pipeannulus(i, 1).txtt & " 0.0" & " 0.0" & " 0.0"
            '            ElseIf Class1.pipeannulus(i, 1).cmbithstate = "4" Then

            '                output = ((output + Class1.pipeannulus(i, 1).txtpr & " ") + Class1.pipeannulus(i, 1).txtt & " ") + Class1.pipeannulus(i, 1).txtsqeq & " 0.0" & " 0.0"
            '            ElseIf Class1.pipeannulus(i, 1).cmbithstate = "5" Then
            '                output = ((output + Class1.pipeannulus(i, 1).txtt & " ") + Class1.pipeannulus(i, 1).txtsq & " ") + Class1.pipeannulus(i, 1).txtncqeq & " 0.0" & " 0.0"
            '            ElseIf Class1.pipeannulus(i, 1).cmbithstate = "6" Then
            '                output = ((((output + Class1.pipeannulus(i, 1).txtpr & " ") + Class1.pipeannulus(i, 1).txtlsie & " ") + Class1.pipeannulus(i, 1).txtvsie & " ") + Class1.pipeannulus(i, 1).txtvvf & " ") + Class1.pipeannulus(i, 1).txtncq
            '            End If

            '            ' /000000000000000000000000000000000000000000000

            '            For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1
            '                If Class1.pipeannulus(i, j - 1).cmbfluid <> Class1.pipeannulus(i, j).cmbfluid Or Class1.pipeannulus(i, j - 1).cbboron <> Class1.pipeannulus(i, j).cbboron Or Class1.pipeannulus(i, j - 1).cmbithstate <> Class1.pipeannulus(i, j).cmbithstate Or Class1.pipeannulus(i, j - 1).cmbithstate <> Class1.pipeannulus(i, j).cmbithstate Or Class1.pipeannulus(i, j - 1).txtt <> Class1.pipeannulus(i, j).txtt Or Class1.pipeannulus(i, j - 1).txtpr <> Class1.pipeannulus(i, j).txtpr Or Class1.pipeannulus(i, j - 1).txtvsie <> Class1.pipeannulus(i, j).txtvsie Or Class1.pipeannulus(i, j - 1).txtlsie <> Class1.pipeannulus(i, j).txtlsie Or Class1.pipeannulus(i, j - 1).txtvvf <> Class1.pipeannulus(i, j).txtvvf Or Class1.pipeannulus(i, j - 1).txtsqeq <> Class1.pipeannulus(i, j).txtsqeq Or Class1.pipeannulus(i, j - 1).txtncqeq <> Class1.pipeannulus(i, j).txtncqeq Or Class1.pipeannulus(i, j - 1).txtsq <> Class1.pipeannulus(i, j).txtsq Or Class1.pipeannulus(i, j - 1).txtqeq <> Class1.pipeannulus(i, j).txtqeq Or Class1.pipeannulus(i, j - 1).txtncq <> Class1.pipeannulus(i, j).txtncq Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.pipeannulus(i, j).cmbfluid

            '                    If Class1.pipeannulus(i, j).cbboron = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    output = output + Class1.pipeannulus(i, j).cmbithstate & " "

            '                    If Class1.pipeannulus(i, j).cmbithstate = "0" Then
            '                        output = (((output + Class1.pipeannulus(i, j).txtpr & " ") + Class1.pipeannulus(i, j).txtlsie & " ") + Class1.pipeannulus(i, j).txtvsie & " ") + Class1.pipeannulus(i, j).txtvvf & " " & "0.0"
            '                    ElseIf Class1.pipeannulus(i, j).cmbithstate = "1" Then
            '                        output = (output + Class1.pipeannulus(i, j).txtt & " ") + Class1.pipeannulus(i, j).txtsqeq & " 0.0" & " 0.0" & " 0.0"

            '                    ElseIf Class1.pipeannulus(i, j).cmbithstate = "2" Then
            '                        output = (output + Class1.pipeannulus(i, j).txtpr & " ") + Class1.pipeannulus(i, j).txtsqeq & " 0.0" & " 0.0" & " 0.0"


            '                    ElseIf Class1.pipeannulus(i, j).cmbithstate = "3" Then
            '                        output = (output + Class1.pipeannulus(i, j).txtpr & " ") + Class1.pipeannulus(i, j).txtt & " 0.0" & " 0.0" & " 0.0"
            '                    ElseIf Class1.pipeannulus(i, j).cmbithstate = "4" Then

            '                        output = ((output + Class1.pipeannulus(i, j).txtpr & " ") + Class1.pipeannulus(i, j).txtt & " ") + Class1.pipeannulus(i, j).txtsqeq & " 0.0" & " 0.0"
            '                    ElseIf Class1.pipeannulus(i, j).cmbithstate = "5" Then
            '                        output = ((output + Class1.pipeannulus(i, j).txtt & " ") + Class1.pipeannulus(i, j).txtsq & " ") + Class1.pipeannulus(i, j).txtncqeq & " 0.0" & " 0.0"
            '                    ElseIf Class1.pipeannulus(i, j).cmbithstate = "6" Then
            '                        output = ((((output + Class1.pipeannulus(i, j).txtpr & " ") + Class1.pipeannulus(i, j).txtlsie & " ") + Class1.pipeannulus(i, j).txtvsie & " ") + Class1.pipeannulus(i, j).txtvvf & " ") + Class1.pipeannulus(i, j).txtncq
            '                    End If
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else

            '                    If (Class1.pipeannulus(i, j + 1).cmbfluid <> Class1.pipeannulus(i, j).cmbfluid Or Class1.pipeannulus(i, j + 1).cbboron <> Class1.pipeannulus(i, j).cbboron Or Class1.pipeannulus(i, j + 1).cmbithstate <> Class1.pipeannulus(i, j).cmbithstate Or Class1.pipeannulus(i, j + 1).cmbithstate <> Class1.pipeannulus(i, j).cmbithstate Or Class1.pipeannulus(i, j + 1).txtt <> Class1.pipeannulus(i, j).txtt Or Class1.pipeannulus(i, j + 1).txtpr <> Class1.pipeannulus(i, j).txtpr Or Class1.pipeannulus(i, j + 1).txtvsie <> Class1.pipeannulus(i, j).txtvsie Or Class1.pipeannulus(i, j + 1).txtlsie <> Class1.pipeannulus(i, j).txtlsie Or Class1.pipeannulus(i, j + 1).txtvvf <> Class1.pipeannulus(i, j).txtvvf Or Class1.pipeannulus(i, j + 1).txtsqeq <> Class1.pipeannulus(i, j).txtsqeq Or Class1.pipeannulus(i, j + 1).txtncqeq <> Class1.pipeannulus(i, j).txtncqeq Or Class1.pipeannulus(i, j + 1).txtsq <> Class1.pipeannulus(i, j).txtsq Or Class1.pipeannulus(i, j + 1).txtqeq <> Class1.pipeannulus(i, j).txtqeq Or Class1.pipeannulus(i, j + 1).txtncq <> Class1.pipeannulus(i, j).txtncq) And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                End If
            '            Next
            '            If Class1.pipeannulus(i, 1).txtnv = "2" AndAlso (Class1.pipeannulus(i, 1).cmbfluid <> Class1.pipeannulus(i, 2).cmbfluid Or Class1.pipeannulus(i, 1).cbboron <> Class1.pipeannulus(i, 2).cbboron Or Class1.pipeannulus(i, 1).cmbithstate <> Class1.pipeannulus(i, 2).cmbithstate Or Class1.pipeannulus(i, 1).cmbithstate <> Class1.pipeannulus(i, 2).cmbithstate Or Class1.pipeannulus(i, 1).txtt <> Class1.pipeannulus(i, 2).txtt Or Class1.pipeannulus(i, 1).txtpr <> Class1.pipeannulus(i, 2).txtpr Or Class1.pipeannulus(i, 1).txtvsie <> Class1.pipeannulus(i, 2).txtvsie Or Class1.pipeannulus(i, 1).txtlsie <> Class1.pipeannulus(i, 2).txtlsie Or Class1.pipeannulus(i, 1).txtvvf <> Class1.pipeannulus(i, 2).txtvvf Or Class1.pipeannulus(i, 1).txtsqeq <> Class1.pipeannulus(i, 2).txtsqeq Or Class1.pipeannulus(i, 1).txtncqeq <> Class1.pipeannulus(i, 2).txtncqeq Or Class1.pipeannulus(i, 1).txtsq <> Class1.pipeannulus(i, 2).txtsq Or Class1.pipeannulus(i, 1).txtqeq <> Class1.pipeannulus(i, 2).txtqeq Or Class1.pipeannulus(i, 1).txtncq <> Class1.pipeannulus(i, 2).txtncq) Then
            '                output = output & " 1 "
            '            End If

            '            '''/////////////////////////   
            '            If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbfluid <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbfluid Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbboron <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbboron Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvsie <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvsie Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtlsie <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtlsie Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvvf <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvvf Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsqeq <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsqeq Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtncqeq <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtncqeq Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsq <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsq Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtqeq <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtqeq Or Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtncq <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtncq Then

            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbfluid

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbboron = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate & " "

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "0" Then
            '                    output = (((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtlsie & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvsie & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvvf & " " & "0.0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "1" Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0" & " 0.0"

            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "2" Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0" & " 0.0"


            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "3" Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt & " 0.0" & " 0.0" & " 0.0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "4" Then

            '                    output = ((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "5" Then
            '                    output = ((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsq & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtncqeq & " 0.0" & " 0.0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "6" Then
            '                    output = ((((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtlsie & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvsie & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvvf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtncq
            '                End If

            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()


            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbfluid

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cbboron = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                output = output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate & " "

            '                If Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "0" Then
            '                    output = (((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtlsie & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvsie & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvvf & " " & "0.0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "1" Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0" & " 0.0"

            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "2" Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0" & " 0.0"


            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "3" Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt & " 0.0" & " 0.0" & " 0.0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "4" Then

            '                    output = ((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "5" Then
            '                    output = ((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtt & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtsq & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtncqeq & " 0.0" & " 0.0"
            '                ElseIf Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).cmbithstate = "6" Then
            '                    output = ((((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtpr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtlsie & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvsie & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtvvf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv)).txtncq
            '                End If


            '                output = output & " " & Class1.pipeannulus(i, 1).txtnv.ToString()
            '            End If


            '            output = Class1.pipeannulus(i, 1).cmbhydroid + "1201 " & output
            '            generate.WriteLine(output)


            '            '  boron concentration  card ccc 2001 ccc2099

            '            ' juction loss coeffient  1301  1399
            '            If Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) >= 2 Then
            '                generate.WriteLine(Class1.pipeannulus(i, 1).cmbhydroid + "1300 " + Class1.pipeannulus(i, 1).cmbvelmfr)

            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = Class1.pipeannulus(i, 1).txtliq + " " + Class1.pipeannulus(i, 1).txtvap & " 0.0"
            '                ' 1 ";
            '                For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 2
            '                    If Class1.pipeannulus(i, j - 1).txtliq <> Class1.pipeannulus(i, j).txtliq Or Class1.pipeannulus(i, j - 1).txtvap <> Class1.pipeannulus(i, j).txtvap Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = (output + Class1.pipeannulus(i, j).txtliq & " ") + Class1.pipeannulus(i, j).txtvap & " 0.0"
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.pipeannulus(i, j + 1).txtliq <> Class1.pipeannulus(i, j).txtliq Or Class1.pipeannulus(i, j + 1).txtvap <> Class1.pipeannulus(i, j).txtvap) And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If

            '                    End If
            '                Next

            '                If Class1.pipeannulus(i, 1).txtnv = "3" AndAlso (Class1.pipeannulus(i, 2).txtliq <> Class1.pipeannulus(i, 1).txtliq Or Class1.pipeannulus(i, 2).txtvap <> Class1.pipeannulus(i, 1).txtvap) Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.pipeannulus(i, 1).txtliq <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtliq Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtliq & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtvap & " 0.0" & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = (output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtliq & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtvap & " 0.0" & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                End If

            '                output = Class1.pipeannulus(i, 1).cmbhydroid + "1301 " & output
            '                generate.WriteLine(output)

            '                ' juction diameter and ccfl  1401 1499


            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = ((Class1.pipeannulus(i, 1).txtdj + " " + Class1.pipeannulus(i, 1).txtfcf & " ") + Class1.pipeannulus(i, 1).txtgi & " ") + Class1.pipeannulus(i, 1).txtslope
            '                For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 2
            '                    If Class1.pipeannulus(i, j - 1).txtdj <> Class1.pipeannulus(i, j).txtdj Or Class1.pipeannulus(i, j - 1).txtfcf <> Class1.pipeannulus(i, j).txtfcf Or Class1.pipeannulus(i, j - 1).txtgi <> Class1.pipeannulus(i, j).txtgi Or Class1.pipeannulus(i, j - 1).txtslope <> Class1.pipeannulus(i, j).txtslope Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = (((output + Class1.pipeannulus(i, j).txtdj & " ") + Class1.pipeannulus(i, j).txtfcf & " ") + Class1.pipeannulus(i, j).txtgi & " ") + Class1.pipeannulus(i, j).txtslope
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.pipeannulus(i, j + 1).txtdj <> Class1.pipeannulus(i, j).txtdj Or Class1.pipeannulus(i, j + 1).txtfcf <> Class1.pipeannulus(i, j).txtfcf Or Class1.pipeannulus(i, j + 1).txtgi <> Class1.pipeannulus(i, j).txtgi Or Class1.pipeannulus(i, j + 1).txtslope <> Class1.pipeannulus(i, j).txtslope) And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If

            '                    End If
            '                Next

            '                If Class1.pipeannulus(i, 1).txtnv = "3" AndAlso (Class1.pipeannulus(i, 1).txtdj <> Class1.pipeannulus(i, 2).txtdj Or Class1.pipeannulus(i, 1).txtfcf <> Class1.pipeannulus(i, 2).txtfcf Or Class1.pipeannulus(i, 1).txtgi <> Class1.pipeannulus(i, 2).txtgi Or Class1.pipeannulus(i, 1).txtslope <> Class1.pipeannulus(i, 2).txtslope) Then
            '                    output = output & " 1 "
            '                End If


            '                If Class1.pipeannulus(i, 1).txtdj <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtdj Or Class1.pipeannulus(i, 1).txtfcf <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtfcf Or Class1.pipeannulus(i, 1).txtgi <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtgi Or Class1.pipeannulus(i, 1).txtslope <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtslope Then
            '                    'if (Class1.pipeannulus[i, 1].txtdj != Class1.pipeannulus[i, Convert.ToInt32(Class1.pipeannulus[i, 1].txtnv)-1].txtdj)
            '                    output = (((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtdj & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtfcf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtgi & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtslope & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = (((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtdj & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtfcf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtgi & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtslope & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                End If

            '                output = Class1.pipeannulus(i, 1).cmbhydroid + "1401 " & output
            '                generate.WriteLine(output)

            '                ' juction form loss data 3001 3099


            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = ((Class1.pipeannulus(i, 1).txtbf + " " + Class1.pipeannulus(i, 1).txtcf & " ") + Class1.pipeannulus(i, 1).txtbr & " ") + Class1.pipeannulus(i, 1).txtcr
            '                For j As Integer = 2 To Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 2
            '                    If Class1.pipeannulus(i, j - 1).txtbf <> Class1.pipeannulus(i, j).txtbf Or Class1.pipeannulus(i, j - 1).txtcf <> Class1.pipeannulus(i, j).txtcf Or Class1.pipeannulus(i, j - 1).txtbr <> Class1.pipeannulus(i, j).txtbr Or Class1.pipeannulus(i, j - 1).txtcr <> Class1.pipeannulus(i, j).txtcr Then
            '                        'if (Class1.pipeannulus[i, j - 1].txtbf != Class1.pipeannulus[i, j].txtbf)
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = (((output + Class1.pipeannulus(i, j).txtbf & " ") + Class1.pipeannulus(i, j).txtcf & " ") + Class1.pipeannulus(i, j).txtbr & " ") + Class1.pipeannulus(i, j).txtcr
            '                        'output = output + Class1.pipeannulus[i, j].txtbf;
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.pipeannulus(i, j + 1).txtbf <> Class1.pipeannulus(i, j).txtbf Or Class1.pipeannulus(i, j + 1).txtcf <> Class1.pipeannulus(i, j).txtcf Or Class1.pipeannulus(i, j + 1).txtbr <> Class1.pipeannulus(i, j).txtbr Or Class1.pipeannulus(i, j + 1).txtcr <> Class1.pipeannulus(i, j).txtcr) And first1 = True Then
            '                            'if (Class1.pipeannulus[i, j].txtbf != Class1.pipeannulus[i, j + 1].txtbf & first1 == true)
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If


            '                    End If
            '                Next

            '                If Class1.pipeannulus(i, 1).txtnv = "3" AndAlso (Class1.pipeannulus(i, 2).txtbf <> Class1.pipeannulus(i, 1).txtbf Or Class1.pipeannulus(i, 2).txtcf <> Class1.pipeannulus(i, 1).txtcf Or Class1.pipeannulus(i, 2).txtbr <> Class1.pipeannulus(i, 1).txtbr Or Class1.pipeannulus(i, 2).txtcr <> Class1.pipeannulus(i, 1).txtcr) Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.pipeannulus(i, 1).txtbf <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtbf Or Class1.pipeannulus(i, 1).txtcf <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtcf Or Class1.pipeannulus(i, 1).txtbr <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtbr Or Class1.pipeannulus(i, 1).txtcr <> Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtcr Then
            '                    ' if (Class1.pipeannulus[i, 1].txtbf != Class1.pipeannulus[i, Convert.ToInt32(Class1.pipeannulus[i, 1].txtnv)-1].txtbf)
            '                    output = (((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtbf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtcf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtbr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtcr & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                    'output = output + Class1.pipeannulus[i, Convert.ToInt32(Class1.pipeannulus[i, 1].txtnv)-1].txtbf + " " +(Convert.ToInt32(Class1.pipeannulus[i, 1].txtnv)-1).ToString ();
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = (((output + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtbf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtcf & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtbr & " ") + Class1.pipeannulus(i, Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).txtcr & " " & (Convert.ToInt32(Class1.pipeannulus(i, 1).txtnv) - 1).ToString()
            '                End If
            '                output = Class1.pipeannulus(i, 1).cmbhydroid + "3001 " & output
            '                generate.WriteLine(output)

            '                '***************************  
            '            End If
            '        End If
            '    Next


            '    ' annulus

            '    ' Copied from *******  PIPE code latest:

            '    ' &&&&&&&&&&&&&&&&&&&&&***********************&&&&&&&&&&&&&&&&&
            '    For i As Integer = 0 To 99
            '        If Class1.annulus(i, 1).gbname IsNot Nothing Then
            '            Class1.annulus(i, 1).cmbhydroid = Class1.annulus(i, 1).gbname.Substring(10, 3).ToString()
            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*         Component ANNULUS " + Class1.annulus(i, 1).cmbhydroid)
            '            generate.WriteLine("*======================================================================")

            '            output = Class1.annulus(i, 1).cmbhydroid + "0000 " + Class1.annulus(i, 1).txtname & " annulus"
            '            generate.WriteLine(output)
            '            output = Class1.annulus(i, 1).cmbhydroid + "0001 " + Class1.annulus(i, 1).txtnv
            '            generate.WriteLine(output)
            '            output = Nothing

            '            ' card X coordinate Volume Flow Area    101
            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = output + Class1.annulus(i, 1).txtvfa
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1


            '                If Class1.annulus(i, j - 1).txtvfa <> Class1.annulus(i, j).txtvfa Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.annulus(i, j).txtvfa
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.annulus(i, j).txtvfa <> Class1.annulus(i, j + 1).txtvfa And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            If Class1.annulus(i, 1).txtnv = "2" AndAlso Class1.annulus(i, 1).txtvfa <> Class1.annulus(i, 2).txtvfa Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.annulus(i, 1).txtvfa <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvfa Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvfa & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvfa & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            End If
            '            '
            '            '                        output = output + Class1.annulus[i, Convert.ToInt32(Class1.annulus[i, 1].txtnv)].txtvfa;
            '            '                        kl = Convert.ToInt32(Class1.annulus[i, 1].txtnv) - kk;
            '            '                        output = output + " " + kl.ToString();
            '            '
            '            '                        

            '            output = Class1.annulus(i, 1).cmbhydroid + "0101 " & output
            '            generate.WriteLine(output)
            '            first1 = True

            '            ''' junction flow area 
            '            If Convert.ToInt32(Class1.annulus(i, 1).txtnv) >= 2 Then

            '                kl = 0
            '                kk = 0
            '                output = Nothing
            '                output = Class1.annulus(i, 1).txtjfa
            '                ' 1 ";
            '                For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 2


            '                    If Class1.annulus(i, j - 1).txtjfa <> Class1.annulus(i, j).txtjfa Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = output + Class1.annulus(i, j).txtjfa
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If Class1.annulus(i, j).txtjfa <> Class1.annulus(i, j + 1).txtjfa And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                    End If
            '                Next
            '                If Class1.annulus(i, 1).txtnv = "3" AndAlso Class1.annulus(i, 1).txtjfa <> Class1.annulus(i, 2).txtjfa Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.annulus(i, 1).txtjfa <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtjfa Then
            '                    output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtjfa & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtjfa & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                End If
            '                output = Class1.annulus(i, 1).cmbhydroid + "0201 " & output
            '                generate.WriteLine(output)
            '            End If

            '            ' card X coordinate Volume Length

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.annulus(i, 1).txtvl
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1


            '                If Class1.annulus(i, j - 1).txtvl <> Class1.annulus(i, j).txtvl Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.annulus(i, j).txtvl
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.annulus(i, j).txtvl <> Class1.annulus(i, j + 1).txtvl And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                End If
            '            Next
            '            If Class1.annulus(i, 1).txtnv = "2" AndAlso Class1.annulus(i, 1).txtvl <> Class1.annulus(i, 2).txtvl Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.annulus(i, 1).txtvl <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvl Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvl & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvl & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            End If
            '            output = Class1.annulus(i, 1).cmbhydroid + "0301 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate Volume volume

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.annulus(i, 1).txtvv
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1


            '                If Class1.annulus(i, j - 1).txtvv <> Class1.annulus(i, j).txtvv Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.annulus(i, j).txtvv
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.annulus(i, j).txtvv <> Class1.annulus(i, j + 1).txtvv And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                End If
            '            Next
            '            If Class1.annulus(i, 1).txtnv = "2" AndAlso Class1.annulus(i, 1).txtvv <> Class1.annulus(i, 2).txtvv Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.annulus(i, 1).txtvv <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvv Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvv & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvv & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            End If
            '            output = Class1.annulus(i, 1).cmbhydroid + "0401 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate Volume azimuthal angle

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.annulus(i, 1).txtvaa
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1


            '                If Class1.annulus(i, j - 1).txtvaa <> Class1.annulus(i, j).txtvaa Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.annulus(i, j).txtvaa
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.annulus(i, j).txtvaa <> Class1.annulus(i, j + 1).txtvaa And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            If Class1.annulus(i, 1).txtnv = "2" AndAlso Class1.annulus(i, 1).txtvaa <> Class1.annulus(i, 2).txtvaa Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.annulus(i, 1).txtvaa <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvaa Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvaa & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvaa & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            End If
            '            output = Class1.annulus(i, 1).cmbhydroid + "0501 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate Volume vertical angle

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.annulus(i, 1).txtvva
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1


            '                If Class1.annulus(i, j - 1).txtvva <> Class1.annulus(i, j).txtvva Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.annulus(i, j).txtvva
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.annulus(i, j).txtvva <> Class1.annulus(i, j + 1).txtvva And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            If Class1.annulus(i, 1).txtnv = "2" AndAlso Class1.annulus(i, 1).txtvva <> Class1.annulus(i, 2).txtvva Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.annulus(i, 1).txtvva <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvva Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvva & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            End If
            '            ' output = output + Class1.annulus[i, Convert.ToInt32(Class1.annulus[i, 1].txtnv)].txtvva + " " + Class1.annulus[i, 1].txtnv.ToString();
            '            output = Class1.annulus(i, 1).cmbhydroid + "0601 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate Volume elevation change

            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.annulus(i, 1).txtvec
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1


            '                If Class1.annulus(i, j - 1).txtvec <> Class1.annulus(i, j).txtvec Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.annulus(i, j).txtvec
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.annulus(i, j).txtvec <> Class1.annulus(i, j + 1).txtvec And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            If Class1.annulus(i, 1).txtnv = "2" AndAlso Class1.annulus(i, 1).txtvec <> Class1.annulus(i, 2).txtvec Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.annulus(i, 1).txtvec <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvec Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvec & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvec & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            End If
            '            output = Class1.annulus(i, 1).cmbhydroid + "0701 " & output
            '            generate.WriteLine(output)

            '            ' card X coordinate wall roughness
            '            ' if (Class1.annulus[i, j - 1].txtvwr != Class1.annulus[i, j].txtvwr | Class1.annulus[i, j - 1].txtvhd != Class1.annulus[i, j].txtvhd )
            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = Class1.annulus(i, 1).txtvwr + " " + Class1.annulus(i, 1).txtvhd
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1


            '                If Class1.annulus(i, j - 1).txtvwr <> Class1.annulus(i, j).txtvwr Or Class1.annulus(i, j - 1).txtvhd <> Class1.annulus(i, j).txtvhd Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    ' output = output + Class1.annulus[i, j].txtvwr;
            '                    output = (output + Class1.annulus(i, j).txtvwr & " ") + Class1.annulus(i, j).txtvhd
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If (Class1.annulus(i, j + 1).txtvwr <> Class1.annulus(i, j).txtvwr Or Class1.annulus(i, j + 1).txtvhd <> Class1.annulus(i, j).txtvhd) And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If


            '                End If
            '            Next
            '            'if (Class1.annulus[i,  1].txtvwr != Class1.annulus[i, Convert.ToInt32(Class1.annulus[i, 1].txtnv)].txtvwr | Class1.annulus[i,  1].txtvhd != Class1.annulus[i, Convert.ToInt32(Class1.annulus[i, 1].txtnv)].txtvhd)
            '            If Class1.annulus(i, 1).txtnv = "2" AndAlso Class1.annulus(i, 1).txtvwr <> Class1.annulus(i, 2).txtvwr OrElse Class1.annulus(i, 1).txtvhd <> Class1.annulus(i, 2).txtvhd Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.annulus(i, 1).txtvwr <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvwr Or Class1.annulus(i, 1).txtvhd <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvhd Then
            '                output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvwr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvhd & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvwr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvhd & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            End If

            '            output = Class1.annulus(i, 1).cmbhydroid + "0801 " & output
            '            generate.WriteLine(output)

            '            first1 = True
            '            ' juction loss coeffient
            '            If Convert.ToInt32(Class1.annulus(i, 1).txtnv) >= 2 Then

            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = Class1.annulus(i, 1).txtjaf + " " + Class1.annulus(i, 1).txtjar
            '                ' 1 ";
            '                For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 2


            '                    If Class1.annulus(i, j - 1).txtjaf <> Class1.annulus(i, j).txtjaf Or Class1.annulus(i, j - 1).txtjar <> Class1.annulus(i, j).txtjar Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = (output + Class1.annulus(i, j).txtjaf & " ") + Class1.annulus(i, j).txtjar
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.annulus(i, j).txtjaf <> Class1.annulus(i, j + 1).txtjaf Or Class1.annulus(i, j).txtjar <> Class1.annulus(i, j + 1).txtjar) And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If

            '                    End If
            '                Next
            '                If Class1.annulus(i, 1).txtnv = "3" AndAlso Class1.annulus(i, 1).txtjaf <> Class1.annulus(i, 2).txtjaf OrElse Class1.annulus(i, 1).txtjar <> Class1.annulus(i, 2).txtjar Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.annulus(i, 1).txtjaf <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtjaf Or Class1.annulus(i, 1).txtjar <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtjar Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtjaf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtjaf & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtjaf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtjaf & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                End If

            '                output = Class1.annulus(i, 1).cmbhydroid + "0901 " & output
            '                generate.WriteLine(output)
            '            End If


            '            ' x-coordinate controol cards cards ccc1001-ccc1099




            '            kk = 0
            '            kl = 0
            '            first1 = True
            '            output = Nothing
            '            If Class1.annulus(i, 1).cbtftm = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.annulus(i, 1).cbcbmltm = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.annulus(i, 1).cbwps = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If
            '            If Class1.annulus(i, 1).cbvsmnew = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.annulus(i, 1).cmbifnew = "0" Then
            '                output = output & "0"
            '            ElseIf Class1.annulus(i, 1).cmbifnew = "1" Then
            '                output = output & "1"
            '            End If

            '            If Class1.annulus(i, 1).cbwf = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.annulus(i, 1).cbneqb = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1
            '                If Class1.annulus(i, j - 1).cbtftm <> Class1.annulus(i, j).cbtftm Or Class1.annulus(i, j - 1).cbcbmltm <> Class1.annulus(i, j).cbcbmltm Or Class1.annulus(i, j - 1).cbwps <> Class1.annulus(i, j).cbwps Or Class1.annulus(i, j - 1).cbvsmnew <> Class1.annulus(i, j).cbvsmnew Or Class1.annulus(i, j - 1).cmbifnew <> Class1.annulus(i, j).cmbifnew Or Class1.annulus(i, j - 1).cbwf <> Class1.annulus(i, j).cbwf Or Class1.annulus(i, j - 1).cbneqb <> Class1.annulus(i, j).cbneqb Then

            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If

            '                    'output = output + Class1.annulus[i, j].txtjaf + " " + Class1.annulus[i, j].txtjar;

            '                    If Class1.annulus(i, j).cbtftm = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.annulus(i, j).cbcbmltm = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.annulus(i, j).cbwps = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If
            '                    If Class1.annulus(i, j).cbvsmnew = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If
            '                    If Class1.annulus(i, j).cmbifnew = "0" Then
            '                        output = output & "0"
            '                    ElseIf Class1.annulus(i, j).cmbifnew = "1" Then
            '                        output = output & "1"
            '                    End If

            '                    If Class1.annulus(i, j).cbwf = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.annulus(i, j).cbneqb = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If (Class1.annulus(i, j + 1).cbtftm <> Class1.annulus(i, j).cbtftm Or Class1.annulus(i, j + 1).cbcbmltm <> Class1.annulus(i, j).cbcbmltm Or Class1.annulus(i, j + 1).cbwps <> Class1.annulus(i, j).cbwps Or Class1.annulus(i, j + 1).cbvsmnew <> Class1.annulus(i, j).cbvsmnew Or Class1.annulus(i, j + 1).cmbifnew <> Class1.annulus(i, j).cmbifnew Or Class1.annulus(i, j + 1).cbwf <> Class1.annulus(i, j).cbwf Or Class1.annulus(i, j + 1).cbneqb <> Class1.annulus(i, j).cbneqb) And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If



            '                End If
            '            Next
            '            If Class1.annulus(i, 1).txtnv = "2" AndAlso (Class1.annulus(i, 1).cbtftm <> Class1.annulus(i, 2).cbtftm Or Class1.annulus(i, 1).cbcbmltm <> Class1.annulus(i, 2).cbcbmltm Or Class1.annulus(i, 1).cbwps <> Class1.annulus(i, 2).cbwps Or Class1.annulus(i, 1).cbvsmnew <> Class1.annulus(i, 2).cbvsmnew Or Class1.annulus(i, 1).cmbifnew <> Class1.annulus(i, 2).cmbifnew Or Class1.annulus(i, 1).cbwf <> Class1.annulus(i, 2).cbwf Or Class1.annulus(i, 1).cbneqb <> Class1.annulus(i, 2).cbneqb) Then
            '                output = output & " 1 "
            '            End If


            '            If Class1.annulus(i, 1).cbtftm <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbtftm Or Class1.annulus(i, 1).cbcbmltm <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbcbmltm Or Class1.annulus(i, 1).cbwps <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbwps Or Class1.annulus(i, 1).cbvsmnew <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbvsmnew Or Class1.annulus(i, 1).cmbifnew <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbifnew Or Class1.annulus(i, 1).cbwf <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbwf Or Class1.annulus(i, 1).cbneqb <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbneqb Then
            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbtftm = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbcbmltm = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbwps = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbvsmnew = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbifnew = "0" Then
            '                    output = output & "0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbifnew = "1" Then
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbwf = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbneqb = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()


            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbtftm = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbcbmltm = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbwps = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbvsmnew = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbifnew = "0" Then
            '                    output = output & "0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbifnew = "1" Then
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbwf = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbneqb = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            End If

            '            output = Class1.annulus(i, 1).cmbhydroid + "1001 " & output
            '            generate.WriteLine(output)

            '            ' juction control flages @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            '            If Convert.ToInt32(Class1.annulus(i, 1).txtnv) >= 2 Then
            '                kk = 0
            '                kl = 0
            '                output = Nothing
            '                first1 = True

            '                If Class1.annulus(i, 1).cbmodpv = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, 1).cbccfl = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, 1).cbhse = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.annulus(i, 1).cbchoking = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                output = output + Class1.annulus(i, 1).cmbareachange

            '                If Class1.annulus(i, 1).cbhomo = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "2"
            '                End If
            '                output = output + Class1.annulus(i, 1).cmbmf

            '                For j As Integer = 2 To (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1) - 1
            '                    If Class1.annulus(i, j - 1).cbmodpv <> Class1.annulus(i, j).cbmodpv Or Class1.annulus(i, j - 1).cbccfl <> Class1.annulus(i, j).cbccfl Or Class1.annulus(i, j - 1).cbchoking <> Class1.annulus(i, j).cbchoking Or Class1.annulus(i, j - 1).cmbareachange <> Class1.annulus(i, j).cmbareachange Or Class1.annulus(i, j - 1).cbhomo <> Class1.annulus(i, j).cbhomo Or Class1.annulus(i, j - 1).cmbmf <> Class1.annulus(i, j).cmbmf Or Class1.annulus(i, j - 1).cbvsmnew <> Class1.annulus(i, j).cbvsmnew Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        'output = output + Class1.annulus[i, j].txtjaf + " " + Class1.annulus[i, j].txtjar;
            '                        If Class1.annulus(i, j).cbmodpv = "False" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "1"
            '                        End If

            '                        If Class1.annulus(i, j).cbccfl = "False" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "1"
            '                        End If

            '                        If Class1.annulus(i, j).cbhse = "False" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "1"
            '                        End If

            '                        If Class1.annulus(i, j).cbchoking = "True" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "1"
            '                        End If
            '                        output = output + Class1.annulus(i, j).cmbareachange

            '                        If Class1.annulus(i, j).cbhomo = "False" Then
            '                            output = output & "0"
            '                        Else
            '                            output = output & "2"
            '                        End If
            '                        output = output + Class1.annulus(i, j).cmbmf


            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.annulus(i, j + 1).cbmodpv <> Class1.annulus(i, j).cbmodpv Or Class1.annulus(i, j + 1).cbccfl <> Class1.annulus(i, j).cbccfl Or Class1.annulus(i, j + 1).cbchoking <> Class1.annulus(i, j).cbchoking Or Class1.annulus(i, j + 1).cmbareachange <> Class1.annulus(i, j).cmbareachange Or Class1.annulus(i, j + 1).cbhomo <> Class1.annulus(i, j).cbhomo Or Class1.annulus(i, j + 1).cmbmf <> Class1.annulus(i, j).cmbmf Or Class1.annulus(i, j + 1).cbhse <> Class1.annulus(i, j).cbhse) And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If

            '                    End If
            '                Next

            '                If Class1.annulus(i, 1).txtnv = "3" AndAlso (Class1.annulus(i, 2).cbmodpv <> Class1.annulus(i, 1).cbmodpv Or Class1.annulus(i, 2).cbccfl <> Class1.annulus(i, 1).cbccfl Or Class1.annulus(i, 2).cbchoking <> Class1.annulus(i, 1).cbchoking Or Class1.annulus(i, 2).cmbareachange <> Class1.annulus(i, 1).cmbareachange Or Class1.annulus(i, 2).cbhomo <> Class1.annulus(i, 1).cbhomo Or Class1.annulus(i, 2).cmbmf <> Class1.annulus(i, 1).cmbmf Or Class1.annulus(i, 2).cbhse <> Class1.annulus(i, 1).cbhse) Then
            '                    output = output & " 1 "
            '                End If


            '                If Class1.annulus(i, 1).cbmodpv <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbmodpv Or Class1.annulus(i, 1).cbccfl <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbccfl Or Class1.annulus(i, 1).cbchoking <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbchoking Or Class1.annulus(i, 1).cmbareachange <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cmbareachange Or Class1.annulus(i, 1).cbhomo <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbhomo Or Class1.annulus(i, 1).cmbmf <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cmbmf Or Class1.annulus(i, 1).cbhse <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbhse Then
            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbmodpv = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbccfl = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbhse = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If


            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbchoking = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cmbareachange

            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbhomo = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "2"
            '                    End If

            '                    output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cmbmf
            '                    output = output & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbmodpv = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbccfl = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbhse = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbchoking = "True" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cmbareachange

            '                    If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cbhomo = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "2"
            '                    End If

            '                    output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).cmbmf

            '                    output = output & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                End If
            '                output = Class1.annulus(i, 1).cmbhydroid + "1101 " & output
            '                generate.WriteLine(output)
            '            End If

            '            ' initial conditions ******************************************************************
            '            kk = 0
            '            kl = 0
            '            output = Nothing
            '            first1 = True

            '            output = Class1.annulus(i, 1).cmbfluid

            '            If Class1.annulus(i, 1).cbboron = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            output = output + Class1.annulus(i, 1).cmbithstate & " "

            '            If Class1.annulus(i, 1).cmbithstate = "0" Then
            '                output = (((output + Class1.annulus(i, 1).txtpr & " ") + Class1.annulus(i, 1).txtlsie & " ") + Class1.annulus(i, 1).txtvsie & " ") + Class1.annulus(i, 1).txtvvf & " " & "0.0"
            '            ElseIf Class1.annulus(i, 1).cmbithstate = "1" Then
            '                output = (output + Class1.annulus(i, 1).txtt & " ") + Class1.annulus(i, 1).txtsqeq & " 0.0" & " 0.0" & " 0.0"

            '            ElseIf Class1.annulus(i, 1).cmbithstate = "2" Then
            '                output = (output + Class1.annulus(i, 1).txtpr & " ") + Class1.annulus(i, 1).txtsqeq & " 0.0" & " 0.0" & " 0.0"


            '            ElseIf Class1.annulus(i, 1).cmbithstate = "3" Then
            '                output = (output + Class1.annulus(i, 1).txtpr & " ") + Class1.annulus(i, 1).txtt & " 0.0" & " 0.0" & " 0.0"
            '            ElseIf Class1.annulus(i, 1).cmbithstate = "4" Then

            '                output = ((output + Class1.annulus(i, 1).txtpr & " ") + Class1.annulus(i, 1).txtt & " ") + Class1.annulus(i, 1).txtsqeq & " 0.0" & " 0.0"
            '            ElseIf Class1.annulus(i, 1).cmbithstate = "5" Then
            '                output = ((output + Class1.annulus(i, 1).txtt & " ") + Class1.annulus(i, 1).txtsq & " ") + Class1.annulus(i, 1).txtncqeq & " 0.0" & " 0.0"
            '            ElseIf Class1.annulus(i, 1).cmbithstate = "6" Then
            '                output = ((((output + Class1.annulus(i, 1).txtpr & " ") + Class1.annulus(i, 1).txtlsie & " ") + Class1.annulus(i, 1).txtvsie & " ") + Class1.annulus(i, 1).txtvvf & " ") + Class1.annulus(i, 1).txtncq
            '            End If

            '            ' /000000000000000000000000000000000000000000000

            '            For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1
            '                If Class1.annulus(i, j - 1).cmbfluid <> Class1.annulus(i, j).cmbfluid Or Class1.annulus(i, j - 1).cbboron <> Class1.annulus(i, j).cbboron Or Class1.annulus(i, j - 1).cmbithstate <> Class1.annulus(i, j).cmbithstate Or Class1.annulus(i, j - 1).cmbithstate <> Class1.annulus(i, j).cmbithstate Or Class1.annulus(i, j - 1).txtt <> Class1.annulus(i, j).txtt Or Class1.annulus(i, j - 1).txtpr <> Class1.annulus(i, j).txtpr Or Class1.annulus(i, j - 1).txtvsie <> Class1.annulus(i, j).txtvsie Or Class1.annulus(i, j - 1).txtlsie <> Class1.annulus(i, j).txtlsie Or Class1.annulus(i, j - 1).txtvvf <> Class1.annulus(i, j).txtvvf Or Class1.annulus(i, j - 1).txtsqeq <> Class1.annulus(i, j).txtsqeq Or Class1.annulus(i, j - 1).txtncqeq <> Class1.annulus(i, j).txtncqeq Or Class1.annulus(i, j - 1).txtsq <> Class1.annulus(i, j).txtsq Or Class1.annulus(i, j - 1).txtqeq <> Class1.annulus(i, j).txtqeq Or Class1.annulus(i, j - 1).txtncq <> Class1.annulus(i, j).txtncq Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = output + Class1.annulus(i, j).cmbfluid

            '                    If Class1.annulus(i, j).cbboron = "False" Then
            '                        output = output & "0"
            '                    Else
            '                        output = output & "1"
            '                    End If

            '                    output = output + Class1.annulus(i, j).cmbithstate & " "

            '                    If Class1.annulus(i, j).cmbithstate = "0" Then
            '                        output = (((output + Class1.annulus(i, j).txtpr & " ") + Class1.annulus(i, j).txtlsie & " ") + Class1.annulus(i, j).txtvsie & " ") + Class1.annulus(i, j).txtvvf & " " & "0.0"
            '                    ElseIf Class1.annulus(i, j).cmbithstate = "1" Then
            '                        output = (output + Class1.annulus(i, j).txtt & " ") + Class1.annulus(i, j).txtsqeq & " 0.0" & " 0.0" & " 0.0"

            '                    ElseIf Class1.annulus(i, j).cmbithstate = "2" Then
            '                        output = (output + Class1.annulus(i, j).txtpr & " ") + Class1.annulus(i, j).txtsqeq & " 0.0" & " 0.0" & " 0.0"


            '                    ElseIf Class1.annulus(i, j).cmbithstate = "3" Then
            '                        output = (output + Class1.annulus(i, j).txtpr & " ") + Class1.annulus(i, j).txtt & " 0.0" & " 0.0" & " 0.0"
            '                    ElseIf Class1.annulus(i, j).cmbithstate = "4" Then

            '                        output = ((output + Class1.annulus(i, j).txtpr & " ") + Class1.annulus(i, j).txtt & " ") + Class1.annulus(i, j).txtsqeq & " 0.0" & " 0.0"
            '                    ElseIf Class1.annulus(i, j).cmbithstate = "5" Then
            '                        output = ((output + Class1.annulus(i, j).txtt & " ") + Class1.annulus(i, j).txtsq & " ") + Class1.annulus(i, j).txtncqeq & " 0.0" & " 0.0"
            '                    ElseIf Class1.annulus(i, j).cmbithstate = "6" Then
            '                        output = ((((output + Class1.annulus(i, j).txtpr & " ") + Class1.annulus(i, j).txtlsie & " ") + Class1.annulus(i, j).txtvsie & " ") + Class1.annulus(i, j).txtvvf & " ") + Class1.annulus(i, j).txtncq
            '                    End If
            '                    kl = j
            '                    ' -kk;
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else

            '                    If (Class1.annulus(i, j + 1).cmbfluid <> Class1.annulus(i, j).cmbfluid Or Class1.annulus(i, j + 1).cbboron <> Class1.annulus(i, j).cbboron Or Class1.annulus(i, j + 1).cmbithstate <> Class1.annulus(i, j).cmbithstate Or Class1.annulus(i, j + 1).cmbithstate <> Class1.annulus(i, j).cmbithstate Or Class1.annulus(i, j + 1).txtt <> Class1.annulus(i, j).txtt Or Class1.annulus(i, j + 1).txtpr <> Class1.annulus(i, j).txtpr Or Class1.annulus(i, j + 1).txtvsie <> Class1.annulus(i, j).txtvsie Or Class1.annulus(i, j + 1).txtlsie <> Class1.annulus(i, j).txtlsie Or Class1.annulus(i, j + 1).txtvvf <> Class1.annulus(i, j).txtvvf Or Class1.annulus(i, j + 1).txtsqeq <> Class1.annulus(i, j).txtsqeq Or Class1.annulus(i, j + 1).txtncqeq <> Class1.annulus(i, j).txtncqeq Or Class1.annulus(i, j + 1).txtsq <> Class1.annulus(i, j).txtsq Or Class1.annulus(i, j + 1).txtqeq <> Class1.annulus(i, j).txtqeq Or Class1.annulus(i, j + 1).txtncq <> Class1.annulus(i, j).txtncq) And first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                End If
            '            Next
            '            If Class1.annulus(i, 1).txtnv = "2" AndAlso (Class1.annulus(i, 1).cmbfluid <> Class1.annulus(i, 2).cmbfluid Or Class1.annulus(i, 1).cbboron <> Class1.annulus(i, 2).cbboron Or Class1.annulus(i, 1).cmbithstate <> Class1.annulus(i, 2).cmbithstate Or Class1.annulus(i, 1).cmbithstate <> Class1.annulus(i, 2).cmbithstate Or Class1.annulus(i, 1).txtt <> Class1.annulus(i, 2).txtt Or Class1.annulus(i, 1).txtpr <> Class1.annulus(i, 2).txtpr Or Class1.annulus(i, 1).txtvsie <> Class1.annulus(i, 2).txtvsie Or Class1.annulus(i, 1).txtlsie <> Class1.annulus(i, 2).txtlsie Or Class1.annulus(i, 1).txtvvf <> Class1.annulus(i, 2).txtvvf Or Class1.annulus(i, 1).txtsqeq <> Class1.annulus(i, 2).txtsqeq Or Class1.annulus(i, 1).txtncqeq <> Class1.annulus(i, 2).txtncqeq Or Class1.annulus(i, 1).txtsq <> Class1.annulus(i, 2).txtsq Or Class1.annulus(i, 1).txtqeq <> Class1.annulus(i, 2).txtqeq Or Class1.annulus(i, 1).txtncq <> Class1.annulus(i, 2).txtncq) Then
            '                output = output & " 1 "
            '            End If

            '            '''/////////////////////////   
            '            If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbfluid <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbfluid Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbboron <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbboron Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvsie <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvsie Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtlsie <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtlsie Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvvf <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvvf Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsqeq <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsqeq Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtncqeq <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtncqeq Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsq <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsq Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtqeq <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtqeq Or Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtncq <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtncq Then

            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbfluid

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbboron = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate & " "

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "0" Then
            '                    output = (((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtlsie & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvsie & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvvf & " " & "0.0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "1" Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0" & " 0.0"

            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "2" Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0" & " 0.0"


            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "3" Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt & " 0.0" & " 0.0" & " 0.0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "4" Then

            '                    output = ((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "5" Then
            '                    output = ((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsq & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtncqeq & " 0.0" & " 0.0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "6" Then
            '                    output = ((((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtlsie & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvsie & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvvf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtncq
            '                End If

            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()


            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            ElseIf first1 = False Then
            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbfluid

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cbboron = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                output = output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate & " "

            '                If Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "0" Then
            '                    output = (((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtlsie & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvsie & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvvf & " " & "0.0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "1" Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0" & " 0.0"

            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "2" Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0" & " 0.0"


            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "3" Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt & " 0.0" & " 0.0" & " 0.0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "4" Then

            '                    output = ((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsqeq & " 0.0" & " 0.0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "5" Then
            '                    output = ((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtt & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtsq & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtncqeq & " 0.0" & " 0.0"
            '                ElseIf Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).cmbithstate = "6" Then
            '                    output = ((((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtpr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtlsie & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvsie & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtvvf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv)).txtncq
            '                End If


            '                output = output & " " & Class1.annulus(i, 1).txtnv.ToString()
            '            End If


            '            output = Class1.annulus(i, 1).cmbhydroid + "1201 " & output
            '            generate.WriteLine(output)


            '            '  boron concentration  card ccc 2001 ccc2099

            '            ' juction loss coeffient  1301  1399
            '            If Convert.ToInt32(Class1.annulus(i, 1).txtnv) >= 2 Then
            '                generate.WriteLine(Class1.annulus(i, 1).cmbhydroid + "1300 " + Class1.annulus(i, 1).cmbvelmfr)

            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = Class1.annulus(i, 1).txtliq + " " + Class1.annulus(i, 1).txtvap & " 0.0"
            '                ' 1 ";
            '                For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 2
            '                    If Class1.annulus(i, j - 1).txtliq <> Class1.annulus(i, j).txtliq Or Class1.annulus(i, j - 1).txtvap <> Class1.annulus(i, j).txtvap Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = (output + Class1.annulus(i, j).txtliq & " ") + Class1.annulus(i, j).txtvap & " 0.0"
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.annulus(i, j + 1).txtliq <> Class1.annulus(i, j).txtliq Or Class1.annulus(i, j + 1).txtvap <> Class1.annulus(i, j).txtvap) And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If

            '                    End If
            '                Next

            '                If Class1.annulus(i, 1).txtnv = "3" AndAlso (Class1.annulus(i, 2).txtliq <> Class1.annulus(i, 1).txtliq Or Class1.annulus(i, 2).txtvap <> Class1.annulus(i, 1).txtvap) Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.annulus(i, 1).txtliq <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtliq Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtliq & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtvap & " 0.0" & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = (output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtliq & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtvap & " 0.0" & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                End If

            '                output = Class1.annulus(i, 1).cmbhydroid + "1301 " & output
            '                generate.WriteLine(output)

            '                ' juction diameter and ccfl  1401 1499


            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = ((Class1.annulus(i, 1).txtdj + " " + Class1.annulus(i, 1).txtfcf & " ") + Class1.annulus(i, 1).txtgi & " ") + Class1.annulus(i, 1).txtslope
            '                For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 2
            '                    If Class1.annulus(i, j - 1).txtdj <> Class1.annulus(i, j).txtdj Or Class1.annulus(i, j - 1).txtfcf <> Class1.annulus(i, j).txtfcf Or Class1.annulus(i, j - 1).txtgi <> Class1.annulus(i, j).txtgi Or Class1.annulus(i, j - 1).txtslope <> Class1.annulus(i, j).txtslope Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = (((output + Class1.annulus(i, j).txtdj & " ") + Class1.annulus(i, j).txtfcf & " ") + Class1.annulus(i, j).txtgi & " ") + Class1.annulus(i, j).txtslope
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.annulus(i, j + 1).txtdj <> Class1.annulus(i, j).txtdj Or Class1.annulus(i, j + 1).txtfcf <> Class1.annulus(i, j).txtfcf Or Class1.annulus(i, j + 1).txtgi <> Class1.annulus(i, j).txtgi Or Class1.annulus(i, j + 1).txtslope <> Class1.annulus(i, j).txtslope) And first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If

            '                    End If
            '                Next

            '                If Class1.annulus(i, 1).txtnv = "3" AndAlso (Class1.annulus(i, 1).txtdj <> Class1.annulus(i, 2).txtdj Or Class1.annulus(i, 1).txtfcf <> Class1.annulus(i, 2).txtfcf Or Class1.annulus(i, 1).txtgi <> Class1.annulus(i, 2).txtgi Or Class1.annulus(i, 1).txtslope <> Class1.annulus(i, 2).txtslope) Then
            '                    output = output & " 1 "
            '                End If


            '                If Class1.annulus(i, 1).txtdj <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtdj Or Class1.annulus(i, 1).txtfcf <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtfcf Or Class1.annulus(i, 1).txtgi <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtgi Or Class1.annulus(i, 1).txtslope <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtslope Then
            '                    'if (Class1.annulus[i, 1].txtdj != Class1.annulus[i, Convert.ToInt32(Class1.annulus[i, 1].txtnv)-1].txtdj)
            '                    output = (((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtdj & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtfcf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtgi & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtslope & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = (((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtdj & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtfcf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtgi & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtslope & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                End If

            '                output = Class1.annulus(i, 1).cmbhydroid + "1401 " & output
            '                generate.WriteLine(output)

            '                ' juction form loss data 3001 3099


            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = ((Class1.annulus(i, 1).txtbf + " " + Class1.annulus(i, 1).txtcf & " ") + Class1.annulus(i, 1).txtbr & " ") + Class1.annulus(i, 1).txtcr
            '                For j As Integer = 2 To Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 2
            '                    If Class1.annulus(i, j - 1).txtbf <> Class1.annulus(i, j).txtbf Or Class1.annulus(i, j - 1).txtcf <> Class1.annulus(i, j).txtcf Or Class1.annulus(i, j - 1).txtbr <> Class1.annulus(i, j).txtbr Or Class1.annulus(i, j - 1).txtcr <> Class1.annulus(i, j).txtcr Then
            '                        'if (Class1.annulus[i, j - 1].txtbf != Class1.annulus[i, j].txtbf)
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = (((output + Class1.annulus(i, j).txtbf & " ") + Class1.annulus(i, j).txtcf & " ") + Class1.annulus(i, j).txtbr & " ") + Class1.annulus(i, j).txtcr
            '                        'output = output + Class1.annulus[i, j].txtbf;
            '                        kl = j
            '                        ' -kk;
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If (Class1.annulus(i, j + 1).txtbf <> Class1.annulus(i, j).txtbf Or Class1.annulus(i, j + 1).txtcf <> Class1.annulus(i, j).txtcf Or Class1.annulus(i, j + 1).txtbr <> Class1.annulus(i, j).txtbr Or Class1.annulus(i, j + 1).txtcr <> Class1.annulus(i, j).txtcr) And first1 = True Then
            '                            'if (Class1.annulus[i, j].txtbf != Class1.annulus[i, j + 1].txtbf & first1 == true)
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If


            '                    End If
            '                Next

            '                If Class1.annulus(i, 1).txtnv = "3" AndAlso (Class1.annulus(i, 2).txtbf <> Class1.annulus(i, 1).txtbf Or Class1.annulus(i, 2).txtcf <> Class1.annulus(i, 1).txtcf Or Class1.annulus(i, 2).txtbr <> Class1.annulus(i, 1).txtbr Or Class1.annulus(i, 2).txtcr <> Class1.annulus(i, 1).txtcr) Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.annulus(i, 1).txtbf <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtbf Or Class1.annulus(i, 1).txtcf <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtcf Or Class1.annulus(i, 1).txtbr <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtbr Or Class1.annulus(i, 1).txtcr <> Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtcr Then
            '                    ' if (Class1.annulus[i, 1].txtbf != Class1.annulus[i, Convert.ToInt32(Class1.annulus[i, 1].txtnv)-1].txtbf)
            '                    output = (((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtbf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtcf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtbr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtcr & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                    'output = output + Class1.annulus[i, Convert.ToInt32(Class1.annulus[i, 1].txtnv)-1].txtbf + " " +(Convert.ToInt32(Class1.annulus[i, 1].txtnv)-1).ToString ();
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = (((output + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtbf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtcf & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtbr & " ") + Class1.annulus(i, Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).txtcr & " " & (Convert.ToInt32(Class1.annulus(i, 1).txtnv) - 1).ToString()
            '                End If
            '                output = Class1.annulus(i, 1).cmbhydroid + "3001 " & output
            '                generate.WriteLine(output)

            '                '***************************  
            '            End If
            '        End If
            '    Next






            '    ' valve

            '    For i As Integer = 0 To 99
            '        If Class1.valve(i).gbname IsNot Nothing Then
            '            Class1.valve(i).cmbhydroid = Class1.valve(i).gbname.Substring(10, 3).ToString()
            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*         Component Valve " + Class1.valve(i).cmbhydroid)
            '            generate.WriteLine("*======================================================================")


            '            output = Class1.valve(i).cmbhydroid + "0000 " + Class1.valve(i).txtname & " valve"
            '            generate.WriteLine(output)
            '            output = Class1.valve(i).cmbhydroid + "0101 " + Class1.valve(i).txtfromid



            '            If Convert.ToInt32(Class1.valve(i).txtfromnv) <= 9 Then
            '                Class1.valve(i).txtfromnv = "0" & Convert.ToInt32(Class1.valve(i).txtfromnv).ToString()
            '            ElseIf Convert.ToInt32(Class1.valve(i).txtfromnv) > 9 Then
            '                Class1.valve(i).txtfromnv = Convert.ToInt32(Class1.valve(i).txtfromnv).ToString()
            '            End If


            '            If Convert.ToBoolean(Class1.valve(i).cbformatfrom) = False Then
            '                output = (output & "0") + Class1.valve(i).cmbconsidefrom & "0000" & " "
            '            Else
            '                If Class1.valve(i).cmbconsidefrom = "0" AndAlso Class1.valve(i).cmbconfacexfrom = "0" Then
            '                    output = output + Class1.valve(i).txtfromnv & "0001" & " "
            '                ElseIf Class1.valve(i).cmbconsidefrom = "1" AndAlso Class1.valve(i).cmbconfacexfrom = "0" Then
            '                    output = output + Class1.valve(i).txtfromnv & "0002" & " "
            '                ElseIf Class1.valve(i).cmbconsidefrom = "0" AndAlso Class1.valve(i).cmbconfacexfrom = "1" Then
            '                    output = output + Class1.valve(i).txtfromnv & "0003" & " "
            '                ElseIf Class1.valve(i).cmbconsidefrom = "1" AndAlso Class1.valve(i).cmbconfacexfrom = "1" Then
            '                    output = output + Class1.valve(i).txtfromnv & "0004" & " "
            '                ElseIf Class1.valve(i).cmbconsidefrom = "0" AndAlso Class1.valve(i).cmbconfacexfrom = "2" Then
            '                    output = output + Class1.valve(i).txtfromnv & "0005" & " "
            '                ElseIf Class1.valve(i).cmbconsidefrom = "1" AndAlso Class1.valve(i).cmbconfacexfrom = "2" Then
            '                    output = output + Class1.valve(i).txtfromnv & "0006" & " "
            '                End If
            '            End If

            '            output = output + Class1.valve(i).txttoid

            '            If Convert.ToInt32(Class1.valve(i).txttonv) <= 9 Then
            '                Class1.valve(i).txttonv = "0" & Convert.ToInt32(Class1.valve(i).txttonv).ToString()
            '            ElseIf Convert.ToInt32(Class1.valve(i).txttonv) > 9 Then
            '                Class1.valve(i).txttonv = Convert.ToInt32(Class1.valve(i).txttonv).ToString()
            '            End If

            '            If Convert.ToBoolean(Class1.valve(i).cbformatto) = False Then
            '                output = (output & "0") + Class1.valve(i).cmbconsideto & "0000" & " "
            '            Else
            '                If Class1.valve(i).cmbconsideto = "0" AndAlso Class1.valve(i).cmbconfacexto = "0" Then
            '                    output = output + Class1.valve(i).txttonv & "0001" & " "
            '                ElseIf Class1.valve(i).cmbconsideto = "1" AndAlso Class1.valve(i).cmbconfacexto = "0" Then
            '                    output = output + Class1.valve(i).txttonv & "0002" & " "
            '                ElseIf Class1.valve(i).cmbconsideto = "0" AndAlso Class1.valve(i).cmbconfacexto = "1" Then
            '                    output = output + Class1.valve(i).txttonv & "0003" & " "
            '                ElseIf Class1.valve(i).cmbconsideto = "1" AndAlso Class1.valve(i).cmbconfacexto = "1" Then
            '                    output = output + Class1.valve(i).txttonv & "0004" & " "
            '                ElseIf Class1.valve(i).cmbconsideto = "0" AndAlso Class1.valve(i).cmbconfacexto = "2" Then
            '                    output = output + Class1.valve(i).txttonv & "0005" & " "
            '                ElseIf Class1.valve(i).cmbconsideto = "1" AndAlso Class1.valve(i).cmbconfacexto = "2" Then
            '                    output = output + Class1.valve(i).txttonv & "0006" & " "
            '                End If
            '            End If


            '            output = ((output + Class1.valve(i).txtjarea & " ") + Class1.valve(i).txtffelc & " ") + Class1.valve(i).txtrfelc & " "

            '            If Class1.valve(i).cbmodpv = "True" Then
            '                output = output & "1"
            '            Else
            '                output = output & "0"
            '            End If

            '            If Class1.valve(i).cbccfl = "True" Then
            '                output = output & "1"
            '            Else
            '                output = output & "0"
            '            End If

            '            output = output + Class1.valve(i).cmbhorstrat

            '            If Class1.valve(i).cbchoking = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If
            '            output = output + Class1.valve(i).cmbareachange

            '            If Class1.valve(i).cbhomo = "True" Then
            '                output = output & "1"
            '            Else
            '                output = output & "0"
            '            End If
            '            output = output + Class1.valve(i).cmbmf
            '            output = (((output & " ") + Class1.valve(i).txtsubdc & " ") + Class1.valve(i).txttpdc & " ") + Class1.valve(i).txtshdc
            '            generate.WriteLine(output)
            '            ' card ccc0110 junction dia and ccfl
            '            output = (((Class1.valve(i).cmbhydroid + "0110 " + Class1.valve(i).txtdj & " ") + Class1.valve(i).txtfcf & " ") + Class1.valve(i).txtgi & " ") + Class1.valve(i).txtslope
            '            generate.WriteLine(output)

            '            ' card ccc0111 valve j form loss data
            '            output = (((Class1.valve(i).cmbhydroid + "0111 " + Class1.valve(i).txtbf & " ") + Class1.valve(i).txtcf & " ") + Class1.valve(i).txtbr & " ") + Class1.valve(i).txtcr
            '            generate.WriteLine(output)
            '            ' card ccc0201, valve initial condition
            '            output = (((Class1.valve(i).cmbhydroid + "0201 " + Class1.valve(i).cmbvelmfr & " ") + Class1.valve(i).txtliq & " ") + Class1.valve(i).txtvap & " ") + Class1.valve(i).txtint
            '            generate.WriteLine(output)

            '            ' card ccc 0300 valive type

            '            output = Class1.valve(i).cmbhydroid + "0300 "

            '            If Class1.valve(i).cmbvtype = "0" Then
            '                output = output & "chkvlv"
            '            ElseIf Class1.valve(i).cmbvtype = "1" Then
            '                output = output & "trpvlv"
            '            ElseIf Class1.valve(i).cmbvtype = "2" Then
            '                output = output & "inrvlv"
            '            ElseIf Class1.valve(i).cmbvtype = "3" Then
            '                output = output & "mtrvlv"
            '            ElseIf Class1.valve(i).cmbvtype = "4" Then
            '                output = output & "srvvlv"
            '            ElseIf Class1.valve(i).cmbvtype = "5" Then
            '                output = output & "rlfvlv"
            '            End If

            '            generate.WriteLine(output)
            '            ' ccc0301 vlve data and initial condition

            '            If Class1.valve(i).cmbvtype = "0" Then
            '                output = Class1.valve(i).cmbhydroid + "0301 "
            '                If Class1.valve(i).cmbchkvlvtype = "2" Then
            '                    output = output & "-1"
            '                Else
            '                    output = output + Class1.valve(i).cmbchkvlvtype
            '                End If
            '                output = (((output & " ") + Class1.valve(i).cmbchkvlvip & " ") + Class1.valve(i).txtchkvlvcbp & " ") + Class1.valve(i).txtchkvlvlr

            '                generate.WriteLine(output)
            '            ElseIf Class1.valve(i).cmbvtype = "1" Then
            '                output = Class1.valve(i).cmbhydroid + "0301 " + Class1.valve(i).txttripnum
            '                generate.WriteLine(output)
            '            ElseIf Class1.valve(i).cmbvtype = "2" Then
            '                output = (((((((((((Class1.valve(i).cmbhydroid + "0301 " + Class1.valve(i).cmbinrvlvlo & " ") + Class1.valve(i).cmbinrvlvip & " ") + Class1.valve(i).txtinrvlvcbp & " ") + Class1.valve(i).txtinrvlvlf & " ") + Class1.valve(i).txtinrvlvifa & " ") + Class1.valve(i).txtinrvlvminfa & " ") + Class1.valve(i).txtinrvlvmaxfa & " ") + Class1.valve(i).txtinrvlvmoifa & " ") + Class1.valve(i).txtinrvlviav & " ") + Class1.valve(i).txtinrvlvmlf & " ") + Class1.valve(i).txtinrvlvrf & " ") + Class1.valve(i).txtinrvlvmf

            '                generate.WriteLine(output)
            '            ElseIf Class1.valve(i).cmbvtype = "3" Then
            '                output = ((((Class1.valve(i).cmbhydroid + "0301 " + Class1.valve(i).txtopentrip & " ") + Class1.valve(i).txtclosetrip & " ") + Class1.valve(i).txtmtrvlvvcr & " ") + Class1.valve(i).txtmtrvlvip & " ") + Class1.valve(i).txtmtrvlvvtn
            '                generate.WriteLine(output)
            '            ElseIf Class1.valve(i).cmbvtype = "4" Then
            '                output = Class1.valve(i).cmbhydroid + "0301 " + Class1.valve(i).txtsrvvlvcvn
            '                If Class1.valve(i).cmbsrvvlvicv = "1" Then
            '                    output = (output & " ") + Class1.valve(i).txtsrvvlvvtn
            '                End If
            '                generate.WriteLine(output)
            '            ElseIf Class1.valve(i).cmbvtype = "5" Then
            '                output = ((((((((((((((((Class1.valve(i).cmbhydroid + "0301 " + Class1.valve(i).cmbrlfvlvvic & " ") + Class1.valve(i).txtrlfvlvid & " ") + Class1.valve(i).txtrlfvlvvsd & " ") + Class1.valve(i).txtrlfvlvvpd & " ") + Class1.valve(i).txtrlfvlvvl & " ") + Class1.valve(i).txtrlfvlvmod & " ") + Class1.valve(i).txtrlfvlvhos & " ") + Class1.valve(i).txtrlfvlvmid & " ") + Class1.valve(i).txtrlfvlvhibe & " ") + Class1.valve(i).txtrlfvlvbad & " ") + Class1.valve(i).txtrlfvlvvsc & " ") + Class1.valve(i).txtrlfvlvvsp & " ") + Class1.valve(i).txtrlfvlvm & " ") + Class1.valve(i).txtrlfvlvvdc & " ") + Class1.valve(i).txtrlfvlvbip & " ") + Class1.valve(i).txtrlfvlvisp & " ") + Class1.valve(i).txtrlfvlvivpv
            '                generate.WriteLine(output)
            '            End If
            '            ' Card CCC0401 TABLE
            '            output = ""
            '            For j As Integer = 0 To Convert.ToInt32(Class1.valve(i).lbtecount) - 1
            '                output = output + Class1.valvetable(i, j) & " "
            '            Next
            '            output = Class1.valve(i).cmbhydroid + "0401 " & output
            '            generate.WriteLine(output)
            '        End If
            '    Next

            '    ' time dependent junctuioon
            '    For i As Integer = 0 To 99
            '        If Class1.tmdpjun(i, 1).gbname IsNot Nothing Then
            '            Class1.tmdpjun(i, 1).cmbhydroid = Class1.tmdpjun(i, 1).gbname.Substring(10, 3).ToString()

            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*         Component Time dependent Junction " + Class1.tmdpjun(i, 1).cmbhydroid)
            '            generate.WriteLine("*======================================================================")

            '            output = Class1.tmdpjun(i, 1).cmbhydroid + "0000 " + Class1.tmdpjun(i, 1).txtname & " tmdpjun"
            '            generate.WriteLine(output)
            '            ' ccc01001 geomerty card
            '            output = (Class1.tmdpjun(i, 1).cmbhydroid + "0101" & " ") + Class1.tmdpjun(i, 1).txtfromid

            '            If Convert.ToInt32(Class1.tmdpjun(i, 1).txtvolumenumberfrom) <= 9 Then
            '                Class1.tmdpjun(i, 1).txtvolumenumberfrom = "0" & Convert.ToInt32(Class1.tmdpjun(i, 1).txtvolumenumberfrom).ToString()
            '            ElseIf Convert.ToInt32(Class1.tmdpjun(i, 1).txtvolumenumberfrom) > 9 Then
            '                Class1.tmdpjun(i, 1).txtvolumenumberfrom = Convert.ToInt32(Class1.tmdpjun(i, 1).txtvolumenumberfrom).ToString()
            '            End If

            '            If Convert.ToInt32(Class1.tmdpjun(i, 1).txtvolumenumberto) <= 9 Then
            '                Class1.tmdpjun(i, 1).txtvolumenumberto = "0" & Convert.ToInt32(Class1.tmdpjun(i, 1).txtvolumenumberto).ToString()
            '            ElseIf Convert.ToInt32(Class1.tmdpjun(i, 1).txtvolumenumberto) > 9 Then
            '                Class1.tmdpjun(i, 1).txtvolumenumberto = Convert.ToInt32(Class1.tmdpjun(i, 1).txtvolumenumberto).ToString()
            '            End If

            '            If Convert.ToBoolean(Class1.tmdpjun(i, 1).cbformatfrom) = False Then
            '                output = (output & "0") + Class1.tmdpjun(i, 1).cmbconsidefrom & "0000" & " "
            '            Else
            '                If Class1.tmdpjun(i, 1).cmbconsidefrom = "0" AndAlso Class1.tmdpjun(i, 1).cmbconfacexfrom = "0" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberfrom & "0001" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsidefrom = "1" AndAlso Class1.tmdpjun(i, 1).cmbconfacexfrom = "0" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberfrom & "0002" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsidefrom = "0" AndAlso Class1.tmdpjun(i, 1).cmbconfacexfrom = "1" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberfrom & "0003" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsidefrom = "1" AndAlso Class1.tmdpjun(i, 1).cmbconfacexfrom = "1" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberfrom & "0004" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsidefrom = "0" AndAlso Class1.tmdpjun(i, 1).cmbconfacexfrom = "2" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberfrom & "0005" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsidefrom = "1" AndAlso Class1.tmdpjun(i, 1).cmbconfacexfrom = "2" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberfrom & "0006" & " "
            '                End If
            '            End If

            '            output = output + Class1.tmdpjun(i, 1).txttoid

            '            If Convert.ToBoolean(Class1.tmdpjun(i, 1).cbformatto) = False Then
            '                output = (output & "0") + Class1.tmdpjun(i, 1).cmbconsideto & "0000" & " "
            '            Else
            '                If Class1.tmdpjun(i, 1).cmbconsideto = "0" AndAlso Class1.tmdpjun(i, 1).cmbconfacexto = "0" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberto & "0001" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsideto = "1" AndAlso Class1.tmdpjun(i, 1).cmbconfacexto = "0" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberto & "0002" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsideto = "0" AndAlso Class1.tmdpjun(i, 1).cmbconfacexto = "1" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberto & "0003" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsideto = "1" AndAlso Class1.tmdpjun(i, 1).cmbconfacexto = "1" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberto & "0004" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsideto = "0" AndAlso Class1.tmdpjun(i, 1).cmbconfacexto = "2" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberto & "0005" & " "
            '                ElseIf Class1.tmdpjun(i, 1).cmbconsideto = "1" AndAlso Class1.tmdpjun(i, 1).cmbconfacexto = "2" Then
            '                    output = output + Class1.tmdpjun(i, 1).txtvolumenumberto & "0006" & " "
            '                End If
            '            End If

            '            output = (output & " ") + Class1.tmdpjun(i, 1).txtjarea
            '            generate.WriteLine(output)

            '            'ccc0200
            '            output = (((Class1.tmdpjun(i, 1).cmbhydroid + "0200 " + Class1.tmdpjun(i, 1).cmbip & " ") + Class1.tmdpjun(i, 1).txtttn & " ") + Class1.tmdpjun(i, 1).txtanpvrc & " ") + Class1.tmdpjun(i, 1).txtnpvrc
            '            generate.WriteLine(output)
            '            ' ccc0201 0299

            '            For j As Integer = 0 To Convert.ToInt32(Class1.tmdpjun(i, 1).counter) - 1
            '                If j < 10 Then
            '                    output = (Class1.tmdpjun(i, 1).cmbhydroid + "020" & (j + 1).ToString() & " ") + Class1.tmdpjun(i, j).lbc
            '                End If
            '                If j >= 10 Then
            '                    output = (Class1.tmdpjun(i, 1).cmbhydroid + "02" & (j + 1).ToString() & " ") + Class1.tmdpjun(i, j).lbc
            '                End If

            '                generate.WriteLine(output)

            '            Next
            '        End If
            '    Next
            '    For Each kvp As KeyValuePair(Of String, RELAP.SimulationObjects.UnitOps.Tank) In ChildParent.Collections.CLCS_TankCollection
            '        '  MsgBox(kvp.Key)
            '        generate.WriteLine("*======================================================================")
            '        generate.WriteLine("*         Component Time Dependent Volume" + Format(univID, "###"))
            '        generate.WriteLine("*======================================================================")
            '        generate.WriteLine(Format(univID, "###") & "0000 " + kvp.Value.Name & " tmdpvol")

            '        output = ((((((((Format(univID, "###") & "0101 " + kvp.Value.FlowArea & " ") + kvp.Value.LengthofVolume & " ") + kvp.Value.Volume & " ") + kvp.Value.Azimuthalangle & " ") + kvp.Value.InclinationAngle & " ") + kvp.Value.ElevationChange & " ") + kvp.Value.WallRoughness & " ") + kvp.Value.HydraulicDiameter & " ") + "0000000"
            '        generate.WriteLine(output)

            '        ' output = Format(univID, "###") + "0200 " + Class1.tmdpvol(i, 1).IC_E + Class1.tmdpvol(i, 1).IC_B + Class1.tmdpvol(i, 1).IC_TS
            '        generate.WriteLine(output)

            '        'For k As Integer = 0 To Convert.ToInt32(Class1.tmdpvol(i, 1).counter) - 1
            '        '    If k < 10 Then
            '        '        generate.WriteLine((Format(univID, "###") + "020" & (k + 1) & " ") + Class1.tmdpvol(i, k).lbc)
            '        '    Else
            '        '        generate.WriteLine((Format(univID, "###") + "02" & (k + 1) & " ") + Class1.tmdpvol(i, k).lbc)

            '        '    End If

            '        'Next
            '        univID = univID + 1
            '        MsgBox(kvp.Value.ComponentName)
            '    Next kvp
            '    ' Time Dependent VOLUME
            '    For i As Integer = 0 To 99
            '        If Class1.tmdpvol(i, 1).gbname IsNot Nothing Then
            '            Class1.tmdpvol(i, 1).id = Class1.tmdpvol(i, 1).gbname.Substring(10, 3).ToString()

            '            counter = 1

            '        End If
            '    Next

            '    ' pump

            '    For i As Integer = 0 To 99
            '        If Class1.pump(i, 1).gbname IsNot Nothing Then
            '            Class1.pump(i, 1).cmbhydroid = Class1.pump(i, 1).gbname.Substring(10, 3).ToString()

            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*         Component Pump " + Class1.pump(i, 1).cmbhydroid)
            '            generate.WriteLine("*======================================================================")

            '            If Convert.ToInt32(Class1.pump(i, 1).txtvndis) <= 9 Then
            '                Class1.pump(i, 1).txtvndis = "0" & Convert.ToInt32(Class1.pump(i, 1).txtvndis).ToString()
            '            End If

            '            ' Class1.pump[location, 1].txtvndis = txtvndis.Text;
            '            If Convert.ToInt32(Class1.pump(i, 1).txtvnsuc) <= 9 Then
            '                Class1.pump(i, 1).txtvnsuc = "0" & Convert.ToInt32(Class1.pump(i, 1).txtvnsuc).ToString()
            '            End If


            '            'card ccc0000
            '            output = Class1.pump(i, 1).cmbhydroid + "0000 " + Class1.pump(i, 1).txtname & " pump"
            '            generate.WriteLine(output)
            '            ' ccc0101
            '            output = ((((((Class1.pump(i, 1).cmbhydroid + "0101 " + Class1.pump(i, 1).txtpvfa & " ") + Class1.pump(i, 1).txtplov & " ") + Class1.pump(i, 1).txtpvov & " ") + Class1.pump(i, 1).txtpaa & " ") + Class1.pump(i, 1).txtpia & " ") + Class1.pump(i, 1).txtpec & " ") + Class1.pump(i, 1).cmbtft + Class1.pump(i, 1).cmbmlt + Class1.pump(i, 1).cmbwps + Class1.pump(i, 1).cmbvsm + Class1.pump(i, 1).cmbifm + Class1.pump(i, 1).cmbwf + Class1.pump(i, 1).cmbesm
            '            generate.WriteLine(output)
            '            ' ccc0108
            '            ' change made----------------
            '            If Convert.ToBoolean(Class1.pump(i, 1).cbformatsuc) = False Then
            '                output = ((((Class1.pump(i, 1).cmbhydroid + "0108 " + Class1.pump(i, 1).txtsucid & "0") + Class1.pump(i, 1).cmbconsidefromsuc & "0000" & " ") + Class1.pump(i, 1).txtjareasuc & " ") + Class1.pump(i, 1).txtffelcsuc & " ") + Class1.pump(i, 1).txtrfelcsuc & "  0"
            '            Else
            '                If Class1.pump(i, 1).cmbconsidefromsuc = "0" AndAlso Class1.pump(i, 1).cmbconfacexfromsuc = "0" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0108 " + Class1.pump(i, 1).txtsucid + Class1.pump(i, 1).txtvnsuc & "0001" & " ") + Class1.pump(i, 1).txtjareasuc & " ") + Class1.pump(i, 1).txtffelcsuc & " ") + Class1.pump(i, 1).txtrfelcsuc & "  0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromsuc = "1" AndAlso Class1.pump(i, 1).cmbconfacexfromsuc = "0" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0108 " + Class1.pump(i, 1).txtsucid + Class1.pump(i, 1).txtvnsuc & "0002" & " ") + Class1.pump(i, 1).txtjareasuc & " ") + Class1.pump(i, 1).txtffelcsuc & " ") + Class1.pump(i, 1).txtrfelcsuc & "  0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromsuc = "0" AndAlso Class1.pump(i, 1).cmbconfacexfromsuc = "1" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0108 " + Class1.pump(i, 1).txtsucid + Class1.pump(i, 1).txtvnsuc & "0003" & " ") + Class1.pump(i, 1).txtjareasuc & " ") + Class1.pump(i, 1).txtffelcsuc & " ") + Class1.pump(i, 1).txtrfelcsuc & "  0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromsuc = "1" AndAlso Class1.pump(i, 1).cmbconfacexfromsuc = "1" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0108 " + Class1.pump(i, 1).txtsucid + Class1.pump(i, 1).txtvnsuc & "0004" & " ") + Class1.pump(i, 1).txtjareasuc & " ") + Class1.pump(i, 1).txtffelcsuc & " ") + Class1.pump(i, 1).txtrfelcsuc & "  0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromsuc = "0" AndAlso Class1.pump(i, 1).cmbconfacexfromsuc = "2" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0108 " + Class1.pump(i, 1).txtsucid + Class1.pump(i, 1).txtvnsuc & "0005" & " ") + Class1.pump(i, 1).txtjareasuc & " ") + Class1.pump(i, 1).txtffelcsuc & " ") + Class1.pump(i, 1).txtrfelcsuc & "  0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromsuc = "1" AndAlso Class1.pump(i, 1).cmbconfacexfromsuc = "2" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0108 " + Class1.pump(i, 1).txtsucid + Class1.pump(i, 1).txtvnsuc & "0006" & " ") + Class1.pump(i, 1).txtjareasuc & " ") + Class1.pump(i, 1).txtffelcsuc & " ") + Class1.pump(i, 1).txtrfelcsuc & "  0"
            '                End If
            '            End If

            '            If Class1.pump(i, 1).cbccflsuc = "True" Then
            '                output = output & "1"
            '            Else
            '                output = output & "0"
            '            End If

            '            'output + output + Class1.pump[i, 1].cmbhorstratsuc;

            '            If Class1.pump(i, 1).cbchokingsuc = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            output = output + Class1.pump(i, 1).cmbareachangesuc

            '            If Class1.pump(i, 1).cbhomosuc = "True" Then
            '                output = output & "2"
            '            Else
            '                output = output & "0"
            '            End If
            '            output = output & "0"

            '            generate.WriteLine(output)

            '            ' ccc0109


            '            'output = Class1.pump[i, 1].cmbhydroid + "0109 " + Class1.pump[i, 1].txtdisid + "0" + Class1.pump[i, 1].cmbconfacexfromdis + "0000" + " " + Class1.pump[i, 1].txtjareadis + " " + Class1.pump[i, 1].txtfcfdis + " " + Class1.pump[i, 1].txtrfelcdis + "  0";
            '            If Convert.ToBoolean(Class1.pump(i, 1).cbformatdis) = False Then
            '                output = ((((Class1.pump(i, 1).cmbhydroid + "0109 " + Class1.pump(i, 1).txtdisid & "0") + Class1.pump(i, 1).cmbconsidefromdis & "0000" & " ") + Class1.pump(i, 1).txtjareadis & " ") + Class1.pump(i, 1).txtffelcdis & " ") + Class1.pump(i, 1).txtrfelcdis & " 0"
            '            Else
            '                If Class1.pump(i, 1).cmbconsidefromdis = "0" AndAlso Class1.pump(i, 1).cmbconfacexfromdis = "0" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0109 " + Class1.pump(i, 1).txtdisid + Class1.pump(i, 1).txtvndis & "0001" & " ") + Class1.pump(i, 1).txtjareadis & " ") + Class1.pump(i, 1).txtffelcdis & " ") + Class1.pump(i, 1).txtrfelcdis & " 0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromdis = "1" AndAlso Class1.pump(i, 1).cmbconfacexfromdis = "0" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0109 " + Class1.pump(i, 1).txtdisid + Class1.pump(i, 1).txtvndis & "0002" & " ") + Class1.pump(i, 1).txtjareadis & " ") + Class1.pump(i, 1).txtffelcdis & " ") + Class1.pump(i, 1).txtrfelcdis & " 0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromdis = "0" AndAlso Class1.pump(i, 1).cmbconfacexfromdis = "1" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0109 " + Class1.pump(i, 1).txtdisid + Class1.pump(i, 1).txtvndis & "0003" & " ") + Class1.pump(i, 1).txtjareadis & " ") + Class1.pump(i, 1).txtffelcdis & " ") + Class1.pump(i, 1).txtrfelcdis & " 0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromdis = "1" AndAlso Class1.pump(i, 1).cmbconfacexfromdis = "1" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0109 " + Class1.pump(i, 1).txtdisid + Class1.pump(i, 1).txtvndis & "0004" & " ") + Class1.pump(i, 1).txtjareadis & " ") + Class1.pump(i, 1).txtffelcdis & " ") + Class1.pump(i, 1).txtrfelcdis & " 0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromdis = "0" AndAlso Class1.pump(i, 1).cmbconfacexfromdis = "2" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0109 " + Class1.pump(i, 1).txtdisid + Class1.pump(i, 1).txtvndis & "0005" & " ") + Class1.pump(i, 1).txtjareadis & " ") + Class1.pump(i, 1).txtffelcdis & " ") + Class1.pump(i, 1).txtrfelcdis & " 0"
            '                ElseIf Class1.pump(i, 1).cmbconsidefromdis = "1" AndAlso Class1.pump(i, 1).cmbconfacexfromdis = "2" Then
            '                    output = (((Class1.pump(i, 1).cmbhydroid + "0109 " + Class1.pump(i, 1).txtdisid + Class1.pump(i, 1).txtvndis & "0006" & " ") + Class1.pump(i, 1).txtjareadis & " ") + Class1.pump(i, 1).txtffelcdis & " ") + Class1.pump(i, 1).txtrfelcdis & " 0"
            '                End If
            '            End If
            '            If Class1.pump(i, 1).cbccfldis = "True" Then
            '                output = output & "1"
            '            Else
            '                output = output & "0"
            '            End If

            '            'output + output + Class1.pump[i, 1].cmbhorstratdis;

            '            If Class1.pump(i, 1).cbchokingdis = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            output = output + Class1.pump(i, 1).cmbareachangedis

            '            If Class1.pump(i, 1).cbhomodis = "True" Then
            '                output = output & "2"
            '            Else
            '                output = output & "0"
            '            End If
            '            output = output & "0"

            '            generate.WriteLine(output)

            '            ' ccc0110   optional card

            '            If Class1.pump(i, 1).cbccflsuc = "True" Then
            '                output = (((Class1.pump(i, 1).cmbhydroid + "0110 " + Class1.pump(i, 1).txtdjsuc & " ") + Class1.pump(i, 1).txtfcfsuc & " ") + Class1.pump(i, 1).txtgisuc & " ") + Class1.pump(i, 1).txtslopesuc
            '                generate.WriteLine(output)


            '                output = Nothing
            '            Else
            '                output = Class1.pump(i, 1).cmbhydroid + "0110 " + Class1.pump(i, 1).txtdjsuc
            '                generate.WriteLine(output)
            '                output = Nothing
            '            End If

            '            ' ccc0111   optional card
            '            If Class1.pump(i, 1).cbccfldis = "False" Then
            '                output = Class1.pump(i, 1).cmbhydroid + "0111 " + Class1.pump(i, 1).txtdjdis
            '                generate.WriteLine(output)
            '            Else
            '                output = (((Class1.pump(i, 1).cmbhydroid + "0111 " + Class1.pump(i, 1).txtdjdis & " ") + Class1.pump(i, 1).txtfcfdis & " ") + Class1.pump(i, 1).txtgidis & " ") + Class1.pump(i, 1).txtslopedis
            '                generate.WriteLine(output)
            '            End If


            '            ' ccc 0112 optional

            '            output = (((Class1.pump(i, 1).cmbhydroid + "0112 " + Class1.pump(i, 1).txtbfsuc & " ") + Class1.pump(i, 1).txtcfsuc & " ") + Class1.pump(i, 1).txtbrsuc & " ") + Class1.pump(i, 1).txtcrsuc
            '            generate.WriteLine(output)

            '            ' ccc 0113 optional

            '            output = (((Class1.pump(i, 1).cmbhydroid + "0113 " + Class1.pump(i, 1).txtbfdis & " ") + Class1.pump(i, 1).txtcfdis & " ") + Class1.pump(i, 1).txtbrdis & " ") + Class1.pump(i, 1).txtcrdis
            '            generate.WriteLine(output)

            '            ' ccc0200

            '            output = Class1.pump(i, 1).cmbhydroid + "0200 " + Class1.pump(i, 1).cmbfluid + Class1.pump(i, 1).cmbboron + Class1.pump(i, 1).cmbap & " "
            '            If Class1.pump(i, 1).cmbap = "0" Then
            '                output = (((output + Class1.pump(i, 1).txtpres & " ") + Class1.pump(i, 1).txtlsie & " ") + Class1.pump(i, 1).txtvsie & " ") + Class1.pump(i, 1).txtvvf

            '            ElseIf Class1.pump(i, 1).cmbap = "1" Then
            '                output = (output + Class1.pump(i, 1).txttemp & " ") + Class1.pump(i, 1).txtsqec

            '            ElseIf Class1.pump(i, 1).cmbap = "2" Then
            '                output = (output + Class1.pump(i, 1).txtpres & " ") + Class1.pump(i, 1).txtsqec

            '            ElseIf Class1.pump(i, 1).cmbap = "3" Then
            '                output = (output + Class1.pump(i, 1).txtpres & " ") + Class1.pump(i, 1).txttemp

            '            ElseIf Class1.pump(i, 1).cmbap = "4" Then
            '                output = ((output + Class1.pump(i, 1).txtpres & " ") + Class1.pump(i, 1).txttemp & " ") + Class1.pump(i, 1).txtsqec

            '            ElseIf Class1.pump(i, 1).cmbap = "5" Then
            '                output = ((output + Class1.pump(i, 1).txttemp & " ") + Class1.pump(i, 1).txtsqec & " ") + Class1.pump(i, 1).txtncqec

            '            ElseIf Class1.pump(i, 1).cmbap = "6" Then
            '                output = ((((output + Class1.pump(i, 1).txtpres & " ") + Class1.pump(i, 1).txtlsie & " ") + Class1.pump(i, 1).txtvsie & " ") + Class1.pump(i, 1).txtvvf & " ") + Class1.pump(i, 1).txtncq
            '            End If

            '            generate.WriteLine(output)

            '            ' ccc 0201
            '            output = ((Class1.pump(i, 1).cmbhydroid + "0201 " + Class1.pump(i, 1).cmbvelmfrsuc & " ") + Class1.pump(i, 1).txtliqsuc & " ") + Class1.pump(i, 1).txtvapsuc & " 0"
            '            generate.WriteLine(output)

            '            ' ccc 0202
            '            output = ((Class1.pump(i, 1).cmbhydroid + "0202 " + Class1.pump(i, 1).cmbvelmfrdis & " ") + Class1.pump(i, 1).txtliqdis & " ") + Class1.pump(i, 1).txtvapdis & " 0"
            '            generate.WriteLine(output)


            '            ' ccc0301

            '            output = ((((((Class1.pump(i, 1).cmbhydroid + "0301 " + Class1.pump(i, 1).txtptdi & " ") + Class1.pump(i, 1).txttpi & " ") + Class1.pump(i, 1).txttpdti & " ") + Class1.pump(i, 1).txtpmtti & " ") + Class1.pump(i, 1).txttdpvi & " ") + Class1.pump(i, 1).txtptn & " ") + Class1.pump(i, 1).cmbri
            '            generate.WriteLine(output)

            '            ' ccc0302 to ccc0304

            '            output = (((((Class1.pump(i, 1).cmbhydroid + "0302 " + Class1.pump(i, 1).txtrpv & " ") + Class1.pump(i, 1).txtratio & " ") + Class1.pump(i, 1).txtrf & " ") + Class1.pump(i, 1).txtrh & " ") + Class1.pump(i, 1).txtrt & " ") + Class1.pump(i, 1).txtmi
            '            generate.WriteLine(output)

            '            output = ((((Class1.pump(i, 1).cmbhydroid + "0303 " + Class1.pump(i, 1).txtrd & " ") + Class1.pump(i, 1).txtrpmt & " ") + Class1.pump(i, 1).txttf2 & " ") + Class1.pump(i, 1).txttf0 & " ") + Class1.pump(i, 1).txttf3 & " 0.0"
            '            generate.WriteLine(output)

            '            ' ccc0308
            '            If Class1.pump(i, 1).cbpvic = "True" Then
            '                output = ((((Class1.pump(i, 1).cmbhydroid + "0308 " + Class1.pump(i, 1).txtrs & " ") + Class1.pump(i, 1).txti3 & " ") + Class1.pump(i, 1).txti2 & " ") + Class1.pump(i, 1).txti1 & " ") + Class1.pump(i, 1).txti0
            '                generate.WriteLine(output)
            '            End If

            '            ' ccc0309

            '            If Class1.pump(i, 1).cbpscc = "True" Then
            '                output = (Class1.pump(i, 1).cmbhydroid + "0309 " + Class1.pump(i, 1).txtccnsc & " ") + Class1.pump(i, 1).txtpdt
            '                generate.WriteLine(output)
            '            End If

            '            ' ccc0310

            '            If Class1.pump(i, 1).cbpsdc = "True" Then
            '                output = ((Class1.pump(i, 1).cmbhydroid + "0310 " + Class1.pump(i, 1).txtept & " ") + Class1.pump(i, 1).txtmfvps & " ") + Class1.pump(i, 1).txtmrvps
            '                generate.WriteLine(output)
            '            End If

            '            If Class1.pump(i, 1).txtptdi = "0" Then

            '                ' curve 1 1 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter00) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "1100 1 1"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter00) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "110" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc00
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "11" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc00
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 2 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter01) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "1200 1 2"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter01) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "120" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc01
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "12" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc01
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If


            '                ' curve 1 3 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter02) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "1300 1 3"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter02) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "130" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc02
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "13" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc02
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 4 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter03) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "1400 1 4"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter03) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "140" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc03
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "14" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc03
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 5 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter04) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "1500 1 5"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter04) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "150" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc04
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "15" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc04
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 6 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter05) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "1600 1 6"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter05) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "160" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc05
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "16" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc05
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 7 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter06) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "1700 1 7"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter06) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "170" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc06
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "17" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc06
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 8 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter07) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "1800 1 8"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter07) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "180" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc07
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "18" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc07
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If


            '                ' curve 2 1 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter10) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "1900 2 1"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter10) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "190" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc10
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "19" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc10
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 2 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter11) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "2000 2 2"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter11) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "200" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc11
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "20" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc11
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If


            '                ' curve 2 3 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter12) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "2100 2 3"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter12) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "210" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc12
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "21" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc12
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 4 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter13) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "2200 2 4"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter13) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "220" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc13
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "22" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc13
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 5 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter14) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "2300 2 5"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter04) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "230" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc14
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "23" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc14
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 6 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter15) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "2400 2 6"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter15) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "240" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc15
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "24" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc15
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 7 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter16) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "2500 2 7"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter16) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "250" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc16
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "25" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc16
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 8 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbsphccounter17) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "2600 1 8"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbsphccounter17) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "260" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc17
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "26" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbsphc17
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next


            '                    ' end of if
            '                End If
            '            End If

            '            If Class1.pump(i, 1).txttpi = "0" Then
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpmtcounter0) > 0 Then
            '                    generate.WriteLine("* Table ============")

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpmtcounter0) - 1
            '                        If k < 9 Then
            '                            output = Class1.pump(i, 1).cmbhydroid + "300 " + Class1.pump(i, k).lbtpmt0
            '                            generate.WriteLine(output)
            '                        Else
            '                            output = Class1.pump(i, 1).cmbhydroid + "30 " + Class1.pump(i, k).lbtpmt0
            '                            generate.WriteLine(output)
            '                        End If
            '                    Next
            '                End If


            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpmtcounter1) > 0 Then
            '                    generate.WriteLine("* Table ============")

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpmtcounter1) - 1
            '                        If k < 9 Then
            '                            output = Class1.pump(i, 1).cmbhydroid + "310 " + Class1.pump(i, k).lbtpmt1
            '                            generate.WriteLine(output)
            '                        Else
            '                            output = Class1.pump(i, 1).cmbhydroid + "31 " + Class1.pump(i, k).lbtpmt1
            '                            generate.WriteLine(output)
            '                        End If
            '                    Next
            '                End If
            '            End If

            '            If Class1.pump(i, 1).txttpdti = "0" Then

            '                ' curve 1 1 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter00) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "4100 1 1"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter00) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "410" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt00
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "41" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt00
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 2 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter01) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "4200 1 2"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter01) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "420" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt01
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "42" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt01
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If


            '                ' curve 1 3 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter02) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "4300 1 3"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter02) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "430" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt02
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "43" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt02
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 4 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter03) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "4400 1 4"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter03) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "440" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt03
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "44" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt03
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 5 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter04) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "4500 1 5"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter04) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "450" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt04
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "45" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt04
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 6 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter05) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "4600 1 6"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter05) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "460" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt05
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "46" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt05
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 7 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter06) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "4700 1 7"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter06) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "470" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt06
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "47" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt06
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 8 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter07) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "4800 1 8"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter07) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "480" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt07
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "48" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt07
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If


            '                ' curve 2 1 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter10) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "4900 2 1"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter10) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "490" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt10
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "49" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt10
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 2 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter11) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "5000 2 2"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter11) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "500" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt11
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "50" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt11
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If


            '                ' curve 2 3 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter12) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "5100 2 3"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter12) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "510" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt12
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "51" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt12
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 4 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter13) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "5200 2 4"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter13) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "520" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt13
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "52" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt13
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 5 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter14) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "5300 2 5"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter04) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "530" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt14
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "53" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt14
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 1 6 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter15) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "5400 2 6"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter15) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "540" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt15
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "54" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt15
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 7 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter16) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "2500 2 7"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter16) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "250" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt16
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "25" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt16
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next
            '                End If

            '                ' curve 2 8 
            '                If Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter17) > 0 Then
            '                    generate.WriteLine("* Table ====================")
            '                    output = Class1.pump(i, 1).cmbhydroid + "2600 1 8"
            '                    generate.WriteLine(output)

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtpdtcounter17) - 1
            '                        If k < 9 Then
            '                            output = (Class1.pump(i, 1).cmbhydroid + "260" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt17
            '                        Else
            '                            output = (Class1.pump(i, 1).cmbhydroid + "26" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtpdt17
            '                        End If
            '                        generate.WriteLine(output)
            '                    Next


            '                    ' end of if
            '                End If
            '            End If

            '            If Class1.pump(i, 1).txtpmtti = "0" Then
            '                For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbrpmtdcounter) - 1
            '                    If k < 9 Then
            '                        generate.WriteLine((Class1.pump(i, 1).cmbhydroid + "600" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbrpmtd)
            '                    Else
            '                        generate.WriteLine((Class1.pump(i, 1).cmbhydroid + "60" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbrpmtd)
            '                        ' generate.WriteLine(output);
            '                    End If
            '                Next
            '            End If

            '            If Class1.pump(i, 1).cmbtdpvi = "0" Then
            '                generate.WriteLine(((Class1.pump(i, 1).cmbhydroid + "6100 " + Class1.pump(i, 1).txttn & " ") + Class1.pump(i, 1).txtanpvrc & " ") + Class1.pump(i, 1).txtnpvrc)
            '                For k As Integer = 0 To Convert.ToInt32(Class1.pump(i, 1).lbtdpvcounter) - 1
            '                    If k < 9 Then
            '                        generate.WriteLine((Class1.pump(i, 1).cmbhydroid + "610" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtdpv)
            '                    Else
            '                        generate.WriteLine((Class1.pump(i, 1).cmbhydroid + "61" & (k + 1).ToString() & " ") + Class1.pump(i, k).lbtdpv)
            '                        'generate.WriteLine(output);
            '                    End If
            '                Next


            '            End If
            '        End If
            '    Next
            '    '*************************************************************************

            '    For i As Integer = 0 To 99
            '        If Class1.branch(i, 1).gbname IsNot Nothing Then
            '            Class1.branch(i, 1).cmbhydroid = Class1.branch(i, 1).gbname.Substring(10, 3).ToString()

            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*         Component Branch Separator Jetmixer Turbine ECCMIX " + Class1.branch(i, 1).cmbhydroid)
            '            generate.WriteLine("*======================================================================")
            '            'card ccc0000
            '            output = Class1.branch(i, 1).cmbhydroid + "0000 " + Class1.branch(i, 1).txtname & " "
            '            If Convert.ToInt32(Class1.branch(i, 1).cmbtype) = 0 Then
            '                output = output & "branch"
            '            ElseIf Convert.ToInt32(Class1.branch(i, 1).cmbtype) = 1 Then
            '                output = output & "separator"
            '            ElseIf Convert.ToInt32(Class1.branch(i, 1).cmbtype) = 2 Then
            '                output = output & "jetmixer"
            '            ElseIf Convert.ToInt32(Class1.branch(i, 1).cmbtype) = 3 Then
            '                output = output & "turbine"
            '            ElseIf Convert.ToInt32(Class1.branch(i, 1).cmbtype) = 4 Then
            '                output = output & "eccmix"
            '            End If
            '            generate.WriteLine(output)

            '            ' card ccc0001

            '            output = (Class1.branch(i, 1).cmbhydroid + "0001 " + Class1.branch(i, 1).txtnj & " ") + Class1.branch(i, 1).cmbicc
            '            generate.WriteLine(output)

            '            ' card ccc0002 not include

            '            ' card ccc0101 
            '            output = (((((((Class1.branch(i, 1).cmbhydroid + "0101 " + Class1.branch(i, 1).txtvfa & " ") + Class1.branch(i, 1).txtlov & " ") + Class1.branch(i, 1).txtvov & " ") + Class1.branch(i, 1).txtaa & " ") + Class1.branch(i, 1).txtia & " ") + Class1.branch(i, 1).txtec & " ") + Class1.branch(i, 1).txtwr & " ") + Class1.branch(i, 1).txthd & " "
            '            output = output & Class1.branch(i, 1).cmbtft.ToString()
            '            output = output & Class1.branch(i, 1).cmbmlt.ToString()
            '            output = output & Class1.branch(i, 1).cmbwps.ToString()
            '            output = output & Class1.branch(i, 1).cmbvsm.ToString()
            '            output = output & Class1.branch(i, 1).cmbifm.ToString()
            '            output = output & Class1.branch(i, 1).cmbwf.ToString()
            '            output = output & Class1.branch(i, 1).cmbesm.ToString()
            '            generate.WriteLine(output)

            '            ' card ccc0131
            '            output = (((((Class1.branch(i, 1).cmbhydroid + "0131 " + Class1.branch(i, 1).txtsfx & " ") + Class1.branch(i, 1).txtvrex & " ") + Class1.branch(i, 1).txtsfy & " ") + Class1.branch(i, 1).txtvrey & " ") + Class1.branch(i, 1).txtsfz & " ") + Class1.branch(i, 1).txtvrez
            '            generate.WriteLine(output)

            '            ''' ccc0200
            '            output = Class1.branch(i, 1).cmbhydroid + "0200 " + Class1.branch(i, 1).cmbfluid + Class1.branch(i, 1).cmbboron + Class1.branch(i, 1).cmbap & " "

            '            If Class1.branch(i, 1).cmbap = "0" Then
            '                output = (((output + Class1.branch(i, 1).txtpres & " ") + Class1.branch(i, 1).txtlsie & " ") + Class1.branch(i, 1).txtvsie & " ") + Class1.branch(i, 1).txtvvf

            '            ElseIf Class1.branch(i, 1).cmbap = "1" Then
            '                output = (output + Class1.branch(i, 1).txttemp & " ") + Class1.branch(i, 1).txtsqec

            '            ElseIf Class1.branch(i, 1).cmbap = "2" Then
            '                output = (output + Class1.branch(i, 1).txtpres & " ") + Class1.branch(i, 1).txtsqec

            '            ElseIf Class1.branch(i, 1).cmbap = "3" Then
            '                output = (output + Class1.branch(i, 1).txtpres & " ") + Class1.branch(i, 1).txttemp

            '            ElseIf Class1.branch(i, 1).cmbap = "4" Then
            '                output = ((output + Class1.branch(i, 1).txtpres & " ") + Class1.branch(i, 1).txttemp & " ") + Class1.branch(i, 1).txtsqec

            '            ElseIf Class1.branch(i, 1).cmbap = "5" Then
            '                output = ((output + Class1.branch(i, 1).txttemp & " ") + Class1.branch(i, 1).txtsqec & " ") + Class1.branch(i, 1).txtncqec

            '            ElseIf Class1.branch(i, 1).cmbap = "6" Then
            '                output = ((((output + Class1.branch(i, 1).txtpres & " ") + Class1.branch(i, 1).txtlsie & " ") + Class1.branch(i, 1).txtvsie & " ") + Class1.branch(i, 1).txtvvf & " ") + Class1.branch(i, 1).txtncq
            '            End If

            '            generate.WriteLine(output)
            '            ''' cccN101

            '            For j As Integer = 0 To Convert.ToInt32(Class1.branch(i, 1).txtnj) - 1
            '                If Convert.ToInt32(Class1.branch(i, j).txtnvfromj) <= 9 Then
            '                    Class1.branch(i, j).txtnvfromj = "0" & Convert.ToInt32(Class1.branch(i, j).txtnvfromj).ToString()
            '                End If
            '                If Convert.ToInt32(Class1.branch(i, j).txtnvtoj) <= 9 Then
            '                    Class1.branch(i, j).txtnvtoj = "0" & Convert.ToInt32(Class1.branch(i, j).txtnvtoj).ToString()
            '                End If


            '                If Class1.branch(i, j).cbformatfrom = "False" Then

            '                    output = ((Class1.branch(i, 1).cmbhydroid + (j + 1).ToString() & "101 ") + Class1.branch(i, j).txtidfromj & "0") + Class1.branch(i, j).cmbconsidefromj & "0000" & " "
            '                Else
            '                    output = (Class1.branch(i, 1).cmbhydroid + (j + 1).ToString() & "101 ") + Class1.branch(i, j).txtidfromj + Class1.branch(i, j).txtnvfromj & "00"

            '                    If Class1.branch(i, j).cmbconsidefromj = "0" AndAlso Class1.branch(i, j).cmbconfacefromj = "0" Then
            '                        output = output & "01 "
            '                    ElseIf Class1.branch(i, j).cmbconsidefromj = "1" AndAlso Class1.branch(i, j).cmbconfacefromj = "0" Then
            '                        output = output & "02 "
            '                    ElseIf Class1.branch(i, j).cmbconsidefromj = "0" AndAlso Class1.branch(i, j).cmbconfacefromj = "1" Then
            '                        output = output & "03 "
            '                    ElseIf Class1.branch(i, j).cmbconsidefromj = "1" AndAlso Class1.branch(i, j).cmbconfacefromj = "1" Then
            '                        output = output & "04 "
            '                    ElseIf Class1.branch(i, j).cmbconsidefromj = "0" AndAlso Class1.branch(i, j).cmbconfacefromj = "2" Then
            '                        output = output & "05 "
            '                    ElseIf Class1.branch(i, j).cmbconsidefromj = "1" AndAlso Class1.branch(i, j).cmbconfacefromj = "2" Then
            '                        output = output & "06 "

            '                    End If
            '                End If

            '                If Class1.branch(i, j).cbformatto = "False" Then

            '                    output = (output + Class1.branch(i, j).txtidtoj & "0") + Class1.branch(i, j).cmbconsidetoj & "0000 "
            '                Else
            '                    output = output + Class1.branch(i, j).txtidtoj + Class1.branch(i, j).txtnvtoj & "00"

            '                    If Class1.branch(i, j).cmbconsidetoj = "0" AndAlso Class1.branch(i, j).cmbconfacetoj = "0" Then
            '                        output = output & "01 "
            '                    ElseIf Class1.branch(i, j).cmbconsidetoj = "1" AndAlso Class1.branch(i, j).cmbconfacetoj = "0" Then
            '                        output = output & "02 "
            '                    ElseIf Class1.branch(i, j).cmbconsidetoj = "0" AndAlso Class1.branch(i, j).cmbconfacetoj = "1" Then
            '                        output = output & "03 "
            '                    ElseIf Class1.branch(i, j).cmbconsidetoj = "1" AndAlso Class1.branch(i, j).cmbconfacetoj = "1" Then
            '                        output = output & "04 "
            '                    ElseIf Class1.branch(i, j).cmbconsidetoj = "0" AndAlso Class1.branch(i, j).cmbconfacetoj = "2" Then
            '                        output = output & "05 "
            '                    ElseIf Class1.branch(i, j).cmbconsidetoj = "1" AndAlso Class1.branch(i, j).cmbconfacetoj = "2" Then
            '                        output = output & "06 "

            '                    End If
            '                End If

            '                output = ((output + Class1.branch(i, j).txtjareaj & " ") + Class1.branch(i, j).txtffelcj & " ") + Class1.branch(i, j).txtrfelcj & " "
            '                If Class1.branch(i, j).cbmodpvj = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If

            '                If Class1.branch(i, j).cbccflj = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                output = output + Class1.branch(i, j).cmbhorstratj

            '                If Class1.branch(i, j).cbchokingj = "True" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "1"
            '                End If
            '                output = output + Class1.branch(i, j).cmbareachangej

            '                If Class1.branch(i, j).cbhomoj = "False" Then
            '                    output = output & "0"
            '                Else
            '                    output = output & "2"
            '                End If
            '                output = output + Class1.branch(i, j).cmbmfj & " "

            '                If Class1.branch(i, 1).cmbtype = "1" Then
            '                    output = output + Class1.branch(i, j).txtvflseparatorj & " "
            '                Else
            '                    output = output + Class1.branch(i, j).txtsubdcbranch & " "
            '                End If

            '                output = (output + Class1.branch(i, j).txttpdcbranch & " ") + Class1.branch(i, j).txtsupdcbranch


            '                generate.WriteLine(output)
            '            Next
            '            ''' cccN110

            '            For j As Integer = 0 To Convert.ToInt32(Class1.branch(i, 1).txtnj) - 1
            '                output = ((((Class1.branch(i, 1).cmbhydroid + (j + 1).ToString() & "110 ") + Class1.branch(i, j).txtdjj & " ") + Class1.branch(i, j).txtfcfj & " ") + Class1.branch(i, j).txtgij & " ") + Class1.branch(i, j).txtslopej
            '                generate.WriteLine(output)
            '            Next

            '            ' cccn112
            '            For j As Integer = 0 To Convert.ToInt32(Class1.branch(i, 1).txtnj) - 1
            '                output = ((((Class1.branch(i, 1).cmbhydroid + (j + 1).ToString() & "112 ") + Class1.branch(i, j).txtbfj & " ") + Class1.branch(i, j).txtcfj & " ") + Class1.branch(i, j).txtbrj & " ") + Class1.branch(i, j).txtcrj
            '                generate.WriteLine(output)
            '            Next

            '            ' cccn201
            '            For j As Integer = 0 To Convert.ToInt32(Class1.branch(i, 1).txtnj) - 1
            '                output = ((Class1.branch(i, 1).cmbhydroid + (j + 1).ToString() & "201 ") + Class1.branch(i, j).txtliqj & " ") + Class1.branch(i, j).txtvapj & " 0.0"

            '                generate.WriteLine(output)
            '            Next

            '            ''' ccc0300

            '            If Class1.branch(i, 1).cmbtype = "3" Then
            '                output = (((((Class1.branch(i, 1).cmbhydroid + "0300 " + Class1.branch(i, 1).txttsss & " ") + Class1.branch(i, 1).txtirssg & " ") + Class1.branch(i, 1).txtsfc & " ") + Class1.branch(i, 1).txtscntsc & " ") + Class1.branch(i, 1).txtdtn & " ") + Class1.branch(i, 1).txtdf
            '                generate.WriteLine(output)
            '                ' ccc0400
            '                output = (((Class1.branch(i, 1).cmbhydroid + "0400 " + Class1.branch(i, 1).cmbtt & " ") + Class1.branch(i, 1).txtaemedp & " ") + Class1.branch(i, 1).txtdrf & " ") + Class1.branch(i, 1).txtmsr

            '                generate.WriteLine(output)
            '            End If
            '            If Class1.branch(i, 1).cmbtype = "1" Then
            '                ' ccc0500
            '                output = ((((((Class1.branch(i, 1).cmbhydroid + "0500 " + Class1.branch(i, 1).txtrlprfstss & " ") + Class1.branch(i, 1).txtsnea & " ") + Class1.branch(i, 1).txtrshi & " ") + Class1.branch(i, 1).txtsvarh & " ") + Class1.branch(i, 1).txtlcocuss & " ") + Class1.branch(i, 1).txtlcucuss & " ") + Class1.branch(i, 1).txtadbefsdpsv

            '                generate.WriteLine(output)
            '            End If
            '            If Class1.branch(i, 1).cmbtype = "1" Then
            '                ' ccc0501
            '                output = (((((((Class1.branch(i, 1).cmbhydroid + "0501 " + Class1.branch(i, 1).txtlfvpc1 & " ") + Class1.branch(i, 1).txtvcvpc1 & " ") + Class1.branch(i, 1).txtswir1 & " ") + Class1.branch(i, 1).txtdpec1 & " ") + Class1.branch(i, 1).txtdphd1 & " ") + Class1.branch(i, 1).txtsbl1 & " ") + Class1.branch(i, 1).txtdplc1 & " ") + Class1.branch(i, 1).txtdpec1

            '                generate.WriteLine(output)
            '            End If
            '            If Class1.branch(i, 1).cmbtype = "1" Then
            '                ' ccc0501
            '                output = (((((((Class1.branch(i, 1).cmbhydroid + "0502 " + Class1.branch(i, 1).txtlfvpc2 & " ") + Class1.branch(i, 1).txtvcvpc2 & " ") + Class1.branch(i, 1).txtswir2 & " ") + Class1.branch(i, 1).txtdpec2 & " ") + Class1.branch(i, 1).txtdphd2 & " ") + Class1.branch(i, 1).txtsbl2 & " ") + Class1.branch(i, 1).txtdplc2 & " ") + Class1.branch(i, 1).txtdpec2

            '                generate.WriteLine(output)
            '            End If
            '            If Class1.branch(i, 1).cmbtype = "1" Then
            '                ' ccc0501
            '                output = (((((((Class1.branch(i, 1).cmbhydroid + "0503 " + Class1.branch(i, 1).txtlfvpc3 & " ") + Class1.branch(i, 1).txtvcvpc3 & " ") + Class1.branch(i, 1).txtswir3 & " ") + Class1.branch(i, 1).txtdpec3 & " ") + Class1.branch(i, 1).txtdphd3 & " ") + Class1.branch(i, 1).txtsbl3 & " ") + Class1.branch(i, 1).txtdplc3 & " ") + Class1.branch(i, 1).txtdpec3

            '                generate.WriteLine(output)
            '            End If
            '            If Class1.branch(i, 1).cmbtype = "1" And Class1.branch(i, 1).cmbso = "1" Then
            '                ' ccc600
            '                output = ((Class1.branch(i, 1).cmbhydroid + "0600 " + Class1.branch(i, 1).txtvvbelow & " ") + Class1.branch(i, 1).txtvvabove & " ") + Class1.branch(i, 1).txtrdiq
            '                generate.WriteLine(output)
            '            End If
            '        End If
            '    Next

            '    '___________________ A C C U M U L A T O R _____________________________
            '    For i As Integer = 0 To 99
            '        If Class1.accum(i).gbname IsNot Nothing Then
            '            Class1.accum(i).cmbhydroid = Class1.accum(i).gbname.Substring(10, 3).ToString()

            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*         Component Accumulator " + Class1.accum(i).cmbhydroid)
            '            generate.WriteLine("*======================================================================")
            '            'card ccc0000
            '            output = Class1.accum(i).cmbhydroid + "0000 " + Class1.accum(i).txtname & " accum"
            '            generate.WriteLine(output)
            '            'Cards CCC0101 - 09
            '            output = (((((((((Class1.accum(i).cmbhydroid + "0101 " + Class1.accum(i).txtvfa & " ") + Class1.accum(i).txtlov & " ") + Class1.accum(i).txtvov & " ") + Class1.accum(i).txtaa & " ") + Class1.accum(i).txtia & " ") + Class1.accum(i).txtec & " ") + Class1.accum(i).txtwr & " ") + Class1.accum(i).txthd & " ") + Class1.accum(i).cmbts + Class1.accum(i).cmbmlt + Class1.accum(i).cmbwps + Class1.accum(i).cmbvsm + Class1.accum(i).cmbifm + Class1.accum(i).cmbwf + Class1.accum(i).cmbesm & " ") + Class1.accum(i).cmbgf
            '            generate.WriteLine(output)
            '            ' Card CCC0200
            '            output = ((Class1.accum(i).cmbhydroid + "0200 " + Class1.accum(i).txttankpressure & " ") + Class1.accum(i).txttanktemperature & " ") + Class1.accum(i).txttankbc
            '            generate.WriteLine(output)

            '            ' Junction Geometry Card : Card CCC1101
            '            output = Class1.accum(i).cmbhydroid + "1101 " + Class1.accum(i).txtidtoj




            '            If Convert.ToInt32(Class1.accum(i).txtvolumenumberto) <= 9 Then
            '                Class1.accum(i).txtvolumenumberto = "0" & Convert.ToInt32(Class1.accum(i).txtvolumenumberto).ToString()
            '            ElseIf Convert.ToInt32(Class1.accum(i).txtvolumenumberto) > 9 Then
            '                Class1.accum(i).txtvolumenumberto = Convert.ToInt32(Class1.accum(i).txtvolumenumberto).ToString()
            '            End If

            '            If Convert.ToBoolean(Class1.accum(i).cbformatto) = False Then
            '                output = (output & "0") + Class1.accum(i).cmbconsidetoj & "0000" & " "
            '            Else
            '                If Class1.accum(i).cmbconsidetoj = "0" AndAlso Class1.accum(i).cmbconfacetoj = "0" Then
            '                    output = output + Class1.accum(i).txtvolumenumberto & "0001" & " "
            '                ElseIf Class1.accum(i).cmbconsidetoj = "1" AndAlso Class1.accum(i).cmbconfacetoj = "0" Then
            '                    output = output + Class1.accum(i).txtvolumenumberto & "0002" & " "
            '                ElseIf Class1.accum(i).cmbconsidetoj = "0" AndAlso Class1.accum(i).cmbconfacetoj = "1" Then
            '                    output = output + Class1.accum(i).txtvolumenumberto & "0003" & " "
            '                ElseIf Class1.accum(i).cmbconsidetoj = "1" AndAlso Class1.accum(i).cmbconfacetoj = "1" Then
            '                    output = output + Class1.accum(i).txtvolumenumberto & "0004" & " "
            '                ElseIf Class1.accum(i).cmbconsidetoj = "0" AndAlso Class1.accum(i).cmbconfacetoj = "2" Then
            '                    output = output + Class1.accum(i).txtvolumenumberto & "0005" & " "
            '                ElseIf Class1.accum(i).cmbconsidetoj = "1" AndAlso Class1.accum(i).cmbconfacetoj = "2" Then
            '                    output = output + Class1.accum(i).txtvolumenumberto & "0006" & " "
            '                End If
            '            End If

            '            output = ((output + Class1.accum(i).txtjareaj & " ") + Class1.accum(i).txtffelcj & " ") + Class1.accum(i).txtrfelcj & " "
            '            If Class1.accum(i).cbmodpvj = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If

            '            If Class1.accum(i).cbccflj = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If
            '            output = output + Class1.accum(i).cmbhorstratj

            '            If Class1.accum(i).cbchokingj = "True" Then
            '                output = output & "0"
            '            Else
            '                output = output & "1"
            '            End If
            '            output = output + Class1.accum(i).cmbareachangej

            '            If Class1.accum(i).cbhomoj = "False" Then
            '                output = output & "0"
            '            Else
            '                output = output & "2"
            '            End If
            '            output = output + Class1.accum(i).cmbmfj & " "
            '            generate.WriteLine(output)

            '            ' CCC2200
            '            output = ((((Class1.accum(i).cmbhydroid + "2200 " + Class1.accum(i).txtlvt & " ") + Class1.accum(i).txtllt & " ") + Class1.accum(i).txtlslsp & " ") + Class1.accum(i).txtedss & " ") + Class1.accum(i).txttwt & " "
            '            If Class1.accum(i).cbhtf = "True" Then
            '                output = output & "0 "
            '            Else
            '                output = output & "1 "
            '            End If
            '            output = ((output + Class1.accum(i).txttd & " ") + Class1.accum(i).txttvhc & " ") + Class1.accum(i).txttn
            '            generate.WriteLine(output)
            '        End If
            '    Next
            '    ' _____________ HEAT STRUCTURE___________________
            '    For i As Integer = 0 To 99
            '        If Class1.heat(i, 1).cbbox1 = "True" Then
            '            generate.WriteLine("*======================================================================")
            '            'if(Class1.heat[i,1]
            '            generate.WriteLine("*               -----------------------------------                ")
            '            generate.WriteLine("*              |                                   |               ")
            '            generate.WriteLine("*              |          heat structures          |               ")
            '            generate.WriteLine("*              |                                   |               ")
            '            generate.WriteLine("*               -----------------------------------                ")


            '            generate.WriteLine("*======================================================================")
            '            generate.WriteLine("*                  heat structure " + Class1.heat(i, 1).cmbhstid)
            '            generate.WriteLine("*======================================================================")
            '            ' A8.1 Card 1CCCG000, General Heat Structure Data

            '            ' A8.1.1 General Heat Structure Data Card

            '            output = (("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "000 ") + Class1.heat(i, 1).txtnahswtg & " ") + Class1.heat(i, 1).txtnampftg & " "
            '            If Class1.heat(i, 1).cmbgt = "0" Then
            '                output = output & "1 "
            '            ElseIf Class1.heat(i, 1).cmbgt = "1" Then
            '                output = output & "2 "
            '            ElseIf Class1.heat(i, 1).cmbgt = "2" Then
            '                output = output & "3 "
            '            End If
            '            output = (((output + Class1.heat(i, 1).cmbssif & " ") + Class1.heat(i, 1).txtlbc & " ") + Class1.heat(i, 1).txtrcf & " ") + Class1.heat(i, 1).cmbbvi & " "
            '            ' CHECK
            '            If Class1.heat(i, 1).cmbmnai = "0" Then
            '                output = output & "2 "
            '            ElseIf Class1.heat(i, 1).cmbmnai = "1" Then
            '                output = output & "4 "
            '            ElseIf Class1.heat(i, 1).cmbmnai = "2" Then
            '                output = output & "8 "
            '            ElseIf Class1.heat(i, 1).cmbmnai = "3" Then
            '                output = output & "16 "
            '            ElseIf Class1.heat(i, 1).cmbmnai = "4" Then
            '                output = output & "32 "
            '            ElseIf Class1.heat(i, 1).cmbmnai = "5" Then
            '                output = output & "64 "
            '            ElseIf Class1.heat(i, 1).cmbmnai = "6" Then
            '                output = output & "128 "
            '            End If
            '            generate.WriteLine(output)

            '            ' A8.2 Card 1CCCG001, Gap Conductance Model Initial Gap Pressure Data
            '            output = (("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "001 ") + Class1.heat(i, 1).txtigip & " ") + Class1.heat(i, 1).txtgcrv
            '            generate.WriteLine(output)

            '            ' A8.3 Card 1CCCG003, Metal-Water Reaction Control Card
            '            output = ("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "003 ") + Class1.heat(i, 1).txtiotocos

            '            ' A8.4 Card 1CCCG004, Fuel Cladding Deformation Model Control Card
            '            If Class1.heat(i, 1).cbfcdmcc = "False" Then
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "004 " & "0"
            '            Else
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "003 " & "1"
            '            End If

            '            ' A8.5 Cards 1CCCG011 through 1CCCG099, Gap Deformation Data
            '            output = Nothing
            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            output = (((output + Class1.heat(i, 1).txtfsr & " ") + Class1.heat(i, 1).txtcsr & " ") + Class1.heat(i, 1).txtrddfgisd & " ") + Class1.heat(i, 1).txtrddcc
            '            ' 1 ";
            '            For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnahswtg) - 1
            '                If Class1.heat(i, j - 1).txtfsr <> Class1.heat(i, j).txtfsr OrElse Class1.heat(i, j - 1).txtcsr <> Class1.heat(i, j).txtcsr OrElse Class1.heat(i, j - 1).txtrddfgisd <> Class1.heat(i, j).txtrddfgisd OrElse Class1.heat(i, j - 1).txtrddcc <> Class1.heat(i, j).txtrddcc Then
            '                    If j = 2 Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                    output = (((output + Class1.heat(i, j).txtfsr & " ") + Class1.heat(i, j).txtcsr & " ") + Class1.heat(i, j).txtrddfgisd & " ") + Class1.heat(i, j).txtrddcc
            '                    kl = j
            '                    output = output & " " & kl.ToString() & " "
            '                    kk = j
            '                Else
            '                    If Class1.heat(i, j).txtfsr <> Class1.heat(i, j + 1).txtfsr OrElse Class1.heat(i, j).txtcsr <> Class1.heat(i, j + 1).txtcsr OrElse Class1.heat(i, j).txtrddfgisd <> Class1.heat(i, j + 1).txtrddfgisd OrElse Class1.heat(i, j).txtrddcc <> Class1.heat(i, j + 1).txtrddcc AndAlso first1 = True Then
            '                        output = output & " 1 "
            '                        first1 = False
            '                    End If
            '                End If
            '            Next
            '            If Class1.heat(i, 1).txtnahswtg = "2" AndAlso Class1.heat(i, 1).txtfsr <> Class1.heat(i, 2).txtfsr OrElse Class1.heat(i, 1).txtcsr <> Class1.heat(i, 2).txtcsr OrElse Class1.heat(i, 1).txtrddfgisd <> Class1.heat(i, 2).txtrddfgisd OrElse Class1.heat(i, 1).txtrddcc <> Class1.heat(i, 2).txtrddcc Then
            '                output = output & " 1 "
            '            End If

            '            If Class1.heat(i, 1).txtfsr <> Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtfsr OrElse Class1.heat(i, 1).txtcsr <> Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtcsr OrElse Class1.heat(i, 1).txtrddfgisd <> Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtrddfgisd OrElse Class1.heat(i, 1).txtrddcc <> Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtrddcc Then
            '                output = (((output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtfsr & " ") + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtcsr & " ") + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtrddfgisd & " ") + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtrddcc & " " & Class1.heat(i, 1).txtnahswtg.ToString()
            '            ElseIf first1 = True Then
            '                output = output & " " & Class1.heat(i, 1).txtnahswtg.ToString()
            '            ElseIf first1 = False Then
            '                output = (((output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtfsr & " ") + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtcsr & " ") + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtrddfgisd & " ") + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)).txtrddcc & " " & Class1.heat(i, 1).txtnahswtg.ToString()
            '            End If
            '            output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "011 " & output
            '            generate.WriteLine(output)

            '            ' A8.6 Card 1CCCG100, Heat Structure Mesh Flags
            '            output = ("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "100 ") + Class1.heat(i, 1).txtmlf & " "
            '            If Class1.heat(i, 1).cmbmff = "0" Then
            '                output = output & "1"
            '            Else
            '                output = output & "2"
            '            End If
            '            generate.WriteLine(output)

            '            ' A8.7 Cards 1CCCG101 through 1CCCG199, Heat Structure Mesh Interval Data (Radial)
            '            If Class1.heat(i, 1).cmbmff = "0" Then
            '                If Convert.ToInt32(Class1.heat(i, 1).clbformat1) > 0 Then
            '                    output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "101"

            '                    For k As Integer = 0 To Convert.ToInt32(Class1.heat(i, 1).clbformat1) - 1
            '                        output = (output & " ") + Class1.heat(i, k).lbformat1
            '                    Next
            '                    generate.WriteLine(output)
            '                End If
            '            Else
            '                output = Nothing
            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = output + Class1.heat(i, 1).txtmif2
            '                ' 1 
            '                For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 2
            '                    If Class1.heat(i, j - 1).txtmif2 <> Class1.heat(i, j).txtmif2 Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = output + Class1.heat(i, j).txtmif2
            '                        kl = j
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If Class1.heat(i, j).txtmif2 <> Class1.heat(i, j + 1).txtmif2 AndAlso first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                    End If
            '                Next
            '                If Class1.heat(i, 1).txtnampftg = "3" AndAlso Class1.heat(i, 1).txtmif2 <> Class1.heat(i, 2).txtmif2 Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.heat(i, 1).txtmif2 <> Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtmif2 Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtmif2 & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtmif2 & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                End If
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "101 " & output
            '                generate.WriteLine(output)
            '            End If

            '            ' A8.8 Cards 1CCCG201 through 1CCCG299, Heat StructureComposition Data (Radial)
            '            If Convert.ToInt32(Class1.heat(i, 1).txtmlf) = 0 Then
            '                output = Nothing
            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = output + Class1.heat(i, 1).txtcn
            '                ' 1 
            '                For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 2
            '                    If Class1.heat(i, j - 1).txtcn <> Class1.heat(i, j).txtcn Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = output + Class1.heat(i, j).txtcn
            '                        kl = j
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If Class1.heat(i, j).txtcn <> Class1.heat(i, j + 1).txtcn AndAlso first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                    End If
            '                Next
            '                If Class1.heat(i, 1).txtnampftg = "3" AndAlso Class1.heat(i, 1).txtcn <> Class1.heat(i, 2).txtcn Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.heat(i, 1).txtcn <> Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtcn Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtcn & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtcn & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                End If
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "201 " & output
            '                generate.WriteLine(output)
            '            End If

            '            ' A8.9 Card 1CCCG300, Fission Product Decay Heat Flag
            '            If Convert.ToBoolean(Class1.heat(i, 1).cbfpdhf) = True Then
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "300 " & "DKHEAT"
            '            End If

            '            ' A8.10 Cards 1CCCG301 through 1CCCG399, Heat Structure Source Distribution Data (Radial)
            '            If Convert.ToBoolean(Class1.heat(i, 1).cbfpdhf) = False Then
            '                output = Nothing
            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = output + Class1.heat(i, 1).txtsv
            '                ' 1 
            '                For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 2
            '                    If Class1.heat(i, j - 1).txtsv <> Class1.heat(i, j).txtsv Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = output + Class1.heat(i, j).txtsv
            '                        kl = j
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If Class1.heat(i, j).txtsv <> Class1.heat(i, j + 1).txtsv AndAlso first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                    End If
            '                Next
            '                If Class1.heat(i, 1).txtnampftg = "3" AndAlso Class1.heat(i, 1).txtsv <> Class1.heat(i, 2).txtsv Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.heat(i, 1).txtsv <> Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtsv Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtsv & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtsv & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                End If
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "301 " & output
            '                generate.WriteLine(output)
            '            Else
            '                output = Nothing
            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = output + Class1.heat(i, 1).txtgac
            '                ' 1 
            '                For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 2
            '                    If Class1.heat(i, j - 1).txtgac <> Class1.heat(i, j).txtgac Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = output + Class1.heat(i, j).txtgac
            '                        kl = j
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If Class1.heat(i, j).txtgac <> Class1.heat(i, j + 1).txtgac AndAlso first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                    End If
            '                Next
            '                If Class1.heat(i, 1).txtnampftg = "3" AndAlso Class1.heat(i, 1).txtgac <> Class1.heat(i, 2).txtgac Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.heat(i, 1).txtgac <> Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtgac Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtgac & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                ElseIf first1 = False Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).txtgac & " " & (Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1).ToString()
            '                End If
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "201 " & output
            '                generate.WriteLine(output)
            '            End If

            '            ' A8.11 Card 1CCCG400, Initial Temperature Flag
            '            If Class1.heat(i, 1).cmbitf = "0" Then
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "400 " & "0"
            '            ElseIf Class1.heat(i, 1).cmbitf = "1" Then
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "400 " & "-1"
            '            ElseIf Class1.heat(i, 1).cmbitf = "2" Then
            '                output = ("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "400 ") + Class1.heat(i, 1).txtitf
            '            End If
            '            generate.WriteLine(output)
            '            ' A8.12 Cards 1CCCG401 through 1CCCG499, Initial Temperature Data

            '            ' A8.12.1 Format 1 (Word 1 on Card 1CCCG400 = 0)
            '            If Class1.heat(i, 1).cmbitf = "0" Then
            '                output = Nothing
            '                kl = 0
            '                kk = 0
            '                first1 = True
            '                output = output + Class1.heat(i, 1).txttitdf1
            '                ' 1 
            '                For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1
            '                    If Class1.heat(i, j - 1).txttitdf1 <> Class1.heat(i, j).txttitdf1 Then
            '                        If j = 2 Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                        output = output + Class1.heat(i, j).txttitdf1
            '                        kl = j
            '                        output = output & " " & kl.ToString() & " "
            '                        kk = j
            '                    Else
            '                        If Class1.heat(i, j).txttitdf1 <> Class1.heat(i, j + 1).txttitdf1 AndAlso first1 = True Then
            '                            output = output & " 1 "
            '                            first1 = False
            '                        End If
            '                    End If
            '                Next
            '                If Class1.heat(i, 1).txtnampftg = "2" AndAlso Class1.heat(i, 1).txttitdf1 <> Class1.heat(i, 2).txttitdf1 Then
            '                    output = output & " 1 "
            '                End If

            '                If Class1.heat(i, 1).txttitdf1 <> Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg)).txttitdf1 Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg)).txttitdf1 & " " & Class1.heat(i, 1).txtnampftg.ToString()
            '                ElseIf first1 = True Then
            '                    output = output & " " & Class1.heat(i, 1).txtnampftg.ToString()
            '                ElseIf first1 = False Then
            '                    output = output + Class1.heat(i, Convert.ToInt32(Class1.heat(i, 1).txtnampftg)).txttitdf1 & " " & Class1.heat(i, 1).txtnampftg.ToString()
            '                End If
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "401 " & output
            '                generate.WriteLine(output)

            '                ' A8.12.2 Format 2 (Word 1 on Card 1CCCG400 = -1)
            '            ElseIf Class1.heat(i, 1).cmbitf = "1" Then
            '                For k As Integer = 1 To Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)
            '                    output = Nothing
            '                    kl = 0
            '                    kk = 0
            '                    first1 = True
            '                    output = output + Class1.ITDF2(i, k, 1)
            '                    ' 1 
            '                    For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnampftg) - 1
            '                        If Class1.ITDF2(i, k, j - 1) <> Class1.ITDF2(i, k, j) Then
            '                            If j = 2 Then
            '                                output = output & " 1 "
            '                                first1 = False
            '                            End If
            '                            output = output + Class1.ITDF2(i, k, j)
            '                            kl = j
            '                            output = output & " " & kl.ToString() & " "
            '                            kk = j
            '                        Else
            '                            If Class1.ITDF2(i, k, j) <> Class1.ITDF2(i, k, j + 1) AndAlso first1 = True Then
            '                                output = output & " 1 "
            '                                first1 = False
            '                            End If
            '                        End If
            '                    Next
            '                    If Class1.heat(i, 1).txtnampftg = "2" AndAlso Class1.ITDF2(i, k, 1) <> Class1.ITDF2(i, k, 2) Then
            '                        output = output & " 1 "
            '                    End If

            '                    If Class1.ITDF2(i, k, 1) <> Class1.ITDF2(i, k, Convert.ToInt32(Class1.heat(i, 1).txtnampftg)) Then
            '                        output = output + Class1.ITDF2(i, k, Convert.ToInt32(Class1.heat(i, 1).txtnampftg)) & " " & Class1.heat(i, 1).txtnampftg.ToString()
            '                    ElseIf first1 = True Then
            '                        output = output & " " & Class1.heat(i, 1).txtnampftg.ToString()
            '                    ElseIf first1 = False Then
            '                        output = output + Class1.ITDF2(i, k, Convert.ToInt32(Class1.heat(i, 1).txtnampftg)) & " " & Class1.heat(i, 1).txtnampftg.ToString()
            '                    End If
            '                    If k < 10 Then
            '                        output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "40" & k.ToString() & " " & output
            '                    Else
            '                        output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "4" & k.ToString() & " " & output
            '                    End If
            '                    generate.WriteLine(output)
            '                Next
            '            End If

            '            ' A8.13 Cards 1CCCG501 through 1CCCG599, Left Boundary Condition Cards

            '            ' Modified Sequential Expansion Format

            '            output = Nothing
            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            Dim flaglbc As Integer = 1

            '            Dim checklbc As Boolean = False
            '            For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)
            '                If Class1.word1lbc(i, j - 1) <> Class1.word1lbc(i, j) OrElse Class1.heat(i, j - 1).txtlbcincre <> Class1.heat(i, j).txtlbcincre OrElse Class1.heat(i, j - 1).txtlbcbct <> Class1.heat(i, j).txtlbcbct OrElse Class1.heat(i, j - 1).cmblbcsac <> Class1.heat(i, j).cmblbcsac OrElse Class1.heat(i, j - 1).txtlbcsaf <> Class1.heat(i, j).txtlbcsaf Then
            '                    flaglbc += 1
            '                    If checklbc = False Then
            '                        output = ((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "501" & " ") + Class1.word1lbc(i, 1) & " ") + Class1.heat(i, 1).txtlbcincre & " ") + Class1.heat(i, 1).txtlbcbct & " ") + Class1.heat(i, 1).cmblbcsac & " ") + Class1.heat(i, 1).txtlbcsaf & " 1"
            '                        generate.WriteLine(output)
            '                        checklbc = True
            '                    End If

            '                    If flaglbc <= 9 Then
            '                        output = ((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "50" & flaglbc.ToString() & " ") + Class1.word1lbc(i, j) & " ") + Class1.heat(i, j).txtlbcincre & " ") + Class1.heat(i, j).txtlbcbct & " ") + Class1.heat(i, j).cmblbcsac & " ") + Class1.heat(i, j).txtlbcsaf & " " & j.ToString()
            '                        generate.WriteLine(output)

            '                        first1 = False
            '                    ElseIf flaglbc > 9 Then
            '                        output = ((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "5" & flaglbc.ToString() & " ") + Class1.word1lbc(i, j) & " ") + Class1.heat(i, j).txtlbcincre & " ") + Class1.heat(i, j).txtlbcbct & " ") + Class1.heat(i, j).cmblbcsac & " ") + Class1.heat(i, j).txtlbcsaf & " " & j.ToString()
            '                        generate.WriteLine(output)

            '                        first1 = False
            '                    End If


            '                End If
            '            Next

            '            If flaglbc = 1 Then
            '                output = ((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "50" & flaglbc.ToString() & " ") + Class1.word1lbc(i, 1) & " ") + Class1.heat(i, 1).txtlbcincre & " ") + Class1.heat(i, 1).txtlbcbct & " ") + Class1.heat(i, 1).cmblbcsac & " ") + Class1.heat(i, 1).txtlbcsaf & " " & Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)
            '                generate.WriteLine(output)
            '            End If

            '            ' A8.14 Cards 1CCCG601 through 1CCCG699, Right Boundary Condition Cards

            '            ' Modified Sequential Expansion Format

            '            output = Nothing
            '            kl = 0
            '            kk = 0
            '            first1 = True
            '            Dim flagrbc As Integer = 1
            '            Dim checkrbc As Boolean = False
            '            'output = "1" + Class1.heat[i, 1].cmbhstid + Class1.heat[i, 1].txtgn + "60" + flagrbc.ToString() + " " + Class1.word1rbc[i, 1] + " " + Class1.heat[i, 1].txtrbcincre + " " + Class1.heat[i, 1].txtrbcbct + " " + Class1.heat[i, 1].cmbrbcsac + " " + Class1.heat[i, 1].txtrbcsaf + " 1";
            '            'generate.WriteLine(output);
            '            'flagrbc++;
            '            For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)
            '                If Class1.word1rbc(i, j - 1) <> Class1.word1rbc(i, j) OrElse Class1.heat(i, j - 1).txtrbcincre <> Class1.heat(i, j).txtrbcincre OrElse Class1.heat(i, j - 1).txtrbcbct <> Class1.heat(i, j).txtrbcbct OrElse Class1.heat(i, j - 1).cmbrbcsac <> Class1.heat(i, j).cmbrbcsac OrElse Class1.heat(i, j - 1).txtrbcsaf <> Class1.heat(i, j).txtrbcsaf Then
            '                    flagrbc += 1
            '                    If checkrbc = False Then
            '                        output = ((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "601" & " ") + Class1.word1rbc(i, 1) & " ") + Class1.heat(i, 1).txtrbcincre & " ") + Class1.heat(i, 1).txtrbcbct & " ") + Class1.heat(i, 1).cmbrbcsac & " ") + Class1.heat(i, 1).txtrbcsaf & " 1"
            '                        generate.WriteLine(output)
            '                        checkrbc = True
            '                    End If
            '                    If flagrbc <= 9 Then
            '                        output = ((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "60" & flagrbc.ToString() & " ") + Class1.word1rbc(i, j) & " ") + Class1.heat(i, j).txtrbcincre & " ") + Class1.heat(i, j).txtrbcbct & " ") + Class1.heat(i, j).cmbrbcsac & " ") + Class1.heat(i, j).txtrbcsaf & " " & j.ToString()
            '                        generate.WriteLine(output)
            '                        'flagrbc++;
            '                        first1 = False
            '                    ElseIf flagrbc > 9 Then
            '                        output = ((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "6" & flagrbc.ToString() & " ") + Class1.word1rbc(i, j) & " ") + Class1.heat(i, j).txtrbcincre & " ") + Class1.heat(i, j).txtrbcbct & " ") + Class1.heat(i, j).cmbrbcsac & " ") + Class1.heat(i, j).txtrbcsaf & " " & j.ToString()
            '                        generate.WriteLine(output)
            '                        'flagrbc++;
            '                        first1 = False
            '                    End If
            '                End If
            '            Next
            '            If flagrbc = 1 Then
            '                output = (((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "60" & flagrbc.ToString() & " ") + Class1.word1rbc(i, 1) & " ") + Class1.heat(i, 1).txtrbcincre & " ") + Class1.heat(i, 1).txtrbcbct & " ") + Class1.heat(i, 1).cmbrbcsac & " ") + Class1.heat(i, 1).txtrbcsaf & " ") + Class1.heat(i, 1).txtnahswtg
            '                generate.WriteLine(output)
            '            End If
            '            ' A8.15 Cards 1CCCG701 through 1CCCG799, Source Data Cards

            '            output = Nothing
            '            Dim flagsdc As Integer = 1
            '            Dim checksdc As Boolean = False
            '            'output = "1" + Class1.heat[i, 1].cmbhstid + Class1.heat[i, 1].txtgn + "70" + flagsdc.ToString() + " " + Class1.heat[i, 1].txtst + " " + Class1.heat[i, 1].txtism + " " + Class1.heat[i, 1].txtdmhmleft + " " + Class1.heat[i, 1].txtdmhmright + " 1";
            '            'generate.WriteLine(output);
            '            'flagsdc++;
            '            For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)
            '                If Class1.heat(i, j - 1).txtst <> Class1.heat(i, j).txtst OrElse Class1.heat(i, j - 1).txtism <> Class1.heat(i, j).txtism OrElse Class1.heat(i, j - 1).txtdmhmleft <> Class1.heat(i, j).txtdmhmleft OrElse Class1.heat(i, j - 1).txtdmhmright <> Class1.heat(i, j).txtdmhmright Then
            '                    flagsdc += 1
            '                    If checksdc = False Then
            '                        output = (((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "701" & " ") + Class1.heat(i, 1).txtst & " ") + Class1.heat(i, 1).txtism & " ") + Class1.heat(i, 1).txtdmhmleft & " ") + Class1.heat(i, 1).txtdmhmright & " 1"
            '                        generate.WriteLine(output)
            '                        checksdc = True
            '                    End If
            '                    If flagsdc <= 9 Then
            '                        output = (((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "70" & flagsdc.ToString() & " ") + Class1.heat(i, j).txtst & " ") + Class1.heat(i, j).txtism & " ") + Class1.heat(i, j).txtdmhmleft & " ") + Class1.heat(i, j).txtdmhmright & " " & j.ToString()
            '                        'flagsdc++;
            '                        generate.WriteLine(output)
            '                    ElseIf flagsdc > 9 Then
            '                        output = (((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "7" & flagsdc.ToString() & " ") + Class1.heat(i, j).txtst & " ") + Class1.heat(i, j).txtism & " ") + Class1.heat(i, j).txtdmhmleft & " ") + Class1.heat(i, j).txtdmhmright & " " & j.ToString()
            '                        'flagsdc++;
            '                        generate.WriteLine(output)
            '                    End If
            '                End If
            '            Next
            '            If flagsdc = 1 Then
            '                output = ((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "70" & flagsdc.ToString() & " ") + Class1.heat(i, 1).txtst & " ") + Class1.heat(i, 1).txtism & " ") + Class1.heat(i, 1).txtdmhmleft & " ") + Class1.heat(i, 1).txtdmhmright & " ") + Class1.heat(i, 1).txtnahswtg
            '                generate.WriteLine(output)
            '            End If


            '            '
            '            '                        output = null;
            '            '                        kl = 0; kk = 0; first1 = true;
            '            '                        output = output + Class1.heat[i, 1].txtst + " " + Class1.heat[i, 1].txtism + " " + Class1.heat[i, 1].txtdmhmleft + " " + Class1.heat[i, 1].txtdmhmright;// 1 ";
            '            '                        for (int j = 2; j < Convert.ToInt32(Class1.heat[i, 1].txtnahswtg); j++)
            '            '                        {
            '            '                            if (Class1.heat[i, j - 1].txtst != Class1.heat[i, j].txtst || Class1.heat[i, j - 1].txtism != Class1.heat[i, j].txtism || Class1.heat[i, j - 1].txtdmhmleft != Class1.heat[i, j].txtdmhmleft || Class1.heat[i, j - 1].txtdmhmright != Class1.heat[i, j].txtdmhmright)
            '            '                            {
            '            '                                if (j == 2)
            '            '                                {
            '            '                                    output = output + " 1 ";
            '            '                                    first1 = false;
            '            '                                }
            '            '                                output = output + Class1.heat[i, j].txtst + " " + Class1.heat[i, j].txtism + " " + Class1.heat[i, j].txtdmhmleft + " " + Class1.heat[i, j].txtdmhmright;
            '            '                                kl = j;
            '            '                                output = output + " " + kl.ToString() + " ";
            '            '                                kk = j;
            '            '                            }
            '            '                            else
            '            '                            {
            '            '                                if (Class1.heat[i, j].txtst != Class1.heat[i, j+1].txtst || Class1.heat[i, j].txtism != Class1.heat[i, j+1].txtism || Class1.heat[i, j].txtdmhmleft != Class1.heat[i, j+1].txtdmhmleft || Class1.heat[i, j].txtdmhmright != Class1.heat[i, j+1].txtdmhmright && first1 == true)
            '            '                                {
            '            '                                    output = output + " 1 ";
            '            '                                    first1 = false;
            '            '                                }
            '            '                            }
            '            '                        }
            '            '                        if (Class1.heat[i, 1].txtnahswtg == "2" && Class1.heat[i, 1].txtst != Class1.heat[i, 2].txtst || Class1.heat[i, 1].txtism != Class1.heat[i, 2].txtism || Class1.heat[i, 1].txtdmhmleft != Class1.heat[i, 2].txtdmhmleft || Class1.heat[i, 1].txtdmhmright != Class1.heat[i, 2].txtdmhmright)
            '            '                            output = output + " 1 ";
            '            '
            '            '                        if (Class1.heat[i, 1].txtst != Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtst || Class1.heat[i, 1].txtism != Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtism || Class1.heat[i, 1].txtdmhmleft != Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtdmhmleft || Class1.heat[i, 1].txtdmhmright != Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtdmhmright)
            '            '                            output = output + Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtst + " " + Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtism + " " + Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtdmhmleft + " " + Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtdmhmright + " " + Class1.heat[i, 1].txtnahswtg.ToString();
            '            '                        else if (first1 == true)
            '            '                            output = output + " " + Class1.heat[i, 1].txtnahswtg.ToString();
            '            '                        else if (first1 == false)
            '            '                            output = output + Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtst + " " + Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtism + " " + Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtdmhmleft + " " + Class1.heat[i, Convert.ToInt32(Class1.heat[i, 1].txtnahswtg)].txtdmhmright + " " + Class1.heat[i, 1].txtnahswtg.ToString();
            '            '                        output = "1" + Class1.heat[i, 1].cmbhstid + Class1.heat[i, 1].txtgn + "701 " + output;
            '            '                        generate.WriteLine(output);


            '            ' A8.16 Card 1CCCG800, Additional Left Boundary Option
            '            If Class1.heat(i, 1).cmboptionalb = "0" Then
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "800 " & "0"
            '            Else
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "800 " & "1"
            '            End If
            '            generate.WriteLine(output)

            '            ' A8.17 Cards 1CCCG801 through 1CCCG899, Additional Left Boundary Cards

            '            If Class1.heat(i, 1).cmboptionalb = "0" Then
            '                output = Nothing
            '                Dim flagalb0 As Integer = 1
            '                Dim checkalb0 As Boolean = False
            '                'output = "1" + Class1.heat[i, 1].cmbhstid + Class1.heat[i, 1].txtgn + "80" + flagalb0.ToString() + " " + Class1.heat[i, 1].txththdalb + " " + Class1.heat[i, 1].txthlfalb + " " + Class1.heat[i, 1].txthlralb + " " + Class1.heat[i, 1].txtgslfalb + " " + Class1.heat[i, 1].txtgslralb + " " + Class1.heat[i, 1].txtglcfalb + " " + Class1.heat[i, 1].txtglcralb + " " + Class1.heat[i, 1].txtlbfalb + " 1";
            '                'generate.WriteLine(output);
            '                'flagalb0++;
            '                For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)
            '                    If Class1.heat(i, j - 1).txththdalb <> Class1.heat(i, j).txththdalb OrElse Class1.heat(i, j - 1).txthlfalb <> Class1.heat(i, j).txthlfalb OrElse Class1.heat(i, j - 1).txthlralb <> Class1.heat(i, j).txthlralb OrElse Class1.heat(i, j - 1).txtgslfalb <> Class1.heat(i, j).txtgslfalb OrElse Class1.heat(i, j - 1).txtgslralb <> Class1.heat(i, j).txtgslralb OrElse Class1.heat(i, j - 1).txtglcfalb <> Class1.heat(i, j).txtglcfalb OrElse Class1.heat(i, j - 1).txtglcralb <> Class1.heat(i, j).txtglcralb OrElse Class1.heat(i, j - 1).txtlbfalb <> Class1.heat(i, j).txtlbfalb Then
            '                        flagalb0 += 1
            '                        If checkalb0 = False Then
            '                            output = (((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "801" & " ") + Class1.heat(i, 1).txththdalb & " ") + Class1.heat(i, 1).txthlfalb & " ") + Class1.heat(i, 1).txthlralb & " ") + Class1.heat(i, 1).txtgslfalb & " ") + Class1.heat(i, 1).txtgslralb & " ") + Class1.heat(i, 1).txtglcfalb & " ") + Class1.heat(i, 1).txtglcralb & " ") + Class1.heat(i, 1).txtlbfalb & " 1"
            '                            generate.WriteLine(output)
            '                            checkalb0 = True
            '                        End If
            '                        If flagalb0 <= 9 Then
            '                            output = (((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "80" & flagalb0.ToString() & " ") + Class1.heat(i, j).txththdalb & " ") + Class1.heat(i, j).txthlfalb & " ") + Class1.heat(i, j).txthlralb & " ") + Class1.heat(i, j).txtgslfalb & " ") + Class1.heat(i, j).txtgslralb & " ") + Class1.heat(i, j).txtglcfalb & " ") + Class1.heat(i, j).txtglcralb & " ") + Class1.heat(i, j).txtlbfalb & " " & j.ToString()
            '                            'flagalb0++;
            '                            generate.WriteLine(output)
            '                        ElseIf flagalb0 > 9 Then
            '                            output = (((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "8" & flagalb0.ToString() & " ") + Class1.heat(i, j).txththdalb & " ") + Class1.heat(i, j).txthlfalb & " ") + Class1.heat(i, j).txthlralb & " ") + Class1.heat(i, j).txtgslfalb & " ") + Class1.heat(i, j).txtgslralb & " ") + Class1.heat(i, j).txtglcfalb & " ") + Class1.heat(i, j).txtglcralb & " ") + Class1.heat(i, j).txtlbfalb & " " & j.ToString()
            '                            'flagalb0++;
            '                            generate.WriteLine(output)
            '                        End If
            '                    End If
            '                Next
            '                If flagalb0 = 1 Then
            '                    output = ((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "80" & flagalb0.ToString() & " ") + Class1.heat(i, 1).txththdalb & " ") + Class1.heat(i, 1).txthlfalb & " ") + Class1.heat(i, 1).txthlralb & " ") + Class1.heat(i, 1).txtgslfalb & " ") + Class1.heat(i, 1).txtgslralb & " ") + Class1.heat(i, 1).txtglcfalb & " ") + Class1.heat(i, 1).txtglcralb & " ") + Class1.heat(i, 1).txtlbfalb & " ") + Class1.heat(i, 1).txtnahswtg
            '                    generate.WriteLine(output)
            '                End If


            '            ElseIf Class1.heat(i, 1).cmboptionalb = "1" Then
            '                output = Nothing
            '                Dim flagalb1 As Integer = 1
            '                Dim checkalb1 As Boolean = False
            '                'output = "1" + Class1.heat[i, 1].cmbhstid + Class1.heat[i, 1].txtgn + "80" + flagalb1.ToString() + " " + Class1.heat[i, 1].txththdalb + " " + Class1.heat[i, 1].txthlfalb + " " + Class1.heat[i, 1].txthlralb + " " + Class1.heat[i, 1].txtgslfalb + " " + Class1.heat[i, 1].txtgslralb + " " + Class1.heat[i, 1].txtglcfalb + " " + Class1.heat[i, 1].txtglcralb + " " + Class1.heat[i, 1].txtlbfalb + " " + Class1.heat[i, 1].txtnclalb + " " + Class1.heat[i, 1].txtrtp2dralb + " " + Class1.heat[i, 1].txtffalb + " 1";
            '                'generate.WriteLine(output);
            '                'flagalb1++;
            '                For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)
            '                    If Class1.heat(i, j - 1).txththdalb <> Class1.heat(i, j).txththdalb OrElse Class1.heat(i, j - 1).txthlfalb <> Class1.heat(i, j).txthlfalb OrElse Class1.heat(i, j - 1).txthlralb <> Class1.heat(i, j).txthlralb OrElse Class1.heat(i, j - 1).txtgslfalb <> Class1.heat(i, j).txtgslfalb OrElse Class1.heat(i, j - 1).txtgslralb <> Class1.heat(i, j).txtgslralb OrElse Class1.heat(i, j - 1).txtglcfalb <> Class1.heat(i, j).txtglcfalb OrElse Class1.heat(i, j - 1).txtglcralb <> Class1.heat(i, j).txtglcralb OrElse Class1.heat(i, j - 1).txtlbfalb <> Class1.heat(i, j).txtlbfalb OrElse Class1.heat(i, j - 1).txtnclalb <> Class1.heat(i, j).txtnclalb OrElse Class1.heat(i, j - 1).txtrtp2dralb <> Class1.heat(i, j).txtrtp2dralb OrElse Class1.heat(i, j - 1).txtffalb <> Class1.heat(i, j).txtffalb Then
            '                        flagalb1 += 1
            '                        If checkalb1 = False Then
            '                            output = ((((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "801" & " ") + Class1.heat(i, 1).txththdalb & " ") + Class1.heat(i, 1).txthlfalb & " ") + Class1.heat(i, 1).txthlralb & " ") + Class1.heat(i, 1).txtgslfalb & " ") + Class1.heat(i, 1).txtgslralb & " ") + Class1.heat(i, 1).txtglcfalb & " ") + Class1.heat(i, 1).txtglcralb & " ") + Class1.heat(i, 1).txtlbfalb & " ") + Class1.heat(i, 1).txtnclalb & " ") + Class1.heat(i, 1).txtrtp2dralb & " ") + Class1.heat(i, 1).txtffalb & " 1"
            '                            generate.WriteLine(output)
            '                            checkalb1 = True
            '                        End If
            '                        If flagalb1 <= 9 Then
            '                            output = ((((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "80" & flagalb1.ToString() & " ") + Class1.heat(i, j).txththdalb & " ") + Class1.heat(i, j).txthlfalb & " ") + Class1.heat(i, j).txthlralb & " ") + Class1.heat(i, j).txtgslfalb & " ") + Class1.heat(i, j).txtgslralb & " ") + Class1.heat(i, j).txtglcfalb & " ") + Class1.heat(i, j).txtglcralb & " ") + Class1.heat(i, j).txtlbfalb & " ") + Class1.heat(i, 1).txtnclalb & " ") + Class1.heat(i, 1).txtrtp2dralb & " ") + Class1.heat(i, 1).txtffalb & " " & j.ToString()
            '                            'flagalb1++;
            '                            generate.WriteLine(output)
            '                        ElseIf flagalb1 > 9 Then
            '                            output = ((((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "8" & flagalb1.ToString() & " ") + Class1.heat(i, j).txththdalb & " ") + Class1.heat(i, j).txthlfalb & " ") + Class1.heat(i, j).txthlralb & " ") + Class1.heat(i, j).txtgslfalb & " ") + Class1.heat(i, j).txtgslralb & " ") + Class1.heat(i, j).txtglcfalb & " ") + Class1.heat(i, j).txtglcralb & " ") + Class1.heat(i, j).txtlbfalb & " ") + Class1.heat(i, 1).txtnclalb & " ") + Class1.heat(i, 1).txtrtp2dralb & " ") + Class1.heat(i, 1).txtffalb & " " & j.ToString()
            '                            'flagalb1++;
            '                            generate.WriteLine(output)
            '                        End If
            '                    End If
            '                Next
            '                If flagalb1 = 1 Then
            '                    output = ((((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "80" & flagalb1.ToString() & " ") + Class1.heat(i, 1).txththdalb & " ") + Class1.heat(i, 1).txthlfalb & " ") + Class1.heat(i, 1).txthlralb & " ") + Class1.heat(i, 1).txtgslfalb & " ") + Class1.heat(i, 1).txtgslralb & " ") + Class1.heat(i, 1).txtglcfalb & " ") + Class1.heat(i, 1).txtglcralb & " ") + Class1.heat(i, 1).txtlbfalb & " ") + Class1.heat(i, 1).txtnclalb & " ") + Class1.heat(i, 1).txtrtp2dralb & " ") + Class1.heat(i, 1).txtffalb & " 1"
            '                    generate.WriteLine(output)
            '                End If
            '            End If

            '            ' ----------------------------------------------

            '            ' A8.18 Card 1CCCG900, Additional Right Boundary Option
            '            If Class1.heat(i, 1).cmboptionarb = "0" Then
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "900 " & "0"
            '            Else
            '                output = "1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "900 " & "1"
            '            End If
            '            generate.WriteLine(output)

            '            ' A8.19 Cards 1CCCG901 through 1CCCG999, Additional Right Boundary Cards

            '            If Class1.heat(i, 1).cmboptionarb = "0" Then
            '                output = Nothing
            '                Dim flagarb0 As Integer = 1
            '                Dim checkarb0 As Boolean = False
            '                'output = "1" + Class1.heat[i, 1].cmbhstid + Class1.heat[i, 1].txtgn + "90" + flagarb0.ToString() + " " + Class1.heat[i, 1].txththdarb + " " + Class1.heat[i, 1].txthlfarb + " " + Class1.heat[i, 1].txthlrarb + " " + Class1.heat[i, 1].txtgslfarb + " " + Class1.heat[i, 1].txtgslrarb + " " + Class1.heat[i, 1].txtglcfarb + " " + Class1.heat[i, 1].txtglcrarb + " " + Class1.heat[i, 1].txtlbfarb + " 1";
            '                'generate.WriteLine(output);
            '                'flagarb0++;
            '                For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)
            '                    If Class1.heat(i, j - 1).txththdarb <> Class1.heat(i, j).txththdarb OrElse Class1.heat(i, j - 1).txthlfarb <> Class1.heat(i, j).txthlfarb OrElse Class1.heat(i, j - 1).txthlrarb <> Class1.heat(i, j).txthlrarb OrElse Class1.heat(i, j - 1).txtgslfarb <> Class1.heat(i, j).txtgslfarb OrElse Class1.heat(i, j - 1).txtgslrarb <> Class1.heat(i, j).txtgslrarb OrElse Class1.heat(i, j - 1).txtglcfarb <> Class1.heat(i, j).txtglcfarb OrElse Class1.heat(i, j - 1).txtglcrarb <> Class1.heat(i, j).txtglcrarb OrElse Class1.heat(i, j - 1).txtlbfarb <> Class1.heat(i, j).txtlbfarb Then
            '                        flagarb0 += 1
            '                        If checkarb0 = False Then
            '                            output = (((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "901" & " ") + Class1.heat(i, 1).txththdarb & " ") + Class1.heat(i, 1).txthlfarb & " ") + Class1.heat(i, 1).txthlrarb & " ") + Class1.heat(i, 1).txtgslfarb & " ") + Class1.heat(i, 1).txtgslrarb & " ") + Class1.heat(i, 1).txtglcfarb & " ") + Class1.heat(i, 1).txtglcrarb & " ") + Class1.heat(i, 1).txtlbfarb & " 1"
            '                            generate.WriteLine(output)
            '                            checkarb0 = True
            '                        End If

            '                        If flagarb0 <= 9 Then
            '                            output = (((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "90" & flagarb0.ToString() & " ") + Class1.heat(i, j).txththdarb & " ") + Class1.heat(i, j).txthlfarb & " ") + Class1.heat(i, j).txthlrarb & " ") + Class1.heat(i, j).txtgslfarb & " ") + Class1.heat(i, j).txtgslrarb & " ") + Class1.heat(i, j).txtglcfarb & " ") + Class1.heat(i, j).txtglcrarb & " ") + Class1.heat(i, j).txtlbfarb & " " & j.ToString()
            '                            'flagarb0++;
            '                            generate.WriteLine(output)
            '                        ElseIf flagarb0 > 9 Then
            '                            output = (((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "9" & flagarb0.ToString() & " ") + Class1.heat(i, j).txththdarb & " ") + Class1.heat(i, j).txthlfarb & " ") + Class1.heat(i, j).txthlrarb & " ") + Class1.heat(i, j).txtgslfarb & " ") + Class1.heat(i, j).txtgslrarb & " ") + Class1.heat(i, j).txtglcfarb & " ") + Class1.heat(i, j).txtglcrarb & " ") + Class1.heat(i, j).txtlbfarb & " " & j.ToString()
            '                            'flagarb0++;
            '                            generate.WriteLine(output)
            '                        End If
            '                    End If
            '                Next
            '                If flagarb0 = 1 Then
            '                    output = ((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "90" & flagarb0.ToString() & " ") + Class1.heat(i, 1).txththdarb & " ") + Class1.heat(i, 1).txthlfarb & " ") + Class1.heat(i, 1).txthlrarb & " ") + Class1.heat(i, 1).txtgslfarb & " ") + Class1.heat(i, 1).txtgslrarb & " ") + Class1.heat(i, 1).txtglcfarb & " ") + Class1.heat(i, 1).txtglcrarb & " ") + Class1.heat(i, 1).txtlbfarb & " ") + Class1.heat(i, 1).txtnahswtg
            '                    generate.WriteLine(output)
            '                End If


            '            ElseIf Class1.heat(i, 1).cmboptionarb = "1" Then
            '                output = Nothing
            '                Dim flagarb1 As Integer = 1
            '                Dim checkarb1 As Boolean = False
            '                'output = "1" + Class1.heat[i, 1].cmbhstid + Class1.heat[i, 1].txtgn + "90" + flagarb1.ToString() + " " + Class1.heat[i, 1].txththdarb + " " + Class1.heat[i, 1].txthlfarb + " " + Class1.heat[i, 1].txthlrarb + " " + Class1.heat[i, 1].txtgslfarb + " " + Class1.heat[i, 1].txtgslrarb + " " + Class1.heat[i, 1].txtglcfarb + " " + Class1.heat[i, 1].txtglcrarb + " " + Class1.heat[i, 1].txtlbfarb + " " + Class1.heat[i, 1].txtnclarb + " " + Class1.heat[i, 1].txtrtp2drarb + " " + Class1.heat[i, 1].txtffarb + " 1";
            '                'generate.WriteLine(output);
            '                'flagarb1++;
            '                For j As Integer = 2 To Convert.ToInt32(Class1.heat(i, 1).txtnahswtg)
            '                    If Class1.heat(i, j - 1).txththdarb <> Class1.heat(i, j).txththdarb OrElse Class1.heat(i, j - 1).txthlfarb <> Class1.heat(i, j).txthlfarb OrElse Class1.heat(i, j - 1).txthlrarb <> Class1.heat(i, j).txthlrarb OrElse Class1.heat(i, j - 1).txtgslfarb <> Class1.heat(i, j).txtgslfarb OrElse Class1.heat(i, j - 1).txtgslrarb <> Class1.heat(i, j).txtgslrarb OrElse Class1.heat(i, j - 1).txtglcfarb <> Class1.heat(i, j).txtglcfarb OrElse Class1.heat(i, j - 1).txtglcrarb <> Class1.heat(i, j).txtglcrarb OrElse Class1.heat(i, j - 1).txtlbfarb <> Class1.heat(i, j).txtlbfarb OrElse Class1.heat(i, j - 1).txtnclarb <> Class1.heat(i, j).txtnclarb OrElse Class1.heat(i, j - 1).txtrtp2drarb <> Class1.heat(i, j).txtrtp2drarb OrElse Class1.heat(i, j - 1).txtffarb <> Class1.heat(i, j).txtffarb Then
            '                        flagarb1 += 1
            '                        If checkarb1 = False Then
            '                            output = ((((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "901" & " ") + Class1.heat(i, 1).txththdarb & " ") + Class1.heat(i, 1).txthlfarb & " ") + Class1.heat(i, 1).txthlrarb & " ") + Class1.heat(i, 1).txtgslfarb & " ") + Class1.heat(i, 1).txtgslrarb & " ") + Class1.heat(i, 1).txtglcfarb & " ") + Class1.heat(i, 1).txtglcrarb & " ") + Class1.heat(i, 1).txtlbfarb & " ") + Class1.heat(i, 1).txtnclarb & " ") + Class1.heat(i, 1).txtrtp2drarb & " ") + Class1.heat(i, 1).txtffarb & " 1"
            '                            generate.WriteLine(output)
            '                            checkarb1 = True
            '                        End If

            '                        If flagarb1 <= 9 Then
            '                            output = ((((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "90" & flagarb1.ToString() & " ") + Class1.heat(i, j).txththdarb & " ") + Class1.heat(i, j).txthlfarb & " ") + Class1.heat(i, j).txthlrarb & " ") + Class1.heat(i, j).txtgslfarb & " ") + Class1.heat(i, j).txtgslrarb & " ") + Class1.heat(i, j).txtglcfarb & " ") + Class1.heat(i, j).txtglcrarb & " ") + Class1.heat(i, j).txtlbfarb & " ") + Class1.heat(i, 1).txtnclarb & " ") + Class1.heat(i, 1).txtrtp2drarb & " ") + Class1.heat(i, 1).txtffarb & " " & j.ToString()
            '                            'flagarb1++;
            '                            generate.WriteLine(output)
            '                        ElseIf flagarb1 > 9 Then
            '                            output = ((((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "9" & flagarb1.ToString() & " ") + Class1.heat(i, j).txththdarb & " ") + Class1.heat(i, j).txthlfarb & " ") + Class1.heat(i, j).txthlrarb & " ") + Class1.heat(i, j).txtgslfarb & " ") + Class1.heat(i, j).txtgslrarb & " ") + Class1.heat(i, j).txtglcfarb & " ") + Class1.heat(i, j).txtglcrarb & " ") + Class1.heat(i, j).txtlbfarb & " ") + Class1.heat(i, 1).txtnclarb & " ") + Class1.heat(i, 1).txtrtp2drarb & " ") + Class1.heat(i, 1).txtffarb & " " & j.ToString()
            '                            'flagarb1++;
            '                            generate.WriteLine(output)
            '                        End If
            '                    End If
            '                Next
            '                If flagarb1 = 1 Then
            '                    output = ((((((((((("1" + Class1.heat(i, 1).cmbhstid + Class1.heat(i, 1).txtgn & "90" & flagarb1.ToString() & " ") + Class1.heat(i, 1).txththdarb & " ") + Class1.heat(i, 1).txthlfarb & " ") + Class1.heat(i, 1).txthlrarb & " ") + Class1.heat(i, 1).txtgslfarb & " ") + Class1.heat(i, 1).txtgslrarb & " ") + Class1.heat(i, 1).txtglcfarb & " ") + Class1.heat(i, 1).txtglcrarb & " ") + Class1.heat(i, 1).txtlbfarb & " ") + Class1.heat(i, 1).txtnclarb & " ") + Class1.heat(i, 1).txtrtp2drarb & " ") + Class1.heat(i, 1).txtffarb & " 1"
            '                    generate.WriteLine(output)
            '                End If
            '            End If





            '            ' _______________________________________________
            '        End If
            '    Next




            '    generate.WriteLine(". END of code")
            '    ' file code colse




















            '    ' end of writing code******************************************************************************
            '    generate.Close()
        End If

    End Sub



    
    
    
End Class

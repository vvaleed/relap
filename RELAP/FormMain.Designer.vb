Imports System.IO
Imports System.Runtime.Serialization.Formatters
Imports Infralution.Localization
Imports System.Globalization

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NovoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NovoEstudoDeRegressãoDeDadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseAllToolstripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferênciasDoRELAPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarBarraDeFerramentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateInputFileOnlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateInputFileAndRunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.RELAPNaInternetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlogDeDesenvolvimentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WikiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RastreamentoDeBugsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrarTiposCOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DonateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.SaveAllToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.BgLoadComp = New System.ComponentModel.BackgroundWorker()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.bgLoadFile = New System.ComponentModel.BackgroundWorker()
        Me.bgSaveFile = New System.ComponentModel.BackgroundWorker()
        Me.bgLoadNews = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslupd = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusBarTextProvider1 = New EWSoftware.StatusBarText.StatusBarTextProvider(Me.components)
        Me.TimerBackup = New System.Windows.Forms.Timer(Me.components)
        Me.bgSaveBackup = New System.ComponentModel.BackgroundWorker()
        Me.CultureManager1 = New Infralution.Localization.CultureManager(Me.components)
        Me.sfdUpdater = New System.Windows.Forms.SaveFileDialog()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.SaveStudyDlg = New System.Windows.Forms.SaveFileDialog()
        Me.SaveRegStudyDlg = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowItemReorder = True
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.VerToolStripMenuItem, Me.RunToolStripMenuItem, Me.WindowsMenu, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.HelpProvider1.SetShowHelp(Me.MenuStrip1, True)
        Me.MenuStrip1.Size = New System.Drawing.Size(1002, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NovoToolStripMenuItem, Me.OpenToolStripMenuItem, Me.toolStripSeparator, Me.SaveToolStripMenuItem, Me.SaveAllToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator2, Me.CloseAllToolstripMenuItem, Me.toolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NovoToolStripMenuItem
        '
        Me.NovoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem, Me.NovoEstudoDeRegressãoDeDadosToolStripMenuItem})
        Me.NovoToolStripMenuItem.Name = "NovoToolStripMenuItem"
        Me.NovoToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.NovoToolStripMenuItem.Text = "New"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.page_white
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.NewToolStripMenuItem.Text = "&Steady-state Simulation"
        Me.NewToolStripMenuItem.Visible = False
        '
        'NovoEstudoDoCriadorDeComponentesToolStripMenuItem
        '
        Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.page_white
        Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem.Name = "NovoEstudoDoCriadorDeComponentesToolStripMenuItem"
        Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem.Text = "Compound Creator Study"
        Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem.Visible = False
        '
        'NovoEstudoDeRegressãoDeDadosToolStripMenuItem
        '
        Me.NovoEstudoDeRegressãoDeDadosToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.page_white
        Me.NovoEstudoDeRegressãoDeDadosToolStripMenuItem.Name = "NovoEstudoDeRegressãoDeDadosToolStripMenuItem"
        Me.NovoEstudoDeRegressãoDeDadosToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.NovoEstudoDeRegressãoDeDadosToolStripMenuItem.Text = "Data Regression Study"
        Me.NovoEstudoDeRegressãoDeDadosToolStripMenuItem.Visible = False
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.folder_page_white
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(192, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Enabled = False
        Me.SaveToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.page_save
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'SaveAllToolStripMenuItem
        '
        Me.SaveAllToolStripMenuItem.Enabled = False
        Me.SaveAllToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.disk_multiple
        Me.SaveAllToolStripMenuItem.Name = "SaveAllToolStripMenuItem"
        Me.SaveAllToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SaveAllToolStripMenuItem.Text = "Save All"
        Me.SaveAllToolStripMenuItem.Visible = False
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Enabled = False
        Me.SaveAsToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.disk
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save &As..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(192, 6)
        '
        'CloseAllToolstripMenuItem
        '
        Me.CloseAllToolstripMenuItem.Enabled = False
        Me.CloseAllToolstripMenuItem.Image = Global.RELAP.My.Resources.Resources.cross
        Me.CloseAllToolstripMenuItem.Name = "CloseAllToolstripMenuItem"
        Me.CloseAllToolstripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.CloseAllToolstripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.CloseAllToolstripMenuItem.Text = "Close All"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(192, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.undo_16
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.ExitToolStripMenuItem.Text = "Exi&t RELAP"
        '
        'VerToolStripMenuItem
        '
        Me.VerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreferênciasDoRELAPToolStripMenuItem, Me.MostrarBarraDeFerramentasToolStripMenuItem})
        Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
        Me.VerToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.VerToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.VerToolStripMenuItem.Text = "&Settings"
        '
        'PreferênciasDoRELAPToolStripMenuItem
        '
        Me.PreferênciasDoRELAPToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.application_edit
        Me.PreferênciasDoRELAPToolStripMenuItem.Name = "PreferênciasDoRELAPToolStripMenuItem"
        Me.PreferênciasDoRELAPToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.PreferênciasDoRELAPToolStripMenuItem.Text = "General Settings"
        '
        'MostrarBarraDeFerramentasToolStripMenuItem
        '
        Me.MostrarBarraDeFerramentasToolStripMenuItem.Checked = True
        Me.MostrarBarraDeFerramentasToolStripMenuItem.CheckOnClick = True
        Me.MostrarBarraDeFerramentasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MostrarBarraDeFerramentasToolStripMenuItem.Name = "MostrarBarraDeFerramentasToolStripMenuItem"
        Me.MostrarBarraDeFerramentasToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.MostrarBarraDeFerramentasToolStripMenuItem.Text = "Show Toolstrip"
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateInputFileOnlyToolStripMenuItem, Me.GenerateInputFileAndRunToolStripMenuItem})
        Me.RunToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.RunToolStripMenuItem.Text = "Run"
        '
        'GenerateInputFileOnlyToolStripMenuItem
        '
        Me.GenerateInputFileOnlyToolStripMenuItem.Name = "GenerateInputFileOnlyToolStripMenuItem"
        Me.GenerateInputFileOnlyToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.GenerateInputFileOnlyToolStripMenuItem.Text = "Generate Input File Only"
        '
        'GenerateInputFileAndRunToolStripMenuItem
        '
        Me.GenerateInputFileAndRunToolStripMenuItem.Name = "GenerateInputFileAndRunToolStripMenuItem"
        Me.GenerateInputFileAndRunToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.GenerateInputFileAndRunToolStripMenuItem.Text = "Generate Input File and Run"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem})
        Me.WindowsMenu.MergeIndex = 102
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(62, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.AutoToolTip = True
        Me.CascadeToolStripMenuItem.CheckOnClick = True
        Me.CascadeToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.application_cascade
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.AutoToolTip = True
        Me.TileVerticalToolStripMenuItem.CheckOnClick = True
        Me.TileVerticalToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.application_tile_horizontal
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Group &Vertically"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.AutoToolTip = True
        Me.TileHorizontalToolStripMenuItem.CheckOnClick = True
        Me.TileHorizontalToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.application_tile_vertical
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Group &Horizontally"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.toolStripSeparator5, Me.RELAPNaInternetToolStripMenuItem, Me.RegistroToolStripMenuItem, Me.DonateToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.HelpToolStripMenuItem.MergeIndex = 102
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.help
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ContentsToolStripMenuItem.Text = "&Show Help"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(182, 6)
        '
        'RELAPNaInternetToolStripMenuItem
        '
        Me.RELAPNaInternetToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlogDeDesenvolvimentoToolStripMenuItem, Me.DownloadsToolStripMenuItem, Me.WikiToolStripMenuItem, Me.ForumToolStripMenuItem, Me.RastreamentoDeBugsToolStripMenuItem})
        Me.RELAPNaInternetToolStripMenuItem.Name = "RELAPNaInternetToolStripMenuItem"
        Me.RELAPNaInternetToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RELAPNaInternetToolStripMenuItem.Text = "RELAP on the Web"
        '
        'BlogDeDesenvolvimentoToolStripMenuItem
        '
        Me.BlogDeDesenvolvimentoToolStripMenuItem.Image = CType(resources.GetObject("BlogDeDesenvolvimentoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BlogDeDesenvolvimentoToolStripMenuItem.Name = "BlogDeDesenvolvimentoToolStripMenuItem"
        Me.BlogDeDesenvolvimentoToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.BlogDeDesenvolvimentoToolStripMenuItem.Text = "Development Blog"
        '
        'DownloadsToolStripMenuItem
        '
        Me.DownloadsToolStripMenuItem.Image = CType(resources.GetObject("DownloadsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DownloadsToolStripMenuItem.Name = "DownloadsToolStripMenuItem"
        Me.DownloadsToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.DownloadsToolStripMenuItem.Text = "Downloads"
        '
        'WikiToolStripMenuItem
        '
        Me.WikiToolStripMenuItem.Image = CType(resources.GetObject("WikiToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WikiToolStripMenuItem.Name = "WikiToolStripMenuItem"
        Me.WikiToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.WikiToolStripMenuItem.Text = "Wiki"
        '
        'ForumToolStripMenuItem
        '
        Me.ForumToolStripMenuItem.Name = "ForumToolStripMenuItem"
        Me.ForumToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        '
        'RastreamentoDeBugsToolStripMenuItem
        '
        Me.RastreamentoDeBugsToolStripMenuItem.Image = CType(resources.GetObject("RastreamentoDeBugsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RastreamentoDeBugsToolStripMenuItem.Name = "RastreamentoDeBugsToolStripMenuItem"
        Me.RastreamentoDeBugsToolStripMenuItem.Size = New System.Drawing.Size(304, 22)
        Me.RastreamentoDeBugsToolStripMenuItem.Text = "Bug Tracking / Feature and Support Requests"
        '
        'RegistroToolStripMenuItem
        '
        Me.RegistroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarTiposCOMToolStripMenuItem, Me.DeToolStripMenuItem})
        Me.RegistroToolStripMenuItem.Name = "RegistroToolStripMenuItem"
        Me.RegistroToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.RegistroToolStripMenuItem.Text = "Registry"
        '
        'RegistrarTiposCOMToolStripMenuItem
        '
        Me.RegistrarTiposCOMToolStripMenuItem.Name = "RegistrarTiposCOMToolStripMenuItem"
        Me.RegistrarTiposCOMToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.RegistrarTiposCOMToolStripMenuItem.Text = "Register types for COM Interop"
        '
        'DeToolStripMenuItem
        '
        Me.DeToolStripMenuItem.Name = "DeToolStripMenuItem"
        Me.DeToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.DeToolStripMenuItem.Text = "Unregister types"
        '
        'DonateToolStripMenuItem
        '
        Me.DonateToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.money_add
        Me.DonateToolStripMenuItem.Name = "DonateToolStripMenuItem"
        Me.DonateToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.DonateToolStripMenuItem.Text = "Donate!"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.information
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.AboutToolStripMenuItem.Text = "&About RELAP..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripButton1, Me.SaveAllToolStripButton, Me.ToolStripSeparator3, Me.ToolStripButton2, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripButton5, Me.ToolStripButton4, Me.ToolStripSeparator6, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripButton8})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.HelpProvider1.SetShowHelp(Me.ToolStrip1, True)
        Me.ToolStrip1.Size = New System.Drawing.Size(1002, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = Global.RELAP.My.Resources.Resources.page_white
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "New Steady-State Simulation"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = Global.RELAP.My.Resources.Resources.folder_page_white
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open Simulation"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Enabled = False
        Me.SaveToolStripButton.Image = Global.RELAP.My.Resources.Resources.page_save
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save Active Simulation"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Enabled = False
        Me.ToolStripButton1.Image = Global.RELAP.My.Resources.Resources.disk
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Save As..."
        Me.ToolStripButton1.Visible = False
        '
        'SaveAllToolStripButton
        '
        Me.SaveAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveAllToolStripButton.Enabled = False
        Me.SaveAllToolStripButton.Image = Global.RELAP.My.Resources.Resources.disk_multiple
        Me.SaveAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveAllToolStripButton.Name = "SaveAllToolStripButton"
        Me.SaveAllToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveAllToolStripButton.Text = "Save All"
        Me.SaveAllToolStripButton.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.RELAP.My.Resources.Resources.application_edit
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "General Settings"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.RELAP.My.Resources.Resources.application_cascade
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Cascade Windows"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = Global.RELAP.My.Resources.Resources.application_tile_horizontal
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Group Windows Vertically"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.RELAP.My.Resources.Resources.application_tile_vertical
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Group Windows Horizontally"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = Global.RELAP.My.Resources.Resources.help
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Show Context-Sensitive Help"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.RELAP.My.Resources.Resources.money_add
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Donate"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = Global.RELAP.My.Resources.Resources.information
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "About RELAP"
        '
        'BgLoadComp
        '
        Me.BgLoadComp.WorkerReportsProgress = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "RELAP"
        Me.OpenFileDialog1.Filter = "Steady-state Simulation (*.RELAP)|*.RELAP|Compound Creator Study (*.dwcsd)|*.dwcs" & _
            "d|Data Regression Study (*.dwrsd)|*.dwrsd|All RELAP Files (*.RELAP, *.dwcsd, *.d" & _
            "wrsd)|*.RELAP;*.dwcsd;*.dwrsd"
        Me.OpenFileDialog1.FilterIndex = 4
        Me.OpenFileDialog1.RestoreDirectory = True
        Me.OpenFileDialog1.Title = "Open existing simulation"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "RELAP"
        Me.SaveFileDialog1.Filter = "Steady-state Simulation (*.RELAP)|*.RELAP"
        Me.SaveFileDialog1.RestoreDirectory = True
        Me.SaveFileDialog1.SupportMultiDottedExtensions = True
        Me.SaveFileDialog1.Title = "Save active simulation"
        '
        'bgLoadFile
        '
        Me.bgLoadFile.WorkerReportsProgress = True
        '
        'bgSaveFile
        '
        Me.bgSaveFile.WorkerReportsProgress = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslupd})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 583)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.HelpProvider1.SetShowHelp(Me.StatusStrip1, True)
        Me.StatusStrip1.Size = New System.Drawing.Size(1002, 22)
        Me.StatusStrip1.TabIndex = 22
        Me.StatusStrip1.Text = "StatusStrip1"
        Me.StatusStrip1.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 22)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tslupd
        '
        Me.tslupd.Image = Global.RELAP.My.Resources.Resources.information
        Me.tslupd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tslupd.IsLink = True
        Me.tslupd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.tslupd.Name = "tslupd"
        Me.tslupd.Size = New System.Drawing.Size(16, 17)
        Me.tslupd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tslupd.Visible = False
        '
        'TimerBackup
        '
        Me.TimerBackup.Enabled = True
        '
        'bgSaveBackup
        '
        Me.bgSaveBackup.WorkerReportsProgress = True
        '
        'CultureManager1
        '
        Me.CultureManager1.ManagedControl = Me
        '
        'sfdUpdater
        '
        Me.sfdUpdater.Filter = "All files|*.*"
        Me.sfdUpdater.Title = "Save Installation Package"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "help\RELAP.chm"
        '
        'SaveStudyDlg
        '
        Me.SaveStudyDlg.Filter = "Compound Creator Study|*.dwcsd"
        Me.SaveStudyDlg.Title = "Salvar Estudo"
        '
        'SaveRegStudyDlg
        '
        Me.SaveRegStudyDlg.Filter = "Data Regression Study|*.dwrsd"
        Me.SaveRegStudyDlg.Title = "Save Study"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'FormMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 605)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RELAP 5"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Public WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Public WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Public WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Public WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Public WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Public WithEvents BgLoadComp As System.ComponentModel.BackgroundWorker
    Public WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Public WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Public WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Public WithEvents bgLoadFile As System.ComponentModel.BackgroundWorker
    Public WithEvents bgSaveFile As System.ComponentModel.BackgroundWorker
    Public WithEvents SaveAllToolStripButton As System.Windows.Forms.ToolStripButton
    Public WithEvents SaveAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents CloseAllToolstripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents VerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents bgLoadNews As System.ComponentModel.BackgroundWorker
    Public WithEvents StatusBarTextProvider1 As EWSoftware.StatusBarText.StatusBarTextProvider
    Public WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Public WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel


    Public WithEvents PreferênciasDoRELAPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TimerBackup As System.Windows.Forms.Timer
    Public WithEvents bgSaveBackup As System.ComponentModel.BackgroundWorker


    Private WithEvents CultureManager1 As Infralution.Localization.CultureManager
    Public WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator

    Public Sub New()

        ' This call is required by the Windows Form Designer.

        If Not My.MyApplication.CommandLineMode Or Not My.Application.CAPEOPENMode Then
            InitializeComponent()
        End If

        ' Add any initialization after the InitializeComponent() call.

        If My.Settings.BackupFiles Is Nothing Then My.Settings.BackupFiles = New System.Collections.Specialized.StringCollection
        If My.Settings.GeneralSettings Is Nothing Then My.Settings.GeneralSettings = New System.Collections.Specialized.StringCollection
        If My.Settings.UserDatabases Is Nothing Then My.Settings.UserDatabases = New System.Collections.Specialized.StringCollection

        pathsep = Path.DirectorySeparatorChar

        'Check if RELAP is running in Portable mode, then load settings from file.
        If File.Exists(My.Application.Info.DirectoryPath & Path.DirectorySeparatorChar & "default.ini") Then RELAP.App.LoadSettings()

        If Not My.Application.CommandLineArgs.Contains("-locale") Then
            If My.Settings.ShowLangForm = True Then
                '  Dim lf As New FormLanguageSelection
                ' lf.ShowDialog()
                ' lf = Nothing
                CultureManager.ApplicationUICulture = New CultureInfo(My.Settings.CultureInfo)
                Me.CultureManager1.UICulture = New CultureInfo(My.Settings.CultureInfo)
            End If
        End If

        'AddPropPacks()
        GetComponents()

        With Me.AvailableUnitSystems
            .Add(RELAP.App.GetLocalString("SistemaSI"), New RELAP.SistemasDeUnidades.UnidadesSI)
            '.Add(RELAP.App.GetLocalString("SistemaCGS"), New RELAP.SistemasDeUnidades.UnidadesCGS)
            .Add(RELAP.App.GetLocalString("SistemaIngls"), New RELAP.SistemasDeUnidades.UnidadesINGLES)
            '.Add(RELAP.App.GetLocalString("Personalizado1BR"), New RELAP.SistemasDeUnidades.UnidadesSI_Deriv1)
            '.Add(RELAP.App.GetLocalString("Personalizado2SC"), New RELAP.SistemasDeUnidades.UnidadesSI_Deriv2)
            '.Add(RELAP.App.GetLocalString("Personalizado3CNTP"), New RELAP.SistemasDeUnidades.UnidadesSI_Deriv3)
            '.Add(RELAP.App.GetLocalString("Personalizado4"), New RELAP.SistemasDeUnidades.UnidadesSI_Deriv4)
            Dim myarraylist As New ArrayList
            If Not My.Settings.UserUnits <> "1" Then
                Dim formatter As New Binary.BinaryFormatter()
                Dim bytearray() As Byte
                bytearray = System.Text.Encoding.ASCII.GetBytes(My.Settings.UserUnits)
                formatter = New Binary.BinaryFormatter()
                Dim stream As New MemoryStream(bytearray)
                myarraylist = CType(formatter.Deserialize(stream), ArrayList)
                stream.Close()
            End If
            If myarraylist.Count > 0 Then
                Dim su As New RELAP.SistemasDeUnidades.Unidades
                Dim i As Integer = 0
                Do
                    su = CType(myarraylist.Item(i), RELAP.SistemasDeUnidades.Unidades)
                    If Not .ContainsKey(su.nome) Then .Add(su.nome, su)
                    i += 1
                Loop Until i = myarraylist.Count
            End If

        End With

        Control.CheckForIllegalCrossThreadCalls = False

        'process command line arguments
        'If My.Application.CommandLineArgs.Count > 1 Then
        '    Dim bp As New CommandLineProcessor
        '    bp.ProcessCommandLineArgs(Me)
        'End If


    End Sub
    Public WithEvents RELAPNaInternetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents BlogDeDesenvolvimentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DownloadsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents WikiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ForumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents RastreamentoDeBugsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DonateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Public WithEvents MostrarBarraDeFerramentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sfdUpdater As System.Windows.Forms.SaveFileDialog
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents RegistroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrarTiposCOMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tslupd As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NovoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NovoEstudoDeRegressãoDeDadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NovoEstudoDoCriadorDeComponentesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveStudyDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveRegStudyDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateInputFileOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateInputFileAndRunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog

End Class

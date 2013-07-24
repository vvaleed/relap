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
        Me.NovoEstudoDeRegress�oDeDadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.Prefer�nciasDoRELAPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.AllowItemReorder = True
        Me.HelpProvider1.SetHelpKeyword(Me.MenuStrip1, resources.GetString("MenuStrip1.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.MenuStrip1, CType(resources.GetObject("MenuStrip1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.MenuStrip1, resources.GetString("MenuStrip1.HelpString"))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.VerToolStripMenuItem, Me.RunToolStripMenuItem, Me.WindowsMenu, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.MdiWindowListItem = Me.WindowsMenu
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.HelpProvider1.SetShowHelp(Me.MenuStrip1, CType(resources.GetObject("MenuStrip1.ShowHelp"), Boolean))
        '
        'FileToolStripMenuItem
        '
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NovoToolStripMenuItem, Me.OpenToolStripMenuItem, Me.toolStripSeparator, Me.SaveToolStripMenuItem, Me.SaveAllToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator2, Me.CloseAllToolstripMenuItem, Me.toolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.StatusBarTextProvider1.SetStatusBarText(Me.FileToolStripMenuItem, resources.GetString("FileToolStripMenuItem.StatusBarText"))
        '
        'NovoToolStripMenuItem
        '
        resources.ApplyResources(Me.NovoToolStripMenuItem, "NovoToolStripMenuItem")
        Me.NovoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem, Me.NovoEstudoDeRegress�oDeDadosToolStripMenuItem})
        Me.NovoToolStripMenuItem.Name = "NovoToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.NovoToolStripMenuItem, resources.GetString("NovoToolStripMenuItem.StatusBarText"))
        '
        'NewToolStripMenuItem
        '
        resources.ApplyResources(Me.NewToolStripMenuItem, "NewToolStripMenuItem")
        Me.NewToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.page_white
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.NewToolStripMenuItem, resources.GetString("NewToolStripMenuItem.StatusBarText"))
        '
        'NovoEstudoDoCriadorDeComponentesToolStripMenuItem
        '
        resources.ApplyResources(Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem, "NovoEstudoDoCriadorDeComponentesToolStripMenuItem")
        Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.page_white
        Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem.Name = "NovoEstudoDoCriadorDeComponentesToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.NovoEstudoDoCriadorDeComponentesToolStripMenuItem, resources.GetString("NovoEstudoDoCriadorDeComponentesToolStripMenuItem.StatusBarText"))
        '
        'NovoEstudoDeRegress�oDeDadosToolStripMenuItem
        '
        resources.ApplyResources(Me.NovoEstudoDeRegress�oDeDadosToolStripMenuItem, "NovoEstudoDeRegress�oDeDadosToolStripMenuItem")
        Me.NovoEstudoDeRegress�oDeDadosToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.page_white
        Me.NovoEstudoDeRegress�oDeDadosToolStripMenuItem.Name = "NovoEstudoDeRegress�oDeDadosToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.NovoEstudoDeRegress�oDeDadosToolStripMenuItem, resources.GetString("NovoEstudoDeRegress�oDeDadosToolStripMenuItem.StatusBarText"))
        '
        'OpenToolStripMenuItem
        '
        resources.ApplyResources(Me.OpenToolStripMenuItem, "OpenToolStripMenuItem")
        Me.OpenToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.folder_page_white
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.OpenToolStripMenuItem, resources.GetString("OpenToolStripMenuItem.StatusBarText"))
        '
        'toolStripSeparator
        '
        resources.ApplyResources(Me.toolStripSeparator, "toolStripSeparator")
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.toolStripSeparator, resources.GetString("toolStripSeparator.StatusBarText"))
        '
        'SaveToolStripMenuItem
        '
        resources.ApplyResources(Me.SaveToolStripMenuItem, "SaveToolStripMenuItem")
        Me.SaveToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.page_save
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.SaveToolStripMenuItem, resources.GetString("SaveToolStripMenuItem.StatusBarText"))
        '
        'SaveAllToolStripMenuItem
        '
        resources.ApplyResources(Me.SaveAllToolStripMenuItem, "SaveAllToolStripMenuItem")
        Me.SaveAllToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.disk_multiple
        Me.SaveAllToolStripMenuItem.Name = "SaveAllToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.SaveAllToolStripMenuItem, resources.GetString("SaveAllToolStripMenuItem.StatusBarText"))
        '
        'SaveAsToolStripMenuItem
        '
        resources.ApplyResources(Me.SaveAsToolStripMenuItem, "SaveAsToolStripMenuItem")
        Me.SaveAsToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.disk
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.SaveAsToolStripMenuItem, resources.GetString("SaveAsToolStripMenuItem.StatusBarText"))
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripSeparator2, resources.GetString("ToolStripSeparator2.StatusBarText"))
        '
        'CloseAllToolstripMenuItem
        '
        resources.ApplyResources(Me.CloseAllToolstripMenuItem, "CloseAllToolstripMenuItem")
        Me.CloseAllToolstripMenuItem.Image = Global.RELAP.My.Resources.Resources.cross
        Me.CloseAllToolstripMenuItem.Name = "CloseAllToolstripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.CloseAllToolstripMenuItem, resources.GetString("CloseAllToolstripMenuItem.StatusBarText"))
        '
        'toolStripSeparator1
        '
        resources.ApplyResources(Me.toolStripSeparator1, "toolStripSeparator1")
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.toolStripSeparator1, resources.GetString("toolStripSeparator1.StatusBarText"))
        '
        'ExitToolStripMenuItem
        '
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        Me.ExitToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.undo_16
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ExitToolStripMenuItem, resources.GetString("ExitToolStripMenuItem.StatusBarText"))
        '
        'VerToolStripMenuItem
        '
        resources.ApplyResources(Me.VerToolStripMenuItem, "VerToolStripMenuItem")
        Me.VerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Prefer�nciasDoRELAPToolStripMenuItem, Me.MostrarBarraDeFerramentasToolStripMenuItem})
        Me.VerToolStripMenuItem.Name = "VerToolStripMenuItem"
        Me.VerToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.StatusBarTextProvider1.SetStatusBarText(Me.VerToolStripMenuItem, resources.GetString("VerToolStripMenuItem.StatusBarText"))
        '
        'Prefer�nciasDoRELAPToolStripMenuItem
        '
        resources.ApplyResources(Me.Prefer�nciasDoRELAPToolStripMenuItem, "Prefer�nciasDoRELAPToolStripMenuItem")
        Me.Prefer�nciasDoRELAPToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.application_edit
        Me.Prefer�nciasDoRELAPToolStripMenuItem.Name = "Prefer�nciasDoRELAPToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.Prefer�nciasDoRELAPToolStripMenuItem, resources.GetString("Prefer�nciasDoRELAPToolStripMenuItem.StatusBarText"))
        '
        'MostrarBarraDeFerramentasToolStripMenuItem
        '
        resources.ApplyResources(Me.MostrarBarraDeFerramentasToolStripMenuItem, "MostrarBarraDeFerramentasToolStripMenuItem")
        Me.MostrarBarraDeFerramentasToolStripMenuItem.Checked = True
        Me.MostrarBarraDeFerramentasToolStripMenuItem.CheckOnClick = True
        Me.MostrarBarraDeFerramentasToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MostrarBarraDeFerramentasToolStripMenuItem.Name = "MostrarBarraDeFerramentasToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.MostrarBarraDeFerramentasToolStripMenuItem, resources.GetString("MostrarBarraDeFerramentasToolStripMenuItem.StatusBarText"))
        '
        'RunToolStripMenuItem
        '
        resources.ApplyResources(Me.RunToolStripMenuItem, "RunToolStripMenuItem")
        Me.RunToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateInputFileOnlyToolStripMenuItem, Me.GenerateInputFileAndRunToolStripMenuItem})
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.RunToolStripMenuItem, resources.GetString("RunToolStripMenuItem.StatusBarText"))
        '
        'GenerateInputFileOnlyToolStripMenuItem
        '
        resources.ApplyResources(Me.GenerateInputFileOnlyToolStripMenuItem, "GenerateInputFileOnlyToolStripMenuItem")
        Me.GenerateInputFileOnlyToolStripMenuItem.Name = "GenerateInputFileOnlyToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.GenerateInputFileOnlyToolStripMenuItem, resources.GetString("GenerateInputFileOnlyToolStripMenuItem.StatusBarText"))
        '
        'GenerateInputFileAndRunToolStripMenuItem
        '
        resources.ApplyResources(Me.GenerateInputFileAndRunToolStripMenuItem, "GenerateInputFileAndRunToolStripMenuItem")
        Me.GenerateInputFileAndRunToolStripMenuItem.Name = "GenerateInputFileAndRunToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.GenerateInputFileAndRunToolStripMenuItem, resources.GetString("GenerateInputFileAndRunToolStripMenuItem.StatusBarText"))
        '
        'WindowsMenu
        '
        resources.ApplyResources(Me.WindowsMenu, "WindowsMenu")
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem})
        Me.WindowsMenu.MergeIndex = 102
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.WindowsMenu, resources.GetString("WindowsMenu.StatusBarText"))
        '
        'CascadeToolStripMenuItem
        '
        resources.ApplyResources(Me.CascadeToolStripMenuItem, "CascadeToolStripMenuItem")
        Me.CascadeToolStripMenuItem.AutoToolTip = True
        Me.CascadeToolStripMenuItem.CheckOnClick = True
        Me.CascadeToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.application_cascade
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.CascadeToolStripMenuItem, resources.GetString("CascadeToolStripMenuItem.StatusBarText"))
        '
        'TileVerticalToolStripMenuItem
        '
        resources.ApplyResources(Me.TileVerticalToolStripMenuItem, "TileVerticalToolStripMenuItem")
        Me.TileVerticalToolStripMenuItem.AutoToolTip = True
        Me.TileVerticalToolStripMenuItem.CheckOnClick = True
        Me.TileVerticalToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.application_tile_horizontal
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.TileVerticalToolStripMenuItem, resources.GetString("TileVerticalToolStripMenuItem.StatusBarText"))
        '
        'TileHorizontalToolStripMenuItem
        '
        resources.ApplyResources(Me.TileHorizontalToolStripMenuItem, "TileHorizontalToolStripMenuItem")
        Me.TileHorizontalToolStripMenuItem.AutoToolTip = True
        Me.TileHorizontalToolStripMenuItem.CheckOnClick = True
        Me.TileHorizontalToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.application_tile_vertical
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.TileHorizontalToolStripMenuItem, resources.GetString("TileHorizontalToolStripMenuItem.StatusBarText"))
        '
        'HelpToolStripMenuItem
        '
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.toolStripSeparator5, Me.RELAPNaInternetToolStripMenuItem, Me.RegistroToolStripMenuItem, Me.DonateToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.HelpToolStripMenuItem.MergeIndex = 102
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.HelpToolStripMenuItem, resources.GetString("HelpToolStripMenuItem.StatusBarText"))
        '
        'ContentsToolStripMenuItem
        '
        resources.ApplyResources(Me.ContentsToolStripMenuItem, "ContentsToolStripMenuItem")
        Me.ContentsToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.help
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ContentsToolStripMenuItem, resources.GetString("ContentsToolStripMenuItem.StatusBarText"))
        '
        'toolStripSeparator5
        '
        resources.ApplyResources(Me.toolStripSeparator5, "toolStripSeparator5")
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.toolStripSeparator5, resources.GetString("toolStripSeparator5.StatusBarText"))
        '
        'RELAPNaInternetToolStripMenuItem
        '
        resources.ApplyResources(Me.RELAPNaInternetToolStripMenuItem, "RELAPNaInternetToolStripMenuItem")
        Me.RELAPNaInternetToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlogDeDesenvolvimentoToolStripMenuItem, Me.DownloadsToolStripMenuItem, Me.WikiToolStripMenuItem, Me.ForumToolStripMenuItem, Me.RastreamentoDeBugsToolStripMenuItem})
        Me.RELAPNaInternetToolStripMenuItem.Name = "RELAPNaInternetToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.RELAPNaInternetToolStripMenuItem, resources.GetString("RELAPNaInternetToolStripMenuItem.StatusBarText"))
        '
        'BlogDeDesenvolvimentoToolStripMenuItem
        '
        resources.ApplyResources(Me.BlogDeDesenvolvimentoToolStripMenuItem, "BlogDeDesenvolvimentoToolStripMenuItem")
        Me.BlogDeDesenvolvimentoToolStripMenuItem.Name = "BlogDeDesenvolvimentoToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.BlogDeDesenvolvimentoToolStripMenuItem, resources.GetString("BlogDeDesenvolvimentoToolStripMenuItem.StatusBarText"))
        '
        'DownloadsToolStripMenuItem
        '
        resources.ApplyResources(Me.DownloadsToolStripMenuItem, "DownloadsToolStripMenuItem")
        Me.DownloadsToolStripMenuItem.Name = "DownloadsToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.DownloadsToolStripMenuItem, resources.GetString("DownloadsToolStripMenuItem.StatusBarText"))
        '
        'WikiToolStripMenuItem
        '
        resources.ApplyResources(Me.WikiToolStripMenuItem, "WikiToolStripMenuItem")
        Me.WikiToolStripMenuItem.Name = "WikiToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.WikiToolStripMenuItem, resources.GetString("WikiToolStripMenuItem.StatusBarText"))
        '
        'ForumToolStripMenuItem
        '
        resources.ApplyResources(Me.ForumToolStripMenuItem, "ForumToolStripMenuItem")
        Me.ForumToolStripMenuItem.Name = "ForumToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ForumToolStripMenuItem, resources.GetString("ForumToolStripMenuItem.StatusBarText"))
        '
        'RastreamentoDeBugsToolStripMenuItem
        '
        resources.ApplyResources(Me.RastreamentoDeBugsToolStripMenuItem, "RastreamentoDeBugsToolStripMenuItem")
        Me.RastreamentoDeBugsToolStripMenuItem.Name = "RastreamentoDeBugsToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.RastreamentoDeBugsToolStripMenuItem, resources.GetString("RastreamentoDeBugsToolStripMenuItem.StatusBarText"))
        '
        'RegistroToolStripMenuItem
        '
        resources.ApplyResources(Me.RegistroToolStripMenuItem, "RegistroToolStripMenuItem")
        Me.RegistroToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrarTiposCOMToolStripMenuItem, Me.DeToolStripMenuItem})
        Me.RegistroToolStripMenuItem.Name = "RegistroToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.RegistroToolStripMenuItem, resources.GetString("RegistroToolStripMenuItem.StatusBarText"))
        '
        'RegistrarTiposCOMToolStripMenuItem
        '
        resources.ApplyResources(Me.RegistrarTiposCOMToolStripMenuItem, "RegistrarTiposCOMToolStripMenuItem")
        Me.RegistrarTiposCOMToolStripMenuItem.Name = "RegistrarTiposCOMToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.RegistrarTiposCOMToolStripMenuItem, resources.GetString("RegistrarTiposCOMToolStripMenuItem.StatusBarText"))
        '
        'DeToolStripMenuItem
        '
        resources.ApplyResources(Me.DeToolStripMenuItem, "DeToolStripMenuItem")
        Me.DeToolStripMenuItem.Name = "DeToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.DeToolStripMenuItem, resources.GetString("DeToolStripMenuItem.StatusBarText"))
        '
        'DonateToolStripMenuItem
        '
        resources.ApplyResources(Me.DonateToolStripMenuItem, "DonateToolStripMenuItem")
        Me.DonateToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.money_add
        Me.DonateToolStripMenuItem.Name = "DonateToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.DonateToolStripMenuItem, resources.GetString("DonateToolStripMenuItem.StatusBarText"))
        '
        'AboutToolStripMenuItem
        '
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        Me.AboutToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.information
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.AboutToolStripMenuItem, resources.GetString("AboutToolStripMenuItem.StatusBarText"))
        '
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.HelpProvider1.SetHelpKeyword(Me.ToolStrip1, resources.GetString("ToolStrip1.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.ToolStrip1, CType(resources.GetObject("ToolStrip1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.ToolStrip1, resources.GetString("ToolStrip1.HelpString"))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.ToolStripButton1, Me.SaveAllToolStripButton, Me.ToolStripSeparator3, Me.ToolStripButton2, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripButton5, Me.ToolStripButton4, Me.ToolStripSeparator6, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripButton8})
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.HelpProvider1.SetShowHelp(Me.ToolStrip1, CType(resources.GetObject("ToolStrip1.ShowHelp"), Boolean))
        '
        'NewToolStripButton
        '
        resources.ApplyResources(Me.NewToolStripButton, "NewToolStripButton")
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = Global.RELAP.My.Resources.Resources.page_white
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.NewToolStripButton, resources.GetString("NewToolStripButton.StatusBarText"))
        '
        'OpenToolStripButton
        '
        resources.ApplyResources(Me.OpenToolStripButton, "OpenToolStripButton")
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = Global.RELAP.My.Resources.Resources.folder_page_white
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.OpenToolStripButton, resources.GetString("OpenToolStripButton.StatusBarText"))
        '
        'SaveToolStripButton
        '
        resources.ApplyResources(Me.SaveToolStripButton, "SaveToolStripButton")
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = Global.RELAP.My.Resources.Resources.page_save
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.SaveToolStripButton, resources.GetString("SaveToolStripButton.StatusBarText"))
        '
        'ToolStripButton1
        '
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.RELAP.My.Resources.Resources.disk
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripButton1, resources.GetString("ToolStripButton1.StatusBarText"))
        '
        'SaveAllToolStripButton
        '
        resources.ApplyResources(Me.SaveAllToolStripButton, "SaveAllToolStripButton")
        Me.SaveAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveAllToolStripButton.Image = Global.RELAP.My.Resources.Resources.disk_multiple
        Me.SaveAllToolStripButton.Name = "SaveAllToolStripButton"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.SaveAllToolStripButton, resources.GetString("SaveAllToolStripButton.StatusBarText"))
        '
        'ToolStripSeparator3
        '
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripSeparator3, resources.GetString("ToolStripSeparator3.StatusBarText"))
        '
        'ToolStripButton2
        '
        resources.ApplyResources(Me.ToolStripButton2, "ToolStripButton2")
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.RELAP.My.Resources.Resources.application_edit
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripButton2, resources.GetString("ToolStripButton2.StatusBarText"))
        '
        'ToolStripSeparator4
        '
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripSeparator4, resources.GetString("ToolStripSeparator4.StatusBarText"))
        '
        'ToolStripButton3
        '
        resources.ApplyResources(Me.ToolStripButton3, "ToolStripButton3")
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.RELAP.My.Resources.Resources.application_cascade
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripButton3, resources.GetString("ToolStripButton3.StatusBarText"))
        '
        'ToolStripButton5
        '
        resources.ApplyResources(Me.ToolStripButton5, "ToolStripButton5")
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = Global.RELAP.My.Resources.Resources.application_tile_horizontal
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripButton5, resources.GetString("ToolStripButton5.StatusBarText"))
        '
        'ToolStripButton4
        '
        resources.ApplyResources(Me.ToolStripButton4, "ToolStripButton4")
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.RELAP.My.Resources.Resources.application_tile_vertical
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripButton4, resources.GetString("ToolStripButton4.StatusBarText"))
        '
        'ToolStripSeparator6
        '
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripSeparator6, resources.GetString("ToolStripSeparator6.StatusBarText"))
        '
        'ToolStripButton6
        '
        resources.ApplyResources(Me.ToolStripButton6, "ToolStripButton6")
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = Global.RELAP.My.Resources.Resources.help
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripButton6, resources.GetString("ToolStripButton6.StatusBarText"))
        '
        'ToolStripButton7
        '
        resources.ApplyResources(Me.ToolStripButton7, "ToolStripButton7")
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.RELAP.My.Resources.Resources.money_add
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripButton7, resources.GetString("ToolStripButton7.StatusBarText"))
        '
        'ToolStripButton8
        '
        resources.ApplyResources(Me.ToolStripButton8, "ToolStripButton8")
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = Global.RELAP.My.Resources.Resources.information
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripButton8, resources.GetString("ToolStripButton8.StatusBarText"))
        '
        'BgLoadComp
        '
        Me.BgLoadComp.WorkerReportsProgress = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "RELAP"
        resources.ApplyResources(Me.OpenFileDialog1, "OpenFileDialog1")
        Me.OpenFileDialog1.FilterIndex = 4
        Me.OpenFileDialog1.RestoreDirectory = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "RELAP"
        resources.ApplyResources(Me.SaveFileDialog1, "SaveFileDialog1")
        Me.SaveFileDialog1.RestoreDirectory = True
        Me.SaveFileDialog1.SupportMultiDottedExtensions = True
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
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.HelpProvider1.SetHelpKeyword(Me.StatusStrip1, resources.GetString("StatusStrip1.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me.StatusStrip1, CType(resources.GetObject("StatusStrip1.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me.StatusStrip1, resources.GetString("StatusStrip1.HelpString"))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslupd})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.HelpProvider1.SetShowHelp(Me.StatusStrip1, CType(resources.GetObject("StatusStrip1.ShowHelp"), Boolean))
        '
        'ToolStripStatusLabel1
        '
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Spring = True
        Me.StatusBarTextProvider1.SetStatusBarText(Me.ToolStripStatusLabel1, resources.GetString("ToolStripStatusLabel1.StatusBarText"))
        '
        'tslupd
        '
        resources.ApplyResources(Me.tslupd, "tslupd")
        Me.tslupd.Image = Global.RELAP.My.Resources.Resources.information
        Me.tslupd.IsLink = True
        Me.tslupd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.tslupd.Name = "tslupd"
        Me.StatusBarTextProvider1.SetStatusBarText(Me.tslupd, resources.GetString("tslupd.StatusBarText"))
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
        resources.ApplyResources(Me.sfdUpdater, "sfdUpdater")
        '
        'HelpProvider1
        '
        resources.ApplyResources(Me.HelpProvider1, "HelpProvider1")
        '
        'SaveStudyDlg
        '
        resources.ApplyResources(Me.SaveStudyDlg, "SaveStudyDlg")
        '
        'SaveRegStudyDlg
        '
        resources.ApplyResources(Me.SaveRegStudyDlg, "SaveRegStudyDlg")
        '
        'FormMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.HelpProvider1.SetHelpKeyword(Me, resources.GetString("$this.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me, CType(resources.GetObject("$this.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me, resources.GetString("$this.HelpString"))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.HelpProvider1.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
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


    Public WithEvents Prefer�nciasDoRELAPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents NovoEstudoDeRegress�oDeDadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NovoEstudoDoCriadorDeComponentesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveStudyDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveRegStudyDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateInputFileOnlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateInputFileAndRunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

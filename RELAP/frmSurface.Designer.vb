<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurface
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurface))
        Me.CMS_NoSel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiarParaAÁreaDeTransferênciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_Sel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_Label = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditCompTSMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ConectarAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesconectarDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_Girar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorizontalmenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ClonarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcluirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabelaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviewDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.designSurfacePrintDocument = New System.Drawing.Printing.PrintDocument()
        Me.CMS_ItemsToConnect = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMS_ItemsToDisconnect = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pageSetup = New System.Windows.Forms.PageSetupDialog()
        Me.setupPrint = New System.Windows.Forms.PrintDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.CMS_MultiSelect = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemGroupComponents = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.SpinningProgress1 = New CircularProgress.SpinningProgress.SpinningProgress()
        Me.PanelSimultAdjust = New System.Windows.Forms.Panel()
        Me.PicSimultAdjust = New System.Windows.Forms.PictureBox()
        Me.FlowsheetDesignSurface = New Microsoft.Msdn.Samples.DesignSurface.GraphicsSurface()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CMS_NoSel.SuspendLayout()
        Me.CMS_Sel.SuspendLayout()
        Me.CMS_MultiSelect.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSimultAdjust.SuspendLayout()
        CType(Me.PicSimultAdjust, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CMS_NoSel
        '
        Me.CMS_NoSel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripSeparator1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem5, Me.CopiarParaAÁreaDeTransferênciaToolStripMenuItem})
        Me.CMS_NoSel.Name = "ContextMenuStrip1"
        Me.CMS_NoSel.Size = New System.Drawing.Size(282, 98)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Enabled = False
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(281, 22)
        Me.ToolStripMenuItem3.Text = "Flowsheet"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(278, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.RELAP.My.Resources.Resources.page_white_paint
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(281, 22)
        Me.ToolStripMenuItem2.Text = "Configure Style"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = Global.RELAP.My.Resources.Resources.printer
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(281, 22)
        Me.ToolStripMenuItem5.Text = "Print"
        '
        'CopiarParaAÁreaDeTransferênciaToolStripMenuItem
        '
        Me.CopiarParaAÁreaDeTransferênciaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem4, Me.ToolStripMenuItem8, Me.ToolStripMenuItem10})
        Me.CopiarParaAÁreaDeTransferênciaToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.images
        Me.CopiarParaAÁreaDeTransferênciaToolStripMenuItem.Name = "CopiarParaAÁreaDeTransferênciaToolStripMenuItem"
        Me.CopiarParaAÁreaDeTransferênciaToolStripMenuItem.Size = New System.Drawing.Size(281, 22)
        Me.CopiarParaAÁreaDeTransferênciaToolStripMenuItem.Text = "Capture Snapshot and Send to Clipboard"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.RELAP.My.Resources.Resources.zoom
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem1.Text = "50%"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = Global.RELAP.My.Resources.Resources.zoom
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem4.Text = "100%"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Image = Global.RELAP.My.Resources.Resources.zoom
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem8.Text = "200%"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Image = Global.RELAP.My.Resources.Resources.zoom
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(102, 22)
        Me.ToolStripMenuItem10.Text = "300%"
        '
        'CMS_Sel
        '
        Me.CMS_Sel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Label, Me.EditCompTSMI, Me.ToolStripSeparator6, Me.ConectarAToolStripMenuItem, Me.DesconectarDeToolStripMenuItem, Me.ToolStripSeparator4, Me.TSMI_Girar, Me.HorizontalmenteToolStripMenuItem, Me.ToolStripSeparator2, Me.ClonarToolStripMenuItem, Me.ExcluirToolStripMenuItem, Me.ToolStripSeparator5, Me.TabelaToolStripMenuItem})
        Me.CMS_Sel.Name = "CMS_Sel"
        Me.CMS_Sel.Size = New System.Drawing.Size(240, 226)
        '
        'TSMI_Label
        '
        Me.TSMI_Label.Enabled = False
        Me.TSMI_Label.Name = "TSMI_Label"
        Me.TSMI_Label.Size = New System.Drawing.Size(239, 22)
        Me.TSMI_Label.Text = "ToolStripMenuItem1"
        '
        'EditCompTSMI
        '
        Me.EditCompTSMI.Image = Global.RELAP.My.Resources.Resources.Lab_icon
        Me.EditCompTSMI.Name = "EditCompTSMI"
        Me.EditCompTSMI.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.EditCompTSMI.Size = New System.Drawing.Size(239, 22)
        Me.EditCompTSMI.Text = "Edit Stream Composition"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(236, 6)
        Me.ToolStripSeparator6.Visible = False
        '
        'ConectarAToolStripMenuItem
        '
        Me.ConectarAToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.connect
        Me.ConectarAToolStripMenuItem.Name = "ConectarAToolStripMenuItem"
        Me.ConectarAToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ConectarAToolStripMenuItem.Text = "Connect to..."
        '
        'DesconectarDeToolStripMenuItem
        '
        Me.DesconectarDeToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.disconnect
        Me.DesconectarDeToolStripMenuItem.Name = "DesconectarDeToolStripMenuItem"
        Me.DesconectarDeToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.DesconectarDeToolStripMenuItem.Text = "Disconnect from..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(236, 6)
        '
        'TSMI_Girar
        '
        Me.TSMI_Girar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem6, Me.BToolStripMenuItem, Me.ToolStripMenuItem7})
        Me.TSMI_Girar.Image = Global.RELAP.My.Resources.Resources.arrow_rotate_clockwise
        Me.TSMI_Girar.Name = "TSMI_Girar"
        Me.TSMI_Girar.Size = New System.Drawing.Size(239, 22)
        Me.TSMI_Girar.Text = "Rotate"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripMenuItem6.Text = "90 °"
        '
        'BToolStripMenuItem
        '
        Me.BToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BToolStripMenuItem.Name = "BToolStripMenuItem"
        Me.BToolStripMenuItem.Size = New System.Drawing.Size(100, 22)
        Me.BToolStripMenuItem.Text = "180 °"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(100, 22)
        Me.ToolStripMenuItem7.Text = "270 °"
        '
        'HorizontalmenteToolStripMenuItem
        '
        Me.HorizontalmenteToolStripMenuItem.CheckOnClick = True
        Me.HorizontalmenteToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.shape_flip_horizontal
        Me.HorizontalmenteToolStripMenuItem.Name = "HorizontalmenteToolStripMenuItem"
        Me.HorizontalmenteToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.HorizontalmenteToolStripMenuItem.Text = "Invert Horizontally"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(236, 6)
        '
        'ClonarToolStripMenuItem
        '
        Me.ClonarToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.sheep
        Me.ClonarToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.ClonarToolStripMenuItem.Name = "ClonarToolStripMenuItem"
        Me.ClonarToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ClonarToolStripMenuItem.Text = "Clone"
        Me.ClonarToolStripMenuItem.ToolTipText = "Creates an exact copy of the selected object."
        '
        'ExcluirToolStripMenuItem
        '
        Me.ExcluirToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.cross
        Me.ExcluirToolStripMenuItem.Name = "ExcluirToolStripMenuItem"
        Me.ExcluirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.ExcluirToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ExcluirToolStripMenuItem.Text = "Delete"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(236, 6)
        '
        'TabelaToolStripMenuItem
        '
        Me.TabelaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MostrarToolStripMenuItem, Me.ConfigurarToolStripMenuItem})
        Me.TabelaToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.table
        Me.TabelaToolStripMenuItem.Name = "TabelaToolStripMenuItem"
        Me.TabelaToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.TabelaToolStripMenuItem.Text = "Table"
        '
        'MostrarToolStripMenuItem
        '
        Me.MostrarToolStripMenuItem.CheckOnClick = True
        Me.MostrarToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.table_go
        Me.MostrarToolStripMenuItem.Name = "MostrarToolStripMenuItem"
        Me.MostrarToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.MostrarToolStripMenuItem.Text = "Show"
        '
        'ConfigurarToolStripMenuItem
        '
        Me.ConfigurarToolStripMenuItem.Image = Global.RELAP.My.Resources.Resources.cog
        Me.ConfigurarToolStripMenuItem.Name = "ConfigurarToolStripMenuItem"
        Me.ConfigurarToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.ConfigurarToolStripMenuItem.Text = "Configure..."
        '
        'PreviewDialog
        '
        Me.PreviewDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PreviewDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PreviewDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.PreviewDialog.Document = Me.designSurfacePrintDocument
        Me.PreviewDialog.Enabled = True
        Me.PreviewDialog.Icon = CType(resources.GetObject("PreviewDialog.Icon"), System.Drawing.Icon)
        Me.PreviewDialog.Name = "PrintPreviewDialog1"
        Me.PreviewDialog.UseAntiAlias = True
        Me.PreviewDialog.Visible = False
        '
        'designSurfacePrintDocument
        '
        Me.designSurfacePrintDocument.DocumentName = "documento"
        '
        'CMS_ItemsToConnect
        '
        Me.CMS_ItemsToConnect.Name = "CMS_ItemsToConnect"
        Me.CMS_ItemsToConnect.Size = New System.Drawing.Size(61, 4)
        '
        'CMS_ItemsToDisconnect
        '
        Me.CMS_ItemsToDisconnect.Name = "CMS_ItemsToConnect"
        Me.CMS_ItemsToDisconnect.Size = New System.Drawing.Size(61, 4)
        '
        'pageSetup
        '
        Me.pageSetup.Document = Me.designSurfacePrintDocument
        '
        'setupPrint
        '
        Me.setupPrint.AllowCurrentPage = True
        Me.setupPrint.Document = Me.designSurfacePrintDocument
        Me.setupPrint.UseEXDialog = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        '
        'CMS_MultiSelect
        '
        Me.CMS_MultiSelect.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemGroupComponents})
        Me.CMS_MultiSelect.Name = "CMS_MultiSelect"
        Me.CMS_MultiSelect.Size = New System.Drawing.Size(180, 26)
        '
        'MenuItemGroupComponents
        '
        Me.MenuItemGroupComponents.Name = "MenuItemGroupComponents"
        Me.MenuItemGroupComponents.Size = New System.Drawing.Size(179, 22)
        Me.MenuItemGroupComponents.Text = "Group Components"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.SpinningProgress1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PanelSimultAdjust, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 458)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(982, 40)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(42, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(470, 40)
        Me.Panel2.TabIndex = 13
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.RELAP.My.Resources.Resources.tick
        Me.PictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox3.Location = New System.Drawing.Point(3, 2)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 12
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.RELAP.My.Resources.Resources.clock
        Me.PictureBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox4.Location = New System.Drawing.Point(3, 20)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox4.TabIndex = 11
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'SpinningProgress1
        '
        Me.SpinningProgress1.ActiveSegmentColour = System.Drawing.SystemColors.ControlDark
        Me.SpinningProgress1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SpinningProgress1.BehindTransistionSegmentIsActive = False
        Me.SpinningProgress1.InactiveSegmentColour = System.Drawing.SystemColors.Control
        Me.SpinningProgress1.Location = New System.Drawing.Point(2, 2)
        Me.SpinningProgress1.Margin = New System.Windows.Forms.Padding(2)
        Me.SpinningProgress1.Name = "SpinningProgress1"
        Me.SpinningProgress1.Size = New System.Drawing.Size(38, 35)
        Me.SpinningProgress1.TabIndex = 11
        Me.SpinningProgress1.TransistionSegment = 9
        Me.SpinningProgress1.TransistionSegmentColour = System.Drawing.SystemColors.ControlLight
        Me.SpinningProgress1.Visible = False
        '
        'PanelSimultAdjust
        '
        Me.PanelSimultAdjust.Controls.Add(Me.PicSimultAdjust)
        Me.PanelSimultAdjust.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSimultAdjust.Location = New System.Drawing.Point(512, 0)
        Me.PanelSimultAdjust.Margin = New System.Windows.Forms.Padding(0)
        Me.PanelSimultAdjust.Name = "PanelSimultAdjust"
        Me.PanelSimultAdjust.Size = New System.Drawing.Size(470, 40)
        Me.PanelSimultAdjust.TabIndex = 14
        Me.PanelSimultAdjust.Visible = False
        '
        'PicSimultAdjust
        '
        Me.PicSimultAdjust.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicSimultAdjust.Image = Global.RELAP.My.Resources.Resources.lightning1
        Me.PicSimultAdjust.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PicSimultAdjust.Location = New System.Drawing.Point(426, 0)
        Me.PicSimultAdjust.Margin = New System.Windows.Forms.Padding(0)
        Me.PicSimultAdjust.Name = "PicSimultAdjust"
        Me.PicSimultAdjust.Size = New System.Drawing.Size(42, 40)
        Me.PicSimultAdjust.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PicSimultAdjust.TabIndex = 12
        Me.PicSimultAdjust.TabStop = False
        '
        'FlowsheetDesignSurface
        '
        Me.FlowsheetDesignSurface.AllowDrop = True
        Me.FlowsheetDesignSurface.AutoScroll = True
        Me.FlowsheetDesignSurface.AutoScrollMinSize = New System.Drawing.Size(9600, 6720)
        Me.FlowsheetDesignSurface.BackColor = System.Drawing.Color.White
        Me.FlowsheetDesignSurface.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowsheetDesignSurface.GridColor = System.Drawing.Color.GhostWhite
        Me.FlowsheetDesignSurface.GridLineWidth = 1
        Me.FlowsheetDesignSurface.GridSize = 25.0!
        Me.FlowsheetDesignSurface.Location = New System.Drawing.Point(3, 3)
        Me.FlowsheetDesignSurface.MarginColor = System.Drawing.SystemColors.Control
        Me.FlowsheetDesignSurface.MarginLineWidth = 1
        Me.FlowsheetDesignSurface.MaximumSize = New System.Drawing.Size(10000, 7000)
        Me.FlowsheetDesignSurface.MouseHoverSelect = False
        Me.FlowsheetDesignSurface.Name = "FlowsheetDesignSurface"
        Me.FlowsheetDesignSurface.NonPrintingAreaColor = System.Drawing.Color.LightGray
        Me.FlowsheetDesignSurface.QuickConnect = False
        Me.FlowsheetDesignSurface.SelectedObject = Nothing
        Me.FlowsheetDesignSurface.SelectRectangle = True
        Me.FlowsheetDesignSurface.ShowGrid = False
        Me.FlowsheetDesignSurface.Size = New System.Drawing.Size(976, 452)
        Me.FlowsheetDesignSurface.SnapToGrid = False
        Me.FlowsheetDesignSurface.SurfaceBounds = New System.Drawing.Rectangle(0, 0, 10000, 7000)
        Me.FlowsheetDesignSurface.SurfaceMargins = New System.Drawing.Rectangle(0, 0, 10000, 7000)
        Me.FlowsheetDesignSurface.TabIndex = 0
        Me.FlowsheetDesignSurface.Zoom = 1.0!
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowsheetDesignSurface, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(982, 518)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'frmSurface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 518)
        Me.CloseButton = False
        Me.CloseButtonVisible = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSurface"
        Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document
        Me.TabText = Me.Text
        Me.Text = "Flowsheet"
        Me.CMS_NoSel.ResumeLayout(False)
        Me.CMS_Sel.ResumeLayout(False)
        Me.CMS_MultiSelect.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSimultAdjust.ResumeLayout(False)
        CType(Me.PicSimultAdjust, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents CMS_NoSel As System.Windows.Forms.ContextMenuStrip
    Public WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents CMS_Sel As System.Windows.Forms.ContextMenuStrip
    Public WithEvents TSMI_Girar As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents BToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents TSMI_Label As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TabelaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MostrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ConfigurarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents PreviewDialog As System.Windows.Forms.PrintPreviewDialog
    Public WithEvents designSurfacePrintDocument As System.Drawing.Printing.PrintDocument
    Public WithEvents pageSetup As System.Windows.Forms.PageSetupDialog
    Public WithEvents setupPrint As System.Windows.Forms.PrintDialog
    Public WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents ClonarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents HorizontalmenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ConectarAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents DesconectarDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents CMS_ItemsToConnect As System.Windows.Forms.ContextMenuStrip
    Public WithEvents CMS_ItemsToDisconnect As System.Windows.Forms.ContextMenuStrip
    Public WithEvents ExcluirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents Timer2 As System.Windows.Forms.Timer
    Public WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditCompTSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiarParaAÁreaDeTransferênciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMS_MultiSelect As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuItemGroupComponents As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Public WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Public WithEvents SpinningProgress1 As CircularProgress.SpinningProgress.SpinningProgress
    Public WithEvents PanelSimultAdjust As System.Windows.Forms.Panel
    Public WithEvents PicSimultAdjust As System.Windows.Forms.PictureBox
    Public WithEvents FlowsheetDesignSurface As Microsoft.Msdn.Samples.DesignSurface.GraphicsSurface
    Public WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class

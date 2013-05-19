<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProps
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProps))
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.LblStatusObj = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.LblTipoObj = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FTSProps = New FarsiLibrary.Win.FATabStrip()
        Me.TSProps = New FarsiLibrary.Win.FATabStripItem()
        Me.PGEx1 = New PropertyGridEx.PropertyGridEx()
        Me.TSObj = New FarsiLibrary.Win.FATabStripItem()
        Me.PGEx2 = New PropertyGridEx.PropertyGridEx()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblNomeObj = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        CType(Me.FTSProps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FTSProps.SuspendLayout()
        Me.TSProps.SuspendLayout()
        Me.TSObj.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel5
        '
        resources.ApplyResources(Me.TableLayoutPanel5, "TableLayoutPanel5")
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel8, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel7, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.FTSProps, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel6, 0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        '
        'TableLayoutPanel8
        '
        resources.ApplyResources(Me.TableLayoutPanel8, "TableLayoutPanel8")
        Me.TableLayoutPanel8.Controls.Add(Me.LblStatusObj, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        '
        'LblStatusObj
        '
        resources.ApplyResources(Me.LblStatusObj, "LblStatusObj")
        Me.LblStatusObj.ImageKey = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.LblStatusObj.Name = "LblStatusObj"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ImageKey = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.Label4.Name = "Label4"
        '
        'TableLayoutPanel7
        '
        resources.ApplyResources(Me.TableLayoutPanel7, "TableLayoutPanel7")
        Me.TableLayoutPanel7.Controls.Add(Me.LblTipoObj, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        '
        'LblTipoObj
        '
        resources.ApplyResources(Me.LblTipoObj, "LblTipoObj")
        Me.LblTipoObj.ImageKey = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.LblTipoObj.Name = "LblTipoObj"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ImageKey = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.Label3.Name = "Label3"
        '
        'FTSProps
        '
        resources.ApplyResources(Me.FTSProps, "FTSProps")
        Me.FTSProps.AlwaysShowClose = False
        Me.FTSProps.Items.AddRange(New FarsiLibrary.Win.FATabStripItem() {Me.TSProps, Me.TSObj})
        Me.FTSProps.Name = "FTSProps"
        Me.FTSProps.SelectedItem = Me.TSProps
        '
        'TSProps
        '
        resources.ApplyResources(Me.TSProps, "TSProps")
        Me.TSProps.CanClose = False
        Me.TSProps.Controls.Add(Me.PGEx1)
        Me.TSProps.IsDrawn = True
        Me.TSProps.Name = "TSProps"
        Me.TSProps.Selected = True
        '
        'PGEx1
        '
        resources.ApplyResources(Me.PGEx1, "PGEx1")
        '
        '
        '
        Me.PGEx1.DocCommentDescription.AccessibleDescription = resources.GetString("PGEx1.DocCommentDescription.AccessibleDescription")
        Me.PGEx1.DocCommentDescription.AccessibleName = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.PGEx1.DocCommentDescription.Anchor = CType(resources.GetObject("PGEx1.DocCommentDescription.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PGEx1.DocCommentDescription.AutoEllipsis = True
        Me.PGEx1.DocCommentDescription.AutoSize = CType(resources.GetObject("PGEx1.DocCommentDescription.AutoSize"), Boolean)
        Me.PGEx1.DocCommentDescription.BackColor = System.Drawing.Color.Transparent
        Me.PGEx1.DocCommentDescription.BackgroundImageLayout = CType(resources.GetObject("PGEx1.DocCommentDescription.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PGEx1.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PGEx1.DocCommentDescription.Dock = CType(resources.GetObject("PGEx1.DocCommentDescription.Dock"), System.Windows.Forms.DockStyle)
        Me.PGEx1.DocCommentDescription.Font = CType(resources.GetObject("PGEx1.DocCommentDescription.Font"), System.Drawing.Font)
        Me.PGEx1.DocCommentDescription.ImageAlign = CType(resources.GetObject("PGEx1.DocCommentDescription.ImageAlign"), System.Drawing.ContentAlignment)
        Me.PGEx1.DocCommentDescription.ImageIndex = CType(resources.GetObject("PGEx1.DocCommentDescription.ImageIndex"), Integer)
        Me.PGEx1.DocCommentDescription.ImageKey = resources.GetString("PGEx1.DocCommentDescription.ImageKey")
        Me.PGEx1.DocCommentDescription.ImeMode = CType(resources.GetObject("PGEx1.DocCommentDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx1.DocCommentDescription.Location = CType(resources.GetObject("PGEx1.DocCommentDescription.Location"), System.Drawing.Point)
        Me.PGEx1.DocCommentDescription.Name = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.PGEx1.DocCommentDescription.RightToLeft = CType(resources.GetObject("PGEx1.DocCommentDescription.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PGEx1.DocCommentDescription.Size = CType(resources.GetObject("PGEx1.DocCommentDescription.Size"), System.Drawing.Size)
        Me.PGEx1.DocCommentDescription.TabIndex = CType(resources.GetObject("PGEx1.DocCommentDescription.TabIndex"), Integer)
        Me.PGEx1.DocCommentDescription.TextAlign = CType(resources.GetObject("PGEx1.DocCommentDescription.TextAlign"), System.Drawing.ContentAlignment)
        Me.PGEx1.DocCommentImage = Nothing
        '
        '
        '
        Me.PGEx1.DocCommentTitle.AccessibleDescription = resources.GetString("PGEx1.DocCommentTitle.AccessibleDescription")
        Me.PGEx1.DocCommentTitle.AccessibleName = resources.GetString("PGEx1.DocCommentTitle.AccessibleName")
        Me.PGEx1.DocCommentTitle.Anchor = CType(resources.GetObject("PGEx1.DocCommentTitle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PGEx1.DocCommentTitle.AutoSize = CType(resources.GetObject("PGEx1.DocCommentTitle.AutoSize"), Boolean)
        Me.PGEx1.DocCommentTitle.BackColor = System.Drawing.Color.Transparent
        Me.PGEx1.DocCommentTitle.BackgroundImageLayout = CType(resources.GetObject("PGEx1.DocCommentTitle.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PGEx1.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PGEx1.DocCommentTitle.Dock = CType(resources.GetObject("PGEx1.DocCommentTitle.Dock"), System.Windows.Forms.DockStyle)
        Me.PGEx1.DocCommentTitle.Font = CType(resources.GetObject("PGEx1.DocCommentTitle.Font"), System.Drawing.Font)
        Me.PGEx1.DocCommentTitle.ImageAlign = CType(resources.GetObject("PGEx1.DocCommentTitle.ImageAlign"), System.Drawing.ContentAlignment)
        Me.PGEx1.DocCommentTitle.ImageIndex = CType(resources.GetObject("PGEx1.DocCommentTitle.ImageIndex"), Integer)
        Me.PGEx1.DocCommentTitle.ImageKey = resources.GetString("PGEx1.DocCommentTitle.ImageKey")
        Me.PGEx1.DocCommentTitle.ImeMode = CType(resources.GetObject("PGEx1.DocCommentTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx1.DocCommentTitle.Location = CType(resources.GetObject("PGEx1.DocCommentTitle.Location"), System.Drawing.Point)
        Me.PGEx1.DocCommentTitle.Name = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.PGEx1.DocCommentTitle.RightToLeft = CType(resources.GetObject("PGEx1.DocCommentTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PGEx1.DocCommentTitle.Size = CType(resources.GetObject("PGEx1.DocCommentTitle.Size"), System.Drawing.Size)
        Me.PGEx1.DocCommentTitle.TabIndex = CType(resources.GetObject("PGEx1.DocCommentTitle.TabIndex"), Integer)
        Me.PGEx1.DocCommentTitle.TextAlign = CType(resources.GetObject("PGEx1.DocCommentTitle.TextAlign"), System.Drawing.ContentAlignment)
        Me.PGEx1.DocCommentTitle.UseMnemonic = False
        Me.PGEx1.Name = "PGEx1"
        Me.PGEx1.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.PGEx1.SelectedObject = CType(resources.GetObject("PGEx1.SelectedObject"), Object)
        Me.PGEx1.ShowCustomProperties = True
        Me.PGEx1.ToolbarVisible = False
        '
        '
        '
        Me.PGEx1.ToolStrip.AccessibleDescription = resources.GetString("PGEx1.ToolStrip.AccessibleDescription")
        Me.PGEx1.ToolStrip.AccessibleName = resources.GetString("PGEx1.ToolStrip.AccessibleName")
        Me.PGEx1.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.PGEx1.ToolStrip.AllowMerge = False
        Me.PGEx1.ToolStrip.Anchor = CType(resources.GetObject("PGEx1.ToolStrip.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PGEx1.ToolStrip.AutoSize = CType(resources.GetObject("PGEx1.ToolStrip.AutoSize"), Boolean)
        Me.PGEx1.ToolStrip.BackgroundImage = CType(resources.GetObject("PGEx1.ToolStrip.BackgroundImage"), System.Drawing.Image)
        Me.PGEx1.ToolStrip.BackgroundImageLayout = CType(resources.GetObject("PGEx1.ToolStrip.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PGEx1.ToolStrip.CanOverflow = False
        Me.PGEx1.ToolStrip.Dock = CType(resources.GetObject("PGEx1.ToolStrip.Dock"), System.Windows.Forms.DockStyle)
        Me.PGEx1.ToolStrip.Font = CType(resources.GetObject("PGEx1.ToolStrip.Font"), System.Drawing.Font)
        Me.PGEx1.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PGEx1.ToolStrip.ImeMode = CType(resources.GetObject("PGEx1.ToolStrip.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx1.ToolStrip.Location = CType(resources.GetObject("PGEx1.ToolStrip.Location"), System.Drawing.Point)
        Me.PGEx1.ToolStrip.Name = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.PGEx1.ToolStrip.Padding = CType(resources.GetObject("PGEx1.ToolStrip.Padding"), System.Windows.Forms.Padding)
        Me.PGEx1.ToolStrip.RightToLeft = CType(resources.GetObject("PGEx1.ToolStrip.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PGEx1.ToolStrip.Size = CType(resources.GetObject("PGEx1.ToolStrip.Size"), System.Drawing.Size)
        Me.PGEx1.ToolStrip.TabIndex = CType(resources.GetObject("PGEx1.ToolStrip.TabIndex"), Integer)
        Me.PGEx1.ToolStrip.TabStop = True
        Me.PGEx1.ToolStrip.Text = "PropertyGrid Toolbar"
        Me.PGEx1.ToolStrip.Visible = CType(resources.GetObject("PGEx1.ToolStrip.Visible"), Boolean)
        '
        'TSObj
        '
        resources.ApplyResources(Me.TSObj, "TSObj")
        Me.TSObj.CanClose = False
        Me.TSObj.Controls.Add(Me.PGEx2)
        Me.TSObj.IsDrawn = True
        Me.TSObj.Name = "TSObj"
        '
        'PGEx2
        '
        resources.ApplyResources(Me.PGEx2, "PGEx2")
        '
        '
        '
        Me.PGEx2.DocCommentDescription.AccessibleDescription = resources.GetString("PGEx2.DocCommentDescription.AccessibleDescription")
        Me.PGEx2.DocCommentDescription.AccessibleName = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.PGEx2.DocCommentDescription.Anchor = CType(resources.GetObject("PGEx2.DocCommentDescription.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PGEx2.DocCommentDescription.AutoEllipsis = True
        Me.PGEx2.DocCommentDescription.AutoSize = CType(resources.GetObject("PGEx2.DocCommentDescription.AutoSize"), Boolean)
        Me.PGEx2.DocCommentDescription.BackColor = System.Drawing.Color.Transparent
        Me.PGEx2.DocCommentDescription.BackgroundImageLayout = CType(resources.GetObject("PGEx2.DocCommentDescription.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PGEx2.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.PGEx2.DocCommentDescription.Dock = CType(resources.GetObject("PGEx2.DocCommentDescription.Dock"), System.Windows.Forms.DockStyle)
        Me.PGEx2.DocCommentDescription.Font = CType(resources.GetObject("PGEx2.DocCommentDescription.Font"), System.Drawing.Font)
        Me.PGEx2.DocCommentDescription.ImageAlign = CType(resources.GetObject("PGEx2.DocCommentDescription.ImageAlign"), System.Drawing.ContentAlignment)
        Me.PGEx2.DocCommentDescription.ImageIndex = CType(resources.GetObject("PGEx2.DocCommentDescription.ImageIndex"), Integer)
        Me.PGEx2.DocCommentDescription.ImageKey = resources.GetString("PGEx2.DocCommentDescription.ImageKey")
        Me.PGEx2.DocCommentDescription.ImeMode = CType(resources.GetObject("PGEx2.DocCommentDescription.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx2.DocCommentDescription.Location = CType(resources.GetObject("PGEx2.DocCommentDescription.Location"), System.Drawing.Point)
        Me.PGEx2.DocCommentDescription.Name = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.PGEx2.DocCommentDescription.RightToLeft = CType(resources.GetObject("PGEx2.DocCommentDescription.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PGEx2.DocCommentDescription.Size = CType(resources.GetObject("PGEx2.DocCommentDescription.Size"), System.Drawing.Size)
        Me.PGEx2.DocCommentDescription.TabIndex = CType(resources.GetObject("PGEx2.DocCommentDescription.TabIndex"), Integer)
        Me.PGEx2.DocCommentDescription.TextAlign = CType(resources.GetObject("PGEx2.DocCommentDescription.TextAlign"), System.Drawing.ContentAlignment)
        Me.PGEx2.DocCommentImage = Nothing
        '
        '
        '
        Me.PGEx2.DocCommentTitle.AccessibleDescription = resources.GetString("PGEx2.DocCommentTitle.AccessibleDescription")
        Me.PGEx2.DocCommentTitle.AccessibleName = resources.GetString("PGEx2.DocCommentTitle.AccessibleName")
        Me.PGEx2.DocCommentTitle.Anchor = CType(resources.GetObject("PGEx2.DocCommentTitle.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PGEx2.DocCommentTitle.AutoSize = CType(resources.GetObject("PGEx2.DocCommentTitle.AutoSize"), Boolean)
        Me.PGEx2.DocCommentTitle.BackColor = System.Drawing.Color.Transparent
        Me.PGEx2.DocCommentTitle.BackgroundImageLayout = CType(resources.GetObject("PGEx2.DocCommentTitle.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PGEx2.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.PGEx2.DocCommentTitle.Dock = CType(resources.GetObject("PGEx2.DocCommentTitle.Dock"), System.Windows.Forms.DockStyle)
        Me.PGEx2.DocCommentTitle.Font = CType(resources.GetObject("PGEx2.DocCommentTitle.Font"), System.Drawing.Font)
        Me.PGEx2.DocCommentTitle.ImageAlign = CType(resources.GetObject("PGEx2.DocCommentTitle.ImageAlign"), System.Drawing.ContentAlignment)
        Me.PGEx2.DocCommentTitle.ImageIndex = CType(resources.GetObject("PGEx2.DocCommentTitle.ImageIndex"), Integer)
        Me.PGEx2.DocCommentTitle.ImageKey = resources.GetString("PGEx2.DocCommentTitle.ImageKey")
        Me.PGEx2.DocCommentTitle.ImeMode = CType(resources.GetObject("PGEx2.DocCommentTitle.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx2.DocCommentTitle.Location = CType(resources.GetObject("PGEx2.DocCommentTitle.Location"), System.Drawing.Point)
        Me.PGEx2.DocCommentTitle.Name = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.PGEx2.DocCommentTitle.RightToLeft = CType(resources.GetObject("PGEx2.DocCommentTitle.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PGEx2.DocCommentTitle.Size = CType(resources.GetObject("PGEx2.DocCommentTitle.Size"), System.Drawing.Size)
        Me.PGEx2.DocCommentTitle.TabIndex = CType(resources.GetObject("PGEx2.DocCommentTitle.TabIndex"), Integer)
        Me.PGEx2.DocCommentTitle.TextAlign = CType(resources.GetObject("PGEx2.DocCommentTitle.TextAlign"), System.Drawing.ContentAlignment)
        Me.PGEx2.DocCommentTitle.UseMnemonic = False
        Me.PGEx2.DrawFlatToolbar = True
        Me.PGEx2.Name = "PGEx2"
        Me.PGEx2.SelectedObject = CType(resources.GetObject("PGEx2.SelectedObject"), Object)
        Me.PGEx2.ShowCustomProperties = True
        Me.PGEx2.ToolbarVisible = False
        '
        '
        '
        Me.PGEx2.ToolStrip.AccessibleDescription = resources.GetString("PGEx2.ToolStrip.AccessibleDescription")
        Me.PGEx2.ToolStrip.AccessibleName = resources.GetString("PGEx2.ToolStrip.AccessibleName")
        Me.PGEx2.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.PGEx2.ToolStrip.AllowMerge = False
        Me.PGEx2.ToolStrip.Anchor = CType(resources.GetObject("PGEx2.ToolStrip.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.PGEx2.ToolStrip.AutoSize = CType(resources.GetObject("PGEx2.ToolStrip.AutoSize"), Boolean)
        Me.PGEx2.ToolStrip.BackgroundImage = CType(resources.GetObject("PGEx2.ToolStrip.BackgroundImage"), System.Drawing.Image)
        Me.PGEx2.ToolStrip.BackgroundImageLayout = CType(resources.GetObject("PGEx2.ToolStrip.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.PGEx2.ToolStrip.CanOverflow = False
        Me.PGEx2.ToolStrip.Dock = CType(resources.GetObject("PGEx2.ToolStrip.Dock"), System.Windows.Forms.DockStyle)
        Me.PGEx2.ToolStrip.Font = CType(resources.GetObject("PGEx2.ToolStrip.Font"), System.Drawing.Font)
        Me.PGEx2.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PGEx2.ToolStrip.ImeMode = CType(resources.GetObject("PGEx2.ToolStrip.ImeMode"), System.Windows.Forms.ImeMode)
        Me.PGEx2.ToolStrip.Location = CType(resources.GetObject("PGEx2.ToolStrip.Location"), System.Drawing.Point)
        Me.PGEx2.ToolStrip.Name = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.PGEx2.ToolStrip.Padding = CType(resources.GetObject("PGEx2.ToolStrip.Padding"), System.Windows.Forms.Padding)
        Me.PGEx2.ToolStrip.RightToLeft = CType(resources.GetObject("PGEx2.ToolStrip.RightToLeft"), System.Windows.Forms.RightToLeft)
        Me.PGEx2.ToolStrip.Size = CType(resources.GetObject("PGEx2.ToolStrip.Size"), System.Drawing.Size)
        Me.PGEx2.ToolStrip.TabIndex = CType(resources.GetObject("PGEx2.ToolStrip.TabIndex"), Integer)
        Me.PGEx2.ToolStrip.TabStop = True
        Me.PGEx2.ToolStrip.Text = "PropertyGrid Toolbar"
        Me.PGEx2.ToolStrip.Visible = CType(resources.GetObject("PGEx2.ToolStrip.Visible"), Boolean)
        '
        'TableLayoutPanel6
        '
        resources.ApplyResources(Me.TableLayoutPanel6, "TableLayoutPanel6")
        Me.TableLayoutPanel6.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.LblNomeObj, 1, 0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ImageKey = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.Label1.Name = "Label1"
        '
        'LblNomeObj
        '
        resources.ApplyResources(Me.LblNomeObj, "LblNomeObj")
        Me.LblNomeObj.ImageKey = Global.RELAP.My.Resources.RELAP.NewVersionAvailable
        Me.LblNomeObj.Name = "LblNomeObj"
        '
        'frmProps
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CloseButton = False
        Me.Controls.Add(Me.TableLayoutPanel5)
        Me.DoubleBuffered = True
        Me.Name = "frmProps"
        Me.Opacity = 0.7R
        Me.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft
        Me.TabText = "Objeto seleccionado"
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        CType(Me.FTSProps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FTSProps.ResumeLayout(False)
        Me.TSProps.ResumeLayout(False)
        Me.TSObj.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents LblStatusObj As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents LblTipoObj As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents FTSProps As FarsiLibrary.Win.FATabStrip
    Public WithEvents TSProps As FarsiLibrary.Win.FATabStripItem
    Public WithEvents PGEx1 As PropertyGridEx.PropertyGridEx
    Public WithEvents TSObj As FarsiLibrary.Win.FATabStripItem
    Public WithEvents PGEx2 As PropertyGridEx.PropertyGridEx
    Public WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents LblNomeObj As System.Windows.Forms.Label
End Class

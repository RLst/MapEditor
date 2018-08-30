namespace MapEditor
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.userManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tilePalette = new System.Windows.Forms.ListView();
			this.propertiesListBox = new System.Windows.Forms.ListBox();
			this.mapWorkArea = new System.Windows.Forms.PictureBox();
			this.addTilesButton = new System.Windows.Forms.Button();
			this.clearButton = new System.Windows.Forms.Button();
			this.removeTilesButton = new System.Windows.Forms.Button();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.menuStrip.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mapWorkArea)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu,
            this.toolsMenu,
            this.windowsMenu,
            this.helpMenu});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.MdiWindowListItem = this.windowsMenu;
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(1712, 28);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			// 
			// fileMenu
			// 
			this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator4,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printSetupToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
			this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
			this.fileMenu.Name = "fileMenu";
			this.fileMenu.Size = new System.Drawing.Size(44, 24);
			this.fileMenu.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
			this.newToolStripMenuItem.Text = "&New Map";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.ShowNewDialog);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
			this.toolStripMenuItem1.Size = new System.Drawing.Size(254, 26);
			this.toolStripMenuItem1.Text = "New &Tileset";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(251, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
			this.exportToolStripMenuItem.Text = "&Export...";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(251, 6);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
			this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
			this.printToolStripMenuItem.Text = "&Print [X]";
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
			this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
			this.printPreviewToolStripMenuItem.Text = "Print Pre&view [X]";
			// 
			// printSetupToolStripMenuItem
			// 
			this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
			this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
			this.printSetupToolStripMenuItem.Text = "Print Setup [X]";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(251, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
			// 
			// editMenu
			// 
			this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator6,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
			this.editMenu.Name = "editMenu";
			this.editMenu.Size = new System.Drawing.Size(47, 24);
			this.editMenu.Text = "&Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
			this.undoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
			this.undoToolStripMenuItem.Text = "&Undo";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
			this.redoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
			this.redoToolStripMenuItem.Text = "&Redo";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(168, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
			this.cutToolStripMenuItem.Text = "Cu&t";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
			this.pasteToolStripMenuItem.Text = "&Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
			// 
			// viewMenu
			// 
			this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
			this.viewMenu.Name = "viewMenu";
			this.viewMenu.Size = new System.Drawing.Size(53, 24);
			this.viewMenu.Text = "&View";
			// 
			// toolBarToolStripMenuItem
			// 
			this.toolBarToolStripMenuItem.Checked = true;
			this.toolBarToolStripMenuItem.CheckOnClick = true;
			this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
			this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
			this.toolBarToolStripMenuItem.Text = "&Toolbar";
			this.toolBarToolStripMenuItem.Click += new System.EventHandler(this.ToolBarToolStripMenuItem_Click);
			// 
			// statusBarToolStripMenuItem
			// 
			this.statusBarToolStripMenuItem.Checked = true;
			this.statusBarToolStripMenuItem.CheckOnClick = true;
			this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
			this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
			this.statusBarToolStripMenuItem.Text = "&Status Bar";
			this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
			// 
			// toolsMenu
			// 
			this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
			this.toolsMenu.Name = "toolsMenu";
			this.toolsMenu.Size = new System.Drawing.Size(56, 24);
			this.toolsMenu.Text = "&Tools";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
			this.optionsToolStripMenuItem.Text = "&Options [X]";
			// 
			// windowsMenu
			// 
			this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
			this.windowsMenu.Name = "windowsMenu";
			this.windowsMenu.Size = new System.Drawing.Size(105, 24);
			this.windowsMenu.Text = "&Windows [X]";
			// 
			// newWindowToolStripMenuItem
			// 
			this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
			this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.newWindowToolStripMenuItem.Text = "&New Window";
			this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.ShowNewDialog);
			// 
			// cascadeToolStripMenuItem
			// 
			this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
			this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.cascadeToolStripMenuItem.Text = "&Cascade";
			this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
			// 
			// tileVerticalToolStripMenuItem
			// 
			this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
			this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
			this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
			// 
			// tileHorizontalToolStripMenuItem
			// 
			this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
			this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
			this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
			// 
			// closeAllToolStripMenuItem
			// 
			this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
			this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.closeAllToolStripMenuItem.Text = "C&lose All";
			this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
			// 
			// arrangeIconsToolStripMenuItem
			// 
			this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
			this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
			this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
			// 
			// helpMenu
			// 
			this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManualToolStripMenuItem});
			this.helpMenu.Name = "helpMenu";
			this.helpMenu.Size = new System.Drawing.Size(53, 24);
			this.helpMenu.Text = "&Help";
			// 
			// userManualToolStripMenuItem
			// 
			this.userManualToolStripMenuItem.Name = "userManualToolStripMenuItem";
			this.userManualToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.userManualToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
			this.userManualToolStripMenuItem.Text = "User Manual";
			this.userManualToolStripMenuItem.Click += new System.EventHandler(this.userManualToolStripMenuItem_Click);
			// 
			// toolStrip
			// 
			this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
			this.toolStrip.Location = new System.Drawing.Point(0, 28);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(1712, 27);
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "ToolStrip";
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(24, 24);
			this.newToolStripButton.Text = "New";
			this.newToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.newToolStripButton.ToolTipText = "Create new documents";
			this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
			this.openToolStripButton.Text = "Open";
			this.openToolStripButton.Click += new System.EventHandler(this.OpenFile);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
			this.saveToolStripButton.Text = "Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size(24, 24);
			this.helpToolStripButton.Text = "Help";
			this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 871);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip.Size = new System.Drawing.Size(1712, 25);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "StatusStrip";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
			this.toolStripStatusLabel.Text = "Status";
			// 
			// tilePalette
			// 
			this.tilePalette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tilePalette.Location = new System.Drawing.Point(1317, 117);
			this.tilePalette.Margin = new System.Windows.Forms.Padding(4);
			this.tilePalette.Name = "tilePalette";
			this.tilePalette.Size = new System.Drawing.Size(377, 517);
			this.tilePalette.TabIndex = 4;
			this.tilePalette.UseCompatibleStateImageBehavior = false;
			// 
			// propertiesListBox
			// 
			this.propertiesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.propertiesListBox.FormattingEnabled = true;
			this.propertiesListBox.ItemHeight = 16;
			this.propertiesListBox.Location = new System.Drawing.Point(1317, 652);
			this.propertiesListBox.Margin = new System.Windows.Forms.Padding(4);
			this.propertiesListBox.Name = "propertiesListBox";
			this.propertiesListBox.Size = new System.Drawing.Size(377, 212);
			this.propertiesListBox.TabIndex = 5;
			// 
			// mapWorkArea
			// 
			this.mapWorkArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mapWorkArea.Location = new System.Drawing.Point(16, 64);
			this.mapWorkArea.Margin = new System.Windows.Forms.Padding(4);
			this.mapWorkArea.Name = "mapWorkArea";
			this.mapWorkArea.Size = new System.Drawing.Size(1296, 801);
			this.mapWorkArea.TabIndex = 3;
			this.mapWorkArea.TabStop = false;
			// 
			// addTilesButton
			// 
			this.addTilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addTilesButton.Location = new System.Drawing.Point(1317, 64);
			this.addTilesButton.Margin = new System.Windows.Forms.Padding(4);
			this.addTilesButton.Name = "addTilesButton";
			this.addTilesButton.Size = new System.Drawing.Size(124, 46);
			this.addTilesButton.TabIndex = 6;
			this.addTilesButton.Text = "Add Tiles...";
			this.addTilesButton.UseVisualStyleBackColor = true;
			this.addTilesButton.Click += new System.EventHandler(this.AddTilesButton_Click);
			// 
			// clearButton
			// 
			this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.clearButton.Location = new System.Drawing.Point(1579, 64);
			this.clearButton.Margin = new System.Windows.Forms.Padding(4);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(117, 46);
			this.clearButton.TabIndex = 6;
			this.clearButton.Text = "Clear All";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.ClearTilesButton_Click);
			// 
			// removeTilesButton
			// 
			this.removeTilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.removeTilesButton.Location = new System.Drawing.Point(1449, 64);
			this.removeTilesButton.Margin = new System.Windows.Forms.Padding(4);
			this.removeTilesButton.Name = "removeTilesButton";
			this.removeTilesButton.Size = new System.Drawing.Size(121, 46);
			this.removeTilesButton.TabIndex = 7;
			this.removeTilesButton.Text = "Remove Tiles";
			this.removeTilesButton.UseVisualStyleBackColor = true;
			this.removeTilesButton.Click += new System.EventHandler(this.RemoveTilesButton_Click);
			// 
			// EditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1712, 896);
			this.Controls.Add(this.removeTilesButton);
			this.Controls.Add(this.clearButton);
			this.Controls.Add(this.addTilesButton);
			this.Controls.Add(this.propertiesListBox);
			this.Controls.Add(this.tilePalette);
			this.Controls.Add(this.mapWorkArea);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "EditorForm";
			this.Text = "pkr Map Editor";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mapWorkArea)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ListView tilePalette;
        private System.Windows.Forms.ListBox propertiesListBox;
        private System.Windows.Forms.PictureBox mapWorkArea;
		private System.Windows.Forms.Button addTilesButton;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.ToolStripMenuItem userManualToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.Button removeTilesButton;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
	}
}




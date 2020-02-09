namespace JpCrosswordSolverUI
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSolveStep = new System.Windows.Forms.Button();
			this.splitContainerCommon = new System.Windows.Forms.SplitContainer();
			this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
			this.splitContainerRight = new System.Windows.Forms.SplitContainer();
			this.cbEmpty = new System.Windows.Forms.CheckBox();
			this.cbFilled = new System.Windows.Forms.CheckBox();
			this.cbNone = new System.Windows.Forms.CheckBox();
			this.gbContainer = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbVerticalAffiliation = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbVerticalGroups = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbHorizontalAffiliation = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbHorizontalGroups = new System.Windows.Forms.TextBox();
			this.tbCoordinates = new System.Windows.Forms.TextBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerCommon)).BeginInit();
			this.splitContainerCommon.Panel1.SuspendLayout();
			this.splitContainerCommon.Panel2.SuspendLayout();
			this.splitContainerCommon.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
			this.splitContainerLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
			this.splitContainerRight.SuspendLayout();
			this.gbContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(938, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.newToolStripMenuItem.Text = "&New";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
			this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.printToolStripMenuItem.Text = "&Print";
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
			this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			this.redoToolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// customizeToolStripMenuItem
			// 
			this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
			this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.customizeToolStripMenuItem.Text = "&Customize";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.contentsToolStripMenuItem.Text = "&Contents";
			// 
			// indexToolStripMenuItem
			// 
			this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.indexToolStripMenuItem.Text = "&Index";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.searchToolStripMenuItem.Text = "&Search";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			// 
			// btnSolveStep
			// 
			this.btnSolveStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSolveStep.Location = new System.Drawing.Point(851, 27);
			this.btnSolveStep.Name = "btnSolveStep";
			this.btnSolveStep.Size = new System.Drawing.Size(75, 23);
			this.btnSolveStep.TabIndex = 3;
			this.btnSolveStep.TabStop = false;
			this.btnSolveStep.Text = "Solve step";
			this.btnSolveStep.UseVisualStyleBackColor = true;
			this.btnSolveStep.Click += new System.EventHandler(this.BtnSolveStep_Click);
			// 
			// splitContainerCommon
			// 
			this.splitContainerCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerCommon.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerCommon.IsSplitterFixed = true;
			this.splitContainerCommon.Location = new System.Drawing.Point(12, 27);
			this.splitContainerCommon.Name = "splitContainerCommon";
			// 
			// splitContainerCommon.Panel1
			// 
			this.splitContainerCommon.Panel1.Controls.Add(this.splitContainerLeft);
			// 
			// splitContainerCommon.Panel2
			// 
			this.splitContainerCommon.Panel2.Controls.Add(this.splitContainerRight);
			this.splitContainerCommon.Size = new System.Drawing.Size(776, 491);
			this.splitContainerCommon.SplitterDistance = 52;
			this.splitContainerCommon.TabIndex = 5;
			// 
			// splitContainerLeft
			// 
			this.splitContainerLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerLeft.IsSplitterFixed = true;
			this.splitContainerLeft.Location = new System.Drawing.Point(0, 0);
			this.splitContainerLeft.Name = "splitContainerLeft";
			this.splitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.splitContainerLeft.Size = new System.Drawing.Size(52, 491);
			this.splitContainerLeft.SplitterDistance = 30;
			this.splitContainerLeft.TabIndex = 0;
			this.splitContainerLeft.TabStop = false;
			// 
			// splitContainerRight
			// 
			this.splitContainerRight.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainerRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerRight.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerRight.IsSplitterFixed = true;
			this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
			this.splitContainerRight.Name = "splitContainerRight";
			this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerRight.Panel1
			// 
			this.splitContainerRight.Panel1.Resize += new System.EventHandler(this.SplitContainerRight_Panel1_Resize);
			this.splitContainerRight.Size = new System.Drawing.Size(720, 491);
			this.splitContainerRight.SplitterDistance = 33;
			this.splitContainerRight.TabIndex = 0;
			this.splitContainerRight.TabStop = false;
			// 
			// cbEmpty
			// 
			this.cbEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbEmpty.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbEmpty.AutoSize = true;
			this.cbEmpty.Image = global::JpCrosswordSolverUI.Properties.Resources.Empty;
			this.cbEmpty.Location = new System.Drawing.Point(886, 56);
			this.cbEmpty.MaximumSize = new System.Drawing.Size(40, 40);
			this.cbEmpty.MinimumSize = new System.Drawing.Size(40, 40);
			this.cbEmpty.Name = "cbEmpty";
			this.cbEmpty.Size = new System.Drawing.Size(40, 40);
			this.cbEmpty.TabIndex = 7;
			this.cbEmpty.UseVisualStyleBackColor = true;
			this.cbEmpty.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbEmpty_MouseDown);
			// 
			// cbFilled
			// 
			this.cbFilled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFilled.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbFilled.AutoSize = true;
			this.cbFilled.Image = global::JpCrosswordSolverUI.Properties.Resources.Filled;
			this.cbFilled.Location = new System.Drawing.Point(840, 56);
			this.cbFilled.MaximumSize = new System.Drawing.Size(40, 40);
			this.cbFilled.MinimumSize = new System.Drawing.Size(40, 40);
			this.cbFilled.Name = "cbFilled";
			this.cbFilled.Size = new System.Drawing.Size(40, 40);
			this.cbFilled.TabIndex = 7;
			this.cbFilled.UseVisualStyleBackColor = true;
			this.cbFilled.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbFilled_MouseDown);
			// 
			// cbNone
			// 
			this.cbNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbNone.Appearance = System.Windows.Forms.Appearance.Button;
			this.cbNone.AutoSize = true;
			this.cbNone.ForeColor = System.Drawing.Color.Black;
			this.cbNone.Image = global::JpCrosswordSolverUI.Properties.Resources.None;
			this.cbNone.Location = new System.Drawing.Point(794, 56);
			this.cbNone.MaximumSize = new System.Drawing.Size(40, 40);
			this.cbNone.MinimumSize = new System.Drawing.Size(40, 40);
			this.cbNone.Name = "cbNone";
			this.cbNone.Size = new System.Drawing.Size(40, 40);
			this.cbNone.TabIndex = 7;
			this.cbNone.UseVisualStyleBackColor = true;
			this.cbNone.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbNone_MouseDown);
			// 
			// gbContainer
			// 
			this.gbContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbContainer.Controls.Add(this.label5);
			this.gbContainer.Controls.Add(this.tbVerticalAffiliation);
			this.gbContainer.Controls.Add(this.label4);
			this.gbContainer.Controls.Add(this.label2);
			this.gbContainer.Controls.Add(this.tbVerticalGroups);
			this.gbContainer.Controls.Add(this.label3);
			this.gbContainer.Controls.Add(this.tbHorizontalAffiliation);
			this.gbContainer.Controls.Add(this.label1);
			this.gbContainer.Controls.Add(this.tbHorizontalGroups);
			this.gbContainer.Controls.Add(this.tbCoordinates);
			this.gbContainer.Location = new System.Drawing.Point(794, 102);
			this.gbContainer.Name = "gbContainer";
			this.gbContainer.Size = new System.Drawing.Size(132, 416);
			this.gbContainer.TabIndex = 8;
			this.gbContainer.TabStop = false;
			this.gbContainer.Text = "Info";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 114);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Vertical:";
			// 
			// tbVerticalAffiliation
			// 
			this.tbVerticalAffiliation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbVerticalAffiliation.Location = new System.Drawing.Point(6, 130);
			this.tbVerticalAffiliation.Multiline = true;
			this.tbVerticalAffiliation.Name = "tbVerticalAffiliation";
			this.tbVerticalAffiliation.ReadOnly = true;
			this.tbVerticalAffiliation.Size = new System.Drawing.Size(120, 20);
			this.tbVerticalAffiliation.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 75);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Horizontal:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 236);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Vertical groups:";
			// 
			// tbVerticalGroups
			// 
			this.tbVerticalGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbVerticalGroups.Location = new System.Drawing.Point(6, 252);
			this.tbVerticalGroups.Multiline = true;
			this.tbVerticalGroups.Name = "tbVerticalGroups";
			this.tbVerticalGroups.ReadOnly = true;
			this.tbVerticalGroups.Size = new System.Drawing.Size(120, 40);
			this.tbVerticalGroups.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(6, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Affiliation";
			// 
			// tbHorizontalAffiliation
			// 
			this.tbHorizontalAffiliation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbHorizontalAffiliation.Location = new System.Drawing.Point(6, 91);
			this.tbHorizontalAffiliation.Multiline = true;
			this.tbHorizontalAffiliation.Name = "tbHorizontalAffiliation";
			this.tbHorizontalAffiliation.ReadOnly = true;
			this.tbHorizontalAffiliation.Size = new System.Drawing.Size(120, 20);
			this.tbHorizontalAffiliation.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 177);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Horizontal groups:";
			// 
			// tbHorizontalGroups
			// 
			this.tbHorizontalGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbHorizontalGroups.Location = new System.Drawing.Point(6, 193);
			this.tbHorizontalGroups.Multiline = true;
			this.tbHorizontalGroups.Name = "tbHorizontalGroups";
			this.tbHorizontalGroups.ReadOnly = true;
			this.tbHorizontalGroups.Size = new System.Drawing.Size(120, 40);
			this.tbHorizontalGroups.TabIndex = 1;
			// 
			// tbCoordinates
			// 
			this.tbCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCoordinates.Location = new System.Drawing.Point(6, 19);
			this.tbCoordinates.Name = "tbCoordinates";
			this.tbCoordinates.ReadOnly = true;
			this.tbCoordinates.Size = new System.Drawing.Size(120, 20);
			this.tbCoordinates.TabIndex = 0;
			// 
			// btnReset
			// 
			this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReset.Location = new System.Drawing.Point(794, 27);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(51, 23);
			this.btnReset.TabIndex = 9;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(938, 530);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.gbContainer);
			this.Controls.Add(this.cbEmpty);
			this.Controls.Add(this.cbFilled);
			this.Controls.Add(this.cbNone);
			this.Controls.Add(this.splitContainerCommon);
			this.Controls.Add(this.btnSolveStep);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Jp crossword solver";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainerCommon.Panel1.ResumeLayout(false);
			this.splitContainerCommon.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerCommon)).EndInit();
			this.splitContainerCommon.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
			this.splitContainerLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
			this.splitContainerRight.ResumeLayout(false);
			this.gbContainer.ResumeLayout(false);
			this.gbContainer.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Button btnSolveStep;
		private System.Windows.Forms.SplitContainer splitContainerCommon;
		private System.Windows.Forms.SplitContainer splitContainerLeft;
		private System.Windows.Forms.SplitContainer splitContainerRight;
		private System.Windows.Forms.CheckBox cbNone;
		private System.Windows.Forms.CheckBox cbFilled;
		private System.Windows.Forms.CheckBox cbEmpty;
		private System.Windows.Forms.GroupBox gbContainer;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbVerticalAffiliation;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbVerticalGroups;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbHorizontalAffiliation;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbHorizontalGroups;
		private System.Windows.Forms.TextBox tbCoordinates;
		private System.Windows.Forms.Button btnReset;
	}
}


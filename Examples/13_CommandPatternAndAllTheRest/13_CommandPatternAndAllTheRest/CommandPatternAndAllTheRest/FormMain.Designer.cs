namespace WindowsControlsAndDialogs
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Bsc");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Msc");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Computer Science", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Politics");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Scicology");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Management");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("MTA", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelSelectedStudent = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressLoadStudents = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mitFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mitFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mitFileSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mitFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mitEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdEditProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.mitView = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewTree = new System.Windows.Forms.ToolStripMenuItem();
            this.dugmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsButtonFileOpen = new System.Windows.Forms.ToolStripButton();
            this.cmdEditProperties_ = new System.Windows.Forms.ToolStripButton();
            this.tsMenuView = new System.Windows.Forms.ToolStripDropDownButton();
            this.cmdViewLargeIcons_ = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewSmallIcons_ = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewList_ = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewDetails_ = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdViewTree_ = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewFaculties = new System.Windows.Forms.TreeView();
            this.imageListFacultiesTree = new System.Windows.Forms.ImageList(this.components);
            this.listViewStudents = new System.Windows.Forms.ListView();
            this.colHeaderFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListStudentLevels = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelSelectedStudent,
            this.progressLoadStudents});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(739, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelSelectedStudent
            // 
            this.labelSelectedStudent.Name = "labelSelectedStudent";
            this.labelSelectedStudent.Size = new System.Drawing.Size(125, 17);
            this.labelSelectedStudent.Text = "[labelSelectedStudent]";
            // 
            // progressLoadStudents
            // 
            this.progressLoadStudents.Name = "progressLoadStudents";
            this.progressLoadStudents.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitFile,
            this.mitEdit,
            this.mitView,
            this.dugmaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(739, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mitFile
            // 
            this.mitFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitFileOpen,
            this.mitFileSep1,
            this.mitFileExit});
            this.mitFile.Name = "mitFile";
            this.mitFile.Size = new System.Drawing.Size(37, 20);
            this.mitFile.Text = "&File";
            // 
            // mitFileOpen
            // 
            this.mitFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("mitFileOpen.Image")));
            this.mitFileOpen.Name = "mitFileOpen";
            this.mitFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mitFileOpen.Size = new System.Drawing.Size(146, 22);
            this.mitFileOpen.Text = "&Open";
            this.mitFileOpen.Click += new System.EventHandler(this.mitFileOpen_Click);
            // 
            // mitFileSep1
            // 
            this.mitFileSep1.Name = "mitFileSep1";
            this.mitFileSep1.Size = new System.Drawing.Size(143, 6);
            // 
            // mitFileExit
            // 
            this.mitFileExit.Name = "mitFileExit";
            this.mitFileExit.Size = new System.Drawing.Size(146, 22);
            this.mitFileExit.Text = "Exit";
            // 
            // mitEdit
            // 
            this.mitEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdEditProperties});
            this.mitEdit.Name = "mitEdit";
            this.mitEdit.Size = new System.Drawing.Size(39, 20);
            this.mitEdit.Text = "&Edit";
            // 
            // cmdEditProperties
            // 
            this.cmdEditProperties.Image = global::WindowsControlsAndDialogs.Properties.Resources._FreeTextUp03;
            this.cmdEditProperties.Name = "cmdEditProperties";
            this.cmdEditProperties.Size = new System.Drawing.Size(159, 22);
            this.cmdEditProperties.Text = "Edit &Properties...";
            this.cmdEditProperties.ToolTipText = "Edit Student Properties...";
            // 
            // mitView
            // 
            this.mitView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdViewLargeIcons,
            this.cmdViewSmallIcons,
            this.cmdViewList,
            this.cmdViewDetails,
            this.cmdViewTree});
            this.mitView.Name = "mitView";
            this.mitView.Size = new System.Drawing.Size(44, 20);
            this.mitView.Text = "View";
            // 
            // cmdViewLargeIcons
            // 
            this.cmdViewLargeIcons.Name = "cmdViewLargeIcons";
            this.cmdViewLargeIcons.Size = new System.Drawing.Size(155, 22);
            this.cmdViewLargeIcons.Text = "Large Icons";
            this.cmdViewLargeIcons.ToolTipText = "Large Icons";
            // 
            // cmdViewSmallIcons
            // 
            this.cmdViewSmallIcons.Name = "cmdViewSmallIcons";
            this.cmdViewSmallIcons.Size = new System.Drawing.Size(155, 22);
            this.cmdViewSmallIcons.Text = "Small Icons";
            this.cmdViewSmallIcons.ToolTipText = "Small Icons";
            // 
            // cmdViewList
            // 
            this.cmdViewList.Name = "cmdViewList";
            this.cmdViewList.Size = new System.Drawing.Size(155, 22);
            this.cmdViewList.Text = "List";
            this.cmdViewList.ToolTipText = "List";
            // 
            // cmdViewDetails
            // 
            this.cmdViewDetails.Image = global::WindowsControlsAndDialogs.Properties.Resources.MultiSelectUp02;
            this.cmdViewDetails.Name = "cmdViewDetails";
            this.cmdViewDetails.Size = new System.Drawing.Size(155, 22);
            this.cmdViewDetails.Text = "Details";
            this.cmdViewDetails.ToolTipText = "Details";
            // 
            // cmdViewTree
            // 
            this.cmdViewTree.Image = global::WindowsControlsAndDialogs.Properties.Resources._MultiChoiceUp;
            this.cmdViewTree.Name = "cmdViewTree";
            this.cmdViewTree.Size = new System.Drawing.Size(155, 22);
            this.cmdViewTree.Text = "View/Hide Tree";
            this.cmdViewTree.Click += new System.EventHandler(this.cmdViewTree_Click);
            // 
            // dugmaToolStripMenuItem
            // 
            this.dugmaToolStripMenuItem.Name = "dugmaToolStripMenuItem";
            this.dugmaToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.dugmaToolStripMenuItem.Text = "Dugma";
            this.dugmaToolStripMenuItem.Click += new System.EventHandler(this.dugmaToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonFileOpen,
            this.cmdEditProperties_,
            this.tsMenuView});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(739, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip2";
            // 
            // tsButtonFileOpen
            // 
            this.tsButtonFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonFileOpen.Image")));
            this.tsButtonFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonFileOpen.Name = "tsButtonFileOpen";
            this.tsButtonFileOpen.Size = new System.Drawing.Size(23, 22);
            this.tsButtonFileOpen.Text = "Open";
            this.tsButtonFileOpen.ToolTipText = "Open Students File";
            this.tsButtonFileOpen.Click += new System.EventHandler(this.tsButtonFileOpen_Click);
            // 
            // cmdEditProperties_
            // 
            this.cmdEditProperties_.Image = global::WindowsControlsAndDialogs.Properties.Resources._FreeTextUp03;
            this.cmdEditProperties_.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEditProperties_.Name = "cmdEditProperties_";
            this.cmdEditProperties_.Size = new System.Drawing.Size(112, 22);
            this.cmdEditProperties_.Text = "Edit Properties...";
            this.cmdEditProperties_.ToolTipText = "Edit Student Properties...";
            // 
            // tsMenuView
            // 
            this.tsMenuView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsMenuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdViewLargeIcons_,
            this.cmdViewSmallIcons_,
            this.cmdViewList_,
            this.cmdViewDetails_,
            this.cmdViewTree_});
            this.tsMenuView.Image = ((System.Drawing.Image)(resources.GetObject("tsMenuView.Image")));
            this.tsMenuView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMenuView.Name = "tsMenuView";
            this.tsMenuView.Size = new System.Drawing.Size(45, 22);
            this.tsMenuView.Text = "View";
            // 
            // cmdViewLargeIcons_
            // 
            this.cmdViewLargeIcons_.Name = "cmdViewLargeIcons_";
            this.cmdViewLargeIcons_.Size = new System.Drawing.Size(155, 22);
            this.cmdViewLargeIcons_.Text = "Large Icons";
            this.cmdViewLargeIcons_.ToolTipText = "Large Icons";
            // 
            // cmdViewSmallIcons_
            // 
            this.cmdViewSmallIcons_.Name = "cmdViewSmallIcons_";
            this.cmdViewSmallIcons_.Size = new System.Drawing.Size(155, 22);
            this.cmdViewSmallIcons_.Text = "Small Icons";
            this.cmdViewSmallIcons_.ToolTipText = "Small Icons";
            // 
            // cmdViewList_
            // 
            this.cmdViewList_.Name = "cmdViewList_";
            this.cmdViewList_.Size = new System.Drawing.Size(155, 22);
            this.cmdViewList_.Text = "List";
            this.cmdViewList_.ToolTipText = "List";
            // 
            // cmdViewDetails_
            // 
            this.cmdViewDetails_.Image = global::WindowsControlsAndDialogs.Properties.Resources.MultiSelectUp02;
            this.cmdViewDetails_.Name = "cmdViewDetails_";
            this.cmdViewDetails_.Size = new System.Drawing.Size(155, 22);
            this.cmdViewDetails_.Text = "Details";
            this.cmdViewDetails_.ToolTipText = "Details";
            // 
            // cmdViewTree_
            // 
            this.cmdViewTree_.Image = global::WindowsControlsAndDialogs.Properties.Resources._MultiChoiceUp;
            this.cmdViewTree_.Name = "cmdViewTree_";
            this.cmdViewTree_.Size = new System.Drawing.Size(155, 22);
            this.cmdViewTree_.Text = "View/Hide Tree";
            this.cmdViewTree_.Click += new System.EventHandler(this.cmdViewTree_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewFaculties);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewStudents);
            this.splitContainer1.Size = new System.Drawing.Size(739, 386);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 4;
            // 
            // treeViewFaculties
            // 
            this.treeViewFaculties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFaculties.ImageIndex = 0;
            this.treeViewFaculties.ImageList = this.imageListFacultiesTree;
            this.treeViewFaculties.Location = new System.Drawing.Point(0, 0);
            this.treeViewFaculties.Name = "treeViewFaculties";
            treeNode1.Name = "Msc";
            treeNode1.Text = "Bsc";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Msc";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Computer Science";
            treeNode4.Name = "Node5";
            treeNode4.Text = "Politics";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Scicology";
            treeNode6.Name = "Node8";
            treeNode6.Text = "Management";
            treeNode7.Name = "Node0";
            treeNode7.Text = "MTA";
            this.treeViewFaculties.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeViewFaculties.SelectedImageIndex = 0;
            this.treeViewFaculties.Size = new System.Drawing.Size(195, 386);
            this.treeViewFaculties.TabIndex = 0;
            // 
            // imageListFacultiesTree
            // 
            this.imageListFacultiesTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFacultiesTree.ImageStream")));
            this.imageListFacultiesTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFacultiesTree.Images.SetKeyName(0, "group02_16.ico");
            // 
            // listViewStudents
            // 
            this.listViewStudents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderFirstName,
            this.colHeaderLastName,
            this.colHeaderPhone,
            this.colHeaderAge});
            this.listViewStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewStudents.FullRowSelect = true;
            this.listViewStudents.Location = new System.Drawing.Point(0, 0);
            this.listViewStudents.Name = "listViewStudents";
            this.listViewStudents.Size = new System.Drawing.Size(540, 386);
            this.listViewStudents.SmallImageList = this.imageListStudentLevels;
            this.listViewStudents.TabIndex = 0;
            this.listViewStudents.UseCompatibleStateImageBehavior = false;
            this.listViewStudents.View = System.Windows.Forms.View.Details;
            this.listViewStudents.ItemActivate += new System.EventHandler(this.listViewStudents_ItemActivate);
            this.listViewStudents.SelectedIndexChanged += new System.EventHandler(this.listViewStudents_SelectedIndexChanged);
            // 
            // colHeaderFirstName
            // 
            this.colHeaderFirstName.Text = "First Name";
            this.colHeaderFirstName.Width = 100;
            // 
            // colHeaderLastName
            // 
            this.colHeaderLastName.Text = "Last Name";
            this.colHeaderLastName.Width = 100;
            // 
            // colHeaderPhone
            // 
            this.colHeaderPhone.Text = "Phone";
            this.colHeaderPhone.Width = 100;
            // 
            // colHeaderAge
            // 
            this.colHeaderAge.Text = "Age";
            // 
            // imageListStudentLevels
            // 
            this.imageListStudentLevels.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStudentLevels.ImageStream")));
            this.imageListStudentLevels.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListStudentLevels.Images.SetKeyName(0, "Failed");
            this.imageListStudentLevels.Images.SetKeyName(1, "Regular");
            this.imageListStudentLevels.Images.SetKeyName(2, "Excellent");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Students Data.txt";
            this.openFileDialog1.InitialDirectory = ".";
            this.openFileDialog1.Title = "Select a data file to read students data from";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 457);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RichControlsAndDocking";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelSelectedStudent;
        private System.Windows.Forms.ToolStripProgressBar progressLoadStudents;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mitFile;
        private System.Windows.Forms.ToolStripMenuItem mitFileOpen;
        private System.Windows.Forms.ToolStripSeparator mitFileSep1;
        private System.Windows.Forms.ToolStripMenuItem mitFileExit;
        private System.Windows.Forms.ToolStripMenuItem mitEdit;
        private System.Windows.Forms.ToolStripMenuItem cmdEditProperties;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsButtonFileOpen;
        private System.Windows.Forms.ToolStripButton cmdEditProperties_;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewFaculties;
        private System.Windows.Forms.ListView listViewStudents;
        private System.Windows.Forms.ImageList imageListFacultiesTree;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mitView;
        private System.Windows.Forms.ToolStripMenuItem cmdViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem cmdViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem cmdViewList;
        private System.Windows.Forms.ToolStripMenuItem cmdViewDetails;
        private System.Windows.Forms.ColumnHeader colHeaderFirstName;
        private System.Windows.Forms.ColumnHeader colHeaderPhone;
        private System.Windows.Forms.ColumnHeader colHeaderLastName;
        private System.Windows.Forms.ImageList imageListStudentLevels;
        private System.Windows.Forms.ColumnHeader colHeaderAge;
        private System.Windows.Forms.ToolStripDropDownButton tsMenuView;
        private System.Windows.Forms.ToolStripMenuItem cmdViewLargeIcons_;
        private System.Windows.Forms.ToolStripMenuItem cmdViewSmallIcons_;
        private System.Windows.Forms.ToolStripMenuItem cmdViewList_;
        private System.Windows.Forms.ToolStripMenuItem cmdViewDetails_;
        private System.Windows.Forms.ToolStripMenuItem cmdViewTree;
        private System.Windows.Forms.ToolStripMenuItem cmdViewTree_;
        private System.Windows.Forms.ToolStripMenuItem dugmaToolStripMenuItem;
    }
}
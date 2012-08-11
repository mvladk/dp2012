namespace WindowsControlsAndDialogs
{
    partial class RichControlsAndDocking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RichControlsAndDocking));
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
            this.mitEditEditProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.mitView = new System.Windows.Forms.ToolStripMenuItem();
            this.mitViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.mitViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.mitViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.mitViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.mitHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mitHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsLableAddress = new System.Windows.Forms.ToolStripLabel();
            this.tsTextBoxAddress = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsButtonFileOpen = new System.Windows.Forms.ToolStripButton();
            this.tsButtonEditProperties = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewFaculties = new System.Windows.Forms.TreeView();
            this.imageListFacultiesTree = new System.Windows.Forms.ImageList(this.components);
            this.listViewStudents = new System.Windows.Forms.ListView();
            this.colHeaderFirstName = new System.Windows.Forms.ColumnHeader();
            this.colHeaderLastName = new System.Windows.Forms.ColumnHeader();
            this.colHeaderPhone = new System.Windows.Forms.ColumnHeader();
            this.colHeaderAge = new System.Windows.Forms.ColumnHeader();
            this.imageListStudentLevels = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 370);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(676, 22);
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
            this.mitHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
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
            this.mitEditEditProperties});
            this.mitEdit.Name = "mitEdit";
            this.mitEdit.Size = new System.Drawing.Size(39, 20);
            this.mitEdit.Text = "&Edit";
            // 
            // mitEditEditProperties
            // 
            this.mitEditEditProperties.Image = global::WindowsControlsAndDialogs.Properties.Resources.MultiSelectUp02;
            this.mitEditEditProperties.Name = "mitEditEditProperties";
            this.mitEditEditProperties.Size = new System.Drawing.Size(159, 22);
            this.mitEditEditProperties.Text = "Edit &Properties...";
            this.mitEditEditProperties.Click += new System.EventHandler(this.editPropertiesToolStripMenuItem_Click);
            // 
            // mitView
            // 
            this.mitView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitViewLargeIcons,
            this.mitViewSmallIcons,
            this.mitViewList,
            this.mitViewDetails});
            this.mitView.Name = "mitView";
            this.mitView.Size = new System.Drawing.Size(44, 20);
            this.mitView.Text = "View";
            // 
            // mitViewLargeIcons
            // 
            this.mitViewLargeIcons.Name = "mitViewLargeIcons";
            this.mitViewLargeIcons.Size = new System.Drawing.Size(134, 22);
            this.mitViewLargeIcons.Text = "Large Icons";
            this.mitViewLargeIcons.Click += new System.EventHandler(this.largeIconsToolStripMenuItem_Click);
            // 
            // mitViewSmallIcons
            // 
            this.mitViewSmallIcons.Name = "mitViewSmallIcons";
            this.mitViewSmallIcons.Size = new System.Drawing.Size(134, 22);
            this.mitViewSmallIcons.Text = "Small Icons";
            this.mitViewSmallIcons.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // mitViewList
            // 
            this.mitViewList.Name = "mitViewList";
            this.mitViewList.Size = new System.Drawing.Size(134, 22);
            this.mitViewList.Text = "List";
            this.mitViewList.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // mitViewDetails
            // 
            this.mitViewDetails.Name = "mitViewDetails";
            this.mitViewDetails.Size = new System.Drawing.Size(134, 22);
            this.mitViewDetails.Text = "Details";
            this.mitViewDetails.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // mitHelp
            // 
            this.mitHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitHelpAbout});
            this.mitHelp.Name = "mitHelp";
            this.mitHelp.Size = new System.Drawing.Size(44, 20);
            this.mitHelp.Text = "&Help";
            // 
            // mitHelpAbout
            // 
            this.mitHelpAbout.Name = "mitHelpAbout";
            this.mitHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.mitHelpAbout.Text = "&About";
            this.mitHelpAbout.Click += new System.EventHandler(this.mitHelpAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLableAddress,
            this.tsTextBoxAddress});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsLableAddress
            // 
            this.tsLableAddress.Name = "tsLableAddress";
            this.tsLableAddress.Size = new System.Drawing.Size(52, 22);
            this.tsLableAddress.Text = "Address:";
            // 
            // tsTextBoxAddress
            // 
            this.tsTextBoxAddress.Name = "tsTextBoxAddress";
            this.tsTextBoxAddress.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonFileOpen,
            this.tsButtonEditProperties});
            this.toolStrip2.Location = new System.Drawing.Point(0, 49);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(676, 25);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
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
            // tsButtonEditProperties
            // 
            this.tsButtonEditProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonEditProperties.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonEditProperties.Image")));
            this.tsButtonEditProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonEditProperties.Name = "tsButtonEditProperties";
            this.tsButtonEditProperties.Size = new System.Drawing.Size(23, 22);
            this.tsButtonEditProperties.Text = "Edit Properties...";
            this.tsButtonEditProperties.ToolTipText = "Edit Student Properties...";
            this.tsButtonEditProperties.Click += new System.EventHandler(this.toolStripButtonEditProperties_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewFaculties);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewStudents);
            this.splitContainer1.Size = new System.Drawing.Size(676, 296);
            this.splitContainer1.SplitterDistance = 179;
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
            this.treeViewFaculties.Size = new System.Drawing.Size(179, 296);
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
            this.listViewStudents.Size = new System.Drawing.Size(493, 296);
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
            // RichControlsAndDocking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 392);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RichControlsAndDocking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RichControlsAndDocking";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem mitEditEditProperties;
        private System.Windows.Forms.ToolStripMenuItem mitHelp;
        private System.Windows.Forms.ToolStripMenuItem mitHelpAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tsLableAddress;
        private System.Windows.Forms.ToolStripTextBox tsTextBoxAddress;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsButtonFileOpen;
        private System.Windows.Forms.ToolStripButton tsButtonEditProperties;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewFaculties;
        private System.Windows.Forms.ListView listViewStudents;
        private System.Windows.Forms.ImageList imageListFacultiesTree;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mitView;
        private System.Windows.Forms.ToolStripMenuItem mitViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem mitViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem mitViewList;
        private System.Windows.Forms.ToolStripMenuItem mitViewDetails;
        private System.Windows.Forms.ColumnHeader colHeaderFirstName;
        private System.Windows.Forms.ColumnHeader colHeaderPhone;
        private System.Windows.Forms.ColumnHeader colHeaderLastName;
        private System.Windows.Forms.ImageList imageListStudentLevels;
        private System.Windows.Forms.ColumnHeader colHeaderAge;
    }
}
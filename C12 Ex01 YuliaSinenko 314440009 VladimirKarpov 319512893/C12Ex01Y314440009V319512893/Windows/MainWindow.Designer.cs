namespace C12Ex01Y314440009V319512893
{
    partial class MainWindow
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.image_smallPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.listBoxPictures = new System.Windows.Forms.ListBox();
            this.imageFriend = new System.Windows.Forms.PictureBox();
            this.listBoxTaggetFriends = new System.Windows.Forms.ListBox();
            this.buttonDowload = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image_smallPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(9, 50);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(95, 37);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // image_smallPictureBox
            // 
            this.image_smallPictureBox.Location = new System.Drawing.Point(112, 5);
            this.image_smallPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.image_smallPictureBox.Name = "image_smallPictureBox";
            this.image_smallPictureBox.Size = new System.Drawing.Size(114, 143);
            this.image_smallPictureBox.TabIndex = 1;
            this.image_smallPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Friends";
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.Location = new System.Drawing.Point(9, 153);
            this.listBoxFriends.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(218, 173);
            this.listBoxFriends.TabIndex = 3;
            this.listBoxFriends.SelectedIndexChanged += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 331);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Alboms";
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.Location = new System.Drawing.Point(9, 345);
            this.listBoxAlbums.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(218, 173);
            this.listBoxAlbums.TabIndex = 5;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // listBoxPictures
            // 
            this.listBoxPictures.FormattingEnabled = true;
            this.listBoxPictures.Location = new System.Drawing.Point(236, 6);
            this.listBoxPictures.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPictures.Name = "listBoxPictures";
            this.listBoxPictures.Size = new System.Drawing.Size(182, 511);
            this.listBoxPictures.TabIndex = 6;
            this.listBoxPictures.SelectedIndexChanged += new System.EventHandler(this.listBoxPictures_SelectedIndexChanged);
            // 
            // imageFriend
            // 
            this.imageFriend.Location = new System.Drawing.Point(444, 12);
            this.imageFriend.Margin = new System.Windows.Forms.Padding(2);
            this.imageFriend.Name = "imageFriend";
            this.imageFriend.Size = new System.Drawing.Size(422, 266);
            this.imageFriend.TabIndex = 7;
            this.imageFriend.TabStop = false;
            // 
            // listBoxTaggetFriends
            // 
            this.listBoxTaggetFriends.FormattingEnabled = true;
            this.listBoxTaggetFriends.Location = new System.Drawing.Point(435, 415);
            this.listBoxTaggetFriends.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxTaggetFriends.Name = "listBoxTaggetFriends";
            this.listBoxTaggetFriends.Size = new System.Drawing.Size(269, 108);
            this.listBoxTaggetFriends.TabIndex = 8;
            // 
            // buttonDowload
            // 
            this.buttonDowload.Location = new System.Drawing.Point(713, 415);
            this.buttonDowload.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDowload.Name = "buttonDowload";
            this.buttonDowload.Size = new System.Drawing.Size(165, 32);
            this.buttonDowload.TabIndex = 9;
            this.buttonDowload.Text = "Dowload Selected";
            this.buttonDowload.UseVisualStyleBackColor = true;
            this.buttonDowload.Click += new System.EventHandler(this.buttonDowload_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(713, 488);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(165, 35);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 532);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDowload);
            this.Controls.Add(this.listBoxTaggetFriends);
            this.Controls.Add(this.imageFriend);
            this.Controls.Add(this.listBoxPictures);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxAlbums);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxFriends);
            this.Controls.Add(this.image_smallPictureBox);
            this.Controls.Add(this.buttonLogin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.Text = "Title";
            ((System.ComponentModel.ISupportInitialize)(this.image_smallPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFriend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.PictureBox image_smallPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.ListBox listBoxPictures;
        private System.Windows.Forms.PictureBox imageFriend;
        private System.Windows.Forms.ListBox listBoxTaggetFriends;
        private System.Windows.Forms.Button buttonDowload;
        private System.Windows.Forms.Button buttonExit;
    }
}


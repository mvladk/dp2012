﻿namespace C12Ex01Y314440009V319512893
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
            this.imageFriend = new System.Windows.Forms.PictureBox();
            this.listBoxTaggetFriends = new System.Windows.Forms.ListBox();
            this.buttonDownloadSelectedPhotos = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.AlbumsPhotosPanel = new System.Windows.Forms.Panel();
            this.folderBrowserDialogForDownload = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBarPhotosDownload = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.image_smallPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(12, 62);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(127, 46);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // image_smallPictureBox
            // 
            this.image_smallPictureBox.Location = new System.Drawing.Point(156, 14);
            this.image_smallPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.image_smallPictureBox.Name = "image_smallPictureBox";
            this.image_smallPictureBox.Size = new System.Drawing.Size(147, 153);
            this.image_smallPictureBox.TabIndex = 1;
            this.image_smallPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Friends";
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 16;
            this.listBoxFriends.Location = new System.Drawing.Point(12, 188);
            this.listBoxFriends.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(289, 212);
            this.listBoxFriends.TabIndex = 3;
            this.listBoxFriends.SelectedIndexChanged += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Alboms";
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 16;
            this.listBoxAlbums.Location = new System.Drawing.Point(12, 425);
            this.listBoxAlbums.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(289, 212);
            this.listBoxAlbums.TabIndex = 5;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // imageFriend
            // 
            this.imageFriend.Location = new System.Drawing.Point(565, 15);
            this.imageFriend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageFriend.Name = "imageFriend";
            this.imageFriend.Size = new System.Drawing.Size(576, 386);
            this.imageFriend.TabIndex = 7;
            this.imageFriend.TabStop = false;
            // 
            // listBoxTaggetFriends
            // 
            this.listBoxTaggetFriends.FormattingEnabled = true;
            this.listBoxTaggetFriends.ItemHeight = 16;
            this.listBoxTaggetFriends.Location = new System.Drawing.Point(565, 470);
            this.listBoxTaggetFriends.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxTaggetFriends.Name = "listBoxTaggetFriends";
            this.listBoxTaggetFriends.Size = new System.Drawing.Size(312, 164);
            this.listBoxTaggetFriends.TabIndex = 8;
            // 
            // buttonDownloadSelectedPhotos
            // 
            this.buttonDownloadSelectedPhotos.Location = new System.Drawing.Point(917, 485);
            this.buttonDownloadSelectedPhotos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDownloadSelectedPhotos.Name = "buttonDownloadSelectedPhotos";
            this.buttonDownloadSelectedPhotos.Size = new System.Drawing.Size(220, 39);
            this.buttonDownloadSelectedPhotos.TabIndex = 9;
            this.buttonDownloadSelectedPhotos.Text = "Dowload Selected";
            this.buttonDownloadSelectedPhotos.UseVisualStyleBackColor = true;
            this.buttonDownloadSelectedPhotos.Click += new System.EventHandler(this.buttonDowload_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(921, 585);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(220, 43);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // AlbumsPhotosPanel
            // 
            this.AlbumsPhotosPanel.AutoScroll = true;
            this.AlbumsPhotosPanel.Location = new System.Drawing.Point(332, 14);
            this.AlbumsPhotosPanel.Margin = new System.Windows.Forms.Padding(4);
            this.AlbumsPhotosPanel.Name = "AlbumsPhotosPanel";
            this.AlbumsPhotosPanel.Size = new System.Drawing.Size(197, 624);
            this.AlbumsPhotosPanel.TabIndex = 11;
            // 
            // progressBarPhotosDownload
            // 
            this.progressBarPhotosDownload.Location = new System.Drawing.Point(919, 470);
            this.progressBarPhotosDownload.Name = "progressBarPhotosDownload";
            this.progressBarPhotosDownload.Size = new System.Drawing.Size(218, 15);
            this.progressBarPhotosDownload.TabIndex = 12;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 655);
            this.Controls.Add(this.progressBarPhotosDownload);
            this.Controls.Add(this.AlbumsPhotosPanel);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDownloadSelectedPhotos);
            this.Controls.Add(this.listBoxTaggetFriends);
            this.Controls.Add(this.imageFriend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxAlbums);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxFriends);
            this.Controls.Add(this.image_smallPictureBox);
            this.Controls.Add(this.buttonLogin);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.PictureBox imageFriend;
        private System.Windows.Forms.ListBox listBoxTaggetFriends;
        private System.Windows.Forms.Button buttonDownloadSelectedPhotos;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel AlbumsPhotosPanel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogForDownload;
        private System.Windows.Forms.ProgressBar progressBarPhotosDownload;
    }
}


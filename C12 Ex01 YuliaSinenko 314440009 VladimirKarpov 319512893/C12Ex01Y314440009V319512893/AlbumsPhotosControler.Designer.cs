﻿using System.Windows.Forms;

namespace C12Ex01Y314440009V319512893
{
    public partial class AlbumsPhotosControler
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxAlbumsPhoto = new System.Windows.Forms.PictureBox();
            this.checkBoxAlbumsPhoto = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumsPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAlbumsPhoto
            // 
            this.pictureBoxAlbumsPhoto.Location = new System.Drawing.Point(3, 4);
            this.pictureBoxAlbumsPhoto.Name = "pictureBoxAlbumsPhoto";
            this.pictureBoxAlbumsPhoto.Size = new System.Drawing.Size(105, 105);
            this.pictureBoxAlbumsPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAlbumsPhoto.TabIndex = 0;
            this.pictureBoxAlbumsPhoto.TabStop = false;
            // 
            // checkBoxAlbumsPhoto
            // 
            this.checkBoxAlbumsPhoto.Location = new System.Drawing.Point(10, 88);
            this.checkBoxAlbumsPhoto.Name = "checkBoxAlbumsPhoto";
            this.checkBoxAlbumsPhoto.Size = new System.Drawing.Size(14, 14);
            this.checkBoxAlbumsPhoto.TabIndex = 1;
            this.checkBoxAlbumsPhoto.UseVisualStyleBackColor = false;
            // 
            // AlbumsPhotosControler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxAlbumsPhoto);
            this.Controls.Add(this.pictureBoxAlbumsPhoto);
            this.Name = "AlbumsPhotosControler";
            this.Size = new System.Drawing.Size(110, 110);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumsPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAlbumsPhoto;
        private System.Windows.Forms.CheckBox checkBoxAlbumsPhoto;
    }
}

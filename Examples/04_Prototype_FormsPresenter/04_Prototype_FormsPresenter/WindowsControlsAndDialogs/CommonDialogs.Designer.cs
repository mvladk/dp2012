namespace WindowsControlsAndDialogs
{
    partial class CommonDialogs
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
            this.buttonColorDialog = new System.Windows.Forms.Button();
            this.buttonFontDialog = new System.Windows.Forms.Button();
            this.buttonOpenFileDialog = new System.Windows.Forms.Button();
            this.buttonSaveFileDialog = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // buttonColorDialog
            // 
            this.buttonColorDialog.Location = new System.Drawing.Point(13, 13);
            this.buttonColorDialog.Name = "buttonColorDialog";
            this.buttonColorDialog.Size = new System.Drawing.Size(179, 23);
            this.buttonColorDialog.TabIndex = 0;
            this.buttonColorDialog.Text = "Change My Color";
            this.buttonColorDialog.UseVisualStyleBackColor = true;
            this.buttonColorDialog.Click += new System.EventHandler(this.buttonColorDialog_Click);
            // 
            // buttonFontDialog
            // 
            this.buttonFontDialog.Location = new System.Drawing.Point(13, 42);
            this.buttonFontDialog.Name = "buttonFontDialog";
            this.buttonFontDialog.Size = new System.Drawing.Size(179, 23);
            this.buttonFontDialog.TabIndex = 0;
            this.buttonFontDialog.Text = "Change My Font";
            this.buttonFontDialog.UseVisualStyleBackColor = true;
            this.buttonFontDialog.Click += new System.EventHandler(this.buttonFontDialog_Click);
            // 
            // buttonOpenFileDialog
            // 
            this.buttonOpenFileDialog.Location = new System.Drawing.Point(13, 71);
            this.buttonOpenFileDialog.Name = "buttonOpenFileDialog";
            this.buttonOpenFileDialog.Size = new System.Drawing.Size(179, 23);
            this.buttonOpenFileDialog.TabIndex = 0;
            this.buttonOpenFileDialog.Text = "Open a File";
            this.buttonOpenFileDialog.UseVisualStyleBackColor = true;
            this.buttonOpenFileDialog.Click += new System.EventHandler(this.buttonOpenFileDialog_Click);
            // 
            // buttonSaveFileDialog
            // 
            this.buttonSaveFileDialog.Location = new System.Drawing.Point(13, 100);
            this.buttonSaveFileDialog.Name = "buttonSaveFileDialog";
            this.buttonSaveFileDialog.Size = new System.Drawing.Size(179, 23);
            this.buttonSaveFileDialog.TabIndex = 0;
            this.buttonSaveFileDialog.Text = "Save A File";
            this.buttonSaveFileDialog.UseVisualStyleBackColor = true;
            this.buttonSaveFileDialog.Click += new System.EventHandler(this.buttonSaveFileDialog_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AllowFullOpen = false;
            this.colorDialog1.SolidColorOnly = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "C# Source Files|*.cs";
            // 
            // CommonDialogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 144);
            this.Controls.Add(this.buttonSaveFileDialog);
            this.Controls.Add(this.buttonOpenFileDialog);
            this.Controls.Add(this.buttonFontDialog);
            this.Controls.Add(this.buttonColorDialog);
            this.Name = "CommonDialogs";
            this.Text = "CommonDialogs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonColorDialog;
        private System.Windows.Forms.Button buttonFontDialog;
        private System.Windows.Forms.Button buttonOpenFileDialog;
        private System.Windows.Forms.Button buttonSaveFileDialog;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
namespace _09_Proxy
{
    partial class StudentsLottery
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
            this.buttonGetList = new System.Windows.Forms.Button();
            this.listBoxStudents = new System.Windows.Forms.ListBox();
            this.buttonGetRandomStudent = new System.Windows.Forms.Button();
            this.labelWinnerStudent = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // buttonGetList
            // 
            this.buttonGetList.Location = new System.Drawing.Point(13, 13);
            this.buttonGetList.Name = "buttonGetList";
            this.buttonGetList.Size = new System.Drawing.Size(122, 23);
            this.buttonGetList.TabIndex = 0;
            this.buttonGetList.Text = "Get Students List";
            this.buttonGetList.UseVisualStyleBackColor = true;
            this.buttonGetList.Click += new System.EventHandler(this.buttonGetList_Click);
            // 
            // listBoxStudents
            // 
            this.listBoxStudents.FormattingEnabled = true;
            this.listBoxStudents.Location = new System.Drawing.Point(13, 43);
            this.listBoxStudents.Name = "listBoxStudents";
            this.listBoxStudents.Size = new System.Drawing.Size(120, 186);
            this.listBoxStudents.TabIndex = 1;
            // 
            // buttonGetRandomStudent
            // 
            this.buttonGetRandomStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonGetRandomStudent.Location = new System.Drawing.Point(11, 235);
            this.buttonGetRandomStudent.Name = "buttonGetRandomStudent";
            this.buttonGetRandomStudent.Size = new System.Drawing.Size(122, 23);
            this.buttonGetRandomStudent.TabIndex = 2;
            this.buttonGetRandomStudent.Text = "Get Random Student";
            this.buttonGetRandomStudent.UseVisualStyleBackColor = false;
            this.buttonGetRandomStudent.Click += new System.EventHandler(this.buttonGetRandomStudent_Click);
            // 
            // labelWinnerStudent
            // 
            this.labelWinnerStudent.AutoSize = true;
            this.labelWinnerStudent.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinnerStudent.Location = new System.Drawing.Point(140, 116);
            this.labelWinnerStudent.Name = "labelWinnerStudent";
            this.labelWinnerStudent.Size = new System.Drawing.Size(79, 23);
            this.labelWinnerStudent.TabIndex = 3;
            this.labelWinnerStudent.Text = "[Winner]";
            this.labelWinnerStudent.DoubleClick += new System.EventHandler(this.labelWinnerStudent_DoubleClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(144, 90);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(162, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(144, 142);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(162, 23);
            this.progressBar2.TabIndex = 4;
            // 
            // StudentsLottery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 264);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelWinnerStudent);
            this.Controls.Add(this.buttonGetRandomStudent);
            this.Controls.Add(this.listBoxStudents);
            this.Controls.Add(this.buttonGetList);
            this.Name = "StudentsLottery";
            this.Text = "Students Lottery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGetList;
        private System.Windows.Forms.ListBox listBoxStudents;
        private System.Windows.Forms.Button buttonGetRandomStudent;
        private System.Windows.Forms.Label labelWinnerStudent;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
    }
}
namespace WindowsFormsApplication10
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
            this.listBoxDB = new System.Windows.Forms.ListBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.buttonFindPredicate = new System.Windows.Forms.Button();
            this.buttonComparer = new System.Windows.Forms.Button();
            this.buttonFilterBy = new System.Windows.Forms.Button();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLinqQuery = new System.Windows.Forms.Button();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxDB
            // 
            this.listBoxDB.FormattingEnabled = true;
            this.listBoxDB.Location = new System.Drawing.Point(12, 25);
            this.listBoxDB.Name = "listBoxDB";
            this.listBoxDB.Size = new System.Drawing.Size(381, 355);
            this.listBoxDB.TabIndex = 0;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(12, 388);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(146, 20);
            this.textBoxFirstName.TabIndex = 1;
            // 
            // buttonFindPredicate
            // 
            this.buttonFindPredicate.Location = new System.Drawing.Point(12, 414);
            this.buttonFindPredicate.Name = "buttonFindPredicate";
            this.buttonFindPredicate.Size = new System.Drawing.Size(291, 23);
            this.buttonFindPredicate.TabIndex = 2;
            this.buttonFindPredicate.Text = "חיפוש בבסיס הנתונים - Template Method";
            this.buttonFindPredicate.UseVisualStyleBackColor = true;
            this.buttonFindPredicate.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonComparer
            // 
            this.buttonComparer.Location = new System.Drawing.Point(12, 443);
            this.buttonComparer.Name = "buttonComparer";
            this.buttonComparer.Size = new System.Drawing.Size(291, 23);
            this.buttonComparer.TabIndex = 2;
            this.buttonComparer.Text = "חיפוש ממוין - Strategy";
            this.buttonComparer.UseVisualStyleBackColor = true;
            this.buttonComparer.Click += new System.EventHandler(this.buttonFindFast_Click);
            // 
            // buttonFilterBy
            // 
            this.buttonFilterBy.Location = new System.Drawing.Point(12, 472);
            this.buttonFilterBy.Name = "buttonFilterBy";
            this.buttonFilterBy.Size = new System.Drawing.Size(291, 23);
            this.buttonFilterBy.TabIndex = 2;
            this.buttonFilterBy.Text = "חיפוש ברשימה - Extension methods / IEnumerable";
            this.buttonFilterBy.UseVisualStyleBackColor = true;
            this.buttonFilterBy.Click += new System.EventHandler(this.buttonFilterBy_Click);
            // 
            // listBoxResult
            // 
            this.listBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.Location = new System.Drawing.Point(402, 25);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(502, 251);
            this.listBoxResult.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "תוצאת חיפוש";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "בסיס הנתונים";
            // 
            // buttonLinqQuery
            // 
            this.buttonLinqQuery.Location = new System.Drawing.Point(12, 501);
            this.buttonLinqQuery.Name = "buttonLinqQuery";
            this.buttonLinqQuery.Size = new System.Drawing.Size(291, 23);
            this.buttonLinqQuery.TabIndex = 2;
            this.buttonLinqQuery.Text = "חיפוש ברשימה - Linq";
            this.buttonLinqQuery.UseVisualStyleBackColor = true;
            this.buttonLinqQuery.Click += new System.EventHandler(this.buttonLinqQuery_Click);
            // 
            // dataGridResults
            // 
            this.dataGridResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResults.Location = new System.Drawing.Point(402, 297);
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.Size = new System.Drawing.Size(502, 221);
            this.dataGridResults.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 530);
            this.Controls.Add(this.dataGridResults);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonComparer);
            this.Controls.Add(this.buttonLinqQuery);
            this.Controls.Add(this.buttonFilterBy);
            this.Controls.Add(this.buttonFindPredicate);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.listBoxResult);
            this.Controls.Add(this.listBoxDB);
            this.Name = "FormMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "סטודנטים";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDB;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Button buttonFindPredicate;
        private System.Windows.Forms.Button buttonComparer;
        private System.Windows.Forms.Button buttonFilterBy;
        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLinqQuery;
        private System.Windows.Forms.DataGridView dataGridResults;
    }
}


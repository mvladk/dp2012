using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsControlsAndDialogs
{
    public partial class CommonDialogs : Form
    {
        public CommonDialogs()
        {
            InitializeComponent();
        }

        private void buttonColorDialog_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() ==
                DialogResult.OK)
            {
                buttonColorDialog.BackColor =
                    colorDialog1.Color;
            }
        }

        private void buttonFontDialog_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() ==
                DialogResult.OK)
            {
                buttonFontDialog.Font =
                    fontDialog1.Font;
            }
        }

        private void buttonOpenFileDialog_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() ==
               DialogResult.OK)
            {
                buttonOpenFileDialog.Text =
                    openFileDialog1.FileName;

                System.Diagnostics.Process.Start(openFileDialog1.FileName);
            }
        }

        private void buttonSaveFileDialog_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() ==
               DialogResult.OK)
            {
                buttonSaveFileDialog.Text =
                    saveFileDialog1.FileName;

                //System.Diagnostics.Process.Start(openFileDialog1.FileName);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            e.Cancel = true;
            this.Hide();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsControlsAndDialogs
{
    internal partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            this.Close();
        }
    }
}
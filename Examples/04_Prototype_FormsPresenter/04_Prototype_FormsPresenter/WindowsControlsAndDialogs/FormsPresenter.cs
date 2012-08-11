using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsControlsAndDialogs
{
    public partial class FormsPresenter : Form
    {
        public FormsPresenter()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PopulateListOfForms();
        }

        private void PopulateListOfForms()
        {
            foreach (Type type in FormsRepository.Instance.GetTypes())
            {
                listBox1.Items.Add(type);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Type type = listBox1.SelectedItem as Type;

                Form theFormIWantToSee = FormsRepository.Instance.GetReference(type);

                theFormIWantToSee.Show();
            }
        }
    }
}
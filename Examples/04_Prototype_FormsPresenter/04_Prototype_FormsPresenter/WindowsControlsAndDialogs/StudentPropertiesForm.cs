using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsControlsAndDialogs
{
    internal partial class StudentPropertiesForm : Form
    {
        public StudentPropertiesForm()
        {
            InitializeComponent();
        }

        private Student m_Student;

        public Student Student
        {
            get { return m_Student; }
            set
            {
                if (m_Student != value)
                {
                    m_Student = value;
                    PopulateUI();
                }
            }
        }

        private void PopulateUI()
        {
            textBoxFirstName.Text = m_Student.FirstName;
            textBoxLastName.Text = m_Student.LastName;
            textBoxPhone.Text = m_Student.Phone;
            upDownAge.Value = m_Student.Age;
            comboLevel.SelectedIndex = (int)m_Student.Level;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            UpdateStudentFromUI();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateStudentFromUI()
        {
            if (m_Student != null)
            {
                m_Student.FirstName = textBoxFirstName.Text;
                m_Student.LastName = textBoxLastName.Text;
                m_Student.Phone = textBoxPhone.Text;
                m_Student.Age = (int)upDownAge.Value;
                m_Student.Level = (eStudentLevel)comboLevel.SelectedIndex;
            }
        }
    }
}
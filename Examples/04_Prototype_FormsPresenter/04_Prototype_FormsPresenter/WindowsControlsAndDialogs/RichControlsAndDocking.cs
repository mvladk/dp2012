using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsControlsAndDialogs
{
    public partial class RichControlsAndDocking : Form
    {
        public RichControlsAndDocking()
        {
            InitializeComponent();

            this.Load += new EventHandler(RichControlsAndDocking_Load);
        }

        private void RichControlsAndDocking_Load(object sender, EventArgs e)
        {
            if (File.Exists(@".\Resources\students data.txt"))
            {
                LoadStudentsFromFile(@".\Resources\students data.txt");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (MessageBox.Show("Are you sure?", "Stam", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void mitFileOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void tsButtonFileOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            if (openFileDialog1.ShowDialog() ==
                DialogResult.OK)
            {
                LoadStudentsFromFile(openFileDialog1.FileName);
            }
        }

        private void LoadStudentsFromFile(string i_FileName)
        {
            string[] studentLines = File.ReadAllLines(i_FileName);

            foreach(string studentLine in studentLines)
            {
                Student student = Student.CreateFromLine(studentLine);
                StudentListItem item = new StudentListItem(student);
                listViewStudents.Items.Add(item);
            }
        }

        private void mitHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewStudents.View = View.LargeIcon;
        }

        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewStudents.View = View.SmallIcon;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewStudents.View = View.List;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewStudents.View = View.Details;
        }

        private void toolStripButtonEditProperties_Click(object sender, EventArgs e)
        {
            EditStudentProperties();
        }

        private void editPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditStudentProperties();
        }

        private void listViewStudents_ItemActivate(object sender, EventArgs e)
        {
            EditStudentProperties();
        }

        private void EditStudentProperties()
        {
            if (listViewStudents.SelectedItems.Count == 1)
            {
                StudentListItem selectedStudentItem =
                    listViewStudents.SelectedItems[0] as StudentListItem;

                StudentPropertiesForm studentPropertiesForm =
                    new StudentPropertiesForm();

                studentPropertiesForm.Student = selectedStudentItem.Student;

                studentPropertiesForm.ShowDialog(this);
            }
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewStudents.SelectedItems.Count == 1)
            {
                StudentListItem selectedStudentItem =
                    listViewStudents.SelectedItems[0] as StudentListItem;
                
                labelSelectedStudent.Text = selectedStudentItem.Student.FirstName;
            }
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            e.Cancel = true;
            this.Hide();
        }
    }

    class StudentListItem : ListViewItem
    {
        private Student m_Student;
        public Student Student
        {
            get { return m_Student; }
        }

        public StudentListItem(Student i_Student)
        {
            m_Student = i_Student;
            m_Student.PropertyChanged += new EventHandler(m_Student_PropertyChanged);
            ReBuildItem();
        }

        private void m_Student_PropertyChanged(object sender, EventArgs e)
        {
            ReBuildItem();
        }

        private void ReBuildItem()
        {
            this.SubItems.Clear();
            this.Text = m_Student.FirstName;
            this.SubItems.Add(m_Student.LastName);
            this.SubItems.Add(m_Student.Phone);
            this.SubItems.Add(m_Student.Age.ToString());
            this.ImageIndex = (int)Student.Level;
            // another way:
            this.ImageKey = Student.Level.ToString(); ;

        }
    }
}
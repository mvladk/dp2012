using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using GenericSingletons;
using System.Linq;
using WindowsControlsAndDialogs.Commands;
using WindowsControlsAndDialogs.SmartUIElements;

namespace WindowsControlsAndDialogs
{
    /// <summary>
    /// The client
    /// </summary>
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(RichControlsAndDocking_Load);

            createCommands();

            createMenus();            
        }

        private void createCommands()
        {
            /// note the command patterns and the strategy lambda expression
            ICommand cmdViewLargeIcons =
                    new CommandWithDelegate(() => listViewStudents.View = View.LargeIcon) { Name = "cmdViewLargeIcons" };

            ICommand cmdViewSmallIcons =
                    new CommandWithDelegate(() => listViewStudents.View = View.SmallIcon) { Name = "cmdViewSmallIcons" };

            ICommand cmdViewList =
                    new CommandWithDelegate(() => listViewStudents.View = View.List) { Name = "cmdViewList" };

            ICommand cmdViewDetails =
                    new CommandWithDelegate(() => listViewStudents.View = View.Details) { Name = "cmdViewDetails" };

            /// note the use of Chain of Responsibility pattern here:
            ICommand cmdViewTree =
                new CommandWithToggle(
                    new CommandWithDelegate(() => treeViewFaculties.Visible = !treeViewFaculties.Visible)) { Name = "cmdViewTree", Checked = true };

            ICommand cmdEditProperties =
                    new CommandWithDelegate(() => editStudentProperties()) { Name = "cmdEditProperties" };

            CommandRepository.Instance.AddPrototype(cmdViewLargeIcons, cmdViewLargeIcons.Name);
            CommandRepository.Instance.AddPrototype(cmdViewSmallIcons, cmdViewSmallIcons.Name);
            CommandRepository.Instance.AddPrototype(cmdViewList, cmdViewList.Name);
            CommandRepository.Instance.AddPrototype(cmdViewDetails, cmdViewDetails.Name);
            CommandRepository.Instance.AddPrototype(cmdEditProperties, cmdEditProperties.Name);
            CommandRepository.Instance.AddPrototype(cmdViewTree, cmdViewTree.Name);
        }

        private void createMenus()
        {
            List<ToolStripItem> smartItems = new List<ToolStripItem>();
            foreach (var item in this.mitView.DropDownItems.OfType <ToolStripMenuItem>())
            {
                smartItems.Add(new SmartTSMenutItem(item, CommandRepository.Instance.GetReference(item.Name)));
            }

            this.mitView.DropDownItems.AddRange(smartItems.ToArray());

            smartItems.Clear();
            foreach (var item in this.tsMenuView.DropDownItems.OfType<ToolStripMenuItem>())
            {
                smartItems.Add(new SmartTSMenutItem(item, CommandRepository.Instance.GetReference(item.Name.Trim('_'))));
            }

            this.tsMenuView.DropDownItems.AddRange(smartItems.ToArray());

            mitEdit.DropDownItems.Add(
                new SmartTSMenutItem(cmdEditProperties, CommandRepository.Instance.GetReference("cmdEditProperties")));

            toolStrip.Items.Add(
                new SmartTSButton(cmdEditProperties_, CommandRepository.Instance.GetReference("cmdEditProperties")));
        }

        private void RichControlsAndDocking_Load(object sender, EventArgs e)
        {
            if (File.Exists(@".\Resources\students data.txt"))
            {
                LoadStudentsFromFile(@".\Resources\students data.txt");
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

        private void editStudentProperties()
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
            bool enabled = listViewStudents.SelectedItems.Count == 1;
            if (enabled)
            {

                StudentListItem selectedStudentItem =
                    listViewStudents.SelectedItems[0] as StudentListItem;

                labelSelectedStudent.Text = selectedStudentItem.Student.FirstName;
            }

            CommandRepository.Instance.GetReference("cmdEditProperties").Enabled =
                enabled;

            CommandRepository.Instance.GetReference("cmdEditProperties").ToolTip =
                enabled ? "Edit Student" : "Edit Students";
        }

        private void listViewStudents_ItemActivate(object sender, System.EventArgs e)
        {
            editStudentProperties();
        }

        private void dugmaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmdViewTree_Click(object sender, EventArgs e)
        {
            this.treeViewFaculties.Visible = !this.treeViewFaculties.Visible;
            cmdViewTree.Checked = this.treeViewFaculties.Visible;
            cmdViewTree_.Checked = this.treeViewFaculties.Visible;

        }
    }

    /// Class Proxy / Observer
    class StudentListItem : ListViewItem /// ListViewItem this the ISubject and the RealSubject
    {
        private Student m_Student; /// this is my observable subject
        public Student Student
        {
            get { return m_Student; }
        }

        public StudentListItem(Student i_Student)
        {
            m_Student = i_Student;
            m_Student.PropertyChanged += new PropertyChangedEventHandler(m_Student_PropertyChanged);
            ReBuildItem();
        }

        private void m_Student_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
            /// another way:
            this.ImageKey = Student.Level.ToString(); ;
        }
    }

}
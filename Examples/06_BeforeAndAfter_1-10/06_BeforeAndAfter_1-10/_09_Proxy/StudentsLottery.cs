using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _09_Proxy
{
    public partial class StudentsLottery : Form
    {
        public StudentsLottery()
        {
            InitializeComponent();
        }

        LotteryService.LotteryServiceClient m_ServiceProxy = new LotteryService.LotteryServiceClient();

        private void buttonGetList_Click(object sender, EventArgs e)
        {
            // get students list from web service:
            listBoxStudents.DataSource =
                m_ServiceProxy.GetStudents();

            listBoxStudents.DisplayMember = "FullName";
        }

        private void buttonGetRandomStudent_Click(object sender, EventArgs e)
        {
            // get the winner student from web serivce:
            LotteryService.Student student =
                m_ServiceProxy.GetRandomStudent();

            labelWinnerStudent.Text = student.FullName;
            labelWinnerStudent.Tag = student.ID;

            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar2.Style = ProgressBarStyle.Marquee;
        }

        private void labelWinnerStudent_DoubleClick(object sender, EventArgs e)
        {
            string id = labelWinnerStudent.Tag as string;
            MessageBox.Show(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Infrastructure.Adapters.Facebook;

namespace C12Ex01Y314440009V319512893
{
    public partial class MainWindow : Form
    {
        FBAdapter m_FBAdapter;
        Album m_Album = new Album();
        User m_SelectedFriend = new User();

        public MainWindow()
        {
            InitializeComponent();
            //this.Title = "Facebook Photos Browser.  DP.H.B12.319512893.314440009";
            this.Text = "Facebook Photos Browser.  DP.H.B12.319512893.314440009";
            // this.WindowState.
            this.m_FBAdapter = new FBAdapter();
        }

        private void loginAndInit()
        {
            m_FBAdapter.Login();
            fetchUserInfo();
            fetchFriends();
            //fetchEvents();
        }

        private void fetchUserInfo()
        {
            if (m_FBAdapter.LoggedInUser.Statuses.Count > 0)
            {
                //this.Title = m_FBAdapter.LoggedInUser.Statuses[0].Message;
                this.Text = m_FBAdapter.LoggedInUser.Statuses[0].Message;
            }

            image_smallPictureBox.LoadAsync(m_FBAdapter.LoggedInUser.PictureNormalURL);
            //image_smallPictureBox.Source = new BitmapImage(new Uri(m_FBAdapter.LoggedInUser.PictureNormalURL, UriKind.Absolute));
            //image_smallPictureBox.Stretch = Stretch.Uniform;
        }

        private void fetchFriends()
        {
            listBoxFriends.DisplayMember = "Name";
            foreach (User friend in m_FBAdapter.LoggedInUser.Friends)
            {
                listBoxFriends.Items.Add(friend);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }
    }
}

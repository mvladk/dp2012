//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace C12Ex01Y314440009V319512893
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User m_LoggedInUser;

        public MainWindow()
        {
            
            InitializeComponent();
            this.Title = "Facebook Photos Browser.  DP.H.B12.319512893.314440009";
        }

        private void loginAndInit()
        {
            //LoginResult result = FacebookService.Login("229916837130733",
            //    "user_about_me", "friends_about_me", "publish_stream", "user_events", "read_stream",
            //    "user_status", // this is instead of the 'user_checkins' permission, as desricbed here: http://developers.facebook.com/bugs/170251059758531
            //    "user_photo_video_tags", "friends_photo_video_tags", "user_photos", "friends_photos", "user_videos", "friends_videos"
            //    , "offline_access"
            //    );

            LoginResult result = FacebookService.Connect(@"AAADRG69nse0BADt5k0PRb8IxIEQRLZBVk1hro195rbpT5U8HyOkt2Y0sd9WUwIjZATbwzO8uUpfmUueLiSci0qCKXGi4ySGy1k1PLxcwZDZD");

            //,
            //"user_activities", "friends_activities",
            //"user_birthday", "friends_birthday",
            //"user_checkins", "friends_checkins",
            //"user_education_history", "friends_education_history",
            //"user_events", "friends_events",
            //"user_groups" , "friends_groups",
            //"user_hometown", "friends_hometown",
            //"user_interests", "friends_interests",
            //"user_likes", "friends_likes",
            //"user_location", "friends_location",
            //"user_notes", "friends_notes",
            //"user_online_presence", "friends_online_presence",
            //"user_photo_video_tags", "friends_photo_video_tags",
            //"user_photos", "friends_photos",
            //"user_photos", "friends_photos",
            //"user_relationships", "friends_relationships",
            //"user_relationship_details","friends_relationship_details",
            //"user_religion_politics","friends_religion_politics",
            //"user_status", "friends_status",
            //"user_videos", "friends_videos",
            //"user_website", "friends_website",
            //"user_work_history", "friends_work_history",
            //"email",
            //"read_friendlists",
            //"read_insights",
            //"read_mailbox",
            //"read_requests",
            //"read_stream",
            //"xmpp_login",

            //"create_event",
            //"rsvp_event",
            //"sms",
            //"publish_checkins",
            //"manage_friendlists",
            //"manage_pages",

            //"offline_access"

            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                m_LoggedInUser = result.LoggedInUser;
                fetchUserInfo();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void fetchUserInfo()
        {
            //picture_smallPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            if (m_LoggedInUser.Statuses.Count > 0)
            {
                //textBoxStatus.Text = m_LoggedInUser.Statuses[0].Message;
                this.Title = m_LoggedInUser.Statuses[0].Message;
            }
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            loginAndInit();
        }

    }
}

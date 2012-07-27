using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures.WithSingltonAppSettings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Clipboard.SetText("designpatterns");
        }

        User m_LoggedInUser;

        private void loginAndInit()
        {
            LoginResult result = FacebookService.Login("185561228241561",
                "user_about_me", "friends_about_me", "publish_stream", "user_events", "read_stream",
                "user_status" // this is instead of the 'user_checkins' permission, as desricbed here: http://developers.facebook.com/bugs/170251059758531
                );
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
            picture_smallPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            if (m_LoggedInUser.Statuses.Count > 0)
            {
                textBoxStatus.Text = m_LoggedInUser.Statuses[0].Message; 
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void buttonSetStatus_Click(object sender, EventArgs e)
        {
            m_LoggedInUser.PostStatus(textBoxStatus.Text);
        }

        private void linkNewsFeed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchNewsFeed();
        }

        private void fetchNewsFeed()
        {
            foreach (Post post in m_LoggedInUser.NewsFeed)
            {
                if (post.Message != null)
                {
                    listBoxNewsFeed.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    listBoxNewsFeed.Items.Add(post.Caption);
                }
                else
                {
                    listBoxNewsFeed.Items.Add(string.Format("[{0}]", post.Type));
                }
            }
        }

        private void linkFriends_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchFriends();
        }

        private void fetchFriends()
        {
            //listBoxFriends.DisplayMemeber = "Name";
            foreach (User friend in m_LoggedInUser.Friends)
            {
                listBoxFriends.Items.Add(friend);
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedFriend();
        }

        private void displaySelectedFriend()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                User selectedFriend = listBoxFriends.SelectedItem as User;
                if (selectedFriend.PictureNormalURL != null)
                {
                    pictureBoxFriend.LoadAsync(selectedFriend.PictureNormalURL);
                }
                else
                {
                    picture_smallPictureBox.Image = picture_smallPictureBox.ErrorImage;
                }
            }
        }

        private void labelEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchEvents();
        }

        private void fetchEvents()
        {
            //listBoxEvents.DisplayMemeber = "Name";
            foreach (Event fbEvent in m_LoggedInUser.Events)
            {
                listBoxEvents.Items.Add(fbEvent);
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItems.Count == 1)
            {
                Event selectedEvent = listBoxEvents.SelectedItem as Event;
                pictureBoxEvent.LoadAsync(selectedEvent.PictureNormalURL);
            }
        }

        private void linkCheckins_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchCheckins();
        }

        private void fetchCheckins()
        {
            foreach (Checkin checkin in m_LoggedInUser.Checkins)
            {
                listBoxCheckins.Items.Add(checkin);
            }
        }
    }

    // Application: Class Example (by design.patterns)
    // AppID: 185561228241561
}

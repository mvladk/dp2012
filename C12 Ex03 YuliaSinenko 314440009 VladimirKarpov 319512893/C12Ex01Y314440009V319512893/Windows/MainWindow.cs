// <copyright file="MainWindow.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Infrastructure.Adapters.Facebook;
using Infrastructure.Adapters;

namespace C12Ex03Y314440009V319512893
{
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow : Form
    {
        private ILoginable m_FBAdapter;
        private FacebookUser m_FacebookUser = new FacebookUser();
        private FacebookUser m_FacebookUserFriend = new FacebookUser();
        private FacebookAlbum m_FacebookAlbum = FacebookAlbum.Instance;

        public MainWindow()
        {
            this.InitializeComponent();
            this.Text = "Facebook Photos Browser.DP.H.B12.319512893.314440009";
            this.m_FBAdapter = new FBAdapter();
        }

        /// <summary>
        /// User clicked login buttom, let's login
        /// </summary>
        private void loginAndInit()
        {
            this.m_FBAdapter.Login();
            this.m_FacebookUser.User = (this.m_FBAdapter as FBAdapter).LoggedInUser;
            this.m_FacebookUser.ProfilePictureBox = this.image_smallPictureBox;
            this.m_FacebookUser.FriendsListBox = this.listBoxFriends;
            this.m_FacebookUser.AlbumsListBox = this.listBoxAlbums;
            this.m_FacebookUser.FriendsSortsComboBox = this.friendsSortComboBox;
            this.m_FacebookUser.AlbumsSortsComboBox = this.albumsSortComboBox;
            this.m_FacebookUser.FetchUserInfo();
            this.m_FacebookUser.FetchFriends();
            this.m_FacebookUser.FriendsListBox.SelectedIndexChanged += this.m_FacebookUserFriend.ListBoxFriends_SelectedIndexChanged;
            this.m_FacebookUser.FriendsListBox.SelectedIndexChanged += this.m_FacebookAlbum.FriendsListBox_SelectedIndexChanged;
            this.m_FacebookUser.FriendsListBox.SelectedIndexChanged += this.m_FacebookAlbum.ListBoxFriends_SelectedIndexChanged;
            this.m_FacebookUser.FriendsSortsComboBox.SelectedIndexChanged += this.m_FacebookUser.FriendsSortComboBox_SelectedIndexChanged;
            this.m_FacebookUser.AlbumsSortsComboBox.SelectedIndexChanged += this.m_FacebookUser.AlbumsSortComboBox_SelectedIndexChanged;
             


            this.m_FacebookUserFriend.ProfilePictureBox = this.imageFriend;
            this.m_FacebookUserFriend.AlbumsListBox = this.listBoxAlbums;

            this.m_FacebookAlbum.User = this.m_FacebookUserFriend;
            this.m_FacebookAlbum.User.User = this.m_FacebookUser.User;
            this.m_FacebookAlbum.AlbumPictureBox = this.imageFriend;
            this.m_FacebookAlbum.AlbumsPhotosPanel = this.albumsPhotosPanel;
            this.m_FacebookAlbum.AlbumsTaggetUsers = this.listBoxTaggetFriends;
            this.m_FacebookAlbum.FolderBrowserDialog = this.folderBrowserDialogForDownload;
            this.m_FacebookAlbum.ProgressBar = this.progressBarPhotosDownload;
            this.listBoxAlbums.SelectedIndexChanged += this.m_FacebookAlbum.ListBoxAlbums_SelectedIndexChanged;
            this.buttonDownloadSelectedPhotos.Click += this.m_FacebookAlbum.buttonDowload_Click;
        }

        /// <summary>
        /// Login button clicked
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.loginAndInit();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

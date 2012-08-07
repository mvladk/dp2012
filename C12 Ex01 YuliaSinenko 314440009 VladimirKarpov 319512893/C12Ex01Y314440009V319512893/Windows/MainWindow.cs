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

namespace C12Ex01Y314440009V319512893
{
    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow : Form
    {
        private FBAdapter m_FBAdapter;
        private Album m_AlbumChosen = new Album();
        private FacebookUser m_FacebookUser = new FacebookUser();
        private FacebookUser m_FacebookUserFriend = new FacebookUser(); 

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
            this.m_FacebookUser.User = this.m_FBAdapter.LoggedInUser;
            this.m_FacebookUser.ProfilePictureBox = this.image_smallPictureBox;
            this.m_FacebookUser.FriendsListBox = this.listBoxFriends;
            this.m_FacebookUser.AlbumsListBox = this.listBoxAlbums;
            this.m_FacebookUser.FetchUserInfo();
            this.m_FacebookUser.FetchFriends();
            this.m_FacebookUser.FriendsListBox.SelectedIndexChanged += this.m_FacebookUserFriend.ListBoxFriends_SelectedIndexChanged;
            this.m_FacebookUser.FriendsListBox.SelectedIndexChanged += new EventHandler(this.FriendsListBox_SelectedIndexChanged);
            this.m_FacebookUserFriend.ProfilePictureBox = this.imageFriend;
            this.m_FacebookUserFriend.AlbumsListBox = this.listBoxAlbums;
        }

        /// <summary>
        /// Friends list selected item event
        /// </summary>
        /// <param name="sender">List box</param>
        /// <param name="e">Event Args</param>
        private void FriendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxTaggetFriends.Items.Clear();
            AlbumsPhotosPanel.Controls.Clear();
        }

        /// <summary>
        /// Display selected album photos
        /// </summary>
        private void displaySelectedAlbumsPhotos()
        {
            if (this.m_FacebookUser.AlbumsListBox.SelectedItems.Count == 1)
            {
                this.m_AlbumChosen = this.m_FacebookUser.AlbumsListBox.SelectedItem as Album;
                AlbumsPhotosPanel.Controls.Clear();
                if (this.m_AlbumChosen.Photos.Count > 0)
                {
                    imageFriend.LoadAsync(this.m_AlbumChosen.Photos[0].URL);
                    foreach (Photo albumPhoto in this.m_AlbumChosen.Photos)
                    {
                        AlbumsPhotosControler thumbnail = new AlbumsPhotosControler(albumPhoto.URL, AlbumsPhotosPanel.Controls.Count);
                        thumbnail.PictureBox.Click += new EventHandler(this.thumbnail_Click);
                        AlbumsPhotosPanel.Controls.Add(thumbnail);
                    }
                }
            }
        }

        /// <summary>
        /// Display selected album tags
        /// </summary>
        private void displaySelectedAlbumsTags()
        {
            if (this.m_FacebookUser.AlbumsListBox.SelectedItems.Count == 1)
            {
                Hashtable albumsTaggetFreans = new Hashtable();
                this.m_AlbumChosen = this.m_FacebookUser.AlbumsListBox.SelectedItem as Album;

                listBoxTaggetFriends.Items.Clear();
                foreach (Photo selectedAlbumsfoto in this.m_AlbumChosen.Photos)
                {
                    if (selectedAlbumsfoto != null && selectedAlbumsfoto.Tags != null)
                    {
                        if (selectedAlbumsfoto.Tags.Count > 0)
                        {
                            foreach (PhotoTag tagg in selectedAlbumsfoto.Tags)
                            {
                                if (!albumsTaggetFreans.ContainsKey(tagg.User.Name))
                                {
                                    albumsTaggetFreans.Add(tagg.User.Name, selectedAlbumsfoto);
                                    listBoxTaggetFriends.Items.Add(tagg.User.Name);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Login button clicked
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.loginAndInit();
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.displaySelectedAlbumsPhotos();
            this.displaySelectedAlbumsTags();
        }

        private void thumbnail_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox tmpPicture = sender as PictureBox;
                this.m_FacebookUserFriend.ProfilePictureBox.LoadAsync(tmpPicture.ImageLocation);
            }
        }

        private void listBoxTaggetFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTaggetFriends.SelectedItems.Count == 1)
            {
                string taggetFriendName = listBoxTaggetFriends.SelectedItem.ToString();

                imageFriend.LoadAsync(this.m_AlbumChosen.Photos[0].URL);
     
                AlbumsPhotosPanel.Controls.Clear();
                foreach (Photo albumPhoto in this.m_AlbumChosen.Photos)
                {
                    if (albumPhoto.Tags != null && albumPhoto.Tags.Count > 0)
                    {
                        foreach (PhotoTag tagg in albumPhoto.Tags)
                        {
                            if (tagg.User.Name == taggetFriendName)
                            {
                                AlbumsPhotosControler thumbnail = new AlbumsPhotosControler(albumPhoto.URL, AlbumsPhotosPanel.Controls.Count);
                                thumbnail.PictureBox.Click += new EventHandler(this.thumbnail_Click);
                                AlbumsPhotosPanel.Controls.Add(thumbnail);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDowload_Click(object sender, EventArgs e)
        {
            string path;
            string filename;

            DialogResult folderBrowserDialogResult = folderBrowserDialogForDownload.ShowDialog();

            if (folderBrowserDialogResult == System.Windows.Forms.DialogResult.OK)
            {
                using (WebClient Client = new WebClient())
                {
                    path = folderBrowserDialogForDownload.SelectedPath;
                    this.progressBarPhotosDownload.Value = 0;
                    this.progressBarPhotosDownload.Maximum = 0;
                    foreach (AlbumsPhotosControler SelectedItem in AlbumsPhotosPanel.Controls)
                    {
                        if (SelectedItem is AlbumsPhotosControler)
                        {
                            if (SelectedItem.Is_Selected)
                            {
                                progressBarPhotosDownload.Maximum++;
                                Uri uri = new Uri(SelectedItem.PictureBox.ImageLocation);
                                filename = Path.GetFileName(uri.LocalPath);
                                Client.DownloadFile(uri, path + "\\" + filename);
                                progressBarPhotosDownload.Value++;
                            }
                        }
                    }
                }
            }
        }
    }
}

﻿//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>
//-----------------------------------------------------------------------

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
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Infrastructure.Adapters.Facebook;
using System.IO;


namespace C12Ex01Y314440009V319512893
{

    /// <summary>
    /// Interaction logic for MainWindow
    /// </summary>
    public partial class MainWindow : Form
    {
        FBAdapter m_FBAdapter;
        Album m_AlbumChosen = new Album();
        FacebookUser m_FacebookUser = new FacebookUser();
        FacebookUser m_FacebookUserFriend = new FacebookUser(); 
        //  public event AlbumPhotoDownloadFinishedEventHandler AlbumPhotoDownloadFinished;


        public MainWindow()
        {
            InitializeComponent();
            this.Text = "Facebook Photos Browser.DP.H.B12.319512893.314440009";
            this.m_FBAdapter = new FBAdapter();
        }

        private void loginAndInit()
        {
            m_FBAdapter.Login();
            m_FacebookUser.User = m_FBAdapter.LoggedInUser;
            m_FacebookUser.ProfilePictureBox = image_smallPictureBox;
            m_FacebookUser.FriendsListBox = listBoxFriends;
            m_FacebookUser.AlbumsListBox = listBoxAlbums;

            m_FacebookUserFriend.ProfilePictureBox = imageFriend;

            m_FacebookUser.FetchUserInfo();
            this.Text = m_FacebookUser.User.Statuses[0].Message;
            
            m_FacebookUser.FetchFriends();
        }

        private void displaySelectedFriend()
        {
            if (m_FacebookUser.FriendsListBox.SelectedItems.Count == 1)
            {
                m_FacebookUserFriend.User = m_FacebookUser.FriendsListBox.SelectedItem as User;
                m_FacebookUserFriend.ProfilePictureBox.LoadAsync(m_FacebookUserFriend.User.PictureLargeURL);
            }
        }

        private void displaySelectedFriendAlbums()
        {
            if (m_FacebookUser.FriendsListBox.SelectedItems.Count == 1)
            {
                AlbumsPhotosPanel.Controls.Clear();
                if (m_FacebookUser.AlbumsListBox.Items.Count > 0)
                {
                    m_FacebookUser.AlbumsListBox.Items.Clear();
                    listBoxTaggetFriends.Items.Clear();
                }

                if (m_FacebookUserFriend.User.Albums.Count > 0)
                {
                    foreach (Album album in m_FacebookUserFriend.User.Albums)
                    {
                        m_FacebookUser.AlbumsListBox.DisplayMember = "Name";
                        m_FacebookUser.AlbumsListBox.Items.Add(album);
                    }
                }
            }
        }

        private void displaySelectedAlbumsPhotos()
        {
            if (m_FacebookUser.AlbumsListBox.SelectedItems.Count == 1)
            {
                m_AlbumChosen = m_FacebookUser.AlbumsListBox.SelectedItem as Album;
                AlbumsPhotosPanel.Controls.Clear();
                if (m_AlbumChosen.Photos.Count > 0)
                {
                    imageFriend.LoadAsync(m_AlbumChosen.Photos[0].URL);
                    foreach (Photo albumPhoto in m_AlbumChosen.Photos)
                    {
                        AlbumsPhotosControler thumbnail = new AlbumsPhotosControler(albumPhoto.URL, AlbumsPhotosPanel.Controls.Count);
                        thumbnail.PictureBox.Click += new EventHandler(thumbnail_Click);
                        AlbumsPhotosPanel.Controls.Add(thumbnail);
                    }
                }
            }
        }

        private void displaySelectedAlbumsTags()
        {
            if (m_FacebookUser.AlbumsListBox.SelectedItems.Count == 1)
            {
                Hashtable albumsTaggetFreans = new Hashtable();
                m_AlbumChosen = m_FacebookUser.AlbumsListBox.SelectedItem as Album;

                listBoxTaggetFriends.Items.Clear();
                foreach (Photo selectedAlbumsfoto in m_AlbumChosen.Photos)
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedFriend();
            displaySelectedFriendAlbums();
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedAlbumsPhotos();
            displaySelectedAlbumsTags();
        }

        void thumbnail_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox tmpPicture = sender as PictureBox;
                m_FacebookUserFriend.ProfilePictureBox.LoadAsync(tmpPicture.ImageLocation);
            }
        }

        private void listBoxTaggetFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTaggetFriends.SelectedItems.Count == 1)
            {
                string taggetFriendName = listBoxTaggetFriends.SelectedItem.ToString();

                imageFriend.LoadAsync(m_AlbumChosen.Photos[0].URL);
     
                AlbumsPhotosPanel.Controls.Clear();
                foreach (Photo albumPhoto in m_AlbumChosen.Photos)
                {
                    if (albumPhoto.Tags != null && albumPhoto.Tags.Count > 0)
                    {
                        foreach (PhotoTag tagg in albumPhoto.Tags)
                        {
                            if (tagg.User.Name == taggetFriendName)
                            {
                                AlbumsPhotosControler thumbnail = new AlbumsPhotosControler(albumPhoto.URL, AlbumsPhotosPanel.Controls.Count);
                                thumbnail.PictureBox.Click += new EventHandler(thumbnail_Click);
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
                    progressBarPhotosDownload.Value = 0;
                    progressBarPhotosDownload.Maximum = 0;
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

            //using (WebClient Client = new WebClient())
            //{
            //    foreach (PictureBox SelectedItem in listBoxPictures.SelectedItems)
            //    {
            //        if (SelectedItem is PictureBox)
            //        {
            //            Uri uri = new Uri(SelectedItem.ImageLocation);
            //            filename = Path.GetFileName(uri.LocalPath);
            //            Client.DownloadFile(SelectedItem.ImageLocation, path + filename);
            //        }
            //    }
            //}
        }
    }
}

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
        Album m_Album = new Album();
        FacebookUser m_FacebookUser = new FacebookUser();
        FacebookUser m_FacebookUserFriend = new FacebookUser();

        //  public event AlbumPhotoDownloadFinishedEventHandler AlbumPhotoDownloadFinished;


        public MainWindow()
        {
            InitializeComponent();
            this.Text = "Facebook Photos Browser.  DP.H.B12.319512893.314440009";
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
            m_FacebookUser.PictureBox = image_smallPictureBox;
            m_FacebookUserFriend.PictureBox = imageFriend;

            if (m_FBAdapter.LoggedInUser.Statuses.Count > 0)
            {
                this.Text = m_FBAdapter.LoggedInUser.Statuses[0].Message;
            }

            m_FacebookUser.PictureBox.LoadAsync(m_FBAdapter.LoggedInUser.PictureNormalURL);
        }

        private void fetchFriends()
        {
            listBoxFriends.DisplayMember = "Name";
            foreach (User friend in m_FBAdapter.LoggedInUser.Friends)
            {
                listBoxFriends.Items.Add(friend);
            }
        }

        private void displaySelectedFriend()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                m_FacebookUserFriend.User = listBoxFriends.SelectedItem as User;
                m_FacebookUserFriend.PictureBox.LoadAsync(m_FacebookUserFriend.User.PictureLargeURL);
            }
        }

        private void displaySelectedFriendAlbums()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                if (listBoxAlbums.Items.Count > 0)
                {
                    listBoxAlbums.Items.Clear();
                    //  listBoxPictures.Items.Clear();
                    listBoxTaggetFriends.Items.Clear();
                    //imageFriend.Source = null;
                }

                if (m_FacebookUserFriend.User.Albums.Count > 0)
                {
                    foreach (Album album in m_FacebookUserFriend.User.Albums)
                    {
                        listBoxAlbums.DisplayMember = "Name";
                        listBoxAlbums.Items.Add(album);
                    }
                }
            }
        }

        private void displaySelectedAlbumsPhotos()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                AlbumsPhotosPanel.Controls.Clear();
                Album albumChosen = listBoxAlbums.SelectedItem as Album;
                foreach (Photo albumPhoto in albumChosen.Photos)
                {
                    AlbumsPhotosControler thumbnail = new AlbumsPhotosControler(albumPhoto.URL, AlbumsPhotosPanel.Controls.Count);
                    thumbnail.PictureBox.Click += new EventHandler(thumbnail_Click);
                    AlbumsPhotosPanel.Controls.Add(thumbnail);
                }
            }
        }

        void thumbnail_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox tmpPicture = sender as PictureBox;
                m_FacebookUserFriend.PictureBox.LoadAsync(tmpPicture.ImageLocation);
            }
            //throw new NotImplementedException();
        }

        private void displaySelectedAlbumsTags()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Hashtable albumsTaggetFreans = new Hashtable();

                m_Album = listBoxAlbums.SelectedItem as Album;
                foreach (Photo selectedAlbumsfoto in m_Album.Photos)
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



        //private void displaySelectedAlbumsPhoto()
        //{
        //    if (listBoxPictures.SelectedItems.Count == 1 && listBoxPictures.SelectedItem is PictureBox)
        //    {
        //        PictureBox selectedPhoto = listBoxPictures.SelectedItem as PictureBox;

        //        imageFriend.LoadAsync(selectedPhoto.ImageLocation);
        //        imageFriend.Source = selectedPhoto.Source;
        //        imageFriend.Stretch = Stretch.Uniform;
        //    }
        //}

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

        private void listBoxPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            //displaySelectedAlbumsPhoto();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDowload_Click(object sender, EventArgs e)
        {
            //string path = @"C:\tmp\";
            //string filename;

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

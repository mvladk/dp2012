//-----------------------------------------------------------------------
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        FBAdapter m_FBAdapter;
        Album m_Album = new Album();
        User m_SelectedFriend = new User();

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

        private void displaySelectedFriend()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                m_SelectedFriend = listBoxFriends.SelectedItem as User;

                if (m_SelectedFriend.PictureNormalURL != null)
                {
                    image_smallPictureBox.LoadAsync(m_SelectedFriend.PictureNormalURL);
                    //image_smallPictureBox.Source = new BitmapImage(new Uri(m_SelectedFriend.PictureNormalURL, UriKind.Absolute));
                    //image_smallPictureBox.Stretch = Stretch.Uniform;
                }
                else
                {
                    image_smallPictureBox.LoadAsync(m_FBAdapter.LoggedInUser.PictureNormalURL);
                    //image_smallPictureBox.Source = new BitmapImage(new Uri(m_FBAdapter.LoggedInUser.PictureNormalURL, UriKind.Absolute));
                    //image_smallPictureBox.Stretch = Stretch.Uniform;
                }
            }
        }

        private void displaySelectedFriendAlbums()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                if (listBoxAlbums.Items.Count > 0)
                {
                    listBoxAlbums.Items.Clear();
                    listBoxPictures.Items.Clear();
                    listBoxTaggetFriends.Items.Clear();
                    //imageFriend.Source = null;
                }

                if (m_SelectedFriend.Albums.Count > 0)
                {
                    foreach (Album album in m_SelectedFriend.Albums)
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
                m_Album = listBoxAlbums.SelectedItem as Album;
                listBoxPictures.Items.Clear();
                listBoxTaggetFriends.Items.Clear();
                //imageFriend.Source = null;

                foreach (Photo albumFoto in m_Album.Photos)
                {
                    PictureBox albumsImg = new PictureBox();//TODO change value name 
                    //albumsImg.Source = new BitmapImage(new Uri(albumFoto.URL, UriKind.Absolute));
                    albumsImg.LoadAsync(albumFoto.URL);
                    albumsImg.MaximumSize = new Size(100, 100);
                    //albumsImg.MaxWidth = 100;
                    //albumsImg.MaxHeight = 100;
                    //albumsImg.Margin = new Thickness(-10, 10, 0, 0);
                    albumsImg.Margin = new System.Windows.Forms.Padding(-10, 10, 0, 0);

                    CheckBox selectedPhotoCheckBox = new CheckBox();
                    //selectedPhotoCheckBox.Margin = new Thickness(0,-15,0,0);
                    selectedPhotoCheckBox.Margin = new System.Windows.Forms.Padding(0, -15, 0, 0);
  
                    listBoxPictures.Items.Add(albumsImg);
                    listBoxPictures.Items.Add(selectedPhotoCheckBox);
                }
            }
        }

        private void displaySelectedAlbumsTags()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Hashtable albumsTaggetFreans = new Hashtable();     
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

        private void displaySelectedAlbumsPhoto()
        {
            if (listBoxPictures.SelectedItems.Count == 1 && listBoxPictures.SelectedItem is Image)
            {
                Image selectedPhoto = listBoxPictures.SelectedItem as Image;

                //imageFriend. = selectedPhoto;
                //imageFriend.Source = selectedPhoto.Source;
                //imageFriend.Stretch = Stretch.Uniform;
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

        private void listBoxPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedAlbumsPhoto();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            //Application.Current.Shutdown();
            Application.Exit();
        }
    }
}

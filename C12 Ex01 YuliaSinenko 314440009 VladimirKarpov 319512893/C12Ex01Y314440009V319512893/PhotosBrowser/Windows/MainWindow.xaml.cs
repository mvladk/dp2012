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
using System.Net;
using System.Threading;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using Infrastructure.Adapters.Facebook;


namespace C12Ex01Y314440009V319512893
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FBAdapter m_FBAdapter;
        Album m_Album = new Album();
        User m_SelectedFriend = new User();
        public MainWindow()
        {            
            InitializeComponent();
            this.Title = "Facebook Photos Browser.  DP.H.B12.319512893.314440009";
            m_FBAdapter = new FBAdapter();
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
                this.Title = m_FBAdapter.LoggedInUser.Statuses[0].Message;
            }

            image_smallPictureBox.Source = new BitmapImage(new Uri(m_FBAdapter.LoggedInUser.PictureNormalURL, UriKind.Absolute));
            image_smallPictureBox.Stretch = Stretch.Uniform;
        }

        private void fetchFriends()
        {
            listBoxFriends.DisplayMemberPath = "Name";
            foreach (User friend in m_FBAdapter.LoggedInUser.Friends)
            {
                listBoxFriends.Items.Add(friend);
            }
        }

        //private void fetchEvents()
        //{
        //    listBoxEvents.DisplayMemberPath = "Name";
        //    foreach (Event fbEvent in m_FBAdapter.LoggedInUser.Events)
        //    {
        //        listBoxEvents.Items.Add(fbEvent);
        //    }
        //}

        private void displaySelectedFriend()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                m_SelectedFriend = listBoxFriends.SelectedItem as User;

                if (m_SelectedFriend.PictureNormalURL != null)
                {
                    imageFriend.Source = new BitmapImage(new Uri(m_SelectedFriend.PictureNormalURL, UriKind.Absolute));
                    imageFriend.Stretch = Stretch.Uniform;

                    image_smallPictureBox.Source = new BitmapImage(new Uri(m_SelectedFriend.PictureNormalURL, UriKind.Absolute));
                    image_smallPictureBox.Stretch = Stretch.Uniform;
                }
                else
                {
                    image_smallPictureBox.Source = new BitmapImage(new Uri(m_FBAdapter.LoggedInUser.PictureNormalURL, UriKind.Absolute));
                    image_smallPictureBox.Stretch = Stretch.Uniform;
                }
            }
        }

        private void displaySelectedFriendAlboms()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                if (listBoxAlbums.Items.Count > 0)
                {
                    listBoxAlbums.Items.Clear();
                    listBoxPictures.Items.Clear();
                }

                if (m_SelectedFriend.Albums.Count > 0)
                {
                    foreach (Album album in m_SelectedFriend.Albums)
                    {
                        listBoxAlbums.DisplayMemberPath = "Name";
                        listBoxAlbums.Items.Add(album);
                    }
                }
            }
        }

        private void displaySelectedAlbomsPhotos()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                m_Album = listBoxAlbums.SelectedItem as Album;
                listBoxPictures.Items.Clear();
                foreach (Photo albomFoto in m_Album.Photos)
                {
                    Image albomsImg = new Image();
                    albomsImg.Source = new BitmapImage(new Uri(albomFoto.URL, UriKind.Absolute));
                    albomsImg.MaxWidth = 100;
                    albomsImg.MaxHeight = 100;
                    albomsImg.Margin = new Thickness(0, 10, 0, 0);

                    CheckBox selectedPhotoCheckBox = new CheckBox();
                    selectedPhotoCheckBox.Margin = new Thickness(105,-10,0,0);
                 //   albomsImg.MouseLeftButtonUp += new MouseButtonEventHandler();   
                    listBoxPictures.Items.Add(albomsImg);
                    listBoxPictures.Items.Add(selectedPhotoCheckBox);
                }
            }
        }

        private void displaySelectedAlbomsTags()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Hashtable albomsTaggetFreans = new Hashtable();
                foreach (Photo selectedAlbomsfoto in m_Album.Photos)
                {
                    if (selectedAlbomsfoto != null && selectedAlbomsfoto.Tags != null)
                    {
                        if (selectedAlbomsfoto.Tags.Count > 0)
                        {
                            foreach (PhotoTag tagg in selectedAlbomsfoto.Tags)
                            {
                                if (!albomsTaggetFreans.ContainsKey(tagg.User.Name))
                                {
                                    albomsTaggetFreans.Add(tagg.User.Name, selectedAlbomsfoto);
                                    listBoxTaggetFriends.Items.Add(tagg.User.Name);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            loginAndInit();
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            displaySelectedFriend();
            displaySelectedFriendAlboms();
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            displaySelectedAlbomsPhotos();
            displaySelectedAlbomsTags();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

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
            m_FacebookUser.PictureBox = image_smallPictureBox;

            //fetchEvents();
        }

        private void fetchUserInfo()
        {
            if (m_FBAdapter.LoggedInUser.Statuses.Count > 0)
            {
                //this.Title = m_FBAdapter.LoggedInUser.Statuses[0].Message;
                this.Text = m_FBAdapter.LoggedInUser.Statuses[0].Message;
            }

            m_ProfilePicture.PictureBox.LoadAsync(m_FBAdapter.LoggedInUser.PictureNormalURL);
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
                m_FacebookUser = listBoxFriends.SelectedItem as User;

                if (m_FacebookUser.PictureNormalURL != null)
                {
                    image_smallPictureBox.LoadAsync(m_FacebookUser.PictureNormalURL);
                    //image_smallPictureBox.Source = new BitmapImage(new Uri(m_FacebookUser.PictureNormalURL, UriKind.Absolute));
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

                if (m_FacebookUser.Albums.Count > 0)
                {
                    foreach (Album album in m_FacebookUser.Albums)
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
                imageFriend.ImageLocation = null;

                listViewPic.View = View.Details;
                listViewPic.LabelEdit = true;
                listViewPic.AllowColumnReorder = true;
                listViewPic.CheckBoxes = true;
                listViewPic.FullRowSelect = true;
                listViewPic.GridLines = true;
                ListViewItem item1 = new ListViewItem("item1", 0);

                item1.Checked = true;
                item1.SubItems.Add("1");
                item1.SubItems.Add("2");
                item1.SubItems.Add("3");
                ListViewItem item2 = new ListViewItem("item2", 1);
                item2.SubItems.Add("4");
                item2.SubItems.Add("5");
                item2.SubItems.Add("6");
                ListViewItem item3 = new ListViewItem("item3", 0);
                item3.Checked = true;
                item3.SubItems.Add("7");
                item3.SubItems.Add("8");
                item3.SubItems.Add("9");

                listViewPic.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
                listViewPic.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
                listViewPic.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
                listViewPic.Columns.Add("Column 4", -2, HorizontalAlignment.Center);


                listViewPic.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

                // Create two ImageList objects.
                ImageList imageListSmall = new ImageList();
                ImageList imageListLarge = new ImageList();

                foreach (Photo albumFoto in m_Album.Photos)
                {
                    PictureBox albumsImg = new PictureBox(); //TODO change value name 
                    //albumsImg.Source = new BitmapImage(new Uri(albumFoto.URL, UriKind.Absolute));
                    albumsImg.LoadAsync(albumFoto.URL);
                    albumsImg.Size = new Size(100, 100);


                    ///////////////////////////
                    imageListSmall.Images.Add(albumsImg.Image);
                    imageListLarge.Images.Add(albumsImg.Image);
                    ///////////////////////////


                    //albumsImg.MaxWidth = 100;
                    //albumsImg.MaxHeight = 100;
                    //albumsImg.Margin = new Thickness(-10, 10, 0, 0);


                    //   imageListSmall.Images.Add(0,albumsImg);

                    // albumsImg.Margin = new System.Windows.Forms.Padding(-10, 10, 0, 0);

                    //CheckBox selectedPhotoCheckBox = new CheckBox();
                    ////selectedPhotoCheckBox.Margin = new Thickness(0,-15,0,0);
                    //selectedPhotoCheckBox.Margin = new System.Windows.Forms.Padding(0, -15, 0, 0);
                    listBoxPictures.Items.Add(albumsImg);
                    // listBoxPictures.Items.Add(selectedPhotoCheckBox);
                }

                listViewPic.LargeImageList = imageListLarge;
                listViewPic.SmallImageList = imageListSmall;
            }
        }


        ///////////////////////
        //private void CreateMyListView()
        //{
        //    // Create a new ListView control.
        //    ListView listView1 = new ListView();
        //    listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

        //    // Set the view to show details.
        //    listView1.View = View.Details;
        //    // Allow the user to edit item text.
        //    listView1.LabelEdit = true;
        //    // Allow the user to rearrange columns.
        //    listView1.AllowColumnReorder = true;
        //    // Display check boxes.
        //    listView1.CheckBoxes = true;
        //    // Select the item and subitems when selection is made.
        //    listView1.FullRowSelect = true;
        //    // Display grid lines.
        //    listView1.GridLines = true;
        //    // Sort the items in the list in ascending order.
        //    listView1.Sorting = SortOrder.Ascending;

        //    // Create three items and three sets of subitems for each item.
        //    ListViewItem item1 = new ListViewItem("item1", 0);
        //    // Place a check mark next to the item.
        //    item1.Checked = true;
        //    item1.SubItems.Add("1");
        //    item1.SubItems.Add("2");
        //    item1.SubItems.Add("3");
        //    ListViewItem item2 = new ListViewItem("item2", 1);
        //    item2.SubItems.Add("4");
        //    item2.SubItems.Add("5");
        //    item2.SubItems.Add("6");
        //    ListViewItem item3 = new ListViewItem("item3", 0);
        //    // Place a check mark next to the item.
        //    item3.Checked = true;
        //    item3.SubItems.Add("7");
        //    item3.SubItems.Add("8");
        //    item3.SubItems.Add("9");

        //    // Create columns for the items and subitems.
        //    // Width of -2 indicates auto-size.
        //    listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
        //    listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
        //    listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
        //    listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

        //    //Add the items to the ListView.
        //    listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

        //    // Create two ImageList objects.
        //    ImageList imageListSmall = new ImageList();
        //    ImageList imageListLarge = new ImageList();

        //    // Initialize the ImageList objects with bitmaps.
        //    imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage1.bmp"));
        //    imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage2.bmp"));
        //    imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage1.bmp"));
        //    imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage2.bmp"));

        //    //Assign the ImageList objects to the ListView.
        //    listView1.LargeImageList = imageListLarge;
        //    listView1.SmallImageList = imageListSmall;

        //    // Add the ListView to the control collection.
        //    this.Controls.Add(listView1);
        //}
        //////////////////////////

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
            if (listBoxPictures.SelectedItems.Count == 1 && listBoxPictures.SelectedItem is PictureBox)
            {
                PictureBox selectedPhoto = listBoxPictures.SelectedItem as PictureBox;

                imageFriend.LoadAsync(selectedPhoto.ImageLocation);
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
            Application.Exit();
        }

        private void buttonDowload_Click(object sender, EventArgs e)
        {
            string path = @"C:\tmp\";
            string filename;

            using (WebClient Client = new WebClient())
            {
                foreach (PictureBox SelectedItem in listBoxPictures.SelectedItems)
                {
                    if (SelectedItem is PictureBox)
                    {
                        Uri uri = new Uri(SelectedItem.ImageLocation);
                        filename = Path.GetFileName(uri.LocalPath);
                        Client.DownloadFile(SelectedItem.ImageLocation, path + filename);
                    }
                }
            }
        }
    }
}

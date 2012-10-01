﻿// <copyright file="FacebookUser.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>

namespace C12Ex03Y314440009V319512893
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Facebook;
    using FacebookWrapper;
    using FacebookWrapper.ObjectModel;
    using Infrastructure.Adapters.Facebook;

    /// <summary>
    /// FacebookUser wrapper for Facebook wraper API
    /// </summary>
    public class FacebookUser
    {
        private PictureBox m_ProfilePicture;
        private User m_User;
        private ListBox m_FriendsList;
        private ListBox m_AlbumsList;
        private ComboBox m_FriendsSortsComboBox;
        private ComboBox m_AlbumsSortsComboBox;
        private Sorter sorter = new Sorter(new ComparerUp());

        /// <summary>
        /// Gets or sets the Facebook wrapper User 
        /// </summary>
        public User User
        {
            get { return this.m_User; }
            set { this.m_User = value; }
        }

        /// <summary>
        /// Gets or sets the ProfilePictureBox
        /// </summary>
        public PictureBox ProfilePictureBox
        {
            get { return this.m_ProfilePicture; }
            set { this.m_ProfilePicture = value; }
        }

        /// <summary>
        /// Gets or sets the FriendsListBox
        /// </summary>
        public ListBox FriendsListBox
        {
            get { return this.m_FriendsList; }
            set { this.m_FriendsList = value; }
        }

        /// <summary>
        /// Gets or sets the AlbumsListBox
        /// </summary>
        public ListBox AlbumsListBox
        {
            get { return this.m_AlbumsList; }
            set { this.m_AlbumsList = value; }
        }

        public ComboBox FriendsSortsComboBox
        {
            get { return this.m_FriendsSortsComboBox; }
            set { this.m_FriendsSortsComboBox = value; }
        }
<<<<<<< HEAD

=======
        
>>>>>>> aabf36c8059f866088480dc57ec5faed84be2d59
        public ComboBox AlbumsSortsComboBox
        {
            get { return this.m_AlbumsSortsComboBox; }
            set { this.m_AlbumsSortsComboBox = value; }
        }

        /// <summary>
        /// Login initial actions
        /// </summary>
        public void FetchUserInfo()
        {
<<<<<<< HEAD
            this.ProfilePictureBox.LoadAsync(this.User.PictureNormalURL);
            this.displaySelectedAlbums(this.User.Albums.ToArray());
=======
            this.ProfilePictureBox.Invoke(new Action(() => this.ProfilePictureBox.LoadAsync(this.User.PictureNormalURL)));
<<<<<<< HEAD
            this.displaySelectedAlbums(this.User.Albums.ToArray());
=======
            this.displaySelectedAlbums();
>>>>>>> e974b839ac325aa15a22c88714a7aad4b009215c
>>>>>>> aabf36c8059f866088480dc57ec5faed84be2d59
        }

        /// <summary>
        /// Gets FetchFriends
        /// </summary>
        public void FetchFriends()
        {
            this.FriendsListBox.Invoke(new Action(() => this.FriendsListBox.DisplayMember = "Name"));
            foreach (User friend in this.User.Friends)
            {
                this.FriendsListBox.Invoke(new Action(() => this.FriendsListBox.Items.Add(friend)));
            }
        }

        /// <summary>
        /// Friends list changed index event
        /// </summary>
        /// <param name="sender">List box</param>
        /// <param name="e">Event Args</param>
        public void ListBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox friendsListBox = sender as ListBox;
                this.User = friendsListBox.SelectedItem as User;
                this.ProfilePictureBox.LoadAsync(this.User.PictureLargeURL);
                if (this.User.Albums.Count > 0)
                {
<<<<<<< HEAD
                    this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.Items.Clear()));
=======
                    this.AlbumsListBox.Items.Clear();
>>>>>>> aabf36c8059f866088480dc57ec5faed84be2d59
                    this.displaySelectedAlbums(this.User.Albums.ToArray());
                }
            }
        }
        /// <summary>
        /// Display Friend's selected album
        /// </summary>
        private void displaySelectedAlbums(Album[] i_UserAlbums)
        {
<<<<<<< HEAD
            this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.DisplayMember = "Name"));
            foreach (Album album in i_UserAlbums)
            {
                this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.Items.Add(album)));
=======
            foreach (Album album in i_UserAlbums)
            {
                this.AlbumsListBox.DisplayMember = "Name";
                this.AlbumsListBox.Items.Add(album);
>>>>>>> aabf36c8059f866088480dc57ec5faed84be2d59
            }
        }

        public void FriendsSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
<<<<<<< HEAD
=======
            {
                string sortBy = m_FriendsSortsComboBox.SelectedItem.ToString();
               // object[] tr = {this.User.Friends};
              //  int[] tr = { 1,3,8,5 };
                switch (sortBy)
                {
                    case "Age - asc":
                        sorter.Comparer = new ComparerUp();
                        break;
                    case "Age - desc":
                        sorter.Comparer = new ComparerDown();
                        break;
                    default:
                        return;

                }
              //  sorter.Sort(tr);
            }
        }

        public void AlbumsSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (sender is ComboBox)
            {
                int i=0;
               // Album[] friendsAlbums = new Album[] { this.User.Albums.ToArray() };
                Album[] friendsAlbums = new Album[this.User.Albums.Count];
                foreach (Album item in this.User.Albums)
                {
                    friendsAlbums[i] = item;
                    i++;
                }
                this.AlbumsListBox.Items.Clear();

            
                string sortBy = m_AlbumsSortsComboBox.SelectedItem.ToString();
                switch (sortBy)
                {
                    case "Photos count - asc":
                        sorter.Comparer = new ComparerUp();
                        break;
                    case "Photos count - desc":
                        sorter.Comparer = new ComparerDown();
                        break;
                    default:
                        return;
=======
            this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.Items.Clear()));
            if (this.User.Albums.Count > 0)
>>>>>>> aabf36c8059f866088480dc57ec5faed84be2d59
            {
                string sortBy = m_FriendsSortsComboBox.SelectedItem.ToString();
                // object[] tr = {this.User.Friends};
                //  int[] tr = { 1,3,8,5 };
                switch (sortBy)
                {
<<<<<<< HEAD
                    case "Age - asc":
                        sorter.Comparer = new ComparerUp();
                        break;
                    case "Age - desc":
                        sorter.Comparer = new ComparerDown();
                        break;
                    default:
                        return;

                }
                //  sorter.Sort(tr);
=======
                    this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.Items.Add(album)));
>>>>>>> e974b839ac325aa15a22c88714a7aad4b009215c
                }
                sorter.Sort(friendsAlbums);
                this.AlbumsListBox.Items.Clear();
                this.displaySelectedAlbums(friendsAlbums);
>>>>>>> aabf36c8059f866088480dc57ec5faed84be2d59
            }
        }

        public void AlbumsSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                int i = 0;
                // Album[] friendsAlbums = new Album[] { this.User.Albums.ToArray() };
                Album[] friendsAlbums = new Album[this.User.Albums.Count];
                foreach (Album item in this.User.Albums)
                {
                    friendsAlbums[i] = item;
                    i++;
                }
                this.AlbumsListBox.Items.Clear();


                string sortBy = m_AlbumsSortsComboBox.SelectedItem.ToString();
                switch (sortBy)
                {
                    case "Photos count - asc":
                        sorter.Comparer = new ComparerUp();
                        break;
                    case "Photos count - desc":
                        sorter.Comparer = new ComparerDown();
                        break;
                    default:
                        return;
                }
                sorter.Sort(friendsAlbums);
                this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.Items.Clear()));
                this.displaySelectedAlbums(friendsAlbums);
            }

        }
    }
}
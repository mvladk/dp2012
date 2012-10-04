// <copyright file="FacebookUser.cs" company="Holon Institute of Technology">
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
    using System.Threading;
    using Facebook;
    using FacebookWrapper;
    using FacebookWrapper.ObjectModel;
    using Infrastructure.Adapters.Facebook;

    /// <summary>
    /// FacebookUser wrapper for Facebook wraper API
    /// </summary>
    public class FacebookUser
    {
        private static bool s_IsInitedAlbumsSortsComboBox = false;
        private static bool s_IsInitedFriendSortsComboBox = false;
        private static User[] s_UserFriends;
        private PictureBox m_ProfilePicture;
        private User m_User;
        private ListBox m_FriendsList;
        private ListBox m_AlbumsList;
        private ComboBox m_FriendsSortsComboBox;
        private ComboBox m_AlbumsSortsComboBox;
        private Sorter m_SorterAlbums = new Sorter(new ComparerDECAlbumsByPhotosCount());
        private Sorter m_SorterFriends = new Sorter(new ComparerDESCFriendsByAge());

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

        public ComboBox AlbumsSortsComboBox
        {
            get { return this.m_AlbumsSortsComboBox; }
            set
            {
                this.m_AlbumsSortsComboBox = value;
                if (!s_IsInitedAlbumsSortsComboBox)
                {
                    this.m_AlbumsSortsComboBox.Invoke(new Action(() => this.m_AlbumsSortsComboBox.Items.Add(new ComparerDECAlbumsByPhotosCount())));
                    this.m_AlbumsSortsComboBox.Invoke(new Action(() => this.m_AlbumsSortsComboBox.Items.Add(new ComparerASCAlbumsByPhotosCount())));
                    s_IsInitedAlbumsSortsComboBox = true;
                }
            }
        }

        public ComboBox FriendsSortsComboBox
        {
            get { return this.m_FriendsSortsComboBox; }
            set
            {
                this.m_FriendsSortsComboBox = value;
                if (!s_IsInitedFriendSortsComboBox)
                {
                    this.m_FriendsSortsComboBox.Invoke(new Action(() => this.m_FriendsSortsComboBox.Items.Add(new ComparerDESCFriendsByAge())));
                    this.m_FriendsSortsComboBox.Invoke(new Action(() => this.m_FriendsSortsComboBox.Items.Add(new ComparerASCFriendsByAge())));
                    s_IsInitedFriendSortsComboBox = true;
                }
            }
        }

        /// <summary>
        /// Login initial actions
        /// </summary>
        public void FetchUserInfo()
        {
            this.ProfilePictureBox.Invoke(new Action(() => this.ProfilePictureBox.LoadAsync(this.User.PictureNormalURL)));
            this.displaySelectedAlbums(this.User.Albums.ToArray());
        }

        /// <summary>
        /// Gets FetchFriends
        /// </summary>
        public void FetchFriends()
        {
            if (s_UserFriends == null)
            {
                s_UserFriends = this.User.Friends.ToArray();
            }

            this.FriendsListBox.Invoke(new Action(() => this.FriendsListBox.DisplayMember = "Name"));
            foreach (User friend in s_UserFriends)
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
                if (null != friendsListBox.SelectedItem)
                {
                    this.User = friendsListBox.SelectedItem as User;
                    this.ProfilePictureBox.LoadAsync(this.User.PictureLargeURL);
                    if (this.User.Albums.Count > 0)
                    {
                        this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.Items.Clear()));
                        this.displaySelectedAlbums(this.User.Albums.ToArray());
                    }
                }
            }
        }

        /// <summary>
        /// Display Friend's selected album
        /// </summary>
        private void displaySelectedAlbums(Album[] i_UserAlbums)
        {
            foreach (Album album in i_UserAlbums)
            {
                this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.DisplayMember = "Name"));
                this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.Items.Add(album)));
            }
        }

        public void FriendsSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                m_SorterFriends.Comparer = m_FriendsSortsComboBox.SelectedItem as Comparer;
                this.FriendsListBox.Items.Clear();
                Thread thread = new Thread(new ThreadStart(
                    () =>
                    {
                        m_SorterFriends.Sort(s_UserFriends);
                        this.FetchFriends();
                    }));

                thread.Start();
            }
        }

        public void AlbumsSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                Album[] friendsAlbums = this.User.Albums.ToArray();

                m_SorterAlbums.Comparer = m_AlbumsSortsComboBox.SelectedItem as Comparer;
                this.AlbumsListBox.Invoke(new Action(() => this.AlbumsListBox.Items.Clear()));
                m_SorterAlbums.Sort(friendsAlbums);
                this.displaySelectedAlbums(friendsAlbums);
            }
        }
    }
}

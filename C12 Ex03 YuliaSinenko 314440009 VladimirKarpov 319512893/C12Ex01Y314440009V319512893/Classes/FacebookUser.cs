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

        /// <summary>
        /// Login initial actions
        /// </summary>
        public void FetchUserInfo()
        {
            this.ProfilePictureBox.LoadAsync(this.User.PictureNormalURL);
            this.displaySelectedAlbums();
        }

        /// <summary>
        /// Gets FetchFriends
        /// </summary>
        public void FetchFriends()
        {
            this.FriendsListBox.DisplayMember = "Name";
            foreach (User friend in this.User.Friends)
            {
                this.FriendsListBox.Items.Add(friend);
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
                this.displaySelectedAlbums();
            }
        }

        /// <summary>
        /// Display Friend's selected album
        /// </summary>
        private void displaySelectedAlbums()
        {
            this.AlbumsListBox.Items.Clear();
            if (this.User.Albums.Count > 0)
            {
                foreach (Album album in this.User.Albums)
                {
                    this.AlbumsListBox.DisplayMember = "Name";
                    this.AlbumsListBox.Items.Add(album);
                }
            }
        }
    }
}

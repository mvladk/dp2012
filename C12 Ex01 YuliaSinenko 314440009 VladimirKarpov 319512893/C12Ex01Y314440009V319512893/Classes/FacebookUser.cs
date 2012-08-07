namespace C12Ex01Y314440009V319512893
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Facebook;
    using FacebookWrapper;
    using FacebookWrapper.ObjectModel;
    using Infrastructure.Adapters.Facebook;
    using System.Windows.Forms;

    class FacebookUser
    {
        private PictureBox m_ProfilePicture;
        private User m_User;
        private ListBox m_FriendsList;
        private ListBox m_AlbumsList;

        public User User
        {
            get { return this.m_User; }
            set { this.m_User = value; }
        }

        public PictureBox ProfilePictureBox
        {
            get { return this.m_ProfilePicture; }
            set { this.m_ProfilePicture = value; }
        }

        public ListBox FriendsListBox
        {
            get { return this.m_FriendsList; }
            set { this.m_FriendsList = value; }
        }

        public ListBox AlbumsListBox
        {
            get { return this.m_AlbumsList; }
            set { this.m_AlbumsList = value; }
        }

        public void FetchUserInfo()
        {
            if (this.User.Statuses.Count > 0)
            {
                //this.Text = m_FBAdapter.LoggedInUser.Statuses[0].Message;
            }

            this.ProfilePictureBox.LoadAsync(this.User.PictureNormalURL);
        }

        public void FetchFriends()
        {
            this.FriendsListBox.DisplayMember = "Name";
            foreach (User friend in this.User.Friends)
            {
                this.FriendsListBox.Items.Add(friend);
            }
        }
    }
}

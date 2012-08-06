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
            if (m_FBAdapter.LoggedInUser.Statuses.Count > 0)
            {
                this.Text = m_FBAdapter.LoggedInUser.Statuses[0].Message;
            }

            m_FacebookUser.PictureBox.LoadAsync(m_FBAdapter.LoggedInUser.PictureNormalURL);
        }

        public void FetchFriends()
        {
            listBoxFriends.DisplayMember = "Name";
            foreach (User friend in m_FBAdapter.LoggedInUser.Friends)
            {
                listBoxFriends.Items.Add(friend);
            }
        }
    }
}




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

        public User User
        {
            get { return this.m_User; }
            set { this.m_User = value; }
        }

        public PictureBox PictureBox
        {
            get { return this.m_ProfilePicture; }
            set { this.m_ProfilePicture = value; }
        }
    }
}

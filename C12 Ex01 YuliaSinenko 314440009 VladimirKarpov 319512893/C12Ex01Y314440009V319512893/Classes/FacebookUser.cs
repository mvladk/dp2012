using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Infrastructure.Adapters.Facebook;
using System.Windows.Forms;


namespace C12Ex01Y314440009V319512893
{
    class FacebookUser
    {
        private PictureBox m_ProfilePicture;
        private User m_User;
        
        public User User
        {
            get { return m_User; }
            set { m_User = value;}
        }
        
        public PictureBox PictureBox
        {
            get { return m_ProfilePicture; }
            set { m_ProfilePicture = value; }
        }
    }
}

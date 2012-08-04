using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Infrastructure.Adapters.Facebook;
using System.Windows.Forms;


namespace C12Ex01Y314440009V319512893
{
    class FacebookUser : User
    {
        private FacebookUser m_FacebookUser;
        private PictureBox m_ProfilePicture;

        public PictureBox PictureBox
        {
            get { return m_ProfilePicture; }
            set { m_ProfilePicture = value; }
        }
    }
}

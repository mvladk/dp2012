//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>
//-----------------------------------------------------------------------

namespace Infrastructure.Adapters.Facebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FacebookWrapper;
    using FacebookWrapper.ObjectModel;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FBAdapter : FacebookService
    {
        private User m_LoggedInUser;
        private LoginResult m_LoginResult;

        public User LoggedInUser
        {
            get { return m_LoggedInUser; }
            private set { }
        }

        public FBAdapter()
        {
        }

        public void Login()
        {
            //LoginResult result = FacebookService.Login("229916837130733",
            //    "user_about_me", "friends_about_me", "publish_stream", "user_events", "read_stream",
            //    "user_status", // this is instead of the 'user_checkins' permission, as desricbed here: http://developers.facebook.com/bugs/170251059758531
            //    "user_photo_video_tags", "friends_photo_video_tags", "user_photos", "friends_photos", "user_videos", "friends_videos"
            //    , "offline_access"
            //    );

            this.m_LoginResult = FBAdapter.Connect(@"AAADRG69nse0BADt5k0PRb8IxIEQRLZBVk1hro195rbpT5U8HyOkt2Y0sd9WUwIjZATbwzO8uUpfmUueLiSci0qCKXGi4ySGy1k1PLxcwZDZD");

            if (string.IsNullOrEmpty(this.m_LoginResult.ErrorMessage))
            {
                m_LoggedInUser = this.m_LoginResult.LoggedInUser;
            }
            else
            {
                throw(new Exception(this.m_LoginResult.ErrorMessage));
            }

        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="FBAdapter.cs" company="Holon Institute of Technology">
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
    using System.Threading;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FBAdapter : FacebookService, ILoginable
    {
        /// <summary>
        /// Current User
        /// </summary>
        private User m_loggedInUser;

        /// <summary>
        /// Login result
        /// </summary>
        private LoginResult m_loginResult;

        /// <summary>
        /// Login result
        /// </summary>
        public event EventHandler LoginFinished;

        /// <summary>
        /// Initializes a new instance of the <see cref="FBAdapter"/> class.
        /// </summary>
        public FBAdapter()
        {
        }

        /// <summary>
        /// Gets the name of the User. 
        /// </summary>
        public User LoggedInUser
        {
            get { return this.m_loggedInUser; }
            private set { }
        }

        /// <summary>
        /// Logges in to facebook API
        /// </summary>
        public void Login()
        {
            ////this.m_loginResult = FacebookService.Login(
            ////    "229916837130733",
            ////    "user_about_me",
            ////    "friends_about_me", 
            ////    "publish_stream", 
            ////    "user_events", 
            ////    "read_stream",
            ////    "user_status", // this is instead of the 'user_checkins' permission, as desricbed here: http://developers.facebook.com/bugs/170251059758531
            ////    "user_photo_video_tags",
            ////    "friends_photo_video_tags", 
            ////    "user_photos", 
            ////    "friends_photos", 
            ////    "user_videos", 
            ////    "friends_videos",
            ////    "offline_access");

            this.m_loginResult = FBAdapter.Connect(@"AAADRG69nse0BADt5k0PRb8IxIEQRLZBVk1hro195rbpT5U8HyOkt2Y0sd9WUwIjZATbwzO8uUpfmUueLiSci0qCKXGi4ySGy1k1PLxcwZDZD");

            if (string.IsNullOrEmpty(this.m_loginResult.ErrorMessage))
            {
                this.m_loggedInUser = this.m_loginResult.LoggedInUser;
                FacebookService.s_CollectionLimit = 10;
            }
            else
            {
                throw new Exception(this.m_loginResult.ErrorMessage);
            }

            if (this.LoginFinished != null)
            {
                this.LoginFinished.Invoke(this, EventArgs.Empty);
            }
        }

        public void LoginAsync()
        {
            Thread thread = new Thread(new ThreadStart(this.Login));
            thread.Start();
        }
    }
}

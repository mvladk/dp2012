//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Threading;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;


namespace C12Ex01Y314440009V319512893
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public delegate void UpdateImageSource(ImageSource i_ImageSource);
        private User m_LoggedInUser;
        //private Thread m_LoadImageThread;
        //public UpdateImageSource m_UpdateImageSource;

        public string LocationString;// { get { return "http://www.digitaltrends.com/wp-content/uploads/2010/07/starcraft2_logo.jpg"; } }

        public MainWindow()
        {
            
            InitializeComponent();
            this.Title = "Facebook Photos Browser.  DP.H.B12.319512893.314440009";
            //m_UpdateImageSource = new UpdateImageSource(UpdateImageSourceMethod);
        }

        //public void UpdateImageSourceMethod(ImageSource i_ImageSource)
        //{
        //    image_smallPictureBox.Source = i_ImageSource;
        //}

        private void loginAndInit()
        {
            //LoginResult result = FacebookService.Login("229916837130733",
            //    "user_about_me", "friends_about_me", "publish_stream", "user_events", "read_stream",
            //    "user_status", // this is instead of the 'user_checkins' permission, as desricbed here: http://developers.facebook.com/bugs/170251059758531
            //    "user_photo_video_tags", "friends_photo_video_tags", "user_photos", "friends_photos", "user_videos", "friends_videos"
            //    , "offline_access"
            //    );

            LoginResult result = FacebookService.Connect(@"AAADRG69nse0BADt5k0PRb8IxIEQRLZBVk1hro195rbpT5U8HyOkt2Y0sd9WUwIjZATbwzO8uUpfmUueLiSci0qCKXGi4ySGy1k1PLxcwZDZD");

            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                m_LoggedInUser = result.LoggedInUser;
                fetchUserInfo();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }

        private void fetchUserInfo()
        {
            //picture_smallPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            //image_smallPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            //image_smallPictureBox.Source =   // m_LoggedInUser.PictureNormalURL;

            //LocationString = m_LoggedInUser.PictureNormalURL;

            //Image i = new Image();
            //image.Source = new BitmapSource(new Uri(imageLocation));
           

            //image_smallPictureBox.SourceUpdated +=

            //m_LoadImageThread = new Thread(new ThreadStart(loadProfileImage));
            //m_LoadImageThread.Start();

            if (m_LoggedInUser.Statuses.Count > 0)
            {
                //textBoxStatus.Text = m_LoggedInUser.Statuses[0].Message;
                this.Title = m_LoggedInUser.Statuses[0].Message;
            }

            //BitmapImage src = new BitmapImage();
            //src.BeginInit();

            //src.UriSource = new Uri(
            //    m_LoggedInUser.PictureNormalURL
            //    , UriKind.Absolute);

            //src.CacheOption = BitmapCacheOption.OnLoad;
            //src.EndInit();
            //image_smallPictureBox.Source = src;
            //image_smallPictureBox.Stretch = Stretch.Uniform;

            image_smallPictureBox.Source = new BitmapImage(new Uri(
            m_LoggedInUser.PictureNormalURL
            , UriKind.Absolute)//, BitmapCacheOption.OnLoad
            );

        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            loginAndInit();
        }


        //public void loadProfileImage()
        //{
        //    BitmapImage src = new BitmapImage();
        //    src.BeginInit();

        //    src.UriSource = new Uri(
        //        m_LoggedInUser.PictureNormalURL
        //        , UriKind.Absolute);

        //    src.CacheOption = BitmapCacheOption.OnLoad;
        //    src.EndInit();
        //    //this.m_UpdateImageSource.Invoke(src);
        //    //image_smallPictureBox.Source = new BitmapImage(new Uri(
        //    //m_LoggedInUser.PictureNormalURL
        //    //, UriKind.Absolute)//, BitmapCacheOption.OnLoad
        //    //);
        //}
    }











    public class ImageAsyncHelper : DependencyObject
    {
        public static Uri GetSourceUri(DependencyObject obj) { return (Uri)obj.GetValue(SourceUriProperty); }
        public static void SetSourceUri(DependencyObject obj, Uri value) { obj.SetValue(SourceUriProperty, value); }
        public static readonly DependencyProperty SourceUriProperty = DependencyProperty.RegisterAttached("SourceUri", typeof(Uri), typeof(ImageAsyncHelper), new PropertyMetadata
        {
            PropertyChangedCallback = (obj, e) =>
            {
                ((Image)obj).SetBinding(Image.SourceProperty,
                  new Binding("VerifiedUri")
                  {
                      Source = new ImageAsyncHelper { GivenUri = (Uri)e.NewValue },
                      IsAsync = true,
                  });
            }
        });

        Uri GivenUri;
        public Uri VerifiedUri
        {
            get
            {
                try
                {
                    Dns.GetHostEntry(GivenUri.DnsSafeHost);
                    return GivenUri;
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }
    }


}

// <copyright file="FacebookAlbum.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>

namespace C12Ex02Y314440009V319512893
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Collections;
    using System.Net;
    using System.IO;
    using Facebook;
    using FacebookWrapper;
    using FacebookWrapper.ObjectModel;
    using Infrastructure.Adapters.Facebook;

    /// <summary>
    /// FacebookAlbum wrapper for Facebook wraper API
    /// </summary>
    public class FacebookAlbum
    {
        private FacebookAlbum() 
        {
        }
        public static FacebookAlbum Instance
        {
            get
            {
                return Singleton<FacebookAlbum>.Instance;
            }
        }

        private Album m_Album;
        private FacebookUser m_User;
        private PictureBox m_AlbumPictureBox;
        private ListBox m_AlbumsTaggetUsers;
        private Panel m_AlbumsPhotosPanel;
        private FolderBrowserDialog m_FolderBrowserDialog;
        private ProgressBar m_ProgressBar;

        /// <summary>
        /// Gets or sets the Facebook wrapper User 
        /// </summary>
        public FacebookUser User
        {
            get { return this.m_User; }
            set { this.m_User = value; }
        }

        /// <summary>
        /// Gets or sets the AlbumPictureBox
        /// </summary>
        public PictureBox AlbumPictureBox
        {
            get { return this.m_AlbumPictureBox; }
            set { this.m_AlbumPictureBox = value; }
        }

        /// <summary>
        /// Gets or sets the AlbumsTaggetUsers
        /// </summary>
        public ListBox AlbumsTaggetUsers
        {
            get { return this.m_AlbumsTaggetUsers; }
            set 
            { 
                this.m_AlbumsTaggetUsers = value;
                this.m_AlbumsTaggetUsers.SelectedIndexChanged += this.listBoxTaggetFriends_SelectedIndexChanged;
            }
        }
        
        /// <summary>
        /// Gets or sets the AlbumsPhotosPanel
        /// </summary>
        public Panel AlbumsPhotosPanel
        {
            get { return this.m_AlbumsPhotosPanel; }
            set { this.m_AlbumsPhotosPanel = value; }
        }

        /// <summary>
        /// Gets or sets the FolderBrowserDialog
        /// </summary>
        public FolderBrowserDialog FolderBrowserDialog
        {
            get { return this.m_FolderBrowserDialog; }
            set { this.m_FolderBrowserDialog = value; }
        }

        /// <summary>
        /// Gets or sets the FolderBrowserDialog
        /// </summary>
        public ProgressBar ProgressBar
        {
            get { return this.m_ProgressBar; }
            set { this.m_ProgressBar = value; }
        }
        
        /// <summary>
        /// Display selected album photos
        /// </summary>
        private void displaySelectedAlbumsPhotos()
        {
            if (this.User.AlbumsListBox.SelectedItems.Count == 1)
            {
                this.m_Album = this.User.AlbumsListBox.SelectedItem as Album;
                AlbumsPhotosPanel.Controls.Clear();
                if (this.m_Album.Photos.Count > 0)
                {
                    this.AlbumPictureBox.LoadAsync(this.m_Album.Photos[0].URL);
                    foreach (Photo albumPhoto in this.m_Album.Photos)
                    {
                        AlbumsPhotosControler thumbnail = new AlbumsPhotosControler(albumPhoto.URL, AlbumsPhotosPanel.Controls.Count);
                        thumbnail.PictureBox.Click += new EventHandler(this.thumbnail_Click);
                        AlbumsPhotosPanel.Controls.Add(thumbnail);
                    }
                }
            }
        }

        /// <summary>
        /// Display selected album tags
        /// </summary>
        private void displaySelectedAlbumsTags()
        {
            if (this.User.AlbumsListBox.SelectedItems.Count == 1)
            {
                Hashtable albumsTaggetFreans = new Hashtable();
                this.m_Album = this.m_User.AlbumsListBox.SelectedItem as Album;

                this.AlbumsTaggetUsers.Items.Clear();
                foreach (Photo selectedAlbumsfoto in this.m_Album.Photos)
                {
                    if (selectedAlbumsfoto != null && selectedAlbumsfoto.Tags != null)
                    {
                        if (selectedAlbumsfoto.Tags.Count > 0)
                        {
                            foreach (PhotoTag tagg in selectedAlbumsfoto.Tags)
                            {
                                if (null != tagg.User.Name && !albumsTaggetFreans.ContainsKey(tagg.User.Name))
                                {
                                    albumsTaggetFreans.Add(tagg.User.Name, selectedAlbumsfoto);
                                    this.AlbumsTaggetUsers.Items.Add(tagg.User.Name);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void listBoxTaggetFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.AlbumsTaggetUsers.SelectedItems.Count == 1)
            {
                string taggetFriendName = this.AlbumsTaggetUsers.SelectedItem.ToString();

                this.AlbumPictureBox.LoadAsync(this.m_Album.Photos[0].URL);

                AlbumsPhotosPanel.Controls.Clear();
                foreach (Photo albumPhoto in this.m_Album.Photos)
                {
                    if (albumPhoto.Tags != null && albumPhoto.Tags.Count > 0)
                    {
                        foreach (PhotoTag tagg in albumPhoto.Tags)
                        {
                            if (tagg.User.Name == taggetFriendName)
                            {
                                AlbumsPhotosControler thumbnail = new AlbumsPhotosControler(albumPhoto.URL, this.AlbumsPhotosPanel.Controls.Count);
                                thumbnail.PictureBox.Click += new EventHandler(this.thumbnail_Click);
                                this.AlbumsPhotosPanel.Controls.Add(thumbnail);
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Friends list changed index event
        /// </summary>
        /// <param name="sender">List box</param>
        /// <param name="e">Event Args</param>
        public void FriendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.AlbumsTaggetUsers.Items.Clear();
            this.AlbumsPhotosPanel.Controls.Clear();
        }

        /// <summary>
        /// Albums list changed index event
        /// </summary>
        /// <param name="sender">List box</param>
        /// <param name="e">Event Args</param>
        public void ListBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.displaySelectedAlbumsPhotos();
            this.displaySelectedAlbumsTags();
        }

        private void thumbnail_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBoxProxy tmpPicture = sender as PictureBoxProxy;
                this.AlbumPictureBox.LoadAsync(tmpPicture.ImageLocation);
            }
        }

        /// <summary>
        /// User list changed index event
        /// </summary>
        /// <param name="sender">List box</param>
        /// <param name="e">Event Args</param>
        public void ListBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ListBox)
            {
                ListBox friendsListBox = sender as ListBox;
                this.User.User = friendsListBox.SelectedItem as User;
            }
        }

        /// <summary>
        /// Friends list changed index event
        /// </summary>
        /// <param name="sender">List box</param>
        /// <param name="e">Event Args</param>
        public void buttonDowload_Click(object sender, EventArgs e)
        {
            string path;
            string filename;

            DialogResult folderBrowserDialogResult = this.FolderBrowserDialog.ShowDialog();

            if (folderBrowserDialogResult == System.Windows.Forms.DialogResult.OK)
            {
                using (WebClient Client = new WebClient())
                {
                    path = FolderBrowserDialog.SelectedPath;
                    this.ProgressBar.Value = 0;
                    this.ProgressBar.Maximum = 0;
                    foreach (AlbumsPhotosControler SelectedItem in AlbumsPhotosPanel.Controls)
                    {
                        if (SelectedItem is AlbumsPhotosControler)
                        {
                            if (SelectedItem.Is_Selected)
                            {
                                this.ProgressBar.Maximum++;
                                Uri uri = new Uri(SelectedItem.PictureBox.ImageLocation);
                                filename = Path.GetFileName(uri.LocalPath);
                                Client.DownloadFile(uri, path + "\\" + filename);
                                this.ProgressBar.Value++;
                            }
                        }
                    }
                }
            }
        }
    }
}
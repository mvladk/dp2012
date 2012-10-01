using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections;
using System.Drawing.Imaging;

namespace C12Ex03Y314440009V319512893
{
    public interface IPictureBox
    {
        void Load(string url);
    }

    public class PictureBoxProxy : PictureBox, IPictureBox
    {
        private static object s_LockObj = new object();

        public static Dictionary<string, Image> s_AlbumsPhotosCollection = new Dictionary<string, Image>();

        private PictureBox m_AlbumPicture = new PictureBox();

        private PictureBox pictureBoxAlbumsPhoto
        {
            get { return this.m_AlbumPicture; }
            set { this.m_AlbumPicture = value; }
        }

        private Dictionary<string, Image> AlbumsPhotosCollection
        {
            get { return s_AlbumsPhotosCollection; }
            set { s_AlbumsPhotosCollection = value; }
        }

        public new void Load(string i_Url)
        {
            if (PictureBoxProxy.s_AlbumsPhotosCollection.Count < 1 || !PictureBoxProxy.s_AlbumsPhotosCollection.ContainsKey(i_Url))
            {
                this.m_AlbumPicture.Load(i_Url);
                lock (s_LockObj)
                {
                    if (PictureBoxProxy.s_AlbumsPhotosCollection.Count < 1 || !PictureBoxProxy.s_AlbumsPhotosCollection.ContainsKey(i_Url))
                    {
                        PictureBoxProxy.s_AlbumsPhotosCollection.Add(i_Url, this.m_AlbumPicture.Image);
                        this.Image = this.m_AlbumPicture.Image;
                        this.ImageLocation = this.m_AlbumPicture.ImageLocation;
                    }
                }
            }
            else
            {
                lock (s_LockObj)
                {
                    this.Image = PictureBoxProxy.s_AlbumsPhotosCollection[i_Url];
                    this.ImageLocation = i_Url;
                }
            }

            ////if (PictureBoxProxy.s_AlbumsPhotosCollection.Count > 0 && PictureBoxProxy.s_AlbumsPhotosCollection.ContainsKey(i_Url))
            ////{
            ////    this.Image = PictureBoxProxy.s_AlbumsPhotosCollection[i_Url];
            ////    this.ImageLocation = i_Url;
            ////}
            ////else
            ////{
            ////    this.m_AlbumPicture.Load(i_Url);
            ////    PictureBoxProxy.s_AlbumsPhotosCollection.Add(i_Url, this.m_AlbumPicture.Image);
            ////    this.Image = this.m_AlbumPicture.Image;
            ////    this.ImageLocation = this.m_AlbumPicture.ImageLocation;
            ////}
        }
    }
}
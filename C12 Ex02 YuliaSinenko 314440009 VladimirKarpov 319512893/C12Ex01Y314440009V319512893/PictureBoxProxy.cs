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

namespace C12Ex02Y314440009V319512893
{
    public interface IPictureBox
    {
        void LoadAsync(string url);
    }

    public class PictureBoxProxy : PictureBox, IPictureBox
    {
        public static Dictionary<string, Image> s_AlbumsPhotosCollection = new Dictionary<string, Image>();

        private PictureBox m_AlbumPicture = new PictureBox();

        public PictureBox pictureBoxAlbumsPhoto
        {
            get { return this.m_AlbumPicture; }
            set { this.m_AlbumPicture = value; }
        }

        public Dictionary<string, Image> AlbumsPhotosCollection
        {
            get { return s_AlbumsPhotosCollection; }
            set { s_AlbumsPhotosCollection = value; }
        }

        /*
         TODO: There is a bug of refreshing tags list when loading from cached results
         */
        public new void LoadAsync(string i_Url)
        {
            if (PictureBoxProxy.s_AlbumsPhotosCollection.Count > 0 && PictureBoxProxy.s_AlbumsPhotosCollection.ContainsKey(i_Url))
            {
                this.Image = PictureBoxProxy.s_AlbumsPhotosCollection[i_Url];
                this.ImageLocation = i_Url;
            }
            else
            {
                this.m_AlbumPicture.Load(i_Url);
                PictureBoxProxy.s_AlbumsPhotosCollection.Add(i_Url, this.m_AlbumPicture.Image);
                this.Image = this.m_AlbumPicture.Image;
                this.ImageLocation = this.m_AlbumPicture.ImageLocation;
            }
        }
    }
}
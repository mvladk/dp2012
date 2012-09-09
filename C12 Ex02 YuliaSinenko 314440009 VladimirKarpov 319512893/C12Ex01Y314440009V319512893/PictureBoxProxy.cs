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

    class PictureBoxProxy : PictureBox , IPictureBox
    {
        public static Dictionary<String, Image> m_AlbumsPhotosCollection = new Dictionary<String, Image>();

        private PictureBox m_AlbumPicture = new PictureBox();


        public PictureBox pictureBoxAlbumsPhoto
        {
            get { return this.m_AlbumPicture; }
            set { this.m_AlbumPicture = value; }
        }

        public Dictionary<String, Image> AlbumsPhotosCollection
        {
            get { return m_AlbumsPhotosCollection; }
            set { m_AlbumsPhotosCollection = value; }
        }
        
        public void LoadAsync(string i_Url)
        {

            if (m_AlbumsPhotosCollection.Count > 0 && m_AlbumsPhotosCollection.ContainsKey(i_Url))
            {
                this.Image = m_AlbumsPhotosCollection[i_Url];
                this.ImageLocation = i_Url;
            }
            else
            {
                m_AlbumPicture.Load(i_Url);
                m_AlbumsPhotosCollection.Add(i_Url, m_AlbumPicture.Image);
                this.Image = m_AlbumPicture.Image;
                this.ImageLocation = m_AlbumPicture.ImageLocation;
            }
        }
        
    }
}
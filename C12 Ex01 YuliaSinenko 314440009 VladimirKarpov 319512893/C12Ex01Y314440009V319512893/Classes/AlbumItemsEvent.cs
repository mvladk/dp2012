using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using FacebookWrapper.ObjectModel;


namespace C12Ex01Y314440009V319512893
{
    class AlbumItemsEvent
    {
        private Photo m_PhotoDownloaded;
        private Image m_PhotoImage;
        private int m_CurrentPhotoNumber;
        private int m_MaxPhotoNumber;
        private string m_PhotoFilePath;

        public AlbumItemsEvent(Photo i_PhotoDownloaded, Image i_PhotoImage, int i_CurrentPhotoNumber, int i_MaxPhotoNumber, string i_PhotoFilePath)
        {
            m_PhotoDownloaded = i_PhotoDownloaded;
            m_PhotoImage = i_PhotoImage;
            m_CurrentPhotoNumber = i_CurrentPhotoNumber;
            m_MaxPhotoNumber = i_MaxPhotoNumber;
            m_PhotoFilePath = i_PhotoFilePath;
        }

        public Photo PhotoDownloaded
        {
            get { return m_PhotoDownloaded; }
            set { m_PhotoDownloaded = value; }
        }

        public Image PhotoImage
        {
            get { return m_PhotoImage; }
            set { m_PhotoImage = value; }
        }

        public int CurrentPhotoNumber
        {
            get { return m_CurrentPhotoNumber; }
        }

        public int MaxPhotoNumber
        {
            get { return m_MaxPhotoNumber; }
        }

        public string PhotoFilePath
        {
            get { return m_PhotoFilePath; }
        }
    }
}

﻿// <auto-generated />

namespace C12Ex03Y314440009V319512893
{
﻿    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    using FacebookWrapper.ObjectModel;
    using System.Threading;

    public partial class AlbumsPhotosControler : UserControl, IComponent
    {
        public PictureBox PictureBox
        {
            get { return pictureBoxAlbumsPhoto; }
            private set { }
        }

        public bool Is_Selected
        {
            get { return checkBoxAlbumsPhoto.Checked; }
            set { checkBoxAlbumsPhoto.Checked = value; }
        }

        public AlbumsPhotosControler(string i_Url, int i_PhotosCount)
        {
            InitializeComponent();

            Thread threadPictureBoxAlbumsPhoto = new Thread(new ThreadStart(
                () => this.pictureBoxAlbumsPhoto.Load(i_Url)
                ));
            threadPictureBoxAlbumsPhoto.Start();

            this.pictureBoxAlbumsPhoto.Click += new EventHandler(pictureBoxAlbumsPhoto_Click);

            this.Location = new Point(0, 100 * i_PhotosCount);
        }

        void pictureBoxAlbumsPhoto_Click(object sender, EventArgs e)
        {
            ////this.checkBoxAlbumsPhoto.Checked = !this.checkBoxAlbumsPhoto.Checked;
        }

        public void displaySelectedPhotoTags(Photo i_photo)
        {
            throw new NotImplementedException();
        }
    }
}
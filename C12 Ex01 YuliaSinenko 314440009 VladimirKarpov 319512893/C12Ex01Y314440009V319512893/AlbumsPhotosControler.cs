﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace C12Ex01Y314440009V319512893
{
    public partial class AlbumsPhotosControler : UserControl
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
            this.pictureBoxAlbumsPhoto.LoadAsync(i_Url);
            this.pictureBoxAlbumsPhoto.Click += new EventHandler(pictureBoxAlbumsPhoto_Click);

            this.Location = new Point(0, 100 * i_PhotosCount);
        }

        void pictureBoxAlbumsPhoto_Click(object sender, EventArgs e)
        {
            this.checkBoxAlbumsPhoto.Checked = !this.checkBoxAlbumsPhoto.Checked;
        }
    }
}

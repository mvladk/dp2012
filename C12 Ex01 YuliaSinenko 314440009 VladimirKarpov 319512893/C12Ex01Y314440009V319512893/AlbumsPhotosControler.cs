using System;
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
        public AlbumsPhotosControler(string i_Url, int i_PhotosCount)
        {
            InitializeComponent();
            this.pictureBoxAlbumsPhoto.LoadAsync(i_Url);
            this.Location = new Point(0, 100 * i_PhotosCount);
        }
    }
}

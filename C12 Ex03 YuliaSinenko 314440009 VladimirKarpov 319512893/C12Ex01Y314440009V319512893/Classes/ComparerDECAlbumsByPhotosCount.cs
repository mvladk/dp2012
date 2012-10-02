// <copyright file="ComparerDECAlbumsByPhotosCount.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>

namespace C12Ex03Y314440009V319512893
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FacebookWrapper.ObjectModel;

    public class ComparerDECAlbumsByPhotosCount : Comparer
    {
        public override bool ShouldSwap(object i_Album1, object i_Album2)
        {
            Album album1 = i_Album1 as Album;
            Album album2 = i_Album2 as Album;
            return album1.Photos.Count < album2.Photos.Count;
        }

        public override string ToString()
        {
            return "Photos count - desc";
        }
    }
}

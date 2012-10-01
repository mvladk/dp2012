using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace C12Ex03Y314440009V319512893
{
    /// the strategy declaration
    public abstract class Comparer
    {
        abstract public bool ShouldSwap(object i_Num1, object i_Num2);
    }

    /// a strategy implementation
    //public class ComparerDown : Comparer
    //{
    //    public override bool ShouldSwap(int i_Num1, int i_Num2)
    //    {
    //        return i_Num1 > i_Num2;
    //    }
    //}

    ///// another strategy implementation
    //public class ComparerUp : Comparer
    //{
    //    public override bool ShouldSwap(int i_Num1, int i_Num2)
    //    {
    //        return i_Num1 < i_Num2;
    //    }
    //}

    public class ComparerDownAlbumsByPhotosCount : Comparer
    {
        public override bool ShouldSwap(object i_Album1, object i_Album2)
        {
            Album album1 = i_Album1 as Album;
            Album album2 = i_Album2 as Album;
            return album1.Photos.Count > album2.Photos.Count;
        }
        public override string ToString()
        {
            return "Photos count - asc";
        }
    }

    /// another strategy implementation
    public class ComparerUpAlbumsByPhotosCount : Comparer
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

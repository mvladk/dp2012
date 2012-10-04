using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using Infrastructure.Adapters.Facebook;

namespace C12Ex02Y314440009V319512893
{
    public interface IComponent
    {
        void displaySelectedPhotoTags(Photo i_photo);
    }
}

// <copyright file="Comparer.cs" company="Holon Institute of Technology">
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

    /// the strategy declaration
    public abstract class Comparer
    {
        public abstract bool ShouldSwap(object i_Comparable1, object i_Comparable2);
    }
}

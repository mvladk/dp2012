// <copyright file="ComparerASCFriendsByAge.cs" company="Holon Institute of Technology">
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

    public class ComparerASCFriendsByAge : Comparer
    {
        public override bool ShouldSwap(object i_User1, object i_User2)
        {
            int result = -1;
            User user1 = i_User1 as User;
            User user2 = i_User2 as User;

            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);

            if (user1.Birthday != null && user2.Birthday != null)
            {
                try
                {
                    DateTime User1Birthday = DateTime.Parse(user1.Birthday, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                    DateTime User2Birthday = DateTime.Parse(user2.Birthday, culture, System.Globalization.DateTimeStyles.AssumeLocal);

                    result = DateTime.Compare(User1Birthday, User2Birthday);
                }
                catch (Exception)
                {
                }
            }

            return result < 0;
        }

        public override string ToString()
        {
            return "Age - asc";
        }
    }
}

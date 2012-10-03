// <copyright file="AlbumPhotosAggregate.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>

namespace C12Ex03Y314440009V319512893.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Drawing;
    using FacebookWrapper.ObjectModel;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AlbumPhotosAggregate : IAggregate
    {
        private Album m_Album;

        public AlbumPhotosAggregate(Album i_Album)
            : base()
        {
            this.m_Album = i_Album;
        }

        public IIterator CreateIterator()
        {
            return new AlbumPhotosIterator(m_Album.Photos);
        }

        /// The ConcreteIterator:
        /// This is a private nested class, which is tightly-coupled 
        /// with the aggregate, and is specific to its needs.
        private class AlbumPhotosIterator : IIterator
        {
            private FacebookObjectCollection<Photo> m_Collection;
            private int m_CurrentIdx = 0;
            private int m_Count = -1;

            public object CurrentItem
            {
                get { return m_Collection[m_CurrentIdx]; }
            }

            public bool IsDone
            {
                get { return m_CurrentIdx >= m_Collection.Count; }
            }

            public AlbumPhotosIterator(FacebookObjectCollection<Photo> i_Collection)
            {
                m_Collection = i_Collection;
                m_Count = m_Collection.Count;
            }

            public void Reset()
            {
                m_CurrentIdx = 0;
            }

            public bool Next()
            {
                return ++m_CurrentIdx < m_Collection.Count;
            }
        }
    }
}

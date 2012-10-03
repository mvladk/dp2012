// -----------------------------------------------------------------------
// <copyright file="AlbumPhotosAggregate.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

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
        Album m_Album;
        public AlbumPhotosAggregate(Album i_CloneFrom)
            : base()
        {
            this.m_Album = i_CloneFrom;
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

            public object CurrentItem
            {
                get { return m_Collection[m_CurrentIdx]; }
            }

            public bool IsDone
            {
                get { return m_CurrentIdx >= m_Collection.Count; }
            }
        }
    }
}

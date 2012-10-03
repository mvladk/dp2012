// <copyright file="IIterator.cs" company="Holon Institute of Technology">
//     Copyright (c) Holon Institute of Technology. All rights reserved.
// </copyright>
// <author>319512893 - Vldimir Karpov</author>
// <author>314440009 - Yulia Sinenko</author>
using System.Collections.Generic;
namespace C12Ex03Y314440009V319512893
{
    /// The Iterator interface
    public interface IIterator
    {
        bool IsDone { get; }

        /// polymorphic item reference
        object CurrentItem { get; }

        IEnumerable<object> NextItem { get; }

        void Reset();

        bool Next();
    }

    /// The Aggregte interface
    public interface IAggregate
    {
        IIterator CreateIterator();
    }
}

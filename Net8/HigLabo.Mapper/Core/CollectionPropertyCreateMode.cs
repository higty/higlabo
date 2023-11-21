using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Core
{
    /// <summary>
    /// Set behavior when target collection property is null.
    /// </summary>
    public enum CollectionPropertyCreateMode
    {
        /// <summary>
        /// Do nothing and skip map.
        /// </summary>
        None,
        /// <summary>
        /// Create new instance. After create new instance, copy all elements of collection of source property.
        /// </summary>
        NewObject,
        /// <summary>
        /// Assign instance from source property. After copy instance, copy all elements of collection of source property.
        /// </summary>
        Assign,
    }
}

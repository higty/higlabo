using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    /// <summary>
    /// Set behavior when class property is null.
    /// </summary>
    public enum CollectionElementCreateMode
    {
        /// <summary>
        /// Create new instance. After create new instance, map all property from source instance.
        /// </summary>
        NewObject,
        /// <summary>
        /// Assign instance from source property.
        /// </summary>
        Assign,
    }
}

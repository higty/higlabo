using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    /// <summary>
    /// RFC3501
    /// 6.4.6.  STORE Command
    /// </summary>
    public enum StoreItem
    { 
        /// <summary>
        /// 
        /// </summary>
        FlagsReplace = 1,
        /// <summary>
        /// 
        /// </summary>
        FlagsReplaceSilent = 2,
        /// <summary>
        /// 
        /// </summary>
        FlagsAdd = 3,
        /// <summary>
        /// 
        /// </summary>
        FlagsAddSilent = 4,
        /// <summary>
        /// 
        /// </summary>
        FlagsRemove = 5,
        /// <summary>
        /// 
        /// </summary>
        FlagsRemoveSilent = 6
    }

}

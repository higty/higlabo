using System;

namespace HigLabo.Data.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public enum RecoveryModel : byte
    {
        /// <summary>
        /// 
        /// </summary>
        Default = 0,
        /// <summary>
        /// 
        /// </summary>
        Simple = 1,
        /// <summary>
        /// 
        /// </summary>
        BulkLogged = 2,
        /// <summary>
        /// 
        /// </summary>
        Full = 3
    }
}

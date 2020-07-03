using System;

namespace HigLabo.Data.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public enum CompatibilityLevel : short
    {
        /// <summary>
        /// 
        /// </summary>
        Default = 0,
        /// <summary>
        /// 
        /// </summary>
        SqlServer2000 = 80,
        /// <summary>
        /// 
        /// </summary>
        SqlServer2005 = 90,
        /// <summary>
        /// 
        /// </summary>
        SqlServer2008 = 100,
    }
}

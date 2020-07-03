using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HigLabo.Data
{
    /// <summary>
    /// デッドロックが発生したことを表現するクラスです。
    /// </summary>
    [Serializable]
    public class DeadLockException : DatabaseException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public DeadLockException(Exception ex)
            : base(ex)
        {
        }
    }
}

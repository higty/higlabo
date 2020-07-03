using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HigLabo.Data
{
    /// <summary>
    /// ロックタイムアウトを表現するクラスです。
    /// </summary>
    [Serializable]
    public class LockTimeoutException : DatabaseException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public LockTimeoutException(Exception ex)
            : base(ex)
        {
        }
    }
}

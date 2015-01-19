using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HigLabo.Data
{
    /// <summary>
    /// タイムアウトを表現するクラスです。
    /// </summary>
    [Serializable]
    public class TimeoutException : DatabaseException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public TimeoutException(Exception ex)
            : base(ex)
        {
        }
    }
}

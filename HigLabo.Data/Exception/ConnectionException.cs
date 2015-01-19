using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HigLabo.Data
{
    /// <summary>
    /// 接続時のエラーを表現するクラスです。
    /// </summary>
    [Serializable]
    public class ConnectionException : DatabaseException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public ConnectionException(Exception ex)
            : base(ex)
        {
        }
    }
}

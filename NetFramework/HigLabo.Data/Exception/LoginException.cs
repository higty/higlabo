using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HigLabo.Data
{
    /// <summary>
    /// ログイン認証に失敗したことを表現するクラスです。
    /// </summary>
    [Serializable]
    public class LoginException : DatabaseException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public LoginException(Exception ex)
            : base(ex)
        {
        }
    }
}

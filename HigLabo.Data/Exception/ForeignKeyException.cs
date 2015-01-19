using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HigLabo.Data
{
    /// <summary>
    /// 外部キー制約違反を表現するクラスです。
    /// </summary>
    [Serializable]
    public class ForeignKeyException : DatabaseException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public ForeignKeyException(Exception ex)
            : base(ex)
        {
        }
    }
}

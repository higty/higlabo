using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HigLabo.Data
{
    /// <summary>
    /// ユニークキー制約を表現するクラスです。
    /// </summary>
    [Serializable]
    public class UniqueConstraintException : DatabaseException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public UniqueConstraintException(Exception ex)
            : base(ex)
        {
        }
    }
}

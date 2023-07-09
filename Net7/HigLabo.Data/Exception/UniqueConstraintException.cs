using System;
using System.Data;
using System.Data.Common;

namespace HigLabo.Data
{
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

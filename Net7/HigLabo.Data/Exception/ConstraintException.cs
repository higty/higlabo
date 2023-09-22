using System;
using System.Data;
using System.Data.Common;

namespace HigLabo.Data
{
    [Serializable]
    public class ConstraintException : DatabaseException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public ConstraintException(Exception ex)
            : base(ex)
        {
        }
    }
}

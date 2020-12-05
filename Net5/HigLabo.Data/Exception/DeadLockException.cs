using System;
using System.Data;
using System.Data.Common;

namespace HigLabo.Data
{
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

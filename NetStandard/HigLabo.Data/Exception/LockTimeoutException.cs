using System;
using System.Data;
using System.Data.Common;

namespace HigLabo.Data
{
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

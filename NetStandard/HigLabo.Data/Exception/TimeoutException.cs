using System;
using System.Data;
using System.Data.Common;

namespace HigLabo.Data
{
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

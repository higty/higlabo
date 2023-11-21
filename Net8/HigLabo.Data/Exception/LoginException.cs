using System;
using System.Data;
using System.Data.Common;

namespace HigLabo.Data
{
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

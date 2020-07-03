using System;
using System.Collections.Generic;

namespace HigLabo.Core
{
    public class ExceptionEventArgs
    {
        public List<Exception> Exceptions { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception
        {
            get { return this.Exceptions[0]; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public ExceptionEventArgs(Exception exception)
        {
            this.Exceptions = new List<Exception>();
            this.Exceptions.Add(exception);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exceptions"></param>
        public ExceptionEventArgs(IEnumerable<Exception> exceptions)
        {
            this.Exceptions = new List<Exception>();
            this.Exceptions.AddRange(exceptions);
        }
    }
}

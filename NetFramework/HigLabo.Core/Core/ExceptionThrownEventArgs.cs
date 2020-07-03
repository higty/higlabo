using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class ExceptionThrownEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }

        public ExceptionThrownEventArgs(Exception ex)
        {
            this.Exception = ex;
        }
    }
}

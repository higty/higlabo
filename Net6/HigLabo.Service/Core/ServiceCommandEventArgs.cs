using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Service
{
    public class ServiceCommandEventArgs : EventArgs
    {
        public ServiceCommand Command { get; private set; }
        public Exception Exception { get; private set; }

        public ServiceCommandEventArgs(ServiceCommand command, Exception exception)
        {
            this.Command = command;
            this.Exception = exception;
        }
    }
}

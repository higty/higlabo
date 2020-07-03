using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class ProcessProgressEventArgs : EventArgs
    {
        public DateTime ExecutedTime { get; private set; }
        public String Message { get; private set; }
        public Double Progress { get; private set; }
        public ProcessProgressEventArgs(String message, Double progress)
        {
            this.ExecutedTime = DateTime.Now;
            this.Message = message;
            this.Progress = progress;
        }
    }
}

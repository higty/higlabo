using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class ImportObjectGenerateFileEventArgs : EventArgs
    {
        public DateTime ExecutedTime { get; private set; }
        public ImportObjectGenerateFileProcessType ProcessType { get; private set; }
        public String Message { get; private set; }
        public ImportObjectGenerateFileEventArgs(ImportObjectGenerateFileProcessType processType, String message)
        {
            this.ExecutedTime = DateTime.Now;
            this.ProcessType = processType;
            this.Message = message;
        }
    }
}

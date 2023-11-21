using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class SourceCodeFileGeneratedEventArgs : EventArgs
    {
        public SourceCodeFile File { get; private set; }
        public DateTime ExecutedTime { get; private set; }
        public String FilePath
        {
            get { return this.File.FilePath; }
        }
        public String FileName { get; private set; }
        public SourceCodeFileGeneratedEventArgs(SourceCodeFile file, DateTime executedTime)
        {
            if (file == null) throw new ArgumentNullException();
            this.File = file;
            this.FileName = Path.GetFileName(this.FilePath);
            this.ExecutedTime = executedTime;
        }
    }
}

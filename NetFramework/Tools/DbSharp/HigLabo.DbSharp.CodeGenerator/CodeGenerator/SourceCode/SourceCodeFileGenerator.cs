using HigLabo.CodeGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class SourceCodeFileGenerator
    {
        public event EventHandler<SourceCodeFileGeneratedEventArgs> FileGenerated;
        public event EventHandler Completed;
        private Int32 _SourceCodeCount = 0;
        private Int32 _GeneratedCount = 0;
        public List<SourceCodeFile> SourceCodes { get; private set; }
        public SourceCodeFileGenerator()
        {
            this.SourceCodes = new List<SourceCodeFile>();
        }
        public void Start()
        {
            this._SourceCodeCount = this.SourceCodes.Count;
            this._GeneratedCount = 0;
            this.SourceCodes.AsParallel().ForAll(this.Execute);
        }
        private void Execute(SourceCodeFile file)
        {
            CSharpSourceCodeGenerator cs = null;

            using (var stm = new StreamWriter(file.FilePath, false, Encoding.UTF8))
            {
                cs = new CSharpSourceCodeGenerator(stm);
                cs.Write(file.SourceCode);
                this.OnFileGenerated(new SourceCodeFileGeneratedEventArgs(file, DateTime.Now));
            }

            Interlocked.Increment(ref _GeneratedCount);
            if (_GeneratedCount == _SourceCodeCount)
            {
                this.OnCompleted();
            }
        }
        protected void OnFileGenerated(SourceCodeFileGeneratedEventArgs e)
        {
            var eh = this.FileGenerated;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        protected void OnCompleted()
        {
            var eh = this.Completed;
            if (eh != null)
            {
                eh(this, EventArgs.Empty);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public abstract class DbSharpCommand
    {
        public event EventHandler Started;
        public event EventHandler<ProcessProgressEventArgs> ProcessProgress;
        public event EventHandler Completed;
        
        public String CommandName { get; set; }
        protected CommandServiceContext Context { get; set; }

        public DbSharpCommand()
        {
            this.CommandName = "";
        }
        public DbSharpCommand(String commandName)
        {
            this.CommandName = commandName;
        }
        public void Execute(CommandServiceContext context)
        {
            this.Context = context;
            this.OnStarted();
            this.Execute();
            this.OnCompleted();
        }
        protected abstract void Execute();

        private void OnStarted()
        {
            var eh = this.Started;
            if (eh != null)
            {
                eh(this, EventArgs.Empty);
            }
        }
        protected void OnProcessProgress(ProcessProgressEventArgs e)
        {
            var eh = this.ProcessProgress;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        private void OnCompleted()
        {
            var eh = this.Completed;
            if (eh != null)
            {
                eh(this, EventArgs.Empty);
            }
        }
    }
}

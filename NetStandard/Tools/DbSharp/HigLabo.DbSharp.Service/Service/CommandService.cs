using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class CommandService
    {
        public event EventHandler<ProcessProgressEventArgs> ProcessProgress;
        public event EventHandler<CommandCompletedEventArgs> CommandCompleted;
        public event EventHandler Completed;

        private Thread _Thread = null;

        public List<DbSharpCommand> Commands { get; private set; }
        public Exception Exception { get; set; }

        public CommandService()
        {
            this.Commands = new List<DbSharpCommand>();
        }

        public void Start()
        {
            _Thread = new Thread(this.Execute);
            _Thread.IsBackground = true;
            _Thread.Name = "CommandService";
            _Thread.Start();
        }
        private void Execute()
        {
            var cx = new CommandServiceContext(this);

            try
            {
                if (this.Commands.Count == 0)
                {
                    this.OnCompleted();
                    return;
                }

                Double d = 1 / this.Commands.Count;
                var count = this.Commands.Count;
                for (int i = 0; i < count; i++)
                {
                    var cm = this.Commands[i];
                    var progressed = d * i;
                    cm.ProcessProgress += (o, e) => this.OnProcessProgress(new ProcessProgressEventArgs(e.Message, progressed + e.Progress / count));
                    cm.Completed += (o, e) => this.OnCommandCompleted(new CommandCompletedEventArgs(o as DbSharpCommand));
                    cm.Execute(cx);
                    cx.PreviousCommand = cm;
                }
            }
            catch (Exception ex)
            {
                this.Exception = ex;
            }
            this.OnCompleted();
        }
        public void ThrowException()
        {
            if (this.Exception != null)
            {
                throw this.Exception;
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
        protected void OnCommandCompleted(CommandCompletedEventArgs e)
        {
            var eh = this.CommandCompleted;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class CommandCompletedEventArgs : EventArgs
    {
        public DbSharpCommand Command { get; set; }
        public CommandCompletedEventArgs(DbSharpCommand command)
        {
            this.Command = command;
        }
    }
}

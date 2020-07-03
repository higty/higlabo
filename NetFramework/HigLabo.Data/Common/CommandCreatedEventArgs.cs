using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace HigLabo.Data
{
    public class CommandCreatedEventArgs : EventArgs
    {
        public DbCommand Command { get; set; }
        public CommandCreatedEventArgs(DbCommand command)
        {
            this.Command = command;
        }
    }
}

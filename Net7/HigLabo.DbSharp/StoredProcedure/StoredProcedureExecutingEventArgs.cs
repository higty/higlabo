using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class StoredProcedureExecutingEventArgs : EventArgs
    {
        public Boolean Cancel { get; set; }
        public StoredProcedure StoredProcedure { get; private set; }
        public DbCommand Command { get; private set; }

        public StoredProcedureExecutingEventArgs(StoredProcedure storedProcedure, DbCommand command)
        {
            this.Cancel = false;
            this.StoredProcedure = storedProcedure;
            this.Command = command;
        }
    }
}

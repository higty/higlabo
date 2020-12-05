using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class StoredProcedureExecutedEventArgs : EventArgs
    {
        public StoredProcedure StoredProcedure { get; private set; }

        public StoredProcedureExecutedEventArgs(StoredProcedure storedProcedure)
        {
            this.StoredProcedure = storedProcedure;
        }
    }
}

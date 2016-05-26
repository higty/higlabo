using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class StoredProcedureExecutingEventArgs : EventArgs
    {
        public Boolean Cancel { get; set; }
        public StoredProcedure StoredProcedure { get; private set; }

        public StoredProcedureExecutingEventArgs(StoredProcedure storedProcedure)
        {
            this.Cancel = false;
            this.StoredProcedure = storedProcedure;
        }
    }
}

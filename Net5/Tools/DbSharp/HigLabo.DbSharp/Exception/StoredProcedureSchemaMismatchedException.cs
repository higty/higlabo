using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class StoredProcedureSchemaMismatchedException : Exception
    {
        public StoredProcedure StoredProcedure {get; private set;}
        public Int32 ColumnOrdinal { get; private set; }
        public StoredProcedureSchemaMismatchedException(StoredProcedure storedProcedure, Int32 columnOrdinal, Exception ex) :
            base(ex.Message, ex)
        {
            this.StoredProcedure = storedProcedure;
            this.ColumnOrdinal = columnOrdinal;
        }
    }
}

using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class ExecuteNonQueryResult
    {
        public Database Database { get; set; }
        public Int32 AffectedRecordCount { get; set; }

        public ExecuteNonQueryResult(Database database, Int32 affectedRecordCount)
        {
            this.Database = database;
            this.AffectedRecordCount = affectedRecordCount;
        }
    }
}

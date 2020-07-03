using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public class Column : DataType
    {
        public Boolean IsPrimaryKey { get; set; }
        public Boolean IsIdentity { get; set; }
        public Boolean IsRowGuidCol { get; set; }
        public Boolean IsServerAutomaticallyInsertValueColumn()
        {
            return this.DbType.IsTimestamp() == true ||
                this.IsIdentity == true ||
                this.IsRowGuidCol == true;
        }
        public Boolean CanUpdateValueColumn()
        {
            return this.DbType.IsTimestamp() == false &&
                this.IsIdentity == false;
        }
    }
}

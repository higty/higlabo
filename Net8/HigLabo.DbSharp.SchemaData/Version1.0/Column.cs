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
        public DefaultCostraint? DefaultCostraint { get; set; }
        public String Clustered { get; set; } = "";
        public ForeignKeyColumn? ForeignKey { get; set; }

        public Boolean IsServerAutomaticallyInsertValueColumn()
        {
            return this.DbType!.IsTimestamp() == true ||
                this.IsIdentity == true ||
                this.IsRowGuidCol == true;
        }
        public Boolean CanUpdateValueColumn()
        {
            return this.DbType!.IsTimestamp() == false &&
                this.IsIdentity == false;
        }
    }
    public class ForeignKeyColumn
    {
        public String ForeignKeyName { get; set; } = "";
        public String TableName { get; set; } = "";
        public String ColumnName { get; set; } = "";
        public String ParentTableName { get; set; } = "";
        public String ParentColumnName { get; set; } = "";
        public String OnUpdate { get; set; } = "";
        public String OnDelete { get; set; } = "";
    }
}

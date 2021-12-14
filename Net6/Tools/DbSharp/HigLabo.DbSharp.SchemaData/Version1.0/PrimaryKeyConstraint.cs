using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public class PrimaryKeyConstraint
    {
        public String Name { get; set; }
        public String TableName { get; set; }
        public String ColumnName { get; set; }
        public String Clustered { get; set; }
    }
}

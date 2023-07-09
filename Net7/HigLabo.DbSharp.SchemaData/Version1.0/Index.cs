using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public class Index
    {
        public String Name { get; set; } = "";
        public String TableName { get; set; } = "";
        public List<Column> Columns { get; set; } = new List<Column>();
        public String IndexType { get; set; } = "";
        public Boolean IsUnique { get; set; }
        public String ObjectType { get; set; } = "";
    }
}

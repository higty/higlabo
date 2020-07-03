using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public abstract class UserDefinedTableType<T> 
        where T : UserDefinedTableTypeRecord
    {
        private List<T> _Records = new List<T>();
        public List<T> Records
        {
            get { return _Records; }
        }

        public abstract DataTable CreateDataTable();
        public DataTable CreateDataTable(IEnumerable<T> records)
        {
            var dt = this.CreateDataTable();
            foreach (var item in records)
            {
                dt.Rows.Add(item.GetValues());
            }
            return dt;
        }
    }
}

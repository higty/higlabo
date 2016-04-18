using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class TableRecordNotFoundException : Exception
    {
        public String TableName { get; private set; }
        public Object[] Values { get; private set; }

        public TableRecordNotFoundException(String tableName)
        {
            this.TableName = tableName;
        }
        public TableRecordNotFoundException(String tableName, params Object[] values)
        {
            this.TableName = tableName;
            this.Values = values;
        }
    }
}

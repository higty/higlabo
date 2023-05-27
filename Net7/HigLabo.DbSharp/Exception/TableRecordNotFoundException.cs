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
            : base("TableName=" + tableName)
        {
            this.TableName = tableName;
        }
        public TableRecordNotFoundException(String tableName, params Object[] values)
            : base("TableName=" + tableName)
        {
            this.TableName = tableName;
            this.Values = values;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Values != null && this.Values.Length > 0)
            {
                var values = String.Join(",", this.Values);
                sb.AppendFormat("{0} ({1})", this.TableName, values);
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine(this.TableName);
            }
            sb.AppendLine(this.StackTrace);
            return sb.ToString();
        }
    }
}

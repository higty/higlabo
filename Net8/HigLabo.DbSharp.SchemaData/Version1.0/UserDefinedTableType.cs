using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public class UserDefinedTableType : DatabaseObject, INotifyPropertyChanged
    {
        private List<DataType> _Columns = new List<DataType>();

        public new DatabaseObjectType ObjectType
        {
            get { return base.ObjectType; }
        }
        public List<DataType> Columns
        {
            get { return _Columns; }
        }

        public UserDefinedTableType()
            : this("")
        {
        }
        public UserDefinedTableType(String name)
            : base(DatabaseObjectType.UserDefinedTableType)
        {
            this.Name = name;
            this.CreateTime = DateTime.Now;
            this.LastAlteredTime = DateTime.Now;
        }

        public String GetDefinitionText()
        {
            var u = this;
            var sb = new StringBuilder();

            sb.AppendFormat("CREATE TYPE {0} AS TABLE", u.Name).AppendLine();
            for (int i = 0; i < u.Columns.Count; i++)
            {
                var c = u.Columns[i];
                if (i == 0)
                {
                    sb.Append("(");
                    sb.Append(c.GetDeclareParameterText());
                }
                else
                {
                    sb.Append(",");
                    sb.Append(c.GetDeclareParameterText());
                }
                if (c.AllowNull == false)
                {
                    sb.Append(" NOT NULL");
                }
                sb.AppendLine();
            }
            sb.Append(")");

            return sb.ToString();
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}

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
    }
}

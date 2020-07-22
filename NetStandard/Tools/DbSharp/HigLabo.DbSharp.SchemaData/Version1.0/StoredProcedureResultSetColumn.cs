using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public class StoredProcedureResultSetColumn : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String _Name = "";
        private String _TableName = "";

        public String Name
        {
            get { return this._Name; }
            set { this.SetPropertyValue(ref _Name, value, PropertyChanged); }
        }
        public String TableName
        {
            get { return this._TableName; }
            set { this.SetPropertyValue(ref _TableName, value, PropertyChanged); }
        }
        public List<DataType> Columns { get; private set; }

        public StoredProcedureResultSetColumn()
            : this("ResultSet")
        {
        }
        public StoredProcedureResultSetColumn(String name)
        {
            this.Name = name;
            this.Columns = new List<DataType>();
        }

    }
}

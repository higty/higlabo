using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HigLabo.DbSharp.MetaData
{
    public class StoredProcedure : DatabaseObject, INotifyPropertyChanged
    {
        public override event PropertyChangedEventHandler PropertyChanged;

        private DatabaseServer _DatabaseServer = DatabaseServer.SqlServer;
        private String _TableName = "";
        private StoredProcedureType _StoredProcedureType = StoredProcedureType.Custom;

        public new DatabaseObjectType ObjectType
        {
            get { return base.ObjectType; }
        }
        public DatabaseServer DatabaseServer
        {
            get { return this._DatabaseServer; }
            set { this.SetPropertyValue(ref _DatabaseServer, value, this.PropertyChanged); }
        }
        public String TableName
        {
            get { return this._TableName; }
            set { this.SetPropertyValue(ref _TableName, value, this.PropertyChanged); }
        }
        public StoredProcedureType StoredProcedureType
        {
            get { return this._StoredProcedureType; }
            set { this.SetPropertyValue(ref _StoredProcedureType, value, this.PropertyChanged); }
        }
        public List<SqlInputParameter> Parameters { get; private set; }
        public List<StoredProcedureResultSetColumn> ResultSets { get; private set; }
        public StoredProcedure()
            : this(DatabaseServer.SqlServer, "")
        {
        }
        public StoredProcedure(DatabaseServer server, String name)
            : base(DatabaseObjectType.StoredProcedure)
        {
            this.Name = name;
            this.DatabaseServer = server;
            this.Parameters = new List<SqlInputParameter>();
            this.ResultSets = new List<StoredProcedureResultSetColumn>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

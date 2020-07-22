using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace HigLabo.DbSharp.MetaData
{
    public class SqlInputParameter : DataType
    {
        private String _UserTableTypeName = "";
        private ParameterDirection _ParameterDirection = ParameterDirection.Input;
        private String _ValueForTest = "";

        public String UserTableTypeName
        {
            get { return this._UserTableTypeName; }
            set { this.SetPropertyValue(ref _UserTableTypeName, value, GetPropertyChangedEventHandler()); }
        }
        public ParameterDirection ParameterDirection
        {
            get { return this._ParameterDirection; }
            set { this.SetPropertyValue(ref _ParameterDirection, value, GetPropertyChangedEventHandler()); }
        }
        public String ValueForTest
        {
            get { return this._ValueForTest; }
            set { this.SetPropertyValue(ref _ValueForTest, value, GetPropertyChangedEventHandler()); }
        }

        public SqlInputParameter()
        {
            this.ParameterDirection = ParameterDirection.Input;
        }
        public SqlInputParameter(String name, DataType column)
        {
            this.ParameterDirection = ParameterDirection.Input;
            this.SetProperty(column);
            this.Name = name;
        }
        public override String GetNameWithoutAtmark()
        {
            return this.Name.TrimStart('@');
        }
        protected override string GetDeclareTypeName()
        {
            switch (this.DbType.DatabaseServer)
            {
                case DatabaseServer.SqlServer:
                    {
                        var tp = this.DbType.SqlServerDbType.Value;
                        if (tp == SqlServer2012DbType.Structured)
                        {
                            return this.UserTableTypeName;
                        }
                    }
                    break;
                case DatabaseServer.Oracle: return this.DbType.OracleServerDbType.ToString();
                case DatabaseServer.MySql: return this.DbType.MySqlServerDbType.ToString();
                case DatabaseServer.PostgreSql: return this.DbType.PostgreSqlServerDbType.ToString();
                default: throw new InvalidOperationException();
            }
            return base.GetDeclareTypeName();
        }
        public override string GetClassName()
        {
            var tp = this.GetClassNameType();
            if (tp == ClassNameType.UserDefinedTableType)
            {
                return this.UserTableTypeName;
            }
            return base.GetClassName();
        }
    }
}

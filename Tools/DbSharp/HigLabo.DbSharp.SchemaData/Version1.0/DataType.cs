using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace HigLabo.DbSharp.MetaData
{
    public class DataType : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String _Name = "";
        private Double _Ordinal = 0;
        private DbType _DbType = null;
        private Int32? _Length = null;
        private Int32? _Precision = null;
        private Int32? _Scale = null;
        private Boolean _AllowNull = true;
        private String _UdtTypeName = "";
        private String _EnumName = "";
        private String _EnumValues = "";

        public String Name
        {
            get { return this._Name; }
            set { this.SetPropertyValue(ref _Name, value, PropertyChanged); }
        }
        public Double Ordinal
        {
            get { return this._Ordinal; }
            set { this.SetPropertyValue(ref _Ordinal, value, PropertyChanged); }
        }
        public DbType DbType
        {
            get { return this._DbType; }
            set { this.SetPropertyValue(ref _DbType, value, PropertyChanged); }
        }
        public Int32? Length
        {
            get { return this._Length; }
            set { this.SetPropertyValue(ref _Length, value, PropertyChanged); }
        }
        public Int32? Precision
        {
            get { return this._Precision; }
            set { this.SetPropertyValue(ref _Precision, value, PropertyChanged); }
        }
        public Int32? Scale
        {
            get { return this._Scale; }
            set { this.SetPropertyValue(ref _Scale, value, PropertyChanged); }
        }
        public Boolean AllowNull
        {
            get { return this._AllowNull; }
            set { this.SetPropertyValue(ref _AllowNull, value, PropertyChanged); }
        }
        public String UdtTypeName
        {
            get { return this._UdtTypeName; }
            set { this.SetPropertyValue(ref _UdtTypeName, value, PropertyChanged); }
        }
        public String EnumName
        {
            get { return this._EnumName; }
            set { this.SetPropertyValue(ref _EnumName, value, PropertyChanged); }
        }
        public String EnumValues
        {
            get { return this._EnumValues; }
            set { this.SetPropertyValue(ref _EnumValues, value, PropertyChanged); }
        }

        public SqlParameterConvertType ConvertType
        {
            get
            {
                if (String.IsNullOrEmpty(this.EnumName) == true)
                {
                    return SqlParameterConvertType.Default;
                }
                return SqlParameterConvertType.Enum;
            }
        }

        public DataType()
        {
            this.AllowNull = true;
        }
        public DataType(String name, DataType dataType)
        {
            this.SetProperty(dataType);
            this.Name = name;
        }
        public virtual String GetNameWithoutAtmark()
        {
            return this.Name;
        }
        public String GetDeclareParameterText()
        {
            switch (this.DbType.DatabaseServer)
            {
                case DatabaseServer.SqlServer:
                    #region
                    {
                        var tp = this.DbType;
                        if (tp.CanDeclareLength() == true && this.Length.HasValue == true)
                        {
                            if (this.Length > 8000 ||
                                this.Length == -1)
                            {
                                return String.Format("{0} {1} (max)", this.Name, this.GetDeclareTypeName());
                            }
                            else if (this.Length > 0)
                            {
                                return String.Format("{0} {1} ({2})", this.Name, this.GetDeclareTypeName(), this.Length);
                            }
                        }
                        else if (tp.CanDeclarePrecisionScale() == true && this.Precision.HasValue == true)
                        {
                            if (this.Scale.HasValue == true)
                            {
                                return String.Format("{0} {1} ({2}, {3})", this.Name, this.GetDeclareTypeName(), this.Precision, this.Scale);
                            }
                            return String.Format("{0} {1} ({2})", this.Name, this.GetDeclareTypeName(), this.Precision);
                        }
                        else if (tp.CanDeclareScale() == true && this.Scale > 0)
                        {
                            return String.Format("{0} {1} ({2})", this.Name, this.GetDeclareTypeName(), this.Scale);
                        }
                        return String.Format("{0} {1}", this.Name, this.GetDeclareTypeName());
                    }
                    #endregion
                case DatabaseServer.MySql:
                    #region
                    {
                        var tp = this.DbType;
                        if (tp.CanDeclareLength() == true && this.Length.HasValue == true)
                        {
                            return String.Format("{0} {1} ({2})", this.Name, this.GetDeclareTypeName(), this.Length);
                        }
                        else if (tp.CanDeclarePrecisionScale() == true && this.Precision.HasValue == true)
                        {
                            if (this.Scale.HasValue == true)
                            {
                                return String.Format("{0} {1} ({2}, {3})", this.Name, this.GetDeclareTypeName(), this.Precision, this.Scale);
                            }
                            return String.Format("{0} {1} ({2})", this.Name, this.GetDeclareTypeName(), this.Precision);
                        }
                        else if (tp.CanDeclareScale() == true && this.Scale > 0)
                        {
                            return String.Format("{0} {1} ({2})", this.Name, this.GetDeclareTypeName(), this.Scale);
                        }
                        //Unsigned type are UIntX and it does not have length,precision,scale.
                        if (tp.CanDeclareUnsigned() == true)
                        {
                            return String.Format("{0} {1} unsigned", this.Name, this.GetDeclareTypeName());
                        }
                        if (tp.MySqlServerDbType.Value == MySqlDbType.Year)
                        {
                            return String.Format("{0} year(4)", this.Name);
                        }
                        if (tp.MySqlServerDbType.Value == MySqlDbType.Enum ||
                            tp.MySqlServerDbType.Value == MySqlDbType.Set)
                        {
                            return String.Format("{0} {1}", this.Name, this.EnumValues);
                        }
                        return String.Format("{0} {1}", this.Name, this.GetDeclareTypeName());
                    }
                    #endregion
                case DatabaseServer.Oracle:
                case DatabaseServer.PostgreSql:
                default: throw new InvalidOperationException();
            }
        }
        protected virtual String GetDeclareTypeName()
        {
            switch (this.DbType.DatabaseServer)
            {
                case DatabaseServer.SqlServer:
                    {
                        var tp = this.DbType.SqlServerDbType.Value;
                        if (tp == SqlServer2012DbType.Structured)
                        {
                            throw new InvalidOperationException("DataType.DbType must not be DbType.Structured.");
                        }
                        else if (tp == SqlServer2012DbType.Udt)
                        {
                            return this.UdtTypeName;
                        }
                        else if (tp == SqlServer2012DbType.Variant) { return "sql_variant"; }
                        return tp.ToString();
                    }
                case DatabaseServer.Oracle: return this.DbType.OracleServerDbType.ToString();
                case DatabaseServer.MySql:
                    {
                        var tp = this.DbType.MySqlServerDbType.Value;
                        if (tp == MySqlDbType.String) return "char";
                        if (tp == MySqlDbType.Byte) return "tinyint";
                        if (tp == MySqlDbType.Int16) return "smallint";
                        if (tp == MySqlDbType.Int24) return "mediumint";
                        if (tp == MySqlDbType.Int32) return "int";
                        if (tp == MySqlDbType.Int64) return "bigint";
                        if (tp == MySqlDbType.String) return "char";
                        if (tp == MySqlDbType.UByte) return "tinyint";
                        if (tp == MySqlDbType.UInt16) return "smallint";
                        if (tp == MySqlDbType.UInt24) return "mediumint";
                        if (tp == MySqlDbType.UInt32) return "int";
                        if (tp == MySqlDbType.UInt64) return "bigint";
                        return this.DbType.MySqlServerDbType.ToString().ToLower();
                    }
                case DatabaseServer.PostgreSql: return this.DbType.PostgreSqlServerDbType.ToString();
                default: throw new InvalidOperationException();
            }
        }
        public virtual String GetClassName()
        {
            var tp = this.GetClassNameType();
            if (tp == ClassNameType.UserDefinedTableType)
            {
                throw new InvalidOperationException("DataType.DbType must not be DbType.Structured.");
            }

            switch (this.ConvertType)
            {
                case SqlParameterConvertType.Enum:
                    {
                        if (this.AllowNull == true)
                        {
                            return this.EnumName + "?";
                        }
                        return this.EnumName;
                    }
                case SqlParameterConvertType.Default:
                    if (this.AllowNull == true && tp.IsStructure() == true)
                    {
                        return tp.ToClassNameString() + "?";
                    }
                    return tp.ToClassNameString();
                default: throw new InvalidOperationException();
            }
        }
        public String GetClassNameText()
        {
            return this.GetClassNameType().ToClassNameString();
        }
        public ClassNameType GetClassNameType()
        {
            var type = this.DbType;
            switch (type.DatabaseServer)
            {
                case DatabaseServer.SqlServer:
                    if (this.DbType.SqlServerDbType.Value == SqlServer2012DbType.Udt)
                    {
                        switch (this.UdtTypeName)
                        {
                            case "geometry": return ClassNameType.Geometry;
                            case "geography": return ClassNameType.Geography;
                            case "hierarchyid": return ClassNameType.HierarchyId;
                            default: break;
                        }
                    }
                    return GetClassNameType(type.SqlServerDbType.Value);
                case DatabaseServer.Oracle: return GetClassNameType(type.OracleServerDbType.Value);
                case DatabaseServer.MySql: return GetClassNameType(type.MySqlServerDbType.Value);
                case DatabaseServer.PostgreSql:
                default: throw new InvalidOperationException();
            }
        }
        private static ClassNameType GetClassNameType(SqlServer2012DbType sqlType)
        {
            switch (sqlType)
            {
                case SqlServer2012DbType.BigInt:
                    return ClassNameType.Int64;

                case SqlServer2012DbType.Binary:
                case SqlServer2012DbType.Image:
                case SqlServer2012DbType.Timestamp:
                case SqlServer2012DbType.VarBinary:
                    return ClassNameType.ByteArray;

                case SqlServer2012DbType.Bit:
                    return ClassNameType.Boolean;

                case SqlServer2012DbType.Char:
                case SqlServer2012DbType.NChar:
                case SqlServer2012DbType.NText:
                case SqlServer2012DbType.NVarChar:
                case SqlServer2012DbType.Text:
                case SqlServer2012DbType.VarChar:
                case SqlServer2012DbType.Xml:
                    return ClassNameType.String;

                case SqlServer2012DbType.DateTime:
                case SqlServer2012DbType.SmallDateTime:
                case SqlServer2012DbType.Date:
                case SqlServer2012DbType.DateTime2:
                    return ClassNameType.DateTime;

                case SqlServer2012DbType.Time:
                    return ClassNameType.TimeSpan;

                case SqlServer2012DbType.Decimal:
                case SqlServer2012DbType.Money:
                case SqlServer2012DbType.SmallMoney:
                    return ClassNameType.Decimal;

                case SqlServer2012DbType.Float:
                    return ClassNameType.Double;

                case SqlServer2012DbType.Int:
                    return ClassNameType.Int32;

                case SqlServer2012DbType.Real:
                    return ClassNameType.Single;

                case SqlServer2012DbType.UniqueIdentifier:
                    return ClassNameType.Guid;

                case SqlServer2012DbType.SmallInt:
                    return ClassNameType.Int16;

                case SqlServer2012DbType.TinyInt:
                    return ClassNameType.Byte;

                case SqlServer2012DbType.Variant:
                case SqlServer2012DbType.Udt:
                    return ClassNameType.Object;

                case SqlServer2012DbType.Structured:
                    return ClassNameType.UserDefinedTableType;

                case SqlServer2012DbType.DateTimeOffset:
                    return ClassNameType.DateTimeOffset;

                default: return ClassNameType.Object;
            }
        }
        private static ClassNameType GetClassNameType(OracleDbType sqlType)
        {
            throw new NotImplementedException();

            //switch (sqlType)
            //{
            //    case Oracle.DataAccess.Client.OracleDbType.Array:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.BFile:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.BinaryDouble:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.BinaryFloat:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Blob:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Byte:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Char:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Clob:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Date:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Decimal:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Double:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Int16:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Int32:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Int64:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.IntervalDS:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.IntervalYM:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Long:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.LongRaw:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.NChar:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.NClob:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.NVarchar2:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Object:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Raw:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Ref:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.RefCursor:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Single:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.TimeStamp:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.TimeStampLTZ:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.TimeStampTZ:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.Varchar2:
            //        break;
            //    case Oracle.DataAccess.Client.OracleDbType.XmlType:
            //        break;
            //    default:
            //        break;
            //}
        }
        private static ClassNameType GetClassNameType(MySqlDbType sqlType)
        {
            switch (sqlType)
            {
                case MySqlDbType.Blob:
                case MySqlDbType.TinyBlob:
                case MySqlDbType.MediumBlob:
                case MySqlDbType.LongBlob:
                case MySqlDbType.Binary:
                case MySqlDbType.VarBinary:
                    return ClassNameType.ByteArray;
           
                case MySqlDbType.Timestamp:
                    return ClassNameType.DateTime;

                case MySqlDbType.Bit: 
                    return ClassNameType.Boolean;
                case MySqlDbType.Guid:
                    return ClassNameType.Guid;

                case MySqlDbType.Date:
                case MySqlDbType.Newdate:
                case MySqlDbType.DateTime:
                    return ClassNameType.DateTime;
                case MySqlDbType.Time:
                    return ClassNameType.TimeSpan;
                case MySqlDbType.Year:
                    return ClassNameType.Int32;

                case MySqlDbType.Byte:
                    return ClassNameType.SByte;
                case MySqlDbType.Int16:
                    return ClassNameType.Int16;
                case MySqlDbType.Int24:
                case MySqlDbType.Int32:
                    return ClassNameType.Int32;
                case MySqlDbType.Int64:
                    return ClassNameType.Int64;
                case MySqlDbType.UByte:
                    return ClassNameType.Byte;
                case MySqlDbType.UInt16:
                    return ClassNameType.UInt16;
                case MySqlDbType.UInt24:
                    return ClassNameType.UInt32;
                case MySqlDbType.UInt32:
                    return ClassNameType.UInt32;
                case MySqlDbType.UInt64:
                    return ClassNameType.UInt64;

                case MySqlDbType.Float:
                    return ClassNameType.Single;
                case MySqlDbType.Double:
                    return ClassNameType.Double;
                case MySqlDbType.Decimal:
                    return ClassNameType.Decimal;
                case MySqlDbType.NewDecimal:
                    return ClassNameType.Decimal;

                case MySqlDbType.String:
                case MySqlDbType.Text:
                case MySqlDbType.VarChar:
                case MySqlDbType.VarString:
                case MySqlDbType.TinyText:
                case MySqlDbType.MediumText:
                case MySqlDbType.LongText:
                    return ClassNameType.String;

                case MySqlDbType.Geometry:
                    return ClassNameType.MySqlGeometry;
                case MySqlDbType.Enum:
                    return ClassNameType.String;
                case MySqlDbType.Set:
                    return ClassNameType.String;

                default:
                    return ClassNameType.Object;
            }
        }
        protected PropertyChangedEventHandler GetPropertyChangedEventHandler()
        {
            return this.PropertyChanged;
        }

        public void SetProperty(DataType dataType)
        {
            this.Name = dataType.Name;
            this.Ordinal = dataType.Ordinal;
            this.DbType = dataType.DbType;
            this.Length = dataType.Length;
            this.Precision = dataType.Precision;
            this.Scale = dataType.Scale;
            this.AllowNull = dataType.AllowNull;
            this.UdtTypeName = dataType.UdtTypeName;
            this.EnumName = dataType.EnumName;
            this.EnumValues = dataType.EnumValues;
        }

        public override string ToString()
        {
            var nullText = "";
            if (this.AllowNull)
            {
                nullText = "Allow Null";
            }
            else
            {
                nullText = "Not Null";
            }
            return String.Format("{0} {1}", this.GetDeclareParameterText(), nullText);
        }
    }
}

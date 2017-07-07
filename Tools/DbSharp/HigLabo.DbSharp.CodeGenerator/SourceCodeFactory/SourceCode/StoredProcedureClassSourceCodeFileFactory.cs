using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.DbSharp;
using HigLabo.CodeGenerator;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class StoredProcedureClassSourceCodeFileFactory : ClassSourceCodeFileFactory
    {
        public StoredProcedure StoredProcedure { get; private set; }
        public String DatabaseKey { get; private set; }

        public StoredProcedureClassSourceCodeFileFactory(StoredProcedure storedProcedure, String databaseKey)
        {
            this.StoredProcedure = storedProcedure;
            this.DatabaseKey = databaseKey;
        }
        public override SourceCodeFile Create(String directoryPath, String namespaceName)
        {
            var sp = this.StoredProcedure;
            var sc = new SourceCode();

            sc.UsingNamespaces.Add("System");
            sc.UsingNamespaces.Add("System.Data");
            sc.UsingNamespaces.Add("System.Data.Common");
            sc.UsingNamespaces.Add("System.Text");
            sc.UsingNamespaces.Add("System.Collections.Generic");
            sc.UsingNamespaces.Add("System.IO");
            sc.UsingNamespaces.Add("System.ComponentModel");
            sc.UsingNamespaces.Add("HigLabo.Core");
            sc.UsingNamespaces.Add("HigLabo.Data");
            sc.UsingNamespaces.Add("HigLabo.DbSharp");
            switch (sp.DatabaseServer)
            {
                case DatabaseServer.SqlServer:break;
                case DatabaseServer.Oracle: throw new NotImplementedException();
                case DatabaseServer.MySql: 
                    sc.UsingNamespaces.Add("MySql.Data.Types");
                    sc.UsingNamespaces.Add("MySql.Data.MySqlClient");
                    break;
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default:break;
            }

            var ns = new Namespace(namespaceName);
            ns.Classes.Add(CreateClass());
            sc.Namespaces.Add(ns);

            return new SourceCodeFile(Path.Combine(directoryPath, sp.Name + ".cs"), sc);
        }
     
        public Class CreateClass()
        {
            var sp = this.StoredProcedure;
            Class c = new Class(AccessModifier.Public, sp.Name);
            StoredProcedureResultSetColumn rs = null;

            c.Modifier.Partial = true;
            if (sp.ResultSets.Count > 0)
            {
                rs = sp.ResultSets[0];
            }
            if (rs == null)
            {
                c.BaseClass = new TypeName("StoredProcedure");
            }
            else 
            {
                if (sp.ResultSets.Count == 1)
                {
                    c.BaseClass = new TypeName(String.Format("StoredProcedureWithResultSet<{0}.{1}>", sp.Name, rs.Name));
                }
                else
                {
                    c.BaseClass = new TypeName(String.Format("StoredProcedureWithResultSetsList<{0}.{1}, {0}.ResultSetsList>", sp.Name, rs.Name));
                }
            }
            c.Fields.Add(CreateNameConstField());

            if (sp.Parameters.Exists(el => el.Name == "DatabaseKey") == false)
            {
                c.Properties.Add(CreateDatabaseKeyProperty());
            }
            if (sp.Parameters.Exists(el => el.Name == "TransactionKey") == false)
            {
                c.Properties.Add(CreateTransactionKeyProperty());
            }

            ClassSourceCodeFileFactory.AddPropertyAndField(c, sp.Parameters);

            c.Constructors.Add(CreateConstructor());

            c.Methods.Add(CreateGetStoredProcedureNameMethod());
            c.Methods.Add(new Method(MethodAccessModifier.Partial, "ConstructorExecuted"));
            c.Methods.Add(CreateCreateCommandMethod());
            c.Methods.Add(CreateSetOutputParameterValueMethod());

            if (rs != null)
            {
                c.Methods.Add(CreateCreateResultSetMethod());

                for (int i = 0; i < sp.ResultSets.Count; i++)
                {
                    if (i == 0)
                    {
                        c.Methods.Add(CreateSetResultSetMethod(sp.ResultSets[i], MethodPolymophism.Override));
                    }
                    else
                    {
                        c.Methods.Add(CreateSetResultSetMethod(sp.ResultSets[i], MethodPolymophism.None));
                    }
                    var f = new ResultSetClassFactory(sp.Name, sp.StoredProcedureType, sp.ResultSets[i]);
                    c.Classes.Add(f.CreateClass());
                }
                if (sp.ResultSets.Count > 1)
                {
                    var f = new ResultSetsListClassFactory(sp);
                    c.Classes.Add(f.CreateClass());

                    c.Methods.Add(CreateSetResultSetsListMethod());
                    c.Methods.Add(CreateMergeMethod());
                }
            }
            c.Methods.Add(CreateToStringMethod());

            return c;
        }

        public Field CreateNameConstField()
        {
            var f = new Field("String", "Name");
            f.Modifier.AccessModifier = AccessModifier.Public;
            f.Modifier.Const = true;
            f.Initializer = String.Format("\"{0}\"", this.StoredProcedure.Name);
            return f;
        }
        public Property CreateDatabaseKeyProperty()
        {
            Property p = new Property("String", "DatabaseKey");
            p.Modifier.AccessModifier = MethodAccessModifier.Public;
            p.Get.Body.Add(SourceCodeLanguage.CSharp, "return ((IDatabaseContext)this).DatabaseKey;");
            p.Set.Body.Add(SourceCodeLanguage.CSharp, "((IDatabaseContext)this).DatabaseKey = value;");

            return p;
        }
        public Property CreateTransactionKeyProperty()
        {
            Property p = new Property("String", "TransactionKey");
            p.Modifier.AccessModifier = MethodAccessModifier.Public;
            p.Get.Body.Add(SourceCodeLanguage.CSharp, "return ((IDatabaseContext)this).TransactionKey;");
            p.Set.Body.Add(SourceCodeLanguage.CSharp, "((IDatabaseContext)this).TransactionKey = value;");

            return p;
        }
 
        public Method CreateGetStoredProcedureNameMethod()
        {
            var sp = this.StoredProcedure;
            var md = new Method( MethodAccessModifier.Public, "GetStoredProcedureName");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("String");
            md.Body.Add(SourceCodeLanguage.CSharp, "return {0}.Name;", sp.Name);

            return md;
        }

        public Constructor CreateConstructor()
        {
            var sp = this.StoredProcedure;
            Constructor ct = new Constructor(AccessModifier.Public, sp.Name);

            ct.Body.Add(SourceCodeLanguage.CSharp, "((IDatabaseContext)this).DatabaseKey = \"{0}\";", this.DatabaseKey);
            ct.Body.Add(SourceCodeLanguage.CSharp, "ConstructorExecuted();");
            if (sp.ResultSets.Count > 1)
            {
                ct.Body.Add(SourceCodeLanguage.CSharp, "_MergeMethod = Merge;");
                foreach (var rs in sp.ResultSets)
                {
                    ct.Body.Add(SourceCodeLanguage.CSharp, "_CreateResultSetMethodList.Add(CreateCreateResultSetMethod<{0}>(this.SetResultSet));", rs.Name);
                }
            }
            return ct;
        }

        public Method CreateCreateCommandMethod()
        {
            var sp = this.StoredProcedure;
            Method md = new Method(MethodAccessModifier.Public, "CreateCommand");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("DbCommand");

            md.Body.AddRange(CreateCreateCommandMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateCreateCommandMethodBody()
        {
            var sp = this.StoredProcedure;
            String pName = "";

            switch (this.StoredProcedure.DatabaseServer)
            {
                case DatabaseServer.SqlServer: yield return new CodeBlock(SourceCodeLanguage.CSharp, "var db = new SqlServerDatabase(\"\");"); break;
                case DatabaseServer.MySql: yield return new CodeBlock(SourceCodeLanguage.CSharp, "var db = new MySqlDatabase(\"\");"); break;
                case DatabaseServer.Oracle: yield return new CodeBlock(SourceCodeLanguage.CSharp, "var db = new OracleDatabase(\"\");"); break;
                case DatabaseServer.PostgreSql: yield return new CodeBlock(SourceCodeLanguage.CSharp, "var db = new PostgreSqlDatabase(\"\");"); break;
                default: throw new InvalidOperationException();
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var cm = db.CreateCommand();");
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "cm.CommandType = CommandType.StoredProcedure;");
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "cm.CommandText = this.GetStoredProcedureName();");

            if (sp.Parameters.Count > 0)
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "");
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "DbParameter p = null;"); 
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "");
                
                foreach (var parameter in sp.Parameters)
                {
                    pName = parameter.GetNameWithoutAtmark();

                    yield return new CodeBlock(SourceCodeLanguage.CSharp, "p = db.CreateParameter(\"{0}\", {1}, {2}, {3});"
                        , parameter.Name, parameter.DbType.GetDbTypeCodeBlock()
                        , parameter.Precision.HasValue ? parameter.Precision.ToString() : "null"
                        , parameter.Scale.HasValue ? parameter.Scale.ToString(): "null");
                    yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.SourceColumn = p.ParameterName;");
                    switch (parameter.ParameterDirection)
                    {
                        case ParameterDirection.Input: yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.Direction = ParameterDirection.Input;"); break;
                        case ParameterDirection.InputOutput: yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.Direction = ParameterDirection.InputOutput;"); break;
                        case ParameterDirection.Output: yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.Direction = ParameterDirection.Output;"); break;
                        case ParameterDirection.ReturnValue: yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.Direction = ParameterDirection.ReturnValue;"); break;
                        default: throw new InvalidOperationException();
                    }
                    if (parameter.Length.HasValue == true)
                    {
                        yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.Size = {0};", parameter.Length);
                    }

                    if (parameter.DbType.IsStructured() == true)
                    {
                        yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.SetTypeName(\"{0}\");", parameter.UserTableTypeName);
                    }
                    if (parameter.DbType.IsUdt() == true)
                    {
                        yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.SetUdtTypeName(\"{0}\");", parameter.UdtTypeName);
                    }
                    switch (parameter.ConvertType)
                    {
                        case SqlParameterConvertType.Default:
                            if (parameter.DbType.IsUserDefinedTableType() == true)
                            {
                                var dtCodeBlock = new CodeBlock(SourceCodeLanguage.CSharp, "");
                                dtCodeBlock.CurlyBracket = true;
                                dtCodeBlock.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "var dt = this.{0}.CreateDataTable();", pName));
                                var foreachCodeBlock = new CodeBlock(SourceCodeLanguage.CSharp, "foreach (var item in this.{0}.Records)", pName);
                                foreachCodeBlock.CurlyBracket = true;
                                foreachCodeBlock.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "dt.Rows.Add(item.GetValues());"));
                                dtCodeBlock.CodeBlocks.Add(foreachCodeBlock);
                                dtCodeBlock.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "p.Value = dt;"));
                                yield return dtCodeBlock;
                            }
                            else
                            {
                                yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.Value = this.{0};", pName);
                            }
                            break;
                        case SqlParameterConvertType.Enum:
                            var methodName = "ToStringFromEnum";
                            if (parameter.AllowNull == true)
                            {
                                methodName = "ToStringOrNullFromEnum";
                            }
                            yield return new CodeBlock(SourceCodeLanguage.CSharp, "p.Value = this.{0}.{1}();", pName, methodName); break;
                        default: throw new InvalidOperationException();
                    }
                    yield return new CodeBlock(SourceCodeLanguage.CSharp, "cm.Parameters.Add(p);");
                    yield return new CodeBlock(SourceCodeLanguage.CSharp, "");
                }

                var cb = new CodeBlock(SourceCodeLanguage.CSharp, "for (int i = 0; i < cm.Parameters.Count; i++)");
                cb.CurlyBracket = true;
                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "if (cm.Parameters[i].Value == null) cm.Parameters[i].Value = DBNull.Value;"));
                yield return cb;
            }

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return cm;");
        }

        public Method CreateSetOutputParameterValueMethod()
        {
            var sp = this.StoredProcedure;
            Method md = new Method(MethodAccessModifier.Protected, "SetOutputParameterValue");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("void");

            md.AddParameter("DbCommand", "command");

            md.Body.AddRange(CreateSetOutputParameterValueMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateSetOutputParameterValueMethodBody()
        {
            var sp = this.StoredProcedure;
            Boolean addedInitializeCodeBlcok = false;

            foreach (var parameter in sp.Parameters)
            {
                if (parameter.ParameterDirection == System.Data.ParameterDirection.Input) continue;
                if (addedInitializeCodeBlcok == false)
                {
                    yield return new CodeBlock(SourceCodeLanguage.CSharp, "var cm = command;");
                    yield return new CodeBlock(SourceCodeLanguage.CSharp, "DbParameter p = null;");
                    addedInitializeCodeBlcok = true;
                }
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "p = cm.Parameters[{0}] as DbParameter;", parameter.Ordinal);
                switch (parameter.ConvertType)
                {
                    case SqlParameterConvertType.Default:
                        if (sp.DatabaseServer == DatabaseServer.MySql &&
                            parameter.DbType.MySqlServerDbType == MetaData.MySqlDbType.Bit)
                        {
                            yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (p.Value != DBNull.Value && p.Value != null) this.{0} = ((UInt64)p.Value != 0);"
                                , parameter.GetNameWithoutAtmark());
                        }
                        else
                        {
                            yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (p.Value != DBNull.Value && p.Value != null) this.{0} = ({1})p.Value;"
                                , parameter.GetNameWithoutAtmark(), parameter.GetClassNameText());
                        }
                        break;
                    case SqlParameterConvertType.Enum:
                        yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (p.Value != DBNull.Value && p.Value != null) this.{0} = StoredProcedure.ToEnum<{1}>(p.Value as String) ?? this.{0};"
                            , parameter.GetNameWithoutAtmark(), parameter.EnumName);
                        break;
                    default: throw new InvalidOperationException();
                }
            }
        }

        public Method CreateCreateResultSetMethod()
        {
            var sp = this.StoredProcedure;
            var rs = sp.ResultSets[0];
            Method md = new Method(MethodAccessModifier.Public, "CreateResultSet");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName(String.Format("{0}.{1}", sp.Name, rs.Name));

            md.Body.Add(SourceCodeLanguage.CSharp, "return new {0}(this);", rs.Name);
            return md;
        }
     
        public Method CreateSetResultSetMethod(StoredProcedureResultSetColumn resultSet, MethodPolymophism polymophism)
        {
            var sp = this.StoredProcedure;
            Method md = new Method(MethodAccessModifier.Protected, "SetResultSet");
            md.Modifier.Polymophism = polymophism;

            md.AddParameter(String.Format("{0}.{1}", sp.Name, resultSet.Name), "resultSet");
            md.AddParameter("IDataReader", "reader");

            md.Body.AddRange(CreateSetResultSetMethodBody(resultSet));
            return md;
        }
        public IEnumerable<CodeBlock> CreateSetResultSetMethodBody(StoredProcedureResultSetColumn resultSet)
        {
            var sp = this.StoredProcedure;
            CodeBlock cb = null;
            CodeBlock setCode = null;
            String code = "";

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var r = resultSet;");
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "Int32 index = -1;");

            cb = new CodeBlock(SourceCodeLanguage.CSharp, "try");
            cb.CurlyBracket = true;
            foreach (var parameter in resultSet.Columns)
            {
                code = "index += 1; ";
                if (parameter.AllowNull == true)
                {
                    code += "if (reader[index] != DBNull.Value) ";
                }
                if (parameter.DbType.IsUdt() == true)
                {
                    code += String.Format("r.{0} = ({1})reader[index];", parameter.Name, parameter.GetClassNameText());
                    setCode = new CodeBlock(SourceCodeLanguage.CSharp, code);
                }
                else
                {
                    switch (parameter.ConvertType)
                    {
                        case SqlParameterConvertType.Default: code += String.Format("r.{0} = {1};", parameter.Name, this.CreateDataReaderCastCSharpCode(parameter)); break;
                        case SqlParameterConvertType.Enum: code += String.Format("r.{0} = StoredProcedure.ToEnum<{1}>(reader[index] as String) ?? r.{0};", parameter.Name, parameter.EnumName); break;
                        default: throw new InvalidOperationException();
                    }
                    setCode = new CodeBlock(SourceCodeLanguage.CSharp, code);
                }
                cb.CodeBlocks.Add(setCode);
            }
            yield return cb;

            cb = new CodeBlock(SourceCodeLanguage.CSharp, "catch (InvalidCastException ex)");
            cb.CurlyBracket = true;
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "throw new StoredProcedureSchemaMismatchedException(this, index, ex);"));
            yield return cb;
        }
        public String CreateDataReaderCastCSharpCode(DataType type)
        {
            switch (type.DbType.DatabaseServer)
            {
                case DatabaseServer.SqlServer: return this.CreateDataReaderCastCSharpCodeSqlServer(type);
                case DatabaseServer.MySql: return this.CreateDataReaderCastCSharpCodeMySql(type);
                case DatabaseServer.Oracle:
                case DatabaseServer.PostgreSql: throw new NotImplementedException();
                default: throw new InvalidOperationException();
            }
        }
        private String CreateDataReaderCastCSharpCodeSqlServer(DataType type)
        {
            switch (type.DbType.SqlServerDbType)
            {
                case SqlServer2012DbType.BigInt:
                    return "reader.GetInt64(index)";

                case SqlServer2012DbType.Image:
                case SqlServer2012DbType.Binary:
                case SqlServer2012DbType.Timestamp:
                case SqlServer2012DbType.VarBinary:
                    return "reader[index] as Byte[]";

                case SqlServer2012DbType.Bit:
                    return "reader.GetBoolean(index)";

                case SqlServer2012DbType.Char:
                case SqlServer2012DbType.NChar:
                case SqlServer2012DbType.NText:
                case SqlServer2012DbType.NVarChar:
                case SqlServer2012DbType.Text:
                case SqlServer2012DbType.VarChar:
                case SqlServer2012DbType.Xml:
                    return "reader[index] as String";

                case SqlServer2012DbType.DateTime:
                case SqlServer2012DbType.SmallDateTime:
                case SqlServer2012DbType.Date:
                case SqlServer2012DbType.DateTime2:
                    return "reader.GetDateTime(index)";

                case SqlServer2012DbType.Time:
                    return "(TimeSpan)reader[index]";

                case SqlServer2012DbType.DateTimeOffset:
                    return "(DateTimeOffset)reader[index]";

                case SqlServer2012DbType.Decimal:
                case SqlServer2012DbType.Money:
                case SqlServer2012DbType.SmallMoney:
                    return "reader.GetDecimal(index)";

                case SqlServer2012DbType.Float:
                    return "reader.GetDouble(index)";

                case SqlServer2012DbType.Int:
                    return "reader.GetInt32(index)";

                case SqlServer2012DbType.Real:
                    return "reader.GetFloat(index)";

                case SqlServer2012DbType.SmallInt:
                    return "reader.GetInt16(index)";

                case SqlServer2012DbType.Structured:
                    return "reader[index] as DataTable";

                case SqlServer2012DbType.TinyInt:
                    return "reader.GetByte(index)";

                case SqlServer2012DbType.Variant:
                case SqlServer2012DbType.Udt:
                    return "reader[index] as Object";

                case SqlServer2012DbType.UniqueIdentifier:
                    return "reader.GetGuid(index)";

                default:
                    return "reader[index] as Object";
            }
        }
        private String CreateDataReaderCastCSharpCodeMySql(DataType type)
        {
            switch (type.DbType.MySqlServerDbType.Value)
            {
                case MetaData.MySqlDbType.Blob:
                case MetaData.MySqlDbType.TinyBlob:
                case MetaData.MySqlDbType.MediumBlob:
                case MetaData.MySqlDbType.LongBlob:
                case MetaData.MySqlDbType.Binary:
                case MetaData.MySqlDbType.VarBinary:
                    return "reader[index] as Byte[]";

                case MetaData.MySqlDbType.Timestamp:
                    return "reader.GetDateTime(index)";

                case MetaData.MySqlDbType.Bit:
                    return "((UInt64)reader[index] != 0)";
                case MetaData.MySqlDbType.Guid:
                    return "reader.GetGuid(index)";

                case MetaData.MySqlDbType.Date:
                case MetaData.MySqlDbType.Newdate:
                case MetaData.MySqlDbType.DateTime:
                    return "reader.GetDateTime(index)";
                case MetaData.MySqlDbType.Time:
                    return " (TimeSpan)reader[index]";
                case MetaData.MySqlDbType.Year:
                    return "reader.GetInt32(index)";

                case MetaData.MySqlDbType.Byte:
                    return "(SByte)reader[index]";
                case MetaData.MySqlDbType.Int16:
                    return "reader.GetInt16(index)";
                case MetaData.MySqlDbType.Int24:
                case MetaData.MySqlDbType.Int32:
                    return "reader.GetInt32(index)";
                case MetaData.MySqlDbType.Int64:
                    return "reader.GetInt64(index)";
                case MetaData.MySqlDbType.UByte:
                    return "reader.GetByte(index)";
                case MetaData.MySqlDbType.UInt16:
                    return "(UInt16)reader[index]";
                case MetaData.MySqlDbType.UInt24:
                case MetaData.MySqlDbType.UInt32:
                    return "(UInt32)reader[index]";
                case MetaData.MySqlDbType.UInt64:
                    return "(UInt64)reader[index]";

                case MetaData.MySqlDbType.Float:
                    return "reader.GetFloat(index)";
                case MetaData.MySqlDbType.Double:
                    return "reader.GetDouble(index)";
                case MetaData.MySqlDbType.Decimal:
                    return "reader.GetDecimal(index)";
                case MetaData.MySqlDbType.NewDecimal:
                    return "reader.GetDecimal(index)";

                case MetaData.MySqlDbType.String:
                case MetaData.MySqlDbType.Text:
                case MetaData.MySqlDbType.VarChar:
                case MetaData.MySqlDbType.VarString:
                case MetaData.MySqlDbType.TinyText:
                case MetaData.MySqlDbType.MediumText:
                case MetaData.MySqlDbType.LongText:
                    return "reader[index] as String";

                case MetaData.MySqlDbType.Geometry:
                    return "((MySqlDataReader)reader).GetMySqlGeometry(index)";
                case MetaData.MySqlDbType.Enum:
                case MetaData.MySqlDbType.Set:
                    return String.Format("StoredProcedure.ToEnum<{0}>(reader[index] as String) ?? r.EnumColumn", type.EnumName);

                default: return "reader[index] as Object";
            }
        }

        public Method CreateToStringMethod()
        {
            var sp = this.StoredProcedure;
            Method md = new Method(MethodAccessModifier.Public, "ToString");
            md.ReturnTypeName =  new TypeName("String");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.Body.AddRange(CreateToStringMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateToStringMethodBody()
        {
            var sp = this.StoredProcedure;

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var sb = new StringBuilder(32);");
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "sb.AppendLine(\"<{0}>\");", sp.Name);

            foreach (var parameter in sp.Parameters)
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "sb.AppendFormat(\"{0}={1}\", this.{0}); sb.AppendLine();", parameter.GetNameWithoutAtmark(), "{0}");
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return sb.ToString();");
        }

        public Method CreateSetResultSetsListMethod()
        {
            var sp = this.StoredProcedure;
            Method md = new Method(MethodAccessModifier.Protected, "SetResultSetsList");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.Parameters.Add(new MethodParameter("ResultSetsList", "resultSetsList"));
            md.Parameters.Add(new MethodParameter("List<List<StoredProcedureResultSet>>", "list"));
            md.Body.AddRange(CreateSetResultSetsListMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateSetResultSetsListMethodBody()
        {
            var sp = this.StoredProcedure;
            var sb = new StringBuilder(128);

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var rs = resultSetsList;");
            sb.Append("var l = list;");

            yield return new CodeBlock(SourceCodeLanguage.CSharp, sb.ToString());

            for (int i = 0; i < sp.ResultSets.Count; i++)
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "rs.{0}List.AddRange(l[{1}].ConvertAll(el => ({0})el));"
                    , sp.ResultSets[i].Name, i);
            }
        }

        public Method CreateMergeMethod()
        {
            var sp = this.StoredProcedure;
            Method md = new Method(MethodAccessModifier.Public, "Merge");
            md.Modifier.Static = true;
            md.Parameters.Add(new MethodParameter("ResultSetsList", "source"));
            md.Parameters.Add(new MethodParameter("ResultSetsList", "target"));

            md.Body.AddRange(CreateMergeMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateMergeMethodBody()
        {
            var sp = this.StoredProcedure;
            var sb = new StringBuilder(128);

            foreach (var item in this.StoredProcedure.ResultSets)
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "target.{0}List.AddRange(source.{0}List);", item.Name);
            }
        }
    }
}

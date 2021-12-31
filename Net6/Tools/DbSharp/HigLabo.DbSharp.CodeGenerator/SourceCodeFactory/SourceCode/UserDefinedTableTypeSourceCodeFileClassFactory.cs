using HigLabo.CodeGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class UserDefinedTableTypeSourceCodeFileClassFactory : ClassSourceCodeFileFactory
    {
        public UserDefinedTableType UserDefinedTableType { get; private set; }
        public UserDefinedTableTypeSourceCodeFileClassFactory(UserDefinedTableType userDefinedTableType)
        {
            this.UserDefinedTableType = userDefinedTableType;
        }
        public override SourceCodeFile Create(String directoryPath, String namespaceName)
        {
            var sp = this.UserDefinedTableType;
            var sc = new SourceCode();

            sc.UsingNamespaces.Add("System");
            sc.UsingNamespaces.Add("System.Text");
            sc.UsingNamespaces.Add("System.Data");
            sc.UsingNamespaces.Add("System.Collections.Generic");
            sc.UsingNamespaces.Add("System.ComponentModel");
            sc.UsingNamespaces.Add("Microsoft.Data.SqlClient.Server");
            sc.UsingNamespaces.Add("HigLabo.DbSharp");

            var ns = new Namespace(namespaceName);
            ns.Classes.Add(CreateClass());
            sc.Namespaces.Add(ns);

            return new SourceCodeFile(Path.Combine(directoryPath, sp.Name + ".cs"), sc);
        }
        public Class CreateClass()
        {
            Class c = new Class(AccessModifier.Public, this.UserDefinedTableType.Name);

            c.Modifier.Partial = true;
            c.BaseClass = new TypeName(String.Format("UserDefinedTableType<{0}.Record>", this.UserDefinedTableType.Name));

            var factory = new UserDefinedTableTypeRecordClassFactory(this.UserDefinedTableType);
            c.Classes.Add(factory.CreateClass());

            c.Methods.Add(CreateSqlDataRecordMethod());

            return c;
        }
        private Method CreateSqlDataRecordMethod()
        {
            Method md = new Method(MethodAccessModifier.Public, "CreateSqlDataRecord");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("SqlDataRecord");
            md.Body.AddRange(CreateSqlDataRecordBody());
            return md;
        }
        private IEnumerable<CodeBlock> CreateSqlDataRecordBody()
        {
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "SqlMetaData[] metaData = new SqlMetaData[{0}];"
                , this.UserDefinedTableType.Columns.Count);
            for (int i = 0; i < this.UserDefinedTableType.Columns.Count; i++)
            {
                var column = this.UserDefinedTableType.Columns[i];
                switch (column.DbType.SqlServerDbType.Value)
                {
                    case SqlServer2022DbType.Decimal:
                        yield return new CodeBlock(SourceCodeLanguage.CSharp
                            , "metaData[{0}] = new SqlMetaData(\"{1}\", {2}, {3}, {4});"
                            , i, column.Name, column.DbType.GetDbTypeCodeBlock(), column.Precision, column.Scale);
                        break;
                    case SqlServer2022DbType.Binary:
                    case SqlServer2022DbType.VarBinary:
                    case SqlServer2022DbType.Variant:
                    case SqlServer2022DbType.Char:
                    case SqlServer2022DbType.VarChar:
                    case SqlServer2022DbType.NChar:
                    case SqlServer2022DbType.NVarChar:
                        yield return new CodeBlock(SourceCodeLanguage.CSharp
                            , "metaData[{0}] = new SqlMetaData(\"{1}\", {2}, {3});"
                            , i, column.Name, column.DbType.GetDbTypeCodeBlock(), column.Length);
                        break;
                    case SqlServer2022DbType.DateTime2:
                    case SqlServer2022DbType.DateTimeOffset:
                        yield return new CodeBlock(SourceCodeLanguage.CSharp
                            , "metaData[{0}] = new SqlMetaData(\"{1}\", {2}, 0, {3});"
                            , i, column.Name, column.DbType.GetDbTypeCodeBlock(), column.Scale);
                        break;
                    case SqlServer2022DbType.Bit:
                    case SqlServer2022DbType.TinyInt:
                    case SqlServer2022DbType.SmallInt:
                    case SqlServer2022DbType.Int:
                    case SqlServer2022DbType.BigInt:
                    case SqlServer2022DbType.Image:
                    case SqlServer2022DbType.Text:
                    case SqlServer2022DbType.NText:
                    case SqlServer2022DbType.Float:
                    case SqlServer2022DbType.Real:
                    case SqlServer2022DbType.SmallDateTime:
                    case SqlServer2022DbType.DateTime:
                    case SqlServer2022DbType.Date:
                    case SqlServer2022DbType.Time:
                    case SqlServer2022DbType.UniqueIdentifier:
                    case SqlServer2022DbType.SmallMoney:
                    case SqlServer2022DbType.Money:
                    case SqlServer2022DbType.Timestamp:
                    case SqlServer2022DbType.Xml:
                    case SqlServer2022DbType.Udt:
                    case SqlServer2022DbType.Structured:
                        yield return new CodeBlock(SourceCodeLanguage.CSharp
                            , "metaData[{0}] = new SqlMetaData(\"{1}\", {2});"
                            , i, column.Name, column.DbType.GetDbTypeCodeBlock());
                        break;
                    default:
                        break;
                }
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return new SqlDataRecord(metaData);");
        }
        [Obsolete]
        private Method CreateCreateDataTableMethod()
        {
            Method md = new Method(MethodAccessModifier.Public, "CreateDataTable");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("DataTable");
            md.Body.AddRange(CreateDataTableMethodBody());
            return md;
        }
        [Obsolete]
        private IEnumerable<CodeBlock> CreateDataTableMethodBody()
        {
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var dt = new DataTable();");
            foreach (var column in this.UserDefinedTableType.Columns)
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "dt.Columns.Add(\"{0}\", typeof({1}));", column.Name, column.GetClassNameText());
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return dt;");
        }
    }
}

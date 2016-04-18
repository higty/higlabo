using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.CodeGenerator;
using System.IO;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class TableClassSourceCodeFileFactory : ClassSourceCodeFileFactory
    {
        public Table Table { get; private set; }
        public String DatabaseKey { get; private set; }

        public TableClassSourceCodeFileFactory(Table table, String databaseKey)
        {
            this.Table = table;
            this.DatabaseKey = databaseKey;
        }
        public override SourceCodeFile Create(String directoryPath, String namespaceName)
        {
            var t = this.Table;
            var sc = new SourceCode();

            sc.UsingNamespaces.Add("System");
            sc.UsingNamespaces.Add("System.Linq");
            sc.UsingNamespaces.Add("System.Data");
            sc.UsingNamespaces.Add("System.Data.Common");
            sc.UsingNamespaces.Add("System.Text");
            sc.UsingNamespaces.Add("System.Collections.Generic");
            sc.UsingNamespaces.Add("HigLabo.Data");
            sc.UsingNamespaces.Add("HigLabo.DbSharp");

            var ns = new Namespace(namespaceName);
            ns.Classes.Add(CreateClass());
            sc.Namespaces.Add(ns);

            return new SourceCodeFile(Path.Combine(directoryPath, t.Name + ".cs"), sc);
        }

        public Class CreateClass()
        {
            var t = this.Table;
            var c = new Class(AccessModifier.Public, t.Name);

            c.BaseClass = new TypeName(String.Format("Table<{0}.Record>", t.Name));
            c.Modifier.Partial = true;

            c.Fields.Add(CreateNameConstField());
            c.Properties.Add(CreateStoredProcedureNameProperty());

            c.Constructors.Add(CreateConstructor());

            c.Methods.Add(CreateCreateRecordMethod());
            c.Methods.Add(CreateSetRecordPropertyMethod());
            c.Methods.Add(CreateSetOutputParameterValueMethod());

            c.Methods.Add(CreateSelectByPrimaryKeyMethod());
            c.Methods.Add(CreateSelectByPrimaryKeyOrNullMethod());
            c.Methods.Add(CreateSelectByPrimaryKeyMethod1());
            c.Methods.Add(CreateSelectByPrimaryKeyOrNullMethod1());
            c.Methods.Add(CreateDeleteByValueMethod());
            c.Methods.Add(CreateDeleteByValueMethod1());


            c.Methods.Add(CreateCreateStoredProcedureWithResultSetMethod());
            c.Methods.Add(CreateCreateStoredProcedureMethod());
            c.Methods.Add(CreateSelectAllStoredProcedureMethod());
            c.Methods.Add(CreateSelectByPrimaryKeyStoredProcedureMethod());
            c.Methods.Add(CreateInsertStoredProcedureMethod());
            c.Methods.Add(CreateUpdateStoredProcedureMethod());
            c.Methods.Add(CreateDeleteStoredProcedureMethod());

            c.Methods.Add(CreateCreateDataTableMethod());
            c.Methods.Add(CreateSetDataRowMethod());

            return c;
        }

        public Field CreateNameConstField()
        {
            var f = new Field("String", "Name");
            f.Modifier.AccessModifier = AccessModifier.Public;
            f.Modifier.Const = true;
            f.Initializer = String.Format("\"{0}\"", this.Table.Name);
            return f;
        }
        public Property CreateStoredProcedureNameProperty()
        {
            var t = this.Table;
            var p = new Property("String", "TableName");
            p.Modifier.Polymophism = MethodPolymophism.Override;
            p.Get.Body.Add(SourceCodeLanguage.CSharp, "return {0}.Name;", t.Name);
            p.Set = null;
            return p;
        }

        public Constructor CreateConstructor()
        {
            var t = this.Table;
            Constructor ct = new Constructor(AccessModifier.Public, t.Name);

            ct.Body.Add(SourceCodeLanguage.CSharp, "((IDatabaseContext)this).DatabaseKey = \"{0}\";", this.DatabaseKey);
            return ct;
        }

        public Method CreateCreateRecordMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CreateRecord");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("Record");

            md.Body.Add(SourceCodeLanguage.CSharp, "return new Record();");

            return md;
        }
        public Method CreateSetRecordPropertyMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Protected, "SetRecordProperty");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("void");
            md.Parameters.Add(new MethodParameter("StoredProcedureResultSet", "resultSet"));
            md.Parameters.Add(new MethodParameter("Record", "record"));

            md.Body.Add(SourceCodeLanguage.CSharp, "record.SetProperty(resultSet as IRecord);");

            return md;
        }

        public Method CreateSelectByPrimaryKeyMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "SelectByPrimaryKey");
            StringBuilder sb = new StringBuilder();
            Boolean isFirst = true;

            md.ReturnTypeName = new TypeName("Record");

            foreach (var column in t.GetPrimaryKeyColumns())
            {
                var pName = this.ToCamelCase(column.Name);

                md.Parameters.Add(new MethodParameter(column.GetClassName(), pName));

                if (isFirst == false)
                {
                    sb.Append(", ");
                }
                sb.Append(pName);
                isFirst = false;
            }
            md.Body.Add(SourceCodeLanguage.CSharp, "return this.SelectByPrimaryKey(this.GetDatabase(), {0});", sb.ToString());

            return md;
        }
        public Method CreateSelectByPrimaryKeyOrNullMethod()
        {
            var t = this.Table;
            StringBuilder sb = new StringBuilder();
            Boolean isFirst = true;
            
            Method md = new Method(MethodAccessModifier.Public, "SelectByPrimaryKeyOrNull");
            md.ReturnTypeName = new TypeName("Record");

            foreach (var column in t.GetPrimaryKeyColumns())
            {
                var pName = this.ToCamelCase(column.Name);

                md.Parameters.Add(new MethodParameter(column.GetClassName(), pName));

                if (isFirst == false)
                {
                    sb.Append(", ");
                }
                sb.Append(pName);
                isFirst = false;
            }
            md.Body.Add(SourceCodeLanguage.CSharp, "return this.SelectByPrimaryKeyOrNull(this.GetDatabase(), {0});", sb.ToString());

            return md;
        }
        public Method CreateSelectByPrimaryKeyMethod1()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "SelectByPrimaryKey");
            StringBuilder sb = new StringBuilder();
            Boolean isFirst = true;

            md.ReturnTypeName = new TypeName("Record");
            md.Parameters.Add(new MethodParameter("Database", "database"));
   
            foreach (var column in t.GetPrimaryKeyColumns())
            {
                var pName = this.ToCamelCase(column.Name);

                md.Parameters.Add(new MethodParameter(column.GetClassName(), pName));

                if (isFirst == false)
                {
                    sb.Append(", ");
                }
                sb.Append(pName);
                isFirst = false;
            }
            md.Body.Add(SourceCodeLanguage.CSharp, "var r = this.SelectByPrimaryKeyOrNull(database, {0});", sb.ToString());
            md.Body.Add(SourceCodeLanguage.CSharp, "if (r == null) throw new TableRecordNotFoundException(Name, {0});", sb.ToString());
            md.Body.Add(SourceCodeLanguage.CSharp, "return r;");

            return md;
        }
        public Method CreateSelectByPrimaryKeyOrNullMethod1()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "SelectByPrimaryKeyOrNull");
            md.ReturnTypeName = new TypeName("Record");
            md.Parameters.Add(new MethodParameter("Database", "database"));

            md.Body.Add(SourceCodeLanguage.CSharp, "var sp = new {0}SelectByPrimaryKey();", t.Name);
            foreach (var column in t.GetPrimaryKeyColumns())
            {
                var pName = this.ToCamelCase(column.Name);
                md.Parameters.Add(new MethodParameter(column.GetClassName(), pName));
                md.Body.Add(SourceCodeLanguage.CSharp, "sp.PK_{0} = {1};", column.Name, pName);
            }
            md.Body.Add(SourceCodeLanguage.CSharp, "var rs = sp.GetFirstResultSet(database);", t.Name);
            md.Body.Add(SourceCodeLanguage.CSharp, "if (rs == null) return null;");
            md.Body.Add(SourceCodeLanguage.CSharp, "var r = new Record(rs);");
            md.Body.Add(SourceCodeLanguage.CSharp, "r.SetOldRecordProperty();");
            md.Body.Add(SourceCodeLanguage.CSharp, "return r;");
            return md;
        }

        public Method CreateDeleteByValueMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "Delete");
            StringBuilder sb = new StringBuilder();
            Boolean isFirst = true;
            
            md.ReturnTypeName = new TypeName("Int32");

            foreach (var column in t.GetPrimaryKeyOrTimestampColumns())
            {
                var pName = this.ToCamelCase(column.Name);

                md.Parameters.Add(new MethodParameter(column.GetClassName(), pName));
                
                if (isFirst == false)
                {
                    sb.Append(", ");
                }
                sb.Append(pName);
                isFirst = false;
            }
            md.Body.Add(SourceCodeLanguage.CSharp, "return this.Delete(this.GetDatabase(), {0});", sb.ToString());

            return md;
        }
        public Method CreateDeleteByValueMethod1()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "Delete");
            md.ReturnTypeName = new TypeName("Int32");
            md.Parameters.Add(new MethodParameter("Database", "database"));

            md.Body.Add(SourceCodeLanguage.CSharp, "var sp = new {0}Delete();", t.Name);
            md.Body.Add(SourceCodeLanguage.CSharp, "((IDatabaseContext)sp).TransactionKey = this.TransactionKey;");
            foreach (var column in t.GetPrimaryKeyOrTimestampColumns())
            {
                var pName = this.ToCamelCase(column.Name);

                md.Parameters.Add(new MethodParameter(column.GetClassName(), pName));
                md.Body.Add(SourceCodeLanguage.CSharp, "sp.PK_{0} = {1};", column.Name, pName);
            }
            md.Body.Add(SourceCodeLanguage.CSharp, "return sp.ExecuteNonQuery(database);");

            return md;
        }

        public Method CreateSetOutputParameterValueMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Protected, "SetOutputParameterValue");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.Parameters.Add(new MethodParameter("Record", "record"));
            md.Parameters.Add(new MethodParameter("StoredProcedure", "storedProcedure"));

            md.Body.AddRange(CreateSetOutputParameterValueMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateSetOutputParameterValueMethodBody()
        {
            var t = this.Table;
            CodeBlock cb = null;

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var spInsert = storedProcedure as {0}Insert;", t.Name);
            cb = new CodeBlock(SourceCodeLanguage.CSharp, "if (spInsert != null)");
            cb.CurlyBracket = true;
            foreach (var column in t.Columns.FindAll(el => el.IsServerAutomaticallyInsertValueColumn()))
            {
                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "record.{0} = spInsert.{0};", column.Name));
            }
            yield return cb;

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var spUpdate = storedProcedure as {0}Update;", t.Name);
            cb = new CodeBlock(SourceCodeLanguage.CSharp, "if (spUpdate != null)");
            cb.CurlyBracket = true;
            foreach (var column in t.Columns.FindAll(el => el.IsServerAutomaticallyInsertValueColumn()))
            {
                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "record.{0} = spUpdate.{0};", column.Name));
            }
            yield return cb;
        }

        public Method CreateCreateStoredProcedureWithResultSetMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CreateStoredProcedureWithResultSet");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("StoredProcedureWithResultSet");
            md.Parameters.Add(new MethodParameter("TableStoredProcedureTypeWithResultSet", "type"));
            md.Parameters.Add(new MethodParameter("Record", "record"));

            md.Body.AddRange(CreateCreateStoredProcedureWithResultSetMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateCreateStoredProcedureWithResultSetMethodBody()
        {
            var t = this.Table;

            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "switch (type)", t.Name);
            cb.CurlyBracket = true;
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp
                , String.Format("case TableStoredProcedureTypeWithResultSet.SelectAll: return CreateSelectAllStoredProcedure();")));
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp
                , String.Format("case TableStoredProcedureTypeWithResultSet.SelectByPrimaryKey: return this.CreateSelectByPrimaryKeyStoredProcedure(record);", t.Name)));
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "default: throw new InvalidOperationException();"));
            yield return cb;
        }
        public Method CreateCreateStoredProcedureMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CreateStoredProcedure");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("StoredProcedure");
            md.Parameters.Add(new MethodParameter("TableStoredProcedureType", "type"));
            md.Parameters.Add(new MethodParameter("Record", "record"));

            md.Body.AddRange(CreateCreateStoredProcedureMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateCreateStoredProcedureMethodBody()
        {
            var t = this.Table;

            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "switch (type)", t.Name);
            cb.CurlyBracket = true;
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp
                , String.Format("case TableStoredProcedureType.Insert: return this.CreateInsertStoredProcedure(record);", t.Name)));
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp
                , String.Format("case TableStoredProcedureType.Update: return this.CreateUpdateStoredProcedure(record);", t.Name)));
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp
                , String.Format("case TableStoredProcedureType.Delete: return this.CreateDeleteStoredProcedure(record);", t.Name)));
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "default: throw new InvalidOperationException();"));
            yield return cb;
        }

        public Method CreateSelectAllStoredProcedureMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CreateSelectAllStoredProcedure");
            md.ReturnTypeName = new TypeName(String.Format("{0}SelectAll", t.Name));

            md.Body.Add(SourceCodeLanguage.CSharp, String.Format("return new {0}SelectAll();", t.Name));

            return md;
        }
        public Method CreateSelectByPrimaryKeyStoredProcedureMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CreateSelectByPrimaryKeyStoredProcedure");
            md.ReturnTypeName = new TypeName(String.Format("{0}SelectByPrimaryKey", t.Name));
            md.Parameters.Add(new MethodParameter("Record", "record"));

            md.Body.AddRange(CreateSelectByPrimaryKeyStoredProcedureMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateSelectByPrimaryKeyStoredProcedureMethodBody()
        {
            var t = this.Table;

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var sp = new {0}SelectByPrimaryKey();", t.Name);
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "((IDatabaseContext)sp).TransactionKey = this.TransactionKey;");
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (record == null) return sp;");

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (record.OldRecord == null) throw new OldRecordIsNullException();");

            foreach (var column in t.GetPrimaryKeyColumns())
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "sp.PK_{0} = record.OldRecord.{0};", column.Name);
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return sp;");
        }
        public Method CreateInsertStoredProcedureMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CreateInsertStoredProcedure");
            md.ReturnTypeName = new TypeName(String.Format("{0}Insert", t.Name));
            md.Parameters.Add(new MethodParameter("Record", "record"));

            md.Body.AddRange(CreateInsertStoredProcedureMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateInsertStoredProcedureMethodBody()
        {
            var t = this.Table;
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var sp = new {0}Insert();", t.Name);
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "((IDatabaseContext)sp).TransactionKey = this.TransactionKey;");
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (record == null) return sp;");
       
            foreach (var column in t.Columns)
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "sp.{0} = record.{0};", column.Name);
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return sp;");
        }
        public Method CreateUpdateStoredProcedureMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CreateUpdateStoredProcedure");
            md.ReturnTypeName = new TypeName(String.Format("{0}Update", t.Name));
            md.Parameters.Add(new MethodParameter("Record", "record"));

            md.Body.AddRange(CreateUpdateStoredProcedureMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateUpdateStoredProcedureMethodBody()
        {
            var t = this.Table;

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var sp = new {0}Update();", t.Name);
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "((IDatabaseContext)sp).TransactionKey = this.TransactionKey;");
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (record == null) return sp;");

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (record.OldRecord == null) throw new OldRecordIsNullException();");

            foreach (var column in t.Columns)
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "sp.{0} = record.{0};", column.Name);
            }
            foreach (var column in t.GetPrimaryKeyOrTimestampColumns())
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "sp.PK_{0} = record.OldRecord.{0};", column.Name);
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return sp;");
        }
        public Method CreateDeleteStoredProcedureMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CreateDeleteStoredProcedure");
            md.ReturnTypeName = new TypeName(String.Format("{0}Delete", t.Name));
            md.Parameters.Add(new MethodParameter("Record", "record"));

            md.Body.AddRange(CreateDeleteStoredProcedureMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateDeleteStoredProcedureMethodBody()
        {
            var t = this.Table;

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var sp = new {0}Delete();", t.Name);
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "((IDatabaseContext)sp).TransactionKey = this.TransactionKey;");
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (record == null) return sp;");

            yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (record.OldRecord == null) throw new OldRecordIsNullException();");

            foreach (var column in t.GetPrimaryKeyOrTimestampColumns())
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "sp.PK_{0} = record.OldRecord.{0};", column.Name);
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return sp;");
        }

        public Method CreateCreateDataTableMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CreateDataTable");
            md.Modifier.AccessModifier = MethodAccessModifier.Protected;
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("DataTable");

            md.Body.Add(SourceCodeLanguage.CSharp, "var dt = new DataTable(Name);");
            foreach (var column in t.GetColumns(true, true))
            {
                md.Body.Add(SourceCodeLanguage.CSharp, "dt.Columns.Add(\"@PK_{0}\", typeof({1}));", column.Name, column.GetClassNameText());
            }
            foreach (var column in t.Columns)
            {
                md.Body.Add(SourceCodeLanguage.CSharp, "dt.Columns.Add(\"@{0}\", typeof({1}));", column.Name, column.GetClassNameText());
            }
            md.Body.Add(SourceCodeLanguage.CSharp, "return dt;");

            return md;
        }
        public Method CreateSetDataRowMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "SetDataRow");
            md.Modifier.AccessModifier = MethodAccessModifier.Protected;
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("DataRow");
            md.Parameters.Add(new MethodParameter("DataRow", "dataRow"));
            md.Parameters.Add(new MethodParameter("Record", "record"));
            md.Parameters.Add(new MethodParameter("SaveMode", "saveMode"));

            md.Body.AddRange(CreateSetDataRowMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateSetDataRowMethodBody()
        {
            var t = this.Table;

            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "if (saveMode != SaveMode.Insert)");
            cb.CurlyBracket = true;
            cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "if (record.OldRecord == null) throw new OldRecordIsNullException();"));
            foreach (var column in t.GetColumns(true, true))
            {
                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "dataRow[\"@PK_{0}\"] = GetValueOrDBNull(record.OldRecord.{0});", column.Name));
            }
            yield return cb;

            foreach (var column in t.Columns)
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "dataRow[\"@{0}\"] = GetValueOrDBNull(record.{0});", column.Name);
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return dataRow;");
        }

        private String ToCamelCase(String value)
        {
            if (String.IsNullOrEmpty(value) == true) return value;
            if (value.Length == 2) return value.ToLower();
            return value.Substring(0, 1).ToLower() + value.Substring(1, value.Length - 1);
        }
    }
}

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
    public class TableRecordClassSourceCodeFileFactory : ClassSourceCodeFileFactory
    {
        public Table Table { get; private set; }

        public TableRecordClassSourceCodeFileFactory(Table table)
        {
            this.Table = table;
        }

        public override SourceCodeFile Create(String directoryPath, String namespaceName)
        {
            var t = this.Table;
            var sc = new SourceCode();

            sc.UsingNamespaces.Add("System");
            sc.UsingNamespaces.Add("System.Data");
            sc.UsingNamespaces.Add("System.Text");
            sc.UsingNamespaces.Add("System.ComponentModel");
            sc.UsingNamespaces.Add("HigLabo.DbSharp");

            var ns = new Namespace(namespaceName);
            ns.Classes.Add(CreateClass());
            sc.Namespaces.Add(ns);

            return new SourceCodeFile(Path.Combine(directoryPath, t.Name + ".Record.cs"), sc);
        }
        public Class CreateClass()
        {
            var t = this.Table;
            var c = new Class(AccessModifier.Public, t.Name);

            c.Modifier.Partial = true;

            c.Classes.Add(this.CreateRecordClass());

            return c;
        }
        
        public Class CreateRecordClass()
        {
            var t = this.Table;
            var c = new Class(AccessModifier.Public, "Record");

            c.Modifier.Partial = true;
            c.BaseClass = new TypeName("TableRecord<Record>");
            c.ImplementInterfaces.Add(new TypeName("IRecord"));

            c.Constructors.Add(CreateDefaultConstructor());
            c.Constructors.Add(CreateConstructor());

            c.Methods.Add(CreateGetTableNameMethod());
            c.Methods.Add(new Method(MethodAccessModifier.Partial, "ConstructorExecuted"));
            c.Methods.Add(CreateSetPropertyMethod());
            c.Methods.Add(CreateSetPropertyMethod1());
            c.Methods.Add(CreateCompareAllColumnMethod());
            c.Methods.Add(CreateComparePrimaryKeyColumnMethod());
            c.Methods.Add(CreateGetValueMethod());
            c.Methods.Add(CreateSetValueMethod());
            c.Methods.Add(CreateGetColumnCountMethod());

            if (t.Columns.Exists(el => el.Name == "SaveMode") == false)
            {
                c.Properties.Add(CreateSaveModeProperty());
            }
            ClassSourceCodeFileFactory.AddPropertyAndField(c, t.Columns);

            return c;
        }

        public Method CreateGetTableNameMethod()
        {
            var t = this.Table;
            var md = new Method(MethodAccessModifier.Public, "GetTableName");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("String");
            md.Body.Add(SourceCodeLanguage.CSharp, String.Format("return \"{0}\";", t.Name)); 

            return md;
        }
        public Property CreateSaveModeProperty()
        {
            var t = this.Table;
            var p = new Property("SaveMode", "SaveMode");
            p.Get.Body.Add(SourceCodeLanguage.CSharp, "return ((ISaveMode)this).SaveMode;");
            p.Set.Body.Add(SourceCodeLanguage.CSharp, "((ISaveMode)this).SaveMode = value;");
            return p;
        }

        public Constructor CreateDefaultConstructor()
        {
            var t = this.Table;
            Constructor ct = new Constructor(AccessModifier.Public, "Record");

            ct.Body.Add(SourceCodeLanguage.CSharp, "ConstructorExecuted();");
            return ct;
        }
        public Constructor CreateConstructor()
        {
            var t = this.Table;
            Constructor ct = new Constructor(AccessModifier.Public, "Record");

            ct.Parameters.Add(new MethodParameter("IRecord", "record"));
            ct.Body.Add(SourceCodeLanguage.CSharp, "this.SetProperty(record);");
            ct.Body.Add(SourceCodeLanguage.CSharp, "ConstructorExecuted();");
            return ct;
        }

        public Method CreateSetPropertyMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "SetProperty");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.Parameters.Add(new MethodParameter("Record", "record"));
            md.ReturnTypeName = new TypeName("void");

            md.Body.Add(SourceCodeLanguage.CSharp, "this.SetProperty(record as IRecord);");
            
            return md;
        }
        public Method CreateSetPropertyMethod1()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "SetProperty");
            md.Parameters.Add(new MethodParameter("IRecord", "record"));
            md.ReturnTypeName = new TypeName("void");
            md.Body.Add(SourceCodeLanguage.CSharp, "if (record == null) throw new ArgumentNullException(\"record\");");
            md.Body.Add(SourceCodeLanguage.CSharp, "var r = record;");
            foreach (var column in t.Columns)
            {
                md.Body.Add(SourceCodeLanguage.CSharp, "this.{0} = r.{0};", column.Name);
            }
            return md;
        }
        public Method CreateCompareAllColumnMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "CompareAllColumn");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.Parameters.Add(new MethodParameter("Record", "record"));
            md.ReturnTypeName = new TypeName("Boolean");
            md.Body.Add(SourceCodeLanguage.CSharp, "if (record == null) throw new ArgumentNullException(\"record\");");
            md.Body.Add(SourceCodeLanguage.CSharp, "var r = record;");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < t.Columns.Count; i++)
            {
                var column = t.Columns[i];
                sb.Clear();
                if (i == 0)
                {
                    sb.Append("return ");
                }
                if (i < t.Columns.Count - 1)
                {
                    sb.AppendFormat("Object.Equals(this.{0}, r.{0}) && ", column.Name);
                }
                else
                {
                    sb.AppendFormat("Object.Equals(this.{0}, r.{0});", column.Name);
                }
                md.Body.Add(SourceCodeLanguage.CSharp, sb.ToString());
            }
            return md;
        }
        public Method CreateComparePrimaryKeyColumnMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "ComparePrimaryKeyColumn");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.Parameters.Add(new MethodParameter("Record", "record"));
            md.ReturnTypeName = new TypeName("Boolean");
            md.Body.Add(SourceCodeLanguage.CSharp, "if (record == null) throw new ArgumentNullException(\"record\");");
            md.Body.Add(SourceCodeLanguage.CSharp, "var r = record;");

            StringBuilder sb = new StringBuilder();
            var columns = t.GetPrimaryKeyColumns().ToList();
            for (int i = 0; i < columns.Count; i++)
            {
                var column = t.Columns[i];
                sb.Clear();
                if (i == 0)
                {
                    sb.Append("return ");
                }
                if (i < columns.Count - 1)
                {
                    sb.AppendFormat("Object.Equals(this.{0}, r.{0}) && ", column.Name);
                }
                else
                {
                    sb.AppendFormat("Object.Equals(this.{0}, r.{0});", column.Name);
                }
                md.Body.Add(SourceCodeLanguage.CSharp, sb.ToString());
            }
            return md;
        }
        public Method CreateGetValueMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "GetValue");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("Object");
            md.Parameters.Add(new MethodParameter("Int32", "index"));

            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "switch (index)");
            cb.CurlyBracket = true;
            Int32 index = 0;
            foreach (var item in t.Columns)
            {
                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "case {0}: return this.{1};", index, item.Name));
                index += 1;
            }
            md.Body.Add(cb);
            md.Body.Add(SourceCodeLanguage.CSharp, "throw new ArgumentOutOfRangeException();");

            return md;
        }
        public Method CreateSetValueMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "SetValue");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("Boolean");
            md.Parameters.Add(new MethodParameter("Int32", "index"));
            md.Parameters.Add(new MethodParameter("Object", "value"));

            var cb = new CodeBlock(SourceCodeLanguage.CSharp, "switch (index)");
            cb.CurlyBracket = true;

            Int32 index = 0;
            CodeBlock cbIf = null;
            CodeBlock cbElse = null;
            Boolean useCast = false;
            foreach (var item in t.Columns)
            {
                var tp = item.GetClassNameType();
                useCast = item.ConvertType == SqlParameterConvertType.Default &&
                    (tp == ClassNameType.Object ||
                    tp == ClassNameType.String ||
                    tp == ClassNameType.ByteArray ||
                    tp == ClassNameType.MySqlGeometry ||
                    tp == ClassNameType.Geography ||
                    tp == ClassNameType.Geometry ||
                    tp == ClassNameType.HierarchyId);

                cb.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "case {0}:", index));
                cbIf = new CodeBlock(SourceCodeLanguage.CSharp, "if (value == null)");
                cbIf.IndentLevel = 1;
                cbIf.CurlyBracket = true;
                if (item.AllowNull == true)
                {
                    cbIf.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "this.{0} = null;", item.Name));
                    cbIf.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "return true;"));
                }
                else
                {
                    cbIf.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "return false;"));
                }
                cb.CodeBlocks.Add(cbIf);

                cbElse = new CodeBlock(SourceCodeLanguage.CSharp, "else");
                cbElse.IndentLevel = 1;
                cbElse.CurlyBracket = true;

                if (useCast == true)
                {
                    if (tp.IsStructure() == true)
                    {
                        cbElse.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp
                            , "var newValue = value as {0}?;", tp.ToClassNameString()));
                    }
                    else
                    {
                        cbElse.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp
                            , "var newValue = value as {0};", item.GetClassName()));
                    }
                }
                else
                {
                    if (item.ConvertType == SqlParameterConvertType.Default)
                    {
                        cbElse.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp
                           , "var newValue = TableRecord.TypeConverter.To{0}(value);", tp));
                    }
                    else if (item.ConvertType == SqlParameterConvertType.Enum)
                    {
                        cbElse.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp
                           , "var newValue = TableRecord.TypeConverter.ToEnum<{0}>(value);", item.EnumName));
                    }
                }
                cbElse.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "if (newValue == null) return false;"));

                if (tp.IsStructure() == true ||
                    item.ConvertType == SqlParameterConvertType.Enum)
                {
                    cbElse.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "this.{0} = newValue.Value;", item.Name));
                }
                else
                {
                    cbElse.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "this.{0} = newValue;", item.Name));
                }
                cbElse.CodeBlocks.Add(new CodeBlock(SourceCodeLanguage.CSharp, "return true;"));
                cb.CodeBlocks.Add(cbElse);

                index += 1;
            }
            md.Body.Add(cb);
            md.Body.Add(SourceCodeLanguage.CSharp
                , String.Format("throw new ArgumentOutOfRangeException(\"index\", index, \"index must be 0-{0}\");"
                , t.Columns.Count - 1));

            return md;
        }
        public Method CreateGetColumnCountMethod()
        {
            var t = this.Table;
            Method md = new Method(MethodAccessModifier.Public, "GetColumnCount");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("Int32");

            md.Body.Add(SourceCodeLanguage.CSharp, "return {0};", t.Columns.Count);

            return md;
        }
    }
}

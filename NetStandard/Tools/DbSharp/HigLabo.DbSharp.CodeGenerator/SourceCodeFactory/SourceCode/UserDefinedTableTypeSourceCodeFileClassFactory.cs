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

            c.Methods.Add(CreateCreateDataTableMethod());

            return c;
        }

        private Method CreateCreateDataTableMethod()
        {
            Method md = new Method(MethodAccessModifier.Public, "CreateDataTable");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("DataTable");
            md.Body.AddRange(CreateDataTableMethodBody());
            return md;
        }
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

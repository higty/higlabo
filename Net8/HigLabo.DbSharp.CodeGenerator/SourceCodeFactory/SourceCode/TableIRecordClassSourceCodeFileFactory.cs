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
    public class TableIRecordClassSourceCodeFileFactory : ClassSourceCodeFileFactory
    {
        public Table Table { get; private set; }

        public TableIRecordClassSourceCodeFileFactory(Table table)
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
            sc.UsingNamespaces.Add("HigLabo.DbSharp");

            var ns = new Namespace(namespaceName);
            ns.Classes.Add(CreateClass());
            sc.Namespaces.Add(ns);

            return new SourceCodeFile(Path.Combine(directoryPath, t.Name + ".IRecord.cs"), sc);
        }
        public Class CreateClass()
        {
            var t = this.Table;
            var c = new Class(AccessModifier.Public, t.Name);

            c.Modifier.Partial = true;

            c.Interfaces.Add(this.CreateIRecordClass());

            return c;
        }
        
        public Interface CreateIRecordClass()
        {
            var t = this.Table;
            var c = new Interface("IRecord");

            this.AddProperty(c);

            return c;
        }
        public void AddProperty(Interface @interface)
        {
            var t = this.Table;

            foreach (var column in t.Columns)
            {
                @interface.Properties.Add(new InterfaceProperty(new TypeName(column.GetClassName()), column.GetNameWithoutAtmark(), true, true));
            }
        }
    }
}

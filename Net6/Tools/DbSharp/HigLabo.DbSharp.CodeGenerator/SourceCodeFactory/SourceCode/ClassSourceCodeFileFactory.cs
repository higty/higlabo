using HigLabo.CodeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public abstract class ClassSourceCodeFileFactory
    {
        public abstract SourceCodeFile Create(String directoryPath, String namespaceName);

        public static void AddPropertyAndField(Class @class, IEnumerable<DataType> parameters, AccessModifier? accessModifier)
        {
            var c = @class;

            foreach (var parameter in parameters)
            {
                var pName = parameter.GetNameWithoutAtmark();
                var p = new Property(parameter.GetClassName(), pName, true);
                p.Set.Modifier = accessModifier;
                if (p.TypeName.Name == "String")
                {
                    if (parameter.AllowNull)
                    {
                        p.Initializer = "null";
                    }
                    else
                    {
                        p.Initializer = "\"\"";
                    }
                }
                else if (parameter.DbType.IsUserDefinedTableType() == true)
                {
                    p.Initializer = String.Format("new {0}()", parameter.GetClassName());
                }
                c.Properties.Add(p);
            }
        }
    }
}

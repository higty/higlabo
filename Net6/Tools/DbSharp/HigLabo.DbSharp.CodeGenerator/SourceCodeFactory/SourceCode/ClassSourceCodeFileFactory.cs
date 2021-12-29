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
                var f = new Field(parameter.GetClassName(), "_" + pName);
                if (f.TypeName.Name == "String")
                {
                    if (parameter.AllowNull)
                    {
                        f.Initializer = "null";
                    }
                    else
                    {
                        f.Initializer = "\"\"";
                    }
                }
                else if (parameter.DbType.IsUserDefinedTableType() == true)
                {
                    f.Initializer = String.Format("new {0}()", parameter.GetClassName());
                }
                c.Fields.Add(f);

                var p = new Property(parameter.GetClassName(), pName);
                p.Get.Body.Add(SourceCodeLanguage.CSharp, "return _{0};", pName);

                if (f.TypeName.Name == "String" && parameter.AllowNull == false)
                {
                    p.Set.Body.Add(SourceCodeLanguage.CSharp, "_{0} = value ?? \"\";", pName);
                }
                else
                {
                    p.Set.Body.Add(SourceCodeLanguage.CSharp, "_{0} = value;", pName);
                }

                c.Properties.Add(p);
            }
        }
    }
}

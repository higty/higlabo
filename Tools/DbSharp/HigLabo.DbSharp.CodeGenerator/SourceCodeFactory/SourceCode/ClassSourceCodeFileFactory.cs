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

        public static void AddPropertyAndField(Class @class, IEnumerable<DataType> parameters)
        {
            var c = @class;
            Property p = null;
            Field f = null;
            String pName = "";

            foreach (var parameter in parameters)
            {
                pName = parameter.GetNameWithoutAtmark();
                f = new Field(parameter.GetClassName(), "_" + pName);
                if (f.TypeName.Name == "String")
                {
                    f.Initializer = "null";
                }
                else if (parameter.DbType.IsUserDefinedTableType() == true)
                {
                    f.Initializer = String.Format("new {0}()", parameter.GetClassName());
                }
                c.Fields.Add(f);

                p = new Property(parameter.GetClassName(), pName);
                p.Get.Body.Add(SourceCodeLanguage.CSharp, "return _{0};", pName);

                if (f.TypeName.Name == "String" &&
                    parameter.AllowNull == false)
                {
                    p.Set.Body.Add(SourceCodeLanguage.CSharp, "this.SetPropertyValue(ref _{0}, value ?? \"\", this.GetPropertyChangedEventHandler());", pName);
                }
                else
                {
                    p.Set.Body.Add(SourceCodeLanguage.CSharp, "this.SetPropertyValue(ref _{0}, value, this.GetPropertyChangedEventHandler());", pName);
                }

                c.Properties.Add(p);
            }
        }
    }
}

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
    public class UserDefinedTableTypeRecordClassFactory 
    {
        public UserDefinedTableType UserDefinedTableType { get; private set; }
        public UserDefinedTableTypeRecordClassFactory(UserDefinedTableType userDefinedTableType)
        {
            this.UserDefinedTableType = userDefinedTableType;
        }
        public Class CreateClass()
        {
            Class c = new Class(AccessModifier.Public, "Record");

            c.Modifier.Partial = true;
            c.BaseClass = new TypeName("UserDefinedTableTypeRecord");

            ClassSourceCodeFileFactory.AddPropertyAndField(c, this.UserDefinedTableType.Columns);

            c.Constructors.Add(new Constructor(AccessModifier.Public, "Record"));
            c.Methods.Add(this.CreateGetValuesMethod());

            return c;
        }
        private Method CreateGetValuesMethod()
        {
            Method md = new Method(MethodAccessModifier.Public, "GetValues");

            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.ReturnTypeName = new TypeName("Object[]");
            md.Body.AddRange(this.CreateGetValuesMethodBody());

            return md;
        }
        private IEnumerable<CodeBlock> CreateGetValuesMethodBody()
        {
            var t = this.UserDefinedTableType;
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "Object[] oo = new Object[{0}];", t.Columns.Count);
            for (int i = 0; i < t.Columns.Count; i++)
            {
                var column = t.Columns[i];
                if (column.ConvertType == SqlParameterConvertType.Enum)
                {
                    if (column.AllowNull == true)
                    {
                        yield return new CodeBlock(SourceCodeLanguage.CSharp, "if (this.{1} != null) oo[{0}] = this.{1}.ToString();", i, t.Columns[i].Name);
                    }
                    else
                    {
                        yield return new CodeBlock(SourceCodeLanguage.CSharp, "oo[{0}] = this.{1}.ToString();", i, t.Columns[i].Name);
                    }
                }
                else
                {
                    yield return new CodeBlock(SourceCodeLanguage.CSharp, "oo[{0}] = this.{1};", i, t.Columns[i].Name);
                }
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return oo;");
        }
    }
}

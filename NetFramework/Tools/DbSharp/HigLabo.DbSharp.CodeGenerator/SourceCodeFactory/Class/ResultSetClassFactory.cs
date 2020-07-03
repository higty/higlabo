using HigLabo.CodeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class ResultSetClassFactory 
    {
        public String StoredProcedureName { get; private set; }
        public StoredProcedureType StoredProcedureType { get; private set; }
        public StoredProcedureResultSetColumn ResultSet { get; set; }
        public ResultSetClassFactory(String storedProcedureName, StoredProcedureType storedProcedureType, StoredProcedureResultSetColumn resultSet)
        {
            this.StoredProcedureName = storedProcedureName;
            this.StoredProcedureType = storedProcedureType;
            this.ResultSet = resultSet;
        }
        public Class CreateClass()
        {
            Class c = new Class(AccessModifier.Public, this.ResultSet.Name);

            c.Modifier.Partial = true;
            c.BaseClass = new TypeName(String.Format("StoredProcedureResultSet", this.StoredProcedureName));
            if (String.IsNullOrEmpty(this.ResultSet.TableName) == false)
            {
                c.ImplementInterfaces.Add(new TypeName(this.ResultSet.TableName + ".IRecord"));
            }

            ClassSourceCodeFileFactory.AddPropertyAndField(c, this.ResultSet.Columns);

            c.Constructors.Add(new Constructor(AccessModifier.Public, this.ResultSet.Name));
            c.Constructors.Add(CreateResultSetConstructor());
            c.Constructors.Add(CreateResultSetConstructorWithStoredProcedure());

            c.Methods.Add(CreateResultSetToStringMethod());

            return c;
        }
        
        public Constructor CreateResultSetConstructor()
        {
            Constructor ct = new Constructor(AccessModifier.Public, this.ResultSet.Name);

            if (String.IsNullOrEmpty(this.ResultSet.TableName) == false)
            {
                if (this.StoredProcedureType == StoredProcedureType.SelectAll ||
                    this.StoredProcedureType == StoredProcedureType.SelectByPrimaryKey)
                {
                    ct.AddParameter(this.ResultSet.TableName + ".IRecord", "resultSet");
                }
                else
                {
                    ct.AddParameter(this.ResultSet.Name, "resultSet");
                }
            }
            else
            {
                ct.AddParameter(this.ResultSet.Name, "resultSet");
            }

            ct.Body.Add(SourceCodeLanguage.CSharp, "var r = resultSet;");
            foreach (var parameter in this.ResultSet.Columns)
            {
                ct.Body.Add(SourceCodeLanguage.CSharp, String.Format("{0} = r.{0};", parameter.Name));
            }
            return ct;
        }
        public Constructor CreateResultSetConstructorWithStoredProcedure()
        {
            Constructor ct = new Constructor(AccessModifier.Internal, this.ResultSet.Name);

            ct.AddParameter(this.StoredProcedureName, "storedProcedure");

            ct.Body.Add(SourceCodeLanguage.CSharp, "this._StoredProcedureResultSet_StoredProcedure = storedProcedure;");

            return ct;
        }

        public Method CreateResultSetToStringMethod()
        {
            Method md = new Method(MethodAccessModifier.Public, "ToString");
            md.ReturnTypeName = new TypeName("String");
            md.Modifier.Polymophism = MethodPolymophism.Override;
            md.Body.AddRange(CreateResultSetToStringMethodBody());

            return md;
        }
        public IEnumerable<CodeBlock> CreateResultSetToStringMethodBody()
        {
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "var sb = new StringBuilder(64);");
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "sb.AppendLine(\"<{0}.{1}>\");", this.StoredProcedureName, this.ResultSet.Name);

            foreach (var parameter in this.ResultSet.Columns)
            {
                yield return new CodeBlock(SourceCodeLanguage.CSharp, "sb.AppendFormat(\"{0}={1}\", this.{0}); sb.AppendLine();", parameter.Name, "{0}");
            }
            yield return new CodeBlock(SourceCodeLanguage.CSharp, "return sb.ToString();");
        }
    }
}

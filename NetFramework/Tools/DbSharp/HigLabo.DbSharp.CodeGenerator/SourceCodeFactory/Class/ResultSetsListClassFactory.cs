using HigLabo.CodeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class ResultSetsListClassFactory 
    {
        public StoredProcedure StoredProcedure { get; private set; }
        public ResultSetsListClassFactory(StoredProcedure storedProcedure)
        {
            this.StoredProcedure = storedProcedure;
        }
        public Class CreateClass()
        {
            Class c = new Class(AccessModifier.Public, "ResultSetsList");

            c.Modifier.Partial = true;

            c.Constructors.Add(new Constructor(AccessModifier.Public, "ResultSetsList"));

            foreach (var item in this.StoredProcedure.ResultSets)
            {
                AddResultSetsXPropertyAndField(c, item);
            }

            return c;
        }
        private void AddResultSetsXPropertyAndField(Class @class, StoredProcedureResultSetColumn resultSet)
        {
            var c = @class;
            var rs = resultSet;
            var f = new Field(String.Format("List<{0}>", rs.Name), String.Format("_{0}List", rs.Name));
            f.Initializer = String.Format("new {0}()", f.TypeName.Name);
            c.Fields.Add(f);

            var p = new Property(f.TypeName, rs.Name + "List");
            p.Get.Body.Add(SourceCodeLanguage.CSharp, String.Format("return {0};", f.Name));

            p.Set = null;

            c.Properties.Add(p);
        }

    }
}

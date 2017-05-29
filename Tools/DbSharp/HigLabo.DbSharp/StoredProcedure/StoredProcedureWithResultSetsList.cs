using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public abstract class StoredProcedureWithResultSetsList<T, TResultSetList> : StoredProcedureWithResultSet<T>
        where T: StoredProcedureResultSet, new()
    {
        protected Func<Database, TResultSetList> _GetResultSetsListMethod = null;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databases"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TResultSetList>> GetResultSetsList(IEnumerable<Database> databases)
        {
            var tt = new List<Task<TResultSetList>>();
            foreach (var db in databases)
            {
                var task = Task.Factory.StartNew<TResultSetList>(() =>
                {
                    return _GetResultSetsListMethod(db);
                });
                tt.Add(task);
            }
            var results = await Task.WhenAll(tt);
            return results;
        }
    }
}

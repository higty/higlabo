using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;

namespace HigLabo.DbSharp
{
    public static class DatabaseExtensions
    {
        public static Int32 Execute(this Database database, StoredProcedure storedProcedure)
        {
            return storedProcedure.ExecuteNonQuery(database);
        }
        public static async ValueTask<List<T>> GetResultSetsAsync<T>(this Database database, StoredProcedureWithResultSet<T> storedProcedure)
            where T : StoredProcedureResultSet, new()
        {
            return await storedProcedure.GetResultSetsAsync(database);
        }   
    }
}

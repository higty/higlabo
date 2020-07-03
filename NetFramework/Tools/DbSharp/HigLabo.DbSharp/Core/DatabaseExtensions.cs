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
        public static List<T> GetResultSets<T>(this Database database, StoredProcedureWithResultSet<T> storedProcedure)
            where T : StoredProcedureResultSet, new()
        {
            return storedProcedure.GetResultSets(database);
        }
        public static List<TableRecord> SelectAll<T>(this Database database, T table)
            where T : ITable
        {
            return table.SelectAllRecords(database);
        }
        public static TableRecord SelectByPrimaryKey<T>(this Database database, T table, TableRecord record)
            where T : ITable
        {
            return table.SelectByPrimaryKey(database, record);
        }
        public static Int32 Insert<T>(this Database database, T table, TableRecord record)
            where T : ITable
        {
            return table.Insert(database, record);
        }
        public static Int32 Insert<T>(this Database database, T table, IEnumerable<TableRecord> records)
            where T : ITable
        {
            return table.Insert(database, records);
        }
        public static Int32 Update<T>(this Database database, T table, TableRecord record)
            where T : ITable
        {
            return table.Update(database, record);
        }
        public static Int32 Update<T>(this Database database, T table, IEnumerable<TableRecord> records)
         where T : ITable
        {
            return table.Update(database, records);
        }
        public static Int32 Delete<T>(this Database database, T table, TableRecord record)
            where T : ITable
        {
            return table.Delete(database, record);
        }
        public static Int32 Delete<T>(this Database database, T table, IEnumerable<TableRecord> records)
           where T : ITable
        {
            return table.Delete(database, records);
        }
    }
}

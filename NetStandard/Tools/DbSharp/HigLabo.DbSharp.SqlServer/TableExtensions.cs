using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public static class TableExtensions
    {
        public static SqlBulkCopyContext CreateBulkCopyContext<T>(this Table<T> table, SqlBulkCopyOptions copyOptions = SqlBulkCopyOptions.Default)
            where T : TableRecord, new()
        {
            var db = GetSqlServerDatabase(table);
            var context = db.CreateSqlBulkCopyContext(copyOptions);
            context.SqlBulkCopy.DestinationTableName = table.TableName;
            return context;
        }
        public static void BulkCopy<T>(this Table<T> table, IEnumerable<T> records)
            where T : TableRecord, new()
        {
            table.BulkCopy(table.CreateBulkCopyContext(), records);
        }
        public static void BulkCopy<T>(this Table<T> table, SqlBulkCopyContext context, IEnumerable<T> records)
            where T : TableRecord, new()
        {
            var db = GetSqlServerDatabase(table);
            var startTime = DateTimeOffset.Now;
            db.BulkCopy(context, new TableRecordReader(records));
            var endTime = DateTimeOffset.Now;
            //fire event
        }
        private static SqlServerDatabase GetSqlServerDatabase<T>(Table<T> table)
            where T : TableRecord, new()
        {
            var db = table.GetDatabase() as SqlServerDatabase;
            if (db == null) throw new InvalidOperationException("Database is not SqlServer");
            return db;
        }
    }
}

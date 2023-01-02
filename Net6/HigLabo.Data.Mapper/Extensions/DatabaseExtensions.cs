using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using HigLabo.Core;

namespace HigLabo.Data
{
    public static class DatabaseExtensions
    {
        public static async Task<T?> GetRecordAsync<T>(this Database database, String query)
            where T : class, new()
        {
            return await GetRecordAsync(database, query, () => new T(), CommandBehavior.Default, CancellationToken.None);
        }
        public static async Task<T?> GetRecordAsync<T>(this Database database, String query, Func<T> constructor)
            where T : class
        {
            return await GetRecordAsync(database, query, constructor, CommandBehavior.Default, CancellationToken.None);
        }
        public static async Task<T?> GetRecordAsync<T>(this Database database, String query
            , CommandBehavior commandBehavior, CancellationToken cancellationToken)
            where T : class, new()
        {
            return await GetRecordAsync(database, query, () => new T(), commandBehavior, cancellationToken);
        }
        public static async Task<T?> GetRecordAsync<T>(this Database database, String query, Func<T> constructor
            , CommandBehavior commandBehavior, CancellationToken cancellationToken)
            where T: class
        {
            var cm = database.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            var l = await GetRecordListAsync(database, cm, constructor, commandBehavior, cancellationToken);
            if (l.Count == 0) { return null; }
            return l[0];
        }

        public static async Task<List<T>> GetRecordListAsync<T>(this Database database, String query)
            where T : class, new()
        {
            var cm = database.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return await GetRecordListAsync(database, cm, () => new T(), CommandBehavior.Default, CancellationToken.None);
        }
        public static async Task<List<T>> GetRecordListAsync<T>(this Database database, String query, Func<T> constructor)
        {
            var cm = database.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return await GetRecordListAsync(database, cm, constructor, CommandBehavior.Default, CancellationToken.None);
        }
        public static async Task<List<T>> GetRecordListAsync<T>(this Database database, DbCommand command
            , CommandBehavior commandBehavior, CancellationToken cancellationToken)
            where T : class, new()
        {
            return await GetRecordListAsync(database, command, () => new T(), commandBehavior, cancellationToken);
        }
        public static async Task<List<T>> GetRecordListAsync<T>(this Database database, DbCommand command, Func<T> constructor
            , CommandBehavior commandBehavior, CancellationToken cancellationToken)
        {
            var l = new List<T>();
            var db = database;
            var dr = await db.ExecuteReaderAsync(command, commandBehavior, cancellationToken);
            var d = new Dictionary<String, Object>();
            while (dr.Read())
            {
                d.Clear();
                dr.SetToDisctionary(d);
                var r = d.Map(constructor());
                l.Add(r);
            }
            return l;
        }
    }
}

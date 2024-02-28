using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using HigLabo.Core;

namespace HigLabo.Data
{
    public static class DatabaseExtensions
    {
        public static async ValueTask<T?> GetRecordAsync<T>(this Database database, String query)
            where T : class, new()
        {
            var cm = database.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return await GetRecordAsync(database, cm, () => new T(), CommandBehavior.Default, CancellationToken.None);
        }
        public static async ValueTask<T?> GetRecordAsync<T>(this Database database, String query, Func<T> constructor)
            where T : class
        {
            var cm = database.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return await GetRecordAsync(database, cm, constructor, CommandBehavior.Default, CancellationToken.None);
        }
        public static async ValueTask<T?> GetRecordAsync<T>(this Database database, DbCommand command)
           where T : class, new()
        {
            return await GetRecordAsync<T>(database, command, CommandBehavior.Default, CancellationToken.None);
        }
        public static async ValueTask<T?> GetRecordAsync<T>(this Database database, DbCommand command, Func<T> constructor)
            where T : class
        {
            return await GetRecordAsync<T>(database, command, constructor, CommandBehavior.Default, CancellationToken.None);
        }
        public static async ValueTask<T?> GetRecordAsync<T>(this Database database, DbCommand command
            , CommandBehavior commandBehavior, CancellationToken cancellationToken)
            where T : class, new()
        {
            return await GetRecordAsync(database, command, () => new T(), commandBehavior, cancellationToken);
        }
        public static async ValueTask<T?> GetRecordAsync<T>(this Database database, DbCommand command, Func<T> constructor
            , CommandBehavior commandBehavior, CancellationToken cancellationToken)
            where T: class
        {
            var l = await GetRecordListAsync(database, command, constructor, commandBehavior, cancellationToken);
            if (l.Count == 0) { return null; }
            return l[0];
        }

        public static async ValueTask<List<T>> GetRecordListAsync<T>(this Database database, String query)
            where T : class, new()
        {
            var cm = database.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return await GetRecordListAsync(database, cm, () => new T(), CommandBehavior.Default, CancellationToken.None);
        }
        public static async ValueTask<List<T>> GetRecordListAsync<T>(this Database database, String query, Func<T> constructor)
        {
            var cm = database.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return await GetRecordListAsync(database, cm, constructor, CommandBehavior.Default, CancellationToken.None);
        }
        public static async ValueTask<List<T>> GetRecordListAsync<T>(this Database database, DbCommand command)
               where T : class, new()
        {
            return await GetRecordListAsync<T>(database, command, CommandBehavior.Default, CancellationToken.None);
        }
        public static async ValueTask<List<T>> GetRecordListAsync<T>(this Database database, DbCommand command, Func<T> constructor)
        {
            return await GetRecordListAsync(database, command, constructor, CommandBehavior.Default, CancellationToken.None);
        }

        public static async ValueTask<List<T>> GetRecordListAsync<T>(this Database database, DbCommand command
            , CommandBehavior commandBehavior, CancellationToken cancellationToken)
            where T : class, new()
        {
            return await GetRecordListAsync(database, command, () => new T(), commandBehavior, cancellationToken);
        }
        public static async ValueTask<List<T>> GetRecordListAsync<T>(this Database database, DbCommand command, Func<T> constructor
            , CommandBehavior commandBehavior, CancellationToken cancellationToken)
        {
            var l = new List<T>();
            var db = database;
            var dr = await db.ExecuteReaderAsync(command, commandBehavior, cancellationToken);
            var d = new Dictionary<String, Object>(StringComparer.OrdinalIgnoreCase);
            while (await dr!.ReadAsync())
            {
                d.Clear();
                dr.SetToDictionary(d);
                var r = d.Map(constructor());
                l.Add(r);
            }
            return l;
        }


        public static async IAsyncEnumerable<T> EnumerateRecordListAsync<T>(this Database database, string query)
           where T : new()
        {
            var cm = database.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            await foreach (var item in EnumerateRecordListAsync<T>(database, cm, CommandBehavior.Default, CancellationToken.None))
            {
                yield return item;
            }
        }
        public static async IAsyncEnumerable<T> EnumerateRecordListAsync<T>(this Database database, string query, Func<T> constructor)
        {
            var cm = database.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            await foreach (var item in EnumerateRecordListAsync<T>(database, cm, constructor, CommandBehavior.Default, CancellationToken.None))
            {
                yield return item;
            }
        }
        public static async IAsyncEnumerable<T> EnumerateRecordListAsync<T>(this Database database, DbCommand command)
            where T :  new()
        {
            await foreach (var item in EnumerateRecordListAsync<T>(database, command, CommandBehavior.Default, CancellationToken.None))
            {
                yield return item;
            }
        }
        public static async IAsyncEnumerable<T> EnumerateRecordListAsync<T>(this Database database, DbCommand command, Func<T> constructor)
        {
            await foreach (var item in EnumerateRecordListAsync<T>(database, command, constructor, CommandBehavior.Default, CancellationToken.None))
            {
                yield return item;
            }
        }
        public static async IAsyncEnumerable<T> EnumerateRecordListAsync<T>(this Database database, DbCommand command
            , CommandBehavior commandBehavior, [EnumeratorCancellation] CancellationToken cancellationToken)
              where T : new()
        {
            await foreach (var item in EnumerateRecordListAsync<T>(database, command, () => new T(), commandBehavior, cancellationToken))
            {
                yield return item;
            }
        }
        public static async IAsyncEnumerable<T> EnumerateRecordListAsync<T>(this Database database, DbCommand command, Func<T> constructor
            , CommandBehavior commandBehavior, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var db = database;
            var dr = await db.ExecuteReaderAsync(command, commandBehavior, cancellationToken);
            var d = new Dictionary<String, Object>(StringComparer.OrdinalIgnoreCase);
            while (await dr!.ReadAsync())
            {
                d.Clear();
                dr.SetToDictionary(d);
                var r = d.Map(constructor());
                yield return r;
            }
        }
    }
}

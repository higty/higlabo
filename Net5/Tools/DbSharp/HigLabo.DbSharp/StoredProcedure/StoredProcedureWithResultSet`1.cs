using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using HigLabo.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Threading;

namespace HigLabo.DbSharp
{
    public abstract class StoredProcedureWithResultSet<T> : StoredProcedureWithResultSet
        where T : StoredProcedureResultSet, new()
    {
        protected abstract void SetResultSet(T resultSet, IDataReader reader);
        public abstract T CreateResultSet();
        protected override StoredProcedureResultSet CreateResultSets(IDataReader reader)
        {
            var rs = this.CreateResultSet();
            SetResultSet(rs, reader);
            return rs;
        }

        public new T GetFirstResultSet()
        {
            return base.GetFirstResultSet() as T;
        }
        public new T GetFirstResultSet(Database database)
        {
            return base.GetFirstResultSet(database) as T;
        }
        public new T GetFirstResultSet(IEnumerable<Database> databases)
        {
            var results = this.GetResultSets(databases);
            return results.FirstOrDefault() as T;
        }
        public new async Task<T> GetFirstResultSetAsync()
        {
            return await this.GetFirstResultSetAsync(this.GetDatabase()).ConfigureAwait(false);
        }
        public new async Task<T> GetFirstResultSetAsync(Database database)
        {
            return await this.GetFirstResultSetAsync(database, CancellationToken.None);
        }
        public new async Task<T> GetFirstResultSetAsync(Database database, CancellationToken cancellationToken)
        {
            return (await this.GetResultSetsAsync(database, cancellationToken)).FirstOrDefault() as T;
        }
        public new async Task<T> GetFirstResultSetAsync(IEnumerable<Database> databases)
        {
            return await this.GetFirstResultSetAsync(databases, CancellationToken.None);
        }
        public new async Task<T> GetFirstResultSetAsync(IEnumerable<Database> databases, CancellationToken cancellationToken)
        {
            var results = await this.GetResultSetsAsync(databases, cancellationToken).ConfigureAwait(false);
            return results.FirstOrDefault() as T;
        }

        public new List<T> GetResultSets()
        {
            return EnumerateResultSets().ToList();
        }
        public new List<T> GetResultSets(Database database)
        {
            return EnumerateResultSets(database).ToList();
        }
        public new List<T> GetResultSets(IEnumerable<Database> databases)
        {
            return base.GetResultSets(databases).Cast<T>().ToList();
        }
        public new async Task<List<T>> GetResultSetsAsync()
        {
            return await GetResultSetsAsync(this.GetDatabase()).ConfigureAwait(false);
        }
        public new async Task<List<T>> GetResultSetsAsync(Database database)
        {
            return await this.GetResultSetsAsync(database, CancellationToken.None);
        }
        public new async Task<List<T>> GetResultSetsAsync(Database database, CancellationToken cancellationToken)
        {
            var l = new List<T>();
            foreach (var item in await base.GetResultSetsAsync(database, cancellationToken).ConfigureAwait(false))
            {
                l.Add(item as T);
            }
            return l;
        }
        public new async Task<IEnumerable<T>> GetResultSetsAsync(IEnumerable<Database> databases)
        {
            return await this.GetResultSetsAsync(databases, CancellationToken.None);
        }
        public new async Task<IEnumerable<T>> GetResultSetsAsync(IEnumerable<Database> databases, CancellationToken cancellationToken)
        {
            var l = new List<T>();
            foreach (var item in await base.GetResultSetsAsync(databases, cancellationToken).ConfigureAwait(false))
            {
                l.Add(item as T);
            }
            return l;
        }

 
        public new IEnumerable<T> EnumerateResultSets()
        {
            return base.EnumerateResultSets().Cast<T>();
        }
        public new IEnumerable<T> EnumerateResultSets(Database database)
        {
            return base.EnumerateResultSets(database).Cast<T>();
        }

        public List<TResult> GetResultSets<TResult>(Func<T, TResult> selector)
        {
            return this.EnumerateResultSets().Select(selector).ToList();
        }
        public List<TResult> GetResultSets<TResult>(Database database, Func<T, TResult> selector)
        {
            return this.EnumerateResultSets(database).Select(selector).ToList();
        }
        public IEnumerable<TResult> EnumerateResultSets<TResult>(Func<T, TResult> selector)
        {
            return this.EnumerateResultSets().Select(selector);
        }
        public IEnumerable<TResult> EnumerateResultSets<TResult>(Database database, Func<T, TResult> selector)
        {
            return this.EnumerateResultSets(database).Select(selector);
        }
        protected Func<DbDataReader, StoredProcedureResultSet> CreateCreateResultSetMethod<TResultSet>(Action<TResultSet, DbDataReader> setResultSetMethod)
            where TResultSet : StoredProcedureResultSet, new()
        {
            return dr =>
            {
                var rs = new TResultSet();
                setResultSetMethod(rs, dr);
                return rs;
            };
        }
    }
}

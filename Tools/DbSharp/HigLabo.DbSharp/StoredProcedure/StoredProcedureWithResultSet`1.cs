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

namespace HigLabo.DbSharp
{
    public abstract class StoredProcedureWithResultSet<T> : StoredProcedureWithResultSet
        where T : StoredProcedureResultSet, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultSet"></param>
        /// <param name="reader"></param>
        protected abstract void SetResultSet(T resultSet, IDataReader reader);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract T CreateResultSet();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override StoredProcedureResultSet CreateResultSets(IDataReader reader)
        {
            var rs = this.CreateResultSet();
            SetResultSet(rs, reader);
            return rs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new T GetFirstResultSet()
        {
            return base.GetFirstResultSet() as T;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public new T GetFirstResultSet(Database database)
        {
            return base.GetFirstResultSet(database) as T;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public new async Task<T> GetFirstResultSetAsync(Database database)
        {
            return (await this.GetResultSetsAsync(database)).FirstOrDefault() as T;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        /// <returns></returns>
        public new async Task<T> GetFirstResultSetAsync(IEnumerable<Database> databases)
        {
            var results = await this.GetResultSetsAsync(databases);
            return results.FirstOrDefault() as T;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new List<T> GetResultSets()
        {
            return EnumerateResultSets().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public new List<T> GetResultSets(Database database)
        {
            return EnumerateResultSets(database).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        /// <returns></returns>
        public new List<T> GetResultSets(IEnumerable<Database> databases)
        {
            return base.GetResultSets(databases).Cast<T>().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new async Task<List<T>> GetResultSetsAsync()
        {
            return await GetResultSetsAsync(this.GetDatabase());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public new async Task<List<T>> GetResultSetsAsync(Database database)
        {
            var l = new List<T>();
            foreach (var item in await base.GetResultSetsAsync(database))
            {
                l.Add(item as T);
            }
            return l;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        /// <returns></returns>
        public new async Task<IEnumerable<T>> GetResultSetsAsync(IEnumerable<Database> databases)
        {
            var l = new List<T>();
            foreach (var item in await base.GetResultSetsAsync(databases))
            {
                l.Add(item as T);
            }
            return l;
        }

 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new IEnumerable<T> EnumerateResultSets()
        {
            return base.EnumerateResultSets().Cast<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public new IEnumerable<T> EnumerateResultSets(Database database)
        {
            return base.EnumerateResultSets(database).Cast<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public List<TResult> GetResultSets<TResult>(Func<T, TResult> selector)
        {
            return this.EnumerateResultSets().Select(selector).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="database"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public List<TResult> GetResultSets<TResult>(Database database, Func<T, TResult> selector)
        {
            return this.EnumerateResultSets(database).Select(selector).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public IEnumerable<TResult> EnumerateResultSets<TResult>(Func<T, TResult> selector)
        {
            return this.EnumerateResultSets().Select(selector);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="database"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public IEnumerable<TResult> EnumerateResultSets<TResult>(Database database, Func<T, TResult> selector)
        {
            return this.EnumerateResultSets(database).Select(selector);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="ResultSet"></typeparam>
        /// <param name="setResultSetMethod"></param>
        /// <returns></returns>
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

using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public abstract class StoredProcedureWithResultSetsList<T, TResultSetList> : StoredProcedureWithResultSet<T>
        where T: StoredProcedureResultSet, new()
        where TResultSetList: new()
    {
        protected static Action<TResultSetList, TResultSetList> _MergeMethod;
        protected List<Func<DbDataReader, StoredProcedureResultSet>> _CreateResultSetMethodList = new List<Func<DbDataReader, StoredProcedureResultSet>>();

        protected abstract void SetResultSetsList(TResultSetList resultSetList, List<List<StoredProcedureResultSet>> list);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TResultSetList GetResultSetsList()
        {
            return this.GetResultSetsList(this.GetDatabase());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public TResultSetList GetResultSetsList(Database database)
        {
            var rsl = new TResultSetList();
            List<List<StoredProcedureResultSet>> l = new List<List<StoredProcedureResultSet>>();
            DbDataReader dr = null;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand(database);
                dr = database.ExecuteReader(cm);
                Int32 index = 0;
                while (true)
                {
                    l.Add(new List<StoredProcedureResultSet>());
                    while (dr.Read())
                    {
                        var rs = _CreateResultSetMethodList[index](dr);
                        l[index].Add(rs);
                    }
                    index += 1;
                    if (dr.NextResult() == false) break;
                }
                dr.Close();
                this.SetOutputParameterValue(cm);
            }
            finally
            {
                if (dr != null) { dr.Dispose(); }
                if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
                if (database.OnTransaction == false) { database.Dispose(); }
            }
            this.SetResultSetsList(rsl, l);
            return rsl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        /// <returns></returns>
        public TResultSetList GetResultSetsList(IEnumerable<Database> databases)
        {
            return this.GetResultSetsListAsync(databases).GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<TResultSetList> GetResultSetsListAsync()
        {
            return await this.GetResultSetsListAsync(this.GetDatabase()).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public async Task<TResultSetList> GetResultSetsListAsync(Database database)
        {
            var rsl = new TResultSetList();
            List<List<StoredProcedureResultSet>> l = new List<List<StoredProcedureResultSet>>();
            DbDataReader dr = null;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand(database);
                dr = await database.ExecuteReaderAsync(cm).ConfigureAwait(false);
                Int32 index = 0;
                while (true)
                {
                    l.Add(new List<StoredProcedureResultSet>());
                    while (dr.Read())
                    {
                        var rs = _CreateResultSetMethodList[index](dr);
                        l[index].Add(rs);
                    }
                    index += 1;
                    if (dr.NextResult() == false) break;
                }
                dr.Close();
                this.SetOutputParameterValue(cm);
            }
            finally
            {
                if (dr != null) { dr.Dispose(); }
                if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
                if (database.OnTransaction == false) { database.Dispose(); }
            }
            this.SetResultSetsList(rsl, l);
            return rsl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databases"></param>
        /// <returns></returns>
        public async Task<TResultSetList> GetResultSetsListAsync(IEnumerable<Database> databases)
        {
            var tt = new List<Task<TResultSetList>>();
            foreach (var db in databases)
            {
                tt.Add(this.GetResultSetsListAsync(db));
            }
            var result = new TResultSetList();
            foreach (var item in await Task.WhenAll(tt).ConfigureAwait(false))
            {
                _MergeMethod(item, result);
            }
            return result;
        }
    }
}

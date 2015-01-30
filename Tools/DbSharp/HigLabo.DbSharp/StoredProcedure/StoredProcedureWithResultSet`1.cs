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
        /// <param name="database"></param>
        /// <param name="createReulstSetMethodList"></param>
        /// <returns></returns>
        protected List<List<StoredProcedureResultSet>> GetResultSetsList(Database database, params Func<DbDataReader, StoredProcedureResultSet>[] createReulstSetMethodList)
        {
            List<List<StoredProcedureResultSet>> l = new List<List<StoredProcedureResultSet>>();
            DbDataReader dr = null;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand();
                dr = database.ExecuteReader(cm);
                Int32 index = 0;
                while (true)
                {
                    l.Add(new List<StoredProcedureResultSet>());
                    while (dr.Read())
                    {
                        var rs = createReulstSetMethodList[index](dr);
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
            return l;
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

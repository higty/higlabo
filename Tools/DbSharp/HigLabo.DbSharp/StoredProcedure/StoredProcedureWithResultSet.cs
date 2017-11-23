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
    public abstract class StoredProcedureWithResultSet : StoredProcedure
    {
        /// <summary>
        /// 
        /// </summary>
        protected StoredProcedureWithResultSet()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected abstract StoredProcedureResultSet CreateResultSets(IDataReader reader);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StoredProcedureResultSet GetFirstResultSet()
        {
            return this.GetResultSets().FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public StoredProcedureResultSet GetFirstResultSet(Database database)
        {
            return this.GetResultSets(database).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public async Task<StoredProcedureResultSet> GetFirstResultSetAsync(Database database)
        {
            return (await this.GetResultSetsAsync(database)).FirstOrDefault();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        /// <returns></returns>
        public async Task<StoredProcedureResultSet> GetFirstResultSetAsync(IEnumerable<Database> databases)
        {
            var results = await this.GetResultSetsAsync(databases);
            return results.FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<StoredProcedureResultSet> GetResultSets()
        {
            return EnumerateResultSets().ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public List<StoredProcedureResultSet> GetResultSets(Database database)
        {
            return EnumerateResultSets(database).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        /// <returns></returns>
        public List<StoredProcedureResultSet> GetResultSets(IEnumerable<Database> databases)
        {
            var tt = new List<Task<List<StoredProcedureResultSet>>>();
            foreach (var db in databases)
            {
                var task = Task.Factory.StartNew<List<StoredProcedureResultSet>>(() =>
                {
                    return this.GetResultSets(db);
                });
                tt.Add(task);
            }
            var l = new List<StoredProcedureResultSet>();
            foreach (var item in Task.WhenAll(tt).Result)
            {
                foreach (var rs in item)
                {
                    l.Add(rs);
                }
            }
            return l;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<StoredProcedureResultSet>> GetResultSetsAsync()
        {
            return await this.GetResultSetsAsync(this.GetDatabase());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public async Task<List<StoredProcedureResultSet>> GetResultSetsAsync(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            DbDataReader dr = null;
            var previousState = database.ConnectionState;
            var resultsets = new List<StoredProcedureResultSet>();

            try
            {
                var cm = CreateCommand();
                var e = new StoredProcedureExecutingEventArgs(this, cm);
                StoredProcedure.OnExecuting(e);
                dr = await database.ExecuteReaderAsync(cm);
                while (dr.Read())
                {
                    var rs = CreateResultSets(dr);
                    resultsets.Add(rs);
                }
                dr.Close();
                this.SetOutputParameterValue(cm);
            }
            finally
            {
                if (dr != null) { dr.Dispose(); }
                if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
                if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
            }
            StoredProcedure.OnExecuted(new StoredProcedureExecutedEventArgs(this));
            return resultsets;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StoredProcedureResultSet>> GetResultSetsAsync(IEnumerable<Database> databases)
        {
            var tt = new List<Task<List<StoredProcedureResultSet>>>();
            foreach (var db in databases)
            {
                var task = Task.Factory.StartNew<List<StoredProcedureResultSet>>(() =>
                {
                    return this.GetResultSets(db);
                });
                tt.Add(task);
            }
            var results = await Task.WhenAll(tt);
            return results.SelectMany(el => el);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StoredProcedureResultSet> EnumerateResultSets()
        {
            return EnumerateResultSets(this.GetDatabase());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public IEnumerable<StoredProcedureResultSet> EnumerateResultSets(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            DbDataReader dr = null;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand();
                var e = new StoredProcedureExecutingEventArgs(this, cm);
                StoredProcedure.OnExecuting(e);
                dr = database.ExecuteReader(cm);
                while (dr.Read())
                {
                    var rs = CreateResultSets(dr);
                    yield return rs;
                }
                dr.Close();
                this.SetOutputParameterValue(cm);
            }
            finally
            {
                if (dr != null) { dr.Dispose(); }
                if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
                if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
            }
            StoredProcedure.OnExecuted(new StoredProcedureExecutedEventArgs(this));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(this.GetDatabase());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public DataTable GetDataTable(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            var previousState = database.ConnectionState;
            try
            {
                var cm = CreateCommand();
                var dt = database.GetDataTable(cm);
                return dt;
            }
            finally
            {
                if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
            }
        }
    }
}

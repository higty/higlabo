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
                var resultsets = new List<StoredProcedureResultSet>();
                var cm = CreateCommand();
                var e = new StoredProcedureExecutingEventArgs(this, cm);
                StoredProcedure.OnExecuting(e);
                dr = database.ExecuteReader(cm);
                while (dr.Read())
                {
                    var rs = CreateResultSets(dr);
                    resultsets.Add(rs);
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

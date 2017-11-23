using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using HigLabo.Core;
using HigLabo.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace HigLabo.DbSharp
{
    public abstract class StoredProcedure : INotifyPropertyChanged, IDatabaseContext
    {
        public static event EventHandler<StoredProcedureExecutingEventArgs> Executing;
        public static event EventHandler<StoredProcedureExecutedEventArgs> Executed;
        public static HigLabo.Core.TypeConverter TypeConverter { get; set; }

        static StoredProcedure()
        {
            TypeConverter = new HigLabo.Core.TypeConverter();
        }
        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        String IDatabaseContext.DatabaseKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        String IDatabaseContext.TransactionKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected StoredProcedure()
        {
            ((IDatabaseContext)this).TransactionKey = "";
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract string GetStoredProcedureName();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract DbCommand CreateCommand();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 ExecuteNonQuery()
        {
            return this.ExecuteNonQuery(this.GetDatabase());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public Int32 ExecuteNonQuery(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            var affectedRecordCount = -1;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand();
                var e = new StoredProcedureExecutingEventArgs(this, cm);
                StoredProcedure.OnExecuting(e);
                if (e.Cancel == true) { return affectedRecordCount; }
                affectedRecordCount = database.ExecuteCommand(cm);
                this.SetOutputParameterValue(cm);
            }
            finally
            {
                if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
                if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
            }
            StoredProcedure.OnExecuted(new StoredProcedureExecutedEventArgs(this));
            return affectedRecordCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        /// <returns></returns>
        public IEnumerable<ExecuteNonQueryResult> ExecuteNonQuery(IEnumerable<Database> databases)
        {
            var tt = new List<Task<ExecuteNonQueryResult>>();
            foreach (var db in databases)
            {
                var task = Task.Factory.StartNew<ExecuteNonQueryResult>(() =>
                {
                    var result = this.ExecuteNonQuery(db);
                    return new ExecuteNonQueryResult(db, result);
                });
                tt.Add(task);
            }
            var l = new List<ExecuteNonQueryResult>();
            return Task.WhenAll(tt).Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Int32> ExecuteNonQueryAsync()
        {
            return await this.ExecuteNonQueryAsync(this.GetDatabase());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public async Task<Int32> ExecuteNonQueryAsync(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            var affectedRecordCount = -1;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand();
                var e = new StoredProcedureExecutingEventArgs(this, cm);
                StoredProcedure.OnExecuting(e);
                if (e.Cancel == true) { return affectedRecordCount; }
                affectedRecordCount = await database.ExecuteCommandAsync(cm);
                this.SetOutputParameterValue(cm);
            }
            finally
            {
                if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
                if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
            }
            StoredProcedure.OnExecuted(new StoredProcedureExecutedEventArgs(this));
            return affectedRecordCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ExecuteNonQueryResult>> ExecuteNonQueryAsync(IEnumerable<Database> databases)
        {
            var tt = new List<Task<ExecuteNonQueryResult>>();
            foreach (var db in databases)
            {
                var task = Task.Factory.StartNew<ExecuteNonQueryResult>(() =>
                {
                    var result = this.ExecuteNonQuery(db);
                    return new ExecuteNonQueryResult(db, result);
                });
                tt.Add(task);
            }
            var results = await Task.WhenAll(tt);
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        protected abstract void SetOutputParameterValue(DbCommand command);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static object ToDBValue(object value)
        {
            return value ?? DBNull.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static T? ToEnum<T>(Object value)
            where T : struct
        {
            return TypeConverter.ToEnum<T>(value);
        }

        protected PropertyChangedEventHandler GetPropertyChangedEventHandler()
        {
            return this.PropertyChanged;
        }
        protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var eh = PropertyChanged;
            if (eh != null)
            {
                eh(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected static void OnExecuting(StoredProcedureExecutingEventArgs e)
        {
            var eh = StoredProcedure.Executing;
            if (eh != null)
            {
                eh(null, e);
            }
        }
        protected static void OnExecuted(StoredProcedureExecutedEventArgs e)
        {
            var eh = StoredProcedure.Executed;
            if (eh != null)
            {
                eh(null, e);
            }
        }
    }
}

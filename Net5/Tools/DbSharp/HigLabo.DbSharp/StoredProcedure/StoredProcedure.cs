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
        public event PropertyChangedEventHandler PropertyChanged;

        String IDatabaseContext.DatabaseKey { get; set; }

        protected StoredProcedure()
        {
        }
        public abstract string GetStoredProcedureName();
        public DbCommand CreateCommand()
        {
            return this.CreateCommand(this.GetDatabase());
        }
        public abstract DbCommand CreateCommand(Database database);
        public Int32 ExecuteNonQuery()
        {
            return this.ExecuteNonQuery(this.GetDatabase());
        }
        public Int32 ExecuteNonQuery(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            var affectedRecordCount = -1;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand(database);
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
        public Int32 ExecuteNonQuery(TransactionContext context)
        {
            return this.ExecuteNonQuery(context.Database);
        }
        public IEnumerable<ExecuteNonQueryResult> ExecuteNonQuery(IEnumerable<Database> databases)
        {
            var tt = new List<Task<ExecuteNonQueryResult>>();
            foreach (var db in databases)
            {
                tt.Add(this.GetExecuteNonQueryResultAsync(db));
            }
            var l = new List<ExecuteNonQueryResult>();
            return Task.WhenAll(tt).GetAwaiter().GetResult();
        }

        public async Task<Int32> ExecuteNonQueryAsync()
        {
            var rs = await this.GetExecuteNonQueryResultAsync().ConfigureAwait(false);
            return rs.AffectedRecordCount;
        }
        private async Task<ExecuteNonQueryResult> GetExecuteNonQueryResultAsync()
        {
            return await this.GetExecuteNonQueryResultAsync(this.GetDatabase()).ConfigureAwait(false);
        }
        public async Task<Int32> ExecuteNonQueryAsync(Database database)
        {
            var rs = await this.GetExecuteNonQueryResultAsync(database).ConfigureAwait(false);
            return rs.AffectedRecordCount;
        }
        public async Task<Int32> ExecuteNonQueryAsync(TransactionContext context)
        {
            return await this.ExecuteNonQueryAsync(context.Database);
        }
        private async Task<ExecuteNonQueryResult> GetExecuteNonQueryResultAsync(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            var affectedRecordCount = -1;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand(database);
                var e = new StoredProcedureExecutingEventArgs(this, cm);
                StoredProcedure.OnExecuting(e);
                if (e.Cancel == true) { return new ExecuteNonQueryResult(database, affectedRecordCount); }
                affectedRecordCount = await database.ExecuteCommandAsync(cm).ConfigureAwait(false);
                this.SetOutputParameterValue(cm);
            }
            finally
            {
                if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
                if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
            }
            StoredProcedure.OnExecuted(new StoredProcedureExecutedEventArgs(this));
            return new ExecuteNonQueryResult(database, affectedRecordCount);
        }
        public async Task<IEnumerable<ExecuteNonQueryResult>> ExecuteNonQueryAsync(IEnumerable<Database> databases)
        {
            var tt = new List<Task<ExecuteNonQueryResult>>();
            foreach (var db in databases)
            {
                tt.Add(this.GetExecuteNonQueryResultAsync(db));
            }
            var results = await Task.WhenAll(tt).ConfigureAwait(false);
            return results;
        }

        protected abstract void SetOutputParameterValue(DbCommand command);
        protected static object ToDBValue(object value)
        {
            return value ?? DBNull.Value;
        }
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

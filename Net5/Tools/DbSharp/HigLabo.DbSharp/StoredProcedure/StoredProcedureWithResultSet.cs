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
    public abstract class StoredProcedureWithResultSet : StoredProcedure
    {
        protected StoredProcedureWithResultSet()
        {
        }
        protected abstract StoredProcedureResultSet CreateResultSets(IDataReader reader);
        public StoredProcedureResultSet GetFirstResultSet()
        {
            return this.GetResultSets().FirstOrDefault();
        }
        public StoredProcedureResultSet GetFirstResultSet(Database database)
        {
            return this.GetResultSets(database).FirstOrDefault();
        }
        public StoredProcedureResultSet GetFirstResultSet(IEnumerable<Database> databases)
        {
            var results = this.GetResultSets(databases);
            return results.FirstOrDefault();
        }
        public async Task<StoredProcedureResultSet> GetFirstResultSetAsync()
        {
            return await this.GetFirstResultSetAsync(this.GetDatabase()).ConfigureAwait(false);
        }
        public async Task<StoredProcedureResultSet> GetFirstResultSetAsync(Database database)
        {
            return await this.GetFirstResultSetAsync(database, CancellationToken.None);
        }
        public async Task<StoredProcedureResultSet> GetFirstResultSetAsync(Database database, CancellationToken cancellationToken)
        {
            return (await this.GetResultSetsAsync(database, cancellationToken)).FirstOrDefault();
        }
        public async Task<StoredProcedureResultSet> GetFirstResultSetAsync(IEnumerable<Database> databases)
        {
            return await this.GetFirstResultSetAsync(databases, CancellationToken.None);
        }
        public async Task<StoredProcedureResultSet> GetFirstResultSetAsync(IEnumerable<Database> databases, CancellationToken cancellationToken)
        {
            var results = await this.GetResultSetsAsync(databases, cancellationToken).ConfigureAwait(false);
            return results.FirstOrDefault();
        }

        public List<StoredProcedureResultSet> GetResultSets()
        {
            return EnumerateResultSets().ToList();
        }
        public List<StoredProcedureResultSet> GetResultSets(Database database)
        {
            return EnumerateResultSets(database).ToList();
        }
        public List<StoredProcedureResultSet> GetResultSets(IEnumerable<Database> databases)
        {
            return this.GetResultSetsAsync(databases).GetAwaiter().GetResult().ToList();
        }
        public async Task<List<StoredProcedureResultSet>> GetResultSetsAsync()
        {
            return await this.GetResultSetsAsync(this.GetDatabase()).ConfigureAwait(false);
        }
        public async Task<List<StoredProcedureResultSet>> GetResultSetsAsync(Database database)
        {
            return await this.GetResultSetsAsync(database, CommandBehavior.Default, CancellationToken.None);
        }
        public async Task<List<StoredProcedureResultSet>> GetResultSetsAsync(Database database, CommandBehavior commandBehavior)
        {
            return await this.GetResultSetsAsync(database, commandBehavior, CancellationToken.None);
        }
        public async Task<List<StoredProcedureResultSet>> GetResultSetsAsync(Database database, CancellationToken cancellationToken)
        {
            return await this.GetResultSetsAsync(database, CommandBehavior.Default, cancellationToken);
        }
        public async Task<List<StoredProcedureResultSet>> GetResultSetsAsync(Database database, CommandBehavior commandBehavior, CancellationToken cancellationToken)
        {
            if (database == null) throw new ArgumentNullException("database");
            DbDataReader dr = null;
            var previousState = database.ConnectionState;
            var resultsets = new List<StoredProcedureResultSet>();

            try
            {
                var cm = CreateCommand(database);
                var e = new StoredProcedureExecutingEventArgs(this, cm);
                StoredProcedure.OnExecuting(e);
                dr = await database.ExecuteReaderAsync(cm, commandBehavior, cancellationToken).ConfigureAwait(false);
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
        public async Task<IEnumerable<StoredProcedureResultSet>> GetResultSetsAsync(IEnumerable<Database> databases)
        {
            return await this.GetResultSetsAsync(databases, CancellationToken.None);
        }
        public async Task<IEnumerable<StoredProcedureResultSet>> GetResultSetsAsync(IEnumerable<Database> databases, CancellationToken cancellationToken)
        {
            var tt = new List<Task<List<StoredProcedureResultSet>>>();
            foreach (var db in databases)
            {
                tt.Add(this.GetResultSetsAsync(db, cancellationToken));
            }
            var results = await Task.WhenAll(tt).ConfigureAwait(false);
            return results.SelectMany(el => el);
        }

        public IEnumerable<StoredProcedureResultSet> EnumerateResultSets()
        {
            return EnumerateResultSets(this.GetDatabase());
        }
        public IEnumerable<StoredProcedureResultSet> EnumerateResultSets(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            DbDataReader dr = null;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand(database);
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

        public DataTable GetDataTable()
        {
            return GetDataTable(this.GetDatabase());
        }
        public DataTable GetDataTable(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            var previousState = database.ConnectionState;
            try
            {
                var cm = CreateCommand(database);
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

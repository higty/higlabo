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

        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync()
        {
            return await this.GetFirstResultSetAsync(this.GetDatabase(), CommandBehavior.Default, CancellationToken.None);
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(CommandBehavior commandBehavior)
        {
            return await this.GetFirstResultSetAsync(this.GetDatabase(), commandBehavior, CancellationToken.None);
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(CancellationToken cancellationToken)
        {
            return await this.GetFirstResultSetAsync(this.GetDatabase(), CommandBehavior.Default, cancellationToken);
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(Database database)
        {
            return await this.GetFirstResultSetAsync(database, CancellationToken.None);
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(Database database, CommandBehavior commandBehavior)
        {
            return await this.GetFirstResultSetAsync(database, commandBehavior, CancellationToken.None);
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(Database database, CancellationToken cancellationToken)
        {
            return await this.GetFirstResultSetAsync(database, CommandBehavior.Default, cancellationToken);
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(Database database, CommandBehavior commandBehavior, CancellationToken cancellationToken)
        {
            var results = await this.GetResultSetsAsync(database, commandBehavior, cancellationToken);
            return results.FirstOrDefault();
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(IEnumerable<Database> databases)
        {
            return await this.GetFirstResultSetAsync(databases, CancellationToken.None);
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(IEnumerable<Database> databases, CommandBehavior commandBehavior)
        {
            return await this.GetFirstResultSetAsync(databases, commandBehavior, CancellationToken.None);
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(IEnumerable<Database> databases, CancellationToken cancellationToken)
        {
            return await this.GetFirstResultSetAsync(databases, CommandBehavior.Default, cancellationToken);
        }
        public async ValueTask<StoredProcedureResultSet?> GetFirstResultSetAsync(IEnumerable<Database> databases, CommandBehavior commandBehavior, CancellationToken cancellationToken)
        {
            var results = await this.GetResultSetsAsync(databases, commandBehavior, cancellationToken);
            return results.FirstOrDefault();
        }

        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync()
        {
            return await this.GetResultSetsAsync(this.GetDatabase(), CommandBehavior.Default, CancellationToken.None);
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(CommandBehavior commandBehavior)
        {
            return await this.GetResultSetsAsync(this.GetDatabase(), commandBehavior, CancellationToken.None);
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(CancellationToken cancellationToken)
        {
            return await this.GetResultSetsAsync(this.GetDatabase(), CommandBehavior.Default, cancellationToken);
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(Database database)
        {
            return await this.GetResultSetsAsync(database, CommandBehavior.Default, CancellationToken.None);
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(Database database, CommandBehavior commandBehavior)
        {
            return await this.GetResultSetsAsync(database, commandBehavior, CancellationToken.None);
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(Database database, CancellationToken cancellationToken)
        {
            return await this.GetResultSetsAsync(database, CommandBehavior.Default, cancellationToken);
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(Database database, CommandBehavior commandBehavior, CancellationToken cancellationToken)
        {
            if (database == null) throw new ArgumentNullException("database");
            DbDataReader? dr = null;
            var previousState = database.ConnectionState;
            var resultsets = new List<StoredProcedureResultSet>();

            try
            {
                var cm = CreateCommand(database);
                dr = await database.ExecuteReaderAsync(cm, commandBehavior, cancellationToken);
                while (dr!.Read())
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
            return resultsets;
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(IEnumerable<Database> databases)
        {
            return await this.GetResultSetsAsync(databases, CancellationToken.None);
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(IEnumerable<Database> databases, CommandBehavior commandBehavior)
        {
            return await this.GetResultSetsAsync(databases, commandBehavior, CancellationToken.None);
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(IEnumerable<Database> databases, CancellationToken cancellationToken)
        {
            return await this.GetResultSetsAsync(databases, CommandBehavior.Default, cancellationToken);
        }
        public async ValueTask<List<StoredProcedureResultSet>> GetResultSetsAsync(IEnumerable<Database> databases, CommandBehavior commandBehavior, CancellationToken cancellationToken)
        {
            var tt = new List<Task<List<StoredProcedureResultSet>>>();
            foreach (var db in databases)
            {
                tt.Add(this.GetResultSetsAsync(db, commandBehavior, cancellationToken).AsTask());
            }
            if (tt.Count == 0) { return await this.GetResultSetsAsync(); }

            var results = await Task.WhenAll(tt).ConfigureAwait(false);
            return results.SelectMany(el => el).ToList();
        }

        public IEnumerable<StoredProcedureResultSet> EnumerateResultSets()
        {
            return EnumerateResultSets(this.GetDatabase());
        }
        public IEnumerable<StoredProcedureResultSet> EnumerateResultSets(CommandBehavior commandBehavior)
        {
            return EnumerateResultSets(this.GetDatabase(), commandBehavior);
        }
        public IEnumerable<StoredProcedureResultSet> EnumerateResultSets(Database database)
        {
            return EnumerateResultSets(database, CommandBehavior.Default);
        }
        public IEnumerable<StoredProcedureResultSet> EnumerateResultSets(Database database, CommandBehavior commandBehavior)
        {
            if (database == null) throw new ArgumentNullException("database");
            DbDataReader? dr = null;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand(database);
                dr = database.ExecuteReader(cm, commandBehavior);
                while (dr!.Read())
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
        }

        public async IAsyncEnumerable<StoredProcedureResultSet> EnumerateResultSetsAsync(Database database)
        {
            await foreach (var item in this.EnumerateResultSetsAsync(database, CommandBehavior.Default, CancellationToken.None))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<StoredProcedureResultSet> EnumerateResultSetsAsync(Database database, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            await foreach (var item in this.EnumerateResultSetsAsync(database, CommandBehavior.Default, cancellationToken))
            {
                yield return item;
            }
        }
        public async IAsyncEnumerable<StoredProcedureResultSet> EnumerateResultSetsAsync(Database database, CommandBehavior commandBehavior, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            if (database == null) throw new ArgumentNullException("database");
            DbDataReader? dr = null;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand(database);
                dr = await database.ExecuteReaderAsync(cm, commandBehavior, cancellationToken);
                while (await dr!.ReadAsync())
                {
                    var rs = CreateResultSets(dr);
                    yield return rs;
                }
                await dr.CloseAsync();
                this.SetOutputParameterValue(cm);
            }
            finally
            {
                if (dr != null) { dr.Dispose(); }
                if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
                if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
            }
        }

        public DataTable? GetDataTable()
        {
            return GetDataTable(this.GetDatabase());
        }
        public DataTable? GetDataTable(Database database)
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

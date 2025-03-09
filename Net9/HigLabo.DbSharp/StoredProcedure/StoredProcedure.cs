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
using System.Threading;

namespace HigLabo.DbSharp;

public abstract class StoredProcedure : IDatabaseKey
{
    public static DatabaseFactory DatabaseFactory { get; private set; } = new DatabaseFactory();
    public static HigLabo.Core.TypeConverter TypeConverter { get; set; } = new HigLabo.Core.TypeConverter();

    public event EventHandler<StoredProcedureEventArgs>? Executing;
    String IDatabaseKey.DatabaseKey { get; set; } = "";

    protected StoredProcedure()
    {
    }

    public abstract string GetStoredProcedureName();
    public DbCommand CreateCommand()
    {
        return this.CreateCommand(this.GetDatabase());
    }
    public abstract DbCommand CreateCommand(Database database);
    public Database GetDatabase()
    {
        return DatabaseFactory.CreateDatabase((this as IDatabaseKey).DatabaseKey);
    }

    private async ValueTask<ExecuteNonQueryResult> GetExecuteNonQueryResultAsync(Database database, CancellationToken cancellationToken)
    {
        if (database == null) throw new ArgumentNullException("database");
        var affectedRecordCount = -1;
        var previousState = database.ConnectionState;

        try
        {
            var cm = CreateCommand(database);
            this.OnExecuting(new StoredProcedureEventArgs(database, cm));
            affectedRecordCount = await database.ExecuteCommandAsync(cm, cancellationToken).ConfigureAwait(false);
            this.SetOutputParameterValue(cm);
        }
        finally
        {
            if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
            if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
        }
        return new ExecuteNonQueryResult(database, affectedRecordCount);
    }
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
            this.OnExecuting(new StoredProcedureEventArgs(database, cm));
            affectedRecordCount = database.ExecuteCommand(cm);
            this.SetOutputParameterValue(cm);
        }
        finally
        {
            if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
            if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
        }
        return affectedRecordCount;
    }
    public Int32 ExecuteNonQuery(TransactionContext context)
    {
        return this.ExecuteNonQuery(context.Database);
    }
    public IEnumerable<ExecuteNonQueryResult> ExecuteNonQuery(IEnumerable<Database> databases)
    {
        return ExecuteNonQuery(databases, CancellationToken.None);
    }
    public IEnumerable<ExecuteNonQueryResult> ExecuteNonQuery(IEnumerable<Database> databases, CancellationToken cancellationToken)
    {
        var tt = new List<Task<ExecuteNonQueryResult>>();
        foreach (var db in databases)
        {
            tt.Add(this.GetExecuteNonQueryResultAsync(db, cancellationToken).AsTask());
        }
        var l = new List<ExecuteNonQueryResult>();
        return Task.WhenAll(tt).GetAwaiter().GetResult();
    }

    public async ValueTask<Int32> ExecuteNonQueryAsync()
    {
        return await this.ExecuteNonQueryAsync(this.GetDatabase(), CancellationToken.None);
    }
    public async ValueTask<Int32> ExecuteNonQueryAsync(CancellationToken cancellationToken)
    {
        return await this.ExecuteNonQueryAsync(this.GetDatabase(), cancellationToken);
    }
    public async ValueTask<Int32> ExecuteNonQueryAsync(TransactionContext context)
    {
        return await this.ExecuteNonQueryAsync(context.Database);
    }
    public async ValueTask<Int32> ExecuteNonQueryAsync(TransactionContext context, CancellationToken cancellationToken)
    {
        return await this.ExecuteNonQueryAsync(context.Database, cancellationToken);
    }
    public async ValueTask<Int32> ExecuteNonQueryAsync(Database database)
    {
        return await this.ExecuteNonQueryAsync(database, CancellationToken.None);
    }
    public async ValueTask<Int32> ExecuteNonQueryAsync(Database database, CancellationToken cancellationToken)
    {
        var rs = await this.GetExecuteNonQueryResultAsync(database, cancellationToken).ConfigureAwait(false);
        return rs.AffectedRecordCount;
    }
    public async ValueTask<IEnumerable<ExecuteNonQueryResult>> ExecuteNonQueryAsync(IEnumerable<Database> databases)
    {
        return await ExecuteNonQueryAsync(databases, CancellationToken.None);
    }
    public async ValueTask<IEnumerable<ExecuteNonQueryResult>> ExecuteNonQueryAsync(IEnumerable<Database> databases, CancellationToken cancellationToken)
    {
        var tt = new List<Task<ExecuteNonQueryResult>>();
        foreach (var db in databases)
        {
            tt.Add(this.GetExecuteNonQueryResultAsync(db, cancellationToken).AsTask());
        }
        var results = await Task.WhenAll(tt).ConfigureAwait(false);
        return results;
    }
    protected void OnExecuting(StoredProcedureEventArgs e)
    {
        this.Executing?.Invoke(this, e);
    }
    protected abstract void SetOutputParameterValue(DbCommand command);
    protected static object ToDBValue(object value)
    {
        return value ?? DBNull.Value;
    }
    protected static T? ToEnum<T>(Object? value)
        where T : struct
    {
        return TypeConverter.ToEnum<T>(value);
    }
}

using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public abstract class StoredProcedureWithResultSetsList<T, TResultSetList> : StoredProcedureWithResultSet<T>
        where T: StoredProcedureResultSet, new()
        where TResultSetList: new()
    {
        protected static Action<TResultSetList, TResultSetList>? _MergeMethod;
        protected List<Func<DbDataReader, StoredProcedureResultSet>> _CreateResultSetMethodList = new List<Func<DbDataReader, StoredProcedureResultSet>>();

        protected abstract void SetResultSetsList(TResultSetList resultSetList, List<List<StoredProcedureResultSet>> list);

        public TResultSetList GetResultSetsList()
        {
            return this.GetResultSetsList(this.GetDatabase(), CommandBehavior.Default);
        }
        public TResultSetList GetResultSetsList(CommandBehavior commandBehavior)
        {
            return this.GetResultSetsList(this.GetDatabase(), commandBehavior);
        }
        public TResultSetList GetResultSetsList(Database database)
        {
            return this.GetResultSetsList(database, CommandBehavior.Default);
        }
        public TResultSetList GetResultSetsList(Database database, CommandBehavior commandBehavior)
        {
            var rsl = new TResultSetList();
            List<List<StoredProcedureResultSet>> l = new List<List<StoredProcedureResultSet>>();
            DbDataReader? dr = null;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand(database);
                dr = database.ExecuteReader(cm, commandBehavior);
                Int32 index = 0;
                while (true)
                {
                    l.Add(new List<StoredProcedureResultSet>());
                    while (dr!.Read())
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
        public TResultSetList GetResultSetsList(IEnumerable<Database> databases)
        {
            return this.GetResultSetsListAsync(databases, CommandBehavior.Default, CancellationToken.None).GetAwaiter().GetResult();
        }
        public TResultSetList GetResultSetsList(IEnumerable<Database> databases, CommandBehavior commandBehavior)
        {
            return this.GetResultSetsListAsync(databases, commandBehavior, CancellationToken.None).GetAwaiter().GetResult();
        }
        public TResultSetList GetResultSetsList(IEnumerable<Database> databases, CancellationToken cancellation)
        {
            return this.GetResultSetsListAsync(databases, CommandBehavior.Default, cancellation).GetAwaiter().GetResult();
        }
        public TResultSetList GetResultSetsList(IEnumerable<Database> databases, CommandBehavior commandBehavior, CancellationToken cancellation)
        {
            return this.GetResultSetsListAsync(databases, commandBehavior, cancellation).GetAwaiter().GetResult();
        }

        public async Task<TResultSetList> GetResultSetsListAsync()
        {
            return await this.GetResultSetsListAsync(this.GetDatabase(), CommandBehavior.Default, CancellationToken.None).ConfigureAwait(false);
        }
        public async Task<TResultSetList> GetResultSetsListAsync(CommandBehavior commandBehavior)
        {
            return await this.GetResultSetsListAsync(this.GetDatabase(), commandBehavior, CancellationToken.None).ConfigureAwait(false);
        }
        public async Task<TResultSetList> GetResultSetsListAsync(CancellationToken cancellation)
        {
            return await this.GetResultSetsListAsync(this.GetDatabase(), CommandBehavior.Default, cancellation).ConfigureAwait(false);
        }
        public async Task<TResultSetList> GetResultSetsListAsync(Database database)
        {
            return await GetResultSetsListAsync(database, CommandBehavior.Default, CancellationToken.None);
        }
        public async Task<TResultSetList> GetResultSetsListAsync(Database database, CommandBehavior commandBehavior)
        {
            return await GetResultSetsListAsync(database, commandBehavior, CancellationToken.None);
        }
        public async Task<TResultSetList> GetResultSetsListAsync(Database database, CancellationToken cancellation)
        {
            return await GetResultSetsListAsync(database, CommandBehavior.Default, cancellation);
        }
        public async Task<TResultSetList> GetResultSetsListAsync(Database database, CommandBehavior commandBehavior, CancellationToken cancellation)
        {
            var rsl = new TResultSetList();
            List<List<StoredProcedureResultSet>> l = new List<List<StoredProcedureResultSet>>();
            DbDataReader? dr = null;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand(database);
                dr = await database.ExecuteReaderAsync(cm, commandBehavior, cancellation).ConfigureAwait(false);
                Int32 index = 0;
                while (true)
                {
                    l.Add(new List<StoredProcedureResultSet>());
                    while (dr!.Read())
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
        public async Task<TResultSetList> GetResultSetsListAsync(IEnumerable<Database> databases)
        {
            return await GetResultSetsListAsync(databases, CommandBehavior.Default, CancellationToken.None);
        }
        public async Task<TResultSetList> GetResultSetsListAsync(IEnumerable<Database> databases, CommandBehavior commandBehavior)
        {
            return await GetResultSetsListAsync(databases, commandBehavior, CancellationToken.None);
        }
        public async Task<TResultSetList> GetResultSetsListAsync(IEnumerable<Database> databases, CancellationToken cancellation)
        {
            return await GetResultSetsListAsync(databases, CommandBehavior.Default, cancellation);
        }
        public async Task<TResultSetList> GetResultSetsListAsync(IEnumerable<Database> databases, CommandBehavior commandBehavior, CancellationToken cancellation)
        {
            var tt = new List<Task<TResultSetList>>();
            foreach (var db in databases)
            {
                tt.Add(this.GetResultSetsListAsync(db, commandBehavior, cancellation));
            }
            var result = new TResultSetList();
            foreach (var item in await Task.WhenAll(tt).ConfigureAwait(false))
            {
                //Set by generated code.
                _MergeMethod!(item, result);
            }
            return result;
        }
    }
}

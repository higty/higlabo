using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.Data
{
    public partial class Database
    {
        public async ValueTask<Int32> OpenAsync()
        {
            if (this.Connection == null)
            {
                this.Connection = this.CreateConnection();
                await this.Connection.OpenAsync().ConfigureAwait(false);
            }
            else
            {
                if (this.Connection.State == ConnectionState.Closed)
                {
                    await this.Connection.OpenAsync().ConfigureAwait(false);
                }
            }
            return 0;
        }

        public async ValueTask<DbDataReader?> ExecuteReaderAsync(String query)
        {
            return await ExecuteReaderAsync(query, CommandBehavior.Default);
        }
        public async ValueTask<DbDataReader?> ExecuteReaderAsync(String query, CommandBehavior commandBehavior)
        {
            return await ExecuteReaderAsync(query, commandBehavior, CancellationToken.None);
        }
        public async ValueTask<DbDataReader?> ExecuteReaderAsync(String query, CommandBehavior commandBehavior, CancellationToken cancellationToken)
        {
            var cm = this.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return await ExecuteReaderAsync(cm, commandBehavior, cancellationToken).ConfigureAwait(false);
        }
        public async ValueTask<DbDataReader?> ExecuteReaderAsync(DbCommand command)
        {
            return await ExecuteReaderAsync(command, CommandBehavior.Default, CancellationToken.None).ConfigureAwait(false);
        }
        public async ValueTask<DbDataReader?> ExecuteReaderAsync(DbCommand command, CommandBehavior commandBehavior)
        {
            return await ExecuteReaderAsync(command, commandBehavior, CancellationToken.None).ConfigureAwait(false);
        }
        public async ValueTask<DbDataReader?> ExecuteReaderAsync(DbCommand command, CommandBehavior commandBehavior, CancellationToken cancellationToken)
        {
            DbDataReader? dr = null;
            DbCommand cm = command;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object? ec = null;

            try
            {
                var e = this.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.ExecuteReader, this.ConnectionString, cm));
                if (e != null && e.Cancel == true) { return null; }
                if (e != null)
                {
                    ec = e.ExecutionContext;
                }

                await this.OpenAsync();
                cm.Connection = this.Connection;
                cm.Transaction = this.Transaction;
                startTime = DateTimeOffset.Now;
                dr = await cm.ExecuteReaderAsync(commandBehavior, cancellationToken).ConfigureAwait(false);
                endTime = DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.Close();
                this.CatchException(new CommandErrorEventArgs(MethodName.ExecuteReader, this.ConnectionString, ex, ec, cm));
            }
            if (startTime.HasValue == true && endTime.HasValue == true)
            {
                this.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.ExecuteReader, this.ConnectionString
                    , startTime.Value, endTime.Value, ec, cm));
            }
            return dr;
        }

        public async ValueTask<Object?> ExecuteScalarAsync(String query)
        {
            var cm = this.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return await this.ExecuteScalarAsync(cm).ConfigureAwait(false);
        }
        public async ValueTask<Object?> ExecuteScalarAsync(DbCommand command)
        {
            return await ExecuteScalarAsync(command, CancellationToken.None).ConfigureAwait(false);
        }
        public async ValueTask<Object?> ExecuteScalarAsync(DbCommand command, CancellationToken cancellationToken)
        {
            Object? o = null;
            ConnectionState state = this.ConnectionState;
            DbCommand cm = command;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object? ec = null;

            try
            {
                var e = this.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.ExecuteScalar, this.ConnectionString, cm));
                if (e != null && e.Cancel == true) { return null; }
                if (e != null)
                {
                    ec = e.ExecutionContext;
                }

                await this.OpenAsync().ConfigureAwait(false);
                cm.Connection = this.Connection;
                cm.Transaction = this.Transaction;
                startTime = DateTimeOffset.Now;
                o = await cm.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                endTime = DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.CatchException(new CommandErrorEventArgs(MethodName.ExecuteScalar, this.ConnectionString, ex, ec, cm));
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Close();
                }
            }
            if (startTime.HasValue == true && endTime.HasValue == true)
            {
                this.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.ExecuteScalar, this.ConnectionString
                    , startTime.Value, endTime.Value, ec, cm));
            }
            return o;
        }

        public async ValueTask<Int32> ExecuteCommandAsync(String query)
        {
            var cm = this.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return await ExecuteCommandAsync(cm).ConfigureAwait(false);
        }
        public async ValueTask<Int32> ExecuteCommandAsync(DbCommand command)
        {
            return await ExecuteCommandAsync(command, CancellationToken.None).ConfigureAwait(false);
        }
        public async ValueTask<Int32> ExecuteCommandAsync(DbCommand command, CancellationToken cancellationToken)
        {
            var affectRecordNumber = Int32.MinValue;
            ConnectionState state = this.ConnectionState;
            DbCommand cm = command;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object? ec = null;

            try
            {
                var e = this.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.ExecuteCommand, this.ConnectionString, cm));
                if (e != null && e.Cancel == true) { return -1; }
                if (e != null)
                {
                    ec = e.ExecutionContext;
                }

                await this.OpenAsync();
                cm.Connection = this.Connection;
                cm.Transaction = this.Transaction;
                startTime = DateTimeOffset.Now;
                affectRecordNumber = await cm.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                endTime = DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.CatchException(new CommandErrorEventArgs(MethodName.ExecuteCommand, this.ConnectionString, ex, ec, cm));
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Close();
                }
            }
            if (startTime.HasValue == true && endTime.HasValue == true)
            {
                this.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.ExecuteCommand, this.ConnectionString
                    , startTime.Value, endTime.Value, ec, cm));
            }
            return affectRecordNumber;
        }

    }
}

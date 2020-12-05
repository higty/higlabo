using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;

namespace HigLabo.Data
{
    public abstract partial class Database : IDisposable
    {
        public static event EventHandler<CommandExecutingEventArgs> CommandExecuting;
        public static event EventHandler<CommandExecutedEventArgs> CommandExecuted;
        public static event EventHandler<CommandErrorEventArgs> CommandError;

        public event EventHandler<ConnectionCreatedEventArgs> ConnectionCreated;
        public event EventHandler<CommandCreatedEventArgs> CommandCreated;

        public static readonly DatabaseDefaultSettings DefaultSettings = new DatabaseDefaultSettings();

        private ConcurrentBag<Int32> _RetryIntervalMillisecondList = new ConcurrentBag<int>();

        protected DbConnection Connection { get; set; }
        protected DbTransaction Transaction { get; set; }
        public String ConnectionString { get; set; }
        public ConnectionState ConnectionState
        {
            get
            {
                if (this.Connection == null)
                { return ConnectionState.Closed; }
                return this.Connection.State;
            }
        }
        public Boolean OnTransaction
        {
            get { return this.Transaction != null; }
        }

        public Database()
        {
            foreach (var item in DefaultSettings.RetryIntervalMillisecondList)
            {
                this._RetryIntervalMillisecondList.Add(item);
            }
        }

        public void Open()
        {
            if (this._RetryIntervalMillisecondList.Count == 0)
            {
                this.OpenConnection();
            }
            else
            {
                this.Open(this._RetryIntervalMillisecondList.ToList());
            }
        }
        private void OpenConnection()
        {
            if (this.Connection == null)
            {
                this.Connection = this.CreateConnection();
                this.Connection.Open();
            }
            else
            {
                if (this.Connection.State == ConnectionState.Closed)
                {
                    this.Connection.Open();
                }
            }
        }
        public void Open(Int32 retryCount, Int32 intervalmilliseconds)
        {
            var l = new List<Int32>();
            for (int i = 0; i < retryCount; i++)
            {
                l.Add(intervalmilliseconds);
            }
            this.Open(l);
        }
        public void Open(List<Int32> retryIntervalMillisecondsList)
        {
            for (int i = 0; i < retryIntervalMillisecondsList.Count; i++)
            {
                try
                {
                    this.OpenConnection();
                    return;
                }
                catch
                {
                    if (i == retryIntervalMillisecondsList.Count - 1)
                    {
                        throw;
                    }
                    this.Close();
                    Thread.Sleep(retryIntervalMillisecondsList[i]);
                }
            }
        }
        public void Close()
        {
            this.Transaction = null;
            if (this.Connection != null)
            {
                if (this.Connection.State == ConnectionState.Open)
                {
                    this.Connection.Close();
                }
                this.Connection.Dispose();
                this.Connection = null;
            }
        }
        public Boolean CanOpen()
        {
            try
            {
                this.Open();
            }
            catch
            {
                return false;
            }
            finally
            {
                this.Close();
            }
            return true;
        }
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            this.Open();
            this.Transaction = this.Connection.BeginTransaction(isolationLevel);
        }
        public void CommitTransaction()
        {
            if (this.Transaction == null) throw new InvalidOperationException("Transaction does not begin.Please call BeginTransaction method before calling CommitTransaction method.");
            this.Transaction.Commit();
            this.Close();
        }
        public void RollBackTransaction()
        {
            if (this.Transaction == null) throw new InvalidOperationException("Transaction does not begin.Please call BeginTransaction method before calling RollBackTransaction method.");
            this.Transaction.Rollback();
            this.Close();
        }
        public DbConnection CreateConnection()
        {
            var cn = this.CreateDbConnection();
            cn.ConnectionString = this.ConnectionString;
            this.OnConnectionCreated(new ConnectionCreatedEventArgs(cn));
            return cn;
        }
        protected abstract DbConnection CreateDbConnection();
        public DbCommand CreateCommand()
        {
            var cm = this.CreateDbCommand();
            this.OnCommandCreated(new CommandCreatedEventArgs(cm));
            return cm;
        }
        protected abstract DbCommand CreateDbCommand();
        public DbCommand CreateCommand(String commandText)
        {
            var cm = this.CreateCommand();
            cm.CommandText = commandText;
            return cm;
        }
        public abstract DbDataAdapter CreateDataAdapter();
        public DbParameter CreateParameter(string parameterName, Enum dbType)
        {
            return this.CreateParameter(parameterName, dbType, 0, 0);
        }
        public abstract DbParameter CreateParameter(string parameterName, Enum dbType, byte? precision, byte? scale);

        public DataSet GetDataSet(String query)
        {
            var cm = this.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return GetDataSet(cm);
        }
        public DataSet GetDataSet(DbCommand command)
        {
            var ds = new DataSet();
            DbDataAdapter da = null;
            DbCommand cm = command;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object ec = null;

            try
            {
                var e = Database.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.GetDataSet, this.ConnectionString, cm));
                if (e != null && e.Cancel == true) { return null; }
                ec = e.ExecutionContext;

                this.Open();
                da = this.CreateDataAdapter();
                cm.Connection = this.Connection;
                cm.Transaction = this.Transaction;
                da.SelectCommand = cm;
                startTime = DateTimeOffset.Now;
                da.Fill(ds);
                endTime = DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.CatchException(new CommandErrorEventArgs(MethodName.GetDataSet, this.ConnectionString, ex, ec, cm));
            }
            finally
            {
                if (cm.Transaction == null && this.Connection.State == ConnectionState.Closed)
                { this.Close(); }
            }
            if (startTime.HasValue == true && endTime.HasValue == true)
            {
                Database.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.GetDataSet, this.ConnectionString
                    , startTime.Value, endTime.Value, ec, cm));
            }
            return ds;
        }
        public DataTable GetDataTable(String query)
        {
            var cm = this.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return GetDataTable(cm);
        }
        public DataTable GetDataTable(DbCommand command)
        {
            var dt = new DataTable();
            DbDataAdapter da = null;
            DbCommand cm = command;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object ec = null;

            try
            {
                var e = Database.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.GetDataTable, this.ConnectionString, cm));
                if (e != null && e.Cancel == true) { return null; }
                ec = e.ExecutionContext;

                this.Open();
                da = this.CreateDataAdapter();
                cm.Connection = this.Connection;
                cm.Transaction = this.Transaction;
                da.SelectCommand = cm;
                startTime = DateTimeOffset.Now;
                da.Fill(dt);
                endTime = DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.CatchException(new CommandErrorEventArgs(MethodName.GetDataTable, this.ConnectionString, ex, ec, cm));
            }
            finally
            {
                if (cm.Transaction == null && this.Connection.State == ConnectionState.Closed)
                { this.Close(); }
            }
            if (startTime.HasValue == true && endTime.HasValue == true)
            {
                Database.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.GetDataTable, this.ConnectionString
                    , startTime.Value, endTime.Value, ec, cm));
            }
            return dt;
        }
        public DbDataReader ExecuteReader(String query)
        {
            return ExecuteReader(query, CommandBehavior.Default);
        }
        public DbDataReader ExecuteReader(String query, CommandBehavior commandBehavior)
        {
            var cm = this.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return ExecuteReader(cm, commandBehavior);
        }
        public DbDataReader ExecuteReader(DbCommand command)
        {
            return this.ExecuteReader(command, CommandBehavior.Default);
        }
        public DbDataReader ExecuteReader(DbCommand command, CommandBehavior commandBehavior)
        {
            DbDataReader dr = null;
            DbCommand cm = command;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object ec = null;

            try
            {
                var e = Database.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.ExecuteReader, this.ConnectionString, cm));
                if (e != null && e.Cancel == true) { return null; }
                ec = e.ExecutionContext;

                this.Open();
                cm.Connection = this.Connection;
                cm.Transaction = this.Transaction;
                startTime = DateTimeOffset.Now;
                dr = cm.ExecuteReader(commandBehavior);
                endTime = DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.Close();
                this.CatchException(new CommandErrorEventArgs(MethodName.ExecuteReader, this.ConnectionString, ex, ec, cm));
            }
            if (startTime.HasValue == true && endTime.HasValue == true)
            {
                Database.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.ExecuteReader, this.ConnectionString
                    , startTime.Value, endTime.Value, ec, cm));
            }
            return dr;
        }
        public Object ExecuteScalar(String query)
        {
            var cm = this.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return this.ExecuteScalar(cm);
        }
        public Object ExecuteScalar(DbCommand command)
        {
            Object o = null;
            ConnectionState state = this.ConnectionState;
            DbCommand cm = command;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object ec = null;

            try
            {
                var e = Database.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.ExecuteScalar, this.ConnectionString, cm));
                if (e != null && e.Cancel == true) { return null; }
                ec = e.ExecutionContext;

                this.Open();
                cm.Connection = this.Connection;
                cm.Transaction = this.Transaction;
                startTime = DateTimeOffset.Now;
                o = cm.ExecuteScalar();
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
                Database.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.ExecuteScalar, this.ConnectionString
                    , startTime.Value, endTime.Value, ec, cm));
            }
            return o;
        }
        public Int32 ExecuteCommand(String query)
        {
            var cm = this.CreateCommand(query);
            cm.CommandType = CommandType.Text;
            return ExecuteCommand(cm);
        }
        public Int32 ExecuteCommand(DbCommand command)
        {
            var affectRecordNumber = Int32.MinValue;
            ConnectionState state = this.ConnectionState;
            DbCommand cm = command;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object ec = null;

            try
            {
                var e = Database.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.ExecuteCommand, this.ConnectionString, cm));
                if (e != null && e.Cancel == true) { return -1; }
                ec = e.ExecutionContext;

                this.Open();
                cm.Connection = this.Connection;
                cm.Transaction = this.Transaction;
                startTime = DateTimeOffset.Now;
                affectRecordNumber = cm.ExecuteNonQuery();
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
                Database.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.ExecuteCommand, this.ConnectionString
                    , startTime.Value, endTime.Value, ec, cm));
            }
            return affectRecordNumber;
        }
        public Int32[] ExecuteCommand(IsolationLevel isolationLevel, params String[] commands)
        {
            var l = new List<DbCommand>();
            foreach (var item in commands)
            {
                var cm = this.CreateCommand(item);
                cm.CommandType = CommandType.Text;
            }
            return ExecuteCommand(isolationLevel, l.ToArray());
        }
        public Int32[] ExecuteCommand(IsolationLevel isolationLevel, params DbCommand[] commands)
        {
            var affectRecordNumber = new Int32[commands.Length];
            ConnectionState state = this.ConnectionState;
            DbCommand cm = null;
            CommandExecutingEventArgs e;
            Object ec = null;

            try
            {
                this.Open();
                this.BeginTransaction(isolationLevel);
                for (Int32 i = 0; i < commands.Length; i++)
                {
                    cm = commands[i];
                    e = Database.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.ExecuteCommandList, this.ConnectionString, cm));
                    if (e != null && e.Cancel == true) { continue; }
                    ec = e.ExecutionContext;

                    cm.Connection = this.Connection;
                    cm.Transaction = this.Transaction;
                    var startTime = DateTimeOffset.Now;
                    affectRecordNumber[i] = cm.ExecuteNonQuery();
                    var endTime = DateTimeOffset.Now;
                    Database.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.ExecuteCommandList, this.ConnectionString
                        , startTime, endTime, ec, cm));
                }
                this.Transaction.Commit();
            }
            catch (Exception ex)
            {
                if (this.Connection.State == ConnectionState.Open)
                {
                    this.Transaction.Rollback();
                }
                this.CatchException(new CommandErrorEventArgs(MethodName.ExecuteCommandList, this.ConnectionString, ex, ec, cm));
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Close();
                }
            }
            return affectRecordNumber;
        }
        public Int32 Save(DbDataAdapter dataAdapter, DataTable dataTable)
        {
            var previousState = ConnectionState;
            int affectedRecordCount = -1;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object ec = null;

            try
            {
                var e = Database.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.Save, ConnectionString, dataAdapter));
                if (e != null && e.Cancel == true) { return -1; }
                ec = e.ExecutionContext;

                Open();
                if (dataAdapter.InsertCommand != null)
                {
                    dataAdapter.InsertCommand.Connection = this.Connection;
                    dataAdapter.InsertCommand.Transaction = this.Transaction;
                }
                if (dataAdapter.UpdateCommand != null)
                {
                    dataAdapter.UpdateCommand.Connection = this.Connection;
                    dataAdapter.UpdateCommand.Transaction = this.Transaction;
                }
                if (dataAdapter.DeleteCommand != null)
                {
                    dataAdapter.DeleteCommand.Connection = this.Connection;
                    dataAdapter.DeleteCommand.Transaction = this.Transaction;
                }
                startTime = DateTimeOffset.Now;
                affectedRecordCount = dataAdapter.Update(dataTable);
                endTime = DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.CatchException(new CommandErrorEventArgs(MethodName.Save, ConnectionString, ex, ec, dataAdapter));
            }
            finally
            {
                if (previousState == ConnectionState.Closed &&
                    ConnectionState == ConnectionState.Open)
                {
                    Close();
                }
            }
            if (startTime.HasValue == true && endTime.HasValue == true)
            {
                Database.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.Save, ConnectionString
                    , startTime.Value, endTime.Value, ec, dataAdapter));
            }
            return affectedRecordCount;
        }

        protected virtual Exception CreateException(Exception exception)
        {
            return new DatabaseException(exception);
        }
        protected virtual Exception CreateException(CommandErrorEventArgs e)
        {
            var exception = CreateException(e.Exception);
            var ex = exception as DatabaseException;
            if (ex != null)
            {
                ex.MethodName = e.MethodName;
                ex.ConnectionString = e.ConnectionString;
                ex.Command = e.Command;
                ex.DataAdapter = e.DataAdapter;
            }
            return exception;
        }

        protected void CatchException(CommandErrorEventArgs e)
        {
            Database.OnCommandError(e);
            if (e.ThrowException == true)
            {
                var ex = this.CreateException(e);
                throw ex;
            }
        }

        protected static CommandExecutingEventArgs OnCommandExecuting(CommandExecutingEventArgs e)
        {
            var eh = Database.CommandExecuting;
            if (eh != null)
            {
                eh(null, e);
            }
            return e;
        }
        protected static CommandExecutedEventArgs OnCommandExecuted(CommandExecutedEventArgs e)
        {
            var eh = Database.CommandExecuted;
            if (eh != null)
            {
                eh(null, e);
            }
            return e;
        }
        protected static CommandErrorEventArgs OnCommandError(CommandErrorEventArgs e)
        {
            var eh = Database.CommandError;
            if (eh != null)
            {
                eh(null, e);
            }
            return e;
        }
        protected void OnConnectionCreated(ConnectionCreatedEventArgs e)
        {
            var eh = this.ConnectionCreated;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        protected void OnCommandCreated(CommandCreatedEventArgs e)
        {
            var eh = this.CommandCreated;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        #region Dispose
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }
        protected void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                if (this.Transaction != null)
                { this.Transaction.Dispose(); }
                if (this.Connection != null)
                { this.Connection.Dispose(); }
            }
            this.Transaction = null;
            this.Connection = null;
        }
        ~Database()
        {
            this.Dispose(false);
        }
        #endregion
    }
}

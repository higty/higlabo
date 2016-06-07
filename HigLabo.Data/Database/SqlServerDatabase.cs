using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HigLabo.Data
{
    /// <summary>
    /// SQLサーバーへの接続及びデータ操作の機能を提供します。
    /// </summary>
    public partial class SqlServerDatabase : Database
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlServerDatabase(String connectionString)
        {
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        public SqlServerDatabase(String serverName, String databaseName)
        {
            this.ConnectionString = SqlServerDatabaseConnectionString.Create(serverName, databaseName, 100);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <param name="inUserID"></param>
        /// <param name="inPassword"></param>
        public SqlServerDatabase(String serverName, String databaseName, String userID, String password)
        {
            this.ConnectionString = SqlServerDatabaseConnectionString.Create(serverName, databaseName, userID, password, 100);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlServerDatabase(SqlServerDatabaseConnectionString connectionString)
        {
            this.ConnectionString = connectionString.Create();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return new SqlConnection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public override DbCommand CreateCommand()
        {
            return new SqlCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public override DbParameter CreateParameter(string name, Enum dbType, byte? precision, byte? scale)
        {
            if (dbType is SqlDbType)
            {
                var p = new SqlParameter(name, (SqlDbType)dbType);
                if (precision.HasValue == true) p.Precision = precision.Value;
                if (scale.HasValue == true) p.Scale = scale.Value;
                return p;
            }
            throw new ArgumentException("dbType must be SqlDbType.");
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected override Exception CreateException(Exception exception)
        {
            var ex = exception as SqlException;

            if (ex != null)
            {
                switch (ex.Number)
                {
                    case -2:
                        // Timeout. 
                        return new TimeoutException(ex);
                    case 17:
                        // SQL Server does not exist or access denied. 
                        return new ConnectionException(ex);
                    case 18456:
                        // Login Failed 
                        return new LoginException(ex);
                    case 547:
                        // ForeignKey Violation 
                        return new ForeignKeyException(ex);
                    case 1205:
                        // DeadLock Victim 
                        return new DeadLockException(ex);
                    case 1222:
                        // Lock timeout
                        return new LockTimeoutException(ex);
                    case 2601:
                    case 2627:
                        // Unique Index/Constriant Violation 
                        return new UniqueConstraintException(ex);
                }
                return new DatabaseException(ex);
            }
            return exception;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SqlBulkCopyContext CreateSqlBulkCopyContext()
        {
            return CreateSqlBulkCopyContext(SqlBulkCopyOptions.Default);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="copyOptions"></param>
        /// <returns></returns>
        public SqlBulkCopyContext CreateSqlBulkCopyContext(SqlBulkCopyOptions copyOptions)
        {
            if (this.Connection == null)
            {
                return new SqlBulkCopyContext(this.ConnectionString, copyOptions);
            }
            return new SqlBulkCopyContext(this.Connection as SqlConnection, copyOptions, this.Transaction as SqlTransaction);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="reader"></param>
        public void BulkCopy(String tableName, IDataReader reader)
        {
            var cx = CreateSqlBulkCopyContext();
            cx.SqlBulkCopy.DestinationTableName = tableName;
            BulkCopy(cx, reader);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="reader"></param>
        public void BulkCopy(SqlBulkCopyContext sqlBulkCopyContext, IDataReader reader)
        {
            var dr = reader;
            var state = ConnectionState;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object ec = null;

            if (sqlBulkCopyContext.Connection == null)
            {
                if (this.ConnectionString != sqlBulkCopyContext.ConnectionString) { throw new InvalidOperationException(); }
            }
            else
            {
                if (this.Connection != sqlBulkCopyContext.Connection) { throw new InvalidOperationException(); }
            }
            if (sqlBulkCopyContext.Transaction != null && this.Transaction != sqlBulkCopyContext.Transaction) { throw new InvalidOperationException(); }

            try
            {
                var e = SqlServerDatabase.OnCommandExecuting(new CommandExecutingEventArgs(MethodName.BulkCopy, ConnectionString, sqlBulkCopyContext));
                if (e != null && e.Cancel == true) { return; }
                ec = e.ExecutionContext;

                Open();
                var bc = sqlBulkCopyContext.SqlBulkCopy;
                startTime = DateTimeOffset.Now;
                bc.WriteToServer(dr);
                endTime = DateTimeOffset.Now;
                dr.Close();
            }
            catch (Exception exception)
            {
                this.CatchException(MethodName.BulkCopy, this.ConnectionString, exception, ec, sqlBulkCopyContext);
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Close();
                }
                ((IDisposable)sqlBulkCopyContext.SqlBulkCopy).Dispose();
            }
            if (startTime.HasValue == true && endTime.HasValue == true)
            {
                SqlServerDatabase.OnCommandExecuted(new CommandExecutedEventArgs(MethodName.BulkCopy, this.ConnectionString
                    , startTime.Value, endTime.Value, ec, sqlBulkCopyContext));
            }
        }

        private void CatchException(MethodName methodName, String connectionString, Exception exception, Object executionContext, SqlBulkCopyContext sqlBulkCopyContext)
        {
            var e = new CommandErrorEventArgs(methodName, connectionString, exception, executionContext, sqlBulkCopyContext);
            SqlServerDatabase.OnCommandError(e);
            if (e.ThrowException == true)
            {
                var ex = CreateException(e);
                throw ex;
            }
        }

    }
}

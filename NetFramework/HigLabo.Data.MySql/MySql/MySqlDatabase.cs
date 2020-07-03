using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace HigLabo.Data
{
    /// <summary>
    /// MYSQLサーバーへの接続及びデータ操作の機能を提供します。
    /// </summary>
    public partial class MySqlDatabase : Database
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public MySqlDatabase(String connectionString)
        {
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        public MySqlDatabase(String serverName, String databaseName)
        {
            this.ConnectionString = MySqlDatabaseConnectionString.Create(serverName, databaseName, 100);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        public MySqlDatabase(String serverName, String databaseName, String userID, String password)
        {
            this.ConnectionString = MySqlDatabaseConnectionString.Create(serverName, databaseName, userID, password, 100);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public MySqlDatabase(MySqlDatabaseConnectionString connectionString)
        {
            this.ConnectionString = connectionString.Create();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return new MySqlConnection();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public override DbCommand CreateCommand()
        {
            return new MySqlCommand();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return new MySqlDataAdapter();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public override DbParameter CreateParameter(string name, Enum dbType, byte? precision, byte? scale)
        {
            if (dbType is MySqlDbType)
            {
                var p = new MySqlParameter(name, (MySqlDbType)dbType);
                if (precision.HasValue == true) p.Precision = precision.Value;
                if (scale.HasValue == true) p.Scale = scale.Value;
                return p;
            }
            throw new ArgumentException("dbType must be MySqlDbType.");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public Int32 ExecuteCommand(MySqlScript script)
        {
            var affectRecordNumber = Int32.MinValue;
            ConnectionState state = this.ConnectionState;
            DateTimeOffset? startTime = null;
            DateTimeOffset? endTime = null;
            Object ec = null;

            try
            {
                var e = Database.OnCommandExecuting(new MySqlScriptExecutingEventArgs(this.ConnectionString, script));
                if (e != null && e.Cancel == true) { return -1; }
                ec = e.ExecutionContext;

                this.Open();
                script.Connection = this.Connection as MySqlConnection;
                startTime = DateTimeOffset.Now;
                affectRecordNumber = script.Execute();
                endTime = DateTimeOffset.Now;
            }
            catch (Exception ex)
            {
                this.CatchException(new MySqlScriptErrorEventArgs(this.ConnectionString, ex, ec, script));
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
                Database.OnCommandExecuted(new MySqlScriptExecutedEventArgs(this.ConnectionString
                    , startTime.Value, endTime.Value, ec, script));
            }
            return affectRecordNumber;
        }

        protected override Exception CreateException(Exception exception)
        {
            var ex = exception as MySql.Data.MySqlClient.MySqlException;
            switch (ex.ErrorCode)
            {
                case 1022: return new UniqueConstraintException(ex);
                case 1044:
                case 1045:
                    return new LoginException(ex);
                case 1159:
                case 1161:
                    return new TimeoutException(ex);
                case 1205:
                    return new LockTimeoutException(ex);
                case 1213:
                    return new DeadLockException(ex);
                case 1215:
                case 1216:
                case 1217:
                    return new ForeignKeyException(ex);
                case 2002:
                case 2003:
                    return new ConnectionException(ex);
                default: return new DatabaseException(exception);
            }
        }
        protected override Exception CreateException(CommandErrorEventArgs e)
        {
            var exception = base.CreateException(e);
            var ex = exception as DatabaseException;
            var ee = e as MySqlScriptErrorEventArgs;
            if (ex != null && ee != null)
            {
                ex.Data["MySqlScript"] = ee.MySqlScript;
            }
            return exception;
        }
    }
}

using System;
using System.Data.SqlClient;

namespace HigLabo.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlBulkCopyContext
    {
        internal String ConnectionString { get; private set; }
        internal SqlConnection Connection { get; private set; }
        internal SqlTransaction Transaction { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public SqlBulkCopy SqlBulkCopy { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public SqlBulkCopyContext(String connectionString)
        {
            ConnectionString = connectionString;
            SqlBulkCopy = new SqlBulkCopy(connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="copyOptions"></param>
        public SqlBulkCopyContext(String connectionString, SqlBulkCopyOptions copyOptions)
        {
            ConnectionString = connectionString;
            SqlBulkCopy = new SqlBulkCopy(connectionString, copyOptions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        public SqlBulkCopyContext(SqlConnection connection)
        {
            Connection = connection;
            SqlBulkCopy = new SqlBulkCopy(connection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="copyOptions"></param>
        /// <param name="transaction"></param>
        public SqlBulkCopyContext(SqlConnection connection, SqlBulkCopyOptions copyOptions, SqlTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
            SqlBulkCopy = new SqlBulkCopy(connection, copyOptions, transaction);
        }
    }
}
using System;
using Microsoft.Data.SqlClient;

namespace HigLabo.Data
{
    public class SqlBulkCopyContext
    {
        internal String ConnectionString { get; private set; }
        internal SqlConnection Connection { get; private set; }
        internal SqlTransaction Transaction { get; private set; }

        public SqlBulkCopy SqlBulkCopy { get; private set; }

        public SqlBulkCopyContext(String connectionString)
        {
            ConnectionString = connectionString;
            SqlBulkCopy = new SqlBulkCopy(connectionString);
        }
        public SqlBulkCopyContext(String connectionString, SqlBulkCopyOptions copyOptions)
        {
            ConnectionString = connectionString;
            SqlBulkCopy = new SqlBulkCopy(connectionString, copyOptions);
        }
        public SqlBulkCopyContext(SqlConnection connection)
        {
            Connection = connection;
            SqlBulkCopy = new SqlBulkCopy(connection);
        }
        public SqlBulkCopyContext(SqlConnection connection, SqlBulkCopyOptions copyOptions, SqlTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
            SqlBulkCopy = new SqlBulkCopy(connection, copyOptions, transaction);
        }
    }
}
using System;
using System.Text;

namespace HigLabo.Data
{
    public class SqlServerDatabaseConnectionString : IConnectionString
    {
        public String ServerName { get; set; } = String.Empty;
        public String DatabaseName { get; set; } = String.Empty;
        public String UserID { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
        public Boolean TrustedConnection { get; set; }
        public Int32? ConnectionTimeout { get; set; }
        public Boolean? MultipleActiveResultSets { get; set; }
        public String AttachDbFilename { get; set; } = String.Empty;
        public String FailoverPartner { get; set; } = "";
        public Boolean? AsynchronousProcessing { get; set; }

        public SqlServerDatabaseConnectionString()
        {
            this.ConnectionTimeout = null;
            this.TrustedConnection = false;
        }

        public String Create()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Server={0};", this.ServerName);
            sb.AppendFormat("Database={0};", this.DatabaseName);
            sb.AppendFormat("Trusted_Connection={0};", this.TrustedConnection);
            sb.AppendFormat("UID={0};", this.UserID);
            sb.AppendFormat("Password={0};", this.Password);
            if (this.ConnectionTimeout.HasValue == true)
            {
                sb.AppendFormat("Connection Timeout={0};", this.ConnectionTimeout);
            }
            if (this.MultipleActiveResultSets.HasValue == true)
            {
                sb.AppendFormat("MultipleActiveResultSets={0};", this.MultipleActiveResultSets);
            }
            if (String.IsNullOrEmpty(this.AttachDbFilename) == false)
            {
                sb.AppendFormat("AttachDbFilename={0};", this.AttachDbFilename);
            }
            if (String.IsNullOrEmpty(this.FailoverPartner) == false)
            {
                sb.AppendFormat("Failover Partner={0};", this.FailoverPartner);
            }
            if (this.AsynchronousProcessing.HasValue == true)
            {
                sb.AppendFormat("Asynchronous Processing={0};", this.AsynchronousProcessing);
            }

            return sb.ToString();
        }

        public static String Create(String serverName, String databaseName, String userID, String password)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.AppendFormat("UID={0};", userID);
            sb.AppendFormat("Password={0};", password);

            return sb.ToString();
        }
        public static String Create(String serverName, String databaseName, String userID, String password, Int32 connectionTimeout)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.AppendFormat("UID={0};", userID);
            sb.AppendFormat("Password={0};", password);
            sb.AppendFormat("Connection Timeout={0};", connectionTimeout);

            return sb.ToString();
        }
        public static String Create(String serverName, String databaseName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.Append("Trusted_Connection=true;");

            return sb.ToString();
        }
        public static String Create(String serverName, String databaseName, Int32 connectionTimeout)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.Append("Trusted_Connection=true;");
            sb.AppendFormat("Connection Timeout={0};", connectionTimeout);

            return sb.ToString();
        }
    }
}

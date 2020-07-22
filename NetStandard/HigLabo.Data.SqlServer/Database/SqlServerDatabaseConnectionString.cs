using System;
using System.Text;

namespace HigLabo.Data
{
    /// <summary>
    /// SQLサーバーへの接続文字列を生成する機能を提供するクラスです。
    /// </summary>
    public class SqlServerDatabaseConnectionString : IConnectionString
    {
        ///<summary>
        /// 
        ///</summary>
        public String ServerName { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public String DatabaseName { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public String UserID { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public String Password { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public Boolean TrustedConnection { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public Int32? ConnectionTimeout { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public Boolean? MultipleActiveResultSets { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public String AttachDbFilename { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public String FailoverPartner { get; set; }
        ///<summary>
        /// 
        ///</summary>
        public Boolean? AsynchronousProcessing { get; set; }

        ///<summary>
        /// 
        ///</summary>
        public SqlServerDatabaseConnectionString()
        {
            this.ConnectionTimeout = null;
            this.TrustedConnection = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// SqlServer用の接続文字列を作成します。
        /// </summary>
        /// <param name="serverName">サーバー名</param>
        /// <param name="databaseName">データベース名</param>
        /// <param name="userID">ユーザーＩＤ</param>
        /// <param name="password">パスワード</param>
        public static String Create(String serverName, String databaseName, String userID, String password)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.AppendFormat("UID={0};", userID);
            sb.AppendFormat("Password={0};", password);

            return sb.ToString();
        }
        /// <summary>
        /// SqlServer用の接続文字列を作成します。
        /// </summary>
        /// <param name="serverName">サーバー名</param>
        /// <param name="databaseName">データベース名</param>
        /// <param name="userID">ユーザーＩＤ</param>
        /// <param name="password">パスワード</param>
        /// <param name="connectionTimeout">タイムアウト</param>
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
        /// <summary>
        /// SqlServer用の接続文字列を作成します。
        /// </summary>
        /// <param name="serverName">サーバー名</param>
        /// <param name="databaseName">データベース名</param>
        public static String Create(String serverName, String databaseName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.Append("Trusted_Connection=true;");

            return sb.ToString();
        }
        /// <summary>
        /// SqlServer用の接続文字列を作成します。
        /// </summary>
        /// <param name="serverName">サーバー名</param>
        /// <param name="databaseName">データベース名</param>
        /// <param name="connectionTimeout">接続タイムアウト</param>
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

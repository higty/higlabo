using System;
using System.Text;

namespace HigLabo.Data
{
    /// <summary>
    /// SQLサーバーへの接続文字列を生成する機能を提供するクラスです。
    /// </summary>
    public class MySqlDatabaseConnectionString : IConnectionString
    {
        /// <summary>
        /// 
        /// </summary>
        public String Driver { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String ServerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String DatabaseName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String UserID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Boolean Encryption { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? ConnectionTimeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? DefaultCommandTimeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? Option { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String STMT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IgnorePrepare { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String CharSet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Protocol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String SharedMemoryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MySqlDatabaseConnectionString()
        {
            Driver = "{MySQL ODBC 3.51 Driver}";
            Option = null;
            STMT = "SET CHARACTER SET SJIS";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String Create()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Server={0};", ServerName);
            sb.AppendFormat("Database={0};", DatabaseName);
            if (Port.HasValue)
            {
                sb.AppendFormat("Port={0};", Port);
            }
            sb.AppendFormat("UID={0};", UserID);
            sb.AppendFormat("PWD={0};", Password);
            if (ConnectionTimeout.HasValue)
            {
                sb.AppendFormat("connection timeout={0};", ConnectionTimeout);
            }
            if (DefaultCommandTimeout.HasValue)
            {
                sb.AppendFormat("default command timeout={0};", DefaultCommandTimeout);
            }
            sb.AppendFormat("Option={0};", Option);
            if (String.IsNullOrEmpty(STMT) == false)
            {
                sb.AppendFormat("STMT={0};", STMT);
            }
            sb.AppendFormat("Ignore Prepare={0};", IgnorePrepare);
            if (String.IsNullOrEmpty(CharSet) == false)
            {
                sb.AppendFormat("CharSet={0};", CharSet);
            }
            if (string.IsNullOrEmpty(Protocol) == false)
            {
                sb.AppendFormat("Protocol={0};", Protocol);
            }
            if (String.IsNullOrEmpty(SharedMemoryName) == false)
            {
                sb.AppendFormat("Shared Memory Name={0};", SharedMemoryName);
            }

            return sb.ToString();
        }

        /// MySql用の接続文字列を作成します。
        /// <summary>
        /// MySql用の接続文字列を作成します。
        /// </summary>
        /// <param name="serverName">サーバー名</param>
        /// <param name="databaseName">データベース名</param>
        /// <param name="userID">ユーザーＩＤ</param>
        /// <param name="password">パスワード</param>
        public static String Create(String serverName, String databaseName, String userID, String password)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.AppendFormat("UID={0};", userID);
            sb.AppendFormat("PWD={0};", password);

            return sb.ToString();
        }

        /// MySql用の接続文字列を作成します。
        /// <summary>
        /// MySql用の接続文字列を作成します。
        /// </summary>
        /// <param name="serverName">サーバー名</param>
        /// <param name="databaseName">データベース名</param>
        /// <param name="userID">ユーザーＩＤ</param>
        /// <param name="password">パスワード</param>
        /// <param name="connectionTimeout">タイムアウト</param>
        public static String Create(String serverName, String databaseName, String userID, String password, Int32 connectionTimeout)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.AppendFormat("UID={0};", userID);
            sb.AppendFormat("PWD={0};", password);
            sb.AppendFormat("connection timeout={0};", connectionTimeout);

            return sb.ToString();
        }

        /// MySql用の接続文字列を作成します。
        /// <summary>
        /// MySql用の接続文字列を作成します。
        /// </summary>
        /// <param name="serverName">サーバー名</param>
        /// <param name="databaseName">データベース名</param>
        public static String Create(String serverName, String databaseName)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.Append("Trusted_Connection=true;");

            return sb.ToString();
        }

        /// MySql用の接続文字列を作成します。
        /// <summary>
        /// MySql用の接続文字列を作成します。
        /// </summary>
        /// <param name="serverName">サーバー名</param>
        /// <param name="databaseName">データベース名</param>
        /// <param name="connectionTimeout">接続タイムアウト</param>
        public static String Create(String serverName, String databaseName, Int32 connectionTimeout)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Server={0};", serverName);
            sb.AppendFormat("Database={0};", databaseName);
            sb.Append("Trusted_Connection=true;");
            sb.AppendFormat("connection timeout={0};", connectionTimeout);

            return sb.ToString();
        }
    }
}
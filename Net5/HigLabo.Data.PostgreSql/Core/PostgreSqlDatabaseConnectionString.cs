using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Data
{
    /// <summary>
    /// Postgreデータベースサーバーへの接続文字列を生成する機能を提供するクラスです。
    /// </summary>
    public class PostgreSqlDatabaseConnectionString : IConnectionString
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
        public Boolean Pooling { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? MinPoolSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? MaxPoolSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? ConnectionLifetime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? CommandTimeout { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? ConnectionTimeout { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Protocol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean Ssl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String SslMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PostgreSqlDatabaseConnectionString()
        {
            this.Driver = "PostgreSQL";
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
            if (this.Port.HasValue == true)
            {
                sb.AppendFormat("Port={0};", this.Port);
            }
            sb.AppendFormat("User ID={0};", this.UserID);
            sb.AppendFormat("Password={0};", this.Password);
            sb.AppendFormat("Pooling={0};", this.Pooling);
            if (this.MinPoolSize.HasValue == true)
            {
                sb.AppendFormat("Min Pool Size={0};", this.MinPoolSize);
            }
            if (this.MaxPoolSize.HasValue == true)
            {
                sb.AppendFormat("Max Pool Size={0};", this.MaxPoolSize);
            }
            if (this.ConnectionLifetime.HasValue == true)
            {
                sb.AppendFormat("Connection Lifetime={0};", this.ConnectionLifetime);
            }
            if (this.CommandTimeout.HasValue == true)
            {
                sb.AppendFormat("CommandTimeout={0};", this.CommandTimeout);
            }
            if (this.ConnectionTimeout.HasValue == true)
            {
                sb.AppendFormat("Timeout={0};", this.ConnectionTimeout);
            }
            if (String.IsNullOrEmpty(this.Protocol) == false)
            {
                sb.AppendFormat("Protocol={0};", this.Protocol);
            }
            sb.AppendFormat("SSL={0};", this.Ssl);
            if (String.IsNullOrEmpty(this.SslMode) == false)
            {
                sb.AppendFormat("SslMode={0};", this.SslMode);
            }

            return sb.ToString();
        }
        /// <summary>
        /// Postgre用の接続文字列を作成します。
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
            sb.AppendFormat("User ID={0};", userID);
            sb.AppendFormat("Password={0};", password);

            return sb.ToString();
        }
        /// <summary>
        /// Postgre用の接続文字列を作成します。
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
            sb.AppendFormat("User ID={0};", userID);
            sb.AppendFormat("Password={0};", password);
            sb.AppendFormat("Connection Timeout={0};", connectionTimeout);

            return sb.ToString();
        }
    }
}

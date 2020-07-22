using System;
using System.Text;

namespace HigLabo.Data
{
    /// <summary>
    /// Oracleデータベースへの接続文字列を生成する機能を提供するクラスです。
    /// </summary>
    public class OracleDatabaseConnectionString : IConnectionString
    {
        /// <summary>
        /// 
        /// </summary>
        public String DataSource { get; set; }
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
        public Int32? ConnectionTimeout { get; set; }
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
        public Int32? IncrPoolSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? DecrPoolSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean LoadBalancing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OracleDatabaseConnectionString()
        {
            ConnectionTimeout = null;
            LoadBalancing = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String Create()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Data Source={0};", DataSource);
            sb.AppendFormat("User ID={0};", UserID);
            sb.AppendFormat("Password={0};", Password);
            sb.AppendFormat("Pooling={0};", Pooling);
            if (MinPoolSize.HasValue)
            {
                sb.AppendFormat("Min Pool Size={0};", MinPoolSize);
            }
            if (MaxPoolSize.HasValue)
            {
                sb.AppendFormat("Max Pool Size={0};", MaxPoolSize);
            }
            if (IncrPoolSize.HasValue)
            {
                sb.AppendFormat("Incr Pool Size={0};", IncrPoolSize);
            }
            if (DecrPoolSize.HasValue)
            {
                sb.AppendFormat("Decr Pool Size={0};", DecrPoolSize);
            }
            if (ConnectionLifetime.HasValue)
            {
                sb.AppendFormat("ConnectionLifetime={0};", ConnectionLifetime);
            }
            sb.AppendFormat("Load Balancing={0};", LoadBalancing);

            return sb.ToString();
        }
        /// <summary>
        /// Oracle用の接続文字列を作成します。
        /// </summary>
        /// <param name="dataSource">データソース名</param>
        /// <param name="userID">ユーザーＩＤ</param>
        /// <param name="password">パスワード</param>
        public static String Create(String dataSource, String userID, String password)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Data Source={0};", dataSource);
            sb.AppendFormat("User ID={0};", userID);
            sb.AppendFormat("Password={0};", password);

            return sb.ToString();
        }
        /// <summary>
        /// Oracle用の接続文字列を作成します。
        /// </summary>
        /// <param name="dataSource">データソース名</param>
        /// <param name="userID">ユーザーＩＤ</param>
        /// <param name="password">パスワード</param>
        /// <param name="connectionTimeout">タイムアウト</param>
        public static String Create(String dataSource, String userID, String password, Int32 connectionTimeout)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Data Source={0};", dataSource);
            sb.AppendFormat("User ID={0};", userID);
            sb.AppendFormat("Password={0};", password);
            sb.AppendFormat("Connection Timeout={0};", connectionTimeout);

            return sb.ToString();
        }
        /// <summary>
        /// Oracle用の接続文字列を作成します。
        /// </summary>
        /// <param name="dataSource">データソース名</param>
        public static String Create(String dataSource)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Data Source={0};", dataSource);
            sb.Append("Trusted_Connection=true;");

            return sb.ToString();
        }
        /// <summary>
        /// Oracle用の接続文字列を作成します。
        /// </summary>
        /// <param name="dataSource">データソース名</param>
        /// <param name="connectionTimeout">接続タイムアウト</param>
        public static String Create(String dataSource, Int32 connectionTimeout)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Data Source={0};", dataSource);
            sb.Append("Trusted_Connection=true;");
            sb.AppendFormat("Connection Timeout={0};", connectionTimeout);

            return sb.ToString();
        }
    }
}
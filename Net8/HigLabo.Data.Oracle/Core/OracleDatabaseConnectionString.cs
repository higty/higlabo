using System;
using System.Text;

namespace HigLabo.Data
{
    public class OracleDatabaseConnectionString : IConnectionString
    {
        public String DataSource { get; set; } = "";
        public String UserID { get; set; } = "";
        public String Password { get; set; } = "";
        public Int32? ConnectionTimeout { get; set; }
        public Boolean Pooling { get; set; }
        public Int32? MinPoolSize { get; set; }
        public Int32? MaxPoolSize { get; set; }
        public Int32? ConnectionLifetime { get; set; }
        public Int32? IncrPoolSize { get; set; }
        public Int32? DecrPoolSize { get; set; }
        public Boolean LoadBalancing { get; set; }

        public OracleDatabaseConnectionString()
        {
            ConnectionTimeout = null;
            LoadBalancing = false;
        }

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

        public static String Create(String dataSource, String userID, String password)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Data Source={0};", dataSource);
            sb.AppendFormat("User ID={0};", userID);
            sb.AppendFormat("Password={0};", password);

            return sb.ToString();
        }
        public static String Create(String dataSource, String userID, String password, Int32 connectionTimeout)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Data Source={0};", dataSource);
            sb.AppendFormat("User ID={0};", userID);
            sb.AppendFormat("Password={0};", password);
            sb.AppendFormat("Connection Timeout={0};", connectionTimeout);

            return sb.ToString();
        }
        public static String Create(String dataSource)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Data Source={0};", dataSource);
            sb.Append("Trusted_Connection=true;");

            return sb.ToString();
        }
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
using System;
using System.Text;

namespace HigLabo.Data;

public class MySqlDatabaseConnectionString : IConnectionString
{
    public String Driver { get; set; } = "";
    public String ServerName { get; set; } = "";
    public String DatabaseName { get; set; } = "";
    public Int32? Port { get; set; }
    public String UserID { get; set; } = "";
    public String Password { get; set; } = "";
    public Boolean Encryption { get; set; }
    public Int32? ConnectionTimeout { get; set; }
    public Int32? DefaultCommandTimeout { get; set; }
    public Int32? Option { get; set; }
    public String STMT { get; set; } = "";
    public Boolean IgnorePrepare { get; set; } 
    public String CharSet { get; set; } = "";
    public String Protocol { get; set; } = "";
    public String SharedMemoryName { get; set; } = "";

    public MySqlDatabaseConnectionString()
    {
        Driver = "{MySQL ODBC 3.51 Driver}";
        Option = null;
        STMT = "SET CHARACTER SET SJIS";
    }

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

    public static String Create(String serverName, String databaseName, String userID, String password)
    {
        var sb = new StringBuilder();

        sb.AppendFormat("Server={0};", serverName);
        sb.AppendFormat("Database={0};", databaseName);
        sb.AppendFormat("UID={0};", userID);
        sb.AppendFormat("PWD={0};", password);

        return sb.ToString();
    }
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
    public static String Create(String serverName, String databaseName)
    {
        var sb = new StringBuilder();

        sb.AppendFormat("Server={0};", serverName);
        sb.AppendFormat("Database={0};", databaseName);
        sb.Append("Trusted_Connection=true;");

        return sb.ToString();
    }
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
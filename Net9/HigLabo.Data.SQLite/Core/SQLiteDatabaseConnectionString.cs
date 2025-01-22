using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace HigLabo.Data;

public class SQLiteDatabaseConnectionString
{
    public int? Version { get; set; }
    public SqliteOpenMode? Mode { get; set; }

    public bool? Pooling { get; set; }
    public string DataSource { get; set; } = "";
    public int? DefaultTimeout { get; set; }
    public string Password { get; set; } = "";
    public bool? RecursiveTriggers { get; set; }
    public bool? ForeignKeys { get; set; }

    public string Create()
    {
        var sb = new SqliteConnectionStringBuilder();
        if (Pooling.HasValue) sb.Pooling = Pooling.Value;
        if (Mode.HasValue) sb.Mode = Mode.Value;
        if (!String.IsNullOrEmpty(DataSource)) sb.DataSource = DataSource;
        if (DefaultTimeout.HasValue) sb.DefaultTimeout = DefaultTimeout.Value;
        if (!String.IsNullOrEmpty(Password)) sb.Password = Password;
        if (RecursiveTriggers.HasValue) sb.RecursiveTriggers = RecursiveTriggers.Value;
        if (ForeignKeys.HasValue) sb.ForeignKeys = ForeignKeys.Value;

        return sb.ToString();
    }

    public static string Create(string filePath)
    {
        return new SQLiteDatabaseConnectionString { DataSource = filePath }.Create();
    }
    public static string Create(string filePath, string password)
    {
        return new SQLiteDatabaseConnectionString { DataSource = filePath, Password = password }.Create();
    }
}
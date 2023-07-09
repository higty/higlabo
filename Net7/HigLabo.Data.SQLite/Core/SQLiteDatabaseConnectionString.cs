using System;
using System.Data;
using System.Data.SQLite;

namespace HigLabo.Data
{
    public class SQLiteDatabaseConnectionString
    {
        public int? Version { get; set; }
        public SynchronizationModes? SyncMode { get; set; }
        public bool? UseUTF16Encoding { get; set; }
        public bool? Pooling { get; set; }
        public bool? BinaryGUID { get; set; }
        public string DataSource { get; set; } = "";
        public string Uri { get; set; } = "";
        public string FullUri { get; set; } = "";
        public int? DefaultTimeout { get; set; }
        public bool? Enlist { get; set; }
        public bool? FailIfMissing { get; set; }
        public bool? LegacyFormat { get; set; }
        public bool? ReadOnly { get; set; }
        public string Password { get; set; } = "";
        public int? PageSize { get; set; }
        public int? MaxPageCount { get; set; }
        public int? CacheSize { get; set; }
        public SQLiteDateFormats? DateTimeFormat { get; set; }
        public DateTimeKind? DateTimeKind { get; set; }
        public string BaseSchemaName { get; set; } = "";
        public SQLiteJournalModeEnum? JournalMode { get; set; }
        public IsolationLevel? DefaultIsolationLevel { get; set; }
        public bool? ForeignKeys { get; set; }
        public SQLiteConnectionFlags? Flags { get; set; }
        public bool? SetDefaults { get; set; }
        public bool? ToFullPath { get; set; }

        public string Create()
        {
            var sb = new SQLiteConnectionStringBuilder();
            if (Version.HasValue) sb.Version = Version.Value;
            if (SyncMode.HasValue) sb.SyncMode = SyncMode.Value;
            if (UseUTF16Encoding.HasValue) sb.UseUTF16Encoding = UseUTF16Encoding.Value;
            if (Pooling.HasValue) sb.Pooling = Pooling.Value;
            if (BinaryGUID.HasValue) sb.BinaryGUID = BinaryGUID.Value;
            if (!String.IsNullOrEmpty(DataSource)) sb.DataSource = DataSource;
            if (!String.IsNullOrEmpty(Uri)) sb.Uri = Uri;
            if (!String.IsNullOrEmpty(FullUri)) sb.FullUri = FullUri;
            if (DefaultTimeout.HasValue) sb.DefaultTimeout = DefaultTimeout.Value;
            if (Enlist.HasValue) sb.Enlist = Enlist.Value;
            if (FailIfMissing.HasValue) sb.FailIfMissing = FailIfMissing.Value;
            if (LegacyFormat.HasValue) sb.LegacyFormat = LegacyFormat.Value;
            if (ReadOnly.HasValue) sb.ReadOnly = ReadOnly.Value;
            if (!String.IsNullOrEmpty(Password)) sb.Password = Password;
            if (PageSize.HasValue) sb.PageSize = PageSize.Value;
            if (MaxPageCount.HasValue) sb.MaxPageCount = MaxPageCount.Value;
            if (CacheSize.HasValue) sb.CacheSize = CacheSize.Value;
            if (DateTimeFormat.HasValue) sb.DateTimeFormat = DateTimeFormat.Value;
            if (DateTimeKind.HasValue) sb.DateTimeKind = DateTimeKind.Value;
            if (!String.IsNullOrEmpty(BaseSchemaName)) sb.BaseSchemaName = BaseSchemaName;
            if (JournalMode.HasValue) sb.JournalMode = JournalMode.Value;
            if (DefaultIsolationLevel.HasValue) sb.DefaultIsolationLevel = DefaultIsolationLevel.Value;
            if (ForeignKeys.HasValue) sb.ForeignKeys = ForeignKeys.Value;
            if (Flags.HasValue) sb.Flags = Flags.Value;
            if (SetDefaults.HasValue) sb.SetDefaults = SetDefaults.Value;
            if (ToFullPath.HasValue) sb.ToFullPath = ToFullPath.Value;

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
}
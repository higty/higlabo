using System;
using System.Data;
using System.Data.SQLite;

namespace HigLabo.Data
{
    /// <summary>
    /// SQLiteデータベースへの接続文字列を作成するクラスです。
    /// </summary>
    public class SQLiteDatabaseConnectionString
    {
        /// <summary>
        /// 接続文字列の作成を行います。
        /// </summary>
        /// <param name="filePath">ファイルパス。</param>
        /// <returns>接続文字列。</returns>
        public static string Create(string filePath)
        {
            return new SQLiteDatabaseConnectionString { DataSource = filePath }.Create();
        }
        /// <summary>
        /// 接続文字列の作成を行います。
        /// </summary>
        /// <param name="filePath">ファイルパス。</param>
        /// <param name="password">パスワード。</param>
        /// <returns>接続文字列。</returns>
        public static string Create(string filePath, string password)
        {
            return new SQLiteDatabaseConnectionString { DataSource = filePath, Password = password }.Create();
        }

        /// <summary>
        /// バージョンを取得または設定します。
        /// </summary>
        public int? Version { get; set; }
        /// <summary>
        /// データベースの同期処理モードを取得または設定します。
        /// </summary>
        public SynchronizationModes? SyncMode { get; set; }
        /// <summary>
        /// 内部エンコーディングにUTF16を使用するかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? UseUTF16Encoding { get; set; }
        /// <summary>
        /// コネクションプーリングを使用するかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? Pooling { get; set; }
        /// <summary>
        /// GUIDをバイナリ形式で保存するかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? BinaryGUID { get; set; }
        /// <summary>
        /// データソースを取得または設定します。
        /// </summary>
        public string DataSource { get; set; }
        /// <summary>
        /// Uriを取得または設定します。
        /// </summary>
        public string Uri { get; set; }
        /// <summary>
        /// FullUriを取得または設定します。
        /// </summary>
        public string FullUri { get; set; }
        /// <summary>
        /// デフォルトのタイムアウト時間を取得または設定します。
        /// </summary>
        public int? DefaultTimeout { get; set; }
        /// <summary>
        /// 分散トランザクションを使用するかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? Enlist { get; set; }
        /// <summary>
        /// 指定したデータベースが存在しない場合、エラーとするかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? FailIfMissing { get; set; }
        /// <summary>
        /// 古いバージョンに対応するかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? LegacyFormat { get; set; }
        /// <summary>
        /// データベースを読み取り専用として開くかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? ReadOnly { get; set; }
        /// <summary>
        /// パスワードを取得または設定します。
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// ページのサイズを取得または設定します。
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// データベースの最大ページ数を取得または設定します。
        /// </summary>
        public int? MaxPageCount { get; set; }
        /// <summary>
        /// キャッシュのサイズを取得または設定します。
        /// </summary>
        public int? CacheSize { get; set; }
        /// <summary>
        /// 日付フォーマットを取得または設定します。
        /// </summary>
        public SQLiteDateFormats? DateTimeFormat { get; set; }
        /// <summary>
        /// 時刻の種類を取得または設定します。
        /// </summary>
        public DateTimeKind? DateTimeKind { get; set; }
        /// <summary>
        /// BaseSchemaNameを取得または設定します。
        /// </summary>
        public string BaseSchemaName { get; set; }
        /// <summary>
        /// ジャーナルファイルの扱いを取得または設定します。
        /// </summary>
        public SQLiteJournalModeEnum? JournalMode { get; set; }
        /// <summary>
        /// 既定の分離レベルを取得または設定します。
        /// </summary>
        public IsolationLevel? DefaultIsolationLevel { get; set; }
        /// <summary>
        /// 外部キーを使用するかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? ForeignKeys { get; set; }
        /// <summary>
        /// フラグを取得または設定します。
        /// </summary>
        public SQLiteConnectionFlags? Flags { get; set; }
        /// <summary>
        /// デフォルトをセットするかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? SetDefaults { get; set; }
        /// <summary>
        /// フルパスにするかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? ToFullPath { get; set; }

        /// <summary>
        /// 接続文字列の作成を行います。
        /// </summary>
        /// <returns>接続文字列。</returns>
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
    }
}
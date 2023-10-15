using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;
using HigLabo.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace HigLabo.Core
{
    public class ErrorLogTable : BigQueryTable
    {
        public class RegexList
        {
            public static Regex Alphabet = new Regex("[A-Za-z0-9]", RegexOptions.IgnoreCase);
        }
        public class Record
        {
            public Guid LogId { get; set; }
            public DateTimeOffset ExecuteTime { get; set; }
            public String ExceptionType { get; set; } = "";
            public String Message { get; set; } = "";
            public String Description { get; set; } = "";
            public Int32 ErrorLevel { get; set; }
            public String MachineName { get; set; } = "";
            public String ProcessName { get; set; } = "";
            public Int32 ProcessId { get; set; }
            public String ThreadName { get; set; } = "";
            public Int32 ThreadId { get; set; }
            public String UserId { get; set; } = "";

            public static Record Create(Exception exception, String userId)
            {
                return Create(exception, 0, userId, "");
            }
            public static Record Create(Exception exception, Int32 errorLevel)
            {
                return Create(exception, errorLevel, "", "");
            }
            public static Record Create(Exception exception, Int32 errorLevel, string userId)
            {
                return Create(exception, errorLevel, userId, "");
            }
            public static Record Create(Exception exception, Int32 errorLevel, string userId, String message)
            {
                var r = new Record();
                r.LogId = SequentialGuid.NewGuid();
                r.ExceptionType = exception.GetType().Name;
                r.ExecuteTime = DateTimeOffset.Now;
                r.MachineName = Environment.MachineName;
                r.ProcessName = Process.GetCurrentProcess().ProcessName;
                r.ThreadName = Thread.CurrentThread.Name ?? "";
                r.ThreadId = Thread.CurrentThread.ManagedThreadId;
                r.UserId = userId;
                r.ErrorLevel = errorLevel;
                if (message.IsNullOrEmpty())
                {
                    r.Message = exception.Message;
                }
                else
                {
                    r.Message = message + Environment.NewLine + exception.Message;
                }
                r.Description = exception.ToString();

                return r;
            }
        }

        public ErrorLogTable(BigqueryService service, String projectId, String datasetId)
            : base(service, projectId, datasetId)
        { }

        public static String CreateTableName(DateOnly date)
        {
            return CreateTableName(date.ToString("yyyyMMdd"));
        }
        public static String CreateTableName(String dateSuffix)
        {
            return "ErrorLog_" + dateSuffix;
        }
        public async ValueTask<Boolean> ExistsAsync(DateOnly date)
        {
            var tableName = CreateTableName(date);
            return await this.ExistsAsync(tableName);
        }
        public async ValueTask<Table> CreateAsync(DateOnly date)
        {
            var sv = this.BigqueryService;
            var name = CreateTableName(date);
            var t = new Table
            {
                FriendlyName = name,
                Description = "Error log table",
                Schema = new TableSchema
                {
                    Fields = CreateTableFieldSchemaList()
                },
                TableReference = new TableReference
                {
                    ProjectId = this.ProjectId,
                    DatasetId = this.DatasetId,
                    TableId = name,
                }
            };
            var req = sv.Tables.Insert(t, this.ProjectId, this.DatasetId);
            var result = await req.ExecuteAsync();
            return result;
        }
        protected override TableFieldSchema[] CreateTableFieldSchemaList()
        {
            var l = new List<TableFieldSchema>();

            l.Add(new TableFieldSchema() { Name = "LogId", Type = "STRING", Mode = "REQUIRED" });
            l.Add(new TableFieldSchema() { Name = "ExecuteTime", Type = "TIMESTAMP", Mode = "REQUIRED" });
            l.Add(new TableFieldSchema() { Name = "ExceptionType", Type = "STRING", Mode = "REQUIRED" });
            l.Add(new TableFieldSchema() { Name = "Message", Type = "STRING" });
            l.Add(new TableFieldSchema() { Name = "Description", Type = "STRING" });
            l.Add(new TableFieldSchema() { Name = "ErrorLevel", Type = "INTEGER", Mode = "REQUIRED" });
            l.Add(new TableFieldSchema() { Name = "MachineName", Type = "STRING" });
            l.Add(new TableFieldSchema() { Name = "ProcessName", Type = "STRING" });
            l.Add(new TableFieldSchema() { Name = "ProcessId", Type = "INTEGER", Mode = "REQUIRED" });
            l.Add(new TableFieldSchema() { Name = "ThreadName", Type = "STRING" });
            l.Add(new TableFieldSchema() { Name = "ThreadId", Type = "INTEGER", Mode = "REQUIRED" });
            l.Add(new TableFieldSchema() { Name = "UserId", Type = "STRING" });

            return l.ToArray();
        }
        private static String CreateSelectClause()
        {
            return @"select LogId,ExecuteTime,ExceptionType,Message,Description
,ErrorLevel,MachineName,ProcessName,ProcessId,ThreadName,ThreadId,UserId";
        }
        private String CreateSelectFromClause(string dateSuffix)
        {
            return $"{CreateSelectClause()} {CreateFromClause(dateSuffix)}";
        }
        private String CreateFromClause(string dateSuffix)
        {
            return $"from `{this.ProjectId}.{this.DatasetId}.{CreateTableName(dateSuffix)}`";
        }

        public async ValueTask<TableDataInsertAllResponse?> InsertAsync(Record record)
        {
            var l = await InsertAsync(new Record[] { record });
            return l.FirstOrDefault();
        }
        public async ValueTask<List<TableDataInsertAllResponse>> InsertAsync(IEnumerable<Record> records)
        {
            var l = new List<TableDataInsertAllResponse>();
            foreach (var item in records.GroupBy(el => el.ExecuteTime.UtcDateTime.Date))
            {
                var date = DateOnly.FromDateTime(item.Key);
                try
                {
                    var res = await base.InsertAsync(CreateTableName(date)
                        , records.Select(el => el.Map(new Dictionary<string, object>())));
                    l.Add(res);
                }
                catch
                {
                    await this.EnsureTable(date);
                    var res = await base.InsertAsync(CreateTableName(date)
                        , records.Select(el => el.Map(new Dictionary<string, object>())));
                    l.Add(res);
                }
            }
            return l;
        }
        private async ValueTask EnsureTable(DateOnly date)
        {
            if (await this.ExistsAsync(date) == false)
            {
                try
                {
                    await this.CreateAsync(date);
                }
                catch { }
            }
        }

        public async ValueTask<(List<Record> Records, string query, UInt64 TotalRecordCount)> List_Data_Get(DateOnly date, Guid? userId, String exceptionType, Int32? errorLevel
            , DateTime startTime, DateTime endTime, Int32 startIndex, Int32 recordCount)
        {
            return await this.List_Data_Get(date, userId, exceptionType, errorLevel, startTime, endTime, startIndex, recordCount, Array.Empty<string>());
        }
        public async ValueTask<(List<Record> Records, string query, UInt64 TotalRecordCount)> List_Data_Get(DateOnly date, Guid? userId, String exceptionType, Int32? errorLevel
            , DateTime startTime, DateTime endTime, Int32 startIndex, Int32 recordCount, IEnumerable<String> whereConditionList)
        {
            return await this.List_Data_Get(date.ToString("yyyyMMdd"), userId, exceptionType, errorLevel, startTime, endTime, startIndex, recordCount, whereConditionList);
        }
        public async ValueTask<(List<Record> Records, string query, UInt64 TotalRecordCount)> List_Data_Get(string dateSuffix, Guid? userId, String exceptionType, Int32? errorLevel
            , DateTime startTime, DateTime endTime, Int32 startIndex, Int32 recordCount, IEnumerable<String> whereConditionList)
        {
            if (startIndex < 0) { throw new ArgumentOutOfRangeException("startIndex must be larger than zero."); }
            if (recordCount < 0) { throw new ArgumentOutOfRangeException("recordCount must be larger than zero."); }

            var l = new List<Record>();

            var sv = this.BigqueryService;
            var req = this.CreateQueryRequest();

            var where = new StringBuilder();
            where.AppendFormat("where (ExecuteTime >= '{0}' and ExecuteTime < '{1}')"
                , startTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            where.AppendLine();
            if (userId.HasValue)
            {
                where.AppendFormat("and UserId = '{0}' ", userId).AppendLine();
            }
            if (errorLevel.HasValue)
            {
                where.AppendFormat("and ErrorLevel >= {0} ", errorLevel).AppendLine();
            }
            if (exceptionType.IsNullOrEmpty() == false &&
                RegexList.Alphabet.IsMatch(exceptionType))
            {
                where.AppendFormat("and ExceptionType = '{0}' ", exceptionType).AppendLine();
            }
            foreach (var item in whereConditionList)
            {
                where.AppendLine(item);
            }

            var sb = new StringBuilder();
            sb.AppendLine(CreateSelectFromClause(dateSuffix));
            sb.AppendLine(where.ToString());
            sb.AppendLine("order by ExecuteTime desc");
            sb.AppendFormat("limit {0} offset {1}", recordCount, startIndex).AppendLine();
            req.Query = sb.ToString();
            {
                var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
                foreach (var d in res.CreateRecords())
                {
                    var r = d.Map(new Record());
                    l.Add(r);
                }
            }

            sb.Clear();
            sb.Append("select COUNT(*) as RecordCount ");
            sb.AppendLine(CreateFromClause(dateSuffix));
            sb.AppendLine(where.ToString());
            req.Query = sb.ToString();
            {
                var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
                var rr = res.CreateRecords();
                if (rr.Count == 0)
                {
                    return (l, req.Query, 0);
                }
                var d = rr[0];
                var totalRecordCount = d["RecordCount"]?.ToString()?.ToUInt64() ?? 0;
                return (l, req.Query, totalRecordCount);
            }
        }
        public async ValueTask<Record?> Data_Get(DateOnly date, Guid logId)
        {
            return await this.Data_Get(date.ToString("yyyyMMdd"), logId);
        }
        public async ValueTask<Record?> Data_Get(String dateSuffix, Guid logId)
        {
            var sv = this.BigqueryService;
            var req = this.CreateQueryRequest();
            req.UseQueryCache = true;

            var sb = new StringBuilder();
            sb.AppendLine(CreateSelectFromClause(dateSuffix));
            sb.AppendFormat("where LogId = '{0}'", logId);
            req.Query = sb.ToString();

            var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
            var l = new List<Record>();
            foreach (var d in res.CreateRecords())
            {
                return d.Map(new Record());
            }
            return null;
        }
        public async ValueTask<(List<Record> records, UInt64 totalRecordCount)> Search_Description_Get(DateOnly date, String searchText, Int32 startIndex, Int32 recordCount)
        {
            await this.EnsureTable(date);
            return await this.Search_Description_Get(date.ToString("yyyyMMdd"), searchText, startIndex, recordCount);
        }
        public async ValueTask<(List<Record> records, UInt64 totalRecordCount)> Search_Description_Get(String dateSuffix, String searchText, Int32 startIndex, Int32 recordCount)
        {
            if (startIndex < 0) { throw new ArgumentOutOfRangeException("startIndex must be larger than zero."); }
            if (recordCount < 0) { throw new ArgumentOutOfRangeException("recordCount must be larger than zero."); }

            var l = new List<Record>();

            var sv = this.BigqueryService;
            var req = this.CreateQueryRequest();

            var where = new StringBuilder();
            where.AppendFormat("where Description like '{0}'", searchText);

            var sb = new StringBuilder();
            sb.AppendLine(CreateSelectFromClause(dateSuffix));
            sb.AppendLine(where.ToString());
            sb.AppendLine("order by ExecuteTime desc");
            sb.AppendFormat("limit {0} offset {1}", recordCount, startIndex).AppendLine();
            req.Query = sb.ToString();
            {
                var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
                foreach (var d in res.CreateRecords())
                {
                    var r = d.Map(new Record());
                    l.Add(r);
                }
            }

            sb.Clear();
            sb.Append("select COUNT(*) as RecordCount ");
            sb.AppendLine(CreateFromClause(dateSuffix));
            sb.AppendLine(where.ToString());
            req.Query = sb.ToString();
            {
                var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
                UInt64 totalRecordCount = 0;
                var dd = res.CreateRecords();
                if (dd.Count > 0)
                {
                    var d = dd[0];
                    totalRecordCount = d["RecordCount"]?.ToString()?.ToUInt64() ?? 0;
                }
                return (l, totalRecordCount);
            }
        }

        public async ValueTask<Boolean> DeleteAsync(DateOnly date, Guid logId)
        {
            var sv = this.BigqueryService;
            var req = this.CreateQueryRequest();
            var sql = String.Format("Delete From {0} Where LogId = '{1}'", CreateTableName(date), logId);

            req.Query = sql;
            try
            {
                var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
            }
            catch (Exception ex)
            {
                var message = ex.ToString();
            }
            return true;
        }
    }
}

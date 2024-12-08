using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;
using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HigLabo.Core;

public class WebAccessLogTable : BigQueryTable
{
    public class Record
    {
        public Guid LogId { get; set; }
        public DateTimeOffset BeginRequestTime { get; set; }
        public DateTimeOffset EndRequestTime { get; set; }
        public Double RequestDurationMilliSeconds { get; set; }

        public String RequestUrl { get; set; } = "";
        public String HttpMethodName { get; set; } = "";
        public Boolean IsAjaxRequest { get; set; }
        public Int32 RequestLength { get; set; }
        public Int32 ResponseLength { get; set; }
        public String RequestHeaderData { get; set; } = "";
        public String RequestBodyData { get; set; } = "";
        public Int32 ResponseStatusCode { get; set; }

        public String MachineName { get; set; } = "";
        public String ProcessName { get; set; } = "";
        public Int32 ProcessId { get; set; }
        public String ThreadName { get; set; } = "";
        public Int32 ThreadId { get; set; }

        public String UserId { get; set; } = "";
        public String UserHostAddress { get; set; } = "";
        public String UserHostName { get; set; } = "";
        public String UserAgent { get; set; } = "";
        public String Referer { get; set; } = "";
        public Guid? ErrorLogId { get; set; }
    }

    public WebAccessLogTable(BigqueryService service, String projectId, String datasetId)
        : base(service, projectId, datasetId)
    { }

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
            Description = "Access log table",
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
    public static String CreateTableName(DateOnly date)
    {
        return CreateTableName(date.ToString("yyyyMMdd"));
    }
    public static String CreateTableName(string dateSuffix)
    {
        return "WebAccessLog_" + dateSuffix;
    }
    protected override TableFieldSchema[] CreateTableFieldSchemaList()
    {
        var l = new List<TableFieldSchema>();

        l.Add(new TableFieldSchema() { Name = "LogId", Type = "STRING", Mode = "REQUIRED" });
        l.Add(new TableFieldSchema() { Name = "BeginRequestTime", Type = "TIMESTAMP", Mode = "REQUIRED" });
        l.Add(new TableFieldSchema() { Name = "EndRequestTime", Type = "TIMESTAMP" });
        l.Add(new TableFieldSchema() { Name = "RequestDurationMilliSeconds", Type = "FLOAT64" });

        l.AddRange(CreateTableFields("STRING", new String[] { "RequestUrl", "HttpMethodName" }));
        l.Add(new TableFieldSchema() { Name = "IsAjaxRequest", Type = "BOOL" });
        l.AddRange(CreateTableFields("INTEGER", new String[] { "RequestLength", "ResponseLength" }));
        l.AddRange(CreateTableFields("STRING", new String[] { "RequestHeaderData", "RequestBodyData" }));
        l.Add(new TableFieldSchema() { Name = "ResponseStatusCode", Type = "INTEGER", Mode = "REQUIRED" });

        l.Add(new TableFieldSchema() { Name = "MachineName", Type = "STRING" });
        l.Add(new TableFieldSchema() { Name = "ProcessName", Type = "STRING" });
        l.Add(new TableFieldSchema() { Name = "ProcessId", Type = "INTEGER", Mode = "REQUIRED" });
        l.Add(new TableFieldSchema() { Name = "ThreadName", Type = "STRING" });
        l.Add(new TableFieldSchema() { Name = "ThreadId", Type = "INTEGER", Mode = "REQUIRED" });

        l.AddRange(CreateTableFields("STRING", new String[] {
            "UserId", "UserHostAddress", "UserHostName", "UserAgent", "UserAgentType"
            , "Referer", "ErrorLogId"}));

        return l.ToArray();
    }
    private static String CreateSelectClause()
    {
        return @"select LogId,RequestUrl,HttpMethodName,IsAjaxRequest,RequestLength,ResponseLength
,BeginRequestTime,EndRequestTime,RequestDurationMilliSeconds
,MachineName,ProcessName,ProcessId,ThreadName,ThreadId
,UserId,UserHostAddress,UserHostName,UserAgent,UserAgentType,Referer
,ErrorLogId,RequestHeaderData,RequestBodyData,ResponseStatusCode";
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
        foreach (var item in records.GroupBy(el => el.BeginRequestTime.UtcDateTime.Date))
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
    public async ValueTask EnsureTable(DateOnly date)
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


    public async Task<(List<Record> Records, string Query, UInt64 TotalRecordCount)> List_Data_Get(DateOnly date, Guid? userId, DateTime startTime, DateTime endTime
        , Int32 startIndex, Int32 recordCount, CancellationToken cancellationToken)
    {
        return await this.List_Data_Get(date, userId, startTime, endTime, startIndex, recordCount, Array.Empty<string>(), cancellationToken);
    }
    public async Task<(List<Record> Records, string Query, UInt64 TotalRecordCount)> List_Data_Get(DateOnly date, Guid? userId, DateTime startTime, DateTime endTime
        , Int32 startIndex, Int32 recordCount, IEnumerable<String> whereConditionList, CancellationToken cancellationToken)
    {
        await this.EnsureTable(date);
        return await this.List_Data_Get(date.ToString("yyyyMMdd"), userId, startTime, endTime, startIndex, recordCount, whereConditionList, cancellationToken);
    }
    public async Task<(List<Record> Records, string Query, UInt64 TotalRecordCount)> List_Data_Get(string dateSuffix, Guid? userId, DateTime startTime, DateTime endTime
        , Int32 startIndex, Int32 recordCount, IEnumerable<String> whereConditionList, CancellationToken cancellationToken)
    {
        if (startIndex < 0) { throw new ArgumentOutOfRangeException("startIndex must be larger than zero."); }
        if (recordCount < 0) { throw new ArgumentOutOfRangeException("recordCount must be larger than zero."); }

        var l = new List<Record>();

        var sv = this.BigqueryService;
        var req = this.CreateQueryRequest();

        var where = new StringBuilder();
        where.AppendFormat("where (BeginRequestTime >= '{0}' and BeginRequestTime < '{1}')"
            , startTime.ToString("yyyy-MM-dd HH:mm:ss")
            , endTime.ToString("yyyy-MM-dd HH:mm:ss"));
        where.AppendLine();
        if (userId.HasValue)
        {
            where.AppendFormat("and UserId = '{0}' ", userId).AppendLine();
        }
        foreach (var item in whereConditionList)
        {
            where.AppendLine(item);
        }

        var sb = new StringBuilder();
        sb.AppendLine(CreateSelectFromClause(dateSuffix));
        sb.AppendLine(where.ToString());
        sb.AppendLine("order by BeginRequestTime desc");
        sb.AppendFormat("limit {0} offset {1}", recordCount, startIndex).AppendLine();
        req.Query = sb.ToString();
        {
            var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync(cancellationToken);
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
            var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync(cancellationToken);
            var dd = res.CreateRecords();
            UInt64 totalRecordCount = 0;
            if (dd.Count > 0)
            {
                var d = dd[0];
                totalRecordCount = d["RecordCount"]?.ToString()?.ToUInt64() ?? 0;
            }
            return (l, req.Query, totalRecordCount);
        }
    }
    public async Task<(List<Record> Records, string Query, UInt64 TotalRecordCount)> List_Data_Get(DateOnly startDate, DateOnly endDate, Guid? userId, DateTime startTime, DateTime endTime
        , Int32 startIndex, Int32 recordCount, CancellationToken cancellationToken)
    {
        return await this.List_Data_Get(startDate, endDate, userId, startTime, endTime, startIndex, recordCount, Array.Empty<string>(), cancellationToken);
    }
    public async Task<(List<Record> Records, string Query, UInt64 TotalRecordCount)> List_Data_Get(DateOnly startDate, DateOnly endDate, Guid? userId, DateTime startTime, DateTime endTime
        , Int32 startIndex, Int32 recordCount, IEnumerable<String> whereConditionList, CancellationToken cancellationToken)
    {
        if (startIndex < 0) { throw new ArgumentOutOfRangeException("startIndex must be larger than zero."); }
        if (recordCount < 0) { throw new ArgumentOutOfRangeException("recordCount must be larger than zero."); }

        var l = new List<Record>();

        var sv = this.BigqueryService;
        var req = this.CreateQueryRequest();

        var where = new StringBuilder();
        where.Append($"WHERE _TABLE_SUFFIX BETWEEN '{startDate.ToString("yyyyMMdd")}' AND '{endDate.ToString("yyyyMMdd")}'");
        where.AppendFormat("AND (BeginRequestTime >= '{0}' and BeginRequestTime < '{1}')"
            , startTime.ToString("yyyy-MM-dd HH:mm:ss")
            , endTime.ToString("yyyy-MM-dd HH:mm:ss"));
        where.AppendLine();
        if (userId.HasValue)
        {
            where.AppendFormat("and UserId = '{0}' ", userId).AppendLine();
        }
        foreach (var item in whereConditionList)
        {
            where.AppendLine(item);
        }

        var sb = new StringBuilder();
        sb.AppendLine(CreateSelectFromClause("*"));
        sb.AppendLine(where.ToString());
        sb.AppendLine("order by BeginRequestTime desc");
        sb.AppendFormat("limit {0} offset {1}", recordCount, startIndex).AppendLine();
        req.Query = sb.ToString();
        {
            var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync(cancellationToken);
            foreach (var d in res.CreateRecords())
            {
                var r = d.Map(new Record());
                l.Add(r);
            }
        }

        sb.Clear();
        sb.Append("select COUNT(*) as RecordCount ");
        sb.AppendLine(CreateFromClause("*"));
        sb.AppendLine(where.ToString());
        req.Query = sb.ToString();
        {
            var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync(cancellationToken);
            var dd = res.CreateRecords();
            UInt64 totalRecordCount = 0;
            if (dd.Count > 0)
            {
                var d = dd[0];
                totalRecordCount = d["RecordCount"]?.ToString()?.ToUInt64() ?? 0;
            }
            return (l, req.Query, totalRecordCount);
        }
    }

    public async Task<(List<Record> records, UInt64 totalRecordCount)> Search_RequestBody_Get(DateOnly date, String searchText, Int32 startIndex, Int32 recordCount)
    {
        await this.EnsureTable(date);
        return await this.Search_RequestBody_Get(date.ToString("yyyyMMdd"), searchText, startIndex, recordCount);
    }
    public async Task<(List<Record> records, UInt64 totalRecordCount)> Search_RequestBody_Get(String dateSuffix, String searchText, Int32 startIndex, Int32 recordCount)
    {
        if (startIndex < 0) { throw new ArgumentOutOfRangeException("startIndex must be larger than zero."); }
        if (recordCount < 0) { throw new ArgumentOutOfRangeException("recordCount must be larger than zero."); }

        var l = new List<Record>();

        var sv = this.BigqueryService;
        var req = this.CreateQueryRequest();

        var where = new StringBuilder();
        where.AppendFormat("where RequestBodyData like '{0}'", searchText);

        var sb = new StringBuilder();
        sb.AppendLine(CreateSelectFromClause(dateSuffix));
        sb.AppendLine(where.ToString());
        sb.AppendLine("order by BeginRequestTime desc");
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
    public async Task<(List<Record> records, UInt64 totalRecordCount)> Search_RequestBody_Get(DateOnly startDate, DateOnly endDate, String searchText, Int32 startIndex, Int32 recordCount)
    {
        if (startIndex < 0) { throw new ArgumentOutOfRangeException("startIndex must be larger than zero."); }
        if (recordCount < 0) { throw new ArgumentOutOfRangeException("recordCount must be larger than zero."); }

        var l = new List<Record>();

        var sv = this.BigqueryService;
        var req = this.CreateQueryRequest();

        var where = new StringBuilder();
        where.Append($"WHERE _TABLE_SUFFIX BETWEEN '{startDate.ToString("yyyyMMdd")}' AND '{endDate.ToString("yyyyMMdd")}'");
        where.AppendFormat("AND RequestBodyData like '{0}'", searchText);

        var sb = new StringBuilder();
        sb.AppendLine(CreateSelectFromClause("*"));
        sb.AppendLine(where.ToString());
        sb.AppendLine("order by BeginRequestTime desc");
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
        sb.AppendLine(CreateFromClause("*"));
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

    public async Task<Record?> Data_Get(DateOnly date, Guid logId)
    {
        await this.EnsureTable(date);
        return await Data_Get(date.ToString("yyyyMMdd"), logId);
    }
    public async Task<Record?> Data_Get(String dateSuffix, Guid logId)
    {
        var sv = this.BigqueryService;
        var req = this.CreateQueryRequest();
        req.UseQueryCache = true;

        var sb = new StringBuilder();
        sb.AppendLine(CreateSelectFromClause(dateSuffix));
        sb.AppendFormat("where LogId = '{0}'", logId);
        req.Query = sb.ToString();

        var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
        var l = new List<ErrorLogTable.Record>();
        foreach (var d in res.CreateRecords())
        {
            return d.Map(new Record());
        }
        return null;
    }
    public async Task<Record?> Error_Data_Get(DateOnly date, Guid errorLogId)
    {
        await this.EnsureTable(date);
        return await Error_Data_Get(date.ToString("yyyyMMdd"), errorLogId);
    }
    public async Task<Record?> Error_Data_Get(String dateSuffix, Guid errorLogId)
    {
        var sv = this.BigqueryService;
        var req = this.CreateQueryRequest();
        req.UseQueryCache = true;

        var sb = new StringBuilder();
        sb.AppendLine(CreateSelectFromClause(dateSuffix));
        sb.AppendFormat("where ErrorLogId = '{0}'", errorLogId);
        req.Query = sb.ToString();

        var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
        var l = new List<ErrorLogTable.Record>();
        foreach (var d in res.CreateRecords())
        {
            return d.Map(new Record());
        }
        return null;
    }

    public async Task<Boolean> DeleteAsync(DateOnly date, Guid logId)
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

using Google.Apis.Bigquery.v2;
using Google.Apis.Bigquery.v2.Data;
using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public abstract class BigQueryTable
    {
        public BigqueryService BigqueryService { get; private set; }
        public String ProjectId { get; protected set; } = "";
        public String DatasetId { get; protected set; } = "";

        public BigQueryTable(BigqueryService service, String projectId, String datasetId)
        {
            this.BigqueryService = service;
            this.ProjectId = projectId;
            this.DatasetId = datasetId;
        }
        public static TableFieldSchema[] CreateTableFields(String type, String[] names)
        {
            var l = new List<TableFieldSchema>();

            foreach (var name in names)
            {
                var c = new TableFieldSchema();
                c.Name = name;
                c.Type = type;
                l.Add(c);
            }
            return l.ToArray();
        }
        protected abstract TableFieldSchema[] CreateTableFieldSchemaList();
        public QueryRequest CreateQueryRequest()
        {
            var req = new QueryRequest();
            req.DefaultDataset = new DatasetReference();
            req.DefaultDataset.DatasetId = this.DatasetId;
            req.DefaultDataset.ProjectId = this.ProjectId;
            req.UseQueryCache = false;
            req.UseLegacySql = false;
            return req;
        }
        public String CreateTableSuffix(DateOnly startDate, DateOnly endDate)
        {
            return String.Format("_TABLE_SUFFIX BETWEEN '{0}' AND '{1}'"
                , startDate.ToString("yyyyMMdd"), endDate.ToString("yyyyMMdd"));
        }
        public async ValueTask<Boolean> ExistsAsync(String tableName)
        {
            var sv = this.BigqueryService;
            var req = this.CreateQueryRequest();
            req.UseQueryCache = false;
            req.Query = String.Format("SELECT size_bytes FROM {0}.__TABLES__ WHERE table_id='{1}'", this.DatasetId, tableName);

            var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
            var rr = res.CreateRecords();

            return rr.Count > 0;
        }
        protected async ValueTask<TableDataInsertAllResponse> InsertAsync(String tableName
            , IEnumerable<Dictionary<String, Object>> records)
        {
            var sv = this.BigqueryService;
            var req = new TableDataInsertAllRequest();
            req.Rows = new List<TableDataInsertAllRequest.RowsData>();
            foreach (var d in records)
            {
                var row = new TableDataInsertAllRequest.RowsData();
                row.Json = d;
                req.Rows.Add(row);
            }
            var res = await sv.Tabledata.InsertAll(req, this.ProjectId, this.DatasetId, tableName).ExecuteAsync();
            return res;
        }

        public async ValueTask<QueryResponse> Query(string query)
        {
            return await this.Query(query, null);
        }
        public async ValueTask<QueryResponse> Query(string query, Action<QueryRequest>? requestCreated)
        {
            var sv = this.BigqueryService;
            var req = this.CreateQueryRequest();
            req.UseQueryCache = false;
            if (requestCreated != null)
            {
                requestCreated(req);
            }
            req.Query = query;

            return await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
        }
        public async ValueTask<List<T>> Query<T>(String query)
            where T : new()
        {
            var sv = this.BigqueryService;
            var req = this.CreateQueryRequest();
            req.UseQueryCache = false;
            req.Query = query;

            var res = await sv.Jobs.Query(req, this.ProjectId).ExecuteAsync();
            var l = new List<T>();
            foreach (var d in res.CreateRecords())
            {
                var r = d.Map(new T());
                l.Add(r);
            }
            return l;
        }
    }
}

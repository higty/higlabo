using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookListTablesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Tables,
            Me_Drive_Root_ItemPath_Workbook_Tables,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables: return $"/me/drive/items/{Id}/workbook/tables";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables: return $"/me/drive/root:/{ItemPath}:/workbook/tables";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string Id { get; set; }
        public string ItemPath { get; set; }
    }
    public partial class WorkbookListTablesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/table?view=graph-rest-1.0
        /// </summary>
        public partial class Table
        {
            public string? Id { get; set; }
            public string? Name { get; set; }
            public bool? ShowHeaders { get; set; }
            public bool? ShowTotals { get; set; }
            public string? Style { get; set; }
            public bool? HighlightFirstColumn { get; set; }
            public bool? HighlightLastColumn { get; set; }
            public bool? ShowBandedColumns { get; set; }
            public bool? ShowBandedRows { get; set; }
            public bool? ShowFilterButton { get; set; }
            public string? LegacyId { get; set; }
        }

        public Table[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListTablesResponse> WorkbookListTablesAsync()
        {
            var p = new WorkbookListTablesParameter();
            return await this.SendAsync<WorkbookListTablesParameter, WorkbookListTablesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListTablesResponse> WorkbookListTablesAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookListTablesParameter();
            return await this.SendAsync<WorkbookListTablesParameter, WorkbookListTablesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListTablesResponse> WorkbookListTablesAsync(WorkbookListTablesParameter parameter)
        {
            return await this.SendAsync<WorkbookListTablesParameter, WorkbookListTablesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListTablesResponse> WorkbookListTablesAsync(WorkbookListTablesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookListTablesParameter, WorkbookListTablesResponse>(parameter, cancellationToken);
        }
    }
}

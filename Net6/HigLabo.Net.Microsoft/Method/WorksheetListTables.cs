using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorksheetListTablesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/tables";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/tables";
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
        public string IdOrName { get; set; }
        public string ItemPath { get; set; }
    }
    public partial class WorksheetListTablesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetListTablesResponse> WorksheetListTablesAsync()
        {
            var p = new WorksheetListTablesParameter();
            return await this.SendAsync<WorksheetListTablesParameter, WorksheetListTablesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetListTablesResponse> WorksheetListTablesAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetListTablesParameter();
            return await this.SendAsync<WorksheetListTablesParameter, WorksheetListTablesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetListTablesResponse> WorksheetListTablesAsync(WorksheetListTablesParameter parameter)
        {
            return await this.SendAsync<WorksheetListTablesParameter, WorksheetListTablesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetListTablesResponse> WorksheetListTablesAsync(WorksheetListTablesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetListTablesParameter, WorksheetListTablesResponse>(parameter, cancellationToken);
        }
    }
}

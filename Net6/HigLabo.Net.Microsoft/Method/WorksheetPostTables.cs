using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorksheetPostTablesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_Add,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_Add,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_Add: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/tables/add";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_Add: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/tables/add";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Address { get; set; }
        public bool? HasHeaders { get; set; }
        public string Id { get; set; }
        public string IdOrName { get; set; }
        public string ItemPath { get; set; }
    }
    public partial class WorksheetPostTablesResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-post-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetPostTablesResponse> WorksheetPostTablesAsync()
        {
            var p = new WorksheetPostTablesParameter();
            return await this.SendAsync<WorksheetPostTablesParameter, WorksheetPostTablesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-post-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetPostTablesResponse> WorksheetPostTablesAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetPostTablesParameter();
            return await this.SendAsync<WorksheetPostTablesParameter, WorksheetPostTablesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-post-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetPostTablesResponse> WorksheetPostTablesAsync(WorksheetPostTablesParameter parameter)
        {
            return await this.SendAsync<WorksheetPostTablesParameter, WorksheetPostTablesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-post-tables?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetPostTablesResponse> WorksheetPostTablesAsync(WorksheetPostTablesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetPostTablesParameter, WorksheetPostTablesResponse>(parameter, cancellationToken);
        }
    }
}

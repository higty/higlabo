using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TablecollectionAddParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Tables_Add,
            Me_Drive_Root_ItemPath_Workbook_Tables_Add,
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_Add: return $"/me/drive/items/{Id}/workbook/tables/add";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_Add: return $"/me/drive/root:/{ItemPath}:/workbook/tables/add";
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
        public string ItemPath { get; set; }
        public string IdOrName { get; set; }
    }
    public partial class TablecollectionAddResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/tablecollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<TablecollectionAddResponse> TablecollectionAddAsync()
        {
            var p = new TablecollectionAddParameter();
            return await this.SendAsync<TablecollectionAddParameter, TablecollectionAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tablecollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<TablecollectionAddResponse> TablecollectionAddAsync(CancellationToken cancellationToken)
        {
            var p = new TablecollectionAddParameter();
            return await this.SendAsync<TablecollectionAddParameter, TablecollectionAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tablecollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<TablecollectionAddResponse> TablecollectionAddAsync(TablecollectionAddParameter parameter)
        {
            return await this.SendAsync<TablecollectionAddParameter, TablecollectionAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tablecollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<TablecollectionAddResponse> TablecollectionAddAsync(TablecollectionAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TablecollectionAddParameter, TablecollectionAddResponse>(parameter, cancellationToken);
        }
    }
}

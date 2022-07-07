using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TablePostRowsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Rows,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Rows,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Rows: return $"/me/drive/items/{Id}/workbook/tables/{IdOrName}/rows";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Rows: return $"/me/drive/root:/{ItemPath}:/workbook/tables/{IdOrName}/rows";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows: return $"/me/drive/items/{ItemsId}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/rows";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows: return $"/me/drive/root:/{RootItemPath}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/rows";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Int32? Index { get; set; }
        public Json? Values { get; set; }
        public string Id { get; set; }
        public string IdOrName { get; set; }
        public string ItemPath { get; set; }
        public string ItemsId { get; set; }
        public string WorksheetsIdOrName { get; set; }
        public string TablesIdOrName { get; set; }
        public string RootItemPath { get; set; }
    }
    public partial class TablePostRowsResponse : RestApiResponse
    {
        public Int32? Index { get; set; }
        public Json? Values { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-post-rows?view=graph-rest-1.0
        /// </summary>
        public async Task<TablePostRowsResponse> TablePostRowsAsync()
        {
            var p = new TablePostRowsParameter();
            return await this.SendAsync<TablePostRowsParameter, TablePostRowsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-post-rows?view=graph-rest-1.0
        /// </summary>
        public async Task<TablePostRowsResponse> TablePostRowsAsync(CancellationToken cancellationToken)
        {
            var p = new TablePostRowsParameter();
            return await this.SendAsync<TablePostRowsParameter, TablePostRowsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-post-rows?view=graph-rest-1.0
        /// </summary>
        public async Task<TablePostRowsResponse> TablePostRowsAsync(TablePostRowsParameter parameter)
        {
            return await this.SendAsync<TablePostRowsParameter, TablePostRowsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-post-rows?view=graph-rest-1.0
        /// </summary>
        public async Task<TablePostRowsResponse> TablePostRowsAsync(TablePostRowsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TablePostRowsParameter, TablePostRowsResponse>(parameter, cancellationToken);
        }
    }
}

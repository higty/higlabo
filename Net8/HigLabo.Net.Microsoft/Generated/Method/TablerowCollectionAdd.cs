using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tablerowcollection-add?view=graph-rest-1.0
    /// </summary>
    public partial class TablerowCollectionAddParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrName { get; set; }
            public string? ItemPath { get; set; }
            public string? ItemsId { get; set; }
            public string? WorksheetsIdOrName { get; set; }
            public string? TablesIdOrName { get; set; }
            public string? RootItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Rows_Add: return $"/me/drive/items/{Id}/workbook/tables/{IdOrName}/rows/add";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Rows_Add: return $"/me/drive/root:/{ItemPath}:/workbook/tables/{IdOrName}/rows/add";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows_Add: return $"/me/drive/items/{ItemsId}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/rows/add";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows_Add: return $"/me/drive/root:/{RootItemPath}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/rows/add";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Rows_Add,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Rows_Add,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows_Add,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows_Add,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Int32? Index { get; set; }
        public Json? Values { get; set; }
    }
    public partial class TablerowCollectionAddResponse : RestApiResponse
    {
        public Int32? Index { get; set; }
        public Json? Values { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tablerowcollection-add?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tablerowcollection-add?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TablerowCollectionAddResponse> TablerowCollectionAddAsync()
        {
            var p = new TablerowCollectionAddParameter();
            return await this.SendAsync<TablerowCollectionAddParameter, TablerowCollectionAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tablerowcollection-add?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TablerowCollectionAddResponse> TablerowCollectionAddAsync(CancellationToken cancellationToken)
        {
            var p = new TablerowCollectionAddParameter();
            return await this.SendAsync<TablerowCollectionAddParameter, TablerowCollectionAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tablerowcollection-add?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TablerowCollectionAddResponse> TablerowCollectionAddAsync(TablerowCollectionAddParameter parameter)
        {
            return await this.SendAsync<TablerowCollectionAddParameter, TablerowCollectionAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tablerowcollection-add?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TablerowCollectionAddResponse> TablerowCollectionAddAsync(TablerowCollectionAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TablerowCollectionAddParameter, TablerowCollectionAddResponse>(parameter, cancellationToken);
        }
    }
}

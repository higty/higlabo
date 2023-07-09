using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tablerow-update?view=graph-rest-1.0
    /// </summary>
    public partial class TablerowUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrName { get; set; }
            public string? Index { get; set; }
            public string? ItemPath { get; set; }
            public string? ItemsId { get; set; }
            public string? WorksheetsIdOrName { get; set; }
            public string? TablesIdOrName { get; set; }
            public string? RowsIndex { get; set; }
            public string? RootItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Rows_Index: return $"/me/drive/items/{Id}/workbook/tables/{IdOrName}/rows/{Index}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Rows_Index: return $"/me/drive/root:/{ItemPath}:/workbook/tables/{IdOrName}/rows/{Index}";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows_Index: return $"/me/drive/items/{ItemsId}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/rows/{RowsIndex}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows_Index: return $"/me/drive/root:/{RootItemPath}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/rows/{RowsIndex}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Rows_Index,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Rows_Index,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows_Index,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows_Index,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public Json? Values { get; set; }
    }
    public partial class TablerowUpdateResponse : RestApiResponse
    {
        public Int32? Index { get; set; }
        public Json? Values { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tablerow-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tablerow-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TablerowUpdateResponse> TablerowUpdateAsync()
        {
            var p = new TablerowUpdateParameter();
            return await this.SendAsync<TablerowUpdateParameter, TablerowUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tablerow-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TablerowUpdateResponse> TablerowUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TablerowUpdateParameter();
            return await this.SendAsync<TablerowUpdateParameter, TablerowUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tablerow-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TablerowUpdateResponse> TablerowUpdateAsync(TablerowUpdateParameter parameter)
        {
            return await this.SendAsync<TablerowUpdateParameter, TablerowUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tablerow-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TablerowUpdateResponse> TablerowUpdateAsync(TablerowUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TablerowUpdateParameter, TablerowUpdateResponse>(parameter, cancellationToken);
        }
    }
}

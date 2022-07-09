using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TablecolumnDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ItemsId { get; set; }
            public string? TablesIdOrName { get; set; }
            public string? ColumnsIdOrName { get; set; }
            public string? RootItemPath { get; set; }
            public string? WorksheetsIdOrName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname: return $"/me/drive/items/{ItemsId}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname: return $"/me/drive/root:/{RootItemPath}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Columns_IdOrname: return $"/me/drive/items/{ItemsId}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Columns_IdOrname: return $"/me/drive/root:/{RootItemPath}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Columns_IdOrname,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Columns_IdOrname,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class TablecolumnDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tablecolumn-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TablecolumnDeleteResponse> TablecolumnDeleteAsync()
        {
            var p = new TablecolumnDeleteParameter();
            return await this.SendAsync<TablecolumnDeleteParameter, TablecolumnDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tablecolumn-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TablecolumnDeleteResponse> TablecolumnDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TablecolumnDeleteParameter();
            return await this.SendAsync<TablecolumnDeleteParameter, TablecolumnDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tablecolumn-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TablecolumnDeleteResponse> TablecolumnDeleteAsync(TablecolumnDeleteParameter parameter)
        {
            return await this.SendAsync<TablecolumnDeleteParameter, TablecolumnDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/tablecolumn-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TablecolumnDeleteResponse> TablecolumnDeleteAsync(TablecolumnDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TablecolumnDeleteParameter, TablecolumnDeleteResponse>(parameter, cancellationToken);
        }
    }
}

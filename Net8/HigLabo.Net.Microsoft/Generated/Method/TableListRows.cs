using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-list-rows?view=graph-rest-1.0
    /// </summary>
    public partial class TableListRowsParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Rows: return $"/me/drive/items/{Id}/workbook/tables/{IdOrName}/rows";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Rows: return $"/me/drive/root:/{ItemPath}:/workbook/tables/{IdOrName}/rows";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows: return $"/me/drive/items/{ItemsId}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/rows";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows: return $"/me/drive/root:/{RootItemPath}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/rows";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Index,
            Values,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Rows,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Rows,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Rows,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class TableListRowsResponse : RestApiResponse
    {
        public WorkbookTableRow[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-list-rows?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/table-list-rows?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TableListRowsResponse> TableListRowsAsync()
        {
            var p = new TableListRowsParameter();
            return await this.SendAsync<TableListRowsParameter, TableListRowsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/table-list-rows?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TableListRowsResponse> TableListRowsAsync(CancellationToken cancellationToken)
        {
            var p = new TableListRowsParameter();
            return await this.SendAsync<TableListRowsParameter, TableListRowsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/table-list-rows?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TableListRowsResponse> TableListRowsAsync(TableListRowsParameter parameter)
        {
            return await this.SendAsync<TableListRowsParameter, TableListRowsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/table-list-rows?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TableListRowsResponse> TableListRowsAsync(TableListRowsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TableListRowsParameter, TableListRowsResponse>(parameter, cancellationToken);
        }
    }
}

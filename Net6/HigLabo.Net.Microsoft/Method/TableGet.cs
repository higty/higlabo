using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TableGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrName { get; set; }
            public string ItemPath { get; set; }
            public string ItemsId { get; set; }
            public string WorksheetsIdOrName { get; set; }
            public string TablesIdOrName { get; set; }
            public string RootItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname: return $"/me/drive/items/{Id}/workbook/tables/{IdOrName}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname: return $"/me/drive/root:/{ItemPath}:/workbook/tables/{IdOrName}";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname: return $"/me/drive/items/{ItemsId}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname: return $"/me/drive/root:/{RootItemPath}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Name,
            ShowHeaders,
            ShowTotals,
            Style,
            HighlightFirstColumn,
            HighlightLastColumn,
            ShowBandedColumns,
            ShowBandedRows,
            ShowFilterButton,
            LegacyId,
            Columns,
            Rows,
            Sort,
            Worksheet,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Tables_IdOrname,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname,
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
    public partial class TableGetResponse : RestApiResponse
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
        public WorkbookTableColumn[]? Columns { get; set; }
        public WorkbookTableRow[]? Rows { get; set; }
        public TableSort? Sort { get; set; }
        public Worksheet? Worksheet { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TableGetResponse> TableGetAsync()
        {
            var p = new TableGetParameter();
            return await this.SendAsync<TableGetParameter, TableGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TableGetResponse> TableGetAsync(CancellationToken cancellationToken)
        {
            var p = new TableGetParameter();
            return await this.SendAsync<TableGetParameter, TableGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TableGetResponse> TableGetAsync(TableGetParameter parameter)
        {
            return await this.SendAsync<TableGetParameter, TableGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TableGetResponse> TableGetAsync(TableGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TableGetParameter, TableGetResponse>(parameter, cancellationToken);
        }
    }
}

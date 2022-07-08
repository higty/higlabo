using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookListTablesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables: return $"/me/drive/items/{Id}/workbook/tables";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables: return $"/me/drive/root:/{ItemPath}:/workbook/tables";
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
            Me_Drive_Items_Id_Workbook_Tables,
            Me_Drive_Root_ItemPath_Workbook_Tables,
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
    public partial class WorkbookListTablesResponse : RestApiResponse
    {
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

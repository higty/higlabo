using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-update?view=graph-rest-1.0
    /// </summary>
    public partial class WorksheetUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrName { get; set; }
            public string? ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum WorksheetUpdateParameterstring
        {
            Visible,
            Hidden,
            VeryHidden,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname,
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
        public string? Name { get; set; }
        public int? Position { get; set; }
        public WorksheetUpdateParameterstring Visibility { get; set; }
    }
    public partial class WorksheetUpdateResponse : RestApiResponse
    {
        public enum Worksheetstring
        {
            Visible,
            Hidden,
            VeryHidden,
        }

        public string? Id { get; set; }
        public string? Name { get; set; }
        public int? Position { get; set; }
        public Worksheetstring Visibility { get; set; }
        public Chart[]? Charts { get; set; }
        public NamedItem[]? Names { get; set; }
        public PivotTable[]? PivotTables { get; set; }
        public WorksheetProtection? Protection { get; set; }
        public Table[]? Tables { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-update?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetUpdateResponse> WorksheetUpdateAsync()
        {
            var p = new WorksheetUpdateParameter();
            return await this.SendAsync<WorksheetUpdateParameter, WorksheetUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-update?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetUpdateResponse> WorksheetUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetUpdateParameter();
            return await this.SendAsync<WorksheetUpdateParameter, WorksheetUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-update?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetUpdateResponse> WorksheetUpdateAsync(WorksheetUpdateParameter parameter)
        {
            return await this.SendAsync<WorksheetUpdateParameter, WorksheetUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-update?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetUpdateResponse> WorksheetUpdateAsync(WorksheetUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetUpdateParameter, WorksheetUpdateResponse>(parameter, cancellationToken);
        }
    }
}

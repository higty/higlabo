using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorksheetListNamesParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Names: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/names";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Names: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/names";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Comment,
            Name,
            Scope,
            Type,
            Value,
            Visible,
            Worksheet,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Names,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Names,
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
    public partial class WorksheetListNamesResponse : RestApiResponse
    {
        public NamedItem[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-names?view=graph-rest-1.0&tabs=http
        /// </summary>
        public async Task<WorksheetListNamesResponse> WorksheetListNamesAsync()
        {
            var p = new WorksheetListNamesParameter();
            return await this.SendAsync<WorksheetListNamesParameter, WorksheetListNamesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-names?view=graph-rest-1.0&tabs=http
        /// </summary>
        public async Task<WorksheetListNamesResponse> WorksheetListNamesAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetListNamesParameter();
            return await this.SendAsync<WorksheetListNamesParameter, WorksheetListNamesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-names?view=graph-rest-1.0&tabs=http
        /// </summary>
        public async Task<WorksheetListNamesResponse> WorksheetListNamesAsync(WorksheetListNamesParameter parameter)
        {
            return await this.SendAsync<WorksheetListNamesParameter, WorksheetListNamesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-names?view=graph-rest-1.0&tabs=http
        /// </summary>
        public async Task<WorksheetListNamesResponse> WorksheetListNamesAsync(WorksheetListNamesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetListNamesParameter, WorksheetListNamesResponse>(parameter, cancellationToken);
        }
    }
}

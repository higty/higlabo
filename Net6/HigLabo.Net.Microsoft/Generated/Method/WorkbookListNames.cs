using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookListNamesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names: return $"/me/drive/items/{Id}/workbook/names";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names: return $"/me/drive/root:/{ItemPath}:/workbook/names";
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
            Me_Drive_Items_Id_Workbook_Names,
            Me_Drive_Root_ItemPath_Workbook_Names,
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
    public partial class WorkbookListNamesResponse : RestApiResponse
    {
        public NamedItem[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListNamesResponse> WorkbookListNamesAsync()
        {
            var p = new WorkbookListNamesParameter();
            return await this.SendAsync<WorkbookListNamesParameter, WorkbookListNamesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListNamesResponse> WorkbookListNamesAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookListNamesParameter();
            return await this.SendAsync<WorkbookListNamesParameter, WorkbookListNamesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListNamesResponse> WorkbookListNamesAsync(WorkbookListNamesParameter parameter)
        {
            return await this.SendAsync<WorkbookListNamesParameter, WorkbookListNamesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListNamesResponse> WorkbookListNamesAsync(WorkbookListNamesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookListNamesParameter, WorkbookListNamesResponse>(parameter, cancellationToken);
        }
    }
}

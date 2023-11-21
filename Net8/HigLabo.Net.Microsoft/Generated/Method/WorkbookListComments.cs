using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookListCommentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Comments: return $"/me/drive/items/{Id}/workbook/comments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Content,
            ContentType,
            Id,
            Replies,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Comments,
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
    public partial class WorkbookListCommentsResponse : RestApiResponse
    {
        public WorkbookComment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookListCommentsResponse> WorkbookListCommentsAsync()
        {
            var p = new WorkbookListCommentsParameter();
            return await this.SendAsync<WorkbookListCommentsParameter, WorkbookListCommentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookListCommentsResponse> WorkbookListCommentsAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookListCommentsParameter();
            return await this.SendAsync<WorkbookListCommentsParameter, WorkbookListCommentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookListCommentsResponse> WorkbookListCommentsAsync(WorkbookListCommentsParameter parameter)
        {
            return await this.SendAsync<WorkbookListCommentsParameter, WorkbookListCommentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-list-comments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkbookListCommentsResponse> WorkbookListCommentsAsync(WorkbookListCommentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookListCommentsParameter, WorkbookListCommentsResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contentsharingsession-get?view=graph-rest-1.0
    /// </summary>
    public partial class ContentsharingsessionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? CallsId { get; set; }
            public string? ContentSharingSessionsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_ContentSharingSessions_Id: return $"/communications/calls/{CallsId}/contentSharingSessions/{ContentSharingSessionsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Communications_Calls_Id_ContentSharingSessions_Id,
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
    public partial class ContentsharingsessionGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contentsharingsession-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contentsharingsession-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentsharingsessionGetResponse> ContentsharingsessionGetAsync()
        {
            var p = new ContentsharingsessionGetParameter();
            return await this.SendAsync<ContentsharingsessionGetParameter, ContentsharingsessionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contentsharingsession-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentsharingsessionGetResponse> ContentsharingsessionGetAsync(CancellationToken cancellationToken)
        {
            var p = new ContentsharingsessionGetParameter();
            return await this.SendAsync<ContentsharingsessionGetParameter, ContentsharingsessionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contentsharingsession-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentsharingsessionGetResponse> ContentsharingsessionGetAsync(ContentsharingsessionGetParameter parameter)
        {
            return await this.SendAsync<ContentsharingsessionGetParameter, ContentsharingsessionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contentsharingsession-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentsharingsessionGetResponse> ContentsharingsessionGetAsync(ContentsharingsessionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentsharingsessionGetParameter, ContentsharingsessionGetResponse>(parameter, cancellationToken);
        }
    }
}

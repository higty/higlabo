using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetsharepointactivitypagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointActivityPages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSharePointActivityPages: return $"/reports/getSharePointActivityPages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class ReportrootGetsharepointactivitypagesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivitypagesResponse> ReportrootGetsharepointactivitypagesAsync()
        {
            var p = new ReportrootGetsharepointactivitypagesParameter();
            return await this.SendAsync<ReportrootGetsharepointactivitypagesParameter, ReportrootGetsharepointactivitypagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivitypagesResponse> ReportrootGetsharepointactivitypagesAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetsharepointactivitypagesParameter();
            return await this.SendAsync<ReportrootGetsharepointactivitypagesParameter, ReportrootGetsharepointactivitypagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivitypagesResponse> ReportrootGetsharepointactivitypagesAsync(ReportrootGetsharepointactivitypagesParameter parameter)
        {
            return await this.SendAsync<ReportrootGetsharepointactivitypagesParameter, ReportrootGetsharepointactivitypagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivitypagesResponse> ReportrootGetsharepointactivitypagesAsync(ReportrootGetsharepointactivitypagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetsharepointactivitypagesParameter, ReportrootGetsharepointactivitypagesResponse>(parameter, cancellationToken);
        }
    }
}

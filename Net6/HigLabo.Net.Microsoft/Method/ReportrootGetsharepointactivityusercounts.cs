using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetsharepointactivityusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointActivityUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSharePointActivityUserCounts: return $"/reports/getSharePointActivityUserCounts";
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
    public partial class ReportrootGetsharepointactivityusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityusercountsResponse> ReportrootGetsharepointactivityusercountsAsync()
        {
            var p = new ReportrootGetsharepointactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetsharepointactivityusercountsParameter, ReportrootGetsharepointactivityusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityusercountsResponse> ReportrootGetsharepointactivityusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetsharepointactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetsharepointactivityusercountsParameter, ReportrootGetsharepointactivityusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityusercountsResponse> ReportrootGetsharepointactivityusercountsAsync(ReportrootGetsharepointactivityusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetsharepointactivityusercountsParameter, ReportrootGetsharepointactivityusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityusercountsResponse> ReportrootGetsharepointactivityusercountsAsync(ReportrootGetsharepointactivityusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetsharepointactivityusercountsParameter, ReportrootGetsharepointactivityusercountsResponse>(parameter, cancellationToken);
        }
    }
}

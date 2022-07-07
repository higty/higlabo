using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetyammeractivityusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerActivityUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetYammerActivityUserCounts: return $"/reports/getYammerActivityUserCounts";
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
    public partial class ReportrootGetyammeractivityusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivityusercountsResponse> ReportrootGetyammeractivityusercountsAsync()
        {
            var p = new ReportrootGetyammeractivityusercountsParameter();
            return await this.SendAsync<ReportrootGetyammeractivityusercountsParameter, ReportrootGetyammeractivityusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivityusercountsResponse> ReportrootGetyammeractivityusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetyammeractivityusercountsParameter();
            return await this.SendAsync<ReportrootGetyammeractivityusercountsParameter, ReportrootGetyammeractivityusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivityusercountsResponse> ReportrootGetyammeractivityusercountsAsync(ReportrootGetyammeractivityusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetyammeractivityusercountsParameter, ReportrootGetyammeractivityusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivityusercountsResponse> ReportrootGetyammeractivityusercountsAsync(ReportrootGetyammeractivityusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetyammeractivityusercountsParameter, ReportrootGetyammeractivityusercountsResponse>(parameter, cancellationToken);
        }
    }
}

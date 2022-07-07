using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetyammeractivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerActivityCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetYammerActivityCounts: return $"/reports/getYammerActivityCounts";
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
    public partial class ReportrootGetyammeractivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivitycountsResponse> ReportrootGetyammeractivitycountsAsync()
        {
            var p = new ReportrootGetyammeractivitycountsParameter();
            return await this.SendAsync<ReportrootGetyammeractivitycountsParameter, ReportrootGetyammeractivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivitycountsResponse> ReportrootGetyammeractivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetyammeractivitycountsParameter();
            return await this.SendAsync<ReportrootGetyammeractivitycountsParameter, ReportrootGetyammeractivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivitycountsResponse> ReportrootGetyammeractivitycountsAsync(ReportrootGetyammeractivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetyammeractivitycountsParameter, ReportrootGetyammeractivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetyammeractivitycountsResponse> ReportrootGetyammeractivitycountsAsync(ReportrootGetyammeractivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetyammeractivitycountsParameter, ReportrootGetyammeractivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

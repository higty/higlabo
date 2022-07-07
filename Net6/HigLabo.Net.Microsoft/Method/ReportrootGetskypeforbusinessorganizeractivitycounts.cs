using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessorganizeractivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessOrganizerActivityCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessOrganizerActivityCounts: return $"/reports/getSkypeForBusinessOrganizerActivityCounts";
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
    public partial class ReportrootGetskypeforbusinessorganizeractivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivitycountsResponse> ReportrootGetskypeforbusinessorganizeractivitycountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessorganizeractivitycountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivitycountsParameter, ReportrootGetskypeforbusinessorganizeractivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivitycountsResponse> ReportrootGetskypeforbusinessorganizeractivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessorganizeractivitycountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivitycountsParameter, ReportrootGetskypeforbusinessorganizeractivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivitycountsResponse> ReportrootGetskypeforbusinessorganizeractivitycountsAsync(ReportrootGetskypeforbusinessorganizeractivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivitycountsParameter, ReportrootGetskypeforbusinessorganizeractivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivitycountsResponse> ReportrootGetskypeforbusinessorganizeractivitycountsAsync(ReportrootGetskypeforbusinessorganizeractivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivitycountsParameter, ReportrootGetskypeforbusinessorganizeractivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

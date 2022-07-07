using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessorganizeractivityusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessOrganizerActivityUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessOrganizerActivityUserCounts: return $"/reports/getSkypeForBusinessOrganizerActivityUserCounts";
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
    public partial class ReportrootGetskypeforbusinessorganizeractivityusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivityusercountsResponse> ReportrootGetskypeforbusinessorganizeractivityusercountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessorganizeractivityusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivityusercountsParameter, ReportrootGetskypeforbusinessorganizeractivityusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivityusercountsResponse> ReportrootGetskypeforbusinessorganizeractivityusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessorganizeractivityusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivityusercountsParameter, ReportrootGetskypeforbusinessorganizeractivityusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivityusercountsResponse> ReportrootGetskypeforbusinessorganizeractivityusercountsAsync(ReportrootGetskypeforbusinessorganizeractivityusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivityusercountsParameter, ReportrootGetskypeforbusinessorganizeractivityusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivityusercountsResponse> ReportrootGetskypeforbusinessorganizeractivityusercountsAsync(ReportrootGetskypeforbusinessorganizeractivityusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivityusercountsParameter, ReportrootGetskypeforbusinessorganizeractivityusercountsResponse>(parameter, cancellationToken);
        }
    }
}

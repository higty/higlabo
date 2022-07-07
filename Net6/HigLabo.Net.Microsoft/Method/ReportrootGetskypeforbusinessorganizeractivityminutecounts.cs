using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessorganizeractivityminutecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessOrganizerActivityMinuteCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessOrganizerActivityMinuteCounts: return $"/reports/getSkypeForBusinessOrganizerActivityMinuteCounts";
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
    public partial class ReportrootGetskypeforbusinessorganizeractivityminutecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivityminutecountsResponse> ReportrootGetskypeforbusinessorganizeractivityminutecountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessorganizeractivityminutecountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivityminutecountsParameter, ReportrootGetskypeforbusinessorganizeractivityminutecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivityminutecountsResponse> ReportrootGetskypeforbusinessorganizeractivityminutecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessorganizeractivityminutecountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivityminutecountsParameter, ReportrootGetskypeforbusinessorganizeractivityminutecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivityminutecountsResponse> ReportrootGetskypeforbusinessorganizeractivityminutecountsAsync(ReportrootGetskypeforbusinessorganizeractivityminutecountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivityminutecountsParameter, ReportrootGetskypeforbusinessorganizeractivityminutecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessorganizeractivityminutecountsResponse> ReportrootGetskypeforbusinessorganizeractivityminutecountsAsync(ReportrootGetskypeforbusinessorganizeractivityminutecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessorganizeractivityminutecountsParameter, ReportrootGetskypeforbusinessorganizeractivityminutecountsResponse>(parameter, cancellationToken);
        }
    }
}

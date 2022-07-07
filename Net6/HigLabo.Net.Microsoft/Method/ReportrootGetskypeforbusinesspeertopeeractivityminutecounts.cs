using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinesspeertopeeractivityminutecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessPeerToPeerActivityMinuteCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessPeerToPeerActivityMinuteCounts: return $"/reports/getSkypeForBusinessPeerToPeerActivityMinuteCounts";
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
    public partial class ReportrootGetskypeforbusinesspeertopeeractivityminutecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivityminutecountsResponse> ReportrootGetskypeforbusinesspeertopeeractivityminutecountsAsync()
        {
            var p = new ReportrootGetskypeforbusinesspeertopeeractivityminutecountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivityminutecountsParameter, ReportrootGetskypeforbusinesspeertopeeractivityminutecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivityminutecountsResponse> ReportrootGetskypeforbusinesspeertopeeractivityminutecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinesspeertopeeractivityminutecountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivityminutecountsParameter, ReportrootGetskypeforbusinesspeertopeeractivityminutecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivityminutecountsResponse> ReportrootGetskypeforbusinesspeertopeeractivityminutecountsAsync(ReportrootGetskypeforbusinesspeertopeeractivityminutecountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivityminutecountsParameter, ReportrootGetskypeforbusinesspeertopeeractivityminutecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityminutecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivityminutecountsResponse> ReportrootGetskypeforbusinesspeertopeeractivityminutecountsAsync(ReportrootGetskypeforbusinesspeertopeeractivityminutecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivityminutecountsParameter, ReportrootGetskypeforbusinesspeertopeeractivityminutecountsResponse>(parameter, cancellationToken);
        }
    }
}

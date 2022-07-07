using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinesspeertopeeractivityusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessPeerToPeerActivityUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessPeerToPeerActivityUserCounts: return $"/reports/getSkypeForBusinessPeerToPeerActivityUserCounts";
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
    public partial class ReportrootGetskypeforbusinesspeertopeeractivityusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivityusercountsResponse> ReportrootGetskypeforbusinesspeertopeeractivityusercountsAsync()
        {
            var p = new ReportrootGetskypeforbusinesspeertopeeractivityusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivityusercountsParameter, ReportrootGetskypeforbusinesspeertopeeractivityusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivityusercountsResponse> ReportrootGetskypeforbusinesspeertopeeractivityusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinesspeertopeeractivityusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivityusercountsParameter, ReportrootGetskypeforbusinesspeertopeeractivityusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivityusercountsResponse> ReportrootGetskypeforbusinesspeertopeeractivityusercountsAsync(ReportrootGetskypeforbusinesspeertopeeractivityusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivityusercountsParameter, ReportrootGetskypeforbusinesspeertopeeractivityusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivityusercountsResponse> ReportrootGetskypeforbusinesspeertopeeractivityusercountsAsync(ReportrootGetskypeforbusinesspeertopeeractivityusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivityusercountsParameter, ReportrootGetskypeforbusinesspeertopeeractivityusercountsResponse>(parameter, cancellationToken);
        }
    }
}

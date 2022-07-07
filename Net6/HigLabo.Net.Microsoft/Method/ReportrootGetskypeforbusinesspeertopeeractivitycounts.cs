using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinesspeertopeeractivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessPeerToPeerActivityCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessPeerToPeerActivityCounts: return $"/reports/getSkypeForBusinessPeerToPeerActivityCounts";
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
    public partial class ReportrootGetskypeforbusinesspeertopeeractivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivitycountsResponse> ReportrootGetskypeforbusinesspeertopeeractivitycountsAsync()
        {
            var p = new ReportrootGetskypeforbusinesspeertopeeractivitycountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivitycountsParameter, ReportrootGetskypeforbusinesspeertopeeractivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivitycountsResponse> ReportrootGetskypeforbusinesspeertopeeractivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinesspeertopeeractivitycountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivitycountsParameter, ReportrootGetskypeforbusinesspeertopeeractivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivitycountsResponse> ReportrootGetskypeforbusinesspeertopeeractivitycountsAsync(ReportrootGetskypeforbusinesspeertopeeractivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivitycountsParameter, ReportrootGetskypeforbusinesspeertopeeractivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinesspeertopeeractivitycountsResponse> ReportrootGetskypeforbusinesspeertopeeractivitycountsAsync(ReportrootGetskypeforbusinesspeertopeeractivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinesspeertopeeractivitycountsParameter, ReportrootGetskypeforbusinesspeertopeeractivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

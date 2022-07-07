using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetteamsuseractivityusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsUserActivityUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetTeamsUserActivityUserCounts: return $"/reports/getTeamsUserActivityUserCounts";
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
    public partial class ReportrootGetteamsuseractivityusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivityusercountsResponse> ReportrootGetteamsuseractivityusercountsAsync()
        {
            var p = new ReportrootGetteamsuseractivityusercountsParameter();
            return await this.SendAsync<ReportrootGetteamsuseractivityusercountsParameter, ReportrootGetteamsuseractivityusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivityusercountsResponse> ReportrootGetteamsuseractivityusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetteamsuseractivityusercountsParameter();
            return await this.SendAsync<ReportrootGetteamsuseractivityusercountsParameter, ReportrootGetteamsuseractivityusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivityusercountsResponse> ReportrootGetteamsuseractivityusercountsAsync(ReportrootGetteamsuseractivityusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetteamsuseractivityusercountsParameter, ReportrootGetteamsuseractivityusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivityusercountsResponse> ReportrootGetteamsuseractivityusercountsAsync(ReportrootGetteamsuseractivityusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetteamsuseractivityusercountsParameter, ReportrootGetteamsuseractivityusercountsResponse>(parameter, cancellationToken);
        }
    }
}

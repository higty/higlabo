using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetteamsuseractivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsUserActivityCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetTeamsUserActivityCounts: return $"/reports/getTeamsUserActivityCounts";
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
    public partial class ReportrootGetteamsuseractivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivitycountsResponse> ReportrootGetteamsuseractivitycountsAsync()
        {
            var p = new ReportrootGetteamsuseractivitycountsParameter();
            return await this.SendAsync<ReportrootGetteamsuseractivitycountsParameter, ReportrootGetteamsuseractivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivitycountsResponse> ReportrootGetteamsuseractivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetteamsuseractivitycountsParameter();
            return await this.SendAsync<ReportrootGetteamsuseractivitycountsParameter, ReportrootGetteamsuseractivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivitycountsResponse> ReportrootGetteamsuseractivitycountsAsync(ReportrootGetteamsuseractivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetteamsuseractivitycountsParameter, ReportrootGetteamsuseractivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetteamsuseractivitycountsResponse> ReportrootGetteamsuseractivitycountsAsync(ReportrootGetteamsuseractivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetteamsuseractivitycountsParameter, ReportrootGetteamsuseractivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetsharepointsiteusagesitecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointSiteUsageSiteCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSharePointSiteUsageSiteCounts: return $"/reports/getSharePointSiteUsageSiteCounts";
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
    public partial class ReportrootGetsharepointsiteusagesitecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagesitecountsResponse> ReportrootGetsharepointsiteusagesitecountsAsync()
        {
            var p = new ReportrootGetsharepointsiteusagesitecountsParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagesitecountsParameter, ReportrootGetsharepointsiteusagesitecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagesitecountsResponse> ReportrootGetsharepointsiteusagesitecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetsharepointsiteusagesitecountsParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagesitecountsParameter, ReportrootGetsharepointsiteusagesitecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagesitecountsResponse> ReportrootGetsharepointsiteusagesitecountsAsync(ReportrootGetsharepointsiteusagesitecountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagesitecountsParameter, ReportrootGetsharepointsiteusagesitecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagesitecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagesitecountsResponse> ReportrootGetsharepointsiteusagesitecountsAsync(ReportrootGetsharepointsiteusagesitecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagesitecountsParameter, ReportrootGetsharepointsiteusagesitecountsResponse>(parameter, cancellationToken);
        }
    }
}

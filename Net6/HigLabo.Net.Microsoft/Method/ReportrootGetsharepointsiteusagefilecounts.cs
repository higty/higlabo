using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetsharepointsiteusagefilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointSiteUsageFileCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSharePointSiteUsageFileCounts: return $"/reports/getSharePointSiteUsageFileCounts";
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
    public partial class ReportrootGetsharepointsiteusagefilecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagefilecountsResponse> ReportrootGetsharepointsiteusagefilecountsAsync()
        {
            var p = new ReportrootGetsharepointsiteusagefilecountsParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagefilecountsParameter, ReportrootGetsharepointsiteusagefilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagefilecountsResponse> ReportrootGetsharepointsiteusagefilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetsharepointsiteusagefilecountsParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagefilecountsParameter, ReportrootGetsharepointsiteusagefilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagefilecountsResponse> ReportrootGetsharepointsiteusagefilecountsAsync(ReportrootGetsharepointsiteusagefilecountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagefilecountsParameter, ReportrootGetsharepointsiteusagefilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagefilecountsResponse> ReportrootGetsharepointsiteusagefilecountsAsync(ReportrootGetsharepointsiteusagefilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagefilecountsParameter, ReportrootGetsharepointsiteusagefilecountsResponse>(parameter, cancellationToken);
        }
    }
}

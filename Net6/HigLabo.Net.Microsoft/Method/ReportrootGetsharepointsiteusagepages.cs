using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetsharepointsiteusagepagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointSiteUsagePages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSharePointSiteUsagePages: return $"/reports/getSharePointSiteUsagePages";
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
    public partial class ReportrootGetsharepointsiteusagepagesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagepagesResponse> ReportrootGetsharepointsiteusagepagesAsync()
        {
            var p = new ReportrootGetsharepointsiteusagepagesParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagepagesParameter, ReportrootGetsharepointsiteusagepagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagepagesResponse> ReportrootGetsharepointsiteusagepagesAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetsharepointsiteusagepagesParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagepagesParameter, ReportrootGetsharepointsiteusagepagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagepagesResponse> ReportrootGetsharepointsiteusagepagesAsync(ReportrootGetsharepointsiteusagepagesParameter parameter)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagepagesParameter, ReportrootGetsharepointsiteusagepagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagepages?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagepagesResponse> ReportrootGetsharepointsiteusagepagesAsync(ReportrootGetsharepointsiteusagepagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagepagesParameter, ReportrootGetsharepointsiteusagepagesResponse>(parameter, cancellationToken);
        }
    }
}

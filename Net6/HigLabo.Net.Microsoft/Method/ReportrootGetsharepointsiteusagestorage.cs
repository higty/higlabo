using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetsharepointsiteusagestorageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointSiteUsageStorage,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSharePointSiteUsageStorage: return $"/reports/getSharePointSiteUsageStorage";
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
    public partial class ReportrootGetsharepointsiteusagestorageResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagestorageResponse> ReportrootGetsharepointsiteusagestorageAsync()
        {
            var p = new ReportrootGetsharepointsiteusagestorageParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagestorageParameter, ReportrootGetsharepointsiteusagestorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagestorageResponse> ReportrootGetsharepointsiteusagestorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetsharepointsiteusagestorageParameter();
            return await this.SendAsync<ReportrootGetsharepointsiteusagestorageParameter, ReportrootGetsharepointsiteusagestorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagestorageResponse> ReportrootGetsharepointsiteusagestorageAsync(ReportrootGetsharepointsiteusagestorageParameter parameter)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagestorageParameter, ReportrootGetsharepointsiteusagestorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointsiteusagestorageResponse> ReportrootGetsharepointsiteusagestorageAsync(ReportrootGetsharepointsiteusagestorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetsharepointsiteusagestorageParameter, ReportrootGetsharepointsiteusagestorageResponse>(parameter, cancellationToken);
        }
    }
}

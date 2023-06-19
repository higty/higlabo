using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetsharepointsiteusagestorageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSharePointSiteUsageStorage: return $"/reports/getSharePointSiteUsageStorage";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointSiteUsageStorage,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class ReportRootGetsharepointsiteusagestorageResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointsiteusagestorageResponse> ReportRootGetsharepointsiteusagestorageAsync()
        {
            var p = new ReportRootGetsharepointsiteusagestorageParameter();
            return await this.SendAsync<ReportRootGetsharepointsiteusagestorageParameter, ReportRootGetsharepointsiteusagestorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointsiteusagestorageResponse> ReportRootGetsharepointsiteusagestorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetsharepointsiteusagestorageParameter();
            return await this.SendAsync<ReportRootGetsharepointsiteusagestorageParameter, ReportRootGetsharepointsiteusagestorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointsiteusagestorageResponse> ReportRootGetsharepointsiteusagestorageAsync(ReportRootGetsharepointsiteusagestorageParameter parameter)
        {
            return await this.SendAsync<ReportRootGetsharepointsiteusagestorageParameter, ReportRootGetsharepointsiteusagestorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagestorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointsiteusagestorageResponse> ReportRootGetsharepointsiteusagestorageAsync(ReportRootGetsharepointsiteusagestorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetsharepointsiteusagestorageParameter, ReportRootGetsharepointsiteusagestorageResponse>(parameter, cancellationToken);
        }
    }
}

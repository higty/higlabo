using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetsharepointsiteusagefilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSharePointSiteUsageFileCounts: return $"/reports/getSharePointSiteUsageFileCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointSiteUsageFileCounts,
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
    public partial class ReportRootGetsharepointsiteusagefilecountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointsiteusagefilecountsResponse> ReportRootGetsharepointsiteusagefilecountsAsync()
        {
            var p = new ReportRootGetsharepointsiteusagefilecountsParameter();
            return await this.SendAsync<ReportRootGetsharepointsiteusagefilecountsParameter, ReportRootGetsharepointsiteusagefilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointsiteusagefilecountsResponse> ReportRootGetsharepointsiteusagefilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetsharepointsiteusagefilecountsParameter();
            return await this.SendAsync<ReportRootGetsharepointsiteusagefilecountsParameter, ReportRootGetsharepointsiteusagefilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointsiteusagefilecountsResponse> ReportRootGetsharepointsiteusagefilecountsAsync(ReportRootGetsharepointsiteusagefilecountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetsharepointsiteusagefilecountsParameter, ReportRootGetsharepointsiteusagefilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointsiteusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointsiteusagefilecountsResponse> ReportRootGetsharepointsiteusagefilecountsAsync(ReportRootGetsharepointsiteusagefilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetsharepointsiteusagefilecountsParameter, ReportRootGetsharepointsiteusagefilecountsResponse>(parameter, cancellationToken);
        }
    }
}

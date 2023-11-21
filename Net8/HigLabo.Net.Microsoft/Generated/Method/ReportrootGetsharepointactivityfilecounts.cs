using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetsharepointactivityfilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSharePointActivityFileCounts: return $"/reports/getSharePointActivityFileCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointActivityFileCounts,
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
    public partial class ReportRootGetsharepointactivityfilecountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivityfilecountsResponse> ReportRootGetsharepointactivityfilecountsAsync()
        {
            var p = new ReportRootGetsharepointactivityfilecountsParameter();
            return await this.SendAsync<ReportRootGetsharepointactivityfilecountsParameter, ReportRootGetsharepointactivityfilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivityfilecountsResponse> ReportRootGetsharepointactivityfilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetsharepointactivityfilecountsParameter();
            return await this.SendAsync<ReportRootGetsharepointactivityfilecountsParameter, ReportRootGetsharepointactivityfilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivityfilecountsResponse> ReportRootGetsharepointactivityfilecountsAsync(ReportRootGetsharepointactivityfilecountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetsharepointactivityfilecountsParameter, ReportRootGetsharepointactivityfilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivityfilecountsResponse> ReportRootGetsharepointactivityfilecountsAsync(ReportRootGetsharepointactivityfilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetsharepointactivityfilecountsParameter, ReportRootGetsharepointactivityfilecountsResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetsharepointactivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSharePointActivityUserCounts: return $"/reports/getSharePointActivityUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointActivityUserCounts,
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
    public partial class ReportRootGetsharepointactivityUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivityUsercountsResponse> ReportRootGetsharepointactivityUsercountsAsync()
        {
            var p = new ReportRootGetsharepointactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetsharepointactivityUsercountsParameter, ReportRootGetsharepointactivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivityUsercountsResponse> ReportRootGetsharepointactivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetsharepointactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetsharepointactivityUsercountsParameter, ReportRootGetsharepointactivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivityUsercountsResponse> ReportRootGetsharepointactivityUsercountsAsync(ReportRootGetsharepointactivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetsharepointactivityUsercountsParameter, ReportRootGetsharepointactivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivityUsercountsResponse> ReportRootGetsharepointactivityUsercountsAsync(ReportRootGetsharepointactivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetsharepointactivityUsercountsParameter, ReportRootGetsharepointactivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

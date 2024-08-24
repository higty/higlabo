using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetSkypeforBusinessorganizerActivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessOrganizerActivityUserCounts: return $"/reports/getSkypeForBusinessOrganizerActivityUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessOrganizerActivityUserCounts,
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
    public partial class ReportRootGetSkypeforBusinessorganizerActivityUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivityUsercountsResponse> ReportRootGetSkypeforBusinessorganizerActivityUsercountsAsync()
        {
            var p = new ReportRootGetSkypeforBusinessorganizerActivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivityUsercountsParameter, ReportRootGetSkypeforBusinessorganizerActivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivityUsercountsResponse> ReportRootGetSkypeforBusinessorganizerActivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetSkypeforBusinessorganizerActivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivityUsercountsParameter, ReportRootGetSkypeforBusinessorganizerActivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivityUsercountsResponse> ReportRootGetSkypeforBusinessorganizerActivityUsercountsAsync(ReportRootGetSkypeforBusinessorganizerActivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivityUsercountsParameter, ReportRootGetSkypeforBusinessorganizerActivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessorganizeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinessorganizerActivityUsercountsResponse> ReportRootGetSkypeforBusinessorganizerActivityUsercountsAsync(ReportRootGetSkypeforBusinessorganizerActivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinessorganizerActivityUsercountsParameter, ReportRootGetSkypeforBusinessorganizerActivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

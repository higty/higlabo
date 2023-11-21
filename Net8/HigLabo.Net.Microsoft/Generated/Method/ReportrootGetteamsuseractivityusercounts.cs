using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetteamsUseractivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsUserActivityUserCounts: return $"/reports/getTeamsUserActivityUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsUserActivityUserCounts,
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
    public partial class ReportRootGetteamsUseractivityUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsUseractivityUsercountsResponse> ReportRootGetteamsUseractivityUsercountsAsync()
        {
            var p = new ReportRootGetteamsUseractivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetteamsUseractivityUsercountsParameter, ReportRootGetteamsUseractivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsUseractivityUsercountsResponse> ReportRootGetteamsUseractivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetteamsUseractivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetteamsUseractivityUsercountsParameter, ReportRootGetteamsUseractivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsUseractivityUsercountsResponse> ReportRootGetteamsUseractivityUsercountsAsync(ReportRootGetteamsUseractivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetteamsUseractivityUsercountsParameter, ReportRootGetteamsUseractivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsUseractivityUsercountsResponse> ReportRootGetteamsUseractivityUsercountsAsync(ReportRootGetteamsUseractivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetteamsUseractivityUsercountsParameter, ReportRootGetteamsUseractivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

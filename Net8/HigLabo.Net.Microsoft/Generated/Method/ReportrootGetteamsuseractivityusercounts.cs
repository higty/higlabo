using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetTeamsUserActivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetTeamsUserActivityUsercountsResponse : RestApiResponse
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
        public async ValueTask<ReportRootGetTeamsUserActivityUsercountsResponse> ReportRootGetTeamsUserActivityUsercountsAsync()
        {
            var p = new ReportRootGetTeamsUserActivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetTeamsUserActivityUsercountsParameter, ReportRootGetTeamsUserActivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivityUsercountsResponse> ReportRootGetTeamsUserActivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetTeamsUserActivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetTeamsUserActivityUsercountsParameter, ReportRootGetTeamsUserActivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivityUsercountsResponse> ReportRootGetTeamsUserActivityUsercountsAsync(ReportRootGetTeamsUserActivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetTeamsUserActivityUsercountsParameter, ReportRootGetTeamsUserActivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivityUsercountsResponse> ReportRootGetTeamsUserActivityUsercountsAsync(ReportRootGetTeamsUserActivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetTeamsUserActivityUsercountsParameter, ReportRootGetTeamsUserActivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

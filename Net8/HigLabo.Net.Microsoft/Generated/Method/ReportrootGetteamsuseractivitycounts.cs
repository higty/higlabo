using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetTeamsUserActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsUserActivityCounts: return $"/reports/getTeamsUserActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsUserActivityCounts,
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
    public partial class ReportRootGetTeamsUserActivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivitycountsResponse> ReportRootGetTeamsUserActivitycountsAsync()
        {
            var p = new ReportRootGetTeamsUserActivitycountsParameter();
            return await this.SendAsync<ReportRootGetTeamsUserActivitycountsParameter, ReportRootGetTeamsUserActivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivitycountsResponse> ReportRootGetTeamsUserActivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetTeamsUserActivitycountsParameter();
            return await this.SendAsync<ReportRootGetTeamsUserActivitycountsParameter, ReportRootGetTeamsUserActivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivitycountsResponse> ReportRootGetTeamsUserActivitycountsAsync(ReportRootGetTeamsUserActivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetTeamsUserActivitycountsParameter, ReportRootGetTeamsUserActivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivitycountsResponse> ReportRootGetTeamsUserActivitycountsAsync(ReportRootGetTeamsUserActivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetTeamsUserActivitycountsParameter, ReportRootGetTeamsUserActivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetteamsteamactivitydetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsTeamActivityDetail: return $"/reports/getTeamsTeamActivityDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsTeamActivityDetail,
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
    public partial class ReportRootGetteamsteamactivitydetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamactivitydetailResponse> ReportRootGetteamsteamactivitydetailAsync()
        {
            var p = new ReportRootGetteamsteamactivitydetailParameter();
            return await this.SendAsync<ReportRootGetteamsteamactivitydetailParameter, ReportRootGetteamsteamactivitydetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamactivitydetailResponse> ReportRootGetteamsteamactivitydetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetteamsteamactivitydetailParameter();
            return await this.SendAsync<ReportRootGetteamsteamactivitydetailParameter, ReportRootGetteamsteamactivitydetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamactivitydetailResponse> ReportRootGetteamsteamactivitydetailAsync(ReportRootGetteamsteamactivitydetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetteamsteamactivitydetailParameter, ReportRootGetteamsteamactivitydetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsteamactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetteamsteamactivitydetailResponse> ReportRootGetteamsteamactivitydetailAsync(ReportRootGetteamsteamactivitydetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetteamsteamactivitydetailParameter, ReportRootGetteamsteamactivitydetailResponse>(parameter, cancellationToken);
        }
    }
}

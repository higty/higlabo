using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetteamsUseractivityUserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetTeamsUserActivityUserDetail: return $"/reports/getTeamsUserActivityUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetTeamsUserActivityUserDetail,
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
    public partial class ReportRootGetteamsUseractivityUserdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsUseractivityUserdetailResponse> ReportRootGetteamsUseractivityUserdetailAsync()
        {
            var p = new ReportRootGetteamsUseractivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetteamsUseractivityUserdetailParameter, ReportRootGetteamsUseractivityUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsUseractivityUserdetailResponse> ReportRootGetteamsUseractivityUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetteamsUseractivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetteamsUseractivityUserdetailParameter, ReportRootGetteamsUseractivityUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsUseractivityUserdetailResponse> ReportRootGetteamsUseractivityUserdetailAsync(ReportRootGetteamsUseractivityUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetteamsUseractivityUserdetailParameter, ReportRootGetteamsUseractivityUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetteamsUseractivityUserdetailResponse> ReportRootGetteamsUseractivityUserdetailAsync(ReportRootGetteamsUseractivityUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetteamsUseractivityUserdetailParameter, ReportRootGetteamsUseractivityUserdetailResponse>(parameter, cancellationToken);
        }
    }
}

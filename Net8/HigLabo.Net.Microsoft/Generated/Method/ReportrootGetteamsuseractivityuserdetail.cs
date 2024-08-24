using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetTeamsUserActivityUserdetailParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetTeamsUserActivityUserdetailResponse : RestApiResponse
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
        public async ValueTask<ReportRootGetTeamsUserActivityUserdetailResponse> ReportRootGetTeamsUserActivityUserdetailAsync()
        {
            var p = new ReportRootGetTeamsUserActivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetTeamsUserActivityUserdetailParameter, ReportRootGetTeamsUserActivityUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivityUserdetailResponse> ReportRootGetTeamsUserActivityUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetTeamsUserActivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetTeamsUserActivityUserdetailParameter, ReportRootGetTeamsUserActivityUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivityUserdetailResponse> ReportRootGetTeamsUserActivityUserdetailAsync(ReportRootGetTeamsUserActivityUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetTeamsUserActivityUserdetailParameter, ReportRootGetTeamsUserActivityUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getteamsuseractivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetTeamsUserActivityUserdetailResponse> ReportRootGetTeamsUserActivityUserdetailAsync(ReportRootGetTeamsUserActivityUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetTeamsUserActivityUserdetailParameter, ReportRootGetTeamsUserActivityUserdetailResponse>(parameter, cancellationToken);
        }
    }
}

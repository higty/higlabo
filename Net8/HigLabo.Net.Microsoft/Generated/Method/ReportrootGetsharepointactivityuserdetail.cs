using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetSharepointActivityUserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSharePointActivityUserDetail: return $"/reports/getSharePointActivityUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointActivityUserDetail,
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
    public partial class ReportRootGetSharepointActivityUserdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSharepointActivityUserdetailResponse> ReportRootGetSharepointActivityUserdetailAsync()
        {
            var p = new ReportRootGetSharepointActivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetSharepointActivityUserdetailParameter, ReportRootGetSharepointActivityUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSharepointActivityUserdetailResponse> ReportRootGetSharepointActivityUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetSharepointActivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetSharepointActivityUserdetailParameter, ReportRootGetSharepointActivityUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSharepointActivityUserdetailResponse> ReportRootGetSharepointActivityUserdetailAsync(ReportRootGetSharepointActivityUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetSharepointActivityUserdetailParameter, ReportRootGetSharepointActivityUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSharepointActivityUserdetailResponse> ReportRootGetSharepointActivityUserdetailAsync(ReportRootGetSharepointActivityUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetSharepointActivityUserdetailParameter, ReportRootGetSharepointActivityUserdetailResponse>(parameter, cancellationToken);
        }
    }
}

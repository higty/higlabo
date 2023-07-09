using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinessactivityUserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessActivityUserDetail: return $"/reports/getSkypeForBusinessActivityUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessActivityUserDetail,
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
    public partial class ReportRootGetskypeforbusinessactivityUserdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessactivityUserdetailResponse> ReportRootGetskypeforbusinessactivityUserdetailAsync()
        {
            var p = new ReportRootGetskypeforbusinessactivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessactivityUserdetailParameter, ReportRootGetskypeforbusinessactivityUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessactivityUserdetailResponse> ReportRootGetskypeforbusinessactivityUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinessactivityUserdetailParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinessactivityUserdetailParameter, ReportRootGetskypeforbusinessactivityUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessactivityUserdetailResponse> ReportRootGetskypeforbusinessactivityUserdetailAsync(ReportRootGetskypeforbusinessactivityUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessactivityUserdetailParameter, ReportRootGetskypeforbusinessactivityUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetskypeforbusinessactivityUserdetailResponse> ReportRootGetskypeforbusinessactivityUserdetailAsync(ReportRootGetskypeforbusinessactivityUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinessactivityUserdetailParameter, ReportRootGetskypeforbusinessactivityUserdetailResponse>(parameter, cancellationToken);
        }
    }
}

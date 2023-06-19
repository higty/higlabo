using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetonedriveusageAccountdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOneDriveUsageAccountDetail: return $"/reports/getOneDriveUsageAccountDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveUsageAccountDetail,
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
    public partial class ReportRootGetonedriveusageAccountdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetonedriveusageAccountdetailResponse> ReportRootGetonedriveusageAccountdetailAsync()
        {
            var p = new ReportRootGetonedriveusageAccountdetailParameter();
            return await this.SendAsync<ReportRootGetonedriveusageAccountdetailParameter, ReportRootGetonedriveusageAccountdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetonedriveusageAccountdetailResponse> ReportRootGetonedriveusageAccountdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetonedriveusageAccountdetailParameter();
            return await this.SendAsync<ReportRootGetonedriveusageAccountdetailParameter, ReportRootGetonedriveusageAccountdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetonedriveusageAccountdetailResponse> ReportRootGetonedriveusageAccountdetailAsync(ReportRootGetonedriveusageAccountdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetonedriveusageAccountdetailParameter, ReportRootGetonedriveusageAccountdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetonedriveusageAccountdetailResponse> ReportRootGetonedriveusageAccountdetailAsync(ReportRootGetonedriveusageAccountdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetonedriveusageAccountdetailParameter, ReportRootGetonedriveusageAccountdetailResponse>(parameter, cancellationToken);
        }
    }
}

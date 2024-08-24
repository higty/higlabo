using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetoffice365ServicesUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOffice365ServicesUserCounts: return $"/reports/getOffice365ServicesUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365ServicesUserCounts,
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
    public partial class ReportRootGetoffice365ServicesUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365ServicesUsercountsResponse> ReportRootGetoffice365ServicesUsercountsAsync()
        {
            var p = new ReportRootGetoffice365ServicesUsercountsParameter();
            return await this.SendAsync<ReportRootGetoffice365ServicesUsercountsParameter, ReportRootGetoffice365ServicesUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365ServicesUsercountsResponse> ReportRootGetoffice365ServicesUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetoffice365ServicesUsercountsParameter();
            return await this.SendAsync<ReportRootGetoffice365ServicesUsercountsParameter, ReportRootGetoffice365ServicesUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365ServicesUsercountsResponse> ReportRootGetoffice365ServicesUsercountsAsync(ReportRootGetoffice365ServicesUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetoffice365ServicesUsercountsParameter, ReportRootGetoffice365ServicesUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365ServicesUsercountsResponse> ReportRootGetoffice365ServicesUsercountsAsync(ReportRootGetoffice365ServicesUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetoffice365ServicesUsercountsParameter, ReportRootGetoffice365ServicesUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

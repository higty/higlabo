using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetoffice365activationcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOffice365ActivationCounts: return $"/reports/getOffice365ActivationCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365ActivationCounts,
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
    public partial class ReportRootGetoffice365activationcountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activationcountsResponse> ReportRootGetoffice365activationcountsAsync()
        {
            var p = new ReportRootGetoffice365activationcountsParameter();
            return await this.SendAsync<ReportRootGetoffice365activationcountsParameter, ReportRootGetoffice365activationcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activationcountsResponse> ReportRootGetoffice365activationcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetoffice365activationcountsParameter();
            return await this.SendAsync<ReportRootGetoffice365activationcountsParameter, ReportRootGetoffice365activationcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activationcountsResponse> ReportRootGetoffice365activationcountsAsync(ReportRootGetoffice365activationcountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetoffice365activationcountsParameter, ReportRootGetoffice365activationcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activationcountsResponse> ReportRootGetoffice365activationcountsAsync(ReportRootGetoffice365activationcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetoffice365activationcountsParameter, ReportRootGetoffice365activationcountsResponse>(parameter, cancellationToken);
        }
    }
}

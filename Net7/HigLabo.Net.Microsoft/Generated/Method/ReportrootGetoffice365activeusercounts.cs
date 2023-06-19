using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetoffice365activeUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOffice365ActiveUserCounts: return $"/reports/getOffice365ActiveUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365ActiveUserCounts,
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
    public partial class ReportRootGetoffice365activeUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activeUsercountsResponse> ReportRootGetoffice365activeUsercountsAsync()
        {
            var p = new ReportRootGetoffice365activeUsercountsParameter();
            return await this.SendAsync<ReportRootGetoffice365activeUsercountsParameter, ReportRootGetoffice365activeUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activeUsercountsResponse> ReportRootGetoffice365activeUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetoffice365activeUsercountsParameter();
            return await this.SendAsync<ReportRootGetoffice365activeUsercountsParameter, ReportRootGetoffice365activeUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activeUsercountsResponse> ReportRootGetoffice365activeUsercountsAsync(ReportRootGetoffice365activeUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetoffice365activeUsercountsParameter, ReportRootGetoffice365activeUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activeUsercountsResponse> ReportRootGetoffice365activeUsercountsAsync(ReportRootGetoffice365activeUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetoffice365activeUsercountsParameter, ReportRootGetoffice365activeUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

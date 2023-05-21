using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetoffice365GroupsactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOffice365GroupsActivityCounts: return $"/reports/getOffice365GroupsActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365GroupsActivityCounts,
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
    public partial class ReportRootGetoffice365GroupsactivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivitycountsResponse> ReportRootGetoffice365GroupsactivitycountsAsync()
        {
            var p = new ReportRootGetoffice365GroupsactivitycountsParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitycountsParameter, ReportRootGetoffice365GroupsactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivitycountsResponse> ReportRootGetoffice365GroupsactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetoffice365GroupsactivitycountsParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitycountsParameter, ReportRootGetoffice365GroupsactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivitycountsResponse> ReportRootGetoffice365GroupsactivitycountsAsync(ReportRootGetoffice365GroupsactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitycountsParameter, ReportRootGetoffice365GroupsactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivitycountsResponse> ReportRootGetoffice365GroupsactivitycountsAsync(ReportRootGetoffice365GroupsactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitycountsParameter, ReportRootGetoffice365GroupsactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

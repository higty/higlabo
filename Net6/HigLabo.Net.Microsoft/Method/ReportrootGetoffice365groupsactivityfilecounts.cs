using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetoffice365GroupsactivityfilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOffice365GroupsActivityFileCounts: return $"/reports/getOffice365GroupsActivityFileCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365GroupsActivityFileCounts,
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
    public partial class ReportRootGetoffice365GroupsactivityfilecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivityfilecountsResponse> ReportRootGetoffice365GroupsactivityfilecountsAsync()
        {
            var p = new ReportRootGetoffice365GroupsactivityfilecountsParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsactivityfilecountsParameter, ReportRootGetoffice365GroupsactivityfilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivityfilecountsResponse> ReportRootGetoffice365GroupsactivityfilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetoffice365GroupsactivityfilecountsParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsactivityfilecountsParameter, ReportRootGetoffice365GroupsactivityfilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivityfilecountsResponse> ReportRootGetoffice365GroupsactivityfilecountsAsync(ReportRootGetoffice365GroupsactivityfilecountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsactivityfilecountsParameter, ReportRootGetoffice365GroupsactivityfilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivityfilecountsResponse> ReportRootGetoffice365GroupsactivityfilecountsAsync(ReportRootGetoffice365GroupsactivityfilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsactivityfilecountsParameter, ReportRootGetoffice365GroupsactivityfilecountsResponse>(parameter, cancellationToken);
        }
    }
}

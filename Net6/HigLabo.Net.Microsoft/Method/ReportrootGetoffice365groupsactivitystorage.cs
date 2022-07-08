using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetoffice365GroupsactivitystorageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOffice365GroupsActivityStorage: return $"/reports/getOffice365GroupsActivityStorage";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365GroupsActivityStorage,
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
    public partial class ReportRootGetoffice365GroupsactivitystorageResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivitystorageResponse> ReportRootGetoffice365GroupsactivitystorageAsync()
        {
            var p = new ReportRootGetoffice365GroupsactivitystorageParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitystorageParameter, ReportRootGetoffice365GroupsactivitystorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivitystorageResponse> ReportRootGetoffice365GroupsactivitystorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetoffice365GroupsactivitystorageParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitystorageParameter, ReportRootGetoffice365GroupsactivitystorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivitystorageResponse> ReportRootGetoffice365GroupsactivitystorageAsync(ReportRootGetoffice365GroupsactivitystorageParameter parameter)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitystorageParameter, ReportRootGetoffice365GroupsactivitystorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetoffice365GroupsactivitystorageResponse> ReportRootGetoffice365GroupsactivitystorageAsync(ReportRootGetoffice365GroupsactivitystorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitystorageParameter, ReportRootGetoffice365GroupsactivitystorageResponse>(parameter, cancellationToken);
        }
    }
}

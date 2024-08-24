using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetoffice365GroupsActivitystorageParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetoffice365GroupsActivitystorageResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365GroupsActivitystorageResponse> ReportRootGetoffice365GroupsActivitystorageAsync()
        {
            var p = new ReportRootGetoffice365GroupsActivitystorageParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsActivitystorageParameter, ReportRootGetoffice365GroupsActivitystorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365GroupsActivitystorageResponse> ReportRootGetoffice365GroupsActivitystorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetoffice365GroupsActivitystorageParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsActivitystorageParameter, ReportRootGetoffice365GroupsActivitystorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365GroupsActivitystorageResponse> ReportRootGetoffice365GroupsActivitystorageAsync(ReportRootGetoffice365GroupsActivitystorageParameter parameter)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsActivitystorageParameter, ReportRootGetoffice365GroupsActivitystorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365GroupsActivitystorageResponse> ReportRootGetoffice365GroupsActivitystorageAsync(ReportRootGetoffice365GroupsActivitystorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsActivitystorageParameter, ReportRootGetoffice365GroupsActivitystorageResponse>(parameter, cancellationToken);
        }
    }
}

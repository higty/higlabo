using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetoffice365GroupsactivitydetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOffice365GroupsActivityDetail: return $"/reports/getOffice365GroupsActivityDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365GroupsActivityDetail,
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
    public partial class ReportRootGetoffice365GroupsactivitydetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365GroupsactivitydetailResponse> ReportRootGetoffice365GroupsactivitydetailAsync()
        {
            var p = new ReportRootGetoffice365GroupsactivitydetailParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitydetailParameter, ReportRootGetoffice365GroupsactivitydetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365GroupsactivitydetailResponse> ReportRootGetoffice365GroupsactivitydetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetoffice365GroupsactivitydetailParameter();
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitydetailParameter, ReportRootGetoffice365GroupsactivitydetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365GroupsactivitydetailResponse> ReportRootGetoffice365GroupsactivitydetailAsync(ReportRootGetoffice365GroupsactivitydetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitydetailParameter, ReportRootGetoffice365GroupsactivitydetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365GroupsactivitydetailResponse> ReportRootGetoffice365GroupsactivitydetailAsync(ReportRootGetoffice365GroupsactivitydetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetoffice365GroupsactivitydetailParameter, ReportRootGetoffice365GroupsactivitydetailResponse>(parameter, cancellationToken);
        }
    }
}

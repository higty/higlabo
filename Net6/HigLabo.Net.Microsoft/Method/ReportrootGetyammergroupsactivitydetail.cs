using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetyammerGroupsactivitydetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetYammerGroupsActivityDetail: return $"/reports/getYammerGroupsActivityDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerGroupsActivityDetail,
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
    public partial class ReportRootGetyammerGroupsactivitydetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammerGroupsactivitydetailResponse> ReportRootGetyammerGroupsactivitydetailAsync()
        {
            var p = new ReportRootGetyammerGroupsactivitydetailParameter();
            return await this.SendAsync<ReportRootGetyammerGroupsactivitydetailParameter, ReportRootGetyammerGroupsactivitydetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammerGroupsactivitydetailResponse> ReportRootGetyammerGroupsactivitydetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammerGroupsactivitydetailParameter();
            return await this.SendAsync<ReportRootGetyammerGroupsactivitydetailParameter, ReportRootGetyammerGroupsactivitydetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammerGroupsactivitydetailResponse> ReportRootGetyammerGroupsactivitydetailAsync(ReportRootGetyammerGroupsactivitydetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammerGroupsactivitydetailParameter, ReportRootGetyammerGroupsactivitydetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammerGroupsactivitydetailResponse> ReportRootGetyammerGroupsactivitydetailAsync(ReportRootGetyammerGroupsactivitydetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammerGroupsactivitydetailParameter, ReportRootGetyammerGroupsactivitydetailResponse>(parameter, cancellationToken);
        }
    }
}

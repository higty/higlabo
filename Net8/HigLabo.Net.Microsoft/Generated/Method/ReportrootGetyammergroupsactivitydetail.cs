using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetyammerGroupsActivitydetailParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetyammerGroupsActivitydetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerGroupsActivitydetailResponse> ReportRootGetyammerGroupsActivitydetailAsync()
        {
            var p = new ReportRootGetyammerGroupsActivitydetailParameter();
            return await this.SendAsync<ReportRootGetyammerGroupsActivitydetailParameter, ReportRootGetyammerGroupsActivitydetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerGroupsActivitydetailResponse> ReportRootGetyammerGroupsActivitydetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammerGroupsActivitydetailParameter();
            return await this.SendAsync<ReportRootGetyammerGroupsActivitydetailParameter, ReportRootGetyammerGroupsActivitydetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerGroupsActivitydetailResponse> ReportRootGetyammerGroupsActivitydetailAsync(ReportRootGetyammerGroupsActivitydetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammerGroupsActivitydetailParameter, ReportRootGetyammerGroupsActivitydetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammergroupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerGroupsActivitydetailResponse> ReportRootGetyammerGroupsActivitydetailAsync(ReportRootGetyammerGroupsActivitydetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammerGroupsActivitydetailParameter, ReportRootGetyammerGroupsActivitydetailResponse>(parameter, cancellationToken);
        }
    }
}

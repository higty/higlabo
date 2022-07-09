using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetyammeractivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetYammerActivityUserCounts: return $"/reports/getYammerActivityUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerActivityUserCounts,
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
    public partial class ReportRootGetyammeractivityUsercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammeractivityUsercountsResponse> ReportRootGetyammeractivityUsercountsAsync()
        {
            var p = new ReportRootGetyammeractivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetyammeractivityUsercountsParameter, ReportRootGetyammeractivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammeractivityUsercountsResponse> ReportRootGetyammeractivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammeractivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetyammeractivityUsercountsParameter, ReportRootGetyammeractivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammeractivityUsercountsResponse> ReportRootGetyammeractivityUsercountsAsync(ReportRootGetyammeractivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammeractivityUsercountsParameter, ReportRootGetyammeractivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammeractivityUsercountsResponse> ReportRootGetyammeractivityUsercountsAsync(ReportRootGetyammeractivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammeractivityUsercountsParameter, ReportRootGetyammeractivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

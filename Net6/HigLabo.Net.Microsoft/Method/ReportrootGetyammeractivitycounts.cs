using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetyammeractivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetYammerActivityCounts: return $"/reports/getYammerActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetYammerActivityCounts,
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
    public partial class ReportRootGetyammeractivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammeractivitycountsResponse> ReportRootGetyammeractivitycountsAsync()
        {
            var p = new ReportRootGetyammeractivitycountsParameter();
            return await this.SendAsync<ReportRootGetyammeractivitycountsParameter, ReportRootGetyammeractivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammeractivitycountsResponse> ReportRootGetyammeractivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammeractivitycountsParameter();
            return await this.SendAsync<ReportRootGetyammeractivitycountsParameter, ReportRootGetyammeractivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammeractivitycountsResponse> ReportRootGetyammeractivitycountsAsync(ReportRootGetyammeractivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammeractivitycountsParameter, ReportRootGetyammeractivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetyammeractivitycountsResponse> ReportRootGetyammeractivitycountsAsync(ReportRootGetyammeractivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammeractivitycountsParameter, ReportRootGetyammeractivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

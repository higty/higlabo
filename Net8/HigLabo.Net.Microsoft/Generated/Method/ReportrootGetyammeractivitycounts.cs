using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetyammerActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetyammerActivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerActivitycountsResponse> ReportRootGetyammerActivitycountsAsync()
        {
            var p = new ReportRootGetyammerActivitycountsParameter();
            return await this.SendAsync<ReportRootGetyammerActivitycountsParameter, ReportRootGetyammerActivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerActivitycountsResponse> ReportRootGetyammerActivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetyammerActivitycountsParameter();
            return await this.SendAsync<ReportRootGetyammerActivitycountsParameter, ReportRootGetyammerActivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerActivitycountsResponse> ReportRootGetyammerActivitycountsAsync(ReportRootGetyammerActivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetyammerActivitycountsParameter, ReportRootGetyammerActivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getyammeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetyammerActivitycountsResponse> ReportRootGetyammerActivitycountsAsync(ReportRootGetyammerActivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetyammerActivitycountsParameter, ReportRootGetyammerActivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

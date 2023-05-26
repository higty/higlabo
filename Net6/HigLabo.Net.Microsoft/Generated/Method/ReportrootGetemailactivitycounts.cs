using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetemailactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetEmailActivityCounts: return $"/reports/getEmailActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailActivityCounts,
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
    public partial class ReportRootGetemailactivitycountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetemailactivitycountsResponse> ReportRootGetemailactivitycountsAsync()
        {
            var p = new ReportRootGetemailactivitycountsParameter();
            return await this.SendAsync<ReportRootGetemailactivitycountsParameter, ReportRootGetemailactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetemailactivitycountsResponse> ReportRootGetemailactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetemailactivitycountsParameter();
            return await this.SendAsync<ReportRootGetemailactivitycountsParameter, ReportRootGetemailactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetemailactivitycountsResponse> ReportRootGetemailactivitycountsAsync(ReportRootGetemailactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetemailactivitycountsParameter, ReportRootGetemailactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetemailactivitycountsResponse> ReportRootGetemailactivitycountsAsync(ReportRootGetemailactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetemailactivitycountsParameter, ReportRootGetemailactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

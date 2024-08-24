using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetemailActivitycountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetemailActivitycountsResponse : RestApiResponse
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
        public async ValueTask<ReportRootGetemailActivitycountsResponse> ReportRootGetemailActivitycountsAsync()
        {
            var p = new ReportRootGetemailActivitycountsParameter();
            return await this.SendAsync<ReportRootGetemailActivitycountsParameter, ReportRootGetemailActivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailActivitycountsResponse> ReportRootGetemailActivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetemailActivitycountsParameter();
            return await this.SendAsync<ReportRootGetemailActivitycountsParameter, ReportRootGetemailActivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailActivitycountsResponse> ReportRootGetemailActivitycountsAsync(ReportRootGetemailActivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetemailActivitycountsParameter, ReportRootGetemailActivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailActivitycountsResponse> ReportRootGetemailActivitycountsAsync(ReportRootGetemailActivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetemailActivitycountsParameter, ReportRootGetemailActivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

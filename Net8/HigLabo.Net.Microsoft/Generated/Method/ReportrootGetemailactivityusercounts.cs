using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetemailactivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetEmailActivityUserCounts: return $"/reports/getEmailActivityUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailActivityUserCounts,
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
    public partial class ReportRootGetemailactivityUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailactivityUsercountsResponse> ReportRootGetemailactivityUsercountsAsync()
        {
            var p = new ReportRootGetemailactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetemailactivityUsercountsParameter, ReportRootGetemailactivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailactivityUsercountsResponse> ReportRootGetemailactivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetemailactivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetemailactivityUsercountsParameter, ReportRootGetemailactivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailactivityUsercountsResponse> ReportRootGetemailactivityUsercountsAsync(ReportRootGetemailactivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetemailactivityUsercountsParameter, ReportRootGetemailactivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailactivityUsercountsResponse> ReportRootGetemailactivityUsercountsAsync(ReportRootGetemailactivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetemailactivityUsercountsParameter, ReportRootGetemailactivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

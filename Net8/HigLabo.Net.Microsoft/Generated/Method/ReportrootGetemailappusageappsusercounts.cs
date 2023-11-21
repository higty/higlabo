using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetemailappusageappsUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetEmailAppUsageAppsUserCounts: return $"/reports/getEmailAppUsageAppsUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailAppUsageAppsUserCounts,
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
    public partial class ReportRootGetemailappusageappsUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageappsUsercountsResponse> ReportRootGetemailappusageappsUsercountsAsync()
        {
            var p = new ReportRootGetemailappusageappsUsercountsParameter();
            return await this.SendAsync<ReportRootGetemailappusageappsUsercountsParameter, ReportRootGetemailappusageappsUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageappsUsercountsResponse> ReportRootGetemailappusageappsUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetemailappusageappsUsercountsParameter();
            return await this.SendAsync<ReportRootGetemailappusageappsUsercountsParameter, ReportRootGetemailappusageappsUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageappsUsercountsResponse> ReportRootGetemailappusageappsUsercountsAsync(ReportRootGetemailappusageappsUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetemailappusageappsUsercountsParameter, ReportRootGetemailappusageappsUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageappsUsercountsResponse> ReportRootGetemailappusageappsUsercountsAsync(ReportRootGetemailappusageappsUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetemailappusageappsUsercountsParameter, ReportRootGetemailappusageappsUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

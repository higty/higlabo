using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetemailappusageappsUsercountsResponse> ReportRootGetemailappusageappsUsercountsAsync()
        {
            var p = new ReportRootGetemailappusageappsUsercountsParameter();
            return await this.SendAsync<ReportRootGetemailappusageappsUsercountsParameter, ReportRootGetemailappusageappsUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetemailappusageappsUsercountsResponse> ReportRootGetemailappusageappsUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetemailappusageappsUsercountsParameter();
            return await this.SendAsync<ReportRootGetemailappusageappsUsercountsParameter, ReportRootGetemailappusageappsUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetemailappusageappsUsercountsResponse> ReportRootGetemailappusageappsUsercountsAsync(ReportRootGetemailappusageappsUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetemailappusageappsUsercountsParameter, ReportRootGetemailappusageappsUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetemailappusageappsUsercountsResponse> ReportRootGetemailappusageappsUsercountsAsync(ReportRootGetemailappusageappsUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetemailappusageappsUsercountsParameter, ReportRootGetemailappusageappsUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

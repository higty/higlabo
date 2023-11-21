using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetemailappusageversionsUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetEmailAppUsageVersionsUserCounts: return $"/reports/getEmailAppUsageVersionsUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailAppUsageVersionsUserCounts,
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
    public partial class ReportRootGetemailappusageversionsUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageversionsUsercountsResponse> ReportRootGetemailappusageversionsUsercountsAsync()
        {
            var p = new ReportRootGetemailappusageversionsUsercountsParameter();
            return await this.SendAsync<ReportRootGetemailappusageversionsUsercountsParameter, ReportRootGetemailappusageversionsUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageversionsUsercountsResponse> ReportRootGetemailappusageversionsUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetemailappusageversionsUsercountsParameter();
            return await this.SendAsync<ReportRootGetemailappusageversionsUsercountsParameter, ReportRootGetemailappusageversionsUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageversionsUsercountsResponse> ReportRootGetemailappusageversionsUsercountsAsync(ReportRootGetemailappusageversionsUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetemailappusageversionsUsercountsParameter, ReportRootGetemailappusageversionsUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetemailappusageversionsUsercountsResponse> ReportRootGetemailappusageversionsUsercountsAsync(ReportRootGetemailappusageversionsUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetemailappusageversionsUsercountsParameter, ReportRootGetemailappusageversionsUsercountsResponse>(parameter, cancellationToken);
        }
    }
}

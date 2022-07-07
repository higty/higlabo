using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetemailappusageappsusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailAppUsageAppsUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetEmailAppUsageAppsUserCounts: return $"/reports/getEmailAppUsageAppsUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class ReportrootGetemailappusageappsusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageappsusercountsResponse> ReportrootGetemailappusageappsusercountsAsync()
        {
            var p = new ReportrootGetemailappusageappsusercountsParameter();
            return await this.SendAsync<ReportrootGetemailappusageappsusercountsParameter, ReportrootGetemailappusageappsusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageappsusercountsResponse> ReportrootGetemailappusageappsusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetemailappusageappsusercountsParameter();
            return await this.SendAsync<ReportrootGetemailappusageappsusercountsParameter, ReportrootGetemailappusageappsusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageappsusercountsResponse> ReportrootGetemailappusageappsusercountsAsync(ReportrootGetemailappusageappsusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetemailappusageappsusercountsParameter, ReportrootGetemailappusageappsusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageappsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageappsusercountsResponse> ReportrootGetemailappusageappsusercountsAsync(ReportrootGetemailappusageappsusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetemailappusageappsusercountsParameter, ReportrootGetemailappusageappsusercountsResponse>(parameter, cancellationToken);
        }
    }
}

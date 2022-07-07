using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetemailappusageversionsusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailAppUsageVersionsUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetEmailAppUsageVersionsUserCounts: return $"/reports/getEmailAppUsageVersionsUserCounts";
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
    public partial class ReportrootGetemailappusageversionsusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageversionsusercountsResponse> ReportrootGetemailappusageversionsusercountsAsync()
        {
            var p = new ReportrootGetemailappusageversionsusercountsParameter();
            return await this.SendAsync<ReportrootGetemailappusageversionsusercountsParameter, ReportrootGetemailappusageversionsusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageversionsusercountsResponse> ReportrootGetemailappusageversionsusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetemailappusageversionsusercountsParameter();
            return await this.SendAsync<ReportrootGetemailappusageversionsusercountsParameter, ReportrootGetemailappusageversionsusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageversionsusercountsResponse> ReportrootGetemailappusageversionsusercountsAsync(ReportrootGetemailappusageversionsusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetemailappusageversionsusercountsParameter, ReportrootGetemailappusageversionsusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageversionsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageversionsusercountsResponse> ReportrootGetemailappusageversionsusercountsAsync(ReportrootGetemailappusageversionsusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetemailappusageversionsusercountsParameter, ReportrootGetemailappusageversionsusercountsResponse>(parameter, cancellationToken);
        }
    }
}

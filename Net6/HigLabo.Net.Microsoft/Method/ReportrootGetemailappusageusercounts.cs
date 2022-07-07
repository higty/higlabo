using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetemailappusageusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailAppUsageUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetEmailAppUsageUserCounts: return $"/reports/getEmailAppUsageUserCounts";
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
    public partial class ReportrootGetemailappusageusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageusercountsResponse> ReportrootGetemailappusageusercountsAsync()
        {
            var p = new ReportrootGetemailappusageusercountsParameter();
            return await this.SendAsync<ReportrootGetemailappusageusercountsParameter, ReportrootGetemailappusageusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageusercountsResponse> ReportrootGetemailappusageusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetemailappusageusercountsParameter();
            return await this.SendAsync<ReportrootGetemailappusageusercountsParameter, ReportrootGetemailappusageusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageusercountsResponse> ReportrootGetemailappusageusercountsAsync(ReportrootGetemailappusageusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetemailappusageusercountsParameter, ReportrootGetemailappusageusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageusercountsResponse> ReportrootGetemailappusageusercountsAsync(ReportrootGetemailappusageusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetemailappusageusercountsParameter, ReportrootGetemailappusageusercountsResponse>(parameter, cancellationToken);
        }
    }
}

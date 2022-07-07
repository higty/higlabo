using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetemailactivityusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailActivityUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetEmailActivityUserCounts: return $"/reports/getEmailActivityUserCounts";
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
    public partial class ReportrootGetemailactivityusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivityusercountsResponse> ReportrootGetemailactivityusercountsAsync()
        {
            var p = new ReportrootGetemailactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetemailactivityusercountsParameter, ReportrootGetemailactivityusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivityusercountsResponse> ReportrootGetemailactivityusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetemailactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetemailactivityusercountsParameter, ReportrootGetemailactivityusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivityusercountsResponse> ReportrootGetemailactivityusercountsAsync(ReportrootGetemailactivityusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetemailactivityusercountsParameter, ReportrootGetemailactivityusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivityusercountsResponse> ReportrootGetemailactivityusercountsAsync(ReportrootGetemailactivityusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetemailactivityusercountsParameter, ReportrootGetemailactivityusercountsResponse>(parameter, cancellationToken);
        }
    }
}

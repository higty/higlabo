using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetemailactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailActivityCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetEmailActivityCounts: return $"/reports/getEmailActivityCounts";
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
    public partial class ReportrootGetemailactivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivitycountsResponse> ReportrootGetemailactivitycountsAsync()
        {
            var p = new ReportrootGetemailactivitycountsParameter();
            return await this.SendAsync<ReportrootGetemailactivitycountsParameter, ReportrootGetemailactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivitycountsResponse> ReportrootGetemailactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetemailactivitycountsParameter();
            return await this.SendAsync<ReportrootGetemailactivitycountsParameter, ReportrootGetemailactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivitycountsResponse> ReportrootGetemailactivitycountsAsync(ReportrootGetemailactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetemailactivitycountsParameter, ReportrootGetemailactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivitycountsResponse> ReportrootGetemailactivitycountsAsync(ReportrootGetemailactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetemailactivitycountsParameter, ReportrootGetemailactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

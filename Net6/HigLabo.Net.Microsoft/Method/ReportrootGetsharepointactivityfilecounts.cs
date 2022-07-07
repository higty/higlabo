using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetsharepointactivityfilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointActivityFileCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSharePointActivityFileCounts: return $"/reports/getSharePointActivityFileCounts";
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
    public partial class ReportrootGetsharepointactivityfilecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityfilecountsResponse> ReportrootGetsharepointactivityfilecountsAsync()
        {
            var p = new ReportrootGetsharepointactivityfilecountsParameter();
            return await this.SendAsync<ReportrootGetsharepointactivityfilecountsParameter, ReportrootGetsharepointactivityfilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityfilecountsResponse> ReportrootGetsharepointactivityfilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetsharepointactivityfilecountsParameter();
            return await this.SendAsync<ReportrootGetsharepointactivityfilecountsParameter, ReportrootGetsharepointactivityfilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityfilecountsResponse> ReportrootGetsharepointactivityfilecountsAsync(ReportrootGetsharepointactivityfilecountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetsharepointactivityfilecountsParameter, ReportrootGetsharepointactivityfilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getsharepointactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetsharepointactivityfilecountsResponse> ReportrootGetsharepointactivityfilecountsAsync(ReportrootGetsharepointactivityfilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetsharepointactivityfilecountsParameter, ReportrootGetsharepointactivityfilecountsResponse>(parameter, cancellationToken);
        }
    }
}

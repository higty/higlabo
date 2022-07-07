using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessactivityusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessActivityUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessActivityUserCounts: return $"/reports/getSkypeForBusinessActivityUserCounts";
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
    public partial class ReportrootGetskypeforbusinessactivityusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivityusercountsResponse> ReportrootGetskypeforbusinessactivityusercountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessactivityusercountsParameter, ReportrootGetskypeforbusinessactivityusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivityusercountsResponse> ReportrootGetskypeforbusinessactivityusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessactivityusercountsParameter, ReportrootGetskypeforbusinessactivityusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivityusercountsResponse> ReportrootGetskypeforbusinessactivityusercountsAsync(ReportrootGetskypeforbusinessactivityusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessactivityusercountsParameter, ReportrootGetskypeforbusinessactivityusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivityusercountsResponse> ReportrootGetskypeforbusinessactivityusercountsAsync(ReportrootGetskypeforbusinessactivityusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessactivityusercountsParameter, ReportrootGetskypeforbusinessactivityusercountsResponse>(parameter, cancellationToken);
        }
    }
}

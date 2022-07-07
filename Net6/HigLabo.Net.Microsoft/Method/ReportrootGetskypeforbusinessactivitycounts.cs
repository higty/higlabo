using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetskypeforbusinessactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessActivityCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetSkypeForBusinessActivityCounts: return $"/reports/getSkypeForBusinessActivityCounts";
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
    public partial class ReportrootGetskypeforbusinessactivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivitycountsResponse> ReportrootGetskypeforbusinessactivitycountsAsync()
        {
            var p = new ReportrootGetskypeforbusinessactivitycountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessactivitycountsParameter, ReportrootGetskypeforbusinessactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivitycountsResponse> ReportrootGetskypeforbusinessactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetskypeforbusinessactivitycountsParameter();
            return await this.SendAsync<ReportrootGetskypeforbusinessactivitycountsParameter, ReportrootGetskypeforbusinessactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivitycountsResponse> ReportrootGetskypeforbusinessactivitycountsAsync(ReportrootGetskypeforbusinessactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessactivitycountsParameter, ReportrootGetskypeforbusinessactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinessactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetskypeforbusinessactivitycountsResponse> ReportrootGetskypeforbusinessactivitycountsAsync(ReportrootGetskypeforbusinessactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetskypeforbusinessactivitycountsParameter, ReportrootGetskypeforbusinessactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

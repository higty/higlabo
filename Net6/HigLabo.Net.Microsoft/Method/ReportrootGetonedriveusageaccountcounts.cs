using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetonedriveusageaccountcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveUsageAccountCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOneDriveUsageAccountCounts: return $"/reports/getOneDriveUsageAccountCounts";
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
    public partial class ReportrootGetonedriveusageaccountcountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusageaccountcountsResponse> ReportrootGetonedriveusageaccountcountsAsync()
        {
            var p = new ReportrootGetonedriveusageaccountcountsParameter();
            return await this.SendAsync<ReportrootGetonedriveusageaccountcountsParameter, ReportrootGetonedriveusageaccountcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusageaccountcountsResponse> ReportrootGetonedriveusageaccountcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetonedriveusageaccountcountsParameter();
            return await this.SendAsync<ReportrootGetonedriveusageaccountcountsParameter, ReportrootGetonedriveusageaccountcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusageaccountcountsResponse> ReportrootGetonedriveusageaccountcountsAsync(ReportrootGetonedriveusageaccountcountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetonedriveusageaccountcountsParameter, ReportrootGetonedriveusageaccountcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusageaccountcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusageaccountcountsResponse> ReportrootGetonedriveusageaccountcountsAsync(ReportrootGetonedriveusageaccountcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetonedriveusageaccountcountsParameter, ReportrootGetonedriveusageaccountcountsResponse>(parameter, cancellationToken);
        }
    }
}

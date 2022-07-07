using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetonedriveusagestorageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveUsageStorage,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOneDriveUsageStorage: return $"/reports/getOneDriveUsageStorage";
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
    public partial class ReportrootGetonedriveusagestorageResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusagestorageResponse> ReportrootGetonedriveusagestorageAsync()
        {
            var p = new ReportrootGetonedriveusagestorageParameter();
            return await this.SendAsync<ReportrootGetonedriveusagestorageParameter, ReportrootGetonedriveusagestorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusagestorageResponse> ReportrootGetonedriveusagestorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetonedriveusagestorageParameter();
            return await this.SendAsync<ReportrootGetonedriveusagestorageParameter, ReportrootGetonedriveusagestorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusagestorageResponse> ReportrootGetonedriveusagestorageAsync(ReportrootGetonedriveusagestorageParameter parameter)
        {
            return await this.SendAsync<ReportrootGetonedriveusagestorageParameter, ReportrootGetonedriveusagestorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusagestorageResponse> ReportrootGetonedriveusagestorageAsync(ReportrootGetonedriveusagestorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetonedriveusagestorageParameter, ReportrootGetonedriveusagestorageResponse>(parameter, cancellationToken);
        }
    }
}

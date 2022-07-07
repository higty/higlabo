using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetonedriveusagefilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveUsageFileCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOneDriveUsageFileCounts: return $"/reports/getOneDriveUsageFileCounts";
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
    public partial class ReportrootGetonedriveusagefilecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusagefilecountsResponse> ReportrootGetonedriveusagefilecountsAsync()
        {
            var p = new ReportrootGetonedriveusagefilecountsParameter();
            return await this.SendAsync<ReportrootGetonedriveusagefilecountsParameter, ReportrootGetonedriveusagefilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusagefilecountsResponse> ReportrootGetonedriveusagefilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetonedriveusagefilecountsParameter();
            return await this.SendAsync<ReportrootGetonedriveusagefilecountsParameter, ReportrootGetonedriveusagefilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusagefilecountsResponse> ReportrootGetonedriveusagefilecountsAsync(ReportrootGetonedriveusagefilecountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetonedriveusagefilecountsParameter, ReportrootGetonedriveusagefilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagefilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveusagefilecountsResponse> ReportrootGetonedriveusagefilecountsAsync(ReportrootGetonedriveusagefilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetonedriveusagefilecountsParameter, ReportrootGetonedriveusagefilecountsResponse>(parameter, cancellationToken);
        }
    }
}

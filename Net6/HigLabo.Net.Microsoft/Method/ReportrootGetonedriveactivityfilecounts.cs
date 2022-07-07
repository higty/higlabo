using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetonedriveactivityfilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveActivityFileCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOneDriveActivityFileCounts: return $"/reports/getOneDriveActivityFileCounts";
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
    public partial class ReportrootGetonedriveactivityfilecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityfilecountsResponse> ReportrootGetonedriveactivityfilecountsAsync()
        {
            var p = new ReportrootGetonedriveactivityfilecountsParameter();
            return await this.SendAsync<ReportrootGetonedriveactivityfilecountsParameter, ReportrootGetonedriveactivityfilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityfilecountsResponse> ReportrootGetonedriveactivityfilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetonedriveactivityfilecountsParameter();
            return await this.SendAsync<ReportrootGetonedriveactivityfilecountsParameter, ReportrootGetonedriveactivityfilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityfilecountsResponse> ReportrootGetonedriveactivityfilecountsAsync(ReportrootGetonedriveactivityfilecountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetonedriveactivityfilecountsParameter, ReportrootGetonedriveactivityfilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityfilecountsResponse> ReportrootGetonedriveactivityfilecountsAsync(ReportrootGetonedriveactivityfilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetonedriveactivityfilecountsParameter, ReportrootGetonedriveactivityfilecountsResponse>(parameter, cancellationToken);
        }
    }
}

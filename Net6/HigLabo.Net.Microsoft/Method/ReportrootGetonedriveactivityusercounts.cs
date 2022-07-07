using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetonedriveactivityusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveActivityUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOneDriveActivityUserCounts: return $"/reports/getOneDriveActivityUserCounts";
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
    public partial class ReportrootGetonedriveactivityusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityusercountsResponse> ReportrootGetonedriveactivityusercountsAsync()
        {
            var p = new ReportrootGetonedriveactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetonedriveactivityusercountsParameter, ReportrootGetonedriveactivityusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityusercountsResponse> ReportrootGetonedriveactivityusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetonedriveactivityusercountsParameter();
            return await this.SendAsync<ReportrootGetonedriveactivityusercountsParameter, ReportrootGetonedriveactivityusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityusercountsResponse> ReportrootGetonedriveactivityusercountsAsync(ReportrootGetonedriveactivityusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetonedriveactivityusercountsParameter, ReportrootGetonedriveactivityusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveactivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetonedriveactivityusercountsResponse> ReportrootGetonedriveactivityusercountsAsync(ReportrootGetonedriveactivityusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetonedriveactivityusercountsParameter, ReportrootGetonedriveactivityusercountsResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365activationsusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365ActivationsUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365ActivationsUserCounts: return $"/reports/getOffice365ActivationsUserCounts";
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
    public partial class ReportrootGetoffice365activationsusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activationsusercountsResponse> ReportrootGetoffice365activationsusercountsAsync()
        {
            var p = new ReportrootGetoffice365activationsusercountsParameter();
            return await this.SendAsync<ReportrootGetoffice365activationsusercountsParameter, ReportrootGetoffice365activationsusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activationsusercountsResponse> ReportrootGetoffice365activationsusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365activationsusercountsParameter();
            return await this.SendAsync<ReportrootGetoffice365activationsusercountsParameter, ReportrootGetoffice365activationsusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activationsusercountsResponse> ReportrootGetoffice365activationsusercountsAsync(ReportrootGetoffice365activationsusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365activationsusercountsParameter, ReportrootGetoffice365activationsusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activationsusercountsResponse> ReportrootGetoffice365activationsusercountsAsync(ReportrootGetoffice365activationsusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365activationsusercountsParameter, ReportrootGetoffice365activationsusercountsResponse>(parameter, cancellationToken);
        }
    }
}

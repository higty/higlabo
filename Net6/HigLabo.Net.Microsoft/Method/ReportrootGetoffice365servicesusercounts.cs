using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365servicesusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365ServicesUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365ServicesUserCounts: return $"/reports/getOffice365ServicesUserCounts";
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
    public partial class ReportrootGetoffice365servicesusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365servicesusercountsResponse> ReportrootGetoffice365servicesusercountsAsync()
        {
            var p = new ReportrootGetoffice365servicesusercountsParameter();
            return await this.SendAsync<ReportrootGetoffice365servicesusercountsParameter, ReportrootGetoffice365servicesusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365servicesusercountsResponse> ReportrootGetoffice365servicesusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365servicesusercountsParameter();
            return await this.SendAsync<ReportrootGetoffice365servicesusercountsParameter, ReportrootGetoffice365servicesusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365servicesusercountsResponse> ReportrootGetoffice365servicesusercountsAsync(ReportrootGetoffice365servicesusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365servicesusercountsParameter, ReportrootGetoffice365servicesusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365servicesusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365servicesusercountsResponse> ReportrootGetoffice365servicesusercountsAsync(ReportrootGetoffice365servicesusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365servicesusercountsParameter, ReportrootGetoffice365servicesusercountsResponse>(parameter, cancellationToken);
        }
    }
}

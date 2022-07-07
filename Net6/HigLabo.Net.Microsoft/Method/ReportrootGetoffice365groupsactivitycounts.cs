using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365groupsactivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365GroupsActivityCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365GroupsActivityCounts: return $"/reports/getOffice365GroupsActivityCounts";
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
    public partial class ReportrootGetoffice365groupsactivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitycountsResponse> ReportrootGetoffice365groupsactivitycountsAsync()
        {
            var p = new ReportrootGetoffice365groupsactivitycountsParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivitycountsParameter, ReportrootGetoffice365groupsactivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitycountsResponse> ReportrootGetoffice365groupsactivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365groupsactivitycountsParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivitycountsParameter, ReportrootGetoffice365groupsactivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitycountsResponse> ReportrootGetoffice365groupsactivitycountsAsync(ReportrootGetoffice365groupsactivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivitycountsParameter, ReportrootGetoffice365groupsactivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitycountsResponse> ReportrootGetoffice365groupsactivitycountsAsync(ReportrootGetoffice365groupsactivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivitycountsParameter, ReportrootGetoffice365groupsactivitycountsResponse>(parameter, cancellationToken);
        }
    }
}

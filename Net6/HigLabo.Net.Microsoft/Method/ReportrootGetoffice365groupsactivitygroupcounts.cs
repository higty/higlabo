using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365groupsactivitygroupcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365GroupsActivityGroupCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365GroupsActivityGroupCounts: return $"/reports/getOffice365GroupsActivityGroupCounts";
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
    public partial class ReportrootGetoffice365groupsactivitygroupcountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitygroupcountsResponse> ReportrootGetoffice365groupsactivitygroupcountsAsync()
        {
            var p = new ReportrootGetoffice365groupsactivitygroupcountsParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivitygroupcountsParameter, ReportrootGetoffice365groupsactivitygroupcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitygroupcountsResponse> ReportrootGetoffice365groupsactivitygroupcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365groupsactivitygroupcountsParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivitygroupcountsParameter, ReportrootGetoffice365groupsactivitygroupcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitygroupcountsResponse> ReportrootGetoffice365groupsactivitygroupcountsAsync(ReportrootGetoffice365groupsactivitygroupcountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivitygroupcountsParameter, ReportrootGetoffice365groupsactivitygroupcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitygroupcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitygroupcountsResponse> ReportrootGetoffice365groupsactivitygroupcountsAsync(ReportrootGetoffice365groupsactivitygroupcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivitygroupcountsParameter, ReportrootGetoffice365groupsactivitygroupcountsResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365groupsactivityfilecountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365GroupsActivityFileCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365GroupsActivityFileCounts: return $"/reports/getOffice365GroupsActivityFileCounts";
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
    public partial class ReportrootGetoffice365groupsactivityfilecountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivityfilecountsResponse> ReportrootGetoffice365groupsactivityfilecountsAsync()
        {
            var p = new ReportrootGetoffice365groupsactivityfilecountsParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivityfilecountsParameter, ReportrootGetoffice365groupsactivityfilecountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivityfilecountsResponse> ReportrootGetoffice365groupsactivityfilecountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365groupsactivityfilecountsParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivityfilecountsParameter, ReportrootGetoffice365groupsactivityfilecountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivityfilecountsResponse> ReportrootGetoffice365groupsactivityfilecountsAsync(ReportrootGetoffice365groupsactivityfilecountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivityfilecountsParameter, ReportrootGetoffice365groupsactivityfilecountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivityfilecounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivityfilecountsResponse> ReportrootGetoffice365groupsactivityfilecountsAsync(ReportrootGetoffice365groupsactivityfilecountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivityfilecountsParameter, ReportrootGetoffice365groupsactivityfilecountsResponse>(parameter, cancellationToken);
        }
    }
}

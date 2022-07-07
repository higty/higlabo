using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365groupsactivitystorageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365GroupsActivityStorage,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365GroupsActivityStorage: return $"/reports/getOffice365GroupsActivityStorage";
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
    public partial class ReportrootGetoffice365groupsactivitystorageResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitystorageResponse> ReportrootGetoffice365groupsactivitystorageAsync()
        {
            var p = new ReportrootGetoffice365groupsactivitystorageParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivitystorageParameter, ReportrootGetoffice365groupsactivitystorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitystorageResponse> ReportrootGetoffice365groupsactivitystorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365groupsactivitystorageParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivitystorageParameter, ReportrootGetoffice365groupsactivitystorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitystorageResponse> ReportrootGetoffice365groupsactivitystorageAsync(ReportrootGetoffice365groupsactivitystorageParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivitystorageParameter, ReportrootGetoffice365groupsactivitystorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitystorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitystorageResponse> ReportrootGetoffice365groupsactivitystorageAsync(ReportrootGetoffice365groupsactivitystorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivitystorageParameter, ReportrootGetoffice365groupsactivitystorageResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365groupsactivitydetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365GroupsActivityDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365GroupsActivityDetail: return $"/reports/getOffice365GroupsActivityDetail";
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
    public partial class ReportrootGetoffice365groupsactivitydetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitydetailResponse> ReportrootGetoffice365groupsactivitydetailAsync()
        {
            var p = new ReportrootGetoffice365groupsactivitydetailParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivitydetailParameter, ReportrootGetoffice365groupsactivitydetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitydetailResponse> ReportrootGetoffice365groupsactivitydetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365groupsactivitydetailParameter();
            return await this.SendAsync<ReportrootGetoffice365groupsactivitydetailParameter, ReportrootGetoffice365groupsactivitydetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitydetailResponse> ReportrootGetoffice365groupsactivitydetailAsync(ReportrootGetoffice365groupsactivitydetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivitydetailParameter, ReportrootGetoffice365groupsactivitydetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365groupsactivitydetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365groupsactivitydetailResponse> ReportrootGetoffice365groupsactivitydetailAsync(ReportrootGetoffice365groupsactivitydetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365groupsactivitydetailParameter, ReportrootGetoffice365groupsactivitydetailResponse>(parameter, cancellationToken);
        }
    }
}

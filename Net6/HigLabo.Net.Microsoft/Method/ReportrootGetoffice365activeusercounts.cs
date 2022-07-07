using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365activeusercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365ActiveUserCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365ActiveUserCounts: return $"/reports/getOffice365ActiveUserCounts";
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
    public partial class ReportrootGetoffice365activeusercountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activeusercountsResponse> ReportrootGetoffice365activeusercountsAsync()
        {
            var p = new ReportrootGetoffice365activeusercountsParameter();
            return await this.SendAsync<ReportrootGetoffice365activeusercountsParameter, ReportrootGetoffice365activeusercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activeusercountsResponse> ReportrootGetoffice365activeusercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365activeusercountsParameter();
            return await this.SendAsync<ReportrootGetoffice365activeusercountsParameter, ReportrootGetoffice365activeusercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activeusercountsResponse> ReportrootGetoffice365activeusercountsAsync(ReportrootGetoffice365activeusercountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365activeusercountsParameter, ReportrootGetoffice365activeusercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activeusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activeusercountsResponse> ReportrootGetoffice365activeusercountsAsync(ReportrootGetoffice365activeusercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365activeusercountsParameter, ReportrootGetoffice365activeusercountsResponse>(parameter, cancellationToken);
        }
    }
}

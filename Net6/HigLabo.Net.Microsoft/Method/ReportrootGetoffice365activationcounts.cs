using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetoffice365activationcountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365ActivationCounts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetOffice365ActivationCounts: return $"/reports/getOffice365ActivationCounts";
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
    public partial class ReportrootGetoffice365activationcountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activationcountsResponse> ReportrootGetoffice365activationcountsAsync()
        {
            var p = new ReportrootGetoffice365activationcountsParameter();
            return await this.SendAsync<ReportrootGetoffice365activationcountsParameter, ReportrootGetoffice365activationcountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activationcountsResponse> ReportrootGetoffice365activationcountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetoffice365activationcountsParameter();
            return await this.SendAsync<ReportrootGetoffice365activationcountsParameter, ReportrootGetoffice365activationcountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activationcountsResponse> ReportrootGetoffice365activationcountsAsync(ReportrootGetoffice365activationcountsParameter parameter)
        {
            return await this.SendAsync<ReportrootGetoffice365activationcountsParameter, ReportrootGetoffice365activationcountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getoffice365activationcounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetoffice365activationcountsResponse> ReportrootGetoffice365activationcountsAsync(ReportrootGetoffice365activationcountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetoffice365activationcountsParameter, ReportrootGetoffice365activationcountsResponse>(parameter, cancellationToken);
        }
    }
}

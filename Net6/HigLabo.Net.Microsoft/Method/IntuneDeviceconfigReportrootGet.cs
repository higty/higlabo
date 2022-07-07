using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigReportrootGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports: return $"/reports";
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
    public partial class IntuneDeviceconfigReportrootGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-reportroot-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigReportrootGetResponse> IntuneDeviceconfigReportrootGetAsync()
        {
            var p = new IntuneDeviceconfigReportrootGetParameter();
            return await this.SendAsync<IntuneDeviceconfigReportrootGetParameter, IntuneDeviceconfigReportrootGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-reportroot-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigReportrootGetResponse> IntuneDeviceconfigReportrootGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigReportrootGetParameter();
            return await this.SendAsync<IntuneDeviceconfigReportrootGetParameter, IntuneDeviceconfigReportrootGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-reportroot-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigReportrootGetResponse> IntuneDeviceconfigReportrootGetAsync(IntuneDeviceconfigReportrootGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigReportrootGetParameter, IntuneDeviceconfigReportrootGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-reportroot-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigReportrootGetResponse> IntuneDeviceconfigReportrootGetAsync(IntuneDeviceconfigReportrootGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigReportrootGetParameter, IntuneDeviceconfigReportrootGetResponse>(parameter, cancellationToken);
        }
    }
}

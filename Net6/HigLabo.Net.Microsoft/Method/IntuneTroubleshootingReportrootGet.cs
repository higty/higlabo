using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTroubleshootingReportrootGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneTroubleshootingReportrootGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-reportroot-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingReportrootGetResponse> IntuneTroubleshootingReportrootGetAsync()
        {
            var p = new IntuneTroubleshootingReportrootGetParameter();
            return await this.SendAsync<IntuneTroubleshootingReportrootGetParameter, IntuneTroubleshootingReportrootGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-reportroot-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingReportrootGetResponse> IntuneTroubleshootingReportrootGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTroubleshootingReportrootGetParameter();
            return await this.SendAsync<IntuneTroubleshootingReportrootGetParameter, IntuneTroubleshootingReportrootGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-reportroot-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingReportrootGetResponse> IntuneTroubleshootingReportrootGetAsync(IntuneTroubleshootingReportrootGetParameter parameter)
        {
            return await this.SendAsync<IntuneTroubleshootingReportrootGetParameter, IntuneTroubleshootingReportrootGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-troubleshooting-reportroot-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTroubleshootingReportrootGetResponse> IntuneTroubleshootingReportrootGetAsync(IntuneTroubleshootingReportrootGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTroubleshootingReportrootGetParameter, IntuneTroubleshootingReportrootGetResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationListTokenissuancepoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Applications_Id_TokenIssuancePolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_TokenIssuancePolicies: return $"/applications/{Id}/tokenIssuancePolicies";
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
        public string Id { get; set; }
    }
    public partial class ApplicationListTokenissuancepoliciesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/tokenissuancepolicy?view=graph-rest-1.0
        /// </summary>
        public partial class TokenIssuancePolicy
        {
            public string? Id { get; set; }
            public String[]? Definition { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsOrganizationDefault { get; set; }
        }

        public TokenIssuancePolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenissuancepoliciesResponse> ApplicationListTokenissuancepoliciesAsync()
        {
            var p = new ApplicationListTokenissuancepoliciesParameter();
            return await this.SendAsync<ApplicationListTokenissuancepoliciesParameter, ApplicationListTokenissuancepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenissuancepoliciesResponse> ApplicationListTokenissuancepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationListTokenissuancepoliciesParameter();
            return await this.SendAsync<ApplicationListTokenissuancepoliciesParameter, ApplicationListTokenissuancepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenissuancepoliciesResponse> ApplicationListTokenissuancepoliciesAsync(ApplicationListTokenissuancepoliciesParameter parameter)
        {
            return await this.SendAsync<ApplicationListTokenissuancepoliciesParameter, ApplicationListTokenissuancepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenissuancepoliciesResponse> ApplicationListTokenissuancepoliciesAsync(ApplicationListTokenissuancepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationListTokenissuancepoliciesParameter, ApplicationListTokenissuancepoliciesResponse>(parameter, cancellationToken);
        }
    }
}

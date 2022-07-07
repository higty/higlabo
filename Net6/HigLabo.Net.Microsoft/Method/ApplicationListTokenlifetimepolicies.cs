using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationListTokenlifetimepoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Applications_Id_TokenLifetimePolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_TokenLifetimePolicies: return $"/applications/{Id}/tokenLifetimePolicies";
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
    public partial class ApplicationListTokenlifetimepoliciesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/tokenlifetimepolicy?view=graph-rest-1.0
        /// </summary>
        public partial class TokenLifetimePolicy
        {
            public string? Id { get; set; }
            public String[]? Definition { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsOrganizationDefault { get; set; }
        }

        public TokenLifetimePolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenlifetimepoliciesResponse> ApplicationListTokenlifetimepoliciesAsync()
        {
            var p = new ApplicationListTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationListTokenlifetimepoliciesParameter, ApplicationListTokenlifetimepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenlifetimepoliciesResponse> ApplicationListTokenlifetimepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationListTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationListTokenlifetimepoliciesParameter, ApplicationListTokenlifetimepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenlifetimepoliciesResponse> ApplicationListTokenlifetimepoliciesAsync(ApplicationListTokenlifetimepoliciesParameter parameter)
        {
            return await this.SendAsync<ApplicationListTokenlifetimepoliciesParameter, ApplicationListTokenlifetimepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenlifetimepoliciesResponse> ApplicationListTokenlifetimepoliciesAsync(ApplicationListTokenlifetimepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationListTokenlifetimepoliciesParameter, ApplicationListTokenlifetimepoliciesResponse>(parameter, cancellationToken);
        }
    }
}

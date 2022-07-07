using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Applications,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications: return $"/applications";
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
    public partial class ApplicationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/application?view=graph-rest-1.0
        /// </summary>
        public partial class Application
        {
            public AddIn[]? AddIns { get; set; }
            public ApiApplication? Api { get; set; }
            public string? AppId { get; set; }
            public string? ApplicationTemplateId { get; set; }
            public AppRole[]? AppRoles { get; set; }
            public Certification? Certification { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisabledByMicrosoftStatus { get; set; }
            public string? DisplayName { get; set; }
            public string? GroupMembershipClaims { get; set; }
            public string? Id { get; set; }
            public String[]? IdentifierUris { get; set; }
            public InformationalUrl? Info { get; set; }
            public bool? IsDeviceOnlyAuthSupported { get; set; }
            public bool? IsFallbackPublicClient { get; set; }
            public KeyCredential[]? KeyCredentials { get; set; }
            public Stream? Logo { get; set; }
            public string? Notes { get; set; }
            public bool? Oauth2RequiredPostResponse { get; set; }
            public OptionalClaims? OptionalClaims { get; set; }
            public ParentalControlSettings? ParentalControlSettings { get; set; }
            public PasswordCredential[]? PasswordCredentials { get; set; }
            public PublicClientApplication? PublicClient { get; set; }
            public string? PublisherDomain { get; set; }
            public RequiredResourceAccess[]? RequiredResourceAccess { get; set; }
            public string? ServiceManagementReference { get; set; }
            public string? SignInAudience { get; set; }
            public SpaApplication? Spa { get; set; }
            public String[]? Tags { get; set; }
            public string? TokenEncryptionKeyId { get; set; }
            public VerifiedPublisher? VerifiedPublisher { get; set; }
            public WebApplication? Web { get; set; }
        }

        public Application[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListResponse> ApplicationListAsync()
        {
            var p = new ApplicationListParameter();
            return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListResponse> ApplicationListAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationListParameter();
            return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListResponse> ApplicationListAsync(ApplicationListParameter parameter)
        {
            return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListResponse> ApplicationListAsync(ApplicationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(parameter, cancellationToken);
        }
    }
}

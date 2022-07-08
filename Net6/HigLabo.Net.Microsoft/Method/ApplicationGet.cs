using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id: return $"/applications/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AddIns,
            Api,
            AppId,
            ApplicationTemplateId,
            AppRoles,
            Certification,
            CreatedDateTime,
            DeletedDateTime,
            Description,
            DisabledByMicrosoftStatus,
            DisplayName,
            GroupMembershipClaims,
            Id,
            IdentifierUris,
            Info,
            IsDeviceOnlyAuthSupported,
            IsFallbackPublicClient,
            KeyCredentials,
            Logo,
            Notes,
            Oauth2RequiredPostResponse,
            OptionalClaims,
            ParentalControlSettings,
            PasswordCredentials,
            PublicClient,
            PublisherDomain,
            RequiredResourceAccess,
            ServiceManagementReference,
            SignInAudience,
            Spa,
            Tags,
            TokenEncryptionKeyId,
            VerifiedPublisher,
            Web,
            CreatedOnBehalfOf,
            ExtensionProperties,
            Owners,
        }
        public enum ApiPath
        {
            Applications_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class ApplicationGetResponse : RestApiResponse
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
        public DirectoryObject? CreatedOnBehalfOf { get; set; }
        public ExtensionProperty[]? ExtensionProperties { get; set; }
        public DirectoryObject[]? Owners { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationGetResponse> ApplicationGetAsync()
        {
            var p = new ApplicationGetParameter();
            return await this.SendAsync<ApplicationGetParameter, ApplicationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationGetResponse> ApplicationGetAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationGetParameter();
            return await this.SendAsync<ApplicationGetParameter, ApplicationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationGetResponse> ApplicationGetAsync(ApplicationGetParameter parameter)
        {
            return await this.SendAsync<ApplicationGetParameter, ApplicationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationGetResponse> ApplicationGetAsync(ApplicationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationGetParameter, ApplicationGetResponse>(parameter, cancellationToken);
        }
    }
}

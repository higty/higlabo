using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-post-applications?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationPostApplicationsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications: return $"/applications";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
        public RequestSignatureVerification? RequestSignatureVerification { get; set; }
        public RequiredResourceAccess[]? RequiredResourceAccess { get; set; }
        public string? SamlMetadataUrl { get; set; }
        public string? ServiceManagementReference { get; set; }
        public string? SignInAudience { get; set; }
        public SpaApplication? Spa { get; set; }
        public String[]? Tags { get; set; }
        public string? TokenEncryptionKeyId { get; set; }
        public VerifiedPublisher? VerifiedPublisher { get; set; }
        public WebApplication? Web { get; set; }
        public AppManagementPolicy[]? AppManagementPolicies { get; set; }
        public DirectoryObject? CreatedOnBehalfOf { get; set; }
        public ExtensionProperty[]? ExtensionProperties { get; set; }
        public FederatedIdentityCredential[]? FederatedIdentityCredentials { get; set; }
        public DirectoryObject[]? Owners { get; set; }
    }
    public partial class ApplicationPostApplicationsResponse : RestApiResponse
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
        public RequestSignatureVerification? RequestSignatureVerification { get; set; }
        public RequiredResourceAccess[]? RequiredResourceAccess { get; set; }
        public string? SamlMetadataUrl { get; set; }
        public string? ServiceManagementReference { get; set; }
        public string? SignInAudience { get; set; }
        public SpaApplication? Spa { get; set; }
        public String[]? Tags { get; set; }
        public string? TokenEncryptionKeyId { get; set; }
        public VerifiedPublisher? VerifiedPublisher { get; set; }
        public WebApplication? Web { get; set; }
        public AppManagementPolicy[]? AppManagementPolicies { get; set; }
        public DirectoryObject? CreatedOnBehalfOf { get; set; }
        public ExtensionProperty[]? ExtensionProperties { get; set; }
        public FederatedIdentityCredential[]? FederatedIdentityCredentials { get; set; }
        public DirectoryObject[]? Owners { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-post-applications?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-applications?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostApplicationsResponse> ApplicationPostApplicationsAsync()
        {
            var p = new ApplicationPostApplicationsParameter();
            return await this.SendAsync<ApplicationPostApplicationsParameter, ApplicationPostApplicationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-applications?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostApplicationsResponse> ApplicationPostApplicationsAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostApplicationsParameter();
            return await this.SendAsync<ApplicationPostApplicationsParameter, ApplicationPostApplicationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-applications?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostApplicationsResponse> ApplicationPostApplicationsAsync(ApplicationPostApplicationsParameter parameter)
        {
            return await this.SendAsync<ApplicationPostApplicationsParameter, ApplicationPostApplicationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-applications?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostApplicationsResponse> ApplicationPostApplicationsAsync(ApplicationPostApplicationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostApplicationsParameter, ApplicationPostApplicationsResponse>(parameter, cancellationToken);
        }
    }
}

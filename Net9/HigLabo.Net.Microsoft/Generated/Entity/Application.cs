using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/application?view=graph-rest-1.0
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

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
    /// </summary>
    public partial class OrganizationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization: return $"/organization";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AssignedPlans,
            BusinessPhones,
            City,
            Country,
            CountryLetterCode,
            CreatedDateTime,
            DefaultUsageLocation,
            DeletedDateTime,
            DisplayName,
            Id,
            IsMultipleDataLocationsForServicesEnabled,
            MarketingNotificationEmails,
            OnPremisesLastSyncDateTime,
            OnPremisesSyncEnabled,
            PartnerTenantType,
            PostalCode,
            PreferredLanguage,
            PrivacyProfile,
            ProvisionedPlans,
            SecurityComplianceNotificationMails,
            SecurityComplianceNotificationPhones,
            State,
            Street,
            TechnicalNotificationMails,
            TenantType,
            VerifiedDomains,
            CertificateBasedAuthConfiguration,
            Extensions,
            Branding,
        }
        public enum ApiPath
        {
            Organization,
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
    public partial class OrganizationGetResponse : RestApiResponse
    {
        public enum OrganizationPartnerTenantType
        {
            MicrosoftSupport,
            SyndicatePartner,
            BreadthPartner,
            BreadthPartnerDelegatedAdmin,
            ResellerPartnerDelegatedAdmin,
            ValueAddedResellerPartnerDelegatedAdmin,
            UnknownFutureValue,
        }

        public Organization[]? Value { get; set; }
        public AssignedPlan[]? AssignedPlans { get; set; }
        public String[]? BusinessPhones { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? CountryLetterCode { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DefaultUsageLocation { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsMultipleDataLocationsForServicesEnabled { get; set; }
        public String[]? MarketingNotificationEmails { get; set; }
        public DateTimeOffset? OnPremisesLastSyncDateTime { get; set; }
        public bool? OnPremisesSyncEnabled { get; set; }
        public OrganizationPartnerTenantType PartnerTenantType { get; set; }
        public string? PostalCode { get; set; }
        public string? PreferredLanguage { get; set; }
        public PrivacyProfile? PrivacyProfile { get; set; }
        public ProvisionedPlan[]? ProvisionedPlans { get; set; }
        public String[]? SecurityComplianceNotificationMails { get; set; }
        public String[]? SecurityComplianceNotificationPhones { get; set; }
        public string? State { get; set; }
        public string? Street { get; set; }
        public String[]? TechnicalNotificationMails { get; set; }
        public string? TenantType { get; set; }
        public VerifiedDomain[]? VerifiedDomains { get; set; }
        public CertificateBasedAuthConfiguration[]? CertificateBasedAuthConfiguration { get; set; }
        public Extension[]? Extensions { get; set; }
        public OrganizationalBranding[]? Branding { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationGetResponse> OrganizationGetAsync()
        {
            var p = new OrganizationGetParameter();
            return await this.SendAsync<OrganizationGetParameter, OrganizationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationGetResponse> OrganizationGetAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationGetParameter();
            return await this.SendAsync<OrganizationGetParameter, OrganizationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationGetResponse> OrganizationGetAsync(OrganizationGetParameter parameter)
        {
            return await this.SendAsync<OrganizationGetParameter, OrganizationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationGetResponse> OrganizationGetAsync(OrganizationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationGetParameter, OrganizationGetResponse>(parameter, cancellationToken);
        }
    }
}

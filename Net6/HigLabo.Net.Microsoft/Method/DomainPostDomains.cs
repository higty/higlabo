using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-post-domains?view=graph-rest-1.0
    /// </summary>
    public partial class DomainPostDomainsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains: return $"/domains";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Domains,
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
        public string? AuthenticationType { get; set; }
        public string? AvailabilityStatus { get; set; }
        public string? Id { get; set; }
        public bool? IsAdminManaged { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsInitial { get; set; }
        public bool? IsRoot { get; set; }
        public bool? IsVerified { get; set; }
        public Int32? PasswordNotificationWindowInDays { get; set; }
        public Int32? PasswordValidityPeriodInDays { get; set; }
        public DomainState? State { get; set; }
        public String[]? SupportedServices { get; set; }
        public DirectoryObject[]? DomainNameReferences { get; set; }
        public DomainDnsRecord[]? ServiceConfigurationRecords { get; set; }
        public DomainDnsRecord[]? VerificationDnsRecords { get; set; }
        public InternalDomainFederation? FederationConfiguration { get; set; }
    }
    public partial class DomainPostDomainsResponse : RestApiResponse
    {
        public string? AuthenticationType { get; set; }
        public string? AvailabilityStatus { get; set; }
        public string? Id { get; set; }
        public bool? IsAdminManaged { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsInitial { get; set; }
        public bool? IsRoot { get; set; }
        public bool? IsVerified { get; set; }
        public Int32? PasswordNotificationWindowInDays { get; set; }
        public Int32? PasswordValidityPeriodInDays { get; set; }
        public DomainState? State { get; set; }
        public String[]? SupportedServices { get; set; }
        public DirectoryObject[]? DomainNameReferences { get; set; }
        public DomainDnsRecord[]? ServiceConfigurationRecords { get; set; }
        public DomainDnsRecord[]? VerificationDnsRecords { get; set; }
        public InternalDomainFederation? FederationConfiguration { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-post-domains?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-post-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostDomainsResponse> DomainPostDomainsAsync()
        {
            var p = new DomainPostDomainsParameter();
            return await this.SendAsync<DomainPostDomainsParameter, DomainPostDomainsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-post-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostDomainsResponse> DomainPostDomainsAsync(CancellationToken cancellationToken)
        {
            var p = new DomainPostDomainsParameter();
            return await this.SendAsync<DomainPostDomainsParameter, DomainPostDomainsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-post-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostDomainsResponse> DomainPostDomainsAsync(DomainPostDomainsParameter parameter)
        {
            return await this.SendAsync<DomainPostDomainsParameter, DomainPostDomainsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-post-domains?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainPostDomainsResponse> DomainPostDomainsAsync(DomainPostDomainsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainPostDomainsParameter, DomainPostDomainsResponse>(parameter, cancellationToken);
        }
    }
}

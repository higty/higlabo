using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainVerifyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains_Id_Verify: return $"/domains/{Id}/verify";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Domains_Id_Verify,
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
        public String[]? SupportedServices { get; set; }
        public DomainState? State { get; set; }
        public DirectoryObject[]? DomainNameReferences { get; set; }
        public DomainDnsRecord[]? ServiceConfigurationRecords { get; set; }
        public DomainDnsRecord[]? VerificationDnsRecords { get; set; }
        public InternalDomainFederation? FederationConfiguration { get; set; }
    }
    public partial class DomainVerifyResponse : RestApiResponse
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
        public String[]? SupportedServices { get; set; }
        public DomainState? State { get; set; }
        public DirectoryObject[]? DomainNameReferences { get; set; }
        public DomainDnsRecord[]? ServiceConfigurationRecords { get; set; }
        public DomainDnsRecord[]? VerificationDnsRecords { get; set; }
        public InternalDomainFederation? FederationConfiguration { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-verify?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainVerifyResponse> DomainVerifyAsync()
        {
            var p = new DomainVerifyParameter();
            return await this.SendAsync<DomainVerifyParameter, DomainVerifyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-verify?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainVerifyResponse> DomainVerifyAsync(CancellationToken cancellationToken)
        {
            var p = new DomainVerifyParameter();
            return await this.SendAsync<DomainVerifyParameter, DomainVerifyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-verify?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainVerifyResponse> DomainVerifyAsync(DomainVerifyParameter parameter)
        {
            return await this.SendAsync<DomainVerifyParameter, DomainVerifyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-verify?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainVerifyResponse> DomainVerifyAsync(DomainVerifyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainVerifyParameter, DomainVerifyResponse>(parameter, cancellationToken);
        }
    }
}

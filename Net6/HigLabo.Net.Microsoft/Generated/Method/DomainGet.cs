using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
    /// </summary>
    public partial class DomainGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains_Id: return $"/domains/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AuthenticationType,
            AvailabilityStatus,
            Id,
            IsAdminManaged,
            IsDefault,
            IsInitial,
            IsRoot,
            IsVerified,
            PasswordNotificationWindowInDays,
            PasswordValidityPeriodInDays,
            State,
            SupportedServices,
            DomainNameReferences,
            ServiceConfigurationRecords,
            VerificationDnsRecords,
            FederationConfiguration,
        }
        public enum ApiPath
        {
            Domains_Id,
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
    public partial class DomainGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainGetResponse> DomainGetAsync()
        {
            var p = new DomainGetParameter();
            return await this.SendAsync<DomainGetParameter, DomainGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainGetResponse> DomainGetAsync(CancellationToken cancellationToken)
        {
            var p = new DomainGetParameter();
            return await this.SendAsync<DomainGetParameter, DomainGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainGetResponse> DomainGetAsync(DomainGetParameter parameter)
        {
            return await this.SendAsync<DomainGetParameter, DomainGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainGetResponse> DomainGetAsync(DomainGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainGetParameter, DomainGetResponse>(parameter, cancellationToken);
        }
    }
}

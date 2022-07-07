using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainGetParameter : IRestApiParameter, IQueryParameterProperty
    {
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
            SupportedServices,
            State,
        }
        public enum ApiPath
        {
            Domains_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Domains_Id: return $"/domains/{Id}";
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
        public String[]? SupportedServices { get; set; }
        public DomainState? State { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainGetResponse> DomainGetAsync()
        {
            var p = new DomainGetParameter();
            return await this.SendAsync<DomainGetParameter, DomainGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainGetResponse> DomainGetAsync(CancellationToken cancellationToken)
        {
            var p = new DomainGetParameter();
            return await this.SendAsync<DomainGetParameter, DomainGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainGetResponse> DomainGetAsync(DomainGetParameter parameter)
        {
            return await this.SendAsync<DomainGetParameter, DomainGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainGetResponse> DomainGetAsync(DomainGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainGetParameter, DomainGetResponse>(parameter, cancellationToken);
        }
    }
}

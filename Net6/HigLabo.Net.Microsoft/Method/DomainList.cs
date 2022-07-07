using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Domains,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Domains: return $"/domains";
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
    public partial class DomainListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/domain?view=graph-rest-1.0
        /// </summary>
        public partial class Domain
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

        public Domain[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListResponse> DomainListAsync()
        {
            var p = new DomainListParameter();
            return await this.SendAsync<DomainListParameter, DomainListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListResponse> DomainListAsync(CancellationToken cancellationToken)
        {
            var p = new DomainListParameter();
            return await this.SendAsync<DomainListParameter, DomainListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListResponse> DomainListAsync(DomainListParameter parameter)
        {
            return await this.SendAsync<DomainListParameter, DomainListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListResponse> DomainListAsync(DomainListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainListParameter, DomainListResponse>(parameter, cancellationToken);
        }
    }
}

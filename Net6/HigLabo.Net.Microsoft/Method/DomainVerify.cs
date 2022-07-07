using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainVerifyParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Domains_Id_Verify,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Domains_Id_Verify: return $"/domains/{Id}/verify";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
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

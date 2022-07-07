using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalAddkeyParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_AddKey,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_AddKey: return $"/servicePrincipals/{Id}/addKey";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public KeyCredential? KeyCredential { get; set; }
        public PasswordCredential? PasswordCredential { get; set; }
        public string? Proof { get; set; }
        public string Id { get; set; }
    }
    public partial class ServiceprincipalAddkeyResponse : RestApiResponse
    {
        public string? CustomKeyIdentifier { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Key { get; set; }
        public Guid? KeyId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Type { get; set; }
        public string? Usage { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddkeyResponse> ServiceprincipalAddkeyAsync()
        {
            var p = new ServiceprincipalAddkeyParameter();
            return await this.SendAsync<ServiceprincipalAddkeyParameter, ServiceprincipalAddkeyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddkeyResponse> ServiceprincipalAddkeyAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalAddkeyParameter();
            return await this.SendAsync<ServiceprincipalAddkeyParameter, ServiceprincipalAddkeyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddkeyResponse> ServiceprincipalAddkeyAsync(ServiceprincipalAddkeyParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalAddkeyParameter, ServiceprincipalAddkeyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddkeyResponse> ServiceprincipalAddkeyAsync(ServiceprincipalAddkeyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalAddkeyParameter, ServiceprincipalAddkeyResponse>(parameter, cancellationToken);
        }
    }
}

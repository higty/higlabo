using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalAddtokensigningcertificateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            ServicePrincipals_Id_AddTokenSigningCertificate,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_AddTokenSigningCertificate: return $"/servicePrincipals/{Id}/addTokenSigningCertificate";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string Id { get; set; }
    }
    public partial class ServiceprincipalAddtokensigningcertificateResponse : RestApiResponse
    {
        public string? CustomKeyIdentifier { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public Guid? KeyId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Type { get; set; }
        public string? Usage { get; set; }
        public string? Key { get; set; }
        public string? Thumbprint { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddtokensigningcertificateResponse> ServiceprincipalAddtokensigningcertificateAsync()
        {
            var p = new ServiceprincipalAddtokensigningcertificateParameter();
            return await this.SendAsync<ServiceprincipalAddtokensigningcertificateParameter, ServiceprincipalAddtokensigningcertificateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddtokensigningcertificateResponse> ServiceprincipalAddtokensigningcertificateAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalAddtokensigningcertificateParameter();
            return await this.SendAsync<ServiceprincipalAddtokensigningcertificateParameter, ServiceprincipalAddtokensigningcertificateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddtokensigningcertificateResponse> ServiceprincipalAddtokensigningcertificateAsync(ServiceprincipalAddtokensigningcertificateParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalAddtokensigningcertificateParameter, ServiceprincipalAddtokensigningcertificateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalAddtokensigningcertificateResponse> ServiceprincipalAddtokensigningcertificateAsync(ServiceprincipalAddtokensigningcertificateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalAddtokensigningcertificateParameter, ServiceprincipalAddtokensigningcertificateResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalAddTokensigningcertificateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_AddTokenSigningCertificate: return $"/servicePrincipals/{Id}/addTokenSigningCertificate";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ServicePrincipals_Id_AddTokenSigningCertificate,
            ServicePrincipals,
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
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? CustomKeyIdentifier { get; set; }
        public string? Key { get; set; }
        public Guid? KeyId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Type { get; set; }
        public string? Usage { get; set; }
        public string? Thumbprint { get; set; }
    }
    public partial class ServicePrincipalAddTokensigningcertificateResponse : RestApiResponse
    {
        public string? CustomKeyIdentifier { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Key { get; set; }
        public Guid? KeyId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Type { get; set; }
        public string? Usage { get; set; }
        public string? Thumbprint { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalAddTokensigningcertificateResponse> ServicePrincipalAddTokensigningcertificateAsync()
        {
            var p = new ServicePrincipalAddTokensigningcertificateParameter();
            return await this.SendAsync<ServicePrincipalAddTokensigningcertificateParameter, ServicePrincipalAddTokensigningcertificateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalAddTokensigningcertificateResponse> ServicePrincipalAddTokensigningcertificateAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalAddTokensigningcertificateParameter();
            return await this.SendAsync<ServicePrincipalAddTokensigningcertificateParameter, ServicePrincipalAddTokensigningcertificateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalAddTokensigningcertificateResponse> ServicePrincipalAddTokensigningcertificateAsync(ServicePrincipalAddTokensigningcertificateParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalAddTokensigningcertificateParameter, ServicePrincipalAddTokensigningcertificateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalAddTokensigningcertificateResponse> ServicePrincipalAddTokensigningcertificateAsync(ServicePrincipalAddTokensigningcertificateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalAddTokensigningcertificateParameter, ServicePrincipalAddTokensigningcertificateResponse>(parameter, cancellationToken);
        }
    }
}

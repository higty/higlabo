using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalAddTokensigningcertificateParameter : IRestApiParameter
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
    public partial class ServiceprincipalAddTokensigningcertificateResponse : RestApiResponse
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
        public async ValueTask<ServiceprincipalAddTokensigningcertificateResponse> ServiceprincipalAddTokensigningcertificateAsync()
        {
            var p = new ServiceprincipalAddTokensigningcertificateParameter();
            return await this.SendAsync<ServiceprincipalAddTokensigningcertificateParameter, ServiceprincipalAddTokensigningcertificateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalAddTokensigningcertificateResponse> ServiceprincipalAddTokensigningcertificateAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalAddTokensigningcertificateParameter();
            return await this.SendAsync<ServiceprincipalAddTokensigningcertificateParameter, ServiceprincipalAddTokensigningcertificateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalAddTokensigningcertificateResponse> ServiceprincipalAddTokensigningcertificateAsync(ServiceprincipalAddTokensigningcertificateParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalAddTokensigningcertificateParameter, ServiceprincipalAddTokensigningcertificateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-addtokensigningcertificate?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalAddTokensigningcertificateResponse> ServiceprincipalAddTokensigningcertificateAsync(ServiceprincipalAddTokensigningcertificateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalAddTokensigningcertificateParameter, ServiceprincipalAddTokensigningcertificateResponse>(parameter, cancellationToken);
        }
    }
}

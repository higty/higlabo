using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityapiConnectorUploadclientcertificateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_Apiconnectors_Id_UploadClientCertificate: return $"/identity/apiconnectors/{Id}/uploadClientCertificate";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_Apiconnectors_Id_UploadClientCertificate,
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
        public string? Pkcs12Value { get; set; }
        public string? Password { get; set; }
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? TargetUrl { get; set; }
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
    }
    public partial class IdentityapiConnectorUploadclientcertificateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? TargetUrl { get; set; }
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-uploadclientcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorUploadclientcertificateResponse> IdentityapiConnectorUploadclientcertificateAsync()
        {
            var p = new IdentityapiConnectorUploadclientcertificateParameter();
            return await this.SendAsync<IdentityapiConnectorUploadclientcertificateParameter, IdentityapiConnectorUploadclientcertificateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-uploadclientcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorUploadclientcertificateResponse> IdentityapiConnectorUploadclientcertificateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiConnectorUploadclientcertificateParameter();
            return await this.SendAsync<IdentityapiConnectorUploadclientcertificateParameter, IdentityapiConnectorUploadclientcertificateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-uploadclientcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorUploadclientcertificateResponse> IdentityapiConnectorUploadclientcertificateAsync(IdentityapiConnectorUploadclientcertificateParameter parameter)
        {
            return await this.SendAsync<IdentityapiConnectorUploadclientcertificateParameter, IdentityapiConnectorUploadclientcertificateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-uploadclientcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorUploadclientcertificateResponse> IdentityapiConnectorUploadclientcertificateAsync(IdentityapiConnectorUploadclientcertificateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiConnectorUploadclientcertificateParameter, IdentityapiConnectorUploadclientcertificateResponse>(parameter, cancellationToken);
        }
    }
}

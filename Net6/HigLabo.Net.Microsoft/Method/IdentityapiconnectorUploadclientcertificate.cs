using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityapiconnectorUploadclientcertificateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_Apiconnectors_Id_UploadClientCertificate,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_Apiconnectors_Id_UploadClientCertificate: return $"/identity/apiconnectors/{Id}/uploadClientCertificate";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Pkcs12Value { get; set; }
        public string? Password { get; set; }
        public string Id { get; set; }
    }
    public partial class IdentityapiconnectorUploadclientcertificateResponse : RestApiResponse
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
        public async Task<IdentityapiconnectorUploadclientcertificateResponse> IdentityapiconnectorUploadclientcertificateAsync()
        {
            var p = new IdentityapiconnectorUploadclientcertificateParameter();
            return await this.SendAsync<IdentityapiconnectorUploadclientcertificateParameter, IdentityapiconnectorUploadclientcertificateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-uploadclientcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorUploadclientcertificateResponse> IdentityapiconnectorUploadclientcertificateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiconnectorUploadclientcertificateParameter();
            return await this.SendAsync<IdentityapiconnectorUploadclientcertificateParameter, IdentityapiconnectorUploadclientcertificateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-uploadclientcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorUploadclientcertificateResponse> IdentityapiconnectorUploadclientcertificateAsync(IdentityapiconnectorUploadclientcertificateParameter parameter)
        {
            return await this.SendAsync<IdentityapiconnectorUploadclientcertificateParameter, IdentityapiconnectorUploadclientcertificateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-uploadclientcertificate?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorUploadclientcertificateResponse> IdentityapiconnectorUploadclientcertificateAsync(IdentityapiconnectorUploadclientcertificateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiconnectorUploadclientcertificateParameter, IdentityapiconnectorUploadclientcertificateResponse>(parameter, cancellationToken);
        }
    }
}

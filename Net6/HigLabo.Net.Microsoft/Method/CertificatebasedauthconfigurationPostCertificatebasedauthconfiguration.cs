using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Organization_Id_CertificateBasedAuthConfiguration,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Organization_Id_CertificateBasedAuthConfiguration: return $"/organization/{Id}/certificateBasedAuthConfiguration";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public CertificateAuthority[]? CertificateAuthorities { get; set; }
        public string Id { get; set; }
    }
    public partial class CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationResponse : RestApiResponse
    {
        public CertificateAuthority[]? CertificateAuthorities { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-post-certificatebasedauthconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationResponse> CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationAsync()
        {
            var p = new CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationParameter();
            return await this.SendAsync<CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationParameter, CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-post-certificatebasedauthconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationResponse> CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationAsync(CancellationToken cancellationToken)
        {
            var p = new CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationParameter();
            return await this.SendAsync<CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationParameter, CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-post-certificatebasedauthconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationResponse> CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationAsync(CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationParameter parameter)
        {
            return await this.SendAsync<CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationParameter, CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-post-certificatebasedauthconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationResponse> CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationAsync(CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationParameter, CertificatebasedauthconfigurationPostCertificatebasedauthconfigurationResponse>(parameter, cancellationToken);
        }
    }
}

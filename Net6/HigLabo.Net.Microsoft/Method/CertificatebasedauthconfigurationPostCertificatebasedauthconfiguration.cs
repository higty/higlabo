using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization_Id_CertificateBasedAuthConfiguration: return $"/organization/{Id}/certificateBasedAuthConfiguration";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Organization_Id_CertificateBasedAuthConfiguration,
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
        public CertificateAuthority[]? CertificateAuthorities { get; set; }
        public string? Id { get; set; }
    }
    public partial class CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationResponse : RestApiResponse
    {
        public CertificateAuthority[]? CertificateAuthorities { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-post-certificatebasedauthconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationResponse> CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationAsync()
        {
            var p = new CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationParameter();
            return await this.SendAsync<CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationParameter, CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-post-certificatebasedauthconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationResponse> CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationAsync(CancellationToken cancellationToken)
        {
            var p = new CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationParameter();
            return await this.SendAsync<CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationParameter, CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-post-certificatebasedauthconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationResponse> CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationAsync(CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationParameter parameter)
        {
            return await this.SendAsync<CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationParameter, CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-post-certificatebasedauthconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationResponse> CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationAsync(CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationParameter, CertificatebasedauthConfigurationPostCertificatebasedauthConfigurationResponse>(parameter, cancellationToken);
        }
    }
}

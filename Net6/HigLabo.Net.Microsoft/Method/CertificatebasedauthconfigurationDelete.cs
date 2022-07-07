using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CertificatebasedauthconfigurationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Organization_Id_CertificateBasedAuthConfiguration_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Organization_Id_CertificateBasedAuthConfiguration_Id: return $"/organization/{OrganizationId}/certificateBasedAuthConfiguration/{CertificateBasedAuthConfigurationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string OrganizationId { get; set; }
        public string CertificateBasedAuthConfigurationId { get; set; }
    }
    public partial class CertificatebasedauthconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationDeleteResponse> CertificatebasedauthconfigurationDeleteAsync()
        {
            var p = new CertificatebasedauthconfigurationDeleteParameter();
            return await this.SendAsync<CertificatebasedauthconfigurationDeleteParameter, CertificatebasedauthconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationDeleteResponse> CertificatebasedauthconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new CertificatebasedauthconfigurationDeleteParameter();
            return await this.SendAsync<CertificatebasedauthconfigurationDeleteParameter, CertificatebasedauthconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationDeleteResponse> CertificatebasedauthconfigurationDeleteAsync(CertificatebasedauthconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<CertificatebasedauthconfigurationDeleteParameter, CertificatebasedauthconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationDeleteResponse> CertificatebasedauthconfigurationDeleteAsync(CertificatebasedauthconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CertificatebasedauthconfigurationDeleteParameter, CertificatebasedauthconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}

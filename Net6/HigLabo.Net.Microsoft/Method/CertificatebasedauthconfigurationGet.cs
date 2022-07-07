using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CertificatebasedauthconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string OrganizationId { get; set; }
        public string CertificateBasedAuthConfigurationId { get; set; }
    }
    public partial class CertificatebasedauthconfigurationGetResponse : RestApiResponse
    {
        public CertificateAuthority[]? CertificateAuthorities { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationGetResponse> CertificatebasedauthconfigurationGetAsync()
        {
            var p = new CertificatebasedauthconfigurationGetParameter();
            return await this.SendAsync<CertificatebasedauthconfigurationGetParameter, CertificatebasedauthconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationGetResponse> CertificatebasedauthconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new CertificatebasedauthconfigurationGetParameter();
            return await this.SendAsync<CertificatebasedauthconfigurationGetParameter, CertificatebasedauthconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationGetResponse> CertificatebasedauthconfigurationGetAsync(CertificatebasedauthconfigurationGetParameter parameter)
        {
            return await this.SendAsync<CertificatebasedauthconfigurationGetParameter, CertificatebasedauthconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationGetResponse> CertificatebasedauthconfigurationGetAsync(CertificatebasedauthconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CertificatebasedauthconfigurationGetParameter, CertificatebasedauthconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}

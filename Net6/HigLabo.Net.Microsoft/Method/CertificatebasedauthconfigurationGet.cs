using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CertificatebasedauthConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string OrganizationId { get; set; }
            public string CertificateBasedAuthConfigurationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization_Id_CertificateBasedAuthConfiguration_Id: return $"/organization/{OrganizationId}/certificateBasedAuthConfiguration/{CertificateBasedAuthConfigurationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Organization_Id_CertificateBasedAuthConfiguration_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class CertificatebasedauthConfigurationGetResponse : RestApiResponse
    {
        public CertificateAuthority[]? CertificateAuthorities { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationGetResponse> CertificatebasedauthConfigurationGetAsync()
        {
            var p = new CertificatebasedauthConfigurationGetParameter();
            return await this.SendAsync<CertificatebasedauthConfigurationGetParameter, CertificatebasedauthConfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationGetResponse> CertificatebasedauthConfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new CertificatebasedauthConfigurationGetParameter();
            return await this.SendAsync<CertificatebasedauthConfigurationGetParameter, CertificatebasedauthConfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationGetResponse> CertificatebasedauthConfigurationGetAsync(CertificatebasedauthConfigurationGetParameter parameter)
        {
            return await this.SendAsync<CertificatebasedauthConfigurationGetParameter, CertificatebasedauthConfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationGetResponse> CertificatebasedauthConfigurationGetAsync(CertificatebasedauthConfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CertificatebasedauthConfigurationGetParameter, CertificatebasedauthConfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}

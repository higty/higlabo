using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CertificatebasedauthconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string Id { get; set; }
    }
    public partial class CertificatebasedauthconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/certificatebasedauthconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class CertificateBasedAuthConfiguration
        {
            public CertificateAuthority[]? CertificateAuthorities { get; set; }
            public string? Id { get; set; }
        }

        public CertificateBasedAuthConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationListResponse> CertificatebasedauthconfigurationListAsync()
        {
            var p = new CertificatebasedauthconfigurationListParameter();
            return await this.SendAsync<CertificatebasedauthconfigurationListParameter, CertificatebasedauthconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationListResponse> CertificatebasedauthconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new CertificatebasedauthconfigurationListParameter();
            return await this.SendAsync<CertificatebasedauthconfigurationListParameter, CertificatebasedauthconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationListResponse> CertificatebasedauthconfigurationListAsync(CertificatebasedauthconfigurationListParameter parameter)
        {
            return await this.SendAsync<CertificatebasedauthconfigurationListParameter, CertificatebasedauthconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthconfigurationListResponse> CertificatebasedauthconfigurationListAsync(CertificatebasedauthconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CertificatebasedauthconfigurationListParameter, CertificatebasedauthconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}

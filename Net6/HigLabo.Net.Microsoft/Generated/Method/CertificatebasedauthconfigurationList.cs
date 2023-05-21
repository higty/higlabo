using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
    /// </summary>
    public partial class CertificatebasedauthConfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization_Id_CertificateBasedAuthConfiguration: return $"/organization/{Id}/certificateBasedAuthConfiguration";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CertificateAuthorities,
            Id,
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
    public partial class CertificatebasedauthConfigurationListResponse : RestApiResponse
    {
        public CertificateBasedAuthConfiguration[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationListResponse> CertificatebasedauthConfigurationListAsync()
        {
            var p = new CertificatebasedauthConfigurationListParameter();
            return await this.SendAsync<CertificatebasedauthConfigurationListParameter, CertificatebasedauthConfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationListResponse> CertificatebasedauthConfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new CertificatebasedauthConfigurationListParameter();
            return await this.SendAsync<CertificatebasedauthConfigurationListParameter, CertificatebasedauthConfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationListResponse> CertificatebasedauthConfigurationListAsync(CertificatebasedauthConfigurationListParameter parameter)
        {
            return await this.SendAsync<CertificatebasedauthConfigurationListParameter, CertificatebasedauthConfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<CertificatebasedauthConfigurationListResponse> CertificatebasedauthConfigurationListAsync(CertificatebasedauthConfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CertificatebasedauthConfigurationListParameter, CertificatebasedauthConfigurationListResponse>(parameter, cancellationToken);
        }
    }
}

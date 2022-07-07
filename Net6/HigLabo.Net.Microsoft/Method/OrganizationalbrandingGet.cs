using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrganizationalbrandingGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Organization_OrganizationId_Branding,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Organization_OrganizationId_Branding: return $"/organization/{OrganizationId}/branding";
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
    }
    public partial class OrganizationalbrandingGetResponse : RestApiResponse
    {
        public string? BackgroundColor { get; set; }
        public Stream? BackgroundImage { get; set; }
        public string? BackgroundImageRelativeUrl { get; set; }
        public Stream? BannerLogo { get; set; }
        public string? BannerLogoRelativeUrl { get; set; }
        public String[]? CdnList { get; set; }
        public string? Id { get; set; }
        public string? SignInPageText { get; set; }
        public Stream? SquareLogo { get; set; }
        public string? SquareLogoRelativeUrl { get; set; }
        public string? UsernameHintText { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingGetResponse> OrganizationalbrandingGetAsync()
        {
            var p = new OrganizationalbrandingGetParameter();
            return await this.SendAsync<OrganizationalbrandingGetParameter, OrganizationalbrandingGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingGetResponse> OrganizationalbrandingGetAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalbrandingGetParameter();
            return await this.SendAsync<OrganizationalbrandingGetParameter, OrganizationalbrandingGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingGetResponse> OrganizationalbrandingGetAsync(OrganizationalbrandingGetParameter parameter)
        {
            return await this.SendAsync<OrganizationalbrandingGetParameter, OrganizationalbrandingGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingGetResponse> OrganizationalbrandingGetAsync(OrganizationalbrandingGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalbrandingGetParameter, OrganizationalbrandingGetResponse>(parameter, cancellationToken);
        }
    }
}

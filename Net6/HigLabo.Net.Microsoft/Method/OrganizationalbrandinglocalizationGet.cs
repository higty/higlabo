using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrganizationalbrandinglocalizationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId: return $"/organization/{OrganizationId}/branding/localizations/{OrganizationalBrandingLocalizationId}";
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
        public string OrganizationalBrandingLocalizationId { get; set; }
    }
    public partial class OrganizationalbrandinglocalizationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationGetResponse> OrganizationalbrandinglocalizationGetAsync()
        {
            var p = new OrganizationalbrandinglocalizationGetParameter();
            return await this.SendAsync<OrganizationalbrandinglocalizationGetParameter, OrganizationalbrandinglocalizationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationGetResponse> OrganizationalbrandinglocalizationGetAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalbrandinglocalizationGetParameter();
            return await this.SendAsync<OrganizationalbrandinglocalizationGetParameter, OrganizationalbrandinglocalizationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationGetResponse> OrganizationalbrandinglocalizationGetAsync(OrganizationalbrandinglocalizationGetParameter parameter)
        {
            return await this.SendAsync<OrganizationalbrandinglocalizationGetParameter, OrganizationalbrandinglocalizationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationGetResponse> OrganizationalbrandinglocalizationGetAsync(OrganizationalbrandinglocalizationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalbrandinglocalizationGetParameter, OrganizationalbrandinglocalizationGetResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrganizationalbrandingPostLocalizationsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Organization_OrganizationId_Branding_Localizations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Organization_OrganizationId_Branding_Localizations: return $"/organization/{OrganizationId}/branding/localizations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string OrganizationId { get; set; }
    }
    public partial class OrganizationalbrandingPostLocalizationsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingPostLocalizationsResponse> OrganizationalbrandingPostLocalizationsAsync()
        {
            var p = new OrganizationalbrandingPostLocalizationsParameter();
            return await this.SendAsync<OrganizationalbrandingPostLocalizationsParameter, OrganizationalbrandingPostLocalizationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingPostLocalizationsResponse> OrganizationalbrandingPostLocalizationsAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalbrandingPostLocalizationsParameter();
            return await this.SendAsync<OrganizationalbrandingPostLocalizationsParameter, OrganizationalbrandingPostLocalizationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingPostLocalizationsResponse> OrganizationalbrandingPostLocalizationsAsync(OrganizationalbrandingPostLocalizationsParameter parameter)
        {
            return await this.SendAsync<OrganizationalbrandingPostLocalizationsParameter, OrganizationalbrandingPostLocalizationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingPostLocalizationsResponse> OrganizationalbrandingPostLocalizationsAsync(OrganizationalbrandingPostLocalizationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalbrandingPostLocalizationsParameter, OrganizationalbrandingPostLocalizationsResponse>(parameter, cancellationToken);
        }
    }
}

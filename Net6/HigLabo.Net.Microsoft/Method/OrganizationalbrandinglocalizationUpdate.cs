using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrganizationalbrandinglocalizationUpdateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId_BackgroundImageOrBannerLogoOrSquareLogo,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId_BackgroundImageOrBannerLogoOrSquareLogo: return $"/organization/{OrganizationId}/branding/localizations/{OrganizationalBrandingLocalizationId}/{BackgroundImageOrBannerLogoOrSquareLogo}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string? BackgroundColor { get; set; }
        public Stream? BackgroundImage { get; set; }
        public Stream? BannerLogo { get; set; }
        public string? SignInPageText { get; set; }
        public Stream? SquareLogo { get; set; }
        public string? UsernameHintText { get; set; }
        public string OrganizationId { get; set; }
        public string OrganizationalBrandingLocalizationId { get; set; }
        public string BackgroundImageOrBannerLogoOrSquareLogo { get; set; }
    }
    public partial class OrganizationalbrandinglocalizationUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationUpdateResponse> OrganizationalbrandinglocalizationUpdateAsync()
        {
            var p = new OrganizationalbrandinglocalizationUpdateParameter();
            return await this.SendAsync<OrganizationalbrandinglocalizationUpdateParameter, OrganizationalbrandinglocalizationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationUpdateResponse> OrganizationalbrandinglocalizationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalbrandinglocalizationUpdateParameter();
            return await this.SendAsync<OrganizationalbrandinglocalizationUpdateParameter, OrganizationalbrandinglocalizationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationUpdateResponse> OrganizationalbrandinglocalizationUpdateAsync(OrganizationalbrandinglocalizationUpdateParameter parameter)
        {
            return await this.SendAsync<OrganizationalbrandinglocalizationUpdateParameter, OrganizationalbrandinglocalizationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationUpdateResponse> OrganizationalbrandinglocalizationUpdateAsync(OrganizationalbrandinglocalizationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalbrandinglocalizationUpdateParameter, OrganizationalbrandinglocalizationUpdateResponse>(parameter, cancellationToken);
        }
    }
}

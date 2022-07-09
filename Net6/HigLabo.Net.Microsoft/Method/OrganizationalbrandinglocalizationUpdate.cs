using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrganizationalBrandinglocalizationUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? OrganizationId { get; set; }
            public string? OrganizationalBrandingLocalizationId { get; set; }
            public string? BackgroundImageOrBannerLogoOrSquareLogo { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId: return $"/organization/{OrganizationId}/branding/localizations/{OrganizationalBrandingLocalizationId}";
                    case ApiPath.Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId_BackgroundImageOrBannerLogoOrSquareLogo: return $"/organization/{OrganizationId}/branding/localizations/{OrganizationalBrandingLocalizationId}/{BackgroundImageOrBannerLogoOrSquareLogo}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId,
            Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId_BackgroundImageOrBannerLogoOrSquareLogo,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? BackgroundColor { get; set; }
        public Stream? BackgroundImage { get; set; }
        public Stream? BannerLogo { get; set; }
        public string? SignInPageText { get; set; }
        public Stream? SquareLogo { get; set; }
        public string? UsernameHintText { get; set; }
    }
    public partial class OrganizationalBrandinglocalizationUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandinglocalizationUpdateResponse> OrganizationalBrandinglocalizationUpdateAsync()
        {
            var p = new OrganizationalBrandinglocalizationUpdateParameter();
            return await this.SendAsync<OrganizationalBrandinglocalizationUpdateParameter, OrganizationalBrandinglocalizationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandinglocalizationUpdateResponse> OrganizationalBrandinglocalizationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalBrandinglocalizationUpdateParameter();
            return await this.SendAsync<OrganizationalBrandinglocalizationUpdateParameter, OrganizationalBrandinglocalizationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandinglocalizationUpdateResponse> OrganizationalBrandinglocalizationUpdateAsync(OrganizationalBrandinglocalizationUpdateParameter parameter)
        {
            return await this.SendAsync<OrganizationalBrandinglocalizationUpdateParameter, OrganizationalBrandinglocalizationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandinglocalizationUpdateResponse> OrganizationalBrandinglocalizationUpdateAsync(OrganizationalBrandinglocalizationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalBrandinglocalizationUpdateParameter, OrganizationalBrandinglocalizationUpdateResponse>(parameter, cancellationToken);
        }
    }
}

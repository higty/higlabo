using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
    /// </summary>
    public partial class OrganizationalBrandingPostLocalizationsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? OrganizationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization_OrganizationId_Branding_Localizations: return $"/organization/{OrganizationId}/branding/localizations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Organization_OrganizationId_Branding_Localizations,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? BackgroundColor { get; set; }
        public Stream? BackgroundImage { get; set; }
        public string? BackgroundImageRelativeUrl { get; set; }
        public Stream? BannerLogo { get; set; }
        public string? BannerLogoRelativeUrl { get; set; }
        public String[]? CdnList { get; set; }
        public string? SignInPageText { get; set; }
        public Stream? SquareLogo { get; set; }
        public string? SquareLogoRelativeUrl { get; set; }
        public string? UsernameHintText { get; set; }
    }
    public partial class OrganizationalBrandingPostLocalizationsResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingPostLocalizationsResponse> OrganizationalBrandingPostLocalizationsAsync()
        {
            var p = new OrganizationalBrandingPostLocalizationsParameter();
            return await this.SendAsync<OrganizationalBrandingPostLocalizationsParameter, OrganizationalBrandingPostLocalizationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingPostLocalizationsResponse> OrganizationalBrandingPostLocalizationsAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalBrandingPostLocalizationsParameter();
            return await this.SendAsync<OrganizationalBrandingPostLocalizationsParameter, OrganizationalBrandingPostLocalizationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingPostLocalizationsResponse> OrganizationalBrandingPostLocalizationsAsync(OrganizationalBrandingPostLocalizationsParameter parameter)
        {
            return await this.SendAsync<OrganizationalBrandingPostLocalizationsParameter, OrganizationalBrandingPostLocalizationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-post-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingPostLocalizationsResponse> OrganizationalBrandingPostLocalizationsAsync(OrganizationalBrandingPostLocalizationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalBrandingPostLocalizationsParameter, OrganizationalBrandingPostLocalizationsResponse>(parameter, cancellationToken);
        }
    }
}

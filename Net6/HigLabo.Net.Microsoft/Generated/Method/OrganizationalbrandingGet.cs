using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
    /// </summary>
    public partial class OrganizationalBrandingGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? OrganizationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization_OrganizationId_Branding: return $"/organization/{OrganizationId}/branding";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            BackgroundColor,
            BackgroundImage,
            BackgroundImageRelativeUrl,
            BannerLogo,
            BannerLogoRelativeUrl,
            CdnList,
            Id,
            SignInPageText,
            SquareLogo,
            SquareLogoRelativeUrl,
            UsernameHintText,
            Localizations,
        }
        public enum ApiPath
        {
            Organization_OrganizationId_Branding,
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
    public partial class OrganizationalBrandingGetResponse : RestApiResponse
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
        public OrganizationalBrandingLocalization[]? Localizations { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingGetResponse> OrganizationalBrandingGetAsync()
        {
            var p = new OrganizationalBrandingGetParameter();
            return await this.SendAsync<OrganizationalBrandingGetParameter, OrganizationalBrandingGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingGetResponse> OrganizationalBrandingGetAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalBrandingGetParameter();
            return await this.SendAsync<OrganizationalBrandingGetParameter, OrganizationalBrandingGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingGetResponse> OrganizationalBrandingGetAsync(OrganizationalBrandingGetParameter parameter)
        {
            return await this.SendAsync<OrganizationalBrandingGetParameter, OrganizationalBrandingGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingGetResponse> OrganizationalBrandingGetAsync(OrganizationalBrandingGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalBrandingGetParameter, OrganizationalBrandingGetResponse>(parameter, cancellationToken);
        }
    }
}

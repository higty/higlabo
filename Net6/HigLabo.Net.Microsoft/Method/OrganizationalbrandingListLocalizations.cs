using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrganizationalbrandingListLocalizationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class OrganizationalbrandingListLocalizationsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/organizationalbrandinglocalization?view=graph-rest-1.0
        /// </summary>
        public partial class OrganizationalBrandingLocalization
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

        public OrganizationalBrandingLocalization[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingListLocalizationsResponse> OrganizationalbrandingListLocalizationsAsync()
        {
            var p = new OrganizationalbrandingListLocalizationsParameter();
            return await this.SendAsync<OrganizationalbrandingListLocalizationsParameter, OrganizationalbrandingListLocalizationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingListLocalizationsResponse> OrganizationalbrandingListLocalizationsAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalbrandingListLocalizationsParameter();
            return await this.SendAsync<OrganizationalbrandingListLocalizationsParameter, OrganizationalbrandingListLocalizationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingListLocalizationsResponse> OrganizationalbrandingListLocalizationsAsync(OrganizationalbrandingListLocalizationsParameter parameter)
        {
            return await this.SendAsync<OrganizationalbrandingListLocalizationsParameter, OrganizationalbrandingListLocalizationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandingListLocalizationsResponse> OrganizationalbrandingListLocalizationsAsync(OrganizationalbrandingListLocalizationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalbrandingListLocalizationsParameter, OrganizationalbrandingListLocalizationsResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrganizationalBrandingListLocalizationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string OrganizationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization_OrganizationId_Branding_Localizations: return $"/organization/{OrganizationId}/branding/localizations";
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
    public partial class OrganizationalBrandingListLocalizationsResponse : RestApiResponse
    {
        public OrganizationalBrandingLocalization[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingListLocalizationsResponse> OrganizationalBrandingListLocalizationsAsync()
        {
            var p = new OrganizationalBrandingListLocalizationsParameter();
            return await this.SendAsync<OrganizationalBrandingListLocalizationsParameter, OrganizationalBrandingListLocalizationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingListLocalizationsResponse> OrganizationalBrandingListLocalizationsAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalBrandingListLocalizationsParameter();
            return await this.SendAsync<OrganizationalBrandingListLocalizationsParameter, OrganizationalBrandingListLocalizationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingListLocalizationsResponse> OrganizationalBrandingListLocalizationsAsync(OrganizationalBrandingListLocalizationsParameter parameter)
        {
            return await this.SendAsync<OrganizationalBrandingListLocalizationsParameter, OrganizationalBrandingListLocalizationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbranding-list-localizations?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalBrandingListLocalizationsResponse> OrganizationalBrandingListLocalizationsAsync(OrganizationalBrandingListLocalizationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalBrandingListLocalizationsParameter, OrganizationalBrandingListLocalizationsResponse>(parameter, cancellationToken);
        }
    }
}

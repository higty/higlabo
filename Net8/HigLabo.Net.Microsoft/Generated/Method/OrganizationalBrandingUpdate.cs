using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-update?view=graph-rest-1.0
    /// </summary>
    public partial class OrganizationalBrandingUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? BackgroundColor { get; set; }
        public Stream? BackgroundImage { get; set; }
        public Stream? BannerLogo { get; set; }
        public string? SignInPageText { get; set; }
        public Stream? SquareLogo { get; set; }
        public string? UsernameHintText { get; set; }
    }
    public partial class OrganizationalBrandingUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationalBrandingUpdateResponse> OrganizationalBrandingUpdateAsync()
        {
            var p = new OrganizationalBrandingUpdateParameter();
            return await this.SendAsync<OrganizationalBrandingUpdateParameter, OrganizationalBrandingUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationalBrandingUpdateResponse> OrganizationalBrandingUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalBrandingUpdateParameter();
            return await this.SendAsync<OrganizationalBrandingUpdateParameter, OrganizationalBrandingUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationalBrandingUpdateResponse> OrganizationalBrandingUpdateAsync(OrganizationalBrandingUpdateParameter parameter)
        {
            return await this.SendAsync<OrganizationalBrandingUpdateParameter, OrganizationalBrandingUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbranding-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationalBrandingUpdateResponse> OrganizationalBrandingUpdateAsync(OrganizationalBrandingUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalBrandingUpdateParameter, OrganizationalBrandingUpdateResponse>(parameter, cancellationToken);
        }
    }
}

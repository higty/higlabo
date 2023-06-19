using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
    /// </summary>
    public partial class OrganizationalBrandinglocalizationDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? OrganizationId { get; set; }
            public string? OrganizationalBrandingLocalizationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId: return $"/organization/{OrganizationId}/branding/localizations/{OrganizationalBrandingLocalizationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Organization_OrganizationId_Branding_Localizations_OrganizationalBrandingLocalizationId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class OrganizationalBrandinglocalizationDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationalBrandinglocalizationDeleteResponse> OrganizationalBrandinglocalizationDeleteAsync()
        {
            var p = new OrganizationalBrandinglocalizationDeleteParameter();
            return await this.SendAsync<OrganizationalBrandinglocalizationDeleteParameter, OrganizationalBrandinglocalizationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationalBrandinglocalizationDeleteResponse> OrganizationalBrandinglocalizationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalBrandinglocalizationDeleteParameter();
            return await this.SendAsync<OrganizationalBrandinglocalizationDeleteParameter, OrganizationalBrandinglocalizationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationalBrandinglocalizationDeleteResponse> OrganizationalBrandinglocalizationDeleteAsync(OrganizationalBrandinglocalizationDeleteParameter parameter)
        {
            return await this.SendAsync<OrganizationalBrandinglocalizationDeleteParameter, OrganizationalBrandinglocalizationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationalBrandinglocalizationDeleteResponse> OrganizationalBrandinglocalizationDeleteAsync(OrganizationalBrandinglocalizationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalBrandinglocalizationDeleteParameter, OrganizationalBrandinglocalizationDeleteResponse>(parameter, cancellationToken);
        }
    }
}

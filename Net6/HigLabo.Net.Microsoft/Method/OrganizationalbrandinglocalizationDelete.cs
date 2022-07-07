using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrganizationalbrandinglocalizationDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string OrganizationId { get; set; }
        public string OrganizationalBrandingLocalizationId { get; set; }
    }
    public partial class OrganizationalbrandinglocalizationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationDeleteResponse> OrganizationalbrandinglocalizationDeleteAsync()
        {
            var p = new OrganizationalbrandinglocalizationDeleteParameter();
            return await this.SendAsync<OrganizationalbrandinglocalizationDeleteParameter, OrganizationalbrandinglocalizationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationDeleteResponse> OrganizationalbrandinglocalizationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationalbrandinglocalizationDeleteParameter();
            return await this.SendAsync<OrganizationalbrandinglocalizationDeleteParameter, OrganizationalbrandinglocalizationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationDeleteResponse> OrganizationalbrandinglocalizationDeleteAsync(OrganizationalbrandinglocalizationDeleteParameter parameter)
        {
            return await this.SendAsync<OrganizationalbrandinglocalizationDeleteParameter, OrganizationalbrandinglocalizationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/organizationalbrandinglocalization-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationalbrandinglocalizationDeleteResponse> OrganizationalbrandinglocalizationDeleteAsync(OrganizationalbrandinglocalizationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationalbrandinglocalizationDeleteParameter, OrganizationalbrandinglocalizationDeleteResponse>(parameter, cancellationToken);
        }
    }
}

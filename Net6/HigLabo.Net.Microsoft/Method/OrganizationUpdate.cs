using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organization-update?view=graph-rest-1.0
    /// </summary>
    public partial class OrganizationUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization_Id: return $"/organization/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Organization_Id,
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
        public String[]? MarketingNotificationEmails { get; set; }
        public PrivacyProfile? PrivacyProfile { get; set; }
        public String[]? SecurityComplianceNotificationMails { get; set; }
        public String[]? SecurityComplianceNotificationPhones { get; set; }
        public String[]? TechnicalNotificationMails { get; set; }
    }
    public partial class OrganizationUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organization-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationUpdateResponse> OrganizationUpdateAsync()
        {
            var p = new OrganizationUpdateParameter();
            return await this.SendAsync<OrganizationUpdateParameter, OrganizationUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationUpdateResponse> OrganizationUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationUpdateParameter();
            return await this.SendAsync<OrganizationUpdateParameter, OrganizationUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationUpdateResponse> OrganizationUpdateAsync(OrganizationUpdateParameter parameter)
        {
            return await this.SendAsync<OrganizationUpdateParameter, OrganizationUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OrganizationUpdateResponse> OrganizationUpdateAsync(OrganizationUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationUpdateParameter, OrganizationUpdateResponse>(parameter, cancellationToken);
        }
    }
}

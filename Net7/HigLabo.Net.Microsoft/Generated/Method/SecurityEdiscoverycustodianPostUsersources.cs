using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-usersources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianPostUsersourcesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? CustodianId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_UserSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{CustodianId}/userSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum SecurityEdiscoverycustodianPostUsersourcesParameterSecuritySourceType
        {
            Mailbox,
            Site,
        }
        public enum UserSourceSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum UserSourceSecuritySourceType
        {
            Mailbox,
            Site,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_UserSources,
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
        public string? Email { get; set; }
        public SecurityEdiscoverycustodianPostUsersourcesParameterSecuritySourceType IncludedSources { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public UserSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public string? SiteWebUrl { get; set; }
    }
    public partial class SecurityEdiscoverycustodianPostUsersourcesResponse : RestApiResponse
    {
        public enum UserSourceSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum UserSourceSecuritySourceType
        {
            Mailbox,
            Site,
        }

        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public UserSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public UserSourceSecuritySourceType IncludedSources { get; set; }
        public string? SiteWebUrl { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-usersources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianPostUsersourcesResponse> SecurityEdiscoverycustodianPostUsersourcesAsync()
        {
            var p = new SecurityEdiscoverycustodianPostUsersourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianPostUsersourcesParameter, SecurityEdiscoverycustodianPostUsersourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianPostUsersourcesResponse> SecurityEdiscoverycustodianPostUsersourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianPostUsersourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianPostUsersourcesParameter, SecurityEdiscoverycustodianPostUsersourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianPostUsersourcesResponse> SecurityEdiscoverycustodianPostUsersourcesAsync(SecurityEdiscoverycustodianPostUsersourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianPostUsersourcesParameter, SecurityEdiscoverycustodianPostUsersourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-post-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianPostUsersourcesResponse> SecurityEdiscoverycustodianPostUsersourcesAsync(SecurityEdiscoverycustodianPostUsersourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianPostUsersourcesParameter, SecurityEdiscoverycustodianPostUsersourcesResponse>(parameter, cancellationToken);
        }
    }
}

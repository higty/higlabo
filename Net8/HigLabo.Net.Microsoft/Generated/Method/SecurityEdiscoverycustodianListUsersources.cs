using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianListUsersourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? CustodianId { get; set; }
            public string? EdiscoveryHoldPolicyId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_UserSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{CustodianId}/userSources";
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_LegalHolds_EdiscoveryHoldPolicyId_UserSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/legalHolds/{EdiscoveryHoldPolicyId}/userSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_UserSources,
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_LegalHolds_EdiscoveryHoldPolicyId_UserSources,
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
    public partial class SecurityEdiscoverycustodianListUsersourcesResponse : RestApiResponse
    {
        public UserSource[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianListUsersourcesResponse> SecurityEdiscoverycustodianListUsersourcesAsync()
        {
            var p = new SecurityEdiscoverycustodianListUsersourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianListUsersourcesParameter, SecurityEdiscoverycustodianListUsersourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianListUsersourcesResponse> SecurityEdiscoverycustodianListUsersourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianListUsersourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianListUsersourcesParameter, SecurityEdiscoverycustodianListUsersourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianListUsersourcesResponse> SecurityEdiscoverycustodianListUsersourcesAsync(SecurityEdiscoverycustodianListUsersourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianListUsersourcesParameter, SecurityEdiscoverycustodianListUsersourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianListUsersourcesResponse> SecurityEdiscoverycustodianListUsersourcesAsync(SecurityEdiscoverycustodianListUsersourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianListUsersourcesParameter, SecurityEdiscoverycustodianListUsersourcesResponse>(parameter, cancellationToken);
        }
    }
}

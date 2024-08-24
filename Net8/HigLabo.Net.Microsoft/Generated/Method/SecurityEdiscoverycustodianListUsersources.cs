using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycustodianListUsersourcesParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class SecurityEDiscoverycustodianListUsersourcesResponse : RestApiResponse<UserSource>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycustodianListUsersourcesResponse> SecurityEDiscoverycustodianListUsersourcesAsync()
        {
            var p = new SecurityEDiscoverycustodianListUsersourcesParameter();
            return await this.SendAsync<SecurityEDiscoverycustodianListUsersourcesParameter, SecurityEDiscoverycustodianListUsersourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycustodianListUsersourcesResponse> SecurityEDiscoverycustodianListUsersourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycustodianListUsersourcesParameter();
            return await this.SendAsync<SecurityEDiscoverycustodianListUsersourcesParameter, SecurityEDiscoverycustodianListUsersourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycustodianListUsersourcesResponse> SecurityEDiscoverycustodianListUsersourcesAsync(SecurityEDiscoverycustodianListUsersourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycustodianListUsersourcesParameter, SecurityEDiscoverycustodianListUsersourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycustodianListUsersourcesResponse> SecurityEDiscoverycustodianListUsersourcesAsync(SecurityEDiscoverycustodianListUsersourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycustodianListUsersourcesParameter, SecurityEDiscoverycustodianListUsersourcesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-usersources?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UserSource> SecurityEDiscoverycustodianListUsersourcesEnumerateAsync(SecurityEDiscoverycustodianListUsersourcesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityEDiscoverycustodianListUsersourcesParameter, SecurityEDiscoverycustodianListUsersourcesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<UserSource>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

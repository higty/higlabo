using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class IdentitysecuritydefaultsenforcementPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_IdentitySecurityDefaultsEnforcementPolicy: return $"/policies/identitySecurityDefaultsEnforcementPolicy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_IdentitySecurityDefaultsEnforcementPolicy,
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
        public bool? IsEnabled { get; set; }
    }
    public partial class IdentitysecuritydefaultsenforcementPolicyUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitysecuritydefaultsenforcementPolicyUpdateResponse> IdentitysecuritydefaultsenforcementPolicyUpdateAsync()
        {
            var p = new IdentitysecuritydefaultsenforcementPolicyUpdateParameter();
            return await this.SendAsync<IdentitysecuritydefaultsenforcementPolicyUpdateParameter, IdentitysecuritydefaultsenforcementPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitysecuritydefaultsenforcementPolicyUpdateResponse> IdentitysecuritydefaultsenforcementPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitysecuritydefaultsenforcementPolicyUpdateParameter();
            return await this.SendAsync<IdentitysecuritydefaultsenforcementPolicyUpdateParameter, IdentitysecuritydefaultsenforcementPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitysecuritydefaultsenforcementPolicyUpdateResponse> IdentitysecuritydefaultsenforcementPolicyUpdateAsync(IdentitysecuritydefaultsenforcementPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<IdentitysecuritydefaultsenforcementPolicyUpdateParameter, IdentitysecuritydefaultsenforcementPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identitysecuritydefaultsenforcementpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentitysecuritydefaultsenforcementPolicyUpdateResponse> IdentitysecuritydefaultsenforcementPolicyUpdateAsync(IdentitysecuritydefaultsenforcementPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitysecuritydefaultsenforcementPolicyUpdateParameter, IdentitysecuritydefaultsenforcementPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-delete-policies?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationstrengthRootDeletePoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AuthenticationStrengthPolicyId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationStrengthPolicies_AuthenticationStrengthPolicyId_ref: return $"/policies/authenticationStrengthPolicies/{AuthenticationStrengthPolicyId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_AuthenticationStrengthPolicies_AuthenticationStrengthPolicyId_ref,
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
    public partial class AuthenticationstrengthRootDeletePoliciesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-delete-policies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-delete-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthRootDeletePoliciesResponse> AuthenticationstrengthRootDeletePoliciesAsync()
        {
            var p = new AuthenticationstrengthRootDeletePoliciesParameter();
            return await this.SendAsync<AuthenticationstrengthRootDeletePoliciesParameter, AuthenticationstrengthRootDeletePoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-delete-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthRootDeletePoliciesResponse> AuthenticationstrengthRootDeletePoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationstrengthRootDeletePoliciesParameter();
            return await this.SendAsync<AuthenticationstrengthRootDeletePoliciesParameter, AuthenticationstrengthRootDeletePoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-delete-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthRootDeletePoliciesResponse> AuthenticationstrengthRootDeletePoliciesAsync(AuthenticationstrengthRootDeletePoliciesParameter parameter)
        {
            return await this.SendAsync<AuthenticationstrengthRootDeletePoliciesParameter, AuthenticationstrengthRootDeletePoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-delete-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthRootDeletePoliciesResponse> AuthenticationstrengthRootDeletePoliciesAsync(AuthenticationstrengthRootDeletePoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationstrengthRootDeletePoliciesParameter, AuthenticationstrengthRootDeletePoliciesResponse>(parameter, cancellationToken);
        }
    }
}

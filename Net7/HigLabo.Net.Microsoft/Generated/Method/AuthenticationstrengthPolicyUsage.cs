using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-usage?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationstrengthPolicyUsageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AuthenticationStrengthPolicyId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationStrengthPolicies_AuthenticationStrengthPolicyId_Usage: return $"/policies/authenticationStrengthPolicies/{AuthenticationStrengthPolicyId}/usage";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationStrengthPolicies_AuthenticationStrengthPolicyId_Usage,
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
    public partial class AuthenticationstrengthPolicyUsageResponse : RestApiResponse
    {
        public ConditionalAccessPolicy[]? Mfa { get; set; }
        public ConditionalAccessPolicy[]? None { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-usage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-usage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthPolicyUsageResponse> AuthenticationstrengthPolicyUsageAsync()
        {
            var p = new AuthenticationstrengthPolicyUsageParameter();
            return await this.SendAsync<AuthenticationstrengthPolicyUsageParameter, AuthenticationstrengthPolicyUsageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-usage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthPolicyUsageResponse> AuthenticationstrengthPolicyUsageAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationstrengthPolicyUsageParameter();
            return await this.SendAsync<AuthenticationstrengthPolicyUsageParameter, AuthenticationstrengthPolicyUsageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-usage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthPolicyUsageResponse> AuthenticationstrengthPolicyUsageAsync(AuthenticationstrengthPolicyUsageParameter parameter)
        {
            return await this.SendAsync<AuthenticationstrengthPolicyUsageParameter, AuthenticationstrengthPolicyUsageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-usage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthPolicyUsageResponse> AuthenticationstrengthPolicyUsageAsync(AuthenticationstrengthPolicyUsageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationstrengthPolicyUsageParameter, AuthenticationstrengthPolicyUsageResponse>(parameter, cancellationToken);
        }
    }
}

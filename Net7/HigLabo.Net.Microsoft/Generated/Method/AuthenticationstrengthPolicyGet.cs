using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationstrengthPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AuthenticationStrengthPolicyId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationStrengthPolicies_AuthenticationStrengthPolicyId: return $"/policies/authenticationStrengthPolicies/{AuthenticationStrengthPolicyId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthenticationStrengthPolicies_AuthenticationStrengthPolicyId,
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
    public partial class AuthenticationstrengthPolicyGetResponse : RestApiResponse
    {
        public enum AuthenticationStrengthPolicyAuthenticationStrengthPolicyType
        {
            BuiltIn,
            Custom,
            UnknownFutureValue,
            Eq,
            Ne,
            Not,
            In,
        }
        public enum AuthenticationStrengthPolicyAuthenticationStrengthRequirements
        {
            None,
            Mfa,
            UnknownFutureValue,
        }

        public AuthenticationMethodModes[]? AllowedCombinations { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public AuthenticationStrengthPolicyAuthenticationStrengthPolicyType PolicyType { get; set; }
        public AuthenticationStrengthPolicyAuthenticationStrengthRequirements RequirementsSatisfied { get; set; }
        public AuthenticationCombinationConfiguration[]? CombinationConfigurations { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthPolicyGetResponse> AuthenticationstrengthPolicyGetAsync()
        {
            var p = new AuthenticationstrengthPolicyGetParameter();
            return await this.SendAsync<AuthenticationstrengthPolicyGetParameter, AuthenticationstrengthPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthPolicyGetResponse> AuthenticationstrengthPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationstrengthPolicyGetParameter();
            return await this.SendAsync<AuthenticationstrengthPolicyGetParameter, AuthenticationstrengthPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthPolicyGetResponse> AuthenticationstrengthPolicyGetAsync(AuthenticationstrengthPolicyGetParameter parameter)
        {
            return await this.SendAsync<AuthenticationstrengthPolicyGetParameter, AuthenticationstrengthPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthPolicyGetResponse> AuthenticationstrengthPolicyGetAsync(AuthenticationstrengthPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationstrengthPolicyGetParameter, AuthenticationstrengthPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}

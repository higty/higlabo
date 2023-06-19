using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-policies?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationstrengthRootListPoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationStrengthPolicies: return $"/policies/authenticationStrengthPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AllowedCombinations,
            CreatedDateTime,
            Description,
            DisplayName,
            Id,
            ModifiedDateTime,
            PolicyType,
            RequirementsSatisfied,
            CombinationConfigurations,
        }
        public enum ApiPath
        {
            Policies_AuthenticationStrengthPolicies,
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
    public partial class AuthenticationstrengthRootListPoliciesResponse : RestApiResponse
    {
        public AuthenticationStrengthPolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-policies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthRootListPoliciesResponse> AuthenticationstrengthRootListPoliciesAsync()
        {
            var p = new AuthenticationstrengthRootListPoliciesParameter();
            return await this.SendAsync<AuthenticationstrengthRootListPoliciesParameter, AuthenticationstrengthRootListPoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthRootListPoliciesResponse> AuthenticationstrengthRootListPoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new AuthenticationstrengthRootListPoliciesParameter();
            return await this.SendAsync<AuthenticationstrengthRootListPoliciesParameter, AuthenticationstrengthRootListPoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthRootListPoliciesResponse> AuthenticationstrengthRootListPoliciesAsync(AuthenticationstrengthRootListPoliciesParameter parameter)
        {
            return await this.SendAsync<AuthenticationstrengthRootListPoliciesParameter, AuthenticationstrengthRootListPoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/authenticationstrengthroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AuthenticationstrengthRootListPoliciesResponse> AuthenticationstrengthRootListPoliciesAsync(AuthenticationstrengthRootListPoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthenticationstrengthRootListPoliciesParameter, AuthenticationstrengthRootListPoliciesResponse>(parameter, cancellationToken);
        }
    }
}

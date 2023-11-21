using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessRootListPoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_Policies: return $"/identity/conditionalAccess/policies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Conditions,
            CreatedDateTime,
            DisplayName,
            GrantControls,
            Id,
            ModifiedDateTime,
            SessionControls,
            State,
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_Policies,
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
    public partial class ConditionalAccessRootListPoliciesResponse : RestApiResponse
    {
        public ConditionalAccessPolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootListPoliciesResponse> ConditionalAccessRootListPoliciesAsync()
        {
            var p = new ConditionalAccessRootListPoliciesParameter();
            return await this.SendAsync<ConditionalAccessRootListPoliciesParameter, ConditionalAccessRootListPoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootListPoliciesResponse> ConditionalAccessRootListPoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalAccessRootListPoliciesParameter();
            return await this.SendAsync<ConditionalAccessRootListPoliciesParameter, ConditionalAccessRootListPoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootListPoliciesResponse> ConditionalAccessRootListPoliciesAsync(ConditionalAccessRootListPoliciesParameter parameter)
        {
            return await this.SendAsync<ConditionalAccessRootListPoliciesParameter, ConditionalAccessRootListPoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootListPoliciesResponse> ConditionalAccessRootListPoliciesAsync(ConditionalAccessRootListPoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalAccessRootListPoliciesParameter, ConditionalAccessRootListPoliciesResponse>(parameter, cancellationToken);
        }
    }
}

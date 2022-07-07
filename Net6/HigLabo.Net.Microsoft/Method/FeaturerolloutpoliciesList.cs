using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class FeaturerolloutpoliciesListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_FeatureRolloutPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_FeatureRolloutPolicies: return $"/policies/featureRolloutPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class FeaturerolloutpoliciesListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/featurerolloutpolicy?view=graph-rest-1.0
        /// </summary>
        public partial class FeatureRolloutPolicy
        {
            public enum FeatureRolloutPolicystring
            {
                PassthroughAuthentication,
                SeamlessSso,
                PasswordHashSync,
                EmailAsAlternateId,
                UnknownFutureValue,
            }

            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public FeatureRolloutPolicystring Feature { get; set; }
            public string? Id { get; set; }
            public bool? IsAppliedToOrganization { get; set; }
            public bool? IsEnabled { get; set; }
        }

        public FeatureRolloutPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync()
        {
            var p = new FeaturerolloutpoliciesListParameter();
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutpoliciesListParameter();
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync(FeaturerolloutpoliciesListParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-list?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesListResponse> FeaturerolloutpoliciesListAsync(FeaturerolloutpoliciesListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutpoliciesListParameter, FeaturerolloutpoliciesListResponse>(parameter, cancellationToken);
        }
    }
}

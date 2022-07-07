using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class FeaturerolloutpoliciesPostParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Feature { get; set; }
        public string? IsEnabled { get; set; }
    }
    public partial class FeaturerolloutpoliciesPostResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-post?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesPostResponse> FeaturerolloutpoliciesPostAsync()
        {
            var p = new FeaturerolloutpoliciesPostParameter();
            return await this.SendAsync<FeaturerolloutpoliciesPostParameter, FeaturerolloutpoliciesPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-post?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesPostResponse> FeaturerolloutpoliciesPostAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutpoliciesPostParameter();
            return await this.SendAsync<FeaturerolloutpoliciesPostParameter, FeaturerolloutpoliciesPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-post?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesPostResponse> FeaturerolloutpoliciesPostAsync(FeaturerolloutpoliciesPostParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutpoliciesPostParameter, FeaturerolloutpoliciesPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicies-post?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpoliciesPostResponse> FeaturerolloutpoliciesPostAsync(FeaturerolloutpoliciesPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutpoliciesPostParameter, FeaturerolloutpoliciesPostResponse>(parameter, cancellationToken);
        }
    }
}

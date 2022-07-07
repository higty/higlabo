using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class FeaturerolloutpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_FeatureRolloutPolicies_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_FeatureRolloutPolicies_Id: return $"/policies/featureRolloutPolicies/{Id}";
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
        public string Id { get; set; }
    }
    public partial class FeaturerolloutpolicyGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyGetResponse> FeaturerolloutpolicyGetAsync()
        {
            var p = new FeaturerolloutpolicyGetParameter();
            return await this.SendAsync<FeaturerolloutpolicyGetParameter, FeaturerolloutpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyGetResponse> FeaturerolloutpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutpolicyGetParameter();
            return await this.SendAsync<FeaturerolloutpolicyGetParameter, FeaturerolloutpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyGetResponse> FeaturerolloutpolicyGetAsync(FeaturerolloutpolicyGetParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutpolicyGetParameter, FeaturerolloutpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutpolicyGetResponse> FeaturerolloutpolicyGetAsync(FeaturerolloutpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutpolicyGetParameter, FeaturerolloutpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}

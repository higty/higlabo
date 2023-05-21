using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class FeaturerolloutPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_FeatureRolloutPolicies_Id: return $"/policies/featureRolloutPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_FeatureRolloutPolicies_Id,
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
    public partial class FeaturerolloutPolicyGetResponse : RestApiResponse
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
        public DirectoryObject[]? AppliesTo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyGetResponse> FeaturerolloutPolicyGetAsync()
        {
            var p = new FeaturerolloutPolicyGetParameter();
            return await this.SendAsync<FeaturerolloutPolicyGetParameter, FeaturerolloutPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyGetResponse> FeaturerolloutPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new FeaturerolloutPolicyGetParameter();
            return await this.SendAsync<FeaturerolloutPolicyGetParameter, FeaturerolloutPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyGetResponse> FeaturerolloutPolicyGetAsync(FeaturerolloutPolicyGetParameter parameter)
        {
            return await this.SendAsync<FeaturerolloutPolicyGetParameter, FeaturerolloutPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/featurerolloutpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<FeaturerolloutPolicyGetResponse> FeaturerolloutPolicyGetAsync(FeaturerolloutPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FeaturerolloutPolicyGetParameter, FeaturerolloutPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}

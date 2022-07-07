using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppPolicies_ManagedAppPolicyId,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies_ManagedAppPolicyId,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies_ManagedAppPolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppPolicies_ManagedAppPolicyId: return $"/deviceAppManagement/managedAppPolicies/{ManagedAppPolicyId}";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies_ManagedAppPolicyId: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/appliedPolicies/{ManagedAppPolicyId}";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies_ManagedAppPolicyId: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/intendedPolicies/{ManagedAppPolicyId}";
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
        public string ManagedAppPolicyId { get; set; }
        public string ManagedAppRegistrationId { get; set; }
    }
    public partial class IntuneMamManagedappconfigurationGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public KeyValuePair[]? CustomSettings { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappconfigurationGetResponse> IntuneMamManagedappconfigurationGetAsync()
        {
            var p = new IntuneMamManagedappconfigurationGetParameter();
            return await this.SendAsync<IntuneMamManagedappconfigurationGetParameter, IntuneMamManagedappconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappconfigurationGetResponse> IntuneMamManagedappconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappconfigurationGetParameter();
            return await this.SendAsync<IntuneMamManagedappconfigurationGetParameter, IntuneMamManagedappconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappconfigurationGetResponse> IntuneMamManagedappconfigurationGetAsync(IntuneMamManagedappconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappconfigurationGetParameter, IntuneMamManagedappconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappconfigurationGetResponse> IntuneMamManagedappconfigurationGetAsync(IntuneMamManagedappconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappconfigurationGetParameter, IntuneMamManagedappconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}

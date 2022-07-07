using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedapppolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppPolicies,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppPolicies: return $"/deviceAppManagement/managedAppPolicies";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/appliedPolicies";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/intendedPolicies";
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
        public string ManagedAppRegistrationId { get; set; }
    }
    public partial class IntuneMamManagedapppolicyListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedapppolicy?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedAppPolicy
        {
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Id { get; set; }
            public string? Version { get; set; }
        }

        public ManagedAppPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedapppolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedapppolicyListResponse> IntuneMamManagedapppolicyListAsync()
        {
            var p = new IntuneMamManagedapppolicyListParameter();
            return await this.SendAsync<IntuneMamManagedapppolicyListParameter, IntuneMamManagedapppolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedapppolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedapppolicyListResponse> IntuneMamManagedapppolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedapppolicyListParameter();
            return await this.SendAsync<IntuneMamManagedapppolicyListParameter, IntuneMamManagedapppolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedapppolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedapppolicyListResponse> IntuneMamManagedapppolicyListAsync(IntuneMamManagedapppolicyListParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedapppolicyListParameter, IntuneMamManagedapppolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedapppolicy-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedapppolicyListResponse> IntuneMamManagedapppolicyListAsync(IntuneMamManagedapppolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedapppolicyListParameter, IntuneMamManagedapppolicyListResponse>(parameter, cancellationToken);
        }
    }
}

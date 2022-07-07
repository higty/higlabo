using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissiongrantpolicyListExcludesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_PermissionGrantPolicies_Id_Excludes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_PermissionGrantPolicies_Id_Excludes: return $"/policies/permissionGrantPolicies/{Id}/excludes";
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
    public partial class PermissiongrantpolicyListExcludesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/permissiongrantconditionset?view=graph-rest-1.0
        /// </summary>
        public partial class PermissionGrantConditionSet
        {
            public enum PermissionGrantConditionSetPermissionType
            {
                Application,
                Delegated,
                DelegatedUserConsentable,
            }

            public string? Id { get; set; }
            public string? PermissionClassification { get; set; }
            public PermissionGrantConditionSetPermissionType PermissionType { get; set; }
            public string? ResourceApplication { get; set; }
            public String[]? Permissions { get; set; }
            public String[]? ClientApplicationIds { get; set; }
            public String[]? ClientApplicationTenantIds { get; set; }
            public String[]? ClientApplicationPublisherIds { get; set; }
            public bool? ClientApplicationsFromVerifiedPublisherOnly { get; set; }
        }

        public PermissionGrantConditionSet[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyListExcludesResponse> PermissiongrantpolicyListExcludesAsync()
        {
            var p = new PermissiongrantpolicyListExcludesParameter();
            return await this.SendAsync<PermissiongrantpolicyListExcludesParameter, PermissiongrantpolicyListExcludesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyListExcludesResponse> PermissiongrantpolicyListExcludesAsync(CancellationToken cancellationToken)
        {
            var p = new PermissiongrantpolicyListExcludesParameter();
            return await this.SendAsync<PermissiongrantpolicyListExcludesParameter, PermissiongrantpolicyListExcludesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyListExcludesResponse> PermissiongrantpolicyListExcludesAsync(PermissiongrantpolicyListExcludesParameter parameter)
        {
            return await this.SendAsync<PermissiongrantpolicyListExcludesParameter, PermissiongrantpolicyListExcludesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permissiongrantpolicy-list-excludes?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissiongrantpolicyListExcludesResponse> PermissiongrantpolicyListExcludesAsync(PermissiongrantpolicyListExcludesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissiongrantpolicyListExcludesParameter, PermissiongrantpolicyListExcludesResponse>(parameter, cancellationToken);
        }
    }
}

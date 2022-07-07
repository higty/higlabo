using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementListAccesspackagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages: return $"/identityGovernance/entitlementManagement/accessPackages";
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
    public partial class EntitlementmanagementListAccesspackagesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackage?view=graph-rest-1.0
        /// </summary>
        public partial class AccessPackage
        {
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public bool? IsHidden { get; set; }
            public DateTimeOffset? ModifiedDateTime { get; set; }
        }

        public AccessPackage[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAccesspackagesResponse> EntitlementmanagementListAccesspackagesAsync()
        {
            var p = new EntitlementmanagementListAccesspackagesParameter();
            return await this.SendAsync<EntitlementmanagementListAccesspackagesParameter, EntitlementmanagementListAccesspackagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAccesspackagesResponse> EntitlementmanagementListAccesspackagesAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementListAccesspackagesParameter();
            return await this.SendAsync<EntitlementmanagementListAccesspackagesParameter, EntitlementmanagementListAccesspackagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAccesspackagesResponse> EntitlementmanagementListAccesspackagesAsync(EntitlementmanagementListAccesspackagesParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementListAccesspackagesParameter, EntitlementmanagementListAccesspackagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAccesspackagesResponse> EntitlementmanagementListAccesspackagesAsync(EntitlementmanagementListAccesspackagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementListAccesspackagesParameter, EntitlementmanagementListAccesspackagesResponse>(parameter, cancellationToken);
        }
    }
}

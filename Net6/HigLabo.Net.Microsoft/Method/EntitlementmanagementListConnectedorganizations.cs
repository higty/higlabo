using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementListConnectedorganizationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations: return $"/identityGovernance/entitlementManagement/connectedOrganizations";
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
    public partial class EntitlementmanagementListConnectedorganizationsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/connectedorganization?view=graph-rest-1.0
        /// </summary>
        public partial class ConnectedOrganization
        {
            public enum ConnectedOrganizationConnectedOrganizationState
            {
                AllConfiguredConnectedOrganizationSubjects,
                Configured,
                Proposed,
                UnknownFutureValue,
            }

            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public IdentitySource[]? IdentitySources { get; set; }
            public DateTimeOffset? ModifiedDateTime { get; set; }
            public ConnectedOrganizationConnectedOrganizationState State { get; set; }
        }

        public ConnectedOrganization[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListConnectedorganizationsResponse> EntitlementmanagementListConnectedorganizationsAsync()
        {
            var p = new EntitlementmanagementListConnectedorganizationsParameter();
            return await this.SendAsync<EntitlementmanagementListConnectedorganizationsParameter, EntitlementmanagementListConnectedorganizationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListConnectedorganizationsResponse> EntitlementmanagementListConnectedorganizationsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementListConnectedorganizationsParameter();
            return await this.SendAsync<EntitlementmanagementListConnectedorganizationsParameter, EntitlementmanagementListConnectedorganizationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListConnectedorganizationsResponse> EntitlementmanagementListConnectedorganizationsAsync(EntitlementmanagementListConnectedorganizationsParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementListConnectedorganizationsParameter, EntitlementmanagementListConnectedorganizationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListConnectedorganizationsResponse> EntitlementmanagementListConnectedorganizationsAsync(EntitlementmanagementListConnectedorganizationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementListConnectedorganizationsParameter, EntitlementmanagementListConnectedorganizationsResponse>(parameter, cancellationToken);
        }
    }
}

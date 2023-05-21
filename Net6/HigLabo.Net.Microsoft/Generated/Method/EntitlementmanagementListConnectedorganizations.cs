using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementListConnectedorganizationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations: return $"/identityGovernance/entitlementManagement/connectedOrganizations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Description,
            DisplayName,
            Id,
            IdentitySources,
            ModifiedDateTime,
            State,
            ExternalSponsors,
            InternalSponsors,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations,
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
    public partial class EntitlementManagementListConnectedorganizationsResponse : RestApiResponse
    {
        public ConnectedOrganization[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListConnectedorganizationsResponse> EntitlementManagementListConnectedorganizationsAsync()
        {
            var p = new EntitlementManagementListConnectedorganizationsParameter();
            return await this.SendAsync<EntitlementManagementListConnectedorganizationsParameter, EntitlementManagementListConnectedorganizationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListConnectedorganizationsResponse> EntitlementManagementListConnectedorganizationsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementListConnectedorganizationsParameter();
            return await this.SendAsync<EntitlementManagementListConnectedorganizationsParameter, EntitlementManagementListConnectedorganizationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListConnectedorganizationsResponse> EntitlementManagementListConnectedorganizationsAsync(EntitlementManagementListConnectedorganizationsParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementListConnectedorganizationsParameter, EntitlementManagementListConnectedorganizationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-connectedorganizations?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListConnectedorganizationsResponse> EntitlementManagementListConnectedorganizationsAsync(EntitlementManagementListConnectedorganizationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementListConnectedorganizationsParameter, EntitlementManagementListConnectedorganizationsResponse>(parameter, cancellationToken);
        }
    }
}

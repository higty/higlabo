using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class ConnectedorganizationListInternalsponsorsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{Id}/internalSponsors";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors,
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
    public partial class ConnectedorganizationListInternalsponsorsResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationListInternalsponsorsResponse> ConnectedorganizationListInternalsponsorsAsync()
        {
            var p = new ConnectedorganizationListInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationListInternalsponsorsParameter, ConnectedorganizationListInternalsponsorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationListInternalsponsorsResponse> ConnectedorganizationListInternalsponsorsAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationListInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationListInternalsponsorsParameter, ConnectedorganizationListInternalsponsorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationListInternalsponsorsResponse> ConnectedorganizationListInternalsponsorsAsync(ConnectedorganizationListInternalsponsorsParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationListInternalsponsorsParameter, ConnectedorganizationListInternalsponsorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationListInternalsponsorsResponse> ConnectedorganizationListInternalsponsorsAsync(ConnectedorganizationListInternalsponsorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationListInternalsponsorsParameter, ConnectedorganizationListInternalsponsorsResponse>(parameter, cancellationToken);
        }
    }
}

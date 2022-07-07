using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConnectedorganizationListInternalsponsorsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_InternalSponsors: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{Id}/internalSponsors";
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
    public partial class ConnectedorganizationListInternalsponsorsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryobject?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryObject
        {
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationListInternalsponsorsResponse> ConnectedorganizationListInternalsponsorsAsync()
        {
            var p = new ConnectedorganizationListInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationListInternalsponsorsParameter, ConnectedorganizationListInternalsponsorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationListInternalsponsorsResponse> ConnectedorganizationListInternalsponsorsAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationListInternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationListInternalsponsorsParameter, ConnectedorganizationListInternalsponsorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationListInternalsponsorsResponse> ConnectedorganizationListInternalsponsorsAsync(ConnectedorganizationListInternalsponsorsParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationListInternalsponsorsParameter, ConnectedorganizationListInternalsponsorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-list-internalsponsors?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationListInternalsponsorsResponse> ConnectedorganizationListInternalsponsorsAsync(ConnectedorganizationListInternalsponsorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationListInternalsponsorsParameter, ConnectedorganizationListInternalsponsorsResponse>(parameter, cancellationToken);
        }
    }
}

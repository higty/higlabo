using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConnectedorganizationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_ConnectedOrganizationId: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{ConnectedOrganizationId}";
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
        public string ConnectedOrganizationId { get; set; }
    }
    public partial class ConnectedorganizationGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationGetResponse> ConnectedorganizationGetAsync()
        {
            var p = new ConnectedorganizationGetParameter();
            return await this.SendAsync<ConnectedorganizationGetParameter, ConnectedorganizationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationGetResponse> ConnectedorganizationGetAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationGetParameter();
            return await this.SendAsync<ConnectedorganizationGetParameter, ConnectedorganizationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationGetResponse> ConnectedorganizationGetAsync(ConnectedorganizationGetParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationGetParameter, ConnectedorganizationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/connectedorganization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ConnectedorganizationGetResponse> ConnectedorganizationGetAsync(ConnectedorganizationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationGetParameter, ConnectedorganizationGetResponse>(parameter, cancellationToken);
        }
    }
}

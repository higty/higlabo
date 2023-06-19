using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class ConnectedorganizationListExternalsponsorsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_ExternalSponsors: return $"/identityGovernance/entitlementManagement/connectedOrganizations/{Id}/externalSponsors";
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
            IdentityGovernance_EntitlementManagement_ConnectedOrganizations_Id_ExternalSponsors,
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
    public partial class ConnectedorganizationListExternalsponsorsResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedorganizationListExternalsponsorsResponse> ConnectedorganizationListExternalsponsorsAsync()
        {
            var p = new ConnectedorganizationListExternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationListExternalsponsorsParameter, ConnectedorganizationListExternalsponsorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedorganizationListExternalsponsorsResponse> ConnectedorganizationListExternalsponsorsAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedorganizationListExternalsponsorsParameter();
            return await this.SendAsync<ConnectedorganizationListExternalsponsorsParameter, ConnectedorganizationListExternalsponsorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedorganizationListExternalsponsorsResponse> ConnectedorganizationListExternalsponsorsAsync(ConnectedorganizationListExternalsponsorsParameter parameter)
        {
            return await this.SendAsync<ConnectedorganizationListExternalsponsorsParameter, ConnectedorganizationListExternalsponsorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedorganizationListExternalsponsorsResponse> ConnectedorganizationListExternalsponsorsAsync(ConnectedorganizationListExternalsponsorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedorganizationListExternalsponsorsParameter, ConnectedorganizationListExternalsponsorsResponse>(parameter, cancellationToken);
        }
    }
}

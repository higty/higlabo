using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class ConnectedOrganizationListExternalsponsorsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ConnectedOrganizationListExternalsponsorsResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedOrganizationListExternalsponsorsResponse> ConnectedOrganizationListExternalsponsorsAsync()
        {
            var p = new ConnectedOrganizationListExternalsponsorsParameter();
            return await this.SendAsync<ConnectedOrganizationListExternalsponsorsParameter, ConnectedOrganizationListExternalsponsorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedOrganizationListExternalsponsorsResponse> ConnectedOrganizationListExternalsponsorsAsync(CancellationToken cancellationToken)
        {
            var p = new ConnectedOrganizationListExternalsponsorsParameter();
            return await this.SendAsync<ConnectedOrganizationListExternalsponsorsParameter, ConnectedOrganizationListExternalsponsorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedOrganizationListExternalsponsorsResponse> ConnectedOrganizationListExternalsponsorsAsync(ConnectedOrganizationListExternalsponsorsParameter parameter)
        {
            return await this.SendAsync<ConnectedOrganizationListExternalsponsorsParameter, ConnectedOrganizationListExternalsponsorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConnectedOrganizationListExternalsponsorsResponse> ConnectedOrganizationListExternalsponsorsAsync(ConnectedOrganizationListExternalsponsorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConnectedOrganizationListExternalsponsorsParameter, ConnectedOrganizationListExternalsponsorsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/connectedorganization-list-externalsponsors?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> ConnectedOrganizationListExternalsponsorsEnumerateAsync(ConnectedOrganizationListExternalsponsorsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ConnectedOrganizationListExternalsponsorsParameter, ConnectedOrganizationListExternalsponsorsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

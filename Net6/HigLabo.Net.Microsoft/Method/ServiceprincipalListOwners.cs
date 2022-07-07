using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListOwnersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_Owners,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_Owners: return $"/servicePrincipals/{Id}/owners";
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
    public partial class ServiceprincipalListOwnersResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnersResponse> ServiceprincipalListOwnersAsync()
        {
            var p = new ServiceprincipalListOwnersParameter();
            return await this.SendAsync<ServiceprincipalListOwnersParameter, ServiceprincipalListOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnersResponse> ServiceprincipalListOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListOwnersParameter();
            return await this.SendAsync<ServiceprincipalListOwnersParameter, ServiceprincipalListOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnersResponse> ServiceprincipalListOwnersAsync(ServiceprincipalListOwnersParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListOwnersParameter, ServiceprincipalListOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnersResponse> ServiceprincipalListOwnersAsync(ServiceprincipalListOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListOwnersParameter, ServiceprincipalListOwnersResponse>(parameter, cancellationToken);
        }
    }
}

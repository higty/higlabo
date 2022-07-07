using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListTransitivememberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_TransitiveMemberOf,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_TransitiveMemberOf: return $"/servicePrincipals/{Id}/transitiveMemberOf";
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
    public partial class ServiceprincipalListTransitivememberofResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListTransitivememberofResponse> ServiceprincipalListTransitivememberofAsync()
        {
            var p = new ServiceprincipalListTransitivememberofParameter();
            return await this.SendAsync<ServiceprincipalListTransitivememberofParameter, ServiceprincipalListTransitivememberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListTransitivememberofResponse> ServiceprincipalListTransitivememberofAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListTransitivememberofParameter();
            return await this.SendAsync<ServiceprincipalListTransitivememberofParameter, ServiceprincipalListTransitivememberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListTransitivememberofResponse> ServiceprincipalListTransitivememberofAsync(ServiceprincipalListTransitivememberofParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListTransitivememberofParameter, ServiceprincipalListTransitivememberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListTransitivememberofResponse> ServiceprincipalListTransitivememberofAsync(ServiceprincipalListTransitivememberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListTransitivememberofParameter, ServiceprincipalListTransitivememberofResponse>(parameter, cancellationToken);
        }
    }
}

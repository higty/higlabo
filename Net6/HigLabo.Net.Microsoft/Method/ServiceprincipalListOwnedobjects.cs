using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListOwnedobjectsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_OwnedObjects,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_OwnedObjects: return $"/servicePrincipals/{Id}/ownedObjects";
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
    public partial class ServiceprincipalListOwnedobjectsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnedobjectsResponse> ServiceprincipalListOwnedobjectsAsync()
        {
            var p = new ServiceprincipalListOwnedobjectsParameter();
            return await this.SendAsync<ServiceprincipalListOwnedobjectsParameter, ServiceprincipalListOwnedobjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnedobjectsResponse> ServiceprincipalListOwnedobjectsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListOwnedobjectsParameter();
            return await this.SendAsync<ServiceprincipalListOwnedobjectsParameter, ServiceprincipalListOwnedobjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnedobjectsResponse> ServiceprincipalListOwnedobjectsAsync(ServiceprincipalListOwnedobjectsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListOwnedobjectsParameter, ServiceprincipalListOwnedobjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnedobjectsResponse> ServiceprincipalListOwnedobjectsAsync(ServiceprincipalListOwnedobjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListOwnedobjectsParameter, ServiceprincipalListOwnedobjectsResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListCreatedobjectsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_CreatedObjects,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_CreatedObjects: return $"/servicePrincipals/{Id}/createdObjects";
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
    public partial class ServiceprincipalListCreatedobjectsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListCreatedobjectsResponse> ServiceprincipalListCreatedobjectsAsync()
        {
            var p = new ServiceprincipalListCreatedobjectsParameter();
            return await this.SendAsync<ServiceprincipalListCreatedobjectsParameter, ServiceprincipalListCreatedobjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListCreatedobjectsResponse> ServiceprincipalListCreatedobjectsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListCreatedobjectsParameter();
            return await this.SendAsync<ServiceprincipalListCreatedobjectsParameter, ServiceprincipalListCreatedobjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListCreatedobjectsResponse> ServiceprincipalListCreatedobjectsAsync(ServiceprincipalListCreatedobjectsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListCreatedobjectsParameter, ServiceprincipalListCreatedobjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListCreatedobjectsResponse> ServiceprincipalListCreatedobjectsAsync(ServiceprincipalListCreatedobjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListCreatedobjectsParameter, ServiceprincipalListCreatedobjectsResponse>(parameter, cancellationToken);
        }
    }
}

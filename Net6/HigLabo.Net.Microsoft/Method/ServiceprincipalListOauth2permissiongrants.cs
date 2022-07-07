using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListOauth2permissiongrantsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_Oauth2PermissionGrants,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ServicePrincipals_Id_Oauth2PermissionGrants: return $"/servicePrincipals/{Id}/oauth2PermissionGrants";
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
    public partial class ServiceprincipalListOauth2permissiongrantsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/oauth2permissiongrant?view=graph-rest-1.0
        /// </summary>
        public partial class OAuth2PermissionGrant
        {
            public string? Id { get; set; }
            public string? ClientId { get; set; }
            public string? ConsentType { get; set; }
            public string? PrincipalId { get; set; }
            public string? ResourceId { get; set; }
            public string? Scope { get; set; }
        }

        public OAuth2PermissionGrant[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOauth2permissiongrantsResponse> ServiceprincipalListOauth2permissiongrantsAsync()
        {
            var p = new ServiceprincipalListOauth2permissiongrantsParameter();
            return await this.SendAsync<ServiceprincipalListOauth2permissiongrantsParameter, ServiceprincipalListOauth2permissiongrantsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOauth2permissiongrantsResponse> ServiceprincipalListOauth2permissiongrantsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListOauth2permissiongrantsParameter();
            return await this.SendAsync<ServiceprincipalListOauth2permissiongrantsParameter, ServiceprincipalListOauth2permissiongrantsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOauth2permissiongrantsResponse> ServiceprincipalListOauth2permissiongrantsAsync(ServiceprincipalListOauth2permissiongrantsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListOauth2permissiongrantsParameter, ServiceprincipalListOauth2permissiongrantsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list-oauth2permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOauth2permissiongrantsResponse> ServiceprincipalListOauth2permissiongrantsAsync(ServiceprincipalListOauth2permissiongrantsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListOauth2permissiongrantsParameter, ServiceprincipalListOauth2permissiongrantsResponse>(parameter, cancellationToken);
        }
    }
}

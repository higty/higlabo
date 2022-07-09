using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListOauth2permissiongrantsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_Oauth2PermissionGrants: return $"/servicePrincipals/{Id}/oauth2PermissionGrants";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            ClientId,
            ConsentType,
            PrincipalId,
            ResourceId,
            Scope,
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_Oauth2PermissionGrants,
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
    public partial class ServiceprincipalListOauth2permissiongrantsResponse : RestApiResponse
    {
        public OAuth2PermissionGrant[]? Value { get; set; }
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

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalListTransitivememberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_TransitiveMemberOf: return $"/servicePrincipals/{Id}/transitiveMemberOf";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
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
            ServicePrincipals_Id_TransitiveMemberOf,
            ServicePrincipals,
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
    public partial class ServiceprincipalListTransitivememberofResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListTransitivememberofResponse> ServiceprincipalListTransitivememberofAsync()
        {
            var p = new ServiceprincipalListTransitivememberofParameter();
            return await this.SendAsync<ServiceprincipalListTransitivememberofParameter, ServiceprincipalListTransitivememberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListTransitivememberofResponse> ServiceprincipalListTransitivememberofAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListTransitivememberofParameter();
            return await this.SendAsync<ServiceprincipalListTransitivememberofParameter, ServiceprincipalListTransitivememberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListTransitivememberofResponse> ServiceprincipalListTransitivememberofAsync(ServiceprincipalListTransitivememberofParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListTransitivememberofParameter, ServiceprincipalListTransitivememberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListTransitivememberofResponse> ServiceprincipalListTransitivememberofAsync(ServiceprincipalListTransitivememberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListTransitivememberofParameter, ServiceprincipalListTransitivememberofResponse>(parameter, cancellationToken);
        }
    }
}

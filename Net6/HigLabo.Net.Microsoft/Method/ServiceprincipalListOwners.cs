using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalListOwnersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_Owners: return $"/servicePrincipals/{Id}/owners";
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
            ServicePrincipals_Id_Owners,
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
    public partial class ServiceprincipalListOwnersResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnersResponse> ServiceprincipalListOwnersAsync()
        {
            var p = new ServiceprincipalListOwnersParameter();
            return await this.SendAsync<ServiceprincipalListOwnersParameter, ServiceprincipalListOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnersResponse> ServiceprincipalListOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListOwnersParameter();
            return await this.SendAsync<ServiceprincipalListOwnersParameter, ServiceprincipalListOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnersResponse> ServiceprincipalListOwnersAsync(ServiceprincipalListOwnersParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListOwnersParameter, ServiceprincipalListOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListOwnersResponse> ServiceprincipalListOwnersAsync(ServiceprincipalListOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListOwnersParameter, ServiceprincipalListOwnersResponse>(parameter, cancellationToken);
        }
    }
}

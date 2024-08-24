using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalListOwnersParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ServicePrincipalListOwnersResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListOwnersResponse> ServicePrincipalListOwnersAsync()
        {
            var p = new ServicePrincipalListOwnersParameter();
            return await this.SendAsync<ServicePrincipalListOwnersParameter, ServicePrincipalListOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListOwnersResponse> ServicePrincipalListOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalListOwnersParameter();
            return await this.SendAsync<ServicePrincipalListOwnersParameter, ServicePrincipalListOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListOwnersResponse> ServicePrincipalListOwnersAsync(ServicePrincipalListOwnersParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalListOwnersParameter, ServicePrincipalListOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListOwnersResponse> ServicePrincipalListOwnersAsync(ServicePrincipalListOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalListOwnersParameter, ServicePrincipalListOwnersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-owners?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> ServicePrincipalListOwnersEnumerateAsync(ServicePrincipalListOwnersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ServicePrincipalListOwnersParameter, ServicePrincipalListOwnersResponse>(parameter, cancellationToken);
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

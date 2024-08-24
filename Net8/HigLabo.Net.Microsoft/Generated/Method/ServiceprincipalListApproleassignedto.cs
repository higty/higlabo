using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalListApproleassignedtoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_AppRoleAssignedTo: return $"/servicePrincipals/{Id}/appRoleAssignedTo";
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
            ServicePrincipals_Id_AppRoleAssignedTo,
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
    public partial class ServicePrincipalListApproleassignedtoResponse : RestApiResponse<AppRoleAssignment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListApproleassignedtoResponse> ServicePrincipalListApproleassignedtoAsync()
        {
            var p = new ServicePrincipalListApproleassignedtoParameter();
            return await this.SendAsync<ServicePrincipalListApproleassignedtoParameter, ServicePrincipalListApproleassignedtoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListApproleassignedtoResponse> ServicePrincipalListApproleassignedtoAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalListApproleassignedtoParameter();
            return await this.SendAsync<ServicePrincipalListApproleassignedtoParameter, ServicePrincipalListApproleassignedtoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListApproleassignedtoResponse> ServicePrincipalListApproleassignedtoAsync(ServicePrincipalListApproleassignedtoParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalListApproleassignedtoParameter, ServicePrincipalListApproleassignedtoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListApproleassignedtoResponse> ServicePrincipalListApproleassignedtoAsync(ServicePrincipalListApproleassignedtoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalListApproleassignedtoParameter, ServicePrincipalListApproleassignedtoResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignedto?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AppRoleAssignment> ServicePrincipalListApproleassignedtoEnumerateAsync(ServicePrincipalListApproleassignedtoParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ServicePrincipalListApproleassignedtoParameter, ServicePrincipalListApproleassignedtoResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AppRoleAssignment>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

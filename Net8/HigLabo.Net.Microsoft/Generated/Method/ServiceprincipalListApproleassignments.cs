using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalListApproleAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_AppRoleAssignments: return $"/servicePrincipals/{Id}/appRoleAssignments";
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
            ServicePrincipals_Id_AppRoleAssignments,
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
    public partial class ServicePrincipalListApproleAssignmentsResponse : RestApiResponse<AppRoleAssignment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListApproleAssignmentsResponse> ServicePrincipalListApproleAssignmentsAsync()
        {
            var p = new ServicePrincipalListApproleAssignmentsParameter();
            return await this.SendAsync<ServicePrincipalListApproleAssignmentsParameter, ServicePrincipalListApproleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListApproleAssignmentsResponse> ServicePrincipalListApproleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalListApproleAssignmentsParameter();
            return await this.SendAsync<ServicePrincipalListApproleAssignmentsParameter, ServicePrincipalListApproleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListApproleAssignmentsResponse> ServicePrincipalListApproleAssignmentsAsync(ServicePrincipalListApproleAssignmentsParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalListApproleAssignmentsParameter, ServicePrincipalListApproleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListApproleAssignmentsResponse> ServicePrincipalListApproleAssignmentsAsync(ServicePrincipalListApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalListApproleAssignmentsParameter, ServicePrincipalListApproleAssignmentsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AppRoleAssignment> ServicePrincipalListApproleAssignmentsEnumerateAsync(ServicePrincipalListApproleAssignmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ServicePrincipalListApproleAssignmentsParameter, ServicePrincipalListApproleAssignmentsResponse>(parameter, cancellationToken);
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

using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementListAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Assignments: return $"/identityGovernance/entitlementManagement/assignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Assignments,
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
    public partial class EntitlementManagementListAssignmentsResponse : RestApiResponse<AccessPackageAssignment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentsResponse> EntitlementManagementListAssignmentsAsync()
        {
            var p = new EntitlementManagementListAssignmentsParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentsParameter, EntitlementManagementListAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentsResponse> EntitlementManagementListAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementListAssignmentsParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentsParameter, EntitlementManagementListAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentsResponse> EntitlementManagementListAssignmentsAsync(EntitlementManagementListAssignmentsParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentsParameter, EntitlementManagementListAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentsResponse> EntitlementManagementListAssignmentsAsync(EntitlementManagementListAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentsParameter, EntitlementManagementListAssignmentsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessPackageAssignment> EntitlementManagementListAssignmentsEnumerateAsync(EntitlementManagementListAssignmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EntitlementManagementListAssignmentsParameter, EntitlementManagementListAssignmentsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessPackageAssignment>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

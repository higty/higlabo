using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementListAssignmentpoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentPolicies: return $"/identityGovernance/entitlementManagement/assignmentPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentPolicies,
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
    public partial class EntitlementManagementListAssignmentpoliciesResponse : RestApiResponse<AccessPackageAssignmentPolicy>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentpoliciesResponse> EntitlementManagementListAssignmentpoliciesAsync()
        {
            var p = new EntitlementManagementListAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentpoliciesParameter, EntitlementManagementListAssignmentpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentpoliciesResponse> EntitlementManagementListAssignmentpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementListAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentpoliciesParameter, EntitlementManagementListAssignmentpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentpoliciesResponse> EntitlementManagementListAssignmentpoliciesAsync(EntitlementManagementListAssignmentpoliciesParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentpoliciesParameter, EntitlementManagementListAssignmentpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentpoliciesResponse> EntitlementManagementListAssignmentpoliciesAsync(EntitlementManagementListAssignmentpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentpoliciesParameter, EntitlementManagementListAssignmentpoliciesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessPackageAssignmentPolicy> EntitlementManagementListAssignmentpoliciesEnumerateAsync(EntitlementManagementListAssignmentpoliciesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EntitlementManagementListAssignmentpoliciesParameter, EntitlementManagementListAssignmentpoliciesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessPackageAssignmentPolicy>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

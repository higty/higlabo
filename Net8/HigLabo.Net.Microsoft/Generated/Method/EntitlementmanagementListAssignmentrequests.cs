using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementListAssignmentRequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests: return $"/identityGovernance/entitlementManagement/assignmentRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests,
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
    public partial class EntitlementManagementListAssignmentRequestsResponse : RestApiResponse<AccessPackageAssignmentRequest>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentRequestsResponse> EntitlementManagementListAssignmentRequestsAsync()
        {
            var p = new EntitlementManagementListAssignmentRequestsParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentRequestsParameter, EntitlementManagementListAssignmentRequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentRequestsResponse> EntitlementManagementListAssignmentRequestsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementListAssignmentRequestsParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentRequestsParameter, EntitlementManagementListAssignmentRequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentRequestsResponse> EntitlementManagementListAssignmentRequestsAsync(EntitlementManagementListAssignmentRequestsParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentRequestsParameter, EntitlementManagementListAssignmentRequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAssignmentRequestsResponse> EntitlementManagementListAssignmentRequestsAsync(EntitlementManagementListAssignmentRequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentRequestsParameter, EntitlementManagementListAssignmentRequestsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessPackageAssignmentRequest> EntitlementManagementListAssignmentRequestsEnumerateAsync(EntitlementManagementListAssignmentRequestsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EntitlementManagementListAssignmentRequestsParameter, EntitlementManagementListAssignmentRequestsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessPackageAssignmentRequest>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

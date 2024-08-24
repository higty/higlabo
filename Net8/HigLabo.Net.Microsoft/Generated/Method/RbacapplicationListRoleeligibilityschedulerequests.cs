using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
    /// </summary>
    public partial class RbacApplicationListRoleeligibilityScheduleRequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleRequests: return $"/roleManagement/directory/roleEligibilityScheduleRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilityScheduleRequests,
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
    public partial class RbacApplicationListRoleeligibilityScheduleRequestsResponse : RestApiResponse<UnifiedRoleEligibilityScheduleRequest>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleeligibilityScheduleRequestsResponse> RbacApplicationListRoleeligibilityScheduleRequestsAsync()
        {
            var p = new RbacApplicationListRoleeligibilityScheduleRequestsParameter();
            return await this.SendAsync<RbacApplicationListRoleeligibilityScheduleRequestsParameter, RbacApplicationListRoleeligibilityScheduleRequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleeligibilityScheduleRequestsResponse> RbacApplicationListRoleeligibilityScheduleRequestsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacApplicationListRoleeligibilityScheduleRequestsParameter();
            return await this.SendAsync<RbacApplicationListRoleeligibilityScheduleRequestsParameter, RbacApplicationListRoleeligibilityScheduleRequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleeligibilityScheduleRequestsResponse> RbacApplicationListRoleeligibilityScheduleRequestsAsync(RbacApplicationListRoleeligibilityScheduleRequestsParameter parameter)
        {
            return await this.SendAsync<RbacApplicationListRoleeligibilityScheduleRequestsParameter, RbacApplicationListRoleeligibilityScheduleRequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleeligibilityScheduleRequestsResponse> RbacApplicationListRoleeligibilityScheduleRequestsAsync(RbacApplicationListRoleeligibilityScheduleRequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacApplicationListRoleeligibilityScheduleRequestsParameter, RbacApplicationListRoleeligibilityScheduleRequestsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UnifiedRoleEligibilityScheduleRequest> RbacApplicationListRoleeligibilityScheduleRequestsEnumerateAsync(RbacApplicationListRoleeligibilityScheduleRequestsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<RbacApplicationListRoleeligibilityScheduleRequestsParameter, RbacApplicationListRoleeligibilityScheduleRequestsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<UnifiedRoleEligibilityScheduleRequest>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

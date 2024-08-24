using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public partial class RbacApplicationListRoleAssignmentScheduleinstancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleInstances: return $"/roleManagement/directory/roleAssignmentScheduleInstances";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleInstances,
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
    public partial class RbacApplicationListRoleAssignmentScheduleinstancesResponse : RestApiResponse<UnifiedRoleAssignmentScheduleInstance>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleAssignmentScheduleinstancesResponse> RbacApplicationListRoleAssignmentScheduleinstancesAsync()
        {
            var p = new RbacApplicationListRoleAssignmentScheduleinstancesParameter();
            return await this.SendAsync<RbacApplicationListRoleAssignmentScheduleinstancesParameter, RbacApplicationListRoleAssignmentScheduleinstancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleAssignmentScheduleinstancesResponse> RbacApplicationListRoleAssignmentScheduleinstancesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacApplicationListRoleAssignmentScheduleinstancesParameter();
            return await this.SendAsync<RbacApplicationListRoleAssignmentScheduleinstancesParameter, RbacApplicationListRoleAssignmentScheduleinstancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleAssignmentScheduleinstancesResponse> RbacApplicationListRoleAssignmentScheduleinstancesAsync(RbacApplicationListRoleAssignmentScheduleinstancesParameter parameter)
        {
            return await this.SendAsync<RbacApplicationListRoleAssignmentScheduleinstancesParameter, RbacApplicationListRoleAssignmentScheduleinstancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleAssignmentScheduleinstancesResponse> RbacApplicationListRoleAssignmentScheduleinstancesAsync(RbacApplicationListRoleAssignmentScheduleinstancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacApplicationListRoleAssignmentScheduleinstancesParameter, RbacApplicationListRoleAssignmentScheduleinstancesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UnifiedRoleAssignmentScheduleInstance> RbacApplicationListRoleAssignmentScheduleinstancesEnumerateAsync(RbacApplicationListRoleAssignmentScheduleinstancesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<RbacApplicationListRoleAssignmentScheduleinstancesParameter, RbacApplicationListRoleAssignmentScheduleinstancesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<UnifiedRoleAssignmentScheduleInstance>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

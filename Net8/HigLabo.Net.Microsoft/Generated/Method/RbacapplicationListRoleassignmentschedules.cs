using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
    /// </summary>
    public partial class RbacApplicationListRoleAssignmentSchedulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentSchedules: return $"/roleManagement/directory/roleAssignmentSchedules";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentSchedules,
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
    public partial class RbacApplicationListRoleAssignmentSchedulesResponse : RestApiResponse<UnifiedRoleAssignmentSchedule>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleAssignmentSchedulesResponse> RbacApplicationListRoleAssignmentSchedulesAsync()
        {
            var p = new RbacApplicationListRoleAssignmentSchedulesParameter();
            return await this.SendAsync<RbacApplicationListRoleAssignmentSchedulesParameter, RbacApplicationListRoleAssignmentSchedulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleAssignmentSchedulesResponse> RbacApplicationListRoleAssignmentSchedulesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacApplicationListRoleAssignmentSchedulesParameter();
            return await this.SendAsync<RbacApplicationListRoleAssignmentSchedulesParameter, RbacApplicationListRoleAssignmentSchedulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleAssignmentSchedulesResponse> RbacApplicationListRoleAssignmentSchedulesAsync(RbacApplicationListRoleAssignmentSchedulesParameter parameter)
        {
            return await this.SendAsync<RbacApplicationListRoleAssignmentSchedulesParameter, RbacApplicationListRoleAssignmentSchedulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleAssignmentSchedulesResponse> RbacApplicationListRoleAssignmentSchedulesAsync(RbacApplicationListRoleAssignmentSchedulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacApplicationListRoleAssignmentSchedulesParameter, RbacApplicationListRoleAssignmentSchedulesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UnifiedRoleAssignmentSchedule> RbacApplicationListRoleAssignmentSchedulesEnumerateAsync(RbacApplicationListRoleAssignmentSchedulesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<RbacApplicationListRoleAssignmentSchedulesParameter, RbacApplicationListRoleAssignmentSchedulesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<UnifiedRoleAssignmentSchedule>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

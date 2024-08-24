using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
    /// </summary>
    public partial class RbacApplicationListRoleeligibilitySchedulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilitySchedules: return $"/roleManagement/directory/roleEligibilitySchedules";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilitySchedules,
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
    public partial class RbacApplicationListRoleeligibilitySchedulesResponse : RestApiResponse<UnifiedRoleEligibilitySchedule>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleeligibilitySchedulesResponse> RbacApplicationListRoleeligibilitySchedulesAsync()
        {
            var p = new RbacApplicationListRoleeligibilitySchedulesParameter();
            return await this.SendAsync<RbacApplicationListRoleeligibilitySchedulesParameter, RbacApplicationListRoleeligibilitySchedulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleeligibilitySchedulesResponse> RbacApplicationListRoleeligibilitySchedulesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacApplicationListRoleeligibilitySchedulesParameter();
            return await this.SendAsync<RbacApplicationListRoleeligibilitySchedulesParameter, RbacApplicationListRoleeligibilitySchedulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleeligibilitySchedulesResponse> RbacApplicationListRoleeligibilitySchedulesAsync(RbacApplicationListRoleeligibilitySchedulesParameter parameter)
        {
            return await this.SendAsync<RbacApplicationListRoleeligibilitySchedulesParameter, RbacApplicationListRoleeligibilitySchedulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleeligibilitySchedulesResponse> RbacApplicationListRoleeligibilitySchedulesAsync(RbacApplicationListRoleeligibilitySchedulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacApplicationListRoleeligibilitySchedulesParameter, RbacApplicationListRoleeligibilitySchedulesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UnifiedRoleEligibilitySchedule> RbacApplicationListRoleeligibilitySchedulesEnumerateAsync(RbacApplicationListRoleeligibilitySchedulesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<RbacApplicationListRoleeligibilitySchedulesParameter, RbacApplicationListRoleeligibilitySchedulesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<UnifiedRoleEligibilitySchedule>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

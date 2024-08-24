using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleRequests_FilterByCurrentUser: return $"/roleManagement/directory/roleEligibilityScheduleRequests/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilityScheduleRequests_FilterByCurrentUser,
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
    public partial class UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse : RestApiResponse<UnifiedRoleEligibilityScheduleRequest>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleRequestFilterbycurrentUserAsync()
        {
            var p = new UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleRequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleRequestFilterbycurrentUserAsync(UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse> UnifiedroleeligibilityScheduleRequestFilterbycurrentUserAsync(UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UnifiedRoleEligibilityScheduleRequest> UnifiedroleeligibilityScheduleRequestFilterbycurrentUserEnumerateAsync(UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UnifiedroleeligibilityScheduleRequestFilterbycurrentUserParameter, UnifiedroleeligibilityScheduleRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
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

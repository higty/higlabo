using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
    /// </summary>
    public partial class UserListCalendarGroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_CalendarGroups: return $"/me/calendarGroups";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups: return $"/users/{IdOrUserPrincipalName}/calendarGroups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_CalendarGroups,
            Users_IdOrUserPrincipalName_CalendarGroups,
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
    public partial class UserListCalendarGroupsResponse : RestApiResponse<CalendarGroup>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListCalendarGroupsResponse> UserListCalendarGroupsAsync()
        {
            var p = new UserListCalendarGroupsParameter();
            return await this.SendAsync<UserListCalendarGroupsParameter, UserListCalendarGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListCalendarGroupsResponse> UserListCalendarGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListCalendarGroupsParameter();
            return await this.SendAsync<UserListCalendarGroupsParameter, UserListCalendarGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListCalendarGroupsResponse> UserListCalendarGroupsAsync(UserListCalendarGroupsParameter parameter)
        {
            return await this.SendAsync<UserListCalendarGroupsParameter, UserListCalendarGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListCalendarGroupsResponse> UserListCalendarGroupsAsync(UserListCalendarGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListCalendarGroupsParameter, UserListCalendarGroupsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<CalendarGroup> UserListCalendarGroupsEnumerateAsync(UserListCalendarGroupsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListCalendarGroupsParameter, UserListCalendarGroupsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<CalendarGroup>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

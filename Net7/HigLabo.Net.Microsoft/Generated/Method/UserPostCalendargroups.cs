using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
    /// </summary>
    public partial class UserPostCalendarGroupsParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Name { get; set; }
        public string? ChangeKey { get; set; }
        public Guid? ClassId { get; set; }
        public string? Id { get; set; }
        public Calendar[]? Calendars { get; set; }
    }
    public partial class UserPostCalendarGroupsResponse : RestApiResponse
    {
        public string? Name { get; set; }
        public string? ChangeKey { get; set; }
        public Guid? ClassId { get; set; }
        public string? Id { get; set; }
        public Calendar[]? Calendars { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserPostCalendarGroupsResponse> UserPostCalendarGroupsAsync()
        {
            var p = new UserPostCalendarGroupsParameter();
            return await this.SendAsync<UserPostCalendarGroupsParameter, UserPostCalendarGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserPostCalendarGroupsResponse> UserPostCalendarGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostCalendarGroupsParameter();
            return await this.SendAsync<UserPostCalendarGroupsParameter, UserPostCalendarGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserPostCalendarGroupsResponse> UserPostCalendarGroupsAsync(UserPostCalendarGroupsParameter parameter)
        {
            return await this.SendAsync<UserPostCalendarGroupsParameter, UserPostCalendarGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserPostCalendarGroupsResponse> UserPostCalendarGroupsAsync(UserPostCalendarGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostCalendarGroupsParameter, UserPostCalendarGroupsResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserPostCalendargroupsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_CalendarGroups,
            Users_IdOrUserPrincipalName_CalendarGroups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_CalendarGroups: return $"/me/calendarGroups";
                    case ApiPath.Users_IdOrUserPrincipalName_CalendarGroups: return $"/users/{IdOrUserPrincipalName}/calendarGroups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserPostCalendargroupsResponse : RestApiResponse
    {
        public string? Name { get; set; }
        public string? ChangeKey { get; set; }
        public Guid? ClassId { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostCalendargroupsResponse> UserPostCalendargroupsAsync()
        {
            var p = new UserPostCalendargroupsParameter();
            return await this.SendAsync<UserPostCalendargroupsParameter, UserPostCalendargroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostCalendargroupsResponse> UserPostCalendargroupsAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostCalendargroupsParameter();
            return await this.SendAsync<UserPostCalendargroupsParameter, UserPostCalendargroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostCalendargroupsResponse> UserPostCalendargroupsAsync(UserPostCalendargroupsParameter parameter)
        {
            return await this.SendAsync<UserPostCalendargroupsParameter, UserPostCalendargroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostCalendargroupsResponse> UserPostCalendargroupsAsync(UserPostCalendargroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostCalendargroupsParameter, UserPostCalendargroupsResponse>(parameter, cancellationToken);
        }
    }
}

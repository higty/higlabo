using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListCalendargroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserListCalendargroupsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/calendargroup?view=graph-rest-1.0
        /// </summary>
        public partial class CalendarGroup
        {
            public string? Name { get; set; }
            public string? ChangeKey { get; set; }
            public Guid? ClassId { get; set; }
            public string? Id { get; set; }
        }

        public CalendarGroup[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendargroupsResponse> UserListCalendargroupsAsync()
        {
            var p = new UserListCalendargroupsParameter();
            return await this.SendAsync<UserListCalendargroupsParameter, UserListCalendargroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendargroupsResponse> UserListCalendargroupsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListCalendargroupsParameter();
            return await this.SendAsync<UserListCalendargroupsParameter, UserListCalendargroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendargroupsResponse> UserListCalendargroupsAsync(UserListCalendargroupsParameter parameter)
        {
            return await this.SendAsync<UserListCalendargroupsParameter, UserListCalendargroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-calendargroups?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCalendargroupsResponse> UserListCalendargroupsAsync(UserListCalendargroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListCalendargroupsParameter, UserListCalendargroupsResponse>(parameter, cancellationToken);
        }
    }
}

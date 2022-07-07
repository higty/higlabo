using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserReminderviewParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_ReminderView,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_ReminderView: return $"/users/{IdOrUserPrincipalName}/reminderView";
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
    public partial class UserReminderviewResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/reminder?view=graph-rest-1.0
        /// </summary>
        public partial class Reminder
        {
            public string? ChangeKey { get; set; }
            public DateTimeTimeZone? EventEndTime { get; set; }
            public string? EventId { get; set; }
            public Location? EventLocation { get; set; }
            public DateTimeTimeZone? EventStartTime { get; set; }
            public string? EventSubject { get; set; }
            public string? EventWebLink { get; set; }
            public DateTimeTimeZone? ReminderFireTime { get; set; }
        }

        public Reminder[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
        /// </summary>
        public async Task<UserReminderviewResponse> UserReminderviewAsync()
        {
            var p = new UserReminderviewParameter();
            return await this.SendAsync<UserReminderviewParameter, UserReminderviewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
        /// </summary>
        public async Task<UserReminderviewResponse> UserReminderviewAsync(CancellationToken cancellationToken)
        {
            var p = new UserReminderviewParameter();
            return await this.SendAsync<UserReminderviewParameter, UserReminderviewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
        /// </summary>
        public async Task<UserReminderviewResponse> UserReminderviewAsync(UserReminderviewParameter parameter)
        {
            return await this.SendAsync<UserReminderviewParameter, UserReminderviewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
        /// </summary>
        public async Task<UserReminderviewResponse> UserReminderviewAsync(UserReminderviewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserReminderviewParameter, UserReminderviewResponse>(parameter, cancellationToken);
        }
    }
}

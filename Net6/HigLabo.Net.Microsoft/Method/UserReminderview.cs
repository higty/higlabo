using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserReminderviewParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_ReminderView: return $"/users/{IdOrUserPrincipalName}/reminderView";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_ReminderView,
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
    public partial class UserReminderviewResponse : RestApiResponse
    {
        public Reminder[]? Value { get; set; }
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

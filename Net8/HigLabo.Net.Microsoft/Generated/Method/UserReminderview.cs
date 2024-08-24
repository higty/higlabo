using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
    /// </summary>
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
    public partial class UserReminderviewResponse : RestApiResponse<Reminder>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserReminderviewResponse> UserReminderviewAsync()
        {
            var p = new UserReminderviewParameter();
            return await this.SendAsync<UserReminderviewParameter, UserReminderviewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserReminderviewResponse> UserReminderviewAsync(CancellationToken cancellationToken)
        {
            var p = new UserReminderviewParameter();
            return await this.SendAsync<UserReminderviewParameter, UserReminderviewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserReminderviewResponse> UserReminderviewAsync(UserReminderviewParameter parameter)
        {
            return await this.SendAsync<UserReminderviewParameter, UserReminderviewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserReminderviewResponse> UserReminderviewAsync(UserReminderviewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserReminderviewParameter, UserReminderviewResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-reminderview?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Reminder> UserReminderviewEnumerateAsync(UserReminderviewParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserReminderviewParameter, UserReminderviewResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Reminder>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

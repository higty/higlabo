using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodotasklistUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TodoTaskListId { get; set; }
            public string IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId: return $"/me/todo/lists/{TodoTaskListId}";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
    }
    public partial class TodotasklistUpdateResponse : RestApiResponse
    {
        public enum TodoTaskListWellknownListName
        {
            None,
            DefaultList,
            FlaggedEmails,
            UnknownFutureValue,
        }

        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsShared { get; set; }
        public TodoTaskListWellknownListName WellknownListName { get; set; }
        public Extension[]? Extensions { get; set; }
        public TodoTask[]? Tasks { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistUpdateResponse> TodotasklistUpdateAsync()
        {
            var p = new TodotasklistUpdateParameter();
            return await this.SendAsync<TodotasklistUpdateParameter, TodotasklistUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistUpdateResponse> TodotasklistUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TodotasklistUpdateParameter();
            return await this.SendAsync<TodotasklistUpdateParameter, TodotasklistUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistUpdateResponse> TodotasklistUpdateAsync(TodotasklistUpdateParameter parameter)
        {
            return await this.SendAsync<TodotasklistUpdateParameter, TodotasklistUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistUpdateResponse> TodotasklistUpdateAsync(TodotasklistUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotasklistUpdateParameter, TodotasklistUpdateResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
    /// </summary>
    public partial class TodoPostListsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists: return $"/me/todo/lists";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists: return $"/users/{IdOrUserPrincipalName}/todo/lists";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum TodoTaskListWellknownListName
        {
            None,
            DefaultList,
            FlaggedEmails,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            Me_Todo_Lists,
            Users_IdOruserPrincipalName_Todo_Lists,
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
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsShared { get; set; }
        public TodoTaskListWellknownListName WellknownListName { get; set; }
        public Extension[]? Extensions { get; set; }
        public TodoTask[]? Tasks { get; set; }
    }
    public partial class TodoPostListsResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodoPostListsResponse> TodoPostListsAsync()
        {
            var p = new TodoPostListsParameter();
            return await this.SendAsync<TodoPostListsParameter, TodoPostListsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodoPostListsResponse> TodoPostListsAsync(CancellationToken cancellationToken)
        {
            var p = new TodoPostListsParameter();
            return await this.SendAsync<TodoPostListsParameter, TodoPostListsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodoPostListsResponse> TodoPostListsAsync(TodoPostListsParameter parameter)
        {
            return await this.SendAsync<TodoPostListsParameter, TodoPostListsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TodoPostListsResponse> TodoPostListsAsync(TodoPostListsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodoPostListsParameter, TodoPostListsResponse>(parameter, cancellationToken);
        }
    }
}

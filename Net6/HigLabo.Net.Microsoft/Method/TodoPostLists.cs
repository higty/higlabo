using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodoPostListsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Todo_Lists,
            Users_IdOruserPrincipalName_Todo_Lists,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Todo_Lists: return $"/me/todo/lists";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists: return $"/users/{IdOrUserPrincipalName}/todo/lists";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string IdOrUserPrincipalName { get; set; }
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
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
        /// </summary>
        public async Task<TodoPostListsResponse> TodoPostListsAsync()
        {
            var p = new TodoPostListsParameter();
            return await this.SendAsync<TodoPostListsParameter, TodoPostListsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
        /// </summary>
        public async Task<TodoPostListsResponse> TodoPostListsAsync(CancellationToken cancellationToken)
        {
            var p = new TodoPostListsParameter();
            return await this.SendAsync<TodoPostListsParameter, TodoPostListsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
        /// </summary>
        public async Task<TodoPostListsResponse> TodoPostListsAsync(TodoPostListsParameter parameter)
        {
            return await this.SendAsync<TodoPostListsParameter, TodoPostListsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todo-post-lists?view=graph-rest-1.0
        /// </summary>
        public async Task<TodoPostListsResponse> TodoPostListsAsync(TodoPostListsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodoPostListsParameter, TodoPostListsResponse>(parameter, cancellationToken);
        }
    }
}

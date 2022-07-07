using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodoListListsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class TodoListListsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/todotasklist?view=graph-rest-1.0
        /// </summary>
        public partial class TodoTaskList
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

        public TodoTaskList[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
        /// </summary>
        public async Task<TodoListListsResponse> TodoListListsAsync()
        {
            var p = new TodoListListsParameter();
            return await this.SendAsync<TodoListListsParameter, TodoListListsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
        /// </summary>
        public async Task<TodoListListsResponse> TodoListListsAsync(CancellationToken cancellationToken)
        {
            var p = new TodoListListsParameter();
            return await this.SendAsync<TodoListListsParameter, TodoListListsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
        /// </summary>
        public async Task<TodoListListsResponse> TodoListListsAsync(TodoListListsParameter parameter)
        {
            return await this.SendAsync<TodoListListsParameter, TodoListListsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
        /// </summary>
        public async Task<TodoListListsResponse> TodoListListsAsync(TodoListListsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodoListListsParameter, TodoListListsResponse>(parameter, cancellationToken);
        }
    }
}

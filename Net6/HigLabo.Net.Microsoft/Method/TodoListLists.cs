using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodoListListsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            DisplayName,
            Id,
            IsOwner,
            IsShared,
            WellknownListName,
            Extensions,
            Tasks,
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
    public partial class TodoListListsResponse : RestApiResponse
    {
        public TodoTaskList[]? Value { get; set; }
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

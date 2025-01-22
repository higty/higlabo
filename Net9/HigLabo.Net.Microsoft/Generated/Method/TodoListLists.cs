using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
/// </summary>
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
public partial class TodoListListsResponse : RestApiResponse<TodoTaskList>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodoListListsResponse> TodoListListsAsync()
    {
        var p = new TodoListListsParameter();
        return await this.SendAsync<TodoListListsParameter, TodoListListsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodoListListsResponse> TodoListListsAsync(CancellationToken cancellationToken)
    {
        var p = new TodoListListsParameter();
        return await this.SendAsync<TodoListListsParameter, TodoListListsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodoListListsResponse> TodoListListsAsync(TodoListListsParameter parameter)
    {
        return await this.SendAsync<TodoListListsParameter, TodoListListsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodoListListsResponse> TodoListListsAsync(TodoListListsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TodoListListsParameter, TodoListListsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todo-list-lists?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<TodoTaskList> TodoListListsEnumerateAsync(TodoListListsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<TodoListListsParameter, TodoListListsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<TodoTaskList>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}

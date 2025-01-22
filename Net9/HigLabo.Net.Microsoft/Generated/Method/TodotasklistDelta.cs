using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
/// </summary>
public partial class TodotasklistDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Todo_Lists_Delta: return $"/me/todo/lists/delta";
                case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_Delta: return $"/users/{IdOrUserPrincipalName}/todo/lists/delta";
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
        Me_Todo_Lists_Delta,
        Users_IdOruserPrincipalName_Todo_Lists_Delta,
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
public partial class TodotasklistDeltaResponse : RestApiResponse
{
    public TodoTaskList[]? Value { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodotasklistDeltaResponse> TodotasklistDeltaAsync()
    {
        var p = new TodotasklistDeltaParameter();
        return await this.SendAsync<TodotasklistDeltaParameter, TodotasklistDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodotasklistDeltaResponse> TodotasklistDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new TodotasklistDeltaParameter();
        return await this.SendAsync<TodotasklistDeltaParameter, TodotasklistDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodotasklistDeltaResponse> TodotasklistDeltaAsync(TodotasklistDeltaParameter parameter)
    {
        return await this.SendAsync<TodotasklistDeltaParameter, TodotasklistDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodotasklistDeltaResponse> TodotasklistDeltaAsync(TodotasklistDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TodotasklistDeltaParameter, TodotasklistDeltaResponse>(parameter, cancellationToken);
    }
}

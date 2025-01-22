using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/todotask-delta?view=graph-rest-1.0
/// </summary>
public partial class TodotaskDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? TodoTaskListId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Todo_Lists_Id_Tasks_Delta: return $"/me/todo/lists/{Id}/tasks/delta";
                case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_Delta: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
        Body,
        BodyLastModifiedDateTime,
        Categories,
        CompletedDateTime,
        CreatedDateTime,
        DueDateTime,
        HasAttachments,
        Id,
        Importance,
        IsReminderOn,
        LastModifiedDateTime,
        Recurrence,
        ReminderDateTime,
        StartDateTime,
        Status,
        Title,
        Attachments,
        ChecklistItems,
        Extensions,
        LinkedResources,
    }
    public enum ApiPath
    {
        Me_Todo_Lists_Id_Tasks_Delta,
        Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_Delta,
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
public partial class TodotaskDeltaResponse : RestApiResponse
{
    public TodoTask[]? Value { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/todotask-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodotaskDeltaResponse> TodotaskDeltaAsync()
    {
        var p = new TodotaskDeltaParameter();
        return await this.SendAsync<TodotaskDeltaParameter, TodotaskDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodotaskDeltaResponse> TodotaskDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new TodotaskDeltaParameter();
        return await this.SendAsync<TodotaskDeltaParameter, TodotaskDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodotaskDeltaResponse> TodotaskDeltaAsync(TodotaskDeltaParameter parameter)
    {
        return await this.SendAsync<TodotaskDeltaParameter, TodotaskDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotask-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TodotaskDeltaResponse> TodotaskDeltaAsync(TodotaskDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TodotaskDeltaParameter, TodotaskDeltaResponse>(parameter, cancellationToken);
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/opentypeextension-delete?view=graph-rest-1.0
/// </summary>
public partial class OpenTypeExtensionDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? ExtensionId { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? GroupsId { get; set; }
        public string? EventsId { get; set; }
        public string? ExtensionsExtensionId { get; set; }
        public string? ThreadsId { get; set; }
        public string? PostsId { get; set; }
        public string? TodoTaskListId { get; set; }
        public string? TaskId { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Devices_Id_Extensions_ExtensionId: return $"/devices/{Id}/extensions/{ExtensionId}";
                case ApiPath.Users_IdOruserPrincipalName_Events_Id_Extensions_ExtensionId: return $"/users/{IdOrUserPrincipalName}/events/{Id}/extensions/{ExtensionId}";
                case ApiPath.Groups_Id_Extensions_ExtensionId: return $"/groups/{Id}/extensions/{ExtensionId}";
                case ApiPath.Groups_Id_Events_Id_Extensions_ExtensionId: return $"/groups/{GroupsId}/events/{EventsId}/extensions/{ExtensionsExtensionId}";
                case ApiPath.Groups_Id_Threads_Id_Posts_Id_Extensions_ExtensionId: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/extensions/{ExtensionsExtensionId}";
                case ApiPath.Users_IdOruserPrincipalName_Messages_Id_Extensions_ExtensionId: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/extensions/{ExtensionId}";
                case ApiPath.Organization_Id_Extensions_ExtensionId: return $"/organization/{Id}/extensions/{ExtensionId}";
                case ApiPath.Users_IdOruserPrincipalName_Contacts_Id_Extensions_ExtensionId: return $"/users/{IdOrUserPrincipalName}/contacts/{Id}/extensions/{ExtensionId}";
                case ApiPath.Users_IdOruserPrincipalName_Extensions_ExtensionId: return $"/users/{IdOrUserPrincipalName}/extensions/{ExtensionId}";
                case ApiPath.Me_Todo_Lists_TodoTaskListId_Extensions_ExtensionId: return $"/me/todo/lists/{TodoTaskListId}/extensions/{ExtensionId}";
                case ApiPath.Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_Extensions_ExtensionId: return $"/me/todo/lists/{TodoTaskListId}/tasks/{TaskId}/extensions/{ExtensionId}";
                case ApiPath.Users_UserId_Todo_Lists_TodoTaskListId_Extensions_ExtensionId: return $"/users/{UserId}/todo/lists/{TodoTaskListId}/extensions/{ExtensionId}";
                case ApiPath.Users_UserId_Todo_Lists_TodoTaskListId_Tasks_TaskId_Extensions_ExtensionId: return $"/users/{UserId}/todo/lists/{TodoTaskListId}/tasks/{TaskId}/extensions/{ExtensionId}";
                case ApiPath.Me_Extensions_ExtensionId: return $"/me/extensions/{ExtensionId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Devices_Id_Extensions_ExtensionId,
        Users_IdOruserPrincipalName_Events_Id_Extensions_ExtensionId,
        Groups_Id_Extensions_ExtensionId,
        Groups_Id_Events_Id_Extensions_ExtensionId,
        Groups_Id_Threads_Id_Posts_Id_Extensions_ExtensionId,
        Users_IdOruserPrincipalName_Messages_Id_Extensions_ExtensionId,
        Organization_Id_Extensions_ExtensionId,
        Users_IdOruserPrincipalName_Contacts_Id_Extensions_ExtensionId,
        Users_IdOruserPrincipalName_Extensions_ExtensionId,
        Me_Todo_Lists_TodoTaskListId_Extensions_ExtensionId,
        Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_Extensions_ExtensionId,
        Users_UserId_Todo_Lists_TodoTaskListId_Extensions_ExtensionId,
        Users_UserId_Todo_Lists_TodoTaskListId_Tasks_TaskId_Extensions_ExtensionId,
        Me_Extensions_ExtensionId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class OpenTypeExtensionDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/opentypeextension-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenTypeExtensionDeleteResponse> OpenTypeExtensionDeleteAsync()
    {
        var p = new OpenTypeExtensionDeleteParameter();
        return await this.SendAsync<OpenTypeExtensionDeleteParameter, OpenTypeExtensionDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenTypeExtensionDeleteResponse> OpenTypeExtensionDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new OpenTypeExtensionDeleteParameter();
        return await this.SendAsync<OpenTypeExtensionDeleteParameter, OpenTypeExtensionDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenTypeExtensionDeleteResponse> OpenTypeExtensionDeleteAsync(OpenTypeExtensionDeleteParameter parameter)
    {
        return await this.SendAsync<OpenTypeExtensionDeleteParameter, OpenTypeExtensionDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenTypeExtensionDeleteResponse> OpenTypeExtensionDeleteAsync(OpenTypeExtensionDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OpenTypeExtensionDeleteParameter, OpenTypeExtensionDeleteResponse>(parameter, cancellationToken);
    }
}

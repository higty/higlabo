using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-update?view=graph-rest-1.0
    /// </summary>
    public partial class OpenTypeextensionUpdateParameter : IRestApiParameter
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
                    case ApiPath.Users_Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_Extensions_ExtensionId: return $"/users/me/todo/lists/{TodoTaskListId}/tasks/{TaskId}/extensions/{ExtensionId}";
                    case ApiPath.Users_Me_Todo_Lists_TodoTaskListId_Extensions_ExtensionId: return $"/users/me/todo/lists/{TodoTaskListId}/extensions/{ExtensionId}";
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
            Users_Me_Todo_Lists_TodoTaskListId_Tasks_TaskId_Extensions_ExtensionId,
            Users_Me_Todo_Lists_TodoTaskListId_Extensions_ExtensionId,
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
        public string? ExtensionName { get; set; }
    }
    public partial class OpenTypeextensionUpdateResponse : RestApiResponse
    {
        public string? ExtensionName { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenTypeextensionUpdateResponse> OpenTypeextensionUpdateAsync()
        {
            var p = new OpenTypeextensionUpdateParameter();
            return await this.SendAsync<OpenTypeextensionUpdateParameter, OpenTypeextensionUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenTypeextensionUpdateResponse> OpenTypeextensionUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OpenTypeextensionUpdateParameter();
            return await this.SendAsync<OpenTypeextensionUpdateParameter, OpenTypeextensionUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenTypeextensionUpdateResponse> OpenTypeextensionUpdateAsync(OpenTypeextensionUpdateParameter parameter)
        {
            return await this.SendAsync<OpenTypeextensionUpdateParameter, OpenTypeextensionUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenTypeextensionUpdateResponse> OpenTypeextensionUpdateAsync(OpenTypeextensionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenTypeextensionUpdateParameter, OpenTypeextensionUpdateResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-get?view=graph-rest-1.0
    /// </summary>
    public partial class OpenTypeextensionGetParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_Extensions_ExtensionId: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{TaskId}/extensions/{ExtensionId}";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Extensions_ExtensionId: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/extensions/{ExtensionId}";
                    case ApiPath.Users_IdOruserPrincipalName_Events_Id: return $"/users/{IdOrUserPrincipalName}/events/{Id}";
                    case ApiPath.Groups_Id_Events_Id: return $"/groups/{GroupsId}/events/{EventsId}";
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}";
                    case ApiPath.Users_IdOruserPrincipalName_Messages_Id: return $"/users/{IdOrUserPrincipalName}/messages/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_Contacts_Id: return $"/users/{IdOrUserPrincipalName}/contacts/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_Id: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}/tasks/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_Id: return $"/users/{IdOrUserPrincipalName}/todo/lists/{Id}";
                    case ApiPath.Devices_Id: return $"/devices/{Id}";
                    case ApiPath.Groups_Id: return $"/groups/{Id}";
                    case ApiPath.Organization_Id: return $"/organization/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName: return $"/users/{IdOrUserPrincipalName}";
                    case ApiPath.Users_IdOruserPrincipalName_Events: return $"/users/{IdOrUserPrincipalName}/events";
                    case ApiPath.Groups_Id_Events: return $"/groups/{Id}/events";
                    case ApiPath.Groups_Id_Threads_Id_Posts: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts";
                    case ApiPath.Users_IdOruserPrincipalName_Messages: return $"/users/{IdOrUserPrincipalName}/messages";
                    case ApiPath.Users_IdOruserPrincipalName_Contacts: return $"/users/{IdOrUserPrincipalName}/contacts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
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
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_TaskId_Extensions_ExtensionId,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Extensions_ExtensionId,
            Users_IdOruserPrincipalName_Events_Id,
            Groups_Id_Events_Id,
            Groups_Id_Threads_Id_Posts_Id,
            Users_IdOruserPrincipalName_Messages_Id,
            Users_IdOruserPrincipalName_Contacts_Id,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId_Tasks_Id,
            Users_IdOruserPrincipalName_Todo_Lists_Id,
            Devices_Id,
            Groups_Id,
            Organization_Id,
            Users_IdOruserPrincipalName,
            Users_IdOruserPrincipalName_Events,
            Groups_Id_Events,
            Groups_Id_Threads_Id_Posts,
            Users_IdOruserPrincipalName_Messages,
            Users_IdOruserPrincipalName_Contacts,
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
    public partial class OpenTypeextensionGetResponse : RestApiResponse
    {
        public string? ExtensionName { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenTypeextensionGetResponse> OpenTypeextensionGetAsync()
        {
            var p = new OpenTypeextensionGetParameter();
            return await this.SendAsync<OpenTypeextensionGetParameter, OpenTypeextensionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenTypeextensionGetResponse> OpenTypeextensionGetAsync(CancellationToken cancellationToken)
        {
            var p = new OpenTypeextensionGetParameter();
            return await this.SendAsync<OpenTypeextensionGetParameter, OpenTypeextensionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenTypeextensionGetResponse> OpenTypeextensionGetAsync(OpenTypeextensionGetParameter parameter)
        {
            return await this.SendAsync<OpenTypeextensionGetParameter, OpenTypeextensionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/opentypeextension-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenTypeextensionGetResponse> OpenTypeextensionGetAsync(OpenTypeextensionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenTypeextensionGetParameter, OpenTypeextensionGetResponse>(parameter, cancellationToken);
        }
    }
}

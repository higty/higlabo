using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenTypeextensionPostOpenTypeextensionParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string Id { get; set; }
            public string GroupsId { get; set; }
            public string ThreadsId { get; set; }
            public string PostsId { get; set; }
            public string EventsId { get; set; }
            public string UsersIdOrUserPrincipalName { get; set; }
            public string ListsId { get; set; }
            public string TasksId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_IdOruserPrincipalName_Events: return $"/users/{IdOrUserPrincipalName}/events";
                    case ApiPath.Users_IdOruserPrincipalName_Messages: return $"/users/{IdOrUserPrincipalName}/messages";
                    case ApiPath.Groups_Id_Events: return $"/groups/{Id}/events";
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id_Reply: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/reply";
                    case ApiPath.Users_IdOruserPrincipalName_Contacts: return $"/users/{IdOrUserPrincipalName}/contacts";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_Id_Tasks: return $"/users/{IdOrUserPrincipalName}/todo/lists/{Id}/tasks";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists: return $"/users/{IdOrUserPrincipalName}/todo/lists";
                    case ApiPath.Devices_Id_Extensions: return $"/devices/{Id}/extensions";
                    case ApiPath.Users_IdOruserPrincipalName_Events_Id_Extensions: return $"/users/{IdOrUserPrincipalName}/events/{Id}/extensions";
                    case ApiPath.Groups_Id_Extensions: return $"/groups/{Id}/extensions";
                    case ApiPath.Groups_Id_Events_Id_Extensions: return $"/groups/{GroupsId}/events/{EventsId}/extensions";
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id_Extensions: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/extensions";
                    case ApiPath.Users_IdOruserPrincipalName_Messages_Id_Extensions: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/extensions";
                    case ApiPath.Organization_Id_Extensions: return $"/organization/{Id}/extensions";
                    case ApiPath.Users_IdOruserPrincipalName_Contacts_Id_Extensions: return $"/users/{IdOrUserPrincipalName}/contacts/{Id}/extensions";
                    case ApiPath.Users_IdOruserPrincipalName_Extensions: return $"/users/{IdOrUserPrincipalName}/extensions";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_Id_Tasks_Id_Extensions: return $"/users/{UsersIdOrUserPrincipalName}/todo/lists/{ListsId}/tasks/{TasksId}/extensions";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_Id_Extensions: return $"/users/{IdOrUserPrincipalName}/todo/lists/{Id}/extensions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_IdOruserPrincipalName_Events,
            Users_IdOruserPrincipalName_Messages,
            Groups_Id_Events,
            Groups_Id_Threads_Id_Posts_Id_Reply,
            Users_IdOruserPrincipalName_Contacts,
            Users_IdOruserPrincipalName_Todo_Lists_Id_Tasks,
            Users_IdOruserPrincipalName_Todo_Lists,
            Devices_Id_Extensions,
            Users_IdOruserPrincipalName_Events_Id_Extensions,
            Groups_Id_Extensions,
            Groups_Id_Events_Id_Extensions,
            Groups_Id_Threads_Id_Posts_Id_Extensions,
            Users_IdOruserPrincipalName_Messages_Id_Extensions,
            Organization_Id_Extensions,
            Users_IdOruserPrincipalName_Contacts_Id_Extensions,
            Users_IdOruserPrincipalName_Extensions,
            Users_IdOruserPrincipalName_Todo_Lists_Id_Tasks_Id_Extensions,
            Users_IdOruserPrincipalName_Todo_Lists_Id_Extensions,
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
        public string? ExtensionName { get; set; }
    }
    public partial class OpenTypeextensionPostOpenTypeextensionResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/opentypeextension-post-opentypeextension?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenTypeextensionPostOpenTypeextensionResponse> OpenTypeextensionPostOpenTypeextensionAsync()
        {
            var p = new OpenTypeextensionPostOpenTypeextensionParameter();
            return await this.SendAsync<OpenTypeextensionPostOpenTypeextensionParameter, OpenTypeextensionPostOpenTypeextensionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/opentypeextension-post-opentypeextension?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenTypeextensionPostOpenTypeextensionResponse> OpenTypeextensionPostOpenTypeextensionAsync(CancellationToken cancellationToken)
        {
            var p = new OpenTypeextensionPostOpenTypeextensionParameter();
            return await this.SendAsync<OpenTypeextensionPostOpenTypeextensionParameter, OpenTypeextensionPostOpenTypeextensionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/opentypeextension-post-opentypeextension?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenTypeextensionPostOpenTypeextensionResponse> OpenTypeextensionPostOpenTypeextensionAsync(OpenTypeextensionPostOpenTypeextensionParameter parameter)
        {
            return await this.SendAsync<OpenTypeextensionPostOpenTypeextensionParameter, OpenTypeextensionPostOpenTypeextensionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/opentypeextension-post-opentypeextension?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenTypeextensionPostOpenTypeextensionResponse> OpenTypeextensionPostOpenTypeextensionAsync(OpenTypeextensionPostOpenTypeextensionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenTypeextensionPostOpenTypeextensionParameter, OpenTypeextensionPostOpenTypeextensionResponse>(parameter, cancellationToken);
        }
    }
}

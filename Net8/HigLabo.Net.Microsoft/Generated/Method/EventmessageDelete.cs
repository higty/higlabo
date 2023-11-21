using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/eventmessage-delete?view=graph-rest-1.0
    /// </summary>
    public partial class EventmessageDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? MailFoldersId { get; set; }
            public string? MessagesId { get; set; }
            public string? UsersIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Messages_Id: return $"/me/messages/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id: return $"/users/{IdOrUserPrincipalName}/messages/{Id}";
                    case ApiPath.Me_MailFolders_Id_Messages_Id: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id: return $"/users/{UsersIdOrUserPrincipalName}/mailFolders/{MailFoldersId}/messages/{MessagesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Messages_Id,
            Users_IdOrUserPrincipalName_Messages_Id,
            Me_MailFolders_Id_Messages_Id,
            Users_IdOrUserPrincipalName_MailFolders_Id_Messages_Id,
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
    public partial class EventmessageDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/eventmessage-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventmessageDeleteResponse> EventmessageDeleteAsync()
        {
            var p = new EventmessageDeleteParameter();
            return await this.SendAsync<EventmessageDeleteParameter, EventmessageDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventmessageDeleteResponse> EventmessageDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EventmessageDeleteParameter();
            return await this.SendAsync<EventmessageDeleteParameter, EventmessageDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventmessageDeleteResponse> EventmessageDeleteAsync(EventmessageDeleteParameter parameter)
        {
            return await this.SendAsync<EventmessageDeleteParameter, EventmessageDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventmessageDeleteResponse> EventmessageDeleteAsync(EventmessageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventmessageDeleteParameter, EventmessageDeleteResponse>(parameter, cancellationToken);
        }
    }
}

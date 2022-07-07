using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Messages,
            Users_IdOruserPrincipalName_Messages,
            Me_MailFolders_Id_Messages,
            Me_MailFolders,
            Users_IdOruserPrincipalName_MailFolders,
            Me_Events,
            Users_IdOruserPrincipalName_Events,
            Me_Calendars,
            Users_IdOruserPrincipalName_Calendars,
            Me_Contacts,
            Users_IdOruserPrincipalName_Contacts,
            Me_ContactFolders,
            Users_IdOruserPrincipalName_ContactFolders,
            Groups_Id_Events,
            Groups_Id_Threads_Id_Posts_Id_Reply,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Reply,
            Groups_Id_Threads_Id_Reply,
            Groups_Id_Conversations_Id_Threads_Id_Reply,
            Groups_Id_Threads,
            Groups_Id_Conversations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Messages: return $"/me/messages";
                    case ApiPath.Users_IdOruserPrincipalName_Messages: return $"/users/{IdOrUserPrincipalName}/messages";
                    case ApiPath.Me_MailFolders_Id_Messages: return $"/me/mailFolders/{Id}/messages";
                    case ApiPath.Me_MailFolders: return $"/me/mailFolders";
                    case ApiPath.Users_IdOruserPrincipalName_MailFolders: return $"/users/{IdOrUserPrincipalName}/mailFolders";
                    case ApiPath.Me_Events: return $"/me/events";
                    case ApiPath.Users_IdOruserPrincipalName_Events: return $"/users/{IdOrUserPrincipalName}/events";
                    case ApiPath.Me_Calendars: return $"/me/calendars";
                    case ApiPath.Users_IdOruserPrincipalName_Calendars: return $"/users/{IdOrUserPrincipalName}/calendars";
                    case ApiPath.Me_Contacts: return $"/me/contacts";
                    case ApiPath.Users_IdOruserPrincipalName_Contacts: return $"/users/{IdOrUserPrincipalName}/contacts";
                    case ApiPath.Me_ContactFolders: return $"/me/contactFolders";
                    case ApiPath.Users_IdOruserPrincipalName_ContactFolders: return $"/users/{IdOrUserPrincipalName}/contactFolders";
                    case ApiPath.Groups_Id_Events: return $"/groups/{Id}/events";
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id_Reply: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}/reply";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Posts_Id_Reply: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/posts/{PostsId}/reply";
                    case ApiPath.Groups_Id_Threads_Id_Reply: return $"/groups/{GroupsId}/threads/{ThreadsId}/reply";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Reply: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/reply";
                    case ApiPath.Groups_Id_Threads: return $"/groups/{Id}/threads";
                    case ApiPath.Groups_Id_Conversations: return $"/groups/{Id}/conversations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public string? Id { get; set; }
        public string? Value { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string ThreadsId { get; set; }
        public string PostsId { get; set; }
        public string ConversationsId { get; set; }
    }
    public partial class MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/multivaluelegacyextendedproperty-post-multivalueextendedproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesResponse> MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesAsync()
        {
            var p = new MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesParameter();
            return await this.SendAsync<MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesParameter, MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/multivaluelegacyextendedproperty-post-multivalueextendedproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesResponse> MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesAsync(CancellationToken cancellationToken)
        {
            var p = new MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesParameter();
            return await this.SendAsync<MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesParameter, MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/multivaluelegacyextendedproperty-post-multivalueextendedproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesResponse> MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesAsync(MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesParameter parameter)
        {
            return await this.SendAsync<MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesParameter, MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/multivaluelegacyextendedproperty-post-multivalueextendedproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesResponse> MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesAsync(MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesParameter, MultivaluelegacyextendedpropertyPostMultivalueextendedpropertiesResponse>(parameter, cancellationToken);
        }
    }
}

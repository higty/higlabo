using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MultivaluelegacyextendedpropertyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Messages_Id,
            Users_IdOruserPrincipalName_Messages_Id,
            Me_MailFolders_Id_Messages_Id,
            Me_MailFolders_Id,
            Users_IdOruserPrincipalName_MailFolders_Id,
            Me_Events_Id,
            Users_IdOruserPrincipalName_Events_Id,
            Me_Calendars_Id,
            Users_IdOruserPrincipalName_Calendars_Id,
            Me_Contacts_Id,
            Users_IdOruserPrincipalName_Contacts_Id,
            Me_ContactFolders_Id_Contacts_Id,
            Users_IdOruserPrincipalName_ContactFolders_Id_Contacts_Id,
            Me_Contactfolders_Id,
            Users_IdOruserPrincipalName_ContactFolders_Id,
            Groups_Id_Events_Id,
            Groups_Id_Threads_Id_Posts_Id,
            Groups_Id_Conversations_Id_Threads_Id_Posts_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Messages_Id: return $"/me/messages/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_Messages_Id: return $"/users/{IdOrUserPrincipalName}/messages/{Id}";
                    case ApiPath.Me_MailFolders_Id_Messages_Id: return $"/me/mailFolders/{MailFoldersId}/messages/{MessagesId}";
                    case ApiPath.Me_MailFolders_Id: return $"/me/mailFolders/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_MailFolders_Id: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}";
                    case ApiPath.Me_Events_Id: return $"/me/events/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_Events_Id: return $"/users/{IdOrUserPrincipalName}/events/{Id}";
                    case ApiPath.Me_Calendars_Id: return $"/me/calendars/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_Calendars_Id: return $"/users/{IdOrUserPrincipalName}/calendars/{Id}";
                    case ApiPath.Me_Contacts_Id: return $"/me/contacts/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_Contacts_Id: return $"/users/{IdOrUserPrincipalName}/contacts/{Id}";
                    case ApiPath.Me_ContactFolders_Id_Contacts_Id: return $"/me/contactFolders/{ContactFoldersId}/contacts/{ContactsId}";
                    case ApiPath.Users_IdOruserPrincipalName_ContactFolders_Id_Contacts_Id: return $"/users/{UsersIdOrUserPrincipalName}/contactFolders/{ContactFoldersId}/contacts/{ContactsId}";
                    case ApiPath.Me_Contactfolders_Id: return $"/me/contactfolders/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_ContactFolders_Id: return $"/users/{IdOrUserPrincipalName}/contactFolders/{Id}";
                    case ApiPath.Groups_Id_Events_Id: return $"/groups/{GroupsId}/events/{EventsId}";
                    case ApiPath.Groups_Id_Threads_Id_Posts_Id: return $"/groups/{GroupsId}/threads/{ThreadsId}/posts/{PostsId}";
                    case ApiPath.Groups_Id_Conversations_Id_Threads_Id_Posts_Id: return $"/groups/{GroupsId}/conversations/{ConversationsId}/threads/{ThreadsId}/posts/{PostsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string MailFoldersId { get; set; }
        public string MessagesId { get; set; }
        public string ContactFoldersId { get; set; }
        public string ContactsId { get; set; }
        public string UsersIdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string EventsId { get; set; }
        public string ThreadsId { get; set; }
        public string PostsId { get; set; }
        public string ConversationsId { get; set; }
    }
    public partial class MultivaluelegacyextendedpropertyGetResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/multivaluelegacyextendedproperty-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MultivaluelegacyextendedpropertyGetResponse> MultivaluelegacyextendedpropertyGetAsync()
        {
            var p = new MultivaluelegacyextendedpropertyGetParameter();
            return await this.SendAsync<MultivaluelegacyextendedpropertyGetParameter, MultivaluelegacyextendedpropertyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/multivaluelegacyextendedproperty-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MultivaluelegacyextendedpropertyGetResponse> MultivaluelegacyextendedpropertyGetAsync(CancellationToken cancellationToken)
        {
            var p = new MultivaluelegacyextendedpropertyGetParameter();
            return await this.SendAsync<MultivaluelegacyextendedpropertyGetParameter, MultivaluelegacyextendedpropertyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/multivaluelegacyextendedproperty-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MultivaluelegacyextendedpropertyGetResponse> MultivaluelegacyextendedpropertyGetAsync(MultivaluelegacyextendedpropertyGetParameter parameter)
        {
            return await this.SendAsync<MultivaluelegacyextendedpropertyGetParameter, MultivaluelegacyextendedpropertyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/multivaluelegacyextendedproperty-get?view=graph-rest-1.0
        /// </summary>
        public async Task<MultivaluelegacyextendedpropertyGetResponse> MultivaluelegacyextendedpropertyGetAsync(MultivaluelegacyextendedpropertyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MultivaluelegacyextendedpropertyGetParameter, MultivaluelegacyextendedpropertyGetResponse>(parameter, cancellationToken);
        }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventmessageListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Messages_Id_Attachments,
            Users_IdOrUserPrincipalName_Messages_Id_Attachments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Messages_Id_Attachments: return $"/me/messages/{Id}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Attachments: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/attachments";
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
    }
    public partial class EventmessageListAttachmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/attachment?view=graph-rest-1.0
        /// </summary>
        public partial class Attachment
        {
            public string? ContentType { get; set; }
            public string? Id { get; set; }
            public bool? IsInline { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Name { get; set; }
            public Int32? Size { get; set; }
        }

        public Attachment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessageListAttachmentsResponse> EventmessageListAttachmentsAsync()
        {
            var p = new EventmessageListAttachmentsParameter();
            return await this.SendAsync<EventmessageListAttachmentsParameter, EventmessageListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessageListAttachmentsResponse> EventmessageListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EventmessageListAttachmentsParameter();
            return await this.SendAsync<EventmessageListAttachmentsParameter, EventmessageListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessageListAttachmentsResponse> EventmessageListAttachmentsAsync(EventmessageListAttachmentsParameter parameter)
        {
            return await this.SendAsync<EventmessageListAttachmentsParameter, EventmessageListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessageListAttachmentsResponse> EventmessageListAttachmentsAsync(EventmessageListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventmessageListAttachmentsParameter, EventmessageListAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}

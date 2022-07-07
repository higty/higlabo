using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventmessagePostAttachmentsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class EventmessagePostAttachmentsResponse : RestApiResponse
    {
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public bool? IsInline { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessagePostAttachmentsResponse> EventmessagePostAttachmentsAsync()
        {
            var p = new EventmessagePostAttachmentsParameter();
            return await this.SendAsync<EventmessagePostAttachmentsParameter, EventmessagePostAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessagePostAttachmentsResponse> EventmessagePostAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EventmessagePostAttachmentsParameter();
            return await this.SendAsync<EventmessagePostAttachmentsParameter, EventmessagePostAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessagePostAttachmentsResponse> EventmessagePostAttachmentsAsync(EventmessagePostAttachmentsParameter parameter)
        {
            return await this.SendAsync<EventmessagePostAttachmentsParameter, EventmessagePostAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessagePostAttachmentsResponse> EventmessagePostAttachmentsAsync(EventmessagePostAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventmessagePostAttachmentsParameter, EventmessagePostAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}

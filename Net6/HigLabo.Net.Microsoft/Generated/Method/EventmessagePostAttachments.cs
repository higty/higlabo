using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class EventmessagePostAttachmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Messages_Id_Attachments: return $"/me/messages/{Id}/attachments";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Attachments: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/attachments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Messages_Id_Attachments,
            Users_IdOrUserPrincipalName_Messages_Id_Attachments,
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
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public bool? IsInline { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessagePostAttachmentsResponse> EventmessagePostAttachmentsAsync()
        {
            var p = new EventmessagePostAttachmentsParameter();
            return await this.SendAsync<EventmessagePostAttachmentsParameter, EventmessagePostAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessagePostAttachmentsResponse> EventmessagePostAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EventmessagePostAttachmentsParameter();
            return await this.SendAsync<EventmessagePostAttachmentsParameter, EventmessagePostAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessagePostAttachmentsResponse> EventmessagePostAttachmentsAsync(EventmessagePostAttachmentsParameter parameter)
        {
            return await this.SendAsync<EventmessagePostAttachmentsParameter, EventmessagePostAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-post-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<EventmessagePostAttachmentsResponse> EventmessagePostAttachmentsAsync(EventmessagePostAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventmessagePostAttachmentsParameter, EventmessagePostAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}

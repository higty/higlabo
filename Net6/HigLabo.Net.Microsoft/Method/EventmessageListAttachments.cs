using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventmessageListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }

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

        public enum Field
        {
            ContentType,
            Id,
            IsInline,
            LastModifiedDateTime,
            Name,
            Size,
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
    public partial class EventmessageListAttachmentsResponse : RestApiResponse
    {
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

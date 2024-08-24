using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class EventmessageListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class EventmessageListAttachmentsResponse : RestApiResponse<Attachment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventmessageListAttachmentsResponse> EventmessageListAttachmentsAsync()
        {
            var p = new EventmessageListAttachmentsParameter();
            return await this.SendAsync<EventmessageListAttachmentsParameter, EventmessageListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventmessageListAttachmentsResponse> EventmessageListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EventmessageListAttachmentsParameter();
            return await this.SendAsync<EventmessageListAttachmentsParameter, EventmessageListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventmessageListAttachmentsResponse> EventmessageListAttachmentsAsync(EventmessageListAttachmentsParameter parameter)
        {
            return await this.SendAsync<EventmessageListAttachmentsParameter, EventmessageListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EventmessageListAttachmentsResponse> EventmessageListAttachmentsAsync(EventmessageListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventmessageListAttachmentsParameter, EventmessageListAttachmentsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/eventmessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Attachment> EventmessageListAttachmentsEnumerateAsync(EventmessageListAttachmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EventmessageListAttachmentsParameter, EventmessageListAttachmentsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Attachment>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

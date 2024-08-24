using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceupdatemessageListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ServiceUpdateMessageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId_Attachments: return $"/admin/serviceAnnouncement/messages/{ServiceUpdateMessageId}/attachments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId_Attachments,
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
    public partial class ServiceupdatemessageListAttachmentsResponse : RestApiResponse<ServiceAnnouncementAttachment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageListAttachmentsResponse> ServiceupdatemessageListAttachmentsAsync()
        {
            var p = new ServiceupdatemessageListAttachmentsParameter();
            return await this.SendAsync<ServiceupdatemessageListAttachmentsParameter, ServiceupdatemessageListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageListAttachmentsResponse> ServiceupdatemessageListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageListAttachmentsParameter();
            return await this.SendAsync<ServiceupdatemessageListAttachmentsParameter, ServiceupdatemessageListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageListAttachmentsResponse> ServiceupdatemessageListAttachmentsAsync(ServiceupdatemessageListAttachmentsParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageListAttachmentsParameter, ServiceupdatemessageListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageListAttachmentsResponse> ServiceupdatemessageListAttachmentsAsync(ServiceupdatemessageListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageListAttachmentsParameter, ServiceupdatemessageListAttachmentsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ServiceAnnouncementAttachment> ServiceupdatemessageListAttachmentsEnumerateAsync(ServiceupdatemessageListAttachmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ServiceupdatemessageListAttachmentsParameter, ServiceupdatemessageListAttachmentsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ServiceAnnouncementAttachment>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}

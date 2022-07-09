using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/serviceupdatemessage?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceUpdateMessage
    {
        public enum ServiceUpdateMessageServiceUpdateCategory
        {
            PreventOrFixIssue,
            PlanForChange,
            StayInformed,
            UnknownFutureValue,
        }
        public enum ServiceUpdateMessageServiceUpdateSeverity
        {
            Normal,
            High,
            Critical,
            UnknownFutureValue,
        }

        public DateTimeOffset? ActionRequiredByDateTime { get; set; }
        public Stream? AttachmentsArchive { get; set; }
        public ItemBody? Body { get; set; }
        public ServiceUpdateMessageServiceUpdateCategory Category { get; set; }
        public KeyValuePair[]? Details { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public bool? HasAttachments { get; set; }
        public string? Id { get; set; }
        public bool? IsMajorChange { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public String[]? Services { get; set; }
        public ServiceUpdateMessageServiceUpdateSeverity Severity { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public String[]? Tags { get; set; }
        public string? Title { get; set; }
        public ServiceUpdateMessageViewpoint? ViewPoint { get; set; }
        public ServiceAnnouncementAttachment[]? Attachments { get; set; }
    }
}

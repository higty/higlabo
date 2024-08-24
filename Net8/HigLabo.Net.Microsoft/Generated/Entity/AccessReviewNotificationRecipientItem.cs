using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewnotificationrecipientitem?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewNotificationRecipientItem
    {
        public AccessReviewnotificationrecipientscope? NotificationRecipientScope { get; set; }
        public string? NotificationTemplateType { get; set; }
    }
}

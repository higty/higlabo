using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewnotificationrecipientitem?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewNotificationRecipientItem
    {
        public string NotificationTemplateType { get; set; }
        public Accessreviewnotificationrecipientscope NotificationRecipientScope { get; set; }
    }
}

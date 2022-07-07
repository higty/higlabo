using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-notification-notificationmessagetemplate?view=graph-rest-1.0
    /// </summary>
    public partial class NotificationMessageTemplate
    {
        public enum NotificationMessageTemplateNotificationTemplateBrandingOptions
        {
            None,
            IncludeCompanyLogo,
            IncludeCompanyName,
            IncludeContactInformation,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? DefaultLocale { get; set; }
        public NotificationTemplateBrandingOptions? BrandingOptions { get; set; }
    }
}

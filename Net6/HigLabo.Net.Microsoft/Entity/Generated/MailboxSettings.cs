using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/mailboxsettings?view=graph-rest-1.0
    /// </summary>
    public partial class MailboxSettings
    {
        public String? ArchiveFolder { get; set; }
        public AutomaticRepliesSetting? AutomaticRepliesSetting { get; set; }
        public String? DateFormat { get; set; }
        public MailboxSettingsDelegateMeetingMessageDeliveryOptions DelegateMeetingMessageDeliveryOptions { get; set; }
        public LocaleInfo? Language { get; set; }
        public String? TimeFormat { get; set; }
        public String? TimeZone { get; set; }
        public WorkingHours? WorkingHours { get; set; }
    }
}

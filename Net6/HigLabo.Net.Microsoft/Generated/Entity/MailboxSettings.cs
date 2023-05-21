using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/mailboxsettings?view=graph-rest-1.0
    /// </summary>
    public partial class MailboxSettings
    {
        public enum MailboxSettingsDelegateMeetingMessageDeliveryOptions
        {
            SendToDelegateAndInformationToPrincipal,
            SendToDelegateAndPrincipal,
            SendToDelegateOnly,
        }
        public enum MailboxSettingsUserPurpose
        {
            User,
            Linked,
            Shared,
            Room,
            Equipment,
            Others,
            UnknownFutureValue,
        }

        public string? ArchiveFolder { get; set; }
        public AutomaticRepliesSetting? AutomaticRepliesSetting { get; set; }
        public string? DateFormat { get; set; }
        public MailboxSettingsDelegateMeetingMessageDeliveryOptions DelegateMeetingMessageDeliveryOptions { get; set; }
        public LocaleInfo? Language { get; set; }
        public string? TimeFormat { get; set; }
        public string? TimeZone { get; set; }
        public MailboxSettingsUserPurpose UserPurpose { get; set; }
        public WorkingHours? WorkingHours { get; set; }
    }
}

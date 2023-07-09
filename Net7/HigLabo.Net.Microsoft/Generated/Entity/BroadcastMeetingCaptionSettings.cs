using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/broadcastmeetingcaptionsettings?view=graph-rest-1.0
    /// </summary>
    public partial class BroadcastMeetingCaptionSettings
    {
        public bool? IsCaptionEnabled { get; set; }
        public string? SpokenLanguage { get; set; }
        public String[]? TranslationLanguages { get; set; }
    }
}

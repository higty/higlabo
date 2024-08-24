using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/search-answervariant?view=graph-rest-1.0
    /// </summary>
    public partial class AnswerVariant
    {
        public enum AnswerVariantDevicePlatformType
        {
            Android,
            AndroidForWork,
            Ios,
            MacOS,
            WindowsPhone81,
            WindowsPhone81AndLater,
            Windows10AndLater,
            AndroidWorkProfile,
            Unknown,
            AndroidASOP,
            AndroidMobileApplicationManagement,
            IOSMobileApplicationManagement,
            UnknownFutureValue,
        }

        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? LanguageTag { get; set; }
        public AnswerVariantDevicePlatformType Platform { get; set; }
        public string? WebUrl { get; set; }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/endusernotificationsetting?view=graph-rest-1.0
    /// </summary>
    public partial class EndUserNotificationSetting
    {
        public enum EndUserNotificationSettingEndUserNotificationPreference
        {
            Unknown,
            Microsoft,
            Custom,
            UnknownFutureValue,
        }
        public enum EndUserNotificationSettingEndUserNotificationSettingType
        {
            Unknown,
            NoTraining,
            TrainingSelected,
            NoNotification,
            UnknownFutureValue,
        }

        public EndUserNotificationSettingEndUserNotificationPreference NotificationPreference { get; set; }
        public PositiveReinforcementNotification? PositiveReinforcement { get; set; }
        public EndUserNotificationSettingEndUserNotificationSettingType SettingType { get; set; }
    }
}

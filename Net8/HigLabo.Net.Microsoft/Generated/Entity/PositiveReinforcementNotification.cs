using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/positivereinforcementnotification?view=graph-rest-1.0
    /// </summary>
    public partial class PositiveReinforcementNotification
    {
        public enum PositiveReinforcementNotificationNotificationDeliveryPreference
        {
            Unknown,
            DeliverImmedietly,
            DeliverAfterCampaignEnd,
            UnknownFutureValue,
        }

        public string? DefaultLanguage { get; set; }
        public PositiveReinforcementNotificationNotificationDeliveryPreference DeliveryPreference { get; set; }
        public EndUserNotification? EndUserNotification { get; set; }
    }
}

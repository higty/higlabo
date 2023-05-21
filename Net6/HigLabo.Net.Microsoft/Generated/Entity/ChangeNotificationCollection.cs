using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/changenotificationcollection?view=graph-rest-1.0
    /// </summary>
    public partial class ChangeNotificationCollection
    {
        public String[]? ValidationTokens { get; set; }
        public ChangeNotification[]? Value { get; set; }
    }
}

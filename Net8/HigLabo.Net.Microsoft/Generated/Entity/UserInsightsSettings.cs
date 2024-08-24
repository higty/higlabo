using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/userinsightssettings?view=graph-rest-1.0
    /// </summary>
    public partial class UserInsightsSettings
    {
        public bool? IsEnabled { get; set; }
    }
}

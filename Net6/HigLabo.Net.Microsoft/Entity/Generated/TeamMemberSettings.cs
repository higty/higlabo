using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/teammembersettings?view=graph-rest-1.0
    /// </summary>
    public partial class TeamMemberSettings
    {
        public bool? AllowAddRemoveApps { get; set; }
        public bool? AllowCreatePrivateChannels { get; set; }
        public bool? AllowCreateUpdateChannels { get; set; }
        public bool? AllowCreateUpdateRemoveConnectors { get; set; }
        public bool? AllowCreateUpdateRemoveTabs { get; set; }
        public bool? AllowDeleteChannels { get; set; }
    }
}

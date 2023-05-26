using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/teamclasssettings?view=graph-rest-1.0
    /// </summary>
    public partial class TeamClassSettings
    {
        public bool? NotifyGuardiansAboutAssignments { get; set; }
    }
}

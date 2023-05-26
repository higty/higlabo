using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/persistentbrowsersessioncontrol?view=graph-rest-1.0
    /// </summary>
    public partial class PersistentBrowserSessionControl
    {
        public enum PersistentBrowserSessionControlPersistentBrowserSessionMode
        {
            Always,
            Never,
        }

        public bool? IsEnabled { get; set; }
        public PersistentBrowserSessionControlPersistentBrowserSessionMode Mode { get; set; }
    }
}

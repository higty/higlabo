using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-macoscustomconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class MacOSCustomConfiguration
    {
        public string Id { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string PayloadName { get; set; }
        public string PayloadFileName { get; set; }
        public string Payload { get; set; }
    }
}

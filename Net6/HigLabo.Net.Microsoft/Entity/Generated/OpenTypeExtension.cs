using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/opentypeextension?view=graph-rest-1.0
    /// </summary>
    public partial class OpenTypeExtension
    {
        public string ExtensionName { get; set; }
        public string Id { get; set; }
    }
}

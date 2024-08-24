using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/customextensionclientconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class CustomExtensionClientConfiguration
    {
        public Int32? TimeoutInMilliseconds { get; set; }
        public Int32? MaximumRetries { get; set; }
    }
}

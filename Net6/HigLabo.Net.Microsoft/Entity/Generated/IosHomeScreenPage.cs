using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-ioshomescreenpage?view=graph-rest-1.0
    /// </summary>
    public partial class IosHomeScreenPage
    {
        public string DisplayName { get; set; }
        public IosHomeScreenItem[] Icons { get; set; }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-ioshomescreenfolderpage?view=graph-rest-1.0
    /// </summary>
    public partial class IosHomeScreenFolderPage
    {
        public string DisplayName { get; set; }
        public IosHomeScreenApp[] Apps { get; set; }
    }
}

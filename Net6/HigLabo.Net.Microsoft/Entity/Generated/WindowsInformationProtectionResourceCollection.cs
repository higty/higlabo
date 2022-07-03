using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-windowsinformationprotectionresourcecollection?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsInformationProtectionResourceCollection
    {
        public string DisplayName { get; set; }
        public String[] Resources { get; set; }
    }
}

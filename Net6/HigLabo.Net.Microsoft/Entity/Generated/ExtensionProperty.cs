using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/extensionproperty?view=graph-rest-1.0
    /// </summary>
    public partial class ExtensionProperty
    {
        public string AppDisplayName { get; set; }
        public string DataType { get; set; }
        public DateTimeOffset DeletedDateTime { get; set; }
        public bool IsSyncedFromOnPremises { get; set; }
        public string Name { get; set; }
        public String[] TargetObjects { get; set; }
    }
}

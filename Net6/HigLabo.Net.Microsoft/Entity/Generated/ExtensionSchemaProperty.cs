using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/extensionschemaproperty?view=graph-rest-1.0
    /// </summary>
    public partial class ExtensionSchemaProperty
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
}

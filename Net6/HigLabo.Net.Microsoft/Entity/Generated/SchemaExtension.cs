using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/schemaextension?view=graph-rest-1.0
    /// </summary>
    public partial class SchemaExtension
    {
        public string Description { get; set; }
        public string Id { get; set; }
        public string Owner { get; set; }
        public ExtensionSchemaProperty[] Properties { get; set; }
        public string Status { get; set; }
        public String[] TargetTypes { get; set; }
    }
}

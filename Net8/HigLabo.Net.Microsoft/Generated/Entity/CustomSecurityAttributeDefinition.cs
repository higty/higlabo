using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/customsecurityattributedefinition?view=graph-rest-1.0
    /// </summary>
    public partial class CustomSecurityAttributeDefinition
    {
        public string? AttributeSet { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public bool? IsCollection { get; set; }
        public bool? IsSearchable { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
        public bool? UsePreDefinedValuesOnly { get; set; }
        public AllowedValue[]? AllowedValues { get; set; }
    }
}

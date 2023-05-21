using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/userattributevaluesitem?view=graph-rest-1.0
    /// </summary>
    public partial class UserAttributeValuesItem
    {
        public bool? IsDefault { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
}

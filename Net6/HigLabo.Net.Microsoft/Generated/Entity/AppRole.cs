using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/approle?view=graph-rest-1.0
    /// </summary>
    public partial class AppRole
    {
        public String[]? AllowedMemberTypes { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Guid? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public string? Origin { get; set; }
        public string? Value { get; set; }
    }
}

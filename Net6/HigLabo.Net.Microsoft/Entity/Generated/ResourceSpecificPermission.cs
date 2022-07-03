using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/resourcespecificpermission?view=graph-rest-1.0
    /// </summary>
    public partial class ResourceSpecificPermission
    {
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public Guid? Id { get; set; }
        public bool IsEnabled { get; set; }
        public string Value { get; set; }
    }
}

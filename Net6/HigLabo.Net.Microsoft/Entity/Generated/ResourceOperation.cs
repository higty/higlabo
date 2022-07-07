using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-rbac-resourceoperation?view=graph-rest-1.0
    /// </summary>
    public partial class ResourceOperation
    {
        public string? Id { get; set; }
        public string? ResourceName { get; set; }
        public string? ActionName { get; set; }
        public string? Description { get; set; }
    }
}

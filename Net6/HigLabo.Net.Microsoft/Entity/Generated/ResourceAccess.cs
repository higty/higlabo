using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/resourceaccess?view=graph-rest-1.0
    /// </summary>
    public partial class ResourceAccess
    {
        public Guid? Id { get; set; }
        public string? Type { get; set; }
    }
}

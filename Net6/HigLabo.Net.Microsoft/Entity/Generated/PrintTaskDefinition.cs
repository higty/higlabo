using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printtaskdefinition?view=graph-rest-1.0
    /// </summary>
    public partial class PrintTaskDefinition
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public AppIdentity? CreatedBy { get; set; }
    }
}

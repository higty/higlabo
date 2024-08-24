using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/connectedorganizationmembers?view=graph-rest-1.0
    /// </summary>
    public partial class ConnectedOrganizationMembers
    {
        public string? ConnectedOrganizationId { get; set; }
        public string? Description { get; set; }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/assignedlabel?view=graph-rest-1.0
    /// </summary>
    public partial class AssignedLabel
    {
        public string? DisplayName { get; set; }
        public string? LabelId { get; set; }
    }
}

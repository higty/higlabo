using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/assignedlicense?view=graph-rest-1.0
    /// </summary>
    public partial class AssignedLicense
    {
        public Guid[] DisabledPlans { get; set; }
        public Guid? SkuId { get; set; }
    }
}

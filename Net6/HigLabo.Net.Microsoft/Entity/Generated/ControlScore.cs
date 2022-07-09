using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/controlscore?view=graph-rest-1.0
    /// </summary>
    public partial class ControlScore
    {
        public string? ControlName { get; set; }
        public Double? Score { get; set; }
        public string? ControlCategory { get; set; }
        public string? Description { get; set; }
    }
}

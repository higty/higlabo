using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-retentiondurationindays?view=graph-rest-1.0
    /// </summary>
    public partial class RetentionDurationInDays
    {
        public Int32? Days { get; set; }
    }
}

using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/conditionalaccessapplications?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessApplications
    {
        public String[] IncludeApplications { get; set; }
        public String[] ExcludeApplications { get; set; }
        public String[] IncludeUserActions { get; set; }
    }
}

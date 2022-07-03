using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/conditionalaccessusers?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessUsers
    {
        public String[] IncludeUsers { get; set; }
        public String[] ExcludeUsers { get; set; }
        public String[] IncludeGroups { get; set; }
        public String[] ExcludeGroups { get; set; }
        public String[] IncludeRoles { get; set; }
        public String[] ExcludeRoles { get; set; }
    }
}

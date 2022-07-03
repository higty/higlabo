using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/conditionalaccessclientapplications?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessClientApplications
    {
        public String[] ExcludeServicePrincipals { get; set; }
        public String[] IncludeServicePrincipals { get; set; }
    }
}

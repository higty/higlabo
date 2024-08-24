using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/termsofusecontainer?view=graph-rest-1.0
    /// </summary>
    public partial class TermsOfUseContainer
    {
        public AgreementAcceptance[]? AgreementAcceptances { get; set; }
        public Agreement[]? Agreements { get; set; }
    }
}

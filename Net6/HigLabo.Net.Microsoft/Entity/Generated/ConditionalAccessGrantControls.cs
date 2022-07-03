using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/conditionalaccessgrantcontrols?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessGrantControls
    {
        public string Operator { get; set; }
        public ConditionalAccessGrantControlsConditionalAccessGrantControl BuiltInControls { get; set; }
        public String[] CustomAuthenticationFactors { get; set; }
        public String[] TermsOfUse { get; set; }
    }
}

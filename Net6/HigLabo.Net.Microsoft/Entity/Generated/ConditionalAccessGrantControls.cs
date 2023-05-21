using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccessgrantcontrols?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessGrantControls
    {
        public enum ConditionalAccessGrantControlsConditionalAccessGrantControl
        {
            Block,
            Mfa,
            CompliantDevice,
            DomainJoinedDevice,
            ApprovedApplication,
            CompliantApplication,
            PasswordChange,
            UnknownFutureValue,
        }

        public ConditionalAccessGrantControlsConditionalAccessGrantControl BuiltInControls { get; set; }
        public String[]? CustomAuthenticationFactors { get; set; }
        public string? Operator { get; set; }
        public String[]? TermsOfUse { get; set; }
        public AuthenticationStrengthPolicy? AuthenticationStrength { get; set; }
    }
}

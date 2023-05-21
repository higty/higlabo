using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/signinfrequencysessioncontrol?view=graph-rest-1.0
    /// </summary>
    public partial class SignInFrequencySessionControl
    {
        public enum SignInFrequencySessionControlSignInFrequencyAuthenticationType
        {
            PrimaryAndSecondaryAuthentication,
            SecondaryAuthentication,
            UnknownFutureValue,
        }
        public enum SignInFrequencySessionControlSignInFrequencyInterval
        {
            TimeBased,
            EveryTime,
            UnknownFutureValue,
        }
        public enum SignInFrequencySessionControlSigninFrequencyType
        {
            Days,
            Hours,
        }

        public SignInFrequencySessionControlSignInFrequencyAuthenticationType AuthenticationType { get; set; }
        public SignInFrequencySessionControlSignInFrequencyInterval FrequencyInterval { get; set; }
        public bool? IsEnabled { get; set; }
        public SignInFrequencySessionControlSigninFrequencyType Type { get; set; }
        public Int32? Value { get; set; }
    }
}

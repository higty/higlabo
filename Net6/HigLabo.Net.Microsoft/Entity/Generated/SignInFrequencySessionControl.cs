using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/signinfrequencysessioncontrol?view=graph-rest-1.0
    /// </summary>
    public partial class SignInFrequencySessionControl
    {
        public enum SignInFrequencySessionControlSigninFrequencyType
        {
            Days,
            Hours,
        }

        public bool? IsEnabled { get; set; }
        public SignInFrequencySessionControlSigninFrequencyType Type { get; set; }
        public Int32? Value { get; set; }
    }
}

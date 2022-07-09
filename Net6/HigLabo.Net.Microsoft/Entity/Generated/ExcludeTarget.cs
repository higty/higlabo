using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/excludetarget?view=graph-rest-1.0
    /// </summary>
    public partial class ExcludeTarget
    {
        public enum ExcludeTargetAuthenticationMethodTargetType
        {
            User,
            Group,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public ExcludeTargetAuthenticationMethodTargetType TargetType { get; set; }
    }
}
